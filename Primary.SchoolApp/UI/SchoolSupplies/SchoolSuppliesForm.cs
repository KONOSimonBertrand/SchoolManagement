

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
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class SchoolSuppliesForm : SchoolManagement.UI.StudentItemsForm
    {
        private readonly ISchoolSupplieService schoolSupplieService;
        private readonly ILogService logService;
        private readonly ILogger<SchoolSuppliesForm> logger;
        private readonly IUserService userService;
        private readonly ICashFlowService cashFlowService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        private readonly IPrintService printService;
        public SchoolSuppliesForm(ISchoolSupplieService schoolSupplieService, ILogService logService, ILogger<SchoolSuppliesForm> logger, IUserService userService, ICashFlowService cashFlowService, ClientApp clientApp,IPrintService printService)
        {
            this.schoolSupplieService = schoolSupplieService;
            this.logService = logService;
            this.logger = logger;
            this.userService = userService;
            this.cashFlowService=cashFlowService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.SaveButton.ButtonElement.ToolTipText = Language.messageClickToAddDiscount;
            CreateGridViewColumn();
            InitEvents();
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

        private async void LoadSchoolSupplies(int enrollingId)
        {
            selectedEnrolling.SchoolSuppliesList = await schoolSupplieService.GetSchoolSupplieByEnrollingList(enrollingId);
            DataGridView.DataSource = selectedEnrolling.SchoolSuppliesList;
            DataGridView.BestFitColumns();
        }
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
            GridViewDecimalColumn quantityColumn = new("Quantity");
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
            quantityColumn.HeaderText = Language.LabelQuantity;
            cashFlowTypeColumn.HeaderText = Language.LabelSchoolSupplie;
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
            this.DataGridView.Columns.Add(quantityColumn);
            this.DataGridView.Columns.Add(cashFlowTypeColumn);
            this.DataGridView.Columns.Add(paymentMeanColumn);
            this.DataGridView.Columns.Add(transactionDateColumn);
            this.DataGridView.Columns.Add(transactionIdColumn);
            this.DataGridView.Columns.Add(doneByColumn);
            this.DataGridView.Columns.Add(isValidatedColumn);
            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Amount", " {0}", GridAggregateFunction.Sum),
                new GridViewSummaryItem("Quantity", " {0}", GridAggregateFunction.Sum),
            };
            DataGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
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

            LoadSchoolSupplies(enrolling.Id);
            //check authorizations
            this.SaveButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 18 && x.AllowCreate == true);
            this.PrintButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 18 && x.AllowPrint == true);
            this.ExportButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 18 && x.AllowPrint == true);
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
                ShowAddSchoolSuppliesForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        //affichage de UI pour l'ajout d'un versement
        private void ShowAddSchoolSuppliesForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddFeesPaymentForm>();
                form.Text = Language.labelAdd + ":.." + Language.LabelSchoolSupplie;
                form.Icon = this.Icon;
                form.Init(selectedEnrolling, TypeFee.SchoolSupply);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSchoolSupplies(selectedEnrolling.Id);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //fait appel au menu contextuel du grid view
        private  async void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if (DataGridView.CurrentRow.DataBoundItem is SchoolSupplie selectedSupplie)
                {
                    Program.UserConnected.Modules = await userService.GetUserModuleList(Program.UserConnected.Id);
                    if (!selectedSupplie.IsValidated)
                    {
                        RadMenuItem validateMenu = new(Language.LabelValidateTransaction)
                        {
                            Image = AppUtilities.GetImage("Check"),
                            Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 14 && x.AllowCreate == true)
                        };
                        validateMenu.Click += ValidateMenu_Click;
                        e.ContextMenu.Items.Add(validateMenu);
                    }
                }
            }
        }

        private async void ValidateMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is SchoolSupplie selectedItem)
                {
                    if (selectedItem != null && selectedItem.IsValidated == false)
                    {
                        var isValidated = await schoolSupplieService.ValidateSchoolSupplie(selectedItem.Id);
                        if (isValidated)
                        {

                            //enregistrement du log de validation
                            Log logValidate = new()
                            {
                                UserAction = $"Validation  fourniture scolaire {selectedItem.IdNumber} d'un montant de {selectedItem.Amount} pour {selectedItem.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logValidate);
                            //create cash flow
                            var cashFlow = new CashFlow()
                            {
                                Amount = selectedItem.Amount,
                                CashFlowType = selectedItem.CashFlowType,
                                CashFlowTypeId = selectedItem.CashFlowTypeId,
                                Date = DateTime.Now,
                                DoneBy = selectedItem.DoneBy,
                                SchoolYear = selectedEnrolling.SchoolYear,
                                SchoolYearId = selectedEnrolling.SchoolYearId,
                                Note = $"{Language.LabelSupplies} {selectedItem.IdNumber}:{selectedItem.CashFlowType.Name}  {selectedEnrolling.Student.FullName}",
                            };
                            var isDone = await cashFlowService.CreateCashFlow(cashFlow);
                            if (isDone)
                            {
                                LoadSchoolSupplies(selectedEnrolling.Id);
                                //enregistrement du log cash flow
                                Log logCash = new()
                                {
                                    UserAction = $"Ajout d'un flux de trésorerie de {cashFlow.Amount} pour {cashFlow.CashFlowType.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                    UserId = clientApp.UserConnected.Id
                                };
                                await logService.CreateLog(logCash);
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
    }
}
