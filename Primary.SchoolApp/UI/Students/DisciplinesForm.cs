using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Drawing;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.UI.Localization;
using System.IO;

namespace Primary.SchoolApp.UI
{
    internal class DisciplinesForm : SchoolManagement.UI.StudentItemsForm
    {
     
        private readonly IDisciplineService disciplineService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public DisciplinesForm(IPrintService printService, IDisciplineService disciplineService, ILogService logService, ClientApp clientApp)
        {
            this.disciplineService = disciplineService;
            this.logService = logService;
            this.clientApp = clientApp;
            CreateGridViewColumn();
            InitEvents();
        }
        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'élève etc.
        internal void Init(StudentEnrolling enrolling)
        {
            SaveButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowCreate == true);

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

            //load disciplines
            LoadDisciplines(selectedEnrolling.StudentId);
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
                e.Visible &= e.Row.Cells["Subject.DefaultName"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower())||
                     e.Row.Cells["Reason"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower())||
                e.Row.Cells["Evaluation.DefaultName"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }
        // add new discipline
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (!Program.CurrentSchoolYear.IsClosed)
                {
                    var form = Program.ServiceProvider.GetService<AddDisciplineForm>();
                    form.Text = Language.labelAdd + ":.." + Language.labelDiscipline;
                    form.Icon = this.Icon;
                    form.Init(selectedEnrolling.Student);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDisciplines(selectedEnrolling.StudentId);
                    }
                }
                else
                {
                    RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // chargement de la liste des abonnements dans le datagridview
        private async void LoadDisciplines(int studentId)
        {
            DataGridView.DataSource = await disciplineService.GetDisciplineListByStudent(studentId,Program.CurrentSchoolYear.Id);
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
            GridViewDateTimeColumn dateColumn = new("Date");
            GridViewDecimalColumn durationColumn = new("Duration");
            GridViewTextBoxColumn subjectColumn = new("Subject.DefaultName");
            GridViewTextBoxColumn reasonColumn = new("Reason");
            GridViewTextBoxColumn evaluationColumn = new("Evaluation.DefaultName");

            dateColumn.HeaderText = "Date";
            durationColumn.HeaderText = Language.labelDuration;
            subjectColumn.HeaderText = Language.labelDisciplineSubject;
            reasonColumn.HeaderText = Language.labelReason;
            evaluationColumn.HeaderText = Language.labelEvaluationSession;
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd/MM/yyyy";
            dateColumn.FormatString = "{0:dd/MM/yyyy}";
            this.DataGridView.Columns.Add(dateColumn);
            this.DataGridView.Columns.Add(durationColumn);
            this.DataGridView.Columns.Add(subjectColumn);
            this.DataGridView.Columns.Add(reasonColumn);         
            this.DataGridView.Columns.Add(evaluationColumn);
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
                RadMenuItem editMenu = new(Language.labelEdit);
                RadMenuItem deleteMenu = new(Language.labelDelete);
                editMenu.Image = AppUtilities.GetImage("Edit");
                deleteMenu.Image = AppUtilities.GetImage("Delete");
                editMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowUpdate == true);
                deleteMenu.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowDelete == true);
                SaveButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 7 && x.AllowCreate == true);
                e.ContextMenu.Items.Add(editMenu);
                e.ContextMenu.Items.Add(deleteMenu);
                editMenu.Click += EditMenu_Click;
                deleteMenu.Click += DeleteMenu_Click;
            }
        }
        //suppression
        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is Discipline discipline)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes) { 
                    var isDone=disciplineService.DeleteDiscipline(discipline.Id).Result;
                    if (isDone)
                    {
                        LoadDisciplines(selectedEnrolling.StudentId);
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Suppression l'objet disciplinaire  {discipline.Subject.DefaultName} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(logSubscription);
                        
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageDeleteError;
                    }
                }
            }
        }

        // edit discipline
        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is Discipline discipline)
                {
                    if (!Program.CurrentSchoolYear.IsClosed)
                    {
                        var form = Program.ServiceProvider.GetService<EditDisciplineForm>();
                        form.Text = Language.labelUpdate+ ":.." + Language.labelDiscipline;
                        form.Icon = this.Icon;
                        form.Init(discipline);
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadDisciplines(selectedEnrolling.StudentId);
                        }
                    }
                    else
                    {
                        RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
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
