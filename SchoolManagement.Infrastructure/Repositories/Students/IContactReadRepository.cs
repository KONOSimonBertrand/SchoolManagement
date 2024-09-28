using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IContactReadRepository
    {
        Task<Contact> GetContactAsync(string contactName, string contactPhone);
        Task<IList<Contact>> GetContactListAsync(int studentId);
        Task<IList<Contact>> GetContactListAsync();
    }
}