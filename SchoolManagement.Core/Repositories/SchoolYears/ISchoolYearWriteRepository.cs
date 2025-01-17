﻿using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public  interface ISchoolYearWriteRepository
    {
        public Task<bool> AddSchoolYearAsync(SchoolYear schoolYear);
        public Task<bool> UpdateSchoolYearAsync(SchoolYear schoolYear);
        public Task<bool> ChangeSchoolYearStatusAsync(SchoolYear schoolYear); //close or open
    }
}
