

using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Linq;
using Primary.SchoolApp.Services;

namespace Primary.SchoolApp.UI
{
    internal class TuitionPaymentsForm:SchoolManagement.UI.StudentItemsForm
    {
        private readonly IPrintService  printService;
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly IUserService userService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public TuitionPaymentsForm(IPrintService printService, ICashFlowService cashFlowService, ClientApp clientApp, ILogService logService, IUserService userService)
        {
            this.printService = printService;
            this.cashFlowService = cashFlowService;
            this.clientApp = clientApp;
            this.logService = logService;
            this.SaveButton.ButtonElement.ToolTipText = Language.messageClickToAddPayment;
            CreateGridViewColumn();
            InitEvents();
            this.userService = userService;
        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'élève etc.
        internal void Init(StudentEnrolling enrolling) { 
            enrolling.SchoolYear=Program.SchoolYearList.FirstOrDefault(x => x.Id==enrolling.SchoolYearId);
            selectedEnrolling = enrolling;
            if (enrolling.Student.FullName.Length >= 17)
            {
                NameLabel.Text = enrolling.Student.FullName.Substring(0, 17) + "...";
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
            string schoolInfo = Language.labelRegisteredOn + " " + enrolling.Date.ToString("dd/MM/yyyy") + " | " + enrolling.SchoolClass.Name + " | " + enrolling.SchoolClass.Group.Name + " | " + enrolling.SchoolYear.Name;
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
                    var url = clientApp.StudentPitureFolder + "/" + enrolling.Student.IdNumber;
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
            Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
            this.SaveButton.Enabled= Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowCreate == true);
            this.PrintButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowPrint == true);
            this.ExportButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowPrint == true);
            //load payments
            LoadPayments(enrolling.Id);
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
            AppUtilities.PrintGridView(DataGridView, Language.titlePaymentList);
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

