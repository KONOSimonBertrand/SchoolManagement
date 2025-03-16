using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Primary.SchoolApp.Services
{
    public interface IPrintService
    {
        public Task PrintPaymentReceiptAsync(StudentEnrolling enrolling, bool isCopy);
        public Task PrintPaymentReceiptAsync(TuitionPayment payment, bool isCopy);
        public Task PrintPaymentSummaryAsync(StudentEnrolling enrolling);
        public Task PrintPaymentReceiptAsync(Subscription subscription, bool isCopy);
        internal Task PrintSchoolCertificateAsync(StudentEnrollingDTO enrolling);
        internal Task PrintStudentBadgeAsync(StudentEnrollingDTO enrolling,string expirationDate);
        internal Task PrintClassBadgeAsync(IEnumerable<StudentEnrollingDTO> enrollingList, string expirationDate);
        internal Task PrintReportCardByStudentAsync(int studentId, int roomId, int evaluationId, int schoolYearId, int bookId);
        internal Task PrintReportCardByClassRoomAsync(int roomId, int evaluationId, int schoolYearId, int bookId);
        internal Task PrintClassRoomReportAsync(int roomId, int evaluationId, int schoolYearId, int bookId);
        internal Task PrintClassGroupReportAsync(int groupId, int evaluationId, int schoolYearId, int bookId);
        internal Task PrintDisciplinarySheetStudentReportAsync(int studentId, int roomId, int schoolYearId, int bookId);
        internal Task PrintDisciplinarySheetRoomReportAsync(int roomId, int schoolYearId, int bookId);
    }
}