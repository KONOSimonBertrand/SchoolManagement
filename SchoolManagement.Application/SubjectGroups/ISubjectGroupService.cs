

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application.SubjectGroups
{
    public interface ISubjectGroupService
    {
        public Task<bool> CreateSubjectGroup(SubjectGroup subjectGroup);
        public Task<bool> UpdateSubjectGroup(SubjectGroup subjectGroup);
        public Task<SubjectGroup> GetSubjectGroup(string name);
        public Task<IList<SubjectGroup>> GetSubjectGroupList();
    }
}
