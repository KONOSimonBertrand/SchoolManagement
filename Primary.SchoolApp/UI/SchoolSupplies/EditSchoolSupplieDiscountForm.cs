

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditSchoolSupplieDiscountForm:SchoolManagement.UI.EditSchoolSupplieDiscountForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolSupplieService schoolSupplieService;
        private SchoolSupplieDiscount selectedDiscount;
        private List<SchoolSupplieFee> selectedSchoolSupplieFeeList;
        public EditSchoolSupplieDiscountForm(ILogService logService, ClientApp clientApp, ISchoolSupplieService schoolSupplieService )
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolSupplieService = schoolSupplieService;
            this.DiscountTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelDiscountOnAmount,0));
            this.DiscountTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelDiscountOnQuantity,1));
            this.DiscountTypeDropDownList.SelectedIndex = 0;
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
                    var selectedItem = selectedSchoolSupplieFeeList.FirstOrDefault(x => x.CashFlowTypeId == reason.Id);
                    this.CostTextBox.Text = selectedItem.Amount.ToString();
                    this.QuantityTextBox.Text = selectedItem.RequiredQuantity.ToString();
                }
            }
        }

        internal void Init(SchoolSupplieDiscount discount)
        {
            this.selectedDiscount = discount;
            StudentTextBox.Text = discount.Enrolling.Student.FullName;
            ClassTextBox.Text = discount.Enrolling.SchoolClass.Name;
            SchoolYearTextBox.Text = discount.Enrolling.SchoolYear.Name;
            this.DiscountTextBox.Text = discount.Discount.ToString();
            this.ReasonTextBox.Text = discount.Reason;
            this.OrdoredByTextBox.Text = discount.OrderedBy;
            this.CashFlowTypeDropDownList.ReadOnly = true;
            LoadReasonList(discount.Enrolling.ClassId);
            this.CashFlowTypeDropDownList.SelectedIndex = -1;
            CashFlowTypeDropDownList.SelectedValueChanged += CashFlowTypeDropDownList_SelectedValueChanged;
            this.CashFlowTypeDropDownList.SelectedValue = discount.CashFlowType;
            this.DiscountTypeDropDownList.SelectedValue= discount.DiscountType;

        }
        //load cashflowtype list
        private void LoadReasonList(int classId)
        {
            selectedSchoolSupplieFeeList = Program.SchoolSupplieFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            this.CashFlowTypeDropDownList.DataSource = selectedSchoolSupplieFeeList.Select(x => x.CashFlowType).ToList();
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
                selectedDiscount.Discount= double.Parse(DiscountTextBox.Text);
                selectedDiscount.Reason = ReasonTextBox.Text;
                selectedDiscount.OrderedBy = OrdoredByTextBox.Text;
                selectedDiscount.DiscountType=int.Parse(DiscountTypeDropDownList.SelectedValue.ToString());
                //enregistrement de la réduction
                var isDone = schoolSupplieService.UpdateSchoolSupplieDiscount(selectedDiscount).Result;
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
