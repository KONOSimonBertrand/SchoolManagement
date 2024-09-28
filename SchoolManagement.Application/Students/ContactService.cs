

using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public  class ContactService : IContactService
    {
        private readonly IContactWriteRepository contactWriteRepository;
        private readonly IContactReadRepository contactReadRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactWriteRepository = contactRepository;
            this.contactReadRepository = contactRepository;
        }

        public async Task<bool> CreateContact(Contact contact)
        {
            return  await contactWriteRepository.AddContactAsync(contact);
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            return await contactWriteRepository.DeleteContactAsync(contactId);
        }

        public async Task<Contact> GetContact(string contactName, string contactPhone)
        {
            return await contactReadRepository.GetContactAsync(contactName, contactPhone);
        }

        public async Task<IList<Contact>> GetContactList(int studentId)
        {
            return await contactReadRepository.GetContactListAsync(studentId);
        }

        public async Task<IList<Contact>> GetContactList()
        {
            return await contactReadRepository.GetContactListAsync();
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            return await contactWriteRepository.UpdateContactAsync(contact);
        }
    }
}
