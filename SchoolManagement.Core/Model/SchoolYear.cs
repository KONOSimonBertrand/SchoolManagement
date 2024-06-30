namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Une classe pour les années scolaires
    /// Exemple 2021-2022
    /// </summary>
    public class SchoolYear 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartFirstQuarter { get; set; }
        public DateTime? EndFirstQuarter { get; set; }
        public DateTime? StartSecondQuarter { get; set; }
        public DateTime? EndSecondQuarter { get; set; }
        public DateTime? StartThirdQuarter { get; set; }
        public DateTime? EndThirdQuarter { get; set; }
        public bool IsClosed { get; set; }
        public  string State
        {
            get
            {
                return IsClosed ? "Clôturée" : "Ouverte";              
            }
        }
        
        public override int GetHashCode()
        {
            base.GetHashCode();
            return  this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name??"";
        }

        public override bool Equals(object? obj)
        {
            var other = obj as SchoolYear;
            if (other == null) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
    }
}

