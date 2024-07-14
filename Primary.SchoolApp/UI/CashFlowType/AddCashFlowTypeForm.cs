
using SchoolManagement.Application.CashFlowTypes;
using SchoolManagement.Application.Logs;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
namespace Primary.SchoolApp.UI
{
    public partial class AddCashFlowTypeForm : SchoolManagement.UI.EditCashFlowTypeForm
    {
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        CashFlowType cashFlowType;
        public AddCashFlowTypeForm(ICashFlowTypeService cashFlowTypeService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.cashFlowTypeService = cashFlowTypeService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
            this.Text = "AJOUT:.TYPE DE FLUX DE TRESORERIE";
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
           
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(778, 444);
            this.NameTextBox.Focus();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!CashFlowTypeExist(NameTextBox.Text)) {
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
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    ErrorLabel.Text = "Un type de flux de trésorerie potant le même nom existe déjà! ";
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
