

namespace SchoolManagement.Core.Model
{
    public class EvaluationSession
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? FrenchName { get; set; }
        public string? EnglishName { get; set; }
        public int Sequence { get; set; }
        public virtual string DefaultName { get => Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? EnglishName : FrenchName; }
        public override bool Equals(object? obj)
        {
            if (obj is not EvaluationSession other) return false;
            return (other.Id == this.Id || other.FrenchName == this.FrenchName);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return DefaultName ?? string.Empty;
        }
    }
}
