using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Primary.SchoolApp.Reporting
{
    internal class SchoolCertificateReport: SchoolManagement.UI.Reporting.SchoolCertificateReport
    {
        public SchoolCertificateReport(StudentEnrollingDTO dataSource,ClientApp clientApp)
        {
            string img=string.Empty;
            if (dataSource.SchoolClass.DocumentLanguageId==0|| dataSource.SchoolClass.DocumentLanguageId == 1)
            {
                img = dataSource.SchoolClass.DocumentLanguageId == 0 ? "head_paper_fr.png" : "head_paper_en.png";
                HeadSchoolNameENLabel.Visible = false;
                HeadSchoolTitleENLabel.Visible=false;
                StudentENLabel.Visible=false ;
                BornDateENLabel.Visible=false ;
                FatherENLabel.Visible = false;
                MotherENLabel.Visible=false ;
                ClassENLabel.Visible=false ;
                SchoolYearENLabel.Visible=false ;
                StudentIdENLabel.Visible=false ;
                ReportTitleENTextBox.Visible=false ;
                BornPlaceENLabel.Visible = false;
                ReportTitleFRTextBox.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "CERTIFICAT DE SCOLARITE" : "SCHOOL ATTENDANCE CERTIFICATE";
                HeadSchoolNameFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Je sousssigné(e)," : "I the undersigned,";
                HeadSchoolTitleFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Directeur Du Complexe Scolaire Bilingue," : "Director  Of Bilingual School Complexe,";

                SignaturePlaceLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Douala  le........" : "Douala  On........";
                SignatureHeadSchoolLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Le Directeur " : "The Director";
                AllocationNumberLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "N° de  l’allocataire ............. " : "Allocation owner’s  number .........";

                if (dataSource.Student.Sex == "M")
                {
                    StudentFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Certifie que le nommé " : "Certify that,";
                    BornDateFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Né le " : "Born on";
                    FatherFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Fils de " : "Son of";
                }
                else
                {
                    StudentFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Certifie que la nommée " : "Certify that,";
                    BornDateFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Née le " : "Born on";
                    FatherFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Fille de " : "Daughter of";
                }
                if (dataSource.SchoolYear.IsClosed)
                {
                    ClassFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "A été élève dans mon établissement en classe de " : "Has been our pupil and has attended";
                }
                else
                {
                    ClassFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Est élève dans mon établissement en classe de " : "Is our pupil and attending";
                }
                SchoolYearFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Pour le compte l'année scolaire" : "In the course of the academic year";
                StudentIdFRLabel.Value = dataSource.SchoolClass.DocumentLanguageId == 0 ? "Sous le matricule" : "Matricule";
                BornPlaceFRLabel.Value= dataSource.SchoolClass.DocumentLanguageId == 0 ? "A" : "In";
            }
            else
            {
                img = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "head_paper_fr.png" : "head_paper_en.png";
                ReportTitleFRTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "CERTIFICAT DE SCOLARITE" : "SCHOOL  ATTENDANCE CERTIFICATE";
                ReportTitleENTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(CERTIFICAT DE SCOLARITE)" : "(SCHOOL  ATTENDANCE CERTIFICATE)";
                HeadSchoolNameFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Je sousssigné(e),": "I the undersigned,";
                HeadSchoolNameENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Je sousssigné(e))" : "(I the undersigned)";
                HeadSchoolTitleFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Directeur Du Complexe Scolaire Bilingue,": "Director  Of Bilingual School Complexe";
                HeadSchoolTitleENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Directeur Du Complexe Scolaire Bilingue)": "(Director  Of Bilingual School Complexe)";
                BornPlaceFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "A" : "In";
                BornPlaceENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(A)" : "(In)";
                if (dataSource.Student.Sex == "M")
                {
                    StudentFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Certifie que le nommé " : "Certify that";
                    StudentENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Certifie que le nommé) " : "(Certify that)";
                    BornDateFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Né le " : "Born on";
                    BornDateENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Né le)" : "(Born on)";
                    FatherFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Fils de " : "Son of";
                    FatherENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Fils de) " : "(Son of)";
                }
                else
                {
                    StudentFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Certifie que la nommée " : "Certify that";
                    StudentENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Certifie que la nommée) " : "(Certify that)";
                    BornDateFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Née le " : "Born on";
                    BornDateENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Née le) " : "(Born on)";
                    FatherFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Fille de " : "Daughter of";
                    FatherENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Fille de) " : "(Daughter of)";
                }
                if (dataSource.SchoolYear.IsClosed)
                {
                    ClassFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "A été élève dans mon établissement en classe de " : "Has been our pupil and has attended";
                    ClassENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(A été élève dans mon établissement en classe de)" : "(Has been our pupil and has attended)";
                }
                else
                {
                    ClassFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Est élève dans mon établissement en classe de " : "Is our pupil and attending";
                    ClassENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Est élève dans mon établissement en classe de) " : "(Is our pupil and attending)";
                }
                SchoolYearFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Pour le compte l'année scolaire" : "In the course of the academic year";
                SchoolYearENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Pour le compte l'année scolaire)" : "(In the course of the academic year)";
                StudentIdFRLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Sous le matricule" : "Matricule";
                StudentIdENLabel.Value = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? "(Sous le matricule)" : "(Matricule)";

                SignaturePlaceLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Douala  le........" : "Douala  On........";
                SignatureHeadSchoolLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Le Directeur " : "The Director";
                AllocationNumberLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "N° de  l’allocataire ............. " : "Allocation owner’s  number .........";
            }
            this.StudentTextBox.Value = dataSource.Student.FullName.ToUpper();
            SchoolYearTextBox.Value = dataSource.SchoolYear.Name;
            ClassTextBox.Value = dataSource.ClassName.ToUpper();
            StudentIdTextBox.Value = dataSource.Student.IdNumber;
            BornDateTextBox.Value = dataSource.Student.BirthDate.ToShortDateString();
            BornPlaceTextBox.Value = dataSource.Student.BirthPlace.ToUpper();
            var father= dataSource.Student.ContactList.Where(e => e.Relationship == 0).FirstOrDefault();
            var mother = dataSource.Student.ContactList.Where(e => e.Relationship == 1).FirstOrDefault();
            var fatherName = father !=null? FatherTextBox.Value = father.Name : "";
            var motherName = mother != null ? MotherTextBox.Value = mother.Name : "";
            FatherTextBox.Value = fatherName.Length >= 30 ? fatherName.Substring(0, 30) + "..." : fatherName;
            MotherTextBox.Value = motherName.Length >= 30 ? motherName.Substring(0, 30) + "..." : motherName;

            FaceBookPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            FaceBookPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("facebook.png");
            WebSitePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("website.png");
            FacebookAddressLabel.Value = clientApp.Name;
            ContactLabel.Value = clientApp.Contact;
            AddressLabel.Value = clientApp.Address;
            WebSiteLabel.Value = clientApp.WebSite;

            //FaceBookPictureBox.Value = GetImage(Resources.facebook);
            //FaceBookPictureBox.Value = Image.FromStream(new MemoryStream(Resources.facebook),true);
            // WebSitePictureBox.Value = Image.FromStream(new MemoryStream(Resources.website),true);

        }


    }
}
