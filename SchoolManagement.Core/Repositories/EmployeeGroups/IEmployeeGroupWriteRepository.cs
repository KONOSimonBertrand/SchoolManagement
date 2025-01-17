﻿using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IEmployeeGroupWriteRepository
    {
        public Task<bool> AddAsync(EmployeeGroup group);
        public Task<bool> UpdateAsync(EmployeeGroup group);
    }
}