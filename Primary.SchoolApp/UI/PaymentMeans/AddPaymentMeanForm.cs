using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddPaymentMeanForm : SchoolManagement.UI.EditPaymentMeanForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IPaymentMeanService paymentMeanService;
        public AddPaymentMeanForm(IPaymentMeanService paymentMeanService, ILogService logService, ClientApp clientApp)
        {
            this.paymentMeanService = paymentMeanService;
            this.logService = logService;
            this.clientApp = clientApp;
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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ClientSize);

            if (IsValidData())
            {
                if (!PaymentMeanExist(NameTextBox.Text))
                {
                    PaymentMean paymentMean = new();
                    paymentMean.Name = NameTextBox.Text;
                    paymentMean.Account = AccountTextBox.Text;
                    paymentMean.Type = TypeDropDownList.SelectedValue.ToString();
                    paymentMean.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = paymentMeanService.CreatePaymentMean(paymentMean).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout du moyen de paiement {paymentMean.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageAddError;
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
            var item = Program.PaymentMeanList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return paymentMeanService.GetPaymentMean(name).Result != null;

        }
    }
}
