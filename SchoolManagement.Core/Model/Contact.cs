
namespace SchoolManagement.Core.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string IdCard { get; set; }
        public string Job { get; set; }
        public int Relationship {  get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not Contact other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
