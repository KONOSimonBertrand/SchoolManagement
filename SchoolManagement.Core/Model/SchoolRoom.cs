
namespace SchoolManagement.Core.Model
{/// <summary>
 /// Cette classe représente un classe 
 /// Exemple CM2 A
 /// </summary>
    public class SchoolRoom
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ClassId { get; set; }

        public SchoolClass SchoolClass { get; set; }

        public int Sequence {  get; set; }  

        public override bool Equals(object? obj)
        {
            if (obj is not SchoolRoom other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override string ToString() => Name;
    }


}
