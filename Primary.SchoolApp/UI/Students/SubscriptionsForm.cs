using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class SubscriptionsForm : SchoolManagement.UI.StudentItemsForm
    {
        private readonly IPrintService printService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISubscriptionService subscriptionService;
        private readonly IUserService userService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private SchoolYear selectedSchoolYear;
        private Student selectedStudent;
        private StudentEnrolling selectedEnrolling;
        private readonly ILogger<SubscriptionsForm> logger;
        public SubscriptionsForm(IPrintService printService, ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp, ISubscriptionService subscriptionService, IUserService userService, ILogger<SubscriptionsForm> logger)
        {
            this.subscriptionService = subscriptionService;
            this.printService = printService;
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.logger = logger;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
            this.userService = userService;
        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'élève etc.
        internal void InitStartup(StudentEnrolling enrolling)
        {
            selectedSchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            selectedStudent=enrolling.Student;
            selectedEnrolling = enrolling;
            if (enrolling.Student.FullName.Length >= 17)
            {
                NameLabel.Text = string.Concat(enrolling.Student.FullName.AsSpan(0, 17), "...");
            }
            else
            {
                this.NameLabel.Text = enrolling.Student.FullName;
            }
            NameLabel.LabelElement.ToolTipText = enrolling.Student.FullName;
            DateTime today = DateTime.Now;
            int age = today.Year - enrolling.Student.BirthDate.Year;
            if (enrolling.Student.BirthDate > today.AddYears(-age))
            {
                age--;
            }

            PersonalInformationLabel.Text = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), enrolling.Student.Sex == "M" ? Language.LabelMale : Language.LabelFemale, enrolling.Student.BirthDate.ToString("dd/MM/yyyy"));
            string schoolInfo = Language.labelRegisteredOn + " " + enrolling.Date.ToString("dd/MM/yyyy") + " | " + enrolling.SchoolClass.Name + " | " + enrolling.SchoolClass.Group.Name + " | " + selectedSchoolYear.Name;
            SchoolInformationLabel.LabelElement.ToolTipText = schoolInfo;
            if (schoolInfo.Length <= 121)
            {
                SchoolInformationLabel.Text = schoolInfo;
            }
            else
            {
                SchoolInformationLabel.Text = schoolInfo.Substring(0, 121) + "..."; ; ;
            }

            AddressLabel.Text = enrolling.Student.Address;
            EmailLabel.Text = enrolling.Student.Email;
            PhoneLabel.Text = enrolling.Student.Phone;
            //affichage de la photo
            if (File.Exists(enrolling.PictureUrl))
            {

                PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Student.PictureUrl))
                {
                    PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(114, 114));
                }
                else
                {
                    var url = Program.CurrentSchool.StudentPictureDirectory + "/" + enrolling.Student.IdNumber;
                    if (File.Exists(url))
                    {

                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.no_image);
                        PictureLabel.Image = Image.FromStream(ms);
                    }
                }
            }
            //check authorizations
            this.SaveButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowCreate == true);
            this.PrintButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
            this.ExportButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
            //load subsciptions
            LoadSubscriptions();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            CloseButton.Click += CloseButton_Click;
            PrintButton.Click += PrintButton_Click;
            ExportButton.Click += ExportButton_Click;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titlePaymentList);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleSubscriptionList);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //filtre le datagridview en fonction des données de searchTextBox
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                    e.Row.Cells["CashFlowType.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                ShowAddSubscriptionForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // chargement de la liste des abonnements dans le datagridview
        private async void LoadSubscriptions()
        {
            DataGridView.DataSource = await subscriptionService.GetSubscriptionListAsync(selectedStudent.Id,selectedSchoolYear.Id);
            DataGridView.BestFitColumns();
        }
        //Création des colonnes du datagridview
        private void CreateGridViewColumn()
        {
            DataGridView.ReadOnly = true;
            DataGridView.AllowColumnChooser = false;
            DataGridView.ShowFilteringRow = false;
            DataGridView.AllowAddNewRow = false;
            DataGridView.AllowDragToGroup = false;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.EnableFiltering = true;
            GridViewDateTimeColumn startDateColumn = new("StartDate");
            GridViewTextBoxColumn subscriptionColumn = new("CashFlowType.Name");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDateTimeColumn endDateColumn = new("EndDate");
            GridViewTextBoxColumn doneByColumn = new("DoneBy");
            GridViewTextBoxColumn stateColumn = new("State");
            GridViewDateTimeColumn transactionDateColumn = new("TransactionDate");
            GridViewTextBoxColumn transactionIdColumn = new("TransactionId");
            GridViewTextBoxColumn paymentMeanColumn = new("PaymentMean.FullName");
            GridViewTextBoxColumn idNumberColumn = new("IdNumber");
            GridViewTextBoxColumn isValidatedColumn = new("IsValidated");

            transactionDateColumn.IsVisible = false;
            transactionIdColumn.IsVisible = false;
            doneByColumn.IsVisible = false;
            isValidatedColumn.IsVisible = false;

            idNumberColumn.HeaderText = Language.LabelReference;
            startDateColumn.HeaderText = Language.labelStart;
            stateColumn.HeaderText = Language.labelStatut;
            amountColumn.HeaderText = Language.labelAmount;
            subscriptionColumn.HeaderText = Language.labelSubscription;
            paymentMeanColumn.HeaderText = Language.labelPaymentMean;
            endDateColumn.HeaderText = Language.labelEnd;
            transactionDateColumn.HeaderText = Language.labelDateTransaction;
            transactionIdColumn.HeaderText = Language.labelIdTransaction;
            doneByColumn.HeaderText = Language.labelPaymentDoneBy;
            startDateColumn.Format = DateTimePickerFormat.Custom;
            startDateColumn.CustomFormat = "dd/MM/yyyy";
            startDateColumn.FormatString = "{0:dd/MM/yyyy}";
            transactionDateColumn.CustomFormat = "dd/MM/yyyy";
            transactionDateColumn.FormatString = "{0:dd/MM/yyyy}";
            endDateColumn.CustomFormat = "dd/MM/yyyy";
            endDateColumn.FormatString = "{0:dd/MM/yyyy}";

            ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true);
            c1.RowBackColor = Color.FromArgb(255, 209, 140);
            c1.CellBackColor = Color.FromArgb(255, 209, 140);
            c1.RowForeColor = Color.Black;
            c1.CellForeColor = Color.Black;
            isValidatedColumn.ConditionalFormattingObjectList.Add(c1);

            this.DataGridView.Columns.Add(idNumberColumn);
            this.DataGridView.Columns.Add(subscriptionColumn);
            this.DataGridView.Columns.Add(amountColumn);
            this.DataGridView.Columns.Add(startDateColumn);
            this.DataGridView.Columns.Add(endDateColumn);
            this.DataGridView.Columns.Add(stateColumn);
            this.DataGridView.Columns.Add(paymentMeanColumn);
            this.DataGridView.Columns.Add(transactionDateColumn);
            this.DataGridView.Columns.Add(transactionIdColumn);
            this.DataGridView.Columns.Add(doneByColumn);
            this.DataGridView.Columns.Add(isValidatedColumn);
            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Amount", " {0}", GridAggregateFunction.Sum)
            };
            DataGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        //fait appel au menu contextuel du grid view
        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if (DataGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                {
                    //check authorizations
                    Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                    //validate
                    if (!selectedSubscription.IsValidated)
                    {
                        RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                        {
                            Image = AppUtilities.GetImage("Check"),
                            Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                        };
                        validateMenu.Click += ValidateMenu_Click;
                        e.ContextMenu.Items.Add(validateMenu);
                    }

                    
                    if (!selectedSubscription.IdNumber.ToLower().Contains("return") && selectedSubscription.IsValidated)
                    {

                        RadMenuItem returnMenu = new(Language.labelReturn);
                        returnMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                        returnMenu.Image = AppUtilities.GetImage("Undo");
                        e.ContextMenu.Items.Add(returnMenu);
                        returnMenu.Click += ReturnMenu_Click;

                    }
                    RadMenuItem printMenu = new(Language.labelPrintReceipt);
                    printMenu.Image = AppUtilities.GetImage("Printer");
                    printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 4 && x.AllowPrint == true);
                    e.ContextMenu.Items.Add(printMenu);
                    printMenu.Click += PrintMenu_Click;

                }
            }
        }
        // lance l'impression
        private void PrintMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is Subscription subscription)
            {
                subscription.Student=selectedStudent;
                subscription.SchoolYear= selectedSchoolYear;
                printService.PrintPaymentReceiptAsync(subscription, true);
            }
        }

        // validate subscription
        private async void ValidateMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                {
                    if (selectedSubscription != null && selectedSubscription.IsValidated == false)
                    {
                        var isValidated = await subscriptionService.ValidateSubscriptionAsync(selectedSubscription.Id);
                        if (isValidated)
                        {

                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation de l'abonnement {selectedSubscription.IdNumber} d'un montant de {selectedSubscription.Amount} pour {selectedSubscription.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logValidate);
                            logger.LogInformation(logValidate.UserAction);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedSubscription.Amount,
                                CashFlowType = selectedSubscription.CashFlowType,
                                CashFlowTypeId = selectedSubscription.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedSubscription.DoneBy,
                                SchoolYear = selectedSchoolYear,
                                SchoolYearId = selectedSchoolYear.Id,
                                Note = $"{Language.labelSubscription} {selectedSubscription.IdNumber}: {selectedSubscription.CashFlowType.Name}  {selectedStudent.FullName}",
                            };
                            var isDone = await cashFlowService.CreateCashFlow(cashFlow);
                            if (isDone)
                            {
                                LoadSubscriptions();
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                await logService.CreateLog(logCash);
                                logger.LogInformation($"Validation de l'abonnement {selectedSubscription.IdNumber} d'un montant de {selectedSubscription.Amount} pour {selectedSubscription.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
                            }
                            else
                            {
                                logger.LogError($"Erreur lors de l'ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            logger.LogError($"Erreur lors de la validation de l'abonnement {selectedSubscription.IdNumber} d'un montant de {selectedSubscription.Amount} pour {selectedSubscription.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
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

        // retour d'abonnement
        private async void ReturnMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (DataGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                    {
                        if (selectedSubscription != null)
                        {
                            if (! RecordExist(selectedSubscription.IdNumber + "-R"))
                            {
                                var subscription = new Subscription()
                                {
                                    Amount = selectedSubscription.Amount,
                                    CashFlowType = selectedSubscription.CashFlowType,
                                    CashFlowTypeId = selectedSubscription.CashFlowTypeId,
                                    DoneBy = selectedSubscription.DoneBy,
                                    EndDate = selectedSubscription.EndDate,
                                    Student = selectedStudent,
                                    StudentId = selectedSubscription.StudentId,
                                    SchoolYear = selectedSchoolYear,
                                    SchoolYearId = selectedSubscription.SchoolYearId,
                                    IsValidated = selectedSubscription.IsValidated,
                                    PaymentMean = selectedSubscription.PaymentMean,
                                    PaymentMeanId = selectedSubscription.PaymentMeanId,
                                    StartDate = selectedSubscription.StartDate,
                                    TransactionDate = selectedSubscription.TransactionDate,
                                    TransactionId = selectedSubscription.TransactionId,
                                    IdNumber = selectedSubscription.IdNumber,
                                    Receipt = selectedSubscription.Receipt,
                                    ReceiptId = selectedSubscription.ReceiptId
                                };
                                var isDone = await subscriptionService.ReturnSubscriptionAsync(subscription);
                                if (isDone)
                                {
                                    LoadSubscriptions();
                                    Log log = new()
                                    {
                                        UserAction = $"Retour de l'abonnement {selectedSubscription.CashFlowType.Name}  de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    logger.LogInformation(log.UserAction);
                                    await logService.CreateLog(log);

                                }
                                else
                                {
                                    logger.LogError($"Erreur lors du retour de l'abonnement {selectedSubscription.CashFlowType.Name}  de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}");
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
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //affichage de UI pour l'ajout d'un abonnement
        private void ShowAddSubscriptionForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelSubscription;
                form.Icon = this.Icon;
                form.Init(selectedEnrolling, TypeFee.Subscription);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSubscriptions();
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        private bool RecordExist(string idNumber)
        {
            return subscriptionService.GetSubscriptionAsync(idNumber).Result != null;
        }

    }
}
