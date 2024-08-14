

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Une classe represente les modules
    /// Exemple Gestion des inscriptions
    /// </summary>
    public class Module
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MenuGroup{ get; set; }
        public virtual ICollection<UserModule> Modules { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not Module other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
