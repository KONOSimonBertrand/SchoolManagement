

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Drawing;
using SchoolManagement.Application.Subscriptions;

namespace Primary.SchoolApp.UI
{
    internal class SubscriptionsForm : SchoolManagement.UI.StudentItemsForm
    {
        private readonly IPrintService printService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public SubscriptionsForm(IPrintService printService, ICashFlowService cashFlowService, ILogService logService, ClientApp clientApp, ISubscriptionService subscriptionService)
        {
            this.subscriptionService= subscriptionService;
            this.printService = printService;
            this.cashFlowService = cashFlowService;
            this.logService = logService;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'élève etc.
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
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

            PersonalInformationLabel.Text = string.Format("{0} ans | {1} | {2}", age.ToString(), enrolling.Student.Sex == "M" ? "Masculin" : "Feminin", enrolling.Student.BirthDate.ToString("dd/MM/yyyy"));
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

            //load subsciptions
            LoadSubscriptions(enrolling.Id);
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
                e.Visible &= e.Row.Cells["CashFlowType.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
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
        private async void LoadSubscriptions(int enrollingId)
        {
            selectedEnrolling.SubscriptionList = subscriptionService.GetSubscriptionListByEnrollingAsync(enrollingId).Result;
            DataGridView.DataSource = selectedEnrolling.SubscriptionList;
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
            GridViewTextBoxColumn subscriptionColumn = new("CashFlowType.Name");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDecimalColumn discountColumn = new("Discount");
            GridViewDateTimeColumn endDateColumn = new("EndDate");
            GridViewTextBoxColumn doneByColumn = new("DoneBy");
            GridViewTextBoxColumn stateColumn = new("State");
            GridViewDateTimeColumn transactionDateColumn = new("TransactionDate");
            GridViewTextBoxColumn transactionIdColumn = new("TransactionId");
            GridViewTextBoxColumn paymentMeanColumn = new("PaymentMean.FullName");
                      
            dateColumn.HeaderText = Language.labelStart;
            stateColumn.HeaderText = Language.labelStatut;
            amountColumn.HeaderText = Language.labelAmount;
            subscriptionColumn.HeaderText = Language.labelSubscription;
            paymentMeanColumn.HeaderText = Language.labelPaymentMean;
            endDateColumn.HeaderText = Language.labelEnd;
            transactionDateColumn.HeaderText = Language.labelDateTransaction;
            transactionIdColumn.HeaderText = Language.labelIdTransaction;
            doneByColumn.HeaderText = Language.labelPaymentDoneBy;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            transactionDateColumn.CustomFormat = "dd/MM/yyyy";
            transactionDateColumn.FormatString = "{0:dd/MM/yyyy}";
            endDateColumn.CustomFormat = "dd/MM/yyyy";
            endDateColumn.FormatString = "{0:dd/MM/yyyy}";

            
            this.DataGridView.Columns.Add(subscriptionColumn);
            this.DataGridView.Columns.Add(amountColumn);
            this.DataGridView.Columns.Add(discountColumn);
            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(endDateColumn);
            this.DataGridView.Columns.Add(stateColumn);
            this.DataGridView.Columns.Add(paymentMeanColumn);
            transactionDateColumn.IsVisible = false;
            transactionIdColumn.IsVisible = false;
            doneByColumn.IsVisible = false;
            
            this.DataGridView.Columns.Add(transactionDateColumn);
            this.DataGridView.Columns.Add(transactionIdColumn);
            this.DataGridView.Columns.Add(doneByColumn);
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
                if (DataGridView.CurrentRow.DataBoundItem is Subscription subscription)
                {
                    if (!subscription.IsCancel)
                    {
                        RadMenuItem editMenu = new(Language.labelEdit);
                        RadMenuItem cancelMenu = new(Language.labelCancel);
                        RadMenuItem printMenu = new(Language.labelPrintRegistrationReceipt);
                        editMenu.Image = AppUtilities.GetImage("Edit");
                        cancelMenu.Image = AppUtilities.GetImage("Cancel");
                        printMenu.Image = AppUtilities.GetImage("Printer");
                        e.ContextMenu.Items.Add(editMenu);
                        e.ContextMenu.Items.Add(cancelMenu);
                        e.ContextMenu.Items.Add(printMenu);
                        cancelMenu.Click += CancelMenu_Click;
                        printMenu.Click += PrintMenu_Click;
                        editMenu.Click += EditMenu_Click;
                    }
                }
            }
        }

        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (this.DataGridView.CurrentRow != null)
                {
                    if (this.DataGridView.CurrentRow.DataBoundItem is Subscription subscription)
                    {
                        if (!subscription.IsCancel)
                        {
                            subscription.Enrolling = selectedEnrolling;
                            var form = Program.ServiceProvider.GetService<EditSubscriptionForm>();
                            form.Text = Language.labelUpdate + ":.." + Language.labelSubscription;
                            form.Icon = this.Icon;
                            form.Init(subscription);
                            if (form.ShowDialog(this) == DialogResult.OK)
                            {

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

        private void PrintMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is Subscription subscription)
            {
                subscription.Enrolling = selectedEnrolling;
                printService.PrintPaymentReceipt(subscription, true);
            }
        }

        // annulation d'abonnement
        private void CancelMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is Subscription selectedSubscription)
                {
                    if (selectedSubscription != null)
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmCancel, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                           
                            if (selectedSubscription.IsCancel==false)
                            {
                                var isDone = subscriptionService.CancelSubscriptionAsync(selectedSubscription.Id).Result;
                                if (isDone)
                                {
                                    LoadSubscriptions(selectedEnrolling.Id);
                                    Log log = new()
                                    {
                                        UserAction = $"Annulation de l'abonnement {selectedSubscription.CashFlowType.Name}  de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    logService.CreateLog(log);
                                    //enregistrement du cashflow
                                    var cashflow = new CashFlow()
                                    {
                                        Amount = (-1)*selectedSubscription.Amount,
                                        CashFlowType = selectedSubscription.CashFlowType,
                                        CashFlowTypeId = selectedSubscription.CashFlowTypeId,
                                        Date = DateTime.Now,
                                        DoneBy = selectedSubscription.DoneBy,
                                        SchoolYear = selectedEnrolling.SchoolYear,
                                        SchoolYearId = selectedEnrolling.SchoolYearId,
                                        Note = "Annulation de l'abonnement " + selectedSubscription.CashFlowType.Name,
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
                var form = Program.ServiceProvider.GetService<AddSubscriptionForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelSubscription;
                form.Icon = this.Icon;
                form.Init(selectedEnrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSubscriptions(selectedEnrolling.Id);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
    }
}
