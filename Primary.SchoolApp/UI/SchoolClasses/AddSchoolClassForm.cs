
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class AddSchoolClassForm : SchoolManagement.UI.EditSchoolClassForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISchoolGroupService schoolGroupService;
        public AddSchoolClassForm(ISchoolClassService schoolClassService, ILogService logService, ClientApp clientApp, ISchoolGroupService schoolGroupService)
        {
            InitializeComponent();
            this.logService = logService;
            this.schoolClassService = schoolClassService;
            this.clientApp = clientApp;
            this.schoolGroupService = schoolGroupService;
            GroupDropDownList.DataSource = Program.SchoolGroupList;
            InitEvents();
            this.Text = "AJOUT:.CLASSE";
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddGroupButton.Click += AddGroupButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(887, 281);
            NameTextBox.Focus();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            if (GroupDropDownList.SelectedItem==null)
            {
                ShowSchoolGroupAddForm();
            }
            else
            {
                var item = GroupDropDownList.SelectedItem.DataBoundItem as SchoolGroup;
                if (item != null) { 
                    ShowSchoolGroupEditForm(item);
                }
                else
                {
                    RadMessageBox.Show("Groupe inconnu");
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!SchoolClassExist(NameTextBox.Text)) {

                    SchoolClass schoolClass = new();
                    schoolClass.Name = NameTextBox.Text;
                    schoolClass.Group = GroupDropDownList.SelectedItem.DataBoundItem as SchoolGroup;
                    schoolClass.GroupId = schoolClass.Group.Id;
                    schoolClass.BookTypeId = (int)BookTypeDropDownList.SelectedValue;
                    schoolClass.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    bool isDone = schoolClassService.CreateSchoolClass(schoolClass).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de la lasse {schoolClass.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    ErrorLabel.Text = "Une classe portant le même nom existe déjà!";
                }
            }
        }

        // show school group UI for edit
        private void ShowSchoolGroupEditForm(SchoolGroup schoolGroup)
        {
            if (schoolGroup != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolGroupForm>();
                form.Init(schoolGroup);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolGroupService.GetSchoolGroup(form.NameTextBox.Text).Result;
                    GroupDropDownList.DataSource=null;
                    GroupDropDownList.DataSource = Program.SchoolGroupList;
                    GroupDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Groupe inconnu");
            }

        }
        // show school group UI for add new
        private void ShowSchoolGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolGroupForm>();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = schoolGroupService.GetSchoolGroup(form.NameTextBox.Text).Result;
                Program.SchoolGroupList.Add(data);
                GroupDropDownList.DataSource = null;
                GroupDropDownList.DataSource = Program.SchoolGroupList;
                GroupDropDownList.SelectedValue = data;
            }
        }

        private bool SchoolClassExist(string name)
        {
            var item = Program.SchoolClassList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolClassService.GetSchoolClass(name).Result != null;
        }
    }
}
