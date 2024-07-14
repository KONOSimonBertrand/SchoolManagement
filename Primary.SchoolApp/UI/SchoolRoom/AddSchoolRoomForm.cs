
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolClasses;
using SchoolManagement.Application.SchoolRooms;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class AddSchoolRoomForm : SchoolManagement.UI.EditSchoolRoomForm
    {
        private readonly ILogService logService;
        private readonly ISchoolRoomService schoolRoomService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ClientApp clientApp;
        public AddSchoolRoomForm(ISchoolRoomService schoolRoomService,ILogService logService,ClientApp clientApp, ISchoolClassService schoolClassService)
        {
            InitializeComponent();
            this.clientApp = clientApp;
            this.schoolRoomService = schoolRoomService;
            this.schoolClassService = schoolClassService;
            this.logService = logService;
            ClassDropDownList.DataSource = Program.SchoolClassList;
            InitEvents();
            this.Text = "AJOUT:.SALLE DE CLASSE";

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
                if (!SchoolRomExist(NameTextBox.Text)) {
                    SchoolRoom room = new();
                    room.Name = NameTextBox.Text;
                    room.SchoolClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                    room.ClassId = room.SchoolClass.Id;
                    room.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = schoolRoomService.CreateSchoolRoom(room).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de la salle classe {room.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                else
                {
                    ErrorLabel.Text = "Une salle de classe portant le même nom existe déjà";
                }
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
            var item = Program.SchoolRoomList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolRoomService.GetSchoolRoom(name).Result != null;
        }
    }
}
