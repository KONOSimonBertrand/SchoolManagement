

namespace SchoolManagement.Core.Model
{
    public class SubjectGroup
    {
        public int Id { get; set; }
        public string? FrenchName { get; set; }
        public string? EnglishName { get; set; }
        public int Sequence {  get; set; }
            
        public override bool Equals(object? obj)
        {
            if(obj is not SubjectGroup other) return false;
            return (other.Id == this.Id || other.FrenchName == this.FrenchName);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return Thread.CurrentThread.CurrentUICulture.Name == "en-GB"?EnglishName:FrenchName;
        }
    }
}
