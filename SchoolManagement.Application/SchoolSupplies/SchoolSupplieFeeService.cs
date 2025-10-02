

using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application
{
    public class SchoolSupplieFeeService : ISchoolSupplieFeeService
    {
        private readonly ISchoolSupplieFeeWriteRepository schoolSupplieFeeWriteRepository;
        private readonly ISchoolSupplieFeeReadRepository schoolSupplieFeeReadRepository;
        public SchoolSupplieFeeService(ISchoolSupplieFeeRepository schoolSupplieFeesRepository)
        {
            this.schoolSupplieFeeWriteRepository = schoolSupplieFeesRepository;
            this.schoolSupplieFeeReadRepository = schoolSupplieFeesRepository;
        }
        public async Task<bool> CreateSchoolSupplieFee(SchoolSupplieFee schoolSupplieFee)
        {
            return await schoolSupplieFeeWriteRepository.AddAsync(schoolSupplieFee);
        }

        public async Task<SchoolSupplieFee> GetSchoolSupplieFee(int schoolClassId, int cashFlowTypeId, int schoolYearId)
        {
            return await schoolSupplieFeeReadRepository.GetAsync(schoolClassId, cashFlowTypeId, schoolYearId);
        }

        public async Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList()
        {
            return await schoolSupplieFeeReadRepository.GetListAsync();
        }

        public async Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList(int schoolYearId)
        {
            return await schoolSupplieFeeReadRepository.GetListAsync(schoolYearId);
        }

        public async Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList(List<int> classIdList, int cashFlowTypeId, int schoolYearId)
        {
            return await schoolSupplieFeeReadRepository.GetListAsync(classIdList, cashFlowTypeId, schoolYearId);
        }

        public async Task<bool> UpdateSchoolSupplieFee(SchoolSupplieFee schoolSupplieFee)
        {
           return await schoolSupplieFeeWriteRepository.UpdateAsync(schoolSupplieFee);
        }
    }
}
