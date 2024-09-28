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

namespace Primary.SchoolApp.UI
{
    internal class TuitionDiscountsForm : SchoolManagement.UI.StudentItemsForm
    {
        private readonly ICashFlowService cashFlowService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public TuitionDiscountsForm(ICashFlowService cashFlowService, ClientApp clientApp)
        {
            this.cashFlowService = cashFlowService;
            this.clientApp = clientApp;
            this.SaveButton.ButtonElement.ToolTipText = Language.messageClickToAddDiscount;
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

            //load discount
            LoadDiscounts(enrolling.Id);
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

                e.Visible &= e.Row.Cells["CashFlowType.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                    e.Row.Cells["OrdoredBy"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
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
                ShowAddTuitionDiscountForm();
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // chargement de la liste des réductions dans le datagridview
        private async void LoadDiscounts(int enrollingId)
        {
            selectedEnrolling.DiscountList = cashFlowService.GetTuitionDiscountByEnrollingList(enrollingId).Result;
            DataGridView.DataSource = selectedEnrolling.DiscountList;
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
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewTextBoxColumn cashFlowTypeColumn = new("CashFlowType.Name");
            GridViewTextBoxColumn reasonColumn = new("Reason");
            GridViewTextBoxColumn ordoredByColumn = new("OrderedBy");
            dateColumn.HeaderText = "Date";
            amountColumn.HeaderText = Language.labelAmount;
            reasonColumn.HeaderText = Language.labelReason;
            cashFlowTypeColumn.HeaderText = Language.labelSchoolingFee;
            ordoredByColumn.HeaderText = Language.labelOrdoredBy;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";

            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(amountColumn);
            this.DataGridView.Columns.Add(cashFlowTypeColumn);
            this.DataGridView.Columns.Add(reasonColumn);
            this.DataGridView.Columns.Add(ordoredByColumn);
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
                if (DataGridView.CurrentRow.DataBoundItem is TuitionDiscount record)
                {
                    RadMenuItem editMenu = new(Language.labelEdit)
                    {
                        Image = AppUtilities.GetImage("Edit")
                    };
                    e.ContextMenu.Items.Add(editMenu);
                    editMenu.Click += EditMenu_Click;
                }
            }
        }       

        // retour versement
        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is TuitionDiscount record)
                {
                    record.Enrolling=selectedEnrolling;
                    ShowEditTuitionDiscountForm(record);
                }

            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        //affichage de UI pour l'ajout d'une réduction
        private void ShowAddTuitionDiscountForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddTuitionDiscountForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelDiscount;
                form.Icon = this.Icon;
                form.Init(selectedEnrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDiscounts(selectedEnrolling.Id);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        //affichage de UI pour modifier une réduction
        private void ShowEditTuitionDiscountForm(TuitionDiscount discount)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<EditTuitionDiscountForm>();
                form.Text = Language.labelUpdate+ ":.." + Language.labelDiscount;
                form.Icon = this.Icon;
                form.Init(discount);
                if (form.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

    }
}
