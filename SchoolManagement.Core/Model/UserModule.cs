
namespace SchoolManagement.Core.Model
{
    public class UserModule
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ModuleId {get; set; }
        public virtual Module Module { get; set; }
    }
}
