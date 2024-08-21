

namespace SchoolManagement.Core.Model
{
   /// <summary>
   /// Cette classe représente:
   /// les notes administratives, disciplinaires, d'affectation, etc..
   /// </summary>
    public class EmployeeNote
    {
       public  int Id { get; set; }
        public string Title { get; set; }
        public int EnrollingId {  get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual EmployeeEnrolling Enrolling { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeNote other) return false;
            return (this.Id == other.Id );
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
