using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Subscriptions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddSubscriptionForm : SchoolManagement.UI.EditSubscriptionForm
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPrintService printService;
        private StudentEnrolling selectedEnrolling;
        private readonly List<SubscriptionFee> selectedFeeList;
        public AddSubscriptionForm(ISubscriptionService subscriptionService,ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp, IPrintService printService)
        {
            this.subscriptionService = subscriptionService;
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            selectedFeeList = Program.SubscriptionFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id).OrderBy(x => x.CashFlowType.Sequence).ToList();
            this.SubscriptionDropDownList.DataSource = selectedFeeList.Select(x => x.CashFlowType);
            this.SubscriptionDropDownList.SelectedIndex = -1;
            InitEvents();
            
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            this.SubscriptionDropDownList.SelectedValueChanged += SubscriptionDropDownList_SelectedValueChanged;
        }
        private void StudentDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.StudentDropDownList.SelectedItem != null)
            {
                if (this.StudentDropDownList.SelectedItem.DataBoundItem is Student student)
                {
                    this.ClassTextBox.Text = selectedEnrolling.SchoolClass.Name;
                    this.SchoolYearTextBox.Text = selectedEnrolling.SchoolYear.Name;                  
                }
            }
        }
        private void SubscriptionDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.SubscriptionDropDownList.SelectedItem != null)
            {
                if (this.SubscriptionDropDownList.SelectedItem.DataBoundItem is CashFlowType subscriptionType)
                {
                    var fee = selectedFeeList.FirstOrDefault(x => x.CashFlowTypeId == subscriptionType.Id);
                    if (fee != null)
                    {
                        this.FeeTextBox.Text = fee.Amount.ToString();
                        this.DurationTextBox.Text = fee.Duration.ToString();
                        this.EndDateTimePicker.Value = DateTime.Now.AddDays(fee.Duration);
                    }
                }
            }
        }
        
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            this.selectedEnrolling = enrolling;
            this.StudentDropDownList.DataSource = new List<Student>() {
                enrolling.Student
            };
            this.StudentDropDownList.ReadOnly = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var subscriptionType=this.SubscriptionDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                var paymentMean = this.PaymentMeanDropDownList.SelectedItem.DataBoundItem as PaymentMean;
                if (!RecordExist(selectedEnrolling.Id, subscriptionType.Id, this.StartDateTimePicker.Value))
                {
                    Subscription subscription = new()
                    {
                        Date = this.StartDateTimePicker.Value,
                        Amount = double.Parse(this.FeeTextBox.Text),
                        Discount = double.Parse(this.DiscountTextBox.Text),
                        EndDate = this.EndDateTimePicker.Value,
                        CashFlowType = subscriptionType,
                        CashFlowTypeId = subscriptionType.Id,
                        PaymentMean = paymentMean,
                        PaymentMeanId = paymentMean.Id,
                        TransactionDate = this.TransactionDateTimePicker.Value,
                        TransactionId = this.TransactionIdTextBox.Text,
                        DoneBy = this.DoneByTextBox.Text,
                        Enrolling = selectedEnrolling,
                        EnrollingId = selectedEnrolling.Id,
                    };
                    //add subscription
                    var isDone = subscriptionService.CreateSubscriptionAsync(subscription).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Ajout d'un abonnement  {subscription.CashFlowType.Name} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logSubscription);

                        //enregistrement du cashflow
                        var cashflow = new CashFlow()
                        {
                            Amount = subscription.Amount,
                            CashFlowType = subscription.CashFlowType,
                            CashFlowTypeId = subscription.CashFlowTypeId,
                            Date = subscription.Date,
                            DoneBy = subscription.DoneBy,
                            SchoolYear = selectedEnrolling.SchoolYear,
                            SchoolYearId = selectedEnrolling.SchoolYearId,
                            Note = subscription.CashFlowType.Name + " " + selectedEnrolling.Student.FullName,
                        };
                        if (cashFlowService.CreateCashFlow(cashflow).Result)
                        {
                            //enregistrement du log
                            Log logCash = new()
                            {
                                UserAction = $"Ajout d'un flux de trésorerie de {cashflow.Amount} pour {cashflow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(logCash);
                        }
                        //impression du reçu
                        var result = subscriptionService.GetSubscriptionAsync(subscription.EnrollingId, subscription.CashFlowTypeId, subscription.Date).Result;
                        subscription.Id = result.Id;
                        printService.PrintPaymentReceipt(subscription, false);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                        ErrorProvider.SetError(this.SubscriptionDropDownList, Language.messageAddError);
                        this.SubscriptionDropDownList.Focus();
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageRecordExist;
                    ErrorProvider.SetError(this.SubscriptionDropDownList, Language.messageRecordExist);
                    this.SubscriptionDropDownList.Focus();
                }
            }
        }
        private bool RecordExist(int enrollingId,int cashFlowTypeId,DateTime subscriptionDate)
        {          
            return subscriptionService.GetSubscriptionAsync(enrollingId,cashFlowTypeId,subscriptionDate).Result!=null;
        }
    }
}
