

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using SchoolManagement.Core.Enum;
using Primary.SchoolApp.Mapping;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
namespace Primary.SchoolApp.UI
{
    internal class AddOtherCashFlowForm:SchoolManagement.UI.EditOtherCashFlowForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private FlowType selectedType;
        private readonly ILogger<AddOtherCashFlowForm> logger;
        internal string LastIdNumber=string.Empty;
        public AddOtherCashFlowForm(ICashFlowService cashFlowService, ILogService logService, ILogger<AddOtherCashFlowForm> logger, ClientApp clientApp)
        {
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.logger = logger;
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

        internal void Init(FlowType selectedType)
        {
            this.selectedType = selectedType;
            this.CashFlowTypeDropDownList.DataSource = selectedType == FlowType.Inflow ? Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.CashSupply) : Program.CashFlowTypeList.Where(x => x.FlowCategory == FlowCategory.Expense);
        }

        private  async void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {
                var selectedCashFlowTypeDTO= CashFlowTypeDropDownList.SelectedItem.DataBoundItem as CashFlowTypeDTO;
                var selectedCashFlowType= selectedCashFlowTypeDTO.ToCashFlowType();
                string logMessage=string.Empty;
                bool isDone;
                //si c'est une dépense
                if (selectedType == FlowType.Inflow)
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
                    isDone = await cashFlowService.CreateCashBoxIn(cashBoxIn);
                    if (isDone)
                    {
                        logMessage = $"Ajout d'un approvisionnement de {cashBoxIn.Amount} pour {selectedCashFlowTypeDTO.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}";
                        logger.LogInformation(logMessage);
                        LastIdNumber = cashBoxIn.IdNumber;
                        var recordAdded = await cashFlowService.GetCashBoxIn(LastIdNumber);
                        if (recordAdded != null)
                        {
                            cashBoxIn.Id = recordAdded.Id;
                            Program.CashBoxInList.Add(cashBoxIn.ToCashBoxInDTO());
                        }
                    }
                    else
                    {
                        logger.LogError($"Une erreur est survenue lors l'ajout de d'un approvisionnement de {cashBoxIn.Amount} pour {selectedCashFlowTypeDTO.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
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
                    logMessage = $"Ajout d'une dépense de {cashBoxOut.Amount} pour {selectedCashFlowTypeDTO.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}";
                    logger.LogInformation(logMessage);
                    isDone = await cashFlowService.CreateCashBoxOut(cashBoxOut);
                    if (isDone)
                    {
                        LastIdNumber = cashBoxOut.IdNumber;
                        var recordAdded = await cashFlowService.GetCashBoxOut(LastIdNumber);
                        if (recordAdded != null)
                        {
                            cashBoxOut.Id = recordAdded.Id;
                            Program.CashBoxOutList.Add(cashBoxOut.ToCashBoxOutDTO());
                        }
                    }
                    else
                    {
                        logger.LogError($"Une erreur est survenue lors l'ajout de d'une dépense de {cashBoxOut.Amount} pour {selectedCashFlowTypeDTO.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
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
                    await logService.CreateLog(log);
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
