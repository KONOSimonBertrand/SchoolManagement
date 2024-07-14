﻿
using SchoolManagement.Application.Logs;
using SchoolManagement.Application.SchoolGroups;
using SchoolManagement.Application.SchoolYears;
using SchoolManagement.Core.Model;
using System;
using System.Linq;
namespace Primary.SchoolApp.UI
{
    public partial class AddSchoolGroupForm : SchoolManagement.UI.EditSchoolGroupForm
    {

        private readonly ISchoolGroupService schoolGroupService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        public AddSchoolGroupForm(ISchoolGroupService schoolGroupService,ILogService logService,ClientApp clientApp)
        {
            this.schoolGroupService = schoolGroupService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitializeComponent();
            InitEvents();
            this.Text = "AJOUT:.GROUPE DE CLASSES";
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
            if (IsValidData())
            {
                if (!SchoolGroupExist(NameTextBox.Text)) {
                    SchoolGroup schoolGroup = new()
                    {
                        Name = NameTextBox.Text,
                        Sequence = int.Parse(SequenceSpinEditor.Value.ToString())
                    };
                    bool isDone = schoolGroupService.CreateSchoolGroup(schoolGroup).Result;
                    if (isDone == true)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout du groupe de classe {schoolGroup.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
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
                    ErrorLabel.Text = "Un groupe portant le même nom existe déjà!";
                }
            }
        }

        private bool SchoolGroupExist(string name)
        {
            var item = Program.SchoolGroupList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return schoolGroupService.GetSchoolGroup(name).Result != null;
        }
    }
}