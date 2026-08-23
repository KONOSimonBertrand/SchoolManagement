using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Primary.SchoolApp.Services
{
    public interface IPrintService
    {
        Task PrintPaymentReceiptAsync(StudentEnrolling enrolling, bool isCopy);
        Task PrintPaymentReceiptAsync(TuitionPayment payment, bool isCopy);
        Task PrintPaymentSummaryAsync(StudentEnrolling enrolling);
        Task PrintPaymentReceiptAsync(Subscription subscription, bool isCopy);
        Task PrintSchoolCertificateAsync(StudentEnrollingDTO enrolling);
        Task PrintStudentBadgeAsync(StudentEnrollingDTO enrolling, string expirationDate);
        Task PrintClassBadgeAsync(IEnumerable<StudentEnrollingDTO> enrollingList, string expirationDate);
        Task PrintPaymentReceiptAsync(DTOItem.PaymentReceipt paymentReceipt, bool isCopy);

    }
}