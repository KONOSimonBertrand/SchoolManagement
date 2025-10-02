

using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddSchoolSupplieForm:SchoolManagement.UI.EditSchoolSupplieForm
    {
        private readonly ISchoolSupplieService  schoolSupplieService;
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        private readonly IPrintService printService;
        private List<SchoolSupplieFee> selectedSchoolSupplieFeeList;
        private int selectedInitMethod = 0;
        internal string LastIdNumber = string.Empty;// is given when payment added

        public AddSchoolSupplieForm(ISchoolSupplieService schoolSupplieService, ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp,  IPrintService printService)
        {
            this.schoolSupplieService = schoolSupplieService;
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            selectedSchoolSupplieFeeList = new();
            this.PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            InitEvents();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
    
            DataGridView.MasterTemplate.EnableFiltering = true;
            DataGridView.EnableFiltering = true;
            DataGridView.ShowFilteringRow = false;
            DataGridView.AllowAddNewRow = false;
            DataGridView.AutoGenerateColumns = false;
            DataGridView.AllowDragToGroup = false;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            GridViewTextBoxColumn reasonColumn = new("CashFlowType.Name");
            GridViewTextBoxColumn idTransactionColumn = new("TransactionId");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDecimalColumn quantityColumn = new("Quantity");
            GridViewDateTimeColumn dateColumn = new("TransactionDate");
            GridViewComboBoxColumn paymentMeanColumn = new("PaymentMeanId");
            reasonColumn.ReadOnly = true;
            quantityColumn.ReadOnly = true;
            idTransactionColumn.ReadOnly = true;
            amountColumn.ReadOnly = true;
            dateColumn.ReadOnly = true;
            paymentMeanColumn.ReadOnly = true;
            reasonColumn.HeaderText = Language.LabelSchoolSupplie;
            amountColumn.HeaderText = Language.labelAmount;
            dateColumn.HeaderText = Language.labelDateTransaction;
            quantityColumn.HeaderText = Language.LabelQuantity;
            idTransactionColumn.HeaderText = Language.labelIdTransaction;
            paymentMeanColumn.HeaderText = Language.labelPaymentMean;
            reasonColumn.Width = 150;
            amountColumn.Width = 80;
            dateColumn.Width = 120;
            idTransactionColumn.Width = 150;
            paymentMeanColumn.Width = 150;
            quantityColumn.Width = 80;
            paymentMeanColumn.DataSource = Program.PaymentMeanList;
            paymentMeanColumn.ValueMember = "Id";
            paymentMeanColumn.DisplayMember = "FullName";

            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";

            DataGridView.Columns.Add(reasonColumn);
            DataGridView.Columns.Add(quantityColumn);
            DataGridView.Columns.Add(amountColumn);
            DataGridView.Columns.Add(dateColumn);
            DataGridView.Columns.Add(idTransactionColumn);
            DataGridView.Columns.Add(paymentMeanColumn);
           

            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Amount", " {0}", GridAggregateFunction.Sum),
                new GridViewSummaryItem("Balance", " {0}", GridAggregateFunction.Sum)
            };
            DataGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in DataGridView.Columns)
            {
                col.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            }
        }
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            this.selectedEnrolling = enrolling;
            this.StudentDropDownList.DataSource = new List<Student>() {
                enrolling.Student
            };
            this.StudentDropDownList.ReadOnly = true;
        }

        internal void Init(List<Student> students)
        {
            selectedInitMethod = 1;
            this.StudentDropDownList.DataSource = students;
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            this.StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            this.ReasonDropDownList.SelectedValueChanged += ReasonDropDownList_SelectedValueChanged;
            this.AddButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (this.Height < 546) this.Height = 750;
            }
        }

        private void StudentDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.StudentDropDownList.SelectedItem != null)
            {
                if (this.StudentDropDownList.SelectedItem.DataBoundItem is Student student)
                {
                    if (selectedInitMethod == 1)// if Init(List<Student>)
                    {
                        selectedEnrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.StudentId == student.Id).AsStudentEnrolling();
                        selectedEnrolling.SchoolYear = Program.CurrentSchoolYear;
                    }
                    selectedSchoolSupplieFeeList = Program.SchoolSupplieFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.SchoolClassId == selectedEnrolling.ClassId).OrderBy(x => x.CashFlowType.Sequence).ToList();
                    this.ReasonDropDownList.DataSource = selectedSchoolSupplieFeeList.Select(x => x.CashFlowType).ToList();
                    this.StudentInfoLabel.Text = "<html>"+Language.labelClass+": <b>"+selectedEnrolling.SchoolClass.Name+"</b>; "+
                                                          Language.labelSchoolYear+": <b>"+selectedEnrolling.SchoolYear.Name+"</b>; ";
                    
                }
            }
        }
        private void ReasonDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ReasonDropDownList.SelectedItem != null)
            {
                if (this.ReasonDropDownList.SelectedItem.DataBoundItem is CashFlowType reason)
                {
                    var supplieList = schoolSupplieService.GetSchoolSupplieByEnrollingList(selectedEnrolling.Id).Result;
                    var selectedFee = selectedSchoolSupplieFeeList.FirstOrDefault(x => x.CashFlowTypeId == reason.Id);
                    if (selectedFee != null)
                    {
                     
                        var paid = supplieList.Where(x => x.CashFlowTypeId == reason.Id).Sum(x => x.Amount);
                        var unPaid=selectedFee.Amount - paid;

                        this.SchoolSupplieInfoLabel.Text = "<html>" + Language.LabelUnitPrice + ": <b>" + selectedFee.Amount + "</b>; " +
                                                     Language.labelDiscount + ": <b>" + 0 + "</b>; " +
                                                     Language.labelPaid + ": <b>" + paid + "</b>; " +
                                                     Language.labelUnPaid + ": <b>" + unPaid + "</b>; ";
                    }
                }
            }
        }
        private void OnShown(object sender, EventArgs e)
        {
            this.QuantityTextBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