                e.Visible &= e.Row.Cells["IdNumber"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower())||
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
                ShowAddTuitionPaymentForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // chargement de la liste des paiements dans le datagridview
        private async void LoadPayments(int enrollingId)
        {
            selectedEnrolling.PaymentList = cashFlowService.GetTuitionPaymentByEnrollingList(enrollingId).Result;
            DataGridView.DataSource = selectedEnrolling.PaymentList;
            DataGridView.BestFitColumns();
           await Task.Delay(0);
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
            GridViewDateTimeColumn dateColumn = new("Date");
            GridViewTextBoxColumn idNumberColumn = new("IdNumber");
            GridViewDecimalColumn amountColumn = new("Amount");           
            GridViewTextBoxColumn cashFlowTypeColumn = new("CashFlowType.Name");
            GridViewTextBoxColumn paymentMeanColumn = new("PaymentMean.FullName");
            GridViewDateTimeColumn transactionDateColumn = new("TransactionDate");
            GridViewTextBoxColumn transactionIdColumn = new("TransactionId");
            GridViewTextBoxColumn doneByColumn = new("DoneBy");
            GridViewTextBoxColumn isValidatedColumn = new("IsValidated");

            isValidatedColumn.IsVisible = false;

            dateColumn.HeaderText = "Date";
            idNumberColumn.HeaderText = Language.LabelReference;
            amountColumn.HeaderText = Language.labelAmount;
            cashFlowTypeColumn.HeaderText = Language.labelReason;
            paymentMeanColumn.HeaderText = Language.labelPaymentMean;
            transactionDateColumn.HeaderText = Language.labelDateTransaction;
            transactionIdColumn.HeaderText = Language.labelIdTransaction;
            doneByColumn.HeaderText = Language.labelPaymentDoneBy;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            transactionDateColumn.CustomFormat = "dd/MM/yyyy";
            transactionDateColumn.FormatString = "{0:dd/MM/yyyy}";

            ConditionalFormattingObject c1 = new("Orange, applied to entire row", ConditionTypes.Equal, "False", "", true);
            c1.RowBackColor = Color.FromArgb(255, 209, 140);
            c1.CellBackColor = Color.FromArgb(255, 209, 140);
            c1.RowForeColor = Color.Black;
            c1.CellForeColor = Color.Black;
            isValidatedColumn.ConditionalFormattingObjectList.Add(c1);


            this.DataGridView.Columns.Add(idNumberColumn);
            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(amountColumn);          
            this.DataGridView.Columns.Add(cashFlowTypeColumn);
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
                if (DataGridView.CurrentRow.DataBoundItem is TuitionPayment selectedPayment)
                {
                    Program.UserConnected.Modules = userService.GetUserModuleList(Program.UserConnected.Id).Result;
                    if (!selectedPayment.IsValidated)
                    {
                        RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                        {
                            Image = AppUtilities.GetImage("Check"),
                            Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                        };
                        validateMenu.Click += ValidateMenu_Click;
                        e.ContextMenu.Items.Add(validateMenu);
                    }

                    if (!selectedPayment.IdNumber.ToLower().Contains("return") && selectedPayment.IsValidated)
                    {
                        RadMenuItem returnMenu = new(Language.labelReturn);
                        returnMenu.Image = AppUtilities.GetImage("Undo");
                        returnMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 13 && x.AllowCreate == true);
                        e.ContextMenu.Items.Add(returnMenu);
                        returnMenu.Click += ReturnMenu_Click;
                        
                    }
                    RadMenuItem printMenu = new(Language.labelPrintReceipt);
                    printMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 3 && x.AllowPrint == true);
                    e.ContextMenu.Items.Add(printMenu);
                    printMenu.Image = AppUtilities.GetImage("Printer");
                    printMenu.Click += PrintMenu_Click;

                }
            }
        }

        private void ValidateMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is TuitionPayment selectedPayment)
                {
                    if (selectedPayment != null && selectedPayment.IsValidated==false)
                    {                        
                        var isValidated=cashFlowService.ValidateTuitionPayment(selectedPayment.Id).Result;
                        if (isValidated) {

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
                                SchoolYear = selectedEnrolling.SchoolYear,
                                SchoolYearId = selectedEnrolling.SchoolYearId,
                                Note = $"{Language.labelPayment} {selectedPayment.IdNumber}:{selectedPayment.CashFlowType.Name}  {selectedEnrolling.Student.FullName}",
                            };
                            var isDone = cashFlowService.CreateCashFlow(cashFlow).Result;
                            if (isDone)
                            {
                                LoadPayments(selectedEnrolling.Id);
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

        private void PrintMenu_Click(object sender, EventArgs e)
        {
           if(DataGridView.CurrentRow.DataBoundItem is TuitionPayment payment){
                payment.Enrolling=selectedEnrolling;
                printService.PrintPaymentReceiptAsync(payment,true);
            }
        }

        // retour versement
        private void ReturnMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is TuitionPayment selectedPayment)
                {
                    if (selectedPayment != null)
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var payment = new TuitionPayment()
                            {
                                Date = DateTime.Now,
                                Amount = selectedPayment.Amount,
                                TransactionDate = selectedPayment.TransactionDate,
                                TransactionId = selectedPayment.TransactionId,
                                Enrolling = selectedPayment.Enrolling,
                                EnrollingId = selectedPayment.EnrollingId,
                                CashFlowType=selectedPayment.CashFlowType,
                                CashFlowTypeId = selectedPayment.CashFlowTypeId,
                                PaymentMean =selectedPayment.PaymentMean,
                                PaymentMeanId=selectedPayment.PaymentMeanId,
                                Balance=selectedPayment.Balance,
                                IdNumber = selectedPayment.IdNumber,
                                Note = selectedPayment.Note,
                                DoneBy = selectedPayment.DoneBy,
                                IsDuringEnrolling = selectedPayment.IsDuringEnrolling,
                              
                            };
                            if (!selectedEnrolling.PaymentList.ToList().Select(x => x.IdNumber).Contains(payment.IdNumber+"-return"))
                            {
                                var isDone = cashFlowService.ReturnTuitionPayment(payment).Result;
                                if (isDone)
                                {
                                    LoadPayments(selectedEnrolling.Id);
                                    Log log = new()
                                    {
                                        UserAction = $"Retour du versement {payment.Amount}  de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //affichage de UI pour l'ajout d'un versement
        private void ShowAddTuitionPaymentForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddTuitionPaymentForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelPayment;
                form.Icon = this.Icon;
                form.Init(selectedEnrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPayments(selectedEnrolling.Id);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
    }
}
