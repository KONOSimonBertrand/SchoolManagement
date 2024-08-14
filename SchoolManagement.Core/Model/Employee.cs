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
        public string? FullNameWithIdNumber
        {
            get { return IdNumber + "-" + FullName; }
        }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Email {  get; set; }
        public string? Address { get; set; }
        public string? IdCard { get; set; }
        public string? Religion { get; set; }
        public string? Sex { get; set; }
        public string? Nationality { get; set; }
        public DateTime HiringDate { get; set; }
        public string? PictureUrl { get; set; }
        public virtual User? User { get; set; }
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
