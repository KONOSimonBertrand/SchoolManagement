

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IContactService
    {
        Task<bool> CreateContact(Contact contact);
        Task<bool> DeleteContact(int contactId);
        Task<bool> UpdateContact(Contact contact);
        Task<IList<Contact>> GetContactList(int studentId);
        Task<IList<Contact>> GetContactList();
        Task<Contact> GetContact(string contactName, string contactPhone);
    }
}
