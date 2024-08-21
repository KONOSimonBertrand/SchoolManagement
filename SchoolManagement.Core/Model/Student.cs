



namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un élève
    /// Exemple KONO Simon Bertrand
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string FullName
        {
            get { return LastName.Trim() + " " + FirstName.Trim(); }
        }
        public virtual string FullNameWithIdNumber
        {
            get
            {
                return FullName + " #" + IdNumber;
            }
        }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string? IdCard { get; set; }
        public string Religion { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Health {  get; set; }
        public string? PictureUrl { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not Student other) return false;
            return (this.Id == other.Id || this.IdNumber == other.IdNumber);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}
