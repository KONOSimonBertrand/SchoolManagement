
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Primary.SchoolApp.Utilities;
using System.ComponentModel;
using System.Drawing;

namespace Primary.SchoolApp.UI
{
    internal class EditContactForm : SchoolManagement.UI.EditContactForm
    {
        private readonly IContactService contactService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private Contact selectedContact;
        private IList<Contact> contactList;
        public EditContactForm(IContactService contactService, ILogService logService, ClientApp clientApp)
        {
            this.contactService = contactService;
            this.logService = logService;
            this.clientApp = clientApp;
            CreateGridColumn();
            InitEvents();
            this.SearchButton.Image = AppUtilities.GetImage("Search");
            this.RelationshipDropDownList.DataSource = AppUtilities.GetRelationshipList();
        }
        private void InitEvents()
        {
            this.SaveButton.Click += SaveButton_Click;
            this.SearchButton.Click += SearchButton_Click;
            this.DataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            this.Shown += FormOnShown;
            this.DataGridView.CustomFiltering += DataGrid_CustomFiltering;
            this.NameTextBox.TextChanged += SearchTextBox_TextChanged;
        }
        private void CreateGridColumn()
        {
            this.DataGridView.AutoGenerateColumns = false;
            GridViewTextBoxColumn nameColumn = new GridViewTextBoxColumn("Name");
            GridViewTextBoxColumn phoneColumn = new GridViewTextBoxColumn("Phone");
            GridViewTextBoxColumn relationColumn = new GridViewTextBoxColumn("Relation");
            nameColumn.HeaderText = Language.labelContact;
            phoneColumn.HeaderText = Language.labelPhone;
            relationColumn.HeaderText = Language.labelRelationship;
            nameColumn.Width = 300;
            phoneColumn.Width = 100;
            relationColumn.Width = 100;
            this.DataGridView.Columns.Add(nameColumn);
            this.DataGridView.Columns.Add(phoneColumn);
            this.DataGridView.Columns.Add(relationColumn);
            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
            this.DataGridView.AllowAddNewRow = false;
            this.DataGridView.EnableGrouping = false;
            this.DataGridView.DataSource = new List<Contact>();
            this.DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.EnableFiltering = true;
            this.DataGridView.ShowFilteringRow = false;
            this.DataGridView.EnableCustomFiltering = true;
            this.DataGridView.AllowDeleteRow = false;
            this.DataGridView.AllowEditRow = false;
            this.DataGridView.ReadOnly = true;
        }
        private void FormOnShown(object sender, EventArgs e)
        {
            this.IdCardTextBox.Focus();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (this.DataGridView.Visible == false)
            {
                this.DataGridView.Visible = true;
            }
            if (DataGridView.Visible == true)
            {
                this.DataGridView.DataSource = contactList.Where(p => p.Name.Contains(this.NameTextBox.Text));
            }
        }
        internal void Init(Contact contact)
        {
            this.selectedContact = contact;
            this.StudentTextBox.Text = contact.Student.FullName;
            this.NameTextBox.Text = contact.Name;
            this.PhoneTextBox.Text = contact.Phone;
            this.EmailTextBox.Text = contact.Email;
            this.AddressTextBox.Text = contact.Address;
            this.SexDropDownList.SelectedValue = contact.Sex;
            this.JobTextBox.Text = contact.Job;
            this.IdCardTextBox.Text = contact.IdCard;
            this.RelationshipDropDownList.SelectedValue = contact.Relationship;

        }
        private async Task LoadContactList()
        {
            contactList = await contactService.GetContactList();
        }

        private void DataGridView_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (this.DataGridView.Visible == true)
            {
                var contact = e.Row.DataBoundItem as Contact;
                if (contact != null)
                {
                    this.IdCardTextBox.Text = contact.IdCard;
                    this.NameTextBox.Text = contact.Name;
                    this.AddressTextBox.Text = contact.Address;
                    this.PhoneTextBox.Text = contact.Phone;
                    this.SexDropDownList.SelectedValue = contact.Sex;
                    this.JobTextBox.Text = contact.Job;
                    this.EmailTextBox.Text = contact.Email;
                    this.RelationshipDropDownList.SelectedValue = contact.Relationship;
                }
                this.DataGridView.Visible = false;
            }

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.DataGridView.MasterTemplate.Refresh();
        }
        private void DataGrid_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {

            e.Handled = true;
            if (this.NameTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.NameTextBox.Text.ToLower()) ||
                     e.Row.Cells["Phone"].Value.ToString().ToLower().Contains(this.NameTextBox.Text.ToLower());
            }

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {              
                    selectedContact.Name = this.NameTextBox.Text;
                    selectedContact.Phone = this.PhoneTextBox.Text;
                    selectedContact.Address = this.AddressTextBox.Text;
                    selectedContact.Email = this.EmailTextBox.Text;
                    selectedContact.Sex = this.SexDropDownList.SelectedValue.ToString();
                    selectedContact.Relationship = int.Parse(this.RelationshipDropDownList.SelectedValue.ToString());
                    selectedContact.IdCard = this.IdCardTextBox.Text;
                    selectedContact.Job = this.JobTextBox.Text;
                    //update contact
                    var isDone = contactService.UpdateContact(selectedContact).Result;
                    if (isDone)
                    {
                        //enregistrement du log
                        Log log = new()
                        {
                            UserAction = $"Mise à jour d'un contact  {selectedContact.Name} de l'élève {selectedContact.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                        ErrorProvider.SetError(this.NameTextBox, Language.messageAddError);
                        this.NameTextBox.Focus();
                    } 
            }
        }     
    }
}
