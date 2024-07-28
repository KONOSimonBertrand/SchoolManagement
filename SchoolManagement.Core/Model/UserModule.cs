
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

    }
}
