

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    internal class SubjectGroupService : ISubjectGroupService
    {
        private readonly ISubjectGroupWriteRepository subjectGroupWriteRepository;
        private readonly ISubjectGroupReadRepository subjectGroupReadRepository;

        public SubjectGroupService(ISubjectGroupRepository subjectGroupRepository)
        {
            this.subjectGroupWriteRepository = subjectGroupRepository;
            this.subjectGroupReadRepository = subjectGroupRepository;
        }

        public async Task<bool> CreateSubjectGroup(SubjectGroup subjectGroup)
        {
            return  await subjectGroupWriteRepository.AddAsync(subjectGroup);
        }

        public async Task<SubjectGroup> GetSubjectGroup(string name)
        {
           return await  subjectGroupReadRepository.GetAsync(name);
        }

        public async Task<IList<SubjectGroup>> GetSubjectGroupList()
        {
            return await subjectGroupReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateSubjectGroup(SubjectGroup subjectGroup)
        {
            return await subjectGroupWriteRepository.UpdateAsync(subjectGroup);
        }
    }
}
