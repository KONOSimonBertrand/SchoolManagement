
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Core.Model;
using System;
namespace Primary.SchoolApp.UI
{
    public partial class EditSchoolGroupForm : SchoolManagement.UI.EditSchoolGroupForm
    {
        private readonly ISchoolGroupService schoolGroupService;
        private SchoolGroup schoolGroup;
        public EditSchoolGroupForm(ISchoolGroupService schoolGroupService)
        {
            InitializeComponent();
            this.schoolGroupService = schoolGroupService;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (schoolGroup != null) { 
             schoolGroup.Name=NameTextBox.Text;
             schoolGroup.Sequence = int.Parse(SequenceSpinEditor.Value.ToString());
                if (IsValidData())
                {
                    var isDone=schoolGroupService.UpdateSchoolGroup(schoolGroup).Result;
                    if (isDone) {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
            }
        }
        internal void Init(SchoolGroup schoolGroup) { 
        this.schoolGroup = schoolGroup;
            if (schoolGroup != null) { 
             NameTextBox.Text=schoolGroup.Name;
             SequenceSpinEditor.Value = schoolGroup.Sequence;
            
            }
        }
    }
}
