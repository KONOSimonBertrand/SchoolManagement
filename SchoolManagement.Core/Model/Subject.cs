

namespace SchoolManagement.Core.Model
{
    public  class Subject
    {

        public int Id { get; set; }
        public string? FrenchName { get; set; }
        public string? EnglishName { get; set; }
        public int Sequence { get; set; }
        public virtual string FullName { get => FrenchName+"/"+EnglishName; }
        public virtual double Coefficient {  get; set; }
        public virtual double Coefficient2 { get; set; } //reservé pour les classes bilingues
        public virtual double NotedOn {  get; set; }
        public virtual double NotedOn2 { get; set; } //reservé pour les classes bilingues
        public virtual int GroupId { get; set; }
        public virtual SubjectGroup Group { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj is not Subject other) return false;
            return (other.Id == this.Id || other.FrenchName == this.FrenchName);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return FullName ?? string.Empty;
        }
    }
}
