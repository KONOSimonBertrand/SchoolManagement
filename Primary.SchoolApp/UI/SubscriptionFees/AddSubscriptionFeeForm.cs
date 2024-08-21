

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    internal class AddSubscriptionFeeForm : SchoolManagement.UI.EditSubscriptionFeeForm
    {
        private readonly ISubscriptionFeeService subscriptionFeeService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        public AddSubscriptionFeeForm(ISubscriptionFeeService subscriptionFeeService, ILogService logService,
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ClientApp clientApp)
        {
            this.subscriptionFeeService = subscriptionFeeService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            SubscriptionTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "AB");
            SchoolYearDropDownList.DataSource = Program.SchoolYearList;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            SchoolYearDropDownList.SelectedValueChanged += SchoolYearDropDownList_SelectedValueChanged;
            AddSchoolYearButton.Click += AddSchoolYearButton_Click;
            AddSubscriptionTypeButton.Click += AddSubscriptionTypeButton_Click;
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
                    RadMessageBox.Show(Language.messageUnknowType);
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
                    RadMessageBox.Show(Language.messageUnknowSchoolYear);
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
                        ErrorLabel.Text = Language.messageSchoolYearClosed;
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
            SchoolYearDropDownList.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SubscriptionFee subscriptionFee = new();
                subscriptionFee.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                subscriptionFee.SchoolYearId = subscriptionFee.SchoolYear.Id;
                subscriptionFee.CashFlowType = SubscriptionTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                subscriptionFee.CashFlowTypeId = subscriptionFee.CashFlowType.Id;
                subscriptionFee.Duration = int.Parse(DurationSpinEditor.Value.ToString());
                subscriptionFee.Amount = double.Parse(AmountTextBox.Text);
                if (!SubscriptionFeeExist(subscriptionFee.CashFlowTypeId, subscriptionFee.SchoolYearId))
                {
                    var isDone = subscriptionFeeService.CreateSubscriptionFee(subscriptionFee).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout  des frais d'abonnement {subscriptionFee.CashFlowType.Name}  pour l'année scolaire {subscriptionFee.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    this.ErrorLabel.Text = Language.messageSubscriptionFeesExist;
                }
            }
        }
        // show school year UI for edit
        private void ShowSchoolYearEditForm(SchoolYear schoolYear)
        {
            if (schoolYear != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolYearForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSchoolYear;
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
                RadMessageBox.Show(Language.messageUnknowSchoolYear);
            }

        }
        // show school year UI for add new
        private void ShowSchoolYearAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolYearForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSchoolYear;
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
                form.Text = Language.labelUpdate + ":.. " + Language.labelCashFlowType;
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
                RadMessageBox.Show(Language.messageUnknowCashflow);
            }

        }
        // show CashFlowType UI for add new
        private void ShowCashFlowTypeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddCashFlowTypeForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelCashFlowType;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                Program.CashFlowTypeList.Add(data);
                SubscriptionTypeDropDownList.DataSource = null;
                SubscriptionTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "AB");
                SubscriptionTypeDropDownList.SelectedValue = data;
            }
        }

        private bool SubscriptionFeeExist(int cashFlowTypeId, int schoolYearId)
        {
            var item = Program.SubscriptionFeeList.FirstOrDefault(x => x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return subscriptionFeeService.GetSubscriptionFee(cashFlowTypeId, schoolYearId).Result != null;
        }
    }
}
