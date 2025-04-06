

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
        public int DocumentLanguageId { get; set; } //type de document
        public string DocumentLanguage
        {
            get
            {
                if (this.DocumentLanguageId == 0) return Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Français uniquement" : "French only";
                if (this.DocumentLanguageId == 1) return Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Anglais uniquement" : "English only";
                if (this.DocumentLanguageId == 2) return Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Français & Anglais" : "French & English";
                return string.Empty;
            }
        }
        public bool NoteIsTruncate { get; set; }
        public int AverageFormula { get; set; }

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
            return Name ?? "";
        }
    }
}
