using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class AddSchoolSupplieDiscountForm : SchoolManagement.UI.EditSchoolSupplieDiscountForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolSupplieService schoolSupplieService;
        private StudentEnrolling selectedEnrolling;
        private List<SchoolSupplieFee> selectedSchoolSupplieFeeList;
        public AddSchoolSupplieDiscountForm(ILogService logService, ClientApp clientApp, ISchoolSupplieService schoolSupplieService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolSupplieService = schoolSupplieService;
            this.DiscountTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelDiscountOnAmount, 0));
            this.DiscountTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelDiscountOnQuantity, 1));
            this.DiscountTypeDropDownList.SelectedIndex = 0;
            InitEvents();
        }
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            selectedEnrolling = enrolling;
            StudentTextBox.Text = enrolling.Student.FullName;
            ClassTextBox.Text = enrolling.SchoolClass.Name;
            SchoolYearTextBox.Text = enrolling.SchoolYear.Name;
            LoadReasonList(enrolling.ClassId);


        }
        //load cashflowtype list
        private void LoadReasonList(int classId)
        {
            selectedSchoolSupplieFeeList = Program.SchoolSupplieFeeList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            CashFlowTypeDropDownList.DataSource = selectedSchoolSupplieFeeList.Select(x => x.CashFlowType).ToList();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            Shown += OnShown;
            CashFlowTypeDropDownList.SelectedValueChanged += CashFlowTypeDropDownList_SelectedValueChanged;
        }

        private void CashFlowTypeDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CashFlowTypeDropDownList.SelectedItem != null)
            {
                if (CashFlowTypeDropDownList.SelectedItem.DataBoundItem is CashFlowType reason)
                {
                    var selectedItem = selectedSchoolSupplieFeeList.FirstOrDefault(x => x.CashFlowTypeId == reason.Id);
                    CostTextBox.Text = selectedItem.Amount.ToString();
                    QuantityTextBox.Text = selectedItem.RequiredQuantity.ToString();
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            DiscountTextBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var cashFlowType = CashFlowTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                if (!RecordExist(selectedEnrolling.Id, cashFlowType.Id))
                {
                    var discount = new SchoolSupplieDiscount()
                    {
                        Enrolling = selectedEnrolling,
                        EnrollingId = selectedEnrolling.Id,
                        Discount = double.Parse(DiscountTextBox.Text),
                        DiscountType = int.Parse(DiscountTypeDropDownList.SelectedValue.ToString()),
                        Date = DateTime.Now,
                        Reason = ReasonTextBox.Text,
                        OrderedBy = OrdoredByTextBox.Text,
                        CashFlowTypeId = cashFlowType.Id,
                        CashFlowType = cashFlowType,
                        IsActive = true
                    };
                    //enregistrement de la réduction
                    var isDone = schoolSupplieService.CreateSchoolSupplieDiscount(discount).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Ajout d'une réduction de  {discount.Discount} pour {discount.CashFlowType.Name} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    ErrorProvider.SetError(CashFlowTypeDropDownList, Language.messageRecordExist);
                    ErrorLabel.Text += Language.messageRecordExist;
                }
            }
        }
        private bool RecordExist(int enrollingId, int cashflowTypeId)
        {
            var dataList = schoolSupplieService.GetSchoolSupplieDiscountByEnrollingList(enrollingId).Result;
            return dataList.Any(x => x.CashFlowTypeId == cashflowTypeId && x.IsActive);
        }
    }
}
