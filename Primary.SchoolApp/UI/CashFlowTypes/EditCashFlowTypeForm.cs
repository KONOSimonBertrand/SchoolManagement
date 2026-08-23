
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Mapping;
using SchoolManagement.Application;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    public class EditCashFlowTypeForm : SchoolManagement.UI.EditCashFlowTypeForm
    {
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        CashFlowTypeDTO cashFlowTypeDTO;
        private string cashFlowTypeNameTracker;

        public EditCashFlowTypeForm(ICashFlowTypeService cashFlowTypeService, ILogService logService, ClientApp clientApp)
        {
            this.cashFlowTypeService = cashFlowTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            cashFlowTypeNameTracker = string.Empty;

            CategoryDropDownList.Items.Add(new RadListDataItem(Language.labelSchoolingFee, FlowCategory.TuitionFee));
            CategoryDropDownList.Items.Add(new RadListDataItem(Language.LabelSchoolSupplie, FlowCategory.SchoolSupplie));
            CategoryDropDownList.Items.Add(new RadListDataItem(Language.labelSubscription, FlowCategory.Subscription));
            CategoryDropDownList.Items.Add(new RadListDataItem(Language.LabelExpense, FlowCategory.Expense));
            CategoryDropDownList.Items.Add(new RadListDataItem(Language.LabelSupply, FlowCategory.CashSupply));

            FlowDomainDropDownList.Items.Add(new RadListDataItem(Language.LabelFinance, FlowDomain.Finance));
            FlowDomainDropDownList.Items.Add(new RadListDataItem(Language.LabelTransport, FlowDomain.Transport));
            FlowDomainDropDownList.Items.Add(new RadListDataItem(Language.LabelCanteen, FlowDomain.Canteen));
            FlowDomainDropDownList.Items.Add(new RadListDataItem(Language.LabelSchoolActivity, FlowDomain.SchoolActivity));

            TransactionTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelCashTransaction, TransactionType.CashTransaction));
            TransactionTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelTransactionInKind, TransactionType.TransactionInKind));

            FlowTypeDropDownList.Items.Add(new RadListDataItem(Language.labelInput, FlowType.Inflow));
            FlowTypeDropDownList.Items.Add(new RadListDataItem(Language.labelOutput, FlowType.Outflow));


            TransactionTypeDropDownList.SelectedIndex = 0;
            CategoryDropDownList.SelectedIndex = 0;
            FlowDomainDropDownList.SelectedIndex = 0;
            FlowTypeDropDownList.SelectedIndex = 0;
            InitEvents();
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
                    cashFlowTypeDTO.Name = NameTextBox.Text;
                    cashFlowTypeDTO.FlowCategory = (FlowCategory)CategoryDropDownList.SelectedValue;
                    cashFlowTypeDTO.TransactionType = (TransactionType)TransactionTypeDropDownList.SelectedValue;
                    cashFlowTypeDTO.FlowDomain = (FlowDomain)FlowDomainDropDownList.SelectedValue;
                    cashFlowTypeDTO.FlowType = (FlowType)FlowTypeDropDownList.SelectedValue;
                    cashFlowTypeDTO.Description = DescriptionTextBox.Text;
                    cashFlowTypeDTO.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = cashFlowTypeService.UpdateCashFlowType(cashFlowTypeDTO.AsCashFlowType()).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des informations du Type de flux de trésorerie {cashFlowTypeDTO.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
        internal void Init(CashFlowTypeDTO type)
        {
            if (type != null)
            {
                this.cashFlowTypeDTO = type;
                cashFlowTypeNameTracker = type.Name;
                NameTextBox.Text = type.Name;
                CategoryDropDownList.SelectedValue = type.FlowCategory;
                FlowDomainDropDownList.SelectedValue = type.FlowDomain;
                FlowTypeDropDownList.SelectedValue = type.FlowType;
                TransactionTypeDropDownList.SelectedValue = type.TransactionType;
                DescriptionTextBox.Text = type.Description;
                SequenceSpinEditor.Value = type.Sequence;
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
