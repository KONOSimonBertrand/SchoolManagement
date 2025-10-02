using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ISchoolSupplieFeeService
    {
        public Task<bool> CreateSchoolSupplieFee(SchoolSupplieFee schoolSupplieFee);
        public Task<bool> UpdateSchoolSupplieFee(SchoolSupplieFee schoolSupplieFee);
        public Task<SchoolSupplieFee> GetSchoolSupplieFee(int schoolClassId,int cashFlowTypeId, int schoolYearId);
        public Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList(List<int>classIdlist, int cashFlowTypeId, int schoolYearId);
        public Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList();
        public Task<IList<SchoolSupplieFee>> GetSchoolSupplieFeeList(int schoolYearId);
    }
}