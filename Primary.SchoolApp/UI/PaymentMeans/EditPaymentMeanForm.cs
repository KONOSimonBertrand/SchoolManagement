
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class EditPaymentMeanForm : SchoolManagement.UI.EditPaymentMeanForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPaymentMeanService paymentMeanService;

        private PaymentMean paymentMean;
        private string paymentMeanNameTracker;

        public EditPaymentMeanForm(IPaymentMeanService paymentMeanService, ILogService logService, ClientApp clientApp)
        {
            this.paymentMeanService = paymentMeanService;
            this.clientApp = clientApp;
            this.logService = logService;
            this.Text = Language.titlePaymentMeanUpdate.ToUpper();
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }
        internal void Init(PaymentMean mean)
        {
            paymentMean = mean;
            paymentMeanNameTracker = mean.Name;
            NameTextBox.Text = mean.Name;
            AccountTextBox.Text = mean.Account;
            TypeDropDownList.SelectedValue = mean.Type;
            SequenceSpinEditor.Value = mean.Sequence;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!PaymentMeanExist(NameTextBox.Text))
                {
                    paymentMean.Name = NameTextBox.Text;
                    paymentMean.Account = AccountTextBox.Text;
                    paymentMean.Type = TypeDropDownList.SelectedValue.ToString();
                    paymentMean.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = paymentMeanService.UpdatePaymentMean(paymentMean).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des information du moyen de paiement  {paymentMean.Id}-{paymentMean.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messagePaymentMeanExist;
                }
            }
        }

        private bool PaymentMeanExist(string name)
        {
            if (paymentMeanNameTracker == name) return false;
            var item = Program.PaymentMeanList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return paymentMeanService.GetPaymentMean(name).Result != null;
        }
    }
}
