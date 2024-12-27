

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
    internal class EditSchoolingCostForm : SchoolManagement.UI.EditSchoolingCostForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolingCostService schoolingCostService;
        private readonly ISchoolYearService schoolYearService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly ISchoolClassService schoolClassService;
        private SchoolingCost schoolingCost;
        private struct SchoolingCostTracker
        {
            public int ClassId { get; set; }
            public int CostTypeId { get; set; }
            public int SchoolYearId { get; set; }
        }
        private SchoolingCostTracker schoolingCostTracker;
        public EditSchoolingCostForm(ISchoolingCostService schoolingCostService, ILogService logService, ClientApp clientApp,
            ISchoolYearService schoolYearService, ICashFlowTypeService cashFlowTypeService, ISchoolClassService schoolClassService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolingCostService = schoolingCostService;
            this.schoolYearService = schoolYearService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.schoolClassService = schoolClassService;
            ClassDropDownList.DataSource = Program.SchoolClassList;
            CostTypeDropDownList.DataSource = Program.CashFlowTypeList.Where(x => x.Category == "FS");
            SchoolYearDropDownList.DataSource = Program.SchoolYearList;
            schoolingCostTracker = new SchoolingCostTracker();
            InitTranchesGridView();
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
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
                var item = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                if (item != null)
                {
                    ShowCashFlowTypeEditForm(item);
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
            if (ClassDropDownList.SelectedItem == null)
            {
                ShowSchoolClassAddForm();
            }
            else
            {
                var item = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                if (item != null)
                {
                    ShowSchoolClassEditForm(item);
                }
                else
                {
                    RadMessageBox.Show(Language.messageUnknowClass);
                }
            }
        }
        internal void Init(SchoolingCost schoolingCost)
        {
            this.schoolingCost = schoolingCost;
            ClassDropDownList.SelectedValue = schoolingCost.SchoolClassId;
            SchoolYearDropDownList.SelectedValue = schoolingCost.SchoolYearId;
            CostTypeDropDownList.SelectedValue = schoolingCost.CashFlowTypeId;
            CostPayableDropDownList.SelectedValue = schoolingCost.IsPayable.ToString();
            AmountTextBox.Text = schoolingCost.Amount.ToString();
            schoolingCostTracker.SchoolYearId = schoolingCost.SchoolYearId;
            schoolingCostTracker.ClassId = schoolingCost.SchoolClassId;
            schoolingCostTracker.CostTypeId = schoolingCost.CashFlowTypeId;
            TrancheNumberTextBox.Text = schoolingCost.TrancheNumber.ToString();
            PopulateTranchesGridView(schoolingCost);
            TrancheNumberTextBox.TextChanged += TrancheNumberTextBox_TextChanged;

        }

        private void TrancheNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TrancheNumberTextBox.Text != "")
            {
                int trancheNumber = int.Parse(TrancheNumberTextBox.Text);
                if (trancheNumber > 3)
                {
                    ErrorLabel.Text = Language.messageBadTrancheNumber;
                    TrancheNumberTextBox.Text = "3";
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
                        Id = i,
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
        //Chargement des données dans le gridView
        private async void PopulateTranchesGridView(SchoolingCost schoolingCost)
        {
            var getData = await schoolingCostService.GetSchoolingCostItems(schoolingCost.Id);
            IList<SchoolingCostItem> listToLoad = new List<SchoolingCostItem>();
            foreach (var item in getData)
            {
                listToLoad.Add(
                    new SchoolingCostItem()
                    {
                        Rank =item.Rank,
                        Amount = item.Amount,
                        DeadLine = item.DeadLine,
                    }
                    );
            }
            TranchesGridView.DataSource = listToLoad;
            //foreach (var row in TranchesGridView.Rows)
            //{
            //    row.Height = 30;
            //}
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (IsValidTrancheValue(int.Parse(TrancheNumberTextBox.Text)))
                {
                    int yearId = int.Parse(SchoolYearDropDownList.SelectedValue.ToString());
                    int typeId = int.Parse(CostTypeDropDownList.SelectedValue.ToString());
                    int classId = int.Parse(ClassDropDownList.SelectedValue.ToString());

                    if (!SchoolingCostExist(classId, typeId, yearId))
                    {
                        schoolingCost.SchoolYear = SchoolYearDropDownList.SelectedItem.DataBoundItem as SchoolYear;
                        schoolingCost.SchoolClassId = schoolingCost.SchoolYear.Id;
                        schoolingCost.SchoolClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                        schoolingCost.SchoolClassId = schoolingCost.SchoolClass.Id;
                        schoolingCost.CashFlowType = CostTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                        schoolingCost.CashFlowTypeId = schoolingCost.CashFlowType.Id;
                        schoolingCost.IsPayable = bool.Parse(CostPayableDropDownList.SelectedValue.ToString());
                        schoolingCost.TrancheNumber = int.Parse(TrancheNumberTextBox.Text);
                        schoolingCost.Amount = double.Parse(AmountTextBox.Text);
                        schoolingCost.SchoolingCostItems = new List<SchoolingCostItem>();
                        for (int i = 0; i < schoolingCost.TrancheNumber; i++)
                        {
                            var item = TranchesGridView.Rows[i].DataBoundItem as SchoolingCostItem;
                            schoolingCost.SchoolingCostItems.Add(
                                new SchoolingCostItem()
                                {
                                    Amount = item.Amount,
                                    DeadLine = item.DeadLine,
                                    SchoolingCostId = schoolingCost.Id,
                                }
                                );
                        }
                        bool isDone = schoolingCostService.UpdateSchoolingCost(schoolingCost).Result;
                        if (isDone == true)
                        {
                            Log log = new()
                            {
                                UserAction = $"Modification  des frais scolaires {schoolingCost.CashFlowType.Name} pour la classe {schoolingCost.SchoolClass.Name} pour l'année scolaire {schoolingCost.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                        this.ErrorLabel.Text = Language.messageFeeAlreadyExist;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageBadInstalment;
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
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassDropDownList.DataSource = null;
                    ClassDropDownList.DataSource = Program.SchoolClassList;
                    ClassDropDownList.SelectedValue = data;
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
                ClassDropDownList.DataSource = null;
                SchoolYearDropDownList.DataSource = Program.SchoolClassList;
                ClassDropDownList.SelectedValue = data;
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
            if (schoolingCostTracker.ClassId == classId && schoolingCostTracker.CostTypeId == cashFlowTypeId && schoolingCostTracker.SchoolYearId == schoolYearId) return false;
            var item = Program.SchoolingCostList.FirstOrDefault(x => x.SchoolClassId == classId && x.CashFlowTypeId == cashFlowTypeId && x.SchoolYearId == schoolYearId);
            if (item != null) return true;
            return schoolingCostService.GetSchoolingCost(classId, cashFlowTypeId, schoolYearId).Result != null;
        }
    }
}
