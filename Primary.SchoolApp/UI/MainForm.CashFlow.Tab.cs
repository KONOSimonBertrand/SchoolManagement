using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private void InitCashFlowPage()
        {
            InitCashFlowLeftView();
            InitCashFlowGridView();
            InitCashFlowGridViewForTuitionPayments();
            InitCashFlowPageEvents();
        }
        private void InitCashFlowPageEvents()
        {
            CashFlowLeftListView.SelectedItemChanged += CashFlowLeftListView_SelectedItemChanged;
            CashFlowAddButton.Click += CashFlowAddButton_Click;
            CashFlowGridView.ContextMenuOpening += CashFlowGridView_ContextMenuOpening;
            CashFlowSearchTextBox.TextChanged += CashFlowSearchTextBox_TextChanged;
            CashFlowGridView.CustomFiltering += CashFlowGridView_CustomFiltering;
            CashFlowExportToExcelButton.Click += (o, ev) => {
                AppUtilities.ExportGridViewToExcel(CashFlowGridView, Language.TitleCashFlowList);
            };
        }
        private void CashFlowGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            CashFlowGridViewCustomFiltering(e);
        }
        private void CashFlowGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                //get authorization modules
                Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                // create  and show the good context menu
                switch (CashFlowLeftListView.SelectedIndex)
                {
                    case 0:// Frais de scolarité
                        if (CashFlowGridView.CurrentRow.DataBoundItem is TuitionPayment selectedPayment)
                        {
                            //validate payment
                            if (!selectedPayment.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidatePaymentMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }

                            //return payment
                            if (!selectedPayment.IdNumber.ToLower().Contains("return") && selectedPayment.IsValidated)
                            {
                                RadMenuItem menuReturnPayment = new(Language.labelReturn);
                                menuReturnPayment.Image = AppUtilities.GetImage("Undo");
                                menuReturnPayment.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                                e.ContextMenu.Items.Add(menuReturnPayment);
                                //return payment
                                menuReturnPayment.Click += (o, ev) =>
                                {
                                    if (!Program.CurrentSchoolYear.IsClosed)
                                    {
                                        ReturnPayment(selectedPayment);
                                    }
                                    else
                                    {
                                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                                    }
                                };
                            }

                            //print
                            RadMenuItem printMenu = new(Language.labelPrintReceipt);
                            printMenu.Image = AppUtilities.GetImage("Printer");
                            printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowPrint == true);
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {
                                selectedPayment.Enrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == selectedPayment.EnrollingId).AsStudentEnrolling();
                                selectedPayment.Enrolling.SchoolYear = Program.CurrentSchoolYear;
                                printService.PrintPaymentReceiptAsync(selectedPayment, true);
                            };
                        }
                        break;
                    case 1: //Abonnement
                        if (CashFlowGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                        {
                            //validate
                            if (!selectedSubscription.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidateSubscriptionMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }
                            //return subscription
                            if (!selectedSubscription.IdNumber.ToLower().Contains("return") && selectedSubscription.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn);
                                returnMenu.Image = AppUtilities.GetImage("Undo");
                                returnMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                                e.ContextMenu.Items.Add(returnMenu);

                                //Return subscription
                                returnMenu.Click += (o, ev) =>
                                {
                                    if (!Program.CurrentSchoolYear.IsClosed)
                                    {
                                        ReturnSubscription(selectedSubscription);
                                    }
                                    else
                                    {
                                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                                    }
                                };
                            }
                            RadMenuItem printMenu = new(Language.labelPrintReceipt);
                            printMenu.Image = AppUtilities.GetImage("Printer");
                            printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {
                                printService.PrintPaymentReceiptAsync(selectedSubscription, true);
                            };
                        }

                        break;
                    case 2:
                        if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxIn selectedCashBoxIn)
                        {
                            //validate
                            if (!selectedCashBoxIn.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidateCashBoxInMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }
                            //return CashBoxIn
                            if (!selectedCashBoxIn.IdNumber.ToLower().Contains("return") && selectedCashBoxIn.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn);
                                returnMenu.Image = AppUtilities.GetImage("Undo");
                                returnMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                                e.ContextMenu.Items.Add(returnMenu);

                                //Return subscription
                                returnMenu.Click += (o, ev) =>
                                {
                                    if (!Program.CurrentSchoolYear.IsClosed)
                                    {
                                        ReturnCashBoxIn(selectedCashBoxIn);
                                    }
                                    else
                                    {
                                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                                    }
                                };
                            }
                            RadMenuItem printMenu = new(Language.labelPrintReceipt);
                            printMenu.Image = AppUtilities.GetImage("Printer");
                            printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {
                                
                            };
                        }

                        break;
                    case 3:
                        if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxOut selectedCashBoxOut)
                        {
                            //validate
                            if (!selectedCashBoxOut.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidateCashBoxOutMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }
                            //return CashBoxOut
                            if (!selectedCashBoxOut.IdNumber.ToLower().Contains("return") && selectedCashBoxOut.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn);
                                returnMenu.Image = AppUtilities.GetImage("Undo");
                                returnMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                                e.ContextMenu.Items.Add(returnMenu);

                                //Return subscription
                                returnMenu.Click += (o, ev) =>
                                {
                                    if (!Program.CurrentSchoolYear.IsClosed)
                                    {
                                        ReturnCashBoxOut(selectedCashBoxOut);
                                    }
                                    else
                                    {
                                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                                    }
                                };
                            }
                            RadMenuItem printMenu = new(Language.labelPrintReceipt);
                            printMenu.Image = AppUtilities.GetImage("Printer");
                            printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {

                            };
                        }

                        break;
                }

            }
        }
        // validation d'une dépense
        private void ValidateCashBoxOutMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxOut selectedCashBoxOut)
                {
                    if (selectedCashBoxOut != null && selectedCashBoxOut.IsValidated == false)
                    {
                        var isValidated = cashFlowService.ValidateCashBoxOut(selectedCashBoxOut.Id).Result;
                        if (isValidated)
                        {
                            selectedCashBoxOut.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de la dépense {selectedCashBoxOut.IdNumber} d'un montant de {selectedCashBoxOut.Amount} pour {selectedCashBoxOut.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(logValidate);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedCashBoxOut.Amount,
                                CashFlowType = selectedCashBoxOut.CashFlowType,
                                CashFlowTypeId = selectedCashBoxOut.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedCashBoxOut.DoneBy,
                                SchoolYear = Program.CurrentSchoolYear,
                                SchoolYearId = Program.CurrentSchoolYear.Id,
                                Note = $"{Language.LabelExpense} {selectedCashBoxOut.IdNumber}: {selectedCashBoxOut.CashFlowType.Name}",
                            };
                            var isDone = cashFlowService.CreateCashFlow(cashFlow).Result;
                            if (isDone)
                            {
                                InitCashFlowGridViewForData();
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(logCash);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(Language.MessageValidateError);
                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        // return expense
        private void ReturnCashBoxOut(CashBoxOut selectedCashBoxOut)
        {
            if (selectedCashBoxOut != null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var recordExist = cashFlowService.GetCashBoxOut(selectedCashBoxOut.IdNumber + "-return").Result != null;

                    if (!recordExist)
                    {
                        var cashbox = new CashBoxOut()
                        {
                            IdNumber = selectedCashBoxOut.IdNumber,
                            Date = selectedCashBoxOut.Date,
                            DoneBy = selectedCashBoxOut.DoneBy,
                            Note = selectedCashBoxOut.Note,
                            SchoolYear = selectedCashBoxOut.SchoolYear,
                            SchoolYearId = selectedCashBoxOut.SchoolYearId,
                            Amount = selectedCashBoxOut.Amount,
                            CashFlowType = selectedCashBoxOut.CashFlowType,
                            CashFlowTypeId = selectedCashBoxOut.CashFlowTypeId,

                        };
                        var isDone = cashFlowService.ReturnCashBoxOut(cashbox).Result;
                        if (isDone)
                        {
                            var recordAdded = cashFlowService.GetCashBoxOut(selectedCashBoxOut.IdNumber + "-return").Result;
                            if (recordAdded != null)
                            {
                                cashbox.Id = recordAdded.Id;
                                Program.CashBoxOutList.Add(cashbox);
                            }
                            InitCashFlowGridViewForData();

                            Log log = new()
                            {
                                UserAction = $"Retour de la dépense {selectedCashBoxOut.CashFlowType.Name} {selectedCashBoxOut.IdNumber}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(log);
                        }
                        else
                        {
                            RadMessageBox.Show(Language.messageAddError);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageReturnAllreadyDone);
                    }
                }
            }
        }
        // retour d'un approvisionnement
        private void ReturnCashBoxIn(CashBoxIn selectedCashBoxIn)
        {
            if (selectedCashBoxIn!= null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var recordExist = cashFlowService.GetCashBoxIn(selectedCashBoxIn.IdNumber + "-return").Result != null;

                    if (!recordExist)
                    {
                        var cashbox = new CashBoxIn()
                        {
                            IdNumber = selectedCashBoxIn.IdNumber,
                            Date = selectedCashBoxIn.Date,
                            DoneBy = selectedCashBoxIn.DoneBy,
                            Note = selectedCashBoxIn.Note,
                            SchoolYear = selectedCashBoxIn.SchoolYear,
                            SchoolYearId = selectedCashBoxIn.SchoolYearId,
                            Amount = selectedCashBoxIn.Amount,
                            CashFlowType = selectedCashBoxIn.CashFlowType,
                            CashFlowTypeId = selectedCashBoxIn.CashFlowTypeId,

                        };
                        var isDone = cashFlowService.ReturnCashBoxIn(cashbox).Result;
                        if (isDone)
                        {
                            var recordAdded = cashFlowService.GetCashBoxIn(selectedCashBoxIn.IdNumber + "-return").Result;
                            if (recordAdded != null) {
                                cashbox.Id = recordAdded.Id;
                                Program.CashBoxInList.Add(cashbox);
                            }
                            InitCashFlowGridViewForData();
      
                            Log log = new()
                            {
                                UserAction = $"Retour de l'approvisionnement {selectedCashBoxIn.CashFlowType.Name} {selectedCashBoxIn.IdNumber}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(log);
                        }
                        else
                        {
                            RadMessageBox.Show(Language.messageAddError);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageReturnAllreadyDone);
                    }
                }
            }
        }
        // validation d'un approvisionnement
        private void ValidateCashBoxInMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxIn selectedCashBoxIn)
                {
                    if (selectedCashBoxIn != null && selectedCashBoxIn.IsValidated == false)
                    {
                        var isValidated = cashFlowService.ValidateCashBoxIn(selectedCashBoxIn.Id).Result;
                        if (isValidated)
                        {
                            selectedCashBoxIn.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de l'approvisionnement {selectedCashBoxIn.IdNumber} d'un montant de {selectedCashBoxIn.Amount} pour {selectedCashBoxIn.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(logValidate);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedCashBoxIn.Amount,
                                CashFlowType = selectedCashBoxIn.CashFlowType,
                                CashFlowTypeId = selectedCashBoxIn.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedCashBoxIn.DoneBy,
                                SchoolYear = Program.CurrentSchoolYear,
                                SchoolYearId = Program.CurrentSchoolYear.Id,
                                Note = $"{Language.LabelSupply} {selectedCashBoxIn.IdNumber}: {selectedCashBoxIn.CashFlowType.Name}",
                            };
                            var isDone = cashFlowService.CreateCashFlow(cashFlow).Result;
                            if (isDone)
                            {
                                InitCashFlowGridViewForData();
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(logCash);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(Language.MessageValidateError);
                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        // validation d'un abonnement
        private void ValidateSubscriptionMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                {
                    if (selectedSubscription != null && selectedSubscription.IsValidated == false)
                    {
                        var isValidated = subscriptionService.ValidateSubscriptionAsync(selectedSubscription.Id).Result;
                        if (isValidated)
                        {
                            selectedSubscription.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de l'abonnement {selectedSubscription.IdNumber} d'un montant de {selectedSubscription.Amount} pour {selectedSubscription.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(logValidate);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedSubscription.Amount,
                                CashFlowType = selectedSubscription.CashFlowType,
                                CashFlowTypeId = selectedSubscription.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedSubscription.DoneBy,
                                SchoolYear = Program.CurrentSchoolYear,
                                SchoolYearId = Program.CurrentSchoolYear.Id,
                                Note = $"{Language.labelSubscription} {selectedSubscription.IdNumber}: {selectedSubscription.CashFlowType.Name}  {selectedSubscription.Student.FullName}",
                            };
                            var isDone = cashFlowService.CreateCashFlow(cashFlow).Result;
                            if (isDone)
                            {
                                InitCashFlowGridViewForData();
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(logCash);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(Language.MessageValidateError);
                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //Validate tuition payment
        private void ValidatePaymentMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is TuitionPayment selectedPayment)
                {
                    if (selectedPayment != null && selectedPayment.IsValidated == false)
                    {
                        var isValidated = cashFlowService.ValidateTuitionPayment(selectedPayment.Id).Result;
                        if (isValidated)
                        {
                            selectedPayment.IsValidated = true;
                            var selectedEnrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == selectedPayment.EnrollingId);
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation du paiement {selectedPayment.IdNumber} d'un montant de {selectedPayment.Amount} pour {selectedPayment.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(logValidate);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedPayment.Amount,
                                CashFlowType = selectedPayment.CashFlowType,
                                CashFlowTypeId = selectedPayment.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedPayment.DoneBy,
                                SchoolYear = Program.CurrentSchoolYear,
                                SchoolYearId = Program.CurrentSchoolYear.Id,
                                Note = $"{Language.labelPayment} {selectedPayment.IdNumber}:{selectedPayment.CashFlowType.Name}  {selectedEnrolling.Student.FullName}",
                            };
                            var isDone = cashFlowService.CreateCashFlow(cashFlow).Result;
                            if (isDone)
                            {
                              //refresh list
                                InitCashFlowGridViewForData();
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(logCash);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(Language.MessageValidateError);
                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //Return Subscription
        private void ReturnSubscription(Subscription selectedSubscription)
        {
            if (selectedSubscription != null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var recordExist = subscriptionService.GetSubscriptionAsync(selectedSubscription.IdNumber + "-return").Result != null;
                    if (!recordExist)
                    {
                        var subscription = new Subscription()
                        {
                            Amount = selectedSubscription.Amount,
                            CashFlowType = selectedSubscription.CashFlowType,
                            CashFlowTypeId = selectedSubscription.CashFlowTypeId,
                            Discount = selectedSubscription.Discount,
                            DoneBy = selectedSubscription.DoneBy,
                            EndDate = selectedSubscription.EndDate,
                            Student = selectedSubscription.Student,
                            StudentId = selectedSubscription.StudentId,
                            SchoolYear = selectedSubscription.SchoolYear,
                            SchoolYearId = selectedSubscription.SchoolYearId,
                            PaymentMean = selectedSubscription.PaymentMean,
                            PaymentMeanId = selectedSubscription.PaymentMeanId,
                            StartDate = selectedSubscription.StartDate,
                            TransactionDate = selectedSubscription.TransactionDate,
                            TransactionId = selectedSubscription.TransactionId,
                            IdNumber = selectedSubscription.IdNumber
                        };
                        var isDone = subscriptionService.ReturnSubscriptionAsync(subscription).Result;
                        if (isDone)
                        {
                            var recordAdded= subscriptionService.GetSubscriptionAsync(selectedSubscription.IdNumber+"-return").Result;
                            if(recordAdded != null)
                            {
                                subscription.Id = recordAdded.Id;
                                Program.SubscriptionList.Add(subscription);
                            }
                            InitCashFlowGridViewForData();
                            Log log = new()
                            {
                                UserAction = $"Retour de l'abonnement {selectedSubscription.CashFlowType.Name}  de l'élève {selectedSubscription.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logService.CreateLog(log);
                            printService.PrintPaymentReceiptAsync(subscription, false);
                        }
                        else
                        {
                            RadMessageBox.Show(Language.messageAddError);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageReturnAllreadyDone);
                    }
                }
            }
        }

        // retourne un payement
        private void ReturnPayment(TuitionPayment selectedPayment)
        {
            DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                selectedPayment.Enrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == selectedPayment.EnrollingId).AsStudentEnrolling();
                selectedPayment.Enrolling.SchoolYear = Program.CurrentSchoolYear;
              
                var paymentExsit = cashFlowService.GetTuitionPayment(selectedPayment.IdNumber+"-return").Result!=null;
                if (!paymentExsit)
                {
                    var payment = new TuitionPayment()
                    {
                        Date = DateTime.Now,
                        Amount = selectedPayment.Amount,
                        TransactionDate = selectedPayment.TransactionDate,
                        TransactionId = selectedPayment.TransactionId,
                        Enrolling = selectedPayment.Enrolling,
                        EnrollingId = selectedPayment.EnrollingId,
                        CashFlowType = selectedPayment.CashFlowType,
                        CashFlowTypeId = selectedPayment.CashFlowTypeId,
                        PaymentMean = selectedPayment.PaymentMean,
                        PaymentMeanId = selectedPayment.PaymentMeanId,
                        Balance = selectedPayment.Balance,
                        IdNumber = selectedPayment.IdNumber,
                        Note = selectedPayment.Note,
                        DoneBy = selectedPayment.DoneBy,
                        IsDuringEnrolling = selectedPayment.IsDuringEnrolling,
                        
                    };
                    var isDone = cashFlowService.ReturnTuitionPayment(payment).Result;
                    if (isDone)
                    {
                        var recordAdded = cashFlowService.GetTuitionPayment(selectedPayment.IdNumber + "-return").Result;
                        if (recordAdded != null)
                        {
                            payment.Id = recordAdded.Id;
                            Program.TuitionPaymentList.Add(payment);
                        }
                        InitCashFlowGridViewForData();
                        Log log = new()
                        {
                            UserAction = $"Retour du versement {payment.Amount}  de l'élève {selectedPayment.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        //impression du reçu
                        printService.PrintPaymentReceiptAsync(payment, false);
                    }
                    else
                    {
                        RadMessageBox.Show(Language.messageDeleteError);
                    }
                }
                else
                {
                    RadMessageBox.Show(Language.messageReturnAllreadyDone);
                }
            }
        }

        private void CashFlowAddButton_Click(object sender, EventArgs e)
        {
            switch (CashFlowLeftListView.SelectedIndex)
            {
                case 0:
                    var pForm = Program.ServiceProvider.GetService<AddTuitionPaymentForm>();
                    pForm.Text = Language.labelAdd + ":.." + Language.labelPayment;
                    pForm.Icon = this.Icon;
                    pForm.Init(Program.StudentEnrollingList.Select(x=>x.Student).ToList());
                    if (pForm.ShowDialog(this) == DialogResult.OK)
                    {
                        InitCashFlowGridViewForData();
                    }
                    break;
                case 1:
                    var sForm = Program.ServiceProvider.GetService<AddSubscriptionForm>();
                    sForm.Text = Language.labelAdd + ":.." + Language.labelSubscription;
                    sForm.Icon = this.Icon;
                    sForm.InitStartup(Program.StudentEnrollingList.Select(x => x.Student).ToList());
                    if (sForm.ShowDialog(this) == DialogResult.OK)
                    {
                        InitCashFlowGridViewForData();
                    }
                    break;
                case 2:
                    var iForm = Program.ServiceProvider.GetService<AddOtherCashFlowForm>();
                    iForm.Text = Language.labelAdd + ":.." + Language.LabelSupply;
                    iForm.Icon = this.Icon;
                    iForm.Init(2);
                    if (iForm.ShowDialog(this) == DialogResult.OK)
                    {
                        InitCashFlowGridViewForData();
                    }
                    break;
                case 3:
                    var oForm = Program.ServiceProvider.GetService<AddOtherCashFlowForm>();
                    oForm.Text = Language.labelAdd + ":.." + Language.LabelExpense;
                    oForm.Icon = this.Icon;
                    oForm.Init(3);
                    if (oForm.ShowDialog(this) == DialogResult.OK)
                    {
                        InitCashFlowGridViewForData();
                    }
                    break;
            }
        }

        private void CashFlowLeftListView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (CashFlowLeftListView.SelectedItem != null)
            {
                InitCashFlowGridViewForData();
                if (CashFlowLeftListView.SelectedIndex < 2)
                {
                    CashFlowSearchTextBox.NullText = $"{Language.MessageSearchBy} {Language.LabelReference}, {Language.labelIdTransaction}, {Language.labelPaymentMean}, {Language.LabelValidation}, {Language.labelCashFlowType}";
                    if(CashFlowLeftListView.SelectedIndex==0) CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowCreate == true);
                    else CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowCreate == true);
                }
                else
                {
                    if (CashFlowLeftListView.SelectedIndex == 2) CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 15 && x.AllowCreate == true);
                    else CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 16 && x.AllowCreate == true);
                    CashFlowSearchTextBox.NullText = $"{Language.MessageSearchBy} {Language.LabelReference}, {Language.labelNote}, {Language.LabelValidation}, {Language.labelCashFlowType}";
                }
            }
        }

        private void InitCashFlowGridViewForData()
        {
            CashFlowGridView.Templates.Clear();
            CashFlowGridView.MasterTemplate.Reset();

            switch (CashFlowLeftListView.SelectedIndex)
            {
                case 0:
                    InitCashFlowGridViewForTuitionPayments();
                    break;
                case 1:
                    InitCashFlowGridViewForSubscriptions();
                    break;
                default:
                    InitCashFlowGridViewForCashBox();
                    break;
            }
        }

        private void InitCashFlowLeftView()
        {
            ListViewDataItemGroup cashFlowListViewGroup = new ListViewDataItemGroup();
            cashFlowListViewGroup.Text = Language.labelCashFlowTypes.ToUpper();
            CashFlowLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { cashFlowListViewGroup });
            CashFlowLeftListView.ShowCheckBoxes = false;
            ListViewDataItem fsItem = new()
            {
                Key = 0,
                Value = Language.labelSchoolingFee.ToUpper(),
                Tag = Language.labelSchoolingFee.ToUpper(),
                Text = Language.labelSchoolingFee.ToUpper(),
                Group = cashFlowListViewGroup
            };
            ListViewDataItem abItem = new()
            {
                Key = 1,
                Value = Language.labelSubscription.ToUpper(),
                Tag = Language.labelSubscription.ToUpper(),
                Text = Language.labelSubscription.ToUpper(),
                Group = cashFlowListViewGroup
            };

           
            ListViewDataItem apItem = new()
            {
                Key = 2,
                Value = Language.LabelSupply.ToUpper(),
                Tag = Language.LabelSupply.ToUpper(),
                Text = Language.LabelSupply.ToUpper(),
                Group = cashFlowListViewGroup
            };
            ListViewDataItem deItem = new()
            {
                Key = 3,
                Value = Language.LabelExpense.ToUpper(),
                Tag = Language.LabelExpense.ToUpper(),
                Text = Language.LabelExpense.ToUpper(),
                Group = cashFlowListViewGroup
            };
            CashFlowLeftListView.Items.Add(fsItem);
            CashFlowLeftListView.Items.Add(abItem);        
            CashFlowLeftListView.Items.Add(apItem);
            CashFlowLeftListView.Items.Add(deItem);
            CashFlowLeftListView.ShowGroups = false;
            CashFlowLeftListView.SelectedIndex = 0;
        }
        private void InitCashFlowGridView()
        {
            CashFlowGridView.AutoGenerateColumns = false;
            CashFlowGridView.ReadOnly = true;
            CashFlowGridView.MasterTemplate.EnableFiltering = true;
            CashFlowGridView.EnableFiltering = true;
            CashFlowGridView.EnableCustomFiltering = true;
            CashFlowGridView.ShowFilteringRow = false;
            CashFlowGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void InitCashFlowGridViewForTuitionPayments()
        {
            using (CashFlowGridView.DeferRefresh())
            {
                GridViewTextBoxColumn idNumberColumn = new("IdNumber");
                GridViewDateTimeColumn dateColumn = new("Date");
                GridViewDecimalColumn amountColumn = new("Amount");
                GridViewTextBoxColumn paymentMeanColumn = new("PaymentMean");
                GridViewTextBoxColumn transactionIdColumn = new("TransactionId");
                GridViewDateTimeColumn transactionDateColumn = new("TransactionDate");
                GridViewTextBoxColumn cashFlowColumn = new("CashFlowType");
                GridViewTextBoxColumn isValidatedColumn = new("IsValidated");
                GridViewTextBoxColumn validationStateColumn = new("ValidattionState");
               

                foreach (GridViewDataColumn col in CashFlowGridView.Columns)
                {
                    col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
                }
                isValidatedColumn.IsVisible = false;
                dateColumn.Width = 80;
                amountColumn.Width = 100;
                idNumberColumn.Width = 100;
                paymentMeanColumn.Width = 300;
                transactionIdColumn.Width = 150;
                transactionDateColumn.Width = 100;
                validationStateColumn.Width = 100;
                cashFlowColumn.Width = 150;
                dateColumn.HeaderText = "Date";
                amountColumn.HeaderText = Language.labelAmount;
                idNumberColumn.HeaderText = Language.LabelReference;
                paymentMeanColumn.HeaderText = Language.labelPaymentMean;
                transactionIdColumn.HeaderText = Language.labelIdTransaction;
                transactionDateColumn.HeaderText = Language.labelDateTransaction;
                validationStateColumn.HeaderText = Language.LabelValidation;
                cashFlowColumn.HeaderText = Language.labelSchoolingFee;
                dateColumn.Format = DateTimePickerFormat.Custom;
                dateColumn.CustomFormat = "dd-MM-yyyy";
                dateColumn.FormatString = "{0:dd-MM-yyyy}";
                dateColumn.TextAlignment = ContentAlignment.MiddleLeft;
                transactionDateColumn.Format = DateTimePickerFormat.Custom;
                transactionDateColumn.CustomFormat = "dd-MM-yyyy";
                transactionDateColumn.FormatString = "{0:dd-MM-yyyy}";
                transactionDateColumn.TextAlignment = ContentAlignment.MiddleLeft;
                ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true);
                c1.RowBackColor = Color.FromArgb(255, 209, 140);
                c1.CellBackColor = Color.FromArgb(255, 209, 140);
                c1.RowForeColor = Color.Black;
                c1.CellForeColor = Color.Black;
                isValidatedColumn.ConditionalFormattingObjectList.Add(c1);

                CashFlowGridView.Columns.Add(idNumberColumn);
                CashFlowGridView.Columns.Add(dateColumn);
                CashFlowGridView.Columns.Add(amountColumn);
                CashFlowGridView.Columns.Add(paymentMeanColumn);
                CashFlowGridView.Columns.Add(cashFlowColumn);
                CashFlowGridView.Columns.Add(transactionDateColumn);
                CashFlowGridView.Columns.Add(transactionIdColumn);
                CashFlowGridView.Columns.Add(validationStateColumn);
                CashFlowGridView.Columns.Add(isValidatedColumn);
                CashFlowGridView.DataSource = Program.TuitionPaymentList.OrderByDescending(x => x.Id);
            }
        }
        private void InitCashFlowGridViewForSubscriptions()
        {
            using (CashFlowGridView.DeferRefresh())
            {
                GridViewTextBoxColumn idNumberColumn = new("IdNumber");
                GridViewDateTimeColumn startDateColumn = new("StartDate");
                GridViewDecimalColumn amountColumn = new("Amount");
                GridViewTextBoxColumn paymentMeanColumn = new("PaymentMean");
                GridViewTextBoxColumn transactionIdColumn = new("TransactionId");
                GridViewDateTimeColumn endDateColumn = new("EndDate");
                GridViewDateTimeColumn transactionDateColumn = new("TransactionDate");
                GridViewTextBoxColumn cashFlowTypeColumn = new("CashFlowType");
                GridViewTextBoxColumn isValidatedColumn = new("IsValidated");
                GridViewTextBoxColumn validationStateColumn = new("ValidattionState");
                foreach (GridViewDataColumn col in CashFlowGridView.Columns)
                {
                    col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
                }
                isValidatedColumn.IsVisible = false;
                endDateColumn.IsVisible = false;
                startDateColumn.Width = 80;
                idNumberColumn.Width = 100;
                transactionDateColumn.Width = 100;
                amountColumn.Width = 100;
                paymentMeanColumn.Width = 200;
                transactionIdColumn.Width = 120;
                endDateColumn.Width = 80;
                cashFlowTypeColumn.Width = 300;
                validationStateColumn.Width = 100;
                idNumberColumn.HeaderText = Language.LabelReference;
                startDateColumn.HeaderText = "Date";
                transactionDateColumn.HeaderText = Language.labelDateTransaction;
                amountColumn.HeaderText = Language.labelAmount;
                paymentMeanColumn.HeaderText = Language.labelPaymentMean;
                transactionIdColumn.HeaderText = Language.labelIdTransaction;
                endDateColumn.HeaderText = Language.labelDateTransaction;
                cashFlowTypeColumn.HeaderText = Language.labelSubscription;
                validationStateColumn.HeaderText = Language.LabelValidation; 

                startDateColumn.Format = DateTimePickerFormat.Custom;
                startDateColumn.CustomFormat = "dd-MM-yyyy";
                startDateColumn.FormatString = "{0:dd-MM-yyyy}";
                startDateColumn.TextAlignment = ContentAlignment.MiddleLeft;
                endDateColumn.Format = DateTimePickerFormat.Custom;
                endDateColumn.CustomFormat = "dd-MM-yyyy";
                endDateColumn.FormatString = "{0:dd-MM-yyyy}";
                endDateColumn.TextAlignment = ContentAlignment.MiddleLeft;
                transactionDateColumn.Format = DateTimePickerFormat.Custom;
                transactionDateColumn.CustomFormat = "dd-MM-yyyy";
                transactionDateColumn.FormatString = "{0:dd-MM-yyyy}";
                transactionDateColumn.TextAlignment = ContentAlignment.MiddleLeft;

                ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true);
                c1.RowBackColor = Color.FromArgb(255, 209, 140);
                c1.CellBackColor = Color.FromArgb(255, 209, 140);
                c1.RowForeColor = Color.Black;
                c1.CellForeColor = Color.Black;
                isValidatedColumn.ConditionalFormattingObjectList.Add(c1);

                CashFlowGridView.Columns.Add(idNumberColumn);
                CashFlowGridView.Columns.Add(startDateColumn);
                CashFlowGridView.Columns.Add(amountColumn);
                CashFlowGridView.Columns.Add(paymentMeanColumn);
                CashFlowGridView.Columns.Add(cashFlowTypeColumn);
                CashFlowGridView.Columns.Add(transactionDateColumn);
                CashFlowGridView.Columns.Add(transactionIdColumn);
                CashFlowGridView.Columns.Add(endDateColumn);
                CashFlowGridView.Columns.Add(isValidatedColumn);
                CashFlowGridView.Columns.Add(validationStateColumn);
                //load subscriptions
                CashFlowGridView.DataSource = Program.SubscriptionList.OrderByDescending(x => x.Id);
            
            }
        }
        private void InitCashFlowGridViewForCashBox()
        {
            using (CashFlowGridView.DeferRefresh())
            {
                GridViewDateTimeColumn dateColumn = new("Date");
                GridViewTextBoxColumn idNumberColumn = new("IdNumber");
                GridViewDecimalColumn amountColumn = new("Amount");
                GridViewTextBoxColumn noteColumn = new("Note");
                GridViewTextBoxColumn cashFlowTypeColumn = new("CashFlowType");
                GridViewTextBoxColumn isValidatedColumn = new("IsValidated");
                GridViewTextBoxColumn validationStateColumn = new("ValidattionState");
                isValidatedColumn.IsVisible=false;
                dateColumn.Width = 80;
                amountColumn.Width = 80;
                idNumberColumn.Width = 100;
                cashFlowTypeColumn.Width = 150;
                idNumberColumn.Width = 100;
                noteColumn.Width = 220;
                idNumberColumn.HeaderText = Language.LabelReference;
                validationStateColumn.HeaderText = Language.LabelValidation;
                amountColumn.HeaderText = Language.labelAmount;
                cashFlowTypeColumn.HeaderText= Language.labelReason;
                dateColumn.Format = DateTimePickerFormat.Custom;
                dateColumn.CustomFormat = "dd-MM-yyyy";
                dateColumn.FormatString = "{0:dd-MM-yyyy}";
                dateColumn.TextAlignment = ContentAlignment.MiddleLeft;

                CashFlowGridView.MasterTemplate.Columns.Add(idNumberColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(dateColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(amountColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(cashFlowTypeColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(noteColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(validationStateColumn);
                CashFlowGridView.MasterTemplate.Columns.Add(isValidatedColumn);
                GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("IdNumber", " {0}", GridAggregateFunction.Count),
                new GridViewSummaryItem("Amount", " {0}", GridAggregateFunction.Sum)
            };
                CashFlowGridView.MasterTemplate.SummaryRowsBottom.Clear();
                CashFlowGridView.MasterTemplate.SummaryRowsBottom.Add(total);

                ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true);
                c1.RowBackColor = Color.FromArgb(255, 209, 140);
                c1.CellBackColor = Color.FromArgb(255, 209, 140);
                c1.RowForeColor = Color.Black;
                c1.CellForeColor = Color.Black;
                isValidatedColumn.ConditionalFormattingObjectList.Add(c1);
                foreach (GridViewDataColumn col in CashFlowGridView.Columns)
                {
                    col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
                }
                CashFlowGridView.DataSource=CashFlowLeftListView.SelectedIndex==2? Program.CashBoxInList.OrderByDescending(x => x.Id):Program.CashBoxOutList.OrderByDescending(x => x.Id);
            }
        }

        //recherche des données correspondantes pour lancer des filtres
        private void CashFlowSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            CashFlowGridView.MasterTemplate.Refresh();    
        }
        // cash flow filtering
        private async void CashFlowGridViewCustomFiltering(GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (this.CashFlowSearchTextBox.Text != null)
            {
                if (CashFlowLeftListView.SelectedIndex<2)
                {
                    e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["TransactionId"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["ValidattionState"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["CashFlowType"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["PaymentMean"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower());
                }
                else
                {
                    e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Note"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["ValidattionState"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["CashFlowType"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower());
                }
            }
            await System.Threading.Tasks.Task.Delay(0);
        }


    }
}
