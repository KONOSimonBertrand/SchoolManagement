

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.IO;

namespace Primary.SchoolApp.UI
{
    internal  class UploadEmployeePictureForm:SchoolManagement.UI.UploadPictureForm
    {
        private readonly ILogService logService;
        private readonly IEmployeeService employeeService;
        private readonly ClientApp clientApp;
        private EmployeeEnrolling selectedEnrolling;
        public UploadEmployeePictureForm(IEmployeeService employeeService,  ClientApp clientApp, ILogService logService) {
            
            this.employeeService = employeeService;
            this.clientApp = clientApp; 
            this.logService = logService;
            this.Text = "Photo";
            InitEvents();
            UrlPicture=string.Empty;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var isDone = employeeService.SaveEmployeeEnrollingPicture(selectedEnrolling.Id, UrlPicture).Result;
                employeeService.SaveEmployeePicture(selectedEnrolling.EmployeeId, UrlPicture);
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  d'une photo {selectedEnrolling.Employee.FullName} pour l'année {selectedEnrolling.SchoolYear.Name}  par l'utilisateur {clientApp.UserConnected.UserName}",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    ErrorLabel.Text=Language.messageAddError;
                }
            }
            

        }

        internal void Init(EmployeeEnrolling enrolling)
        {
            this.selectedEnrolling = enrolling;
            if (enrolling.Employee.FullName.Length >= 20)
            {
                NameLabel.Text = enrolling.Employee.FullName.Substring(0, 20) + "..."; 
            }
            else
            {
                this.NameLabel.Text = enrolling.Employee.FullName;
            }
            NameLabel.LabelElement.ToolTipText = enrolling.Employee.FullName;
            DateTime today = DateTime.Now;
            int age = today.Year - enrolling.Employee.BirthDate.Year;
            if (enrolling.Employee.BirthDate > today.AddYears(-age))
            {
                age--;
            }
            int workAge = today.Year - enrolling.Employee.HiringDate.Year;
            if (enrolling.Employee.HiringDate > today.AddYears(-workAge))
            {
                workAge--;
            }
            PersonalInformationLabel.Text = string.Format("{0} ans | {1} | {2}", age.ToString(), enrolling.Employee.Sex == "M" ? "Masculin" : "Feminin", enrolling.Employee.BirthDate.ToString("dd/MM/yyyy"));
            string schoolInfo= Language.labelHiredOn+" " + enrolling.Employee.HiringDate.ToString("dd/MM/yyyy") + " | " + workAge + " "+Language.labelYearOfService + " | "+ enrolling.Job.Name + " | " + enrolling.GroupName + " | " + enrolling.SchoolYear;
            SchoolInformationLabel.LabelElement.ToolTipText = schoolInfo;
            if (schoolInfo.Length <= 121)
            {
                SchoolInformationLabel.Text =schoolInfo;
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
                if (File.Exists(enrolling.Employee.PictureUrl))
                {
                    Bitmap bitmap = new(Image.FromFile(enrolling.Employee.PictureUrl), new Size(114, 114));
                    this.SetPanelImage(bitmap);
                }
                else
                {
                    //on cherche une photo dans le dossier 
                    var url = clientApp.EmployeePitureFolder + "/" + enrolling.Employee.IdNumber;
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
