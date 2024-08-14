using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SchoolManagement.Core.Model
{/// <summary>
 /// Une classe represente des utilisateur
 /// Exemple root
 /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<UserModule> Modules { get; set; }=new List<UserModule>(); 
        public virtual ICollection<UserRoom> Rooms { get; set; } =new List<UserRoom>();
        public override bool Equals(object obj)
        {
            if (obj is not User other)
                return false;
                return other.Id==this.Id||other.UserName==this.UserName;
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
