using SchoolManagement.Core.Model;
using System.Data;


namespace Primary.SchoolApp.DTO
{
    public class ExamReport
    {
       
        public string ReportTitle { get; set; }
        public SchoolRoom Room {get;set; }
        
        public SchoolYear SchoolYear {  get; set; }
        public EvaluationSession EvaluationSession {  get; set; }   

        public string Language { get; set; }
        public DataTable DataReport { get; set; }
        public DataTable LabelReport { get; set; }
        public int TotalStudents { get; set; }
        public double TotalCofficients { get; set; }
    }
}
