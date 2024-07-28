


namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente un sysème de notation
    /// Exemple A+, B..
    /// </summary>
    public class RatingSystem
    {
        public int Id { get; set; }
        public string? FrenchName { get; set; }
        public string? EnglishName { get; set; }
        public string? FrenchDescription { get; set; }
        public string? EnglishDescription { get; set; }
        public double MinNote {  get; set; }
        public double MaxNote { get; set; }
        public string? Domain {  get; set; }
        public string DefaultName {
            get {
                return FrenchName + "/" + EnglishName;
            }
        }
        public string DefaultDescription
        {
            get
            {
                return FrenchDescription + "/" + EnglishDescription;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is not RatingSystem other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override string ToString() => DefaultName;
    }
}

