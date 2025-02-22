

namespace SchoolManagement.Core.Model
{
    public class School
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Motto { get; set; } // slogan
        public string? Phone {  get; set; }
        public string? Address { get; set; }
        public string? PostBox { get; set; }
        public string? City { get; set; }
        public string? WebSite { get; set; }
        public string? FaceBook {  get; set; }
        public string? Email {  get; set; }
        public int EvaluationModel {  get; set; }
        public int HeadMasterType{ get; set; }  // Directeur=0,Proviseur=1,Principal=2
        public string? HeadMasterName{ get; set; }
        public string? HeadMasterSex { get; set; }
        public string ? StudentPictureDirectory {  get; set; }
        public string? EmployeePictureDirectory { get; set; }
        public string? Code { get; set; }
        public string? SerialKey { get; set; } //licence
    }
}
