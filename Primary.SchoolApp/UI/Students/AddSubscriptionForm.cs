using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
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
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPrintService printService;
        private readonly List<SubscriptionFee> selectedFeeList;
        //private int selectedInitMethod = 0;
        internal string LastIdNumber = string.Empty;// is given when payment added
        public AddSubscriptionForm(ISubscriptionService subscriptionService, ILogService logService, ClientApp clientApp, IPrintService printService)
        {
            this.subscriptionService = subscriptionService;
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
                    var enrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.StudentId == student.Id).AsStudentEnrolling();
                    this.ClassTextBox.Text = enrolling.SchoolClass.Name;
                    this.SchoolYearTextBox.Text = Program.CurrentSchoolYear.Name;                  
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
        
        internal void InitStartup(Student student)
        {
            this.StudentDropDownList.DataSource = new List<Student>() {
                student
            };
            this.StudentDropDownList.ReadOnly = true;
        }
        internal void InitStartup(List<Student> students)
        {
            this.StudentDropDownList.DataSource = students;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var subscriptionType=this.SubscriptionDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                var paymentMean = this.PaymentMeanDropDownList.SelectedItem.DataBoundItem as PaymentMean;
                var student=this.StudentDropDownList.SelectedItem.DataBoundItem as Student;
                if (!RecordExist(student.Id,Program.CurrentSchoolYear.Id, subscriptionType.Id, this.StartDateTimePicker.Value))
                {
                    Subscription subscription = new()
                    {
                        StartDate = this.StartDateTimePicker.Value,
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
                        Student = student,
                        StudentId = student.Id,
                        SchoolYear=Program.CurrentSchoolYear,
                        SchoolYearId=Program.CurrentSchoolYear.Id,
                        
                    };
                    //add subscription
                    var isDone = subscriptionService.CreateSubscriptionAsync(subscription).Result;
                    if (isDone)
                    {
                        LastIdNumber = subscription.IdNumber;
                        //update list of subscription
                        var recordAdded = subscriptionService.GetSubscriptionAsync(subscription.IdNumber).Result;
                        if (recordAdded != null)
                        {
                            subscription.Id = recordAdded.Id;
                            Program.SubscriptionList.Add(subscription);
                        }
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Ajout d'un abonnement  {subscription.CashFlowType.Name} de l'élève {student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logSubscription);
                        //print
                        var result = subscriptionService.GetSubscriptionAsync(subscription.StudentId,subscription.SchoolYearId, subscription.CashFlowTypeId, subscription.StartDate).Result;
                        subscription.Id = result.Id;
                        printService.PrintPaymentReceiptAsync(subscription, false);
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
        private bool RecordExist(int studentId,int schoolYearId,int cashFlowTypeId,DateTime subscriptionDate)
        {          
            return subscriptionService.GetSubscriptionAsync(studentId,schoolYearId,cashFlowTypeId,subscriptionDate).Result!=null;
        }
    }
}
