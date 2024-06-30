namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un employé
    /// Exemple KONO Simon Bertrand
    /// </summary>
    public class Employee 
    {
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName
        {
            get { return LastName + " " + FirstName; }
        }
        public int JobId { get; set; }
        public Job Job { get; set; }
        
        public override bool Equals(object? obj)
        {
            if (obj is not Employee other) return false;
            return (this.Id == other.Id || this.IdNumber == other.IdNumber);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return IdNumber + "-" + FullName;
        }
    }

}
