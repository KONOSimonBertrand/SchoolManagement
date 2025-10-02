

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class SchoolSuppliesForm : SchoolManagement.UI.StudentItemsForm
    {
        private readonly ISchoolSupplieService schoolSupplieService;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        public SchoolSuppliesForm(ISchoolSupplieService schoolSupplieService, ClientApp clientApp)
        {
            this.schoolSupplieService = schoolSupplieService;
            this.clientApp = clientApp;
            this.SaveButton.ButtonElement.ToolTipText = Language.messageClickToAddDiscount;
            CreateGridViewColumn();
            InitEvents();
        }

        private void InitEvents()
        {
           
        }

        private void CreateGridViewColumn()
        {
            
        }

        // initialise certains éléments. chargement de la photo,
        // affichage des informations personnelles de l'élève etc.
        internal void Init(StudentEnrolling enrolling)
        {
            enrolling.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == enrolling.SchoolYearId);
            selectedEnrolling = enrolling;
            if (enrolling.Student.FullName.Length >= 17)
            {
                NameLabel.Text = enrolling.Student.FullName.Substring(0, 17) + "...";
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

            PersonalInformationLabel.Text = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), enrolling.Student.Sex == "M" ? Language.LabelMale : Language.LabelFemale, enrolling.Student.BirthDate.ToString("dd/MM/yyyy"));
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

            AddressLabel.Text = enrolling.Student.Address;
            EmailLabel.Text = enrolling.Student.Email;
            PhoneLabel.Text = enrolling.Student.Phone;
            //affichage de la photo
            if (File.Exists(enrolling.PictureUrl))
            {

                PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Student.PictureUrl))
                {
                    PictureLabel.Image = new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(114, 114));
                }
                else
                {
                    var url = Program.CurrentSchool.StudentPictureDirectory + "/" + enrolling.Student.IdNumber;
                    if (File.Exists(url))
                    {

                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.no_image);
                        PictureLabel.Image = Image.FromStream(ms);
                    }
                }

            }

            //load discount
            //LoadDiscounts(enrolling.Id);
            //check authorizations
            this.SaveButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 5 && x.AllowCreate == true);
            this.PrintButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 5 && x.AllowPrint == true);
            this.ExportButton.Enabled = Program.UserConnected.Modules.Any(x => x.ModuleId == 5 && x.AllowPrint == true);
        }
    }
}
