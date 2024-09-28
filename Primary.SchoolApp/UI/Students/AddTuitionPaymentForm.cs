using MediaFoundation;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddTuitionPaymentForm:SchoolManagement.UI.EditTuitionPaymentForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        private readonly IPrintService printService;
        private List<SchoolingCost> selectedSchoolFeeList;
        public AddTuitionPaymentForm(ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp, IPrintService printService)
        {
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.printService = printService;
            selectedEnrolling = new StudentEnrolling();
            selectedSchoolFeeList = new List<SchoolingCost>();
            this.PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;          
            InitEvents();
            
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            this.StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            this.ReasonDropDownList.SelectedValueChanged += ReasonDropDownList_SelectedValueChanged;
        }       
        private void StudentDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.StudentDropDownList.SelectedItem != null) { 
                if(this.StudentDropDownList.SelectedItem.DataBoundItem is Student student)
                {
                    this.ClassTextBox.Text = selectedEnrolling.SchoolClass.Name;
                    this.SchoolYearTextBox.Text = selectedEnrolling.SchoolYear.Name;
                    selectedSchoolFeeList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == selectedEnrolling.ClassId).OrderBy(x => x.CashFlowType.Sequence).ToList();
                    this.ReasonDropDownList.DataSource = selectedSchoolFeeList.Select(x => x.CashFlowType).ToList();
                }
            }
        }
        private void ReasonDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ReasonDropDownList.SelectedItem != null)
            {
                if (this.ReasonDropDownList.SelectedItem.DataBoundItem is CashFlowType reason)
                {
                    var paymentList = cashFlowService.GetTuitionPaymentByEnrollingList(selectedEnrolling.Id).Result;
                    var schoolFee = selectedSchoolFeeList.FirstOrDefault(x => x.CashFlowTypeId == reason.Id);
                    if (schoolFee != null)
                    {
                        this.CostTextBox.Text= schoolFee.Amount.ToString();
                        var amountPaid = paymentList.Where(x => x.CashFlowTypeId == reason.Id).Sum(x => x.Amount);
                        this.PaidTextBox.Text = amountPaid.ToString();
                        this.UnpaidTextBox.Text = (schoolFee.Amount - amountPaid).ToString();
                    }
                }
            }
        }
        private void OnShown(object sender, EventArgs e)
        {
            this.AmountTextBox.Focus();
        }
        internal void Init(StudentEnrolling enrolling) {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            this.selectedEnrolling = enrolling;
            this.StudentDropDownList.DataSource = new List<Student>() {
                enrolling.Student
            }; 
            this.StudentDropDownList.ReadOnly = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) { 
                var reason=this.ReasonDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                var paymentMean=this.PaymentMeanDropDownList.SelectedItem.DataBoundItem as PaymentMean;
                TuitionPayment payment =new () { 
                    Date=this.PaymentDateTimePicker.Value,
                    Amount = double.Parse(this.AmountTextBox.Text),
                    Balance=double.Parse(this.UnpaidTextBox.Text)- double.Parse(this.AmountTextBox.Text),
                    CashFlowType =reason,
                    CashFlowTypeId=reason.Id,
                    PaymentMean=paymentMean,
                    PaymentMeanId=paymentMean.Id,
                    TransactionDate=this.TransactionDateTimePicker.Value,
                    TransactionId=this.TransactionIdTextBox.Text,
                    DoneBy=this.DoneByTextBox.Text,
                    IsDuringEnrolling=false,
                    Enrolling=selectedEnrolling,
                    EnrollingId=selectedEnrolling.Id,                    
                };
                //add payment
                var isDone = cashFlowService.CreateTuitionPayment(payment).Result;
                if (isDone)
                {   
                    //enregistrement du log
                    Log logPayment = new()
                    {
                        UserAction = $"Ajout d'un versement de  {payment.Amount} pour {payment.CashFlowType.Name} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(logPayment);

                    //enregistrement du cashflow
                    var cashflow = new CashFlow()
                    {
                        Amount = payment.Amount,
                        CashFlowType = payment.CashFlowType,
                        CashFlowTypeId = payment.CashFlowTypeId,
                        Date = payment.Date,
                        DoneBy = payment.DoneBy,
                        SchoolYear = selectedEnrolling.SchoolYear,
                        SchoolYearId = selectedEnrolling.SchoolYearId,
                        Note = payment.CashFlowType.Name + " " + selectedEnrolling.Student.FullName,
                    };
                    if (cashFlowService.CreateCashFlow(cashflow).Result)
                    {
                        //enregistrement du log
                        Log logCash = new()
                        {
                            UserAction = $"Ajout d'un flux de trésorerie de {cashflow.Amount} pour {cashflow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logCash);
                    }
                    //impression du reçu
                    printService.PrintPaymentReceipt(payment, false);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
      
        
       
    }
}
