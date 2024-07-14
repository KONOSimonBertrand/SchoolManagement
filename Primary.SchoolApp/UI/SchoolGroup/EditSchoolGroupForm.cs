
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
namespace Primary.SchoolApp.UI
{
    public partial class EditSchoolGroupForm : SchoolManagement.UI.EditSchoolGroupForm
    {
        private readonly ISchoolGroupService schoolGroupService;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private SchoolGroup schoolGroup;
        private string schoolGroupNameTracker;
        public EditSchoolGroupForm(ISchoolGroupService schoolGroupService,ILogService logService,ClientApp clientApp)
        {
            this.schoolGroupService = schoolGroupService;
             this.clientApp = clientApp;
            this.logService = logService;
            this.schoolGroupNameTracker =string.Empty;
            InitializeComponent();
            InitEvents();
            this.Text = "MODIFICATION:.GROUPE DE CLASSES";
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click; 
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(788, 192);
            NameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {
                if (!SchoolGroupExist(NameTextBox.Text)) {
                    if (schoolGroup != null)
                    {
                        schoolGroup.Name = NameTextBox.Text;
                        schoolGroup.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                        bool isDone = schoolGroupService.UpdateSchoolGroup(schoolGroup).Result;
                        if (isDone)
                        {
                            Log log = new()
                            {
                                UserAction = $"Modification du groupe de classe {schoolGroup.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                                User = clientApp.UserConnected,
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
                }
                else
                {
                    ErrorLabel.Text = "Un groupe portant le même nom existe déjà!";
                }
            }
        }
        internal void Init(SchoolGroup schoolGroup) { 
        this.schoolGroup = schoolGroup;
            if (schoolGroup != null) {
                schoolGroupNameTracker = schoolGroup.Name;
             NameTextBox.Text=schoolGroup.Name;
             SequenceSpinEditor.Value = schoolGroup.Sequence;           
            }
        }
        private bool SchoolGroupExist(string name)
        {
            if (schoolGroupNameTracker == name) return false;
            var item = Program.SchoolGroupList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolGroupService.GetSchoolGroup(name).Result != null;
        }
    }
}
