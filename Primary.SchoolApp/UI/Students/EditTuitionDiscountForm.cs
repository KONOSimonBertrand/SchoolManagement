using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Primary.SchoolApp
{
    internal class EditTuitionDiscountForm : SchoolManagement.UI.EditTuitionDiscountForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private TuitionDiscount selectedDiscount;
        private List<SchoolingCost> selectedSchoolFeeList;
        public EditTuitionDiscountForm(ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp)
        {
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void CashFlowTypeDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.CashFlowTypeDropDownList.SelectedItem != null)
            {
                if (this.CashFlowTypeDropDownList.SelectedItem.DataBoundItem is CashFlowType reason)
                {
                    var schoolFee = selectedSchoolFeeList.FirstOrDefault(x => x.CashFlowTypeId == reason.Id);
                    this.CostTextBox.Text = schoolFee.Amount.ToString();
                }
            }
        }

        internal void Init(TuitionDiscount discount)
        {
            this.selectedDiscount = discount;
            StudentTextBox.Text = discount.Enrolling.Student.FullName;
            ClassTextBox.Text = discount.Enrolling.SchoolClass.Name;
            SchoolYearTextBox.Text = discount.Enrolling.SchoolYear.Name;
            this.DiscountTextBox.Text = discount.Amount.ToString();          
            this.ReasonTextBox.Text = discount.Reason;
            this.OrdoredByTextBox.Text = discount.OrderedBy;
            this.CashFlowTypeDropDownList.ReadOnly = true;
            LoadReasonList(discount.Enrolling.ClassId);
            this.CashFlowTypeDropDownList.SelectedIndex = -1;
            CashFlowTypeDropDownList.SelectedValueChanged += CashFlowTypeDropDownList_SelectedValueChanged;
            this.CashFlowTypeDropDownList.SelectedValue = discount.CashFlowType;

        }
        //load cashflowtype list
        private void LoadReasonList(int classId)
        {
            var costList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            var reasonList = costList.Select(x => x.CashFlowType).ToList();
            selectedSchoolFeeList = costList;
            this.CashFlowTypeDropDownList.DataSource = reasonList;
        }

        private void OnShown(object sender, EventArgs e)
        {
            DiscountTextBox.Focus();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

                selectedDiscount.Date = DateTime.Now;
                selectedDiscount.Amount = double.Parse(DiscountTextBox.Text);
                selectedDiscount.Reason = ReasonTextBox.Text;
                selectedDiscount.OrderedBy = OrdoredByTextBox.Text;

                //enregistrement de la réduction
                var isDone = cashFlowService.UpdateTuitionDiscount(selectedDiscount).Result;
                if (isDone)
                {
                    //enregistrement du log
                    Log logPayment = new()
                    {
                        UserAction = $"mise à jour de la réduction  de {selectedDiscount.CashFlowType.Name} de l'élève {selectedDiscount.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(logPayment);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ErrorLabel.Text = Language.messageUpdateError;
                }
            }
        }

    }
}
