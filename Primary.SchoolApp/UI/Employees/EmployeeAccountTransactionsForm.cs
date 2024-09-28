

using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
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
    internal class EmployeeAccountTransactionsForm : SchoolManagement.UI.EmployeeItemsForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public EmployeeAccountTransactionsForm(ILogService logService, IEmployeeService employeeService, ClientApp clientApp)
        {
            this.logService = logService;
            this.employeeService = employeeService;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            CloseButton.Click += CloseButton_Click;
            PrintButton.Click += PrintButton_Click;
            ExportButton.Click += ExportButton_Click;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            SaveButton.Text = Language.labelAdd;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titleRoomList);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleRoomList);
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

                e.Visible &= e.Row.Cells["Date"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                     e.Row.Cells["Reason"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
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
                ShowAddEmployeeAccountTransactionForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'employé etc.
        internal void Init(EmployeeEnrolling enrolling)
        {
            selectedEnrolling = enrolling;
            if (enrolling.Employee.FullName.Length >= 20)
            {
                NameLabel.Text = enrolling.Employee.FullName.Substring(0, 20) + "...";
            }
            else
            {
                this.NameLabel.Text = enrolling.Employee.FullName;
            }
            NameLabel.LabelElement.ToolTipText = enrolling.Employee.FullName;
            DateTime today = DateTime.Now;
            int age = today.Year - enrolling.Employee.BirthDate.Year;
            if (enrolling.Employee.BirthDate > today.AddYears(-age))
            {
                age--;
            }
            int workAge = today.Year - enrolling.Employee.HiringDate.Year;
            if (enrolling.Employee.HiringDate > today.AddYears(-workAge))
            {
                workAge--;
            }
            PersonalInformationLabel.Text = string.Format("{0} ans | {1} | {2}", age.ToString(), enrolling.Employee.Sex == "M" ? "Masculin" : "Feminin", enrolling.Employee.BirthDate.ToString("dd/MM/yyyy"));
            string schoolInfo = Language.labelHiredOn + " " + enrolling.Employee.HiringDate.ToString("dd/MM/yyyy") + " | " + workAge + " " + Language.labelYearOfService + " | " + enrolling.Job.Name + " | " + enrolling.GroupName + " | " + enrolling.SchoolYear;
            SchoolInformationLabel.LabelElement.ToolTipText = schoolInfo;
            if (schoolInfo.Length <= 121)
            {
                SchoolInformationLabel.Text = schoolInfo;
            }
            else
            {
                SchoolInformationLabel.Text = schoolInfo.Substring(0, 121) + "..."; ; ;
            }

            AddressLabel.Text = enrolling.Employee.Address;
            EmailLabel.Text = enrolling.Employee.Email;
            PhoneLabel.Text = enrolling.Employee.Phone;
            //affichage de la photo
            if (File.Exists(enrolling.PictureUrl))
            {

                PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Employee.PictureUrl))
                {
                    PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.Employee.PictureUrl), new Size(114, 114));
                }
                else
                {
                    var url = clientApp.EmployeePitureFolder + "/" + enrolling.Employee.IdNumber;
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

            //load transaction
            LoadACountTransactions(enrolling.Id);
        }
        // chargement de la liste des mouvements du compte dans le datagridview
        private async void LoadACountTransactions(int enrollingId)
        {
            selectedEnrolling.AccountTransactions = employeeService.GetAccountTransactionList(enrollingId).Result;
            DataGridView.DataSource = selectedEnrolling.AccountTransactions;
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
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewTextBoxColumn idTransactionColumn = new("TransactionId");
            GridViewTextBoxColumn reasonColumn = new("Reason");

            dateColumn.HeaderText = "Date";
            amountColumn.HeaderText = Language.labelAmount;
            reasonColumn.HeaderText = Language.labelReason;
            idTransactionColumn.HeaderText = Language.labelIdTransaction;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";

            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(amountColumn);
            this.DataGridView.Columns.Add(idTransactionColumn);
            this.DataGridView.Columns.Add(reasonColumn);
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
               if(DataGridView.CurrentRow.DataBoundItem is EmployeeAccountTransaction record)
                {
                    if (!record.TransactionId.ToLower().Contains("return"))
                    {
                        RadMenuItem returnMenu = new(Language.labelReturn);
                        e.ContextMenu.Items.Add(returnMenu);
                        returnMenu.Click += ReturnMenu_Click;
                    }
                }             
            }
        }
        // retour transaction
        private void ReturnMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is EmployeeAccountTransaction record)
                {
                    if (record != null)
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmReturn, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var transaction=new EmployeeAccountTransaction()
                            {
                                Date=record.Date,
                                Amount=(-1)*record.Amount,
                                TransactionId="Return"+record.TransactionId,
                                Enrolling=record.Enrolling,
                                EnrollingId=record.EnrollingId,
                                Reason=record.Reason,
                            };
                            if (!selectedEnrolling.AccountTransactions.Select(x=>x.TransactionId).Contains(transaction.TransactionId)) {
                                var isDone = employeeService.AddAccountTransaction(transaction).Result;
                                if (isDone)
                                {
                                    LoadACountTransactions(selectedEnrolling.Id);
                                    Log log = new()
                                    {
                                        UserAction = $"Ajout d'une transaction de {transaction.Amount} sur le compte de l'employé {selectedEnrolling.Employee.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    logService.CreateLog(log);
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
      
        //affichage de UI pour l'ajout d'une note
        private void ShowAddEmployeeAccountTransactionForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeAccountTransactionForm>();
            form.Text = selectedEnrolling.Employee.FullName + ":.." + Language.labelAdd + " " + Language.labelAccount;
            form.Init(selectedEnrolling);
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadACountTransactions(selectedEnrolling.Id);
            }
        }
       
    }

}
