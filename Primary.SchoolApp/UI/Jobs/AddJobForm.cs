using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddJobForm : SchoolManagement.UI.EditJobForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IJobService jobService;
        public AddJobForm(IJobService jobService, ILogService logService, ClientApp clientApp)
        {
            this.jobService = jobService;
            this.clientApp = clientApp;
            this.logService = logService;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!JobExist(NameTextBox.Text))
                {
                    Job job = new Job();
                    job.Name = NameTextBox.Text;
                    var isDone = jobService.CreateJob(job).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout fonction employé {job.Name}  par l'utilisateur {clientApp.UserConnected.UserName}",
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
                    this.ErrorLabel.Text = Language.messageJobExist;
                }
            }
        }
        private bool JobExist(string name)
        {
            var item = Program.JobList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return jobService.GetJob(name).Result != null;
        }


    }
}
