﻿

using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class EditSchoolRoomForm : SchoolManagement.UI.EditSchoolRoomForm
    {
        private readonly ILogService logService;
        private readonly ISchoolRoomService schoolRoomService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ClientApp clientApp;
        private SchoolRoom schoolRoom;
        private string schoolRoomNameTracker;
        public EditSchoolRoomForm(ISchoolRoomService schoolRoomService, ILogService logService, ClientApp clientApp, ISchoolClassService schoolClassService)
        {
            InitializeComponent();
            this.schoolRoomService = schoolRoomService;
            this.schoolClassService = schoolClassService;
            this.logService = logService;
            this.clientApp = clientApp; 
            schoolRoomNameTracker =string.Empty;
            InitEvents();
            this.Text = "MODIFICATION:.SALLE DE CLASSE";
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(924, 280);
            NameTextBox.Focus();
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem == null) {
                ShowSchoolClassAddForm();
            }
            else
            {
                ShowSchoolClassEditForm(ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!SchoolRomExist(NameTextBox.Text))
                {
                    schoolRoom.Name = NameTextBox.Text;
                    schoolRoom.SchoolClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                    schoolRoom.ClassId = schoolRoom.SchoolClass.Id;
                    schoolRoom.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = schoolRoomService.UpdateSchoolRoom(schoolRoom).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des informations de la salle de classe {schoolRoom.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else {
                    ErrorLabel.Text = "Une salle de classe portant le même nom existe déjà";
                }

            }
        }

        internal void Init(SchoolRoom schoolRoom)
        {
            if (schoolRoom != null)
            {
                ClassDropDownList.DataSource = Program.SchoolClassList;
                schoolRoomNameTracker = schoolRoom.Name;
                this.schoolRoom = schoolRoom;
                NameTextBox.Text = schoolRoom.Name;
                SequenceSpinEditor.Value = schoolRoom.Sequence;
                ClassDropDownList.SelectedValue = schoolRoom.ClassId;
               SequenceSpinEditor.Value = schoolRoom.Sequence;

            }
        }

        // show school class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Init(item);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassDropDownList.DataSource = null;
                    ClassDropDownList.DataSource = Program.SchoolClassList;
                    ClassDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Salle de Classe inconnue");
            }
        }
        // show school class UI to add new 
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                ClassDropDownList.DataSource = null;
                ClassDropDownList.DataSource = Program.SchoolClassList;
                ClassDropDownList.SelectedValue = data;
            }
        }
        private bool SchoolRomExist(string name)
        {
            if(schoolRoomNameTracker==name) return false;
            var item = Program.SchoolRoomList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolRoomService.GetSchoolRoom(name).Result != null;
        }
    }
}