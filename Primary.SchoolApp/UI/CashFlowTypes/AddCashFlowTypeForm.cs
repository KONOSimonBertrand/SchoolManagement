
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
namespace Primary.SchoolApp.UI
{
    public class AddCashFlowTypeForm : SchoolManagement.UI.EditCashFlowTypeForm
    {
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        CashFlowType cashFlowType;
        public AddCashFlowTypeForm(ICashFlowTypeService cashFlowTypeService, ILogService logService, ClientApp clientApp)
        {
            this.cashFlowTypeService = cashFlowTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
            this.Text = Language.titleCashflowAdd.ToUpper();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;

        }

        private void OnShown(object sender, EventArgs e)
        {
            this.NameTextBox.Focus();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!CashFlowTypeExist(NameTextBox.Text))
                {
                    cashFlowType = new CashFlowType();
                    cashFlowType.Name = NameTextBox.Text;
                    cashFlowType.Category = CategoryDropDownList.SelectedValue.ToString();
                    cashFlowType.Domain = DomainDropDownList.SelectedValue.ToString();
                    cashFlowType.Description = DescriptionTextBox.Text;
                    cashFlowType.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = cashFlowTypeService.CreateCashFlowType(cashFlowType).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout du Type de flux de trésorerie {cashFlowType.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    ErrorLabel.Text = Language.messageCashFlowExist;
                }
            }
        }
        private bool CashFlowTypeExist(string name)
        {
            var item = Program.CashFlowTypeList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return cashFlowTypeService.GetCashFlowType(name).Result != null;
        }

    }
}
