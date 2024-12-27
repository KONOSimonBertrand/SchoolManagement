



namespace SchoolManagement.Core.Model
{
    public class ClassSubject
    {
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int BookId { get; set; } //0=section normal; si classe bilingue 0=section francophone 1= section anglophone
        public int GroupId { get; set; }
        public double Coefficient { get; set; }
        public double NotedOn { get; set; }
        public int Sequence { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SchoolClass Class { get; set; }
        public virtual SubjectGroup Group { get; set; }
        public virtual string  BookName{
            get
            {
                if (Class != null) {
                    if (Class.DocumentLanguageId == 0 || Class.DocumentLanguageId == 1) return string.Empty;
                    else
                    {
                        if(BookId==0) return "Francophone";
                        else return "Anglophone";
                    }
                }
                return string.Empty;
            }

}
        public override bool Equals(object? obj)
        {
            if (obj is not ClassSubject other) return false;
            return (this.ClassId == other.ClassId && this.SubjectId== other.SubjectId);
        }
        public override int GetHashCode()
        {
            return (this.ClassId*this.SubjectId).GetHashCode(); ;
        }
    }
}
