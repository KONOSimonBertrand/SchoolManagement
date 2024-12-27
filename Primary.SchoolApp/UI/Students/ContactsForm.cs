using Microsoft.Extensions.DependencyInjection;
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
using Primary.SchoolApp.DTO;
using System.Collections.Generic;

namespace Primary.SchoolApp.UI
{
    internal class ContactsForm:SchoolManagement.UI.StudentItemsForm
    {
        private readonly IContactService contactService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public ContactsForm(IContactService contactService, ILogService logService, ClientApp clientApp)
        {
            this.contactService = contactService;
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

            //load contacts
            LoadContacts(enrolling.StudentId);
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
            AppUtilities.ExportGridViewToExcel(DataGridView, Language.titleContactList);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            AppUtilities.PrintGridView(DataGridView, Language.titleContactList);
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
                e.Visible &= e.Row.Cells["Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                     e.Row.Cells["Phone"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                e.Row.Cells["Address"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }
        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridView.MasterTemplate.Refresh();
        }
        // add new contact
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (!Program.CurrentSchoolYear.IsClosed)
                {
                    var form = Program.ServiceProvider.GetService<AddContactForm>();
                    form.Text = Language.labelAdd + ":.." + Language.labelContact;
                    form.Icon = this.Icon;
                    form.Init(selectedEnrolling.Student);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadContacts(selectedEnrolling.StudentId);
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
        // chargement de la liste des contact dans le datagridview
        private async void LoadContacts(int studentId)
        {
            var contactList = await contactService.GetContactList(studentId);
            selectedEnrolling.Student.ContactList = contactList;
            IList<ContactDTO> contactDTOList=new List<ContactDTO>();
            foreach (var contact in contactList) {
                contactDTOList.Add(contact.AsContactDTO());
            }

            DataGridView.DataSource = contactDTOList;
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
            GridViewTextBoxColumn contactColumn = new("Name");
            GridViewTextBoxColumn phoneColumn = new("Phone");
            GridViewTextBoxColumn AddressColumn = new("Address");
            GridViewTextBoxColumn emailColumn = new("Email");
            GridViewTextBoxColumn jobColumn = new("Job");
            GridViewTextBoxColumn idCardColumn = new("IdCard");
            GridViewTextBoxColumn relationColumn = new("RelationshipName");

            contactColumn.HeaderText = Language.labelContact;
            relationColumn.HeaderText = Language.labelRelationship;
            phoneColumn.HeaderText = Language.labelPhone;
            AddressColumn.HeaderText = Language.labelAddress;
            emailColumn.HeaderText = Language.labelMail;
            jobColumn.HeaderText = Language.labelJob;
            idCardColumn.HeaderText = Language.labelIdCard;

            this.DataGridView.Columns.Add(contactColumn);
            this.DataGridView.Columns.Add(phoneColumn);
            this.DataGridView.Columns.Add(AddressColumn);
            this.DataGridView.Columns.Add(emailColumn);
            this.DataGridView.Columns.Add(relationColumn);
            this.DataGridView.Columns.Add(jobColumn);
            this.DataGridView.Columns.Add(idCardColumn);


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
                e.ContextMenu.Items.Add(editMenu);
                e.ContextMenu.Items.Add(deleteMenu);
                editMenu.Click += EditMenu_Click;
                deleteMenu.Click += DeleteMenu_Click;
            }
        }
        //suppression
        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.DataBoundItem is ContactDTO contactDTO)
            {
                DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmDelete, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var isDone = contactService.DeleteContact(contactDTO.Id).Result;
                    if (isDone)
                    {
                        LoadContacts(selectedEnrolling.StudentId);
                        //enregistrement du log
                        Log logSubscription = new()
                        {
                            UserAction = $"Suppression du contact  {contactDTO.Name} de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
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

        // edit contact
        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                if (DataGridView.CurrentRow.DataBoundItem is ContactDTO contactDTO)
                {
                    if (!Program.CurrentSchoolYear.IsClosed)
                    {
                        var form = Program.ServiceProvider.GetService<EditContactForm>();
                        form.Text = Language.labelUpdate + ":.." + Language.labelContact;
                        form.Icon = this.Icon;
                        form.Init(contactDTO.AsContact());
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadContacts(selectedEnrolling.StudentId);
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
