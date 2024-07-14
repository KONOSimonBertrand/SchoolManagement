

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.CashFlowTypes;
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Application.SubscriptionFees;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class EditSubscriptionFeeForm : SchoolManagement.UI.EditSubscriptionFeeForm
    {
        private readonly ISubscriptionFeeService subscriptionFeeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        SubscriptionFee subscriptionFee;
        public struct SubscriptionFeeTracker
        {
            public int CashFlowTypeId { get; set; }
            public int SchoolYearId { get; set; }
        }
        SubscriptionFeeTracker subscriptionFeeTracker;
        public EditSubscriptionFeeForm(ISubscriptionFeeService subscriptionFeeService, ILogService logService, 
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ClientApp clientApp)
        {
            InitializeComponent();
            this.subscriptionFeeService = subscriptionFeeService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            SubscriptionTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "AB");
            SchoolYearDropDownList.DataSource = Program.SchoolYearList;
            InitEvents();
            this.Text = "MODIFICARION:.FRAIS SCOLARITE";
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            SchoolYearDropDownList.SelectedValueChanged += SchoolYearDropDownList_SelectedValueChanged;
            AddSchoolYearButton.Click += AddSchoolYearButton_Click;
            AddSubscriptionTypeButton.Click += AddSubscriptionTypeButton_Click;
        }
        internal void Init(SubscriptionFee subscriptionFee)
        {
            this.subscriptionFee = subscriptionFee;
            if (subscriptionFee != null)
            {
                SchoolYearDropDownList.SelectedValue = subscriptionFee.SchoolYear.Id;
                SubscriptionTypeDropDownList.SelectedValue = subscriptionFee.CashFlowType.Id;
                AmountTextBox.Text = subscriptionFee.Amount.ToString();
                DurationSpinEditor.Value=subscriptionFee.Duration;
                subscriptionFeeTracker.SchoolYearId = subscriptionFee.SchoolYearId;
                subscriptionFeeTracker.CashFlowTypeId = subscriptionFee.CashFlowTypeId;
            }
        }
        private void AddSubscriptionTypeButton_Click(object sender, EventArgs e)
        {
            if (SubscriptionTypeDropDownList.SelectedItem == null)
            {
                ShowCashFlowTypeAddForm();
            }
            else
            {
                var item = SubscriptionTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                if (item != null)
                {
                    ShowCashFlowTypeEditForm(item);
                }
                else
                {
                    RadMessageBox.Show("Type inconnu");
                }
            }
        }

        private void AddSchoolYearButton_Click(object sender, EventArgs e)
        {
            if (SchoolYearDropDownList.SelectedItem == null)
            {
                ShowSchoolYearAddForm();
            }
            else
            {
                var item = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                if (item != null)
                {
                    ShowSchoolYearEditForm(item);
                }
                else
                {
                    RadMessageBox.Show("Année scolaire inconnue");
                }
            }
        }

        private void SchoolYearDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SchoolYearDropDownList.SelectedIndex >= 0)
            {
                var item = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                if (item != null)
                {
                    if (item.IsClosed)
                    {

                        SaveButton.Enabled = false;
                        AddSchoolYearButton.Enabled = false;
                        ErrorLabel.Text = "Cette année scolaire est clôturée";
                    }
                    else
                    {
                        ErrorLabel.Text = string.Empty;
                        SaveButton.Enabled = true;
                        AddSchoolYearButton.Enabled = true;
                    }
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(883, 293);
            SchoolYearDropDownList.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {

                int yearId= int.Parse(SchoolYearDropDownList.SelectedValue.ToString());
                int typeId= int.Parse(SubscriptionTypeDropDownList.SelectedValue.ToString());

                if (!SubscriptionFeeExist(typeId, yearId))
                {
                    subscriptionFee.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                    subscriptionFee.SchoolYearId = subscriptionFee.SchoolYear.Id;
                    subscriptionFee.CashFlowType = SubscriptionTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                    subscriptionFee.CashFlowTypeId = subscriptionFee.CashFlowType.Id;
                    subscriptionFee.Duration = int.Parse(DurationSpinEditor.Value.ToString());
                    subscriptionFee.Amount = double.Parse(AmountTextBox.Text);
                    var isDone=subscriptionFeeService.UpdateSubscriptionFee(subscriptionFee).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification  des frais d'abonnement {subscriptionFee.CashFlowType.Name}  pour l'année scolaire {subscriptionFee.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    this.ErrorLabel.Text = "Ces frais d'abonnement existent déjà";
                }
            }
        }
        // show school year UI for edit
        private void ShowSchoolYearEditForm(SchoolYear schoolYear)
        {
            if (schoolYear != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolYearForm>();
                form.Init(schoolYear);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolYearService.GetSchoolYear(form.NameTextBox.Text).Result;
                    SchoolYearDropDownList.DataSource = null;
                    SchoolYearDropDownList.DataSource = Program.SchoolYearList;
                    SchoolYearDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Année scolaire inconnue");
            }

        }
        // show school year UI for add new
        private void ShowSchoolYearAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolYearForm>();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = schoolYearService.GetSchoolYear(form.NameTextBox.Text).Result;
                Program.SchoolYearList.Add(data);
                SchoolYearDropDownList.DataSource = null;
                SchoolYearDropDownList.DataSource = Program.SchoolYearList;
                SchoolYearDropDownList.SelectedValue = data;
            }
        }
       
      
        // show CashFlowType UI for edit
        private void ShowCashFlowTypeEditForm(CashFlowType cashFlowType)
        {
            if (cashFlowType != null)
            {
                var form = Program.ServiceProvider.GetService<EditCashFlowTypeForm>();
                form.Init(cashFlowType);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                    SubscriptionTypeDropDownList.DataSource = null;
                    SubscriptionTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "AB");
                    SubscriptionTypeDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Année scolaire inconnue");
            }

        }
        // show CashFlowType UI for add new
        private void ShowCashFlowTypeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddCashFlowTypeForm>();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                Program.CashFlowTypeList.Add(data);
                SubscriptionTypeDropDownList.DataSource = null;
                SubscriptionTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "AB");
                SubscriptionTypeDropDownList.SelectedValue = data;
            }
        }
    
    private bool SubscriptionFeeExist(int cashFlowTypeId,int schoolYearId)
        {
            if (subscriptionFeeTracker.CashFlowTypeId == cashFlowTypeId && subscriptionFeeTracker.SchoolYearId==schoolYearId) {
                return false;
            }
            var item = Program.SubscriptionFeeList.FirstOrDefault(x => x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return subscriptionFeeService.GetSubscriptionFee(cashFlowTypeId, schoolYearId).Result!=null;
        }
    
    }
}
