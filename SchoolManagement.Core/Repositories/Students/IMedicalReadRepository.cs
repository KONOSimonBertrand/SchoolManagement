using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IMedicalReadRepository
    {
        Task<MedicalRecord?> GetMedicalRecordAsync(int studentId, string description);
        Task<IList<MedicalRecord>> GetMedicalRecordListAsync(int studentId);
    }
}