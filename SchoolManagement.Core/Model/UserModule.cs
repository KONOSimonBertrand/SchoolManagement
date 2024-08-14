
namespace SchoolManagement.Core.Model
{
    public class UserModule
    {
        public int UserId { get; set; }
        public int ModuleId {get; set; }
        public bool? IsDefault { get; set; }
        public bool? AllowCreate { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool? AllowDelete { get; set; }
        public bool? AllowRead { get; set; }
        public bool? AllowPrint { get; set; }
        public bool? AllowMail { get; set; }
        public virtual User? User { get; set; }
        public virtual Module? Module { get; set; }
        public virtual bool HasOneChecked
        {
            get
            {
                if(AllowRead==true) return true;
                if (AllowCreate == true) return true;
                if (AllowUpdate == true) return true;
                if (AllowDelete == true) return true;
                if (AllowPrint== true) return true;
                if (AllowMail==true) return true;
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not UserModule other) return false;
            return (this.UserId == other.UserId && this.ModuleId== other.ModuleId);
        }
        public override int GetHashCode()
        {
            return (this.UserId*this.ModuleId).GetHashCode();
        }
    }
}
