using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Primary.SchoolApp.Reporting
{
    internal class BadgeReport : SchoolManagement.UI.Reporting.BadgeReport
    {
        public BadgeReport(StudentEnrollingDTO dataSource, string expirationDate, ClientApp clientApp)
        {

            DataSource = dataSource;
            ExpirationDateTextBox.Value = expirationDate;
            StudentLastNameTextBox.Value = dataSource.Student.LastName;
            StudentFirstNameTextBox.Value = dataSource.Student.FirstName;
            StudentBirthDayFRLabel.Value = "=IIF(Fields.Student.Sex='M', 'Né le','Née le')";
            StudentBirthDayTextBox.Value = dataSource.Student.BirthDate.ToString("dd-MM-yyyy");
            StudentClassTextBox.Value = dataSource.SchoolClass.Name;
            StudentMatriculeTextBox.Value = dataSource.Student.IdNumber;
            StudentClassTextBox.Value = dataSource.ClassName;
            IdCardBarcode.Value = "=Fields.Student.FullName+\" \r\nMatricule:\"+Fields.Student.IdNumber+\"\r\nClasse:\"+Fields.SchoolClass.Name";
            var urlDefault = $"\"{clientApp.StudentPitureFolder}\\\"+Fields.Student.IdNumber+\".jpg\"";
            StudentPictureBox.Value = $"=IFS(Fields.PictureUrl IS NOT null,Fields.PictureUrl,Fields.Student.PictureUrl IS NOT null,Fields.Student.PictureUrl,{urlDefault})";
            SchoolNameTextBox.Value=clientApp.Name;
            SchoolContactTextBox.Value=clientApp.Contact;
            BadgePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("badge_panel.png");
            LogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
            SignaturePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("badge_signature.png");

        }
        public BadgeReport(IEnumerable<StudentEnrollingDTO> dataSource, string expirationDate, ClientApp clientApp)
        {

            ExpirationDateTextBox.Value = expirationDate;
            StudentLastNameTextBox.Value = "=Fields.Student.LastName";
            StudentFirstNameTextBox.Value = "=Fields.Student.FirstName";
            StudentBirthDayFRLabel.Value = "=IIF(Fields.Student.Sex='M', 'Né le','Née le')";
            StudentBirthDayTextBox.Value = "=Student.BirthDate.ToString('dd-MM-yyyy')";
            StudentClassTextBox.Value = "=SchoolClass.Name";
            StudentMatriculeTextBox.Value ="=Student.IdNumber";
            StudentClassTextBox.Value = "=ClassName";
            IdCardBarcode.Value = "=Fields.Student.FullName+\" \r\nMatricule:\"+Fields.Student.IdNumber+\"\r\nClasse:\"+Fields.SchoolClass.Name";
            var urlDefault = $"\"{clientApp.StudentPitureFolder}\\\"+Fields.Student.IdNumber+\".jpg\"";
            StudentPictureBox.Value = $"=IFS(Fields.PictureUrl IS NOT null,Fields.PictureUrl,Fields.Student.PictureUrl IS NOT null,Fields.Student.PictureUrl,{urlDefault})";
            SchoolNameTextBox.Value = clientApp.Name;
            SchoolContactTextBox.Value = clientApp.Contact;
            BadgePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("badge_panel.png");
            LogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
            SignaturePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("badge_signature.png");

            this.DataSource = dataSource;
            
        }

        private Image getPicture(string firstUrl, string secondUrl,string thirdUrl, ClientApp clientApp) { 
        Image picture = null;
            if (File.Exists(firstUrl))
            {

                picture = new Bitmap(Image.FromFile(firstUrl));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(secondUrl))
                {
                    picture = new Bitmap(Image.FromFile(secondUrl));
                }
                else
                {
                    
                    if (File.Exists(thirdUrl))
                    {
                        picture = new Bitmap(Image.FromFile(thirdUrl));
                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.badge_photo);
                        picture = Image.FromStream(ms);
                    }
                }

            }
            return picture;
        }
    }
}
