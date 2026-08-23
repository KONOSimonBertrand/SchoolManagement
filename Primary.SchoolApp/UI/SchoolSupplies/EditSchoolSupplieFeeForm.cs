

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Mapping;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditSchoolSupplieFeeForm : SchoolManagement.UI.EditSchoolSupplieFeeForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolSupplieFeeService schoolSupplieFeeService;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ISchoolClassService schoolClassService;
        private SchoolSupplieFee schoolSupplieFee;
        private struct SchoolSupplieFeeTracker
        {
            public int ClassId { get; set; }
            public int CostTypeId { get; set; }
            public int SchoolYearId { get; set; }
        }
        private SchoolSupplieFeeTracker schoolSupplieFeeTracker;
        public EditSchoolSupplieFeeForm(ISchoolSupplieFeeService schoolSupplieFeeService, ILogService logService, ClientApp clientApp,
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ISchoolClassService schoolClassService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolSupplieFeeService = schoolSupplieFeeService;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.schoolClassService = schoolClassService;
           
            schoolSupplieFeeTracker = new SchoolSupplieFeeTracker();
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            Shown += OnShown;
            SchoolYearDropDownList.SelectedValueChanged += SchoolYearDropDownList_SelectedValueChanged;
            AddClassButton.Click += AddClassButton_Click;
            AddSchoolYearButton.Click += AddSchoolYearButton_Click;
            AddCostTypeButton.Click += AddCostTypeButton_Click;
        }

        private void AddCostTypeButton_Click(object sender, EventArgs e)
        {
            if (CostTypeDropDownList.SelectedItem == null)
            {
                ShowCashFlowTypeAddForm();
            }
            else
            {
                var type = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowTypeDTO;
                if (type != null)
                {
                    ShowCashFlowTypeEditForm(type);
                }
                else
                {
                    RadMessageBox.Show(Language.messageUnknowCashflow);
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

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassAutoCompleteBox.SelectionLength==0)
            {
                ShowSchoolClassAddForm();
            }
            else
            {
                var selectedText= ClassAutoCompleteBox.SelectedText.Replace(';',' ').Trim();
                var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Name == selectedText);
                if (selectedClass != null)
                {
                    ShowSchoolClassEditForm(selectedClass);
                }
                else
                {
                    RadMessageBox.Show(Language.messageUnknowClass);
                }
            }
        }
        internal void Init(SchoolSupplieFee schoolSupplieFee)
        {
            AddClassButton.Visible = false;
            AddCostTypeButton.Visible = false;
            AddSchoolYearButton.Visible = false;
            this.schoolSupplieFee = schoolSupplieFee;
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == schoolSupplieFee.SchoolClassId);
            var selectedYear = Program.SchoolYearList.FirstOrDefault(x => x.Id==schoolSupplieFee.SchoolYearId);
            var selectedCashFlowType = Program.CashFlowTypeList.FirstOrDefault(x => x.Id == schoolSupplieFee.CashFlowTypeId);
            ClassAutoCompleteBox.AutoCompleteDataSource = new[] {
               selectedClass
            };
            CostTypeDropDownList.DataSource = new[] {
               selectedCashFlowType
            };
            SchoolYearDropDownList.DataSource = new[] {
               selectedYear
            };

            //ClassAutoCompleteBox.Text = string.Join(";", classList)+";";
            ClassAutoCompleteBox.Text = selectedClass .Name+ ";";
            SchoolYearDropDownList.SelectedValue = schoolSupplieFee.SchoolYearId;
            CostTypeDropDownList.SelectedValue = schoolSupplieFee.CashFlowTypeId;
            CostPayableDropDownList.SelectedValue = schoolSupplieFee.IsPayable.ToString();
            AmountTextBox.Text = schoolSupplieFee.Amount.ToString();
            schoolSupplieFeeTracker.SchoolYearId = schoolSupplieFee.SchoolYearId;
            schoolSupplieFeeTracker.ClassId = schoolSupplieFee.SchoolClassId;
            schoolSupplieFeeTracker.CostTypeId = schoolSupplieFee.CashFlowTypeId;
            RequiredQuantityTextBox.Text = schoolSupplieFee.RequiredQuantity.ToString();
            ClassAutoCompleteBox.IsReadOnly = true;
            SchoolYearDropDownList.ReadOnly = true;
            CostTypeDropDownList.ReadOnly = true;
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
                int yearId = int.Parse(SchoolYearDropDownList.SelectedValue.ToString());
                int typeId = int.Parse(CostTypeDropDownList.SelectedValue.ToString());
                var selectedClassId = schoolSupplieFee.SchoolClassId;
                string infoMessage = string.Empty;
                if (!SchoolSupplieFeeExist(selectedClassId, typeId, yearId))
                {
                    var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedClassId);
                    schoolSupplieFee.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                    schoolSupplieFee.SchoolClassId = schoolSupplieFee.SchoolYear.Id;
                    schoolSupplieFee.SchoolClass = selectedClass;
                    schoolSupplieFee.SchoolClassId = schoolSupplieFee.SchoolClass.Id;
                    var cashFlowType = (CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowTypeDTO).AsCashFlowType();
                    schoolSupplieFee.CashFlowType = cashFlowType;
                    schoolSupplieFee.CashFlowTypeId = schoolSupplieFee.CashFlowType.Id;
                    schoolSupplieFee.IsPayable = bool.Parse(CostPayableDropDownList.SelectedValue.ToString());
                    schoolSupplieFee.RequiredQuantity = int.Parse(RequiredQuantityTextBox.Text);
                    schoolSupplieFee.Amount = double.Parse(AmountTextBox.Text);

                    bool isDone = schoolSupplieFeeService.UpdateSchoolSupplieFee(schoolSupplieFee).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification  des frais de fournitures scolaires {schoolSupplieFee.CashFlowType.Name} pour la classe {schoolSupplieFee.SchoolClass.Name} pour l'année scolaire {schoolSupplieFee.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        infoMessage = Language.messageUpdateError;
                        ErrorLabel.Text = infoMessage;
                    }
                }
                else
                {
                    infoMessage = Language.messageDataAlreadyExist;
                    ErrorLabel.Text = infoMessage;
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
                if (form.ShowDialog(this) == DialogResult.OK)
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
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolYearService.GetSchoolYear(form.NameTextBox.Text).Result;
                Program.SchoolYearList.Add(data);
                SchoolYearDropDownList.DataSource = null;
                SchoolYearDropDownList.DataSource = Program.SchoolYearList;
                SchoolYearDropDownList.SelectedValue = data;
            }
        }
        // show school class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass schoolClass)
        {
            if (schoolClass != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.InitStartup(schoolClass);
                form.Icon = Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassAutoCompleteBox.AutoCompleteDataSource = null;
                    ClassAutoCompleteBox.AutoCompleteDataSource = Program.SchoolClassList;
                    ClassAutoCompleteBox.AutoCompleteItems.Add(new RadListDataItem(data.Name, data.Id));
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowClass);
            }

        }
        // show school class UI for add new
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClass;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                ClassAutoCompleteBox.AutoCompleteDataSource = null;
                ClassAutoCompleteBox.AutoCompleteDataSource = Program.SchoolClassList;
                ClassAutoCompleteBox.AutoCompleteItems.Add(new RadListDataItem(data.Name, data.Id));
            }
        }
        // show CashFlowType UI for edit
        private void ShowCashFlowTypeEditForm(CashFlowTypeDTO type)
        {
            if (type != null)
            {
                var form = Program.ServiceProvider.GetService<EditCashFlowTypeForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelCashFlowType;
                form.Init(type);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                    CostTypeDropDownList.DataSource = null;
                    CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.FlowCategory == SchoolManagement.Core.Enum.FlowCategory.SchoolSupplie);
                    CostTypeDropDownList.SelectedValue = data;
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
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                Program.CashFlowTypeList.Add(data.AsCashFlowTypeDTO());
                CostTypeDropDownList.DataSource = null;
                CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.FlowCategory == SchoolManagement.Core.Enum.FlowCategory.SchoolSupplie);
                CostTypeDropDownList.SelectedValue = data;
            }
        }
        private bool SchoolSupplieFeeExist(int classId, int cashFlowTypeId, int schoolYearId)
        {
            if (schoolSupplieFeeTracker.ClassId == classId && schoolSupplieFeeTracker.CostTypeId == cashFlowTypeId && schoolSupplieFeeTracker.SchoolYearId == schoolYearId) return false;
            var item = Program.SchoolSupplieFeeList.FirstOrDefault(x => x.SchoolClassId == classId && x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return schoolSupplieFeeService.GetSchoolSupplieFee(classId, cashFlowTypeId, schoolYearId).Result != null;
        }
    }
}
