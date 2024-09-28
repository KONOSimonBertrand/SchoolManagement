﻿using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface IContactWriteRepository
    {
        Task<bool> AddContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int contactId);
        Task<bool> UpdateContactAsync(Contact contact);
    }
}