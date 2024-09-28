

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe représente une l'inscription d'un élève
    /// </summary>
    public class StudentEnrolling
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int SchoolYearId { get; set; }
        public int ClassId { get; set; }
        public string OldSchool { get; set; }
        public bool IsRepeater {  get; set; }
        public string DoneBy {  get; set; }
        public bool IsActive {  get; set; }
        public string ReasonLeft { get; set; }
        public string? PictureUrl { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual Student Student { get; set; }
        public virtual IList<TuitionPayment> PaymentList { get; set; }=new List<TuitionPayment>();
        public virtual IList<TuitionDiscount> DiscountList { get; set; } =new List<TuitionDiscount>();
        public virtual IList<Subscription> SubscriptionList { get; set; }=new List<Subscription>();
        public virtual IList<Discipline> DisciplineList { get; set; }=new List<Discipline>();
            
        public override bool Equals(object? obj)
        {
            if (obj is not StudentEnrolling other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }

    }
}
