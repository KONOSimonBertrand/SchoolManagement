

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class UploadStudentPictureForm : SchoolManagement.UI.UploadPictureForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public UploadStudentPictureForm(ILogService logService, IStudentService studentService, ClientApp clientApp, IStudentEnrollingService studentEnrollingService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.clientApp = clientApp;
            this.studentEnrollingService = studentEnrollingService;
            this.Text = "Photo";
            InitEvents();
            UrlPicture = string.Empty;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var isDone = studentEnrollingService.SaveStudentEnrollingPictureAsync(selectedEnrolling.Id, UrlPicture).Result;
                studentService.SaveStudentPictureAsync(selectedEnrolling.StudentId, UrlPicture);
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  d'une photo {selectedEnrolling.Student.FullName} pour l'année {selectedEnrolling.SchoolYear.Name}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    ErrorLabel.Text = Language.messageAddError;
                }
            }
        }

        internal void Init(StudentEnrolling enrolling)
        {
            if(enrolling.SchoolYear==null) enrolling.SchoolYear =Program.CurrentSchoolYear;
            enrolling.SchoolClass =Program.SchoolClassList.FirstOrDefault(x=>x.Id==enrolling.ClassId);
            this.selectedEnrolling = enrolling;
            if (enrolling.Student.FullName.Length >= 20)
            {
                NameLabel.Text = enrolling.Student.FullName.Substring(0, 20) + "...";
            }
            else
            {
                this.NameLabel.Text = enrolling.Student.FullName;
            }
            NameLabel.LabelElement.ToolTipText = enrolling.Student.FullName;
            DateTime today = DateTime.Now;
            int age = today.Year - enrolling.Student.BirthDate.Year;
            if (enrolling.Student.BirthDate > today.AddYears(-age))
            {
                age--;
            }
           
            PersonalInformationLabel.Text = string.Format("{0} ans | {1} | {2}", age.ToString(), enrolling.Student.Sex == "M" ? "Masculin" : "Feminin", enrolling.Student.BirthDate.ToString("dd/MM/yyyy"));
            string schoolInfo = Language.labelRegisteredOn + " " + enrolling.Date.ToString("dd/MM/yyyy") + " | " + enrolling.SchoolClass.Name + " | " + enrolling.SchoolClass.Group.Name + " | " + enrolling.SchoolYear.Name;
            SchoolInformationLabel.LabelElement.ToolTipText = schoolInfo;
            if (schoolInfo.Length <= 121)
            {
                SchoolInformationLabel.Text = schoolInfo;
            }
            else
            {
                SchoolInformationLabel.Text = schoolInfo.Substring(0, 121) + "..."; ; ;
            }
            //affichage de la photo
            if (File.Exists(enrolling.PictureUrl))
            {

                Bitmap bitmap = new(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
                this.SetPanelImage(bitmap);
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Student.PictureUrl))
                {
                    Bitmap bitmap = new(Image.FromFile(enrolling.Student.PictureUrl), new Size(114, 114));
                    this.SetPanelImage(bitmap);
                }
                else
                {
                    //on cherche une photo dans le dossier 
                    var url = clientApp.StudentPitureFolder + "/" + enrolling.Student.IdNumber;
                    if (File.Exists(url))
                    {
                        Bitmap bitmap = new(Image.FromFile(url), new Size(114, 114));
                        this.SetPanelImage(bitmap);
                    }
                    else
                    {
                        this.SetPanelImage(this.DefaultImage);
                    }
                }
            }
        }
    }
}
