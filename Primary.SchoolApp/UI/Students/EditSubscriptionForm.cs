
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using SchoolManagement.UI.Localization;
using System.Linq;
using System;
using Primary.SchoolApp.Utilities;

namespace Primary.SchoolApp.UI
{
    internal class EditSubscriptionForm : SchoolManagement.UI.EditSubscriptionForm
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPrintService printService;
        private Subscription selectedSubscription;
        private readonly List<SubscriptionFee> selectedFeeList;
        public EditSubscriptionForm(ISubscriptionService subscriptionService, ILogService logService, ClientApp clientApp, IPrintService printService)
        {
            this.subscriptionService = subscriptionService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            selectedFeeList = Program.SubscriptionFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id).OrderBy(x => x.CashFlowType.Sequence).ToList();
            InitEvents();

        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
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

        internal void InitStartUp(Subscription subscription)
        {
           selectedSubscription = subscription;
            if (selectedSubscription != null)
            {
                this.StudentDropDownList.DataSource = new List<Student>() {
                selectedSubscription.Student
                };
                this.SubscriptionDropDownList.DataSource = new List<CashFlowType>()
                {
                     selectedSubscription.CashFlowType
                };
                var fee = selectedFeeList.FirstOrDefault(x => x.CashFlowTypeId == selectedSubscription.CashFlowType.Id);
                this.FeeTextBox.Text= selectedSubscription.Amount.ToString();
                this.DurationTextBox.Text= fee.Duration.ToString();
                this.StartDateTimePicker.Value=selectedSubscription.StartDate;
                this.EndDateTimePicker.Value=selectedSubscription.EndDate;
                this.TransactionIdTextBox.Text=selectedSubscription.TransactionId;
                this.TransactionDateTimePicker.Value=selectedSubscription.TransactionDate;
                this.DoneByTextBox.Text=selectedSubscription.DoneBy;
                this.SubscriptionDropDownList.ReadOnly = true;
                this.StudentDropDownList.ReadOnly = true;
            } 
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var paymentMean = this.PaymentMeanDropDownList.SelectedItem.DataBoundItem as PaymentMean;
                selectedSubscription.PaymentMean = paymentMean;
                selectedSubscription.PaymentMeanId = paymentMean.Id;
                selectedSubscription.StartDate = this.StartDateTimePicker.Value;
                selectedSubscription.Discount = double.Parse(this.DiscountTextBox.Text);
                selectedSubscription.EndDate = this.EndDateTimePicker.Value;
                selectedSubscription.TransactionDate= this.StartDateTimePicker.Value;
                selectedSubscription.TransactionId = this.TransactionIdTextBox.Text;
                selectedSubscription.DoneBy= this.DoneByTextBox.Text;
                var isDone = subscriptionService.UpdateSubscriptiongAsync(selectedSubscription).Result;
                if (isDone)
                {
                    //enregistrement du log
                    Log logSubscription = new()
                    {
                        UserAction = $" Mise à jour de  l'abonnement  {selectedSubscription.CashFlowType.Name} de l'élève {selectedSubscription.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(logSubscription);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }                
                else
                {
                    ErrorLabel.Text = Language.messageUpdateError;
                    ErrorProvider.SetError(this.SubscriptionDropDownList, Language.messageUpdateError);
                    this.SubscriptionDropDownList.Focus();
                }
            }
        }
    }
}
