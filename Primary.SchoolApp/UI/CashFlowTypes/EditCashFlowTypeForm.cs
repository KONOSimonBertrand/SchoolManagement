
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public class EditCashFlowTypeForm : SchoolManagement.UI.EditCashFlowTypeForm
    {
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        CashFlowType cashFlowType;
        private string cashFlowTypeNameTracker;

        public EditCashFlowTypeForm(ICashFlowTypeService cashFlowTypeService, ILogService logService, ClientApp clientApp)
        {
            this.cashFlowTypeService = cashFlowTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            cashFlowTypeNameTracker = string.Empty;
            InitEvents();
            this.Text = Language.titleCashflowUpdate.ToUpper();
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
                    cashFlowType.Name = NameTextBox.Text;
                    cashFlowType.Category = CategoryDropDownList.SelectedValue.ToString();
                    cashFlowType.Domain = DomainDropDownList.SelectedValue.ToString();
                    cashFlowType.Description = DescriptionTextBox.Text;
                    cashFlowType.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = cashFlowTypeService.UpdateCashFlowType(cashFlowType).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des informations du Type de flux de trésorerie {cashFlowType.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    ErrorLabel.Text = Language.messageCashFlowExist;

                }

            }

        }
        internal void Init(CashFlowType cashFlowType)
        {

            if (cashFlowType != null)
            {
                this.cashFlowType = cashFlowType;
                cashFlowTypeNameTracker = cashFlowType.Name;
                NameTextBox.Text = cashFlowType.Name;
                CategoryDropDownList.SelectedValue = cashFlowType.Category;
                DomainDropDownList.SelectedValue = cashFlowType.Domain;
                DescriptionTextBox.Text = cashFlowType.Description;
                SequenceSpinEditor.Value = cashFlowType.Sequence;
            }

        }
        private bool CashFlowTypeExist(string name)
        {
            if (cashFlowTypeNameTracker == name) return false;
            var item = Program.CashFlowTypeList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return cashFlowTypeService.GetCashFlowType(name).Result != null;
        }
    }
}
