

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.Subjects
{
    public interface ISubjectService
    {
        public Task<bool> CreateSubject(Subject subject);
        public Task<bool> UpdateSubject(Subject subject);
        public Task<Subject> GetSubject(string name);
        public Task<IList<Subject>> GetSubjectList();
    }
}
