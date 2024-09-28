using SchoolManagement.Core.Model;
using System.Threading.Tasks;

namespace Primary.SchoolApp.Services
{
    public interface IPrintService
    {
        public Task PrintPaymentReceipt(StudentEnrolling enrolling, bool isCopy);
        public Task PrintPaymentReceipt(TuitionPayment payment, bool isCopy);
        public Task PrintPaymentSummary(StudentEnrolling enrolling);
        public Task PrintPaymentReceipt(Subscription subscription, bool isCopy);
    }
}