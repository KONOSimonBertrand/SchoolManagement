using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    public partial class AddClassSubjectForm : SchoolManagement.UI.EditClassSubjectForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISubjectService subjectService;
        private readonly ISubjectGroupService subjectGroupService;
        private SchoolClass selectedClass;
        private IList<ClassSubject> subjectList;
        public AddClassSubjectForm(ISchoolClassService schoolClassService, ISubjectService subjectService, ISubjectGroupService subjectGroupService, ILogService logService, ClientApp clientApp)
        {
            this.schoolClassService = schoolClassService;
            this.subjectService = subjectService;
            this.subjectGroupService = subjectGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            GroupDropDownList.DataSource = Program.SubjectGroupList;
            SubjectDropDownList.DataSource = Program.SubjectList;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            AddGroupButton.Click += AddGroupButton_Click;
            AddSubjectButton.Click += AddSubjectButton_Click;
            this.Shown += OnShown;
            GroupDropDownList.ToolTipTextNeeded += GroupDropDownList_ToolTipTextNeeded;
            SubjectDropDownList.ToolTipTextNeeded += SubjectDropDownList_ToolTipTextNeeded;
        }

        private void SubjectDropDownList_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            if (SubjectDropDownList.SelectedItem != null)
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject subject)
                {
                    SubjectDropDownList.RootElement.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + subject.EnglishName : "French version: " + subject.FrenchName;
                }
            }

        }

        private void GroupDropDownList_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            if (GroupDropDownList.SelectedItem != null)
            {
                if (GroupDropDownList.SelectedItem.DataBoundItem is SubjectGroup group)
                {
                    GroupDropDownList.RootElement.ToolTipText = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Version anglaise: " + group.EnglishName : "French version: " + group.FrenchName;
                }
            }
        }

        internal void Init(SchoolClass selectedClass)
        {
            this.selectedClass = selectedClass;
            subjectList = schoolClassService.GetClassSubjectList(selectedClass.Id).Result;
            if (selectedClass.BookTypeId != 2)
            {
                this.SectionDropDownList.Items.Clear();
                this.SectionDropDownList.Items.Add(new RadListDataItem(string.Empty, 0));
                this.SectionDropDownList.SelectedIndex = 0;
                this.SectionDropDownList.Enabled = false;
            }
        }
        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            if (SubjectDropDownList.SelectedItem == null)
            {
                ShowSubjectAddForm();
            }
            else
            {
                if (SubjectDropDownList.SelectedItem.DataBoundItem is Subject item)
                {
                    ShowSubjectEditForm(item);
                }
                else
                {

                }
            }
        }
        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            if (GroupDropDownList.SelectedItem == null)
            {
                ShowSubjectGroupAddForm();
            }
            else
            {
                if (GroupDropDownList.SelectedItem.DataBoundItem is SubjectGroup item)
                {
                    ShowSubjectGroupEditForm(item);
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

                if (!RecordExist(selectedClass.Id, int.Parse(SubjectDropDownList.SelectedValue.ToString()), int.Parse(SectionDropDownList.SelectedValue.ToString())))
                {
                    var record = new ClassSubject();
                    record.Class = selectedClass;
                    record.ClassId = selectedClass.Id;
                    record.Subject = SubjectDropDownList.SelectedItem.DataBoundItem as Subject;
                    record.SubjectId = record.Subject.Id;
                    record.Group = GroupDropDownList.SelectedItem.DataBoundItem as SubjectGroup;
                    record.GroupId = record.Group.Id;
                    record.NotedOn = double.Parse(this.NoteOnTextBox.Text);
                    record.Coefficient = double.Parse(this.CoeficientTextBox.Text);
                    record.Sequence = int.Parse(this.SequenceSpinEditor.Value.ToString());
                    record.BookId = int.Parse(SectionDropDownList.SelectedValue.ToString());
                    var isDone = schoolClassService.CreateClassSubject(record).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout de la matière {record.Subject.FrenchName} pour la classe  {record.Class.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    this.ErrorLabel.Text = Language.messageSubjectExist;
                }
            }

        }

        private void OnShown(object sender, EventArgs e)
        {
            SubjectDropDownList.Focus();
        }
        // show subject UI for edit
        private void ShowSubjectEditForm(Subject subject)
        {
            if (subject != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectForm>();
                form.Text = Language.labelAdd + ":.. " + Language.labelSubject;
                form.Icon = this.Icon;
                form.Init(subject);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = subjectService.GetSubject(form.FrenchNameTextBox.Text).Result;
                    SubjectDropDownList.DataSource = null;
                    SubjectDropDownList.DataSource = Program.SubjectList;
                    SubjectDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show subject UI for add new
        private void ShowSubjectAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubjectForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubject;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = subjectService.GetSubject(form.FrenchNameTextBox.Text).Result;
                Program.SubjectList.Add(data);
                SubjectDropDownList.DataSource = null;
                SubjectDropDownList.DataSource = Program.SubjectList;
                SubjectDropDownList.SelectedValue = data;
            }
        }
        // show subject group UI for edit
        private void ShowSubjectGroupEditForm(SubjectGroup group)
        {
            if (group != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSubjectGroup;
                form.Icon = this.Icon;
                form.Init(group);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = subjectGroupService.GetSubjectGroup(form.FrenchNameTextBox.Text).Result;
                    GroupDropDownList.DataSource = null;
                    GroupDropDownList.DataSource = Program.SubjectGroupList;
                    GroupDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show("Groupe inconnu");
            }

        }
        // show subject group UI for add new
        private void ShowSubjectGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubjectGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubjectGroup;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = subjectGroupService.GetSubjectGroup(form.FrenchNameTextBox.Text).Result;
                Program.SubjectGroupList.Add(data);
                GroupDropDownList.DataSource = null;
                GroupDropDownList.DataSource = Program.SubjectGroupList;
                GroupDropDownList.SelectedValue = data;
            }
        }

        private bool RecordExist(int classId, int subjectId, int bookId)
        {
            var item = subjectList.FirstOrDefault(x => x.ClassId == classId && x.SubjectId == subjectId && x.BookId == bookId);
            if (item != null) return true;
            return schoolClassService.GetClassSubject(classId, subjectId, bookId).Result != null;
        }
    }
}
