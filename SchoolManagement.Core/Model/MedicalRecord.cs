

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente une information médicale
    /// Exemple Enseignant
    /// </summary>
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string HealthSubject { get; set; }
        public string Description { get; set; }
        public int StudentId {  get; set; }
        public Student Student { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not MedicalRecord other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            var studentData = Student != null ? Student.FullName : "";
            return Date.ToShortDateString() + "-" + HealthSubject + "-" + studentData;
        }
    }
}
