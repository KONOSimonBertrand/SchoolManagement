

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente un classe 
    /// Exemple CM2
    /// </summary>
    public class SchoolClass
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public virtual SchoolGroup? Group { get; set; }
        public int BookTypeId { get; set; }
        public string BookTypeName
        {
            get
            {
                if (this.BookTypeId == 0) return "Français uniquement";
                if (this.BookTypeId == 1) return "Aglais uniquement";
                if (this.BookTypeId == 2) return "Français & Anglais";
                return "Inconnu";
            }
        }
        public int Sequence { get; set; }
        public virtual ICollection<SchoolRoom> Rooms { get; set; }
        public virtual ICollection<SchoolingCost> SchoolingCosts { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not SchoolClass other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override string ToString() => Name;
    }
}
