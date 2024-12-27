

using SchoolManagement.Core.Model;

namespace Primary.SchoolApp.DTO
{
    internal class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string IdCard { get; set; }
        public string Job { get; set; }
        public int Relationship { get; set; }
        public string RelationshipName { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
