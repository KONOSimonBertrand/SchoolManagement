
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
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
            this.logService = logService;
            this.clientApp = clientApp;
            this.schoolClassService = schoolClassService;
            this.schoolGroupService = schoolGroupService;
            schoolClassNameTracker = string.Empty;
            IsTruncateDropDownList.SelectedValue = 0;
            InitEvents();

        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddGroupButton.Click += AddGroupButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            if (GroupDropDownList.SelectedItem == null)
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
                if (!RecordExist(NameTextBox.Text))
                {
                    schoolClass.Name = NameTextBox.Text;
                    schoolClass.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                    schoolClass.Group = GroupDropDownList.SelectedItem.DataBoundItem as SchoolGroup;
                    schoolClass.GroupId = schoolClass.Group.Id;
                    schoolClass.DocumentLanguageId = (int)DocumentTemplateDropDownList.SelectedValue;
                    schoolClass.ReportCardModel = int.Parse(ReportCardDropDownList.SelectedValue.ToString());
                    schoolClass.AverageFormula = int.Parse(AverageFormulaDropDownList.SelectedValue.ToString());
                    schoolClass.NoteIsTruncate = IsTruncateDropDownList.SelectedValue.ToString()=="0"?false:true;
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
                        ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageClassExist;
                }

            }
        }

        internal void InitStartup(SchoolClass schoolClass)
        {
            if (schoolClass != null)
            {
                schoolClassNameTracker = schoolClass.Name;
                GroupDropDownList.DataSource = Program.SchoolGroupList;
                this.schoolClass = schoolClass;
                NameTextBox.Text = schoolClass.Name;
                SequenceSpinEditor.Value = schoolClass.Sequence;
                GroupDropDownList.SelectedValue = schoolClass.GroupId;
                DocumentTemplateDropDownList.SelectedValue = schoolClass.DocumentLanguageId;
                IsTruncateDropDownList.SelectedValue = schoolClass.NoteIsTruncate==true?1:0;
                ReportCardDropDownList.SelectedValue = schoolClass.ReportCardModel;
                AverageFormulaDropDownList.SelectedValue=schoolClass.AverageFormula;
            }
        }
        // show school grou UI for edit
        private void ShowSchoolGroupEditForm(SchoolGroup schoolGroup)
        {
            if (schoolGroup != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClassGroup;
                form.Icon=this.Icon;
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
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show school group UI for add new
        private void ShowSchoolGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClassGroup;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = schoolGroupService.GetSchoolGroup(form.NameTextBox.Text).Result;
                Program.SchoolGroupList.Add(data);
                GroupDropDownList.DataSource = null;
                GroupDropDownList.DataSource = Program.SchoolGroupList;
                GroupDropDownList.SelectedValue = data;
            }
        }
        private bool RecordExist(string name)
        {
            if (schoolClassNameTracker == name) return false;
            var item = Program.SchoolClassList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolClassService.GetSchoolClass(name).Result != null;
        }
    }
}
