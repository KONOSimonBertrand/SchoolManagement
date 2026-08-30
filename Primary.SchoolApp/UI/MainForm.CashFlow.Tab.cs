using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Mapping;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private string cashFlowLeftViewForToolTipText;
        private void InitCashFlowPage()
        {
            InitCashFlowLeftView();
            InitCashFlowGridView();
            InitCashFlowGridViewForReceipts();
            InitCashFlowPageEvents();
        }
        private void InitCashFlowPageEvents()
        {
            CashFlowLeftListView.SelectedItemChanged += CashFlowLeftListView_SelectedItemChanged;
            CashFlowLeftListView.ItemMouseHover += CashFlowLeftListView_ItemMouseHover;
            CashFlowLeftListView.ToolTipTextNeeded += CashFlowLeftListView_ToolTipTextNeeded;
            CashFlowAddButton.Click += CashFlowAddButton_Click;
            CashFlowGridView.ContextMenuOpening += CashFlowGridView_ContextMenuOpening;
            CashFlowSearchTextBox.TextChanged += CashFlowSearchTextBox_TextChanged;
            CashFlowGridView.CustomFiltering += CashFlowGridView_CustomFiltering;
            CashFlowExportToExcelButton.Click += (o, ev) =>
            {
                AppUtilities.ExportGridViewToExcel(CashFlowGridView, Language.TitleCashFlowList);
            };
        }


        #region Methods
        // return expense
        private void ReturnCashBoxOut(CashBoxOut selectedCashBoxOut)
        {
            if (selectedCashBoxOut != null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var recordExist = cashFlowService.GetCashBoxOut(selectedCashBoxOut.IdNumber + "-R").Result != null;

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
                            var recordAdded = cashFlowService.GetCashBoxOut(selectedCashBoxOut.IdNumber + "-R").Result;
                            if (recordAdded != null)
                            {
                                cashbox.Id = recordAdded.Id;
                                Program.CashBoxOutList.Add(cashbox);
                            }
                            CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);

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
            if (selectedCashBoxIn != null)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var recordExist = cashFlowService.GetCashBoxIn(selectedCashBoxIn.IdNumber + "-R").Result != null;

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
                            var recordAdded = cashFlowService.GetCashBoxIn(selectedCashBoxIn.IdNumber + "-R").Result;
                            if (recordAdded != null)
                            {
                                cashbox.Id = recordAdded.Id;
                                Program.CashBoxInList.Add(cashbox);
                            }
                            CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
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
        // Création d'une validation
        private async Task<bool> CreateValidationTuitionPayment(TuitionPayment payment)
        {
            bool isDone = false;
            if (payment != null && !payment.IsValidated)
            {
                var isValidated = await cashFlowService.ValidateTuitionPayment(payment.Id);
                if (isValidated)
                {
                    payment.IsValidated = true;
                    isDone = true;
                    var selectedEnrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == payment.EnrollingId);
                    //enregistrement du log de validation
                    Log logValidate = new()
                    {
                        UserAction = $"Validation du paiement {payment.IdNumber} d'un montant de {payment.Amount} pour {payment.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    await logService.CreateLog(logValidate);
                    logger.LogInformation(logValidate.UserAction);
                    //create cash flow
                    var cashFlow = new CashFlow()
                    {
                        Amount = payment.Amount,
                        CashFlowType = payment.CashFlowType,
                        CashFlowTypeId = payment.CashFlowTypeId,
                        Date = DateTime.Now,
                        DoneBy = payment.DoneBy,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        Note = $"{Language.labelPayment} {payment.IdNumber}:{payment.CashFlowType.Name}  {selectedEnrolling.Student.FullName}",
                    };
                    if (await cashFlowService.CreateCashFlow(cashFlow))
                    {

                        Log logCash = new()
                        {
                            UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(logCash);
                        logger.LogInformation(logCash.UserAction);
                    }
                    else
                    {
                        logger.LogError(
                            "Une erreur est survenue lors de l'ajout d'un flux de trésorerie de {Amount} pour {CashFlowTypeName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                            cashFlow.Amount,
                            cashFlow.CashFlowType.Name,
                            clientApp.UserConnected.UserName,
                            clientApp.IpAddress
                        );
                    }
                }
                else
                {
                    logger.LogWarning(
                        "La Validation du paiement {IdNumber} d'un montant de {Amount} pour {CashFlowTypeName}  par l'utilisateur {user} sur le poste {IpAddress} n'a pas été réalisée.",
                        payment.IdNumber,
                        payment.Amount,
                        payment.CashFlowType.Name,
                        clientApp.UserConnected.UserName,
                        clientApp.IpAddress
                        );
                }
            }
            return isDone;
        }
        private async Task<bool> CreateValidationSubscription(Subscription subscription)
        {
            bool isDone = false;
            if (subscription != null && !subscription.IsValidated)
            {
                var isValidated = await subscriptionService.ValidateSubscriptionAsync(subscription.Id);
                if (isValidated)
                {
                    var selectedEnrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == subscription.EnrollingId);
                    subscription.IsValidated = true;
                    isDone = true;
                    //enregistrement du log de validation
                    Log logValidate = new()
                    {
                        UserAction = $"Validation du paiement {subscription.IdNumber} d'un montant de {subscription.Amount} pour {subscription.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    await logService.CreateLog(logValidate);
                    logger.LogInformation(logValidate.UserAction);
                    //create cash flow
                    var cashFlow = new CashFlow()
                    {
                        Amount = subscription.Amount,
                        CashFlowType = subscription.CashFlowType,
                        CashFlowTypeId = subscription.CashFlowTypeId,
                        Date = DateTime.Now,
                        DoneBy = subscription.DoneBy,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        Note = $"{Language.labelSubscription} {subscription.IdNumber}:{subscription.CashFlowType.Name}  {selectedEnrolling?.Student?.FullName}",
                    };
                    if (await cashFlowService.CreateCashFlow(cashFlow))
                    {
                        Log logCash = new()
                        {
                            UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(logCash);
                        logger.LogInformation(logCash.UserAction);
                    }
                    else
                    {
                        logger.LogError(
                            "Une erreur est survenue lors de l'ajout d'un flux de trésorerie de {Amount} pour {CashFlowTypeName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                            cashFlow.Amount,
                            cashFlow.CashFlowType.Name,
                            clientApp.UserConnected.UserName,
                            clientApp.IpAddress
                        );
                    }
                }
                else
                {
                    logger.LogError(
                        "Une erreur est survenue lors de la Validation du paiement {IdNumber} d'un montant de {Amount} pour {CashFlowTypeName}  par l'utilisateur {user} sur le poste {IpAddress}",
                        subscription.IdNumber,
                        subscription.Amount,
                        subscription.CashFlowType.Name,
                        clientApp.UserConnected.UserName,
                        clientApp.IpAddress
                        );
                }
            }
            return isDone;
        }
        private async Task<bool> CreateValidationSchoolSupplie(SchoolSupplie supplie)
        {
            bool isDone = false;
            if (supplie != null && !supplie.IsValidated)
            {
                var isValidated = await schoolSupplieService.ValidateSchoolSupplie(supplie.Id);
                if (isValidated)
                {
                    supplie.IsValidated = true;
                    isDone = true;
                    var selectedEnrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == supplie.EnrollingId);
                    //enregistrement du log de validation
                    Log logValidate = new()
                    {
                        UserAction = $"Validation du paiement {supplie.IdNumber} d'un montant de {supplie.Amount} pour {supplie.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    await logService.CreateLog(logValidate);
                    logger.LogInformation(logValidate.UserAction);
                    //create cash flow
                    var cashFlow = new CashFlow()
                    {
                        Amount = supplie.Amount,
                        CashFlowType = supplie.CashFlowType,
                        CashFlowTypeId = supplie.CashFlowTypeId,
                        Date = DateTime.Now,
                        DoneBy = supplie.DoneBy,
                        SchoolYear = Program.CurrentSchoolYear,
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        Note = $"{Language.LabelSchoolSupplie} {supplie.IdNumber}:{supplie.CashFlowType.Name}  {selectedEnrolling.Student.FullName}",
                    };
                    if (await cashFlowService.CreateCashFlow(cashFlow))
                    {

                        Log logCash = new()
                        {
                            UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(logCash);
                        logger.LogInformation(logCash.UserAction);
                    }
                    else
                    {
                        logger.LogError(
                            "Une erreur est survenue lors de l'ajout d'un flux de trésorerie de {Amount} pour {CashFlowTypeName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                            cashFlow.Amount,
                            cashFlow.CashFlowType.Name,
                            clientApp.UserConnected.UserName,
                            clientApp.IpAddress
                        );
                    }
                }
                else
                {
                    logger.LogError(
                        "Une erreur est survenue lors de la Validation du paiement {IdNumber} d'un montant de {Amount} pour {CashFlowTypeName}  par l'utilisateur {user} sur le poste {IpAddress}",
                        supplie.IdNumber,
                        supplie.Amount,
                        supplie.CashFlowType.Name,
                        clientApp.UserConnected.UserName,
                        clientApp.IpAddress
                        );
                }
            }
            return isDone;
        }
        //Return Subscription
        private async Task<bool> CreateReturnSubscription(Subscription subscription, Receipt receipt)
        {
            bool isDone = false;
            if (subscription != null)
            {
                var returnExist = await subscriptionService.GetSubscriptionAsync(subscription.IdNumber + "-R") != null;
                if (!returnExist)
                {
                    var returnSubscription = new Subscription()
                    {
                        Amount = subscription.Amount,
                        CashFlowType = subscription.CashFlowType,
                        CashFlowTypeId = subscription.CashFlowTypeId,
                        DoneBy = subscription.DoneBy,
                        EndDate = subscription.EndDate,
                        Enrolling = subscription.Enrolling,
                        EnrollingId = subscription.EnrollingId,
                        PaymentMean = subscription.PaymentMean,
                        PaymentMeanId = subscription.PaymentMeanId,
                        StartDate = subscription.StartDate,
                        TransactionDate = subscription.TransactionDate,
                        TransactionId = subscription.TransactionId,
                        IdNumber = subscription.IdNumber,
                        Receipt = receipt,
                        ReceiptId = receipt.Id,
                        IsValidated = false

                    };
                    isDone = await subscriptionService.ReturnSubscriptionAsync(returnSubscription);
                    if (isDone)
                    {
                        var recordAdded = await subscriptionService.GetSubscriptionAsync(subscription.IdNumber + "-R");
                        if (recordAdded != null)
                        {
                            returnSubscription.Id = recordAdded.Id;
                            Program.SubscriptionList.Add(recordAdded);
                        }
                        Log log = new()
                        {
                            UserAction = $"Retour de l'abonnement {returnSubscription.CashFlowType.Name} ({returnSubscription.IdNumber})  de l'élève {subscription.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(log);
                        logger.LogInformation(log.UserAction);
                    }
                    else
                    {
                        logger.LogError($"Le retour de l'abonnement {subscription.CashFlowType.Name} ({returnSubscription.IdNumber})  de l'élève {subscription.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé.");
                        RadMessageBox.Show(Language.messageAddError);
                    }
                }
                else { 
                    logger.LogError($"Le retour de l'abonnement {subscription.CashFlowType.Name} ({subscription.IdNumber})  de l'élève {subscription.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé car il existe déjà.");
                }
            }
            return isDone;
        }
        // retourne un payement
        private async Task<bool> CreateReturnPayment(TuitionPayment payment, Receipt receipt)
        {
            bool isDone = false;
            payment.Enrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == payment.EnrollingId).AsStudentEnrolling();
            payment.Enrolling.SchoolYear = Program.CurrentSchoolYear;

            var returnExist = await cashFlowService.GetTuitionPayment(payment.IdNumber + "-R") != null;
            if (!returnExist)
            {
                var returnPayment = new TuitionPayment()
                {
                    Date = DateTime.Now,
                    Amount = payment.Amount,
                    TransactionDate = payment.TransactionDate,
                    TransactionId = payment.TransactionId,
                    Enrolling = payment.Enrolling,
                    EnrollingId = payment.EnrollingId,
                    CashFlowType = payment.CashFlowType,
                    CashFlowTypeId = payment.CashFlowTypeId,
                    PaymentMean = payment.PaymentMean,
                    PaymentMeanId = payment.PaymentMeanId,
                    Balance = payment.Balance,
                    IdNumber = payment.IdNumber,
                    Note = payment.Note,
                    DoneBy = payment.DoneBy,
                    IsValidated = false,
                    Receipt = receipt,
                    ReceiptId = receipt.Id,

                };
                isDone = await cashFlowService.ReturnTuitionPayment(returnPayment);
                if (isDone)
                {
                    var recordAdded = await cashFlowService.GetTuitionPayment(payment.IdNumber + "-R");
                    if (recordAdded != null)
                    {
                        returnPayment.Id = recordAdded.Id;
                        Program.TuitionPaymentList.Add(recordAdded);
                    }
                    Log log = new()
                    {
                        UserAction = $"Retour frais scolaire {returnPayment.CashFlowType.Name} ({returnPayment.IdNumber}) de {returnPayment.Amount}  de l'élève {payment.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    await logService.CreateLog(log);
                    logger.LogInformation(log.UserAction);
                }
                else
                {
                    logger.LogError($"Le retour frais scolaire {returnPayment.CashFlowType.Name} ({returnPayment.IdNumber}) de {returnPayment.Amount}  de l'élève {payment.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé.");
                    RadMessageBox.Show(Language.messageAddError);
                }
            }
            else
            {
                logger.LogError($"Le retour frais scolaire {payment.CashFlowType.Name} ({payment.IdNumber}) de {payment.Amount}  de l'élève {payment.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé car il existe déjà.");
            }
            return isDone;
        }
        // return school supplie
        private async Task<bool> CreateReturnSchoolSupplie(SchoolSupplie supplie, Receipt receipt)
        {
            bool isDone = false;
            supplie.Enrolling = Program.StudentEnrollingList.FirstOrDefault(x => x.Id == supplie.EnrollingId).AsStudentEnrolling();
            supplie.Enrolling.SchoolYear = Program.CurrentSchoolYear;

            var returnExist = await schoolSupplieService.GetSchoolSupplie(supplie.IdNumber + "-R") != null;
            if (!returnExist)
            {
                var returnSupplie = new SchoolSupplie()
                {
                    Date = DateTime.Now,
                    Amount = supplie.Amount,
                    Quantity = supplie.Quantity,
                    TransactionDate = supplie.TransactionDate,
                    TransactionId = supplie.TransactionId,
                    Enrolling = supplie.Enrolling,
                    EnrollingId = supplie.EnrollingId,
                    CashFlowType = supplie.CashFlowType,
                    CashFlowTypeId = supplie.CashFlowTypeId,
                    PaymentMean = supplie.PaymentMean,
                    PaymentMeanId = supplie.PaymentMeanId,
                    Balance = supplie.Balance,
                    IdNumber = supplie.IdNumber,
                    DoneBy = supplie.DoneBy,
                    IsValidated = false,
                    Receipt = receipt,
                    ReceiptId = receipt.Id,

                };
                isDone = await schoolSupplieService.ReturnSchoolSupplie(returnSupplie);
                if (isDone)
                {
                    var recordAdded = await schoolSupplieService.GetSchoolSupplie(supplie.IdNumber + "-R");
                    if (recordAdded != null)
                    {
                        returnSupplie.Id = recordAdded.Id;
                        Program.SchoolSupplieList.Add(recordAdded);
                    }
                    Log log = new()
                    {
                        UserAction = $"Retour fourniture scolaire {returnSupplie.CashFlowType.Name} ({returnSupplie.IdNumber}) de {returnSupplie.Amount}  de l'élève {supplie.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    await logService.CreateLog(log);
                    logger.LogInformation(log.UserAction);
                }
                else
                {
                    logger.LogError($"Le retour fourniture scolaire {returnSupplie.CashFlowType.Name} ({returnSupplie.IdNumber}) de {returnSupplie.Amount}  de l'élève {supplie.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé.");
                    RadMessageBox.Show(Language.messageAddError);
                }
            }
            else
            {
                logger.LogError($"Le retour fourniture scolaire {supplie.CashFlowType.Name} ({supplie.IdNumber}) de {supplie.Amount}  de l'élève {supplie.Enrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé car il existe déjà.");
            }
            return isDone;
        }

        private void InitCashFlowGridViewForData()
        {
            CashFlowGridView.Templates.Clear();
            CashFlowGridView.MasterTemplate.Reset();

            switch (CashFlowLeftListView.SelectedItem.Key)
            {
                case 0:
                    InitCashFlowGridViewForTuitionPayments();
                    break;
                case 1:
                    InitCashFlowGridViewForSubscriptions();
                    break;
                case 2:
                case 3:
                    InitCashFlowGridViewForCashBox();
                    break;
                case 4:
                    InitCashFlowGridViewForSchoolSupplies();
                    break;
                case 5:
                    InitCashFlowGridViewForReceipts();
                    break;
            }
        }
        //init left view
        private void InitCashFlowLeftView()
        {
            ListViewDataItemGroup cashFlowListViewGroup = new()
            {
                Text = Language.labelCashFlowTypes.ToUpper()
            };
            CashFlowLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { cashFlowListViewGroup });
            CashFlowLeftListView.ShowCheckBoxes = false;

            CashFlowLeftListView.Items.Add(
                    new ListViewDataItem()
                    {
                        Key = 5,
                        Value = Language.labelPayments.ToUpper(),
                        Tag = Language.labelPayments.ToUpper(),
                        Text = Language.labelPayments.ToUpper(),
                        Group = cashFlowListViewGroup
                    }
                   );

            if (Program.UserConnected.Modules.Any(m => m.ModuleId == 3 && m?.AllowCreate == true))
            {
                CashFlowLeftListView.Items.Add(
                     new ListViewDataItem()
                     {
                         Key = 0,
                         Value = Language.labelSchoolingFee.ToUpper(),
                         Tag = Language.labelSchoolingFee.ToUpper(),
                         Text = Language.labelSchoolingFee.ToUpper(),
                         Group = cashFlowListViewGroup
                     }
                    );
            }
            if (Program.UserConnected.Modules.Any(m => m.ModuleId == 18 && m?.AllowCreate == true))
            {
                CashFlowLeftListView.Items.Add(
                     new ListViewDataItem()
                     {
                         Key = 4,
                         Value = Language.LabelSchoolSupplieFees.ToUpper(),
                         Tag = Language.LabelSchoolSupplieFees.ToUpper(),
                         Text = Language.LabelSchoolSupplieFees.Trim().Length > 20 ? string.Concat(Language.LabelSchoolSupplieFees.AsSpan(0, 20), "...").ToUpper() : Language.LabelSchoolSupplieFees.ToUpper(),
                         Group = cashFlowListViewGroup
                     }
                    );
            }
            if (Program.UserConnected.Modules.Any(m => m.ModuleId == 4 && m?.AllowCreate == true))
            {
                CashFlowLeftListView.Items.Add(
                     new ListViewDataItem()
                     {
                         Key = 1,
                         Value = Language.labelSubscription.ToUpper(),
                         Tag = Language.labelSubscription.ToUpper(),
                         Text = Language.labelSubscription.ToUpper(),
                         Group = cashFlowListViewGroup
                     }
                    );
            }
            if (Program.UserConnected.Modules.Any(m => m.ModuleId == 15 && m?.AllowCreate == true))
            {
                CashFlowLeftListView.Items.Add(
                     new ListViewDataItem()
                     {
                         Key = 2,
                         Value = Language.LabelSupply.ToUpper(),
                         Tag = Language.LabelSupply.ToUpper(),
                         Text = Language.LabelSupply.ToUpper(),
                         Group = cashFlowListViewGroup
                     }
                    );
            }
            if (Program.UserConnected.Modules.Any(m => m.ModuleId == 15 && m?.AllowCreate == true))
            {
                CashFlowLeftListView.Items.Add(
                     new ListViewDataItem()
                     {
                         Key = 3,
                         Value = Language.LabelExpense.ToUpper(),
                         Tag = Language.LabelExpense.ToUpper(),
                         Text = Language.LabelExpense.ToUpper(),
                         Group = cashFlowListViewGroup
                     }
                    );
            }

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

        private void InitCashFlowGridViewForReceipts()
        {
            using (CashFlowGridView.DeferRefresh())
            {
                CashFlowGridView.Columns.Clear();
                CashFlowGridView.Templates.Clear();
                CashFlowGridView.Relations.Clear();
                GridViewDecimalColumn idColumn = new("Id");
                GridViewTextBoxColumn idNumberColumn = new("IdNumber");
                GridViewDateTimeColumn dateColumn = new("Date");
                GridViewDecimalColumn amountColumn = new("Amount");
                GridViewDecimalColumn opForColumn = new("OpFor");
                GridViewTextBoxColumn isValidatedColumn = new("IsValidated");
                GridViewTextBoxColumn validationStateColumn = new("ValidattionState");

                foreach (GridViewDataColumn col in CashFlowGridView.Columns)
                {
                    col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
                }
                idColumn.IsVisible = false;
                isValidatedColumn.IsVisible = false;
                dateColumn.Width = 80;
                amountColumn.Width = 100;
                idNumberColumn.Width = 100;
                opForColumn.Width = 250;
                dateColumn.HeaderText = "Date";
                amountColumn.HeaderText = Language.labelAmount;
                idNumberColumn.HeaderText = Language.LabelReference;
                opForColumn.HeaderText = Language.labelReason;
                validationStateColumn.HeaderText = Language.LabelValidation;
                dateColumn.Format = DateTimePickerFormat.Custom;
                dateColumn.CustomFormat = "dd-MM-yyyy";
                dateColumn.FormatString = "{0:dd-MM-yyyy}";
                dateColumn.TextAlignment = ContentAlignment.MiddleLeft;
                ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true)
                {
                    RowBackColor = Color.FromArgb(255, 209, 140),
                    CellBackColor = Color.FromArgb(255, 209, 140),
                    RowForeColor = Color.Black,
                    CellForeColor = Color.Black
                };
                isValidatedColumn.ConditionalFormattingObjectList.Add(c1);

                CashFlowGridView.Columns.Add(idColumn);
                CashFlowGridView.Columns.Add(idNumberColumn);
                CashFlowGridView.Columns.Add(dateColumn);
                CashFlowGridView.Columns.Add(amountColumn);
                CashFlowGridView.Columns.Add(opForColumn);
                CashFlowGridView.Columns.Add(validationStateColumn);
                CashFlowGridView.Columns.Add(isValidatedColumn);

                GridViewTemplate template = new();
                GridViewDecimalColumn receiptItemIdColumn = new("Id");
                GridViewTextBoxColumn itemIdNumberColumn = new("Reference");
                GridViewDecimalColumn receiptIdColumn = new("ReceiptId");
                GridViewTextBoxColumn receiptItemNameColumn = new("ItemName");
                GridViewDecimalColumn receiptItemAmountColumn = new("UnitPrice");
                GridViewDecimalColumn quantityColumn = new("Quantity");

                receiptItemIdColumn.HeaderText = "Id";
                receiptIdColumn.HeaderText = "Id";
                itemIdNumberColumn.HeaderText = Language.LabelReference;
                receiptItemNameColumn.HeaderText = Language.labelDesignation;
                receiptItemAmountColumn.HeaderText = Language.labelAmount;

                quantityColumn.HeaderText = Language.LabelQuantity;
                receiptItemIdColumn.IsVisible = false;
                receiptIdColumn.IsVisible = false;

                //template.Columns.Add(receiptItemIdColumn);
                template.Columns.Add(receiptIdColumn);
                template.Columns.Add(itemIdNumberColumn);
                template.Columns.Add(receiptItemNameColumn);
                template.Columns.Add(quantityColumn);
                template.Columns.Add(receiptItemAmountColumn);

                CashFlowGridView.Templates.Add(template);

                GridViewRelation relation = new(CashFlowGridView.MasterTemplate, template)
                {
                    RelationName = "ParentChild"
                };
                relation.ParentColumnNames.Add("Id");
                relation.ChildColumnNames.Add("ReceiptId");
                this.CashFlowGridView.Relations.Add(relation);

                LoadReceipts();
            }
        }
        // Chargement des reçus
        private void LoadReceipts()
        {
            CashFlowGridView.MasterTemplate.DataSource = Program.ReceiptList.OrderByDescending(x => x.Id);
            List<ReceiptItem> receiptItems = Program.ReceiptList.SelectMany(x => x.ReceiptItems).ToList();
            CashFlowGridView.Templates[0].DataSource = receiptItems;
            CashFlowGridView.Refresh();
            CashFlowGridView.BestFitColumns();
            CashFlowGridView.Templates[0].BestFitColumns();
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
                isValidatedColumn.IsVisible = false;
                dateColumn.Width = 80;
                amountColumn.Width = 80;
                idNumberColumn.Width = 100;
                cashFlowTypeColumn.Width = 150;
                idNumberColumn.Width = 100;
                noteColumn.Width = 220;
                idNumberColumn.HeaderText = Language.LabelReference;
                validationStateColumn.HeaderText = Language.LabelValidation;
                amountColumn.HeaderText = Language.labelAmount;
                cashFlowTypeColumn.HeaderText = Language.labelReason;
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
                CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
            }
        }
        private void InitCashFlowGridViewForSchoolSupplies()
        {
            using (CashFlowGridView.DeferRefresh())
            {
                GridViewTextBoxColumn idNumberColumn = new("IdNumber");
                GridViewDateTimeColumn dateColumn = new("Date");
                GridViewDecimalColumn amountColumn = new("Amount");
                GridViewDecimalColumn quantityColumn = new("Quantity");
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
                quantityColumn.Width = 100;
                idNumberColumn.Width = 100;
                paymentMeanColumn.Width = 300;
                transactionIdColumn.Width = 150;
                transactionDateColumn.Width = 100;
                validationStateColumn.Width = 100;
                cashFlowColumn.Width = 150;
                dateColumn.HeaderText = "Date";
                amountColumn.HeaderText = Language.labelAmount;
                quantityColumn.HeaderText = Language.LabelQuantity;
                idNumberColumn.HeaderText = Language.LabelReference;
                paymentMeanColumn.HeaderText = Language.labelPaymentMean;
                transactionIdColumn.HeaderText = Language.labelIdTransaction;
                transactionDateColumn.HeaderText = Language.labelDateTransaction;
                validationStateColumn.HeaderText = Language.LabelValidation;
                cashFlowColumn.HeaderText = Language.LabelSchoolSupplie;
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
                CashFlowGridView.Columns.Add(quantityColumn);
                CashFlowGridView.Columns.Add(paymentMeanColumn);
                CashFlowGridView.Columns.Add(cashFlowColumn);
                CashFlowGridView.Columns.Add(transactionDateColumn);
                CashFlowGridView.Columns.Add(transactionIdColumn);
                CashFlowGridView.Columns.Add(validationStateColumn);
                CashFlowGridView.Columns.Add(isValidatedColumn);
                CashFlowGridView.DataSource = Program.SchoolSupplieList.OrderByDescending(x => x.Id);
            }
        }
        #endregion

        #region Events
        private void CashFlowLeftListView_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            try
            {
                e.Offset = new System.Drawing.Size(e.Offset.Width + 20, e.Offset.Height + 20);
                e.ToolTipText = cashFlowLeftViewForToolTipText;
            }
            catch
            {
            }
        }

        private void CashFlowLeftListView_ItemMouseHover(object sender, ListViewItemEventArgs e)
        {
            cashFlowLeftViewForToolTipText = "" + e.Item.Tag;
        }

        private void CashFlowLeftListView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (CashFlowLeftListView.SelectedItem != null)
            {
                InitCashFlowGridViewForData();
                switch (CashFlowLeftListView.SelectedItem.Key)
                {
                    case 0:
                    case 1:
                    case 4:
                        CashFlowSearchTextBox.NullText = $"{Language.MessageSearchBy} {Language.LabelReference}, {Language.labelIdTransaction}, {Language.labelPaymentMean}, {Language.LabelValidation}, {Language.labelCashFlowType}";
                        if (int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 0)
                        {
                            CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowCreate == true);
                        }
                        else
                        {
                            if (int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 1)
                            {
                                CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowCreate == true);
                            }
                            else
                            {
                                CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 18 && x.AllowCreate == true);

                            }
                        }

                        break;
                    case 2:
                    case 3:
                        CashFlowSearchTextBox.NullText = $"{Language.MessageSearchBy} {Language.LabelReference}, {Language.labelNote}, {Language.LabelValidation}, {Language.labelCashFlowType}";
                        if (int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2)
                        {
                            CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 15 && x.AllowCreate == true);
                        }
                        else
                        {
                            CashFlowAddButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowCreate == true);
                        }
                        break;
                    case 5:
                        CashFlowSearchTextBox.NullText = $"{Language.MessageSearchBy} {Language.LabelReference}, {Language.LabelValidation}";
                        var allowAddSchoolFee = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowCreate == true);
                        var allowAddSubscription = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowCreate == true);
                        var allowAddSupplie = Program.UserConnected.Modules.Any(x => x.ModuleId == 18 && x.AllowCreate == true);
                        if (allowAddSchoolFee && allowAddSubscription && allowAddSupplie)
                        {
                            CashFlowAddButton.Enabled = true;
                        }
                        else
                        {
                            CashFlowAddButton.Enabled = false;
                        }
                        break;
                }
            }
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
                switch (CashFlowLeftListView.SelectedItem.Key)
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
                            if (!selectedCashBoxIn.IdNumber.ToUpper().Contains("-R") && selectedCashBoxIn.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn)
                                {
                                    Image = AppUtilities.GetImage("Undo"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true)
                                };
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
                            if (!selectedCashBoxOut.IdNumber.ToUpper().Contains("-R") && selectedCashBoxOut.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn)
                                {
                                    Image = AppUtilities.GetImage("Undo"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true)
                                };
                                e.ContextMenu.Items.Add(returnMenu);

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
                            RadMenuItem printMenu = new(Language.labelPrintReceipt)
                            {
                                Image = AppUtilities.GetImage("Printer"),
                                Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true)
                            };
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {

                            };
                        }
                        break;
                    case 4: //Fourniture scolaire
                        if (CashFlowGridView.CurrentRow.DataBoundItem is SchoolSupplie selectedSupplie)
                        {
                            //validate
                            if (!selectedSupplie.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidateSupplieMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }
                        }
                        break;
                    case 5:
                        if (CashFlowGridView.CurrentRow.DataBoundItem is ReceiptDTO selectedReceipt)
                        {

                            if (!selectedReceipt.IsValidated)
                            {
                                RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                                {
                                    Image = AppUtilities.GetImage("Check"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                                };
                                validateMenu.Click += ValidateReceiptMenu_Click;
                                e.ContextMenu.Items.Add(validateMenu);
                            }

                            //return Receipt
                            
                            if (!selectedReceipt.IdNumber.ToUpper().Contains("-R") && selectedReceipt.IsValidated)
                            {
                                RadMenuItem returnMenu = new(Language.labelReturn)
                                {
                                    Image = AppUtilities.GetImage("Undo"),
                                    Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true)
                                };
                                e.ContextMenu.Items.Add(returnMenu);
                                returnMenu.Click += ReturnReceiptMenu_Click;
                            }
                            RadMenuItem printMenu = new(Language.labelPrintReceipt)
                            {
                                Image = AppUtilities.GetImage("Printer"),
                                Enabled = Program.UserConnected.Modules.Any(x => (x.ModuleId == 3 && x.AllowPrint == true) || (x.ModuleId == 4 && x.AllowPrint == true) || (x.ModuleId == 18 && x.AllowPrint == true))
                            };
                            e.ContextMenu.Items.Add(printMenu);
                            // impression du reçu
                            printMenu.Click += (o, ev) =>
                            {
                                printService.PrintReceiptAsync(selectedReceipt,true);
                            };
                        }
                        break;
                }

            }
        }
        // validation d'un abonnement
        private async void ValidateSubscriptionMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is Subscription subscription)
                {
                    if (await CreateValidationSubscription(subscription))
                    {
                        subscription.IsValidated = true;
                        logger.LogInformation("Validation du versement {IdNumber}", subscription.IdNumber
                            );
                        CashFlowGridView.DataSource = Program.SubscriptionList.OrderByDescending(x => x.Id);
                    }
                    else
                    {
                        logger.LogWarning("La validation du versement {IdNumber} n'a pas été réalisée", subscription.IdNumber);
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        //Validate tuition payment
        private async void ValidatePaymentMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is TuitionPayment payment)
                {
                    await CreateValidationTuitionPayment(payment);
                    CashFlowGridView.DataSource = Program.TuitionPaymentList.OrderByDescending(x => x.Id);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private async void ValidateSupplieMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is SchoolSupplie supplie)
                {
                    if (await CreateValidationSchoolSupplie(supplie))
                    {
                        supplie.IsValidated = true;
                        logger.LogInformation("Validation fourniture scolaire {IdNumber}", supplie.IdNumber
                            );
                        CashFlowGridView.DataSource = Program.SchoolSupplieList.OrderByDescending(x => x.Id);
                    }
                    else
                    {
                        logger.LogWarning("La validation fourniture scolaire {IdNumber} n'a pas été réalisée", supplie.IdNumber);
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        // Permet de valider un reçu
        private async void ValidateReceiptMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is ReceiptDTO receipt)
                {

                    if (receipt != null && !receipt.IsValidated)
                    {
                        var isDone = await receiptService.ValidateReceiptAsync(receipt.Id);
                        if (isDone)
                        {
                            receipt.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation du  reçu {receipt.IdNumber} d'un montant de {receipt.Amount} pour {receipt.OpFor}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logValidate);
                            logger.LogInformation(logValidate.UserAction);
                            foreach (var item in receipt.ReceiptItems)
                            {
                                if (item.LinkedItem is TuitionPayment payment)
                                {
                                    if (!payment.IsValidated)
                                    {
                                        if (await CreateValidationTuitionPayment(payment))
                                        {
                                            payment.IsValidated = true;
                                            logger.LogInformation("Validation du versement {IdNumber} du reçu {IdNumber}",
                                                payment.IdNumber,
                                                receipt.IdNumber
                                                );
                                        }
                                        else
                                        {
                                            logger.LogError("Une erreur est survenue lors de la validation du versement {IdNumber} du reçu {IdNumber}",
                                                payment.IdNumber,
                                                receipt.IdNumber
                                                );
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LinkedItem is Subscription subscription)
                                    {
                                        if (!subscription.IsValidated)
                                        {
                                            if (await CreateValidationSubscription(subscription))
                                            {
                                                subscription.IsValidated = true;
                                                logger.LogInformation("Validation de l'abonnement {IdNumber} du reçu {IdNumber}",
                                                subscription.IdNumber,
                                                receipt.IdNumber
                                                );
                                            }
                                            else
                                            {
                                                logger.LogError("Une erreur est survenue lors de la validation de l'abonnement {IdNumber} du reçu {IdNumber}",
                                                    subscription.IdNumber,
                                                    receipt.IdNumber
                                                    );
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (item.LinkedItem is SchoolSupplie supplie)
                                        {
                                            if (!supplie.IsValidated)
                                            {
                                                if (await CreateValidationSchoolSupplie(supplie))
                                                {
                                                    supplie.IsValidated = true;
                                                    logger.LogInformation("Validation fourniture scolaire {IdNumber} du reçu {IdNumber}",
                                                    supplie.IdNumber,
                                                    receipt.IdNumber
                                                    );
                                                }
                                                else
                                                {
                                                    logger.LogError("Une erreur est survenue lors de la validation fourniture scolaire {IdNumber} du reçu {IdNumber}",
                                                        supplie.IdNumber,
                                                        receipt.IdNumber
                                                        );
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            LoadReceipts();
                        }
                        else
                        {
                            logger.LogWarning($"La validation du  reçu {receipt.IdNumber} d'un montant de {receipt.Amount} pour {receipt.OpFor}  n'a pas été effectuée ");
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

        // validation d'un approvisionnement
        private async void ValidateCashBoxInMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxIn selectedCashBoxIn)
                {
                    if (selectedCashBoxIn != null && selectedCashBoxIn.IsValidated == false)
                    {
                        var isValidated = await cashFlowService.ValidateCashBoxIn(selectedCashBoxIn.Id);
                        if (isValidated)
                        {
                            selectedCashBoxIn.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de l'approvisionnement {selectedCashBoxIn.IdNumber} d'un montant de {selectedCashBoxIn.Amount} pour {selectedCashBoxIn.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            logger.LogInformation(logValidate.UserAction);
                            await logService.CreateLog(logValidate);
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
                            var isDone = await cashFlowService.CreateCashFlow(cashFlow);
                            if (isDone)
                            {
                                CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logger.LogInformation(logCash.UserAction);
                                await logService.CreateLog(logCash);
                            }
                            else
                            {
                                logger.LogError($"L'ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé.");
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            logger.LogError($"La validation de l'approvisionnement {selectedCashBoxIn.IdNumber} d'un montant de {selectedCashBoxIn.Amount} pour {selectedCashBoxIn.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisée.");
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
        // validation d'une dépense
        private async void ValidateCashBoxOutMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is CashBoxOut selectedCashBoxOut)
                {
                    if (selectedCashBoxOut != null && selectedCashBoxOut.IsValidated == false)
                    {
                        var isValidated = await cashFlowService.ValidateCashBoxOut(selectedCashBoxOut.Id);
                        if (isValidated)
                        {
                            selectedCashBoxOut.IsValidated = true;
                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de la dépense {selectedCashBoxOut.IdNumber} d'un montant de {selectedCashBoxOut.Amount} pour {selectedCashBoxOut.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logValidate);
                            logger.LogInformation(logValidate.UserAction);
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
                                CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                await logService.CreateLog(logCash);
                                logger.LogInformation(logCash.UserAction);
                            }
                            else
                            {
                                logger.LogError($"L'ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisé");
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            logger.LogError($"La validation de la dépense {selectedCashBoxOut.IdNumber} d'un montant de {selectedCashBoxOut.Amount} pour {selectedCashBoxOut.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress} n'a pas été réalisée.");
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
        //Permet de retourner une facture
        private async void ReturnReceiptMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (CashFlowGridView.CurrentRow.DataBoundItem is ReceiptDTO receipt)
                {
                    DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var returnExist = await receiptService.GetReceiptByIdNumberAsync(receipt.IdNumber + "-R") != null;
                        if (!returnExist)
                        {
                            if (receipt != null)
                            {
                                var newReceipt = new Receipt()
                                {
                                    Amount = receipt.Amount,
                                    Balance = -receipt.Balance,
                                    Date = DateTime.Now,
                                    OpDoneBy = receipt.OpDoneBy,
                                    OpFor = receipt.OpFor,
                                    SchoolYear = receipt.SchoolYear,
                                    SchoolYearId = receipt.SchoolYearId,
                                    IdNumber = receipt.IdNumber,
                                    IsValidated = false
                                };
                                var returnReceipt = await receiptService.ReturnReceiptAsync(newReceipt);
                                var returnReceiptDTO = returnReceipt.AsReceiptDTO();
                                Program.ReceiptList.Add(returnReceiptDTO);
                                if (returnReceipt != null)
                                {
                                    foreach (var item in receipt.ReceiptItems)
                                    {
                                        if (item.LinkedItem is TuitionPayment payment)
                                        {
                                            if (payment.IsValidated)
                                            {
                                                if (await CreateReturnPayment(payment, returnReceipt))
                                                {
                                                    logger.LogInformation($"Retour frais scolaire {payment.IdNumber} du reçu {receipt.IdNumber}");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (item.LinkedItem is Subscription subscription)
                                            {
                                                if (await CreateReturnSubscription(subscription, returnReceipt))
                                                {
                                                    logger.LogInformation($"Retour abonnement {subscription.IdNumber} du reçu {receipt.IdNumber}");
                                                }
                                            }
                                            else
                                            {
                                                if (item.LinkedItem is SchoolSupplie supplie)
                                                {
                                                    if (await CreateReturnSchoolSupplie(supplie, returnReceipt))
                                                    {
                                                        logger.LogInformation($"Retour Fourniture scolaire {supplie.IdNumber} du reçu {receipt.IdNumber}");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    AppUtilities.GenerateReceiptItems(returnReceiptDTO, Program.TuitionPaymentList, Program.SubscriptionList, Program.SchoolSupplieList);
                                }
                                LoadReceipts();
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(Language.messageReturnAllreadyDone);
                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        private void CashFlowAddButton_Click(object sender, EventArgs e)
        {
            switch (CashFlowLeftListView.SelectedItem.Key)
            {
                case 0:
                    var form_00 = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                    form_00.Text = Language.labelAdd + ":.." + Language.labelPayment;
                    form_00.Icon = this.Icon;
                    form_00.Init(Program.StudentEnrollingList.Select(x => x.AsStudentEnrolling()).ToList(), TypeFee.TuitionFee);
                    if (form_00.ShowDialog(this) == DialogResult.OK)
                    {
                        CashFlowGridView.DataSource = Program.TuitionPaymentList.OrderByDescending(x => x.Id);
                    }
                    break;
                case 1:
                    var form_01 = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                    form_01.Text = Language.labelAdd + ":.." + Language.labelSubscription;
                    form_01.Icon = this.Icon;
                    form_01.Init(Program.StudentEnrollingList.Select(x => x.AsStudentEnrolling()).ToList(), TypeFee.Subscription);
                    if (form_01.ShowDialog(this) == DialogResult.OK)
                    {
                        CashFlowGridView.DataSource = Program.SubscriptionList.OrderByDescending(x => x.Id);
                    }
                    break;
                case 2:
                    var form_02 = Program.ServiceProvider.GetService<AddOtherCashFlowForm>();
                    form_02.Text = Language.labelAdd + ":.." + Language.LabelSupply;
                    form_02.Icon = this.Icon;
                    form_02.Init(2);
                    if (form_02.ShowDialog(this) == DialogResult.OK)
                    {
                        CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
                    }
                    break;
                case 3:
                    var form_03 = Program.ServiceProvider.GetService<AddOtherCashFlowForm>();
                    form_03.Text = Language.labelAdd + ":.." + Language.LabelExpense;
                    form_03.Icon = this.Icon;
                    form_03.Init(3);
                    if (form_03.ShowDialog(this) == DialogResult.OK)
                    {
                        CashFlowGridView.DataSource = int.Parse(CashFlowLeftListView.SelectedItem.Key.ToString()) == 2 ? Program.CashBoxInList.OrderByDescending(x => x.Id) : Program.CashBoxOutList.OrderByDescending(x => x.Id);
                    }
                    break;
                case 4:
                    var form_04 = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                    form_04.Text = Language.labelAdd + ":.." + Language.LabelSchoolSupplie;
                    form_04.Icon = this.Icon;
                    form_04.Init(Program.StudentEnrollingList.Select(x => x.AsStudentEnrolling()).ToList(), TypeFee.SchoolSupply);
                    if (form_04.ShowDialog(this) == DialogResult.OK)
                    {
                        CashFlowGridView.DataSource = Program.SchoolSupplieList.OrderByDescending(x => x.Id);
                    }
                    break;
                case 5:
                    var form_05 = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                    form_05.Text = Language.labelAdd + ":.." + Language.LabelSupplies;
                    form_05.Icon = this.Icon;
                    form_05.Init(Program.StudentEnrollingList.Select(x => x.AsStudentEnrolling()).ToList(), TypeFee.Unknown);
                    if (form_05.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadReceipts();
                    }
                    break;
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
                switch (CashFlowLeftListView.SelectedItem.Key)
                {
                    case 0:
                    case 1:
                    case 4:
                        e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["TransactionId"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["ValidattionState"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["CashFlowType"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                      e.Row.Cells["PaymentMean"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower());
                        break;
                    case 2:
                    case 3:
                        e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["Note"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                    e.Row.Cells["ValidattionState"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["CashFlowType"].Value.ToString().ToLower().Contains(CashFlowSearchTextBox.Text.ToLower());
                        break;
                }

            }
            await System.Threading.Tasks.Task.Delay(0);
        }
        #endregion

    }
}
