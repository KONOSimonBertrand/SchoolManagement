using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Primary.SchoolApp.Services
{
    public interface IPrintService
    {
        Task PrintPaymentSummaryAsync(StudentEnrolling enrolling);
        Task PrintSchoolCertificateAsync(StudentEnrollingDTO enrolling);
        Task PrintStudentBadgeAsync(StudentEnrollingDTO enrolling, string expirationDate);
        Task PrintClassBadgeAsync(IEnumerable<StudentEnrollingDTO> enrollingList, string expirationDate);
        Task PrintReceiptAsync(ReceiptDTO receipt, bool isCopy);

    }
}