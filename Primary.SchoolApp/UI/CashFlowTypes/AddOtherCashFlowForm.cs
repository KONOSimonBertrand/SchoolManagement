

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddOtherCashFlowForm:SchoolManagement.UI.EditOtherCashFlowForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private int selectedCategory;
        internal string LastIdNumber=string.Empty;
        public AddOtherCashFlowForm(ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp)
        {
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            InitEvents();
            this.clientApp = clientApp;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            CashFlowTypeDropDownList.SelectedIndexChanged += CashFlowTypeDropDownList_SelectedIndexChanged;
        }

        private void CashFlowTypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(CashFlowTypeDropDownList.SelectedItem.DataBoundItem is CashFlowType selectedRecord)
            {
                if (selectedRecord != null) {
                    CashFlowTypeDropDownList.RootElement.ToolTipText = selectedRecord.Name;
                }
            }
        }

        internal void Init(int selectedType)
        {
            this.selectedCategory = selectedType;
            this.CashFlowTypeDropDownList.DataSource = selectedType == 2 ? Program.CashFlowTypeList.Where(x => x.Category == "AP") : Program.CashFlowTypeList.Where(x => x.Category == "DE");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {
                var selectedCashFlowType= CashFlowTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                string logMessage;
                bool isDone;
                //si c'est une dépense
                if (selectedCategory == 2)
                {
                    var cashBoxIn = new CashBoxIn()
                    {
                        Amount = double.Parse(this.AmountTextBox.Text),
                        CashFlowType = selectedCashFlowType,
                        CashFlowTypeId = selectedCashFlowType.Id,
                        Date = TransactionDateTimePicker.Value,
                        DoneBy = DoneByTextBox.Text,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        Note = NoteTextBox.Text,
                    };
                    logMessage = $"Ajout d'un approvisionnement de {cashBoxIn.Amount} pour {selectedCashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}";
                    isDone = cashFlowService.CreateCashBoxIn(cashBoxIn).Result;
                    if (isDone)
                    {
                        LastIdNumber = cashBoxIn.IdNumber;
                        var recordAdded = cashFlowService.GetCashBoxIn(LastIdNumber).Result;
                        if (recordAdded != null)
                        {
                            cashBoxIn.Id = recordAdded.Id;
                            Program.CashBoxInList.Add(cashBoxIn);
                        }
                    }
                }
                else
                {
                    var cashBoxOut = new CashBoxOut()
                    {
                        Amount = double.Parse(this.AmountTextBox.Text),
                        CashFlowType = selectedCashFlowType,
                        CashFlowTypeId = selectedCashFlowType.Id,
                        Date = TransactionDateTimePicker.Value,
                        DoneBy = DoneByTextBox.Text,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        Note = NoteTextBox.Text,
                    };
                    logMessage = $"Ajout d'une dépense de {cashBoxOut.Amount} pour {selectedCashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}";
                    isDone = cashFlowService.CreateCashBoxOut(cashBoxOut).Result;
                    if (isDone)
                    {
                        LastIdNumber = cashBoxOut.IdNumber;
                        var recordAdded = cashFlowService.GetCashBoxOut(LastIdNumber).Result;
                        if (recordAdded != null)
                        {
                            cashBoxOut.Id = recordAdded.Id;
                            Program.CashBoxOutList.Add(cashBoxOut);
                        }
                    }
                }
                if (isDone)
                {
                    //enregistrement du log
                    Log log = new()
                    {
                        UserAction = logMessage,
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ErrorLabel.Text = Language.messageAddError;
                }
            }
        }
    }
}
