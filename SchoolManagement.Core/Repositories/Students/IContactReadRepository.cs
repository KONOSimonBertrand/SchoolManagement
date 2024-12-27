using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IContactReadRepository
    {
        Task<Contact> GetContactAsync(string contactName, string contactPhone);
        Task<IList<Contact>> GetContactListAsync(int studentId);
        Task<IList<Contact>> GetContactListAsync();
    }
}