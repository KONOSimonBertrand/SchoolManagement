

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
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
    internal class AddSchoolingCostForm : SchoolManagement.UI.EditSchoolingCostForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolSchoolingCostService schoolingCostService;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ISchoolClassService schoolClassService;
        private List<SchoolClass> schoolClasses;
        public AddSchoolingCostForm(ISchoolSchoolingCostService schoolingCostService, ILogService logService, ClientApp clientApp,
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ISchoolClassService schoolClassService
            )
        {
            this.schoolingCostService = schoolingCostService;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.schoolClassService = schoolClassService;
            this.logService = logService;
            this.clientApp = clientApp;
            schoolClasses=new List<SchoolClass>();
            CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "FS");
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
            InitTranchesGridView();
            InitEvents();
            TrancheNumberTextBox.Text = "0";

        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            TrancheNumberTextBox.TextChanged += TrancheNumberTextBox_TextChanged;
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
                var item = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
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

        //Vériffie si somme des montants du GridView est égale au montant des frais scolaire
        private bool IsValidTrancheValue(int trancheNumber)
        {
            double totalAmount = 0;
            for (int i = 0; i < TranchesGridView.Rows.Count; i++)
            {
                var item = TranchesGridView.Rows[i].DataBoundItem as SchoolingCostItem;
                totalAmount = totalAmount + item.Amount;
            }
            if (totalAmount != double.Parse(AmountTextBox.Text))
            {
                return false;
            }
            return true;
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
        private void TrancheNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TrancheNumberTextBox.Text != "")
            {
                int trancheNumber = int.Parse(TrancheNumberTextBox.Text);
                if (trancheNumber > 6)
                {
                    ErrorLabel.Text = Language.messageBadTrancheNumber;
                    TrancheNumberTextBox.Text = "6";
                    TrancheNumberTextBox.Focus();
                    return;
                }
                else
                {
                    ErrorLabel.Text = string.Empty;
                }
                IList<SchoolingCostItem> emptyList = new List<SchoolingCostItem>();
                for (int i = 1; i <= trancheNumber; i++)
                {
                    emptyList.Add(new SchoolingCostItem()
                    {
                        Rank = i,
                        Amount = 0,
                        DeadLine = DateTime.Now
                    }
                    );
                }
                TranchesGridView.DataSource = emptyList;
                //foreach (var row in TranchesGridView.Rows)
                //{
                //    row.Height = 40;
                //}
            }
        }
        //création des colonnes du gridView
        private void InitTranchesGridView()
        {
            GridViewDecimalColumn rankColumn = new("Rank");
            GridViewDecimalColumn amounColumn = new("Amount");
            GridViewDateTimeColumn deadLineColumn = new("DeadLine");
            rankColumn.HeaderText = "N°";
            amounColumn.HeaderText = Language.labelAmount;
            deadLineColumn.HeaderText = Language.labelDelay;
            rankColumn.Width = 50;
            amounColumn.Width = 150;
            deadLineColumn.Width = 250;
            deadLineColumn.Format = DateTimePickerFormat.Custom;
            deadLineColumn.CustomFormat = "dd/MM/yyyy";
            deadLineColumn.FormatString = "{0:dd/MM/yyyy}";
            deadLineColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            rankColumn.ReadOnly = true;
            TranchesGridView.Columns.Add(rankColumn);
            TranchesGridView.Columns.Add(amounColumn);
            TranchesGridView.Columns.Add(deadLineColumn);
            GridViewSummaryRowItem summaryRow = new()
            {
                new GridViewSummaryItem("Amount", "Total:  {0}", GridAggregateFunction.Sum)
            };
            TranchesGridView.TableElement.TableHeaderHeight = 40;
            TranchesGridView.MasterTemplate.SummaryRowsBottom.Add(summaryRow);
            TranchesGridView.MasterView.SummaryRows[0].Height = 40;
        }

        private void OnShown(object sender, EventArgs e)
        {
            SchoolYearDropDownList.Focus();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (IsValidTrancheValue(int.Parse(TrancheNumberTextBox.Text)))
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
                                SchoolingCost cost = new();
                                cost.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                                cost.SchoolYearId = cost.SchoolYear.Id;
                                cost.SchoolClass = selectedClass;
                                cost.SchoolClassId = selectedClass.Id;
                                cost.CashFlowType = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                                cost.CashFlowTypeId = cost.CashFlowType.Id;
                                cost.IsPayable = bool.Parse(CostPayableDropDownList.SelectedValue.ToString());
                                cost.TrancheNumber = int.Parse(TrancheNumberTextBox.Text);
                                cost.Amount = double.Parse(AmountTextBox.Text);
                                cost.SchoolingCostItems = new List<SchoolingCostItem>();
                                for (int i = 0; i < cost.TrancheNumber; i++)
                                {
                                    var item = TranchesGridView.Rows[i].DataBoundItem as SchoolingCostItem;
                                    cost.SchoolingCostItems.Add(
                                        new SchoolingCostItem()
                                        {
                                            Amount = item.Amount,
                                            DeadLine = item.DeadLine,
                                            Rank = item.Rank,
                                        }
                                        );
                                }
                                if (!SchoolingCostExist(cost.SchoolClassId, cost.CashFlowTypeId, cost.SchoolYearId))
                                {
                                    bool isDone = schoolingCostService.CreateSchoolingCost(cost).Result;
                                    if (isDone == true)
                                    {
                                        Log log = new()
                                        {
                                            UserAction = $"Ajout  des frais scolaires {cost.CashFlowType.Name} pour la classe {cost.SchoolClass.Name} pour l'année scolaire {cost.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                                            UserId = clientApp.UserConnected.Id
                                        };
                                        logService.CreateLog(log);
                                        rowsAdded++;
                                    }
                                    else
                                    {
                                        infoMessage+= selectedClass +":"+ Language.messageAddError+"\n";
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
                else
                {
                    ErrorProvider.Clear();
                    ErrorLabel.Text = Language.messageBadInstalment;
                    ErrorProvider.SetError(TranchesGridView, Language.messageBadInstalment);
                    TranchesGridView.Focus();
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
                    CostTypeDropDownList.DataSource = null;
                    CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "FS");
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
                Program.CashFlowTypeList.Add(data);
                CostTypeDropDownList.DataSource = null;
                CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "FS");
                CostTypeDropDownList.SelectedValue = data;
            }
        }
        private bool SchoolingCostExist(int classId, int cashFlowTypeId, int schoolYearId)
        {
            var item = Program.SchoolingCostList.FirstOrDefault(x => x.SchoolClassId == classId && x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return schoolingCostService.GetSchoolingCost(classId, cashFlowTypeId, schoolYearId).Result != null;
        }
    }
}
