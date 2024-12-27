

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    internal class SubjectService:ISubjectService
    {
        private readonly ISubjectWriteRepository subjectWriteRepository;
        private readonly ISubjectReadRepository subjectReadRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this.subjectWriteRepository = subjectRepository;
            this.subjectReadRepository = subjectRepository;
        }

        public async Task<bool> CreateSubject(Subject subject)
        {
            return await subjectWriteRepository.AddAsync(subject);
        }

        public async Task<Subject> GetSubject(string name)
        {
            return await subjectReadRepository.GetAsync(name);
        }

        public async Task<IList<Subject>> GetSubjectList()
        {
            return await subjectReadRepository.GetListAsync();
        }

        public async Task<bool> UpdateSubject(Subject subject)
        {
            return await subjectWriteRepository.UpdateAsync(subject);
        }
    }
}
