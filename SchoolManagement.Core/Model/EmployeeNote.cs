

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
        public int EmployeeId {  get; set; }
        public int SchoolYearId {  get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
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
