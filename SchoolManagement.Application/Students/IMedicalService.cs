

using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface IMedicalService
    {

        Task<bool> CreateMedicalRecord(MedicalRecord medicalRecord);
        Task<bool> DeleteMedicalRecord(int medicalRecordId);
        Task<bool> UpdateMedicalRecord(MedicalRecord medicalRecord);
        Task<IList<MedicalRecord>> GetMedicalRecordList(int studentId);
        Task<MedicalRecord> GetMedicalRecord(int studentId, string description);
    }
}
