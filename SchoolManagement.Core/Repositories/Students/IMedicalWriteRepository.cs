using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface IMedicalWriteRepository
    {
        Task<bool> AddMedicalRecordAsync(MedicalRecord medicalRecord);
        Task<bool> DeleteMedicalRecordAsync(int medicalRecordId);
        Task<bool> UpdateMedicalRecordAsync(MedicalRecord medicalRecord);
    }
}