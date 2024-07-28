

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public partial class EditJobForm : SchoolManagement.UI.EditJobForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IJobService jobService;
        private string jobNameTracker;
        private Job job;
        public EditJobForm(IJobService jobService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.jobService = jobService;
            this.clientApp = clientApp;
            this.logService = logService;
            this.Text = "MODIFICATION:.FONCTION";
            jobNameTracker=string.Empty;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }
        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(546, 182);
            NameTextBox.Focus();
        }
        internal void Init(Job job) { 
            this.job = job;
            jobNameTracker = job.Name;
            NameTextBox.Text = job.Name;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!JobExist(NameTextBox.Text))
                {
                    job.Name = NameTextBox.Text;
                    var isDone = jobService.UpdateJob(job).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour fonction employé {job.Name} par l'utilisateur {clientApp.UserConnected.UserName} ",
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
                    this.ErrorLabel.Text = "Cette fonction existe déjà";
                }
            }
        }
        private bool JobExist(string name)
        {
            if (jobNameTracker == name) return false;
            var item = Program.JobList.FirstOrDefault(x => x.Name == name);
            if (item != null) return true;
            return jobService.GetJob(name).Result != null;
        }


    }
}
