

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;

namespace Primary.SchoolApp.UI
{
    internal class AddEmployeeAccountTransactionForm : SchoolManagement.UI.EditEmployeeAccountTransactionForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public AddEmployeeAccountTransactionForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            InitEvents();
            TransactionDateTimePicker.Value = DateTime.Now;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {
                EmployeeAccountTransaction transaction = new()
                {
                    Enrolling = selectedEnrolling,
                    EnrollingId = selectedEnrolling.Id,
                    Amount = double.Parse(AmountTextBox.Text),
                    Reason=ReasonTextBox.Text,
                    Date = TransactionDateTimePicker.Value,
                    TransactionId=employeeService.GenerateAccountTransactionIdNumber().Result,                    
                };
                var isDone = employeeService.AddAccountTransaction(transaction).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout d'une transaction de {transaction.Amount} sur le compte de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ErrorLabel.Text = Language.messageAddError;
                }

                Console.WriteLine(transaction.TransactionId);
            }
        }

        internal void Init(EmployeeEnrolling enrolling)
        {
            this.selectedEnrolling = enrolling;
        }
    }
}
