using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddTuitionDiscountForm:SchoolManagement.UI.EditTuitionDiscountForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        private List<SchoolingCost> selectedSchoolFeeList;
        public AddTuitionDiscountForm(ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp)
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
            CashFlowTypeDropDownList.SelectedValueChanged += CashFlowTypeDropDownList_SelectedValueChanged;
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

        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear=Program.SchoolYearList.FirstOrDefault(x=>x.Id==enrolling.SchoolYearId);
            this.selectedEnrolling = enrolling;
            StudentTextBox.Text= enrolling.Student.FullName;
            ClassTextBox.Text=enrolling.SchoolClass.Name;
            SchoolYearTextBox.Text=enrolling.SchoolYear.Name;
            LoadReasonList(enrolling.ClassId);


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
                var cashFlowType= CashFlowTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                if (!RecordExist(selectedEnrolling.Id, cashFlowType.Id)) {
                    var discount = new TuitionDiscount()
                    {
                        Enrolling = selectedEnrolling,
                        EnrollingId = selectedEnrolling.Id,
                        Amount = double.Parse(DiscountTextBox.Text),
                        Date = DateTime.Now,
                        Reason = ReasonTextBox.Text,
                        OrderedBy = this.OrdoredByTextBox.Text,
                        CashFlowTypeId = cashFlowType.Id,
                        CashFlowType = cashFlowType
                    };
                    //enregistrement de la réduction
                    var isDone = cashFlowService.CreateTuitionDiscount(discount).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log logPayment = new()
                        {
                            UserAction = $"Ajout d'une réduction de  {discount.Amount} pour {discount.CashFlowType.Name} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logPayment);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    this.ErrorProvider.SetError(CashFlowTypeDropDownList, Language.messageRecordExist);
                    ErrorLabel.Text += Language.messageRecordExist;
                }
            }
        }

        private bool RecordExist(int enrollingId,int cashflowTypeId)
        {
            
            return cashFlowService.GetTuitionDiscount(enrollingId,cashflowTypeId).Result != null;
        }

    }
}
