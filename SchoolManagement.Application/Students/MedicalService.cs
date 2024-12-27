using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
   
    public class MedicalService : IMedicalService
    {
        private readonly IMedicalWriteRepository medicalWriteRepository;
        private readonly IMedicalReadRepository medicalReadRepository;
        public MedicalService(IMedicalRepository medicalRepository)
        {
            medicalWriteRepository = medicalRepository;
            medicalReadRepository = medicalRepository;
        }

        public async Task<bool> CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            return await medicalWriteRepository.AddMedicalRecordAsync(medicalRecord);
        }

        public async Task<bool> DeleteMedicalRecord(int medicalRecordId)
        {
            return await medicalWriteRepository.DeleteMedicalRecordAsync(medicalRecordId);
        }

        public  async Task<MedicalRecord> GetMedicalRecord(int studentId, string description)
        {
            return await medicalReadRepository.GetMedicalRecordAsync(studentId,description);
        }

        public async Task<IList<MedicalRecord>> GetMedicalRecordList(int studentId)
        {
            return await medicalReadRepository.GetMedicalRecordListAsync(studentId);
        }

        public async Task<bool> UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            return await medicalWriteRepository.UpdateMedicalRecordAsync(medicalRecord);
        }
    }
}
