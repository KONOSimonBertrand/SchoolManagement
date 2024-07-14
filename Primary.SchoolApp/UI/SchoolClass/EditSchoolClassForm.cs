
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolClasses;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    public partial class EditSchoolClassForm : SchoolManagement.UI.EditSchoolClassForm
    {
        private readonly ISchoolClassService schoolClassService;
        private readonly ISchoolGroupService schoolGroupService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private SchoolClass schoolClass;
        private string schoolClassNameTracker;
        public EditSchoolClassForm(ISchoolClassService schoolClassService, ILogService logService, ClientApp clientApp, ISchoolGroupService schoolGroupService)
        {
            InitializeComponent();
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolClassService = schoolClassService;
            this.schoolGroupService = schoolGroupService;
            schoolClassNameTracker=string.Empty;
            InitEvents();
            this.Text = "MODIFICATION:.CLASSE";

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
            if (GroupDropDownList.SelectedItem ==null)
            {
                ShowSchoolGroupAddForm();
            }
            else
            {
                var item = GroupDropDownList.SelectedItem.DataBoundItem as SchoolGroup;
                if (item != null)
                {
                    ShowSchoolGroupEditForm(item);
                }
                else
                {

                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!SchoolClassExist(NameTextBox.Text)) {
                    schoolClass.Name = NameTextBox.Text;
                    schoolClass.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    schoolClass.Group = GroupDropDownList.SelectedItem.DataBoundItem as SchoolGroup;
                    schoolClass.GroupId = schoolClass.Group.Id;
                    schoolClass.BookTypeId = (int)BookTypeDropDownList.SelectedValue;
                    bool isDone = schoolClassService.UpdateSchoolClass(schoolClass).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Modification des informations de la classe {schoolClass.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    ErrorLabel.Text = "Une classe portant le même nom existe déjà!";
                }

            }
        }

        internal void Init(SchoolClass schoolClass)
        {
            if (schoolClass != null)
            {
                schoolClassNameTracker = schoolClass.Name;
                GroupDropDownList.DataSource = Program.SchoolGroupList;
                this.schoolClass = schoolClass;
                NameTextBox.Text = schoolClass.Name;
                SequenceSpinEditor.Value = schoolClass.Sequence;
                GroupDropDownList.SelectedValue = schoolClass.GroupId;
                BookTypeDropDownList.SelectedValue=schoolClass.BookTypeId;
            }
        }
        // show school grou UI for edit
        private void ShowSchoolGroupEditForm(SchoolGroup schoolGroup)
        {
            if (schoolGroup != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolGroupForm>();
                form.Init(schoolGroup);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = schoolGroupService.GetSchoolGroup(form.NameTextBox.Text).Result;
                    GroupDropDownList.DataSource = null;
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
                GroupDropDownList.DataSource=null;
                GroupDropDownList.DataSource=Program.SchoolGroupList;
                GroupDropDownList.SelectedValue = data;
            }
        }
        private bool SchoolClassExist(string name)
        {
            if (schoolClassNameTracker == name) return false;
            var item = Program.SchoolClassList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolClassService.GetSchoolClass(name).Result != null;
        }
    }
}
