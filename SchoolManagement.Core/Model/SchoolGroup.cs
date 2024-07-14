

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un groupe de classe
    /// Exemple Section anglophone, section francophone
    /// </summary>
    public class SchoolGroup
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        public int Sequence { get; set; }
        public virtual ICollection<SchoolClass> Classes { get; set; }
        public override bool Equals(object? obj)
        {
            if(obj is not SchoolGroup other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
