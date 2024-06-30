using System.Reflection;

namespace SchoolManagement.Core.Model
{/// <summary>
 /// Une classe represente des utilisateur
 /// Exemple root
 /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public IEnumerable<Module> Modules { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj is not User other)
                return false;
                return other.Id==this.Id||other.Username==this.Username;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name??"";
        }
    }
}
