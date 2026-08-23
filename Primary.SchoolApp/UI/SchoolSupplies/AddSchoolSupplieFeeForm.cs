
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Mapping;
using SchoolManagement.Application;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddSchoolSupplieFeeForm : SchoolManagement.UI.EditSchoolSupplieFeeForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolSupplieFeeService schoolSupplieFeeService;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ISchoolClassService schoolClassService;
        private List<SchoolClass> schoolClasses;
        public AddSchoolSupplieFeeForm(ISchoolSupplieFeeService schoolSupplieFeeService, ILogService logService, ClientApp clientApp,
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ISchoolClassService schoolClassService
            )
        {
            this.schoolSupplieFeeService = schoolSupplieFeeService;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.schoolClassService = schoolClassService;
            this.logService = logService;
            this.clientApp = clientApp;
            schoolClasses=new List<SchoolClass>();
            CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.SchoolSupplie);
            schoolClasses.AddRange(Program.SchoolClassList);
            SchoolYearDropDownList.DataSource = Program.SchoolYearList;
            schoolClasses.Add(
                new() { 
                    Id=0,
                    Name=Language.LabelAllClass
                }
                );
            ClassAutoCompleteBox.AutoCompleteDataSource = schoolClasses;
            ClassAutoCompleteBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            InitEvents();
            RequiredQuantityTextBox.Text = "1";

        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            SchoolYearDropDownList.SelectedValueChanged += SchoolYearDropDownList_SelectedValueChanged;
            AddClassButton.Click += AddClassButton_Click;
            AddSchoolYearButton.Click += AddSchoolYearButton_Click;
            AddCostTypeButton.Click += AddCostTypeButton_Click;
            ClassAutoCompleteBox.TextChanged += ClassAutoCompleteBox_TextChanged;
        }

        private void ClassAutoCompleteBox_TextChanged(object sender, EventArgs e)
        {
            if(ClassAutoCompleteBox.Text== Language.LabelAllClass)
            {
                string items = string.Empty;
                var nameList = Program.SchoolClassList.Select(x => x.Name);
                items = string.Join(';', nameList) + ";";
                ClassAutoCompleteBox.Text = items;
            }
        }

        private void AddCostTypeButton_Click(object sender, EventArgs e)
        {
            if (CostTypeDropDownList.SelectedItem == null)
            {
                ShowCashFlowTypeAddForm();
            }
            else
            {
                var item = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowTypeDTO;
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

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassAutoCompleteBox.SelectionLength == 0)
            {
                ShowSchoolClassAddForm();
            }
            else
            {
                var selectedText = ClassAutoCompleteBox.SelectedText.Replace(';', ' ').Trim();
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
                int rowsAdded = 0;// nombre d'enregistrements enregistrés en base
                string infoMessage = string.Empty;
                foreach (var classItem in ClassAutoCompleteBox.Items)
                {
                    var selectedItemClass = ClassAutoCompleteBox.Items.FirstOrDefault(x => x.Value == classItem.Value);
                    if (int.TryParse(selectedItemClass?.Value.ToString(), out var selectedId))
                    {
                        var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedId);
                        if (selectedClass != null)
                        {
                            SchoolSupplieFee supplieFee = new();
                            supplieFee.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                            supplieFee.SchoolYearId = supplieFee.SchoolYear.Id;
                            supplieFee.SchoolClass = selectedClass;
                            supplieFee.SchoolClassId = selectedClass.Id;
                            var cashFlowType = (CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowTypeDTO).AsCashFlowType();
                            supplieFee.CashFlowType = cashFlowType;
                            supplieFee.CashFlowTypeId = supplieFee.CashFlowType.Id;
                            supplieFee.IsPayable = bool.Parse(CostPayableDropDownList.SelectedValue.ToString());
                            supplieFee.Amount = double.Parse(AmountTextBox.Text);
                            supplieFee.RequiredQuantity = double.Parse(RequiredQuantityTextBox.Text);
                            if (!SchoolSupplieFeeExist(supplieFee.SchoolClassId, supplieFee.CashFlowTypeId, supplieFee.SchoolYearId))
                            {
                                bool isDone = schoolSupplieFeeService.CreateSchoolSupplieFee(supplieFee).Result;
                                if (isDone == true)
                                {
                                    Log log = new()
                                    {
                                        UserAction = $"Ajout  des frais des fournitures scolaires {supplieFee.CashFlowType.Name} pour la classe {supplieFee.SchoolClass.Name} pour l'année scolaire {supplieFee.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    logService.CreateLog(log);
                                    rowsAdded++;
                                }
                                else
                                {
                                    infoMessage += selectedClass + ":" + Language.messageAddError + "\n";
                                }
                            }
                            else
                            {
                                infoMessage += selectedClass + ":" + Language.messageFeesExist + "\n";
                            }
                        }
                    }
                }
                if (ClassAutoCompleteBox.Items.Count == rowsAdded)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ErrorProvider.Clear();
                    ErrorLabel.Text = infoMessage;
                    ErrorProvider.SetError(ClassAutoCompleteBox, infoMessage);
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
        // show school class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass schoolClass)
        {
            if (schoolClass != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.InitStartup(schoolClass);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassAutoCompleteBox.AutoCompleteDataSource=null;
                    ClassAutoCompleteBox.AutoCompleteDataSource = Program.SchoolClassList;
                    ClassAutoCompleteBox.AutoCompleteItems.Add(new RadListDataItem(data.Name,data.Id));
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
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
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
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                    CostTypeDropDownList.DataSource = null;
                    CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.SchoolSupplie);
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
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                Program.CashFlowTypeList.Add(data.AsCashFlowTypeDTO());
                CostTypeDropDownList.DataSource = null;
                CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.SchoolSupplie);
                CostTypeDropDownList.SelectedValue = data;
            }
        }
        private bool SchoolSupplieFeeExist(int classId, int cashFlowTypeId, int schoolYearId)
        {
            var item = Program.SchoolSupplieFeeList.FirstOrDefault(x => x.SchoolClassId == classId && x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return schoolSupplieFeeService.GetSchoolSupplieFee(classId, cashFlowTypeId, schoolYearId).Result != null;
        }
    }
}
