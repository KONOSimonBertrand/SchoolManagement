

using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using Telerik.Reporting.Drawing;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class PaymentReceiptA4Report : SchoolManagement.UI.Reporting.PaymentReceiptA4Report
    {
        public PaymentReceiptA4Report() {
            InitComponents();
        }
        public PaymentReceiptA4Report(PaymentReceiptData receiptData)
        {
            InitComponents();
            if (receiptData.Enrolling != null)
            {
                CopyLabel.Visible = receiptData.IsCopy;
                Copy2Label.Visible = receiptData.IsCopy;
                InitVisiblity(receiptData.SchoolGroup.DocumentLanguageId);
                
                PaymentIdNumberTextBox.Value = "#" + receiptData.Enrolling.Id;
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = receiptData.Enrolling.Date.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = receiptData.Enrolling.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = receiptData.Enrolling.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = receiptData.Enrolling.SchoolClass.Name;
                StudentClass2TextBox.Value = receiptData.Enrolling.SchoolClass.Name;
                SchoolYearTextBox.Value = receiptData.Enrolling.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = receiptData.Enrolling.PaymentList.Sum(a => a.Amount).ToString() + " CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                var lFR = "(" + receiptData.Enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                var lEN = "(" + receiptData.Enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                if (receiptData.SchoolGroup.DocumentLanguageId==0)
                {
                    PaymentAmountLeterTextBox.Value = lFR;
                }
                else
                {
                    if (receiptData.SchoolGroup.DocumentLanguageId == 1)
                    {
                        PaymentAmountLeterTextBox.Value = lEN;
                    }
                    else
                    {
                        PaymentAmountLeterTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? lFR.Replace(")", "") + "/"+lEN.Replace("(", "") : lEN.Replace(")", "") + "/"+lFR.Replace("(", "");
                    }
                }
               
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = receiptData.Enrolling.PaymentList.Sum(a => a.Balance).ToString() + " CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                if (receiptData.Enrolling.PaymentList.Count != 0)
                {
                    if (receiptData.Enrolling.PaymentList.Count > 1)
                    {
                        var meanList = receiptData.Enrolling.PaymentList.Select(x => x.PaymentMean).Distinct().ToList();
                        var reasonList = receiptData.Enrolling.PaymentList.Select(x => x.CashFlowType).Distinct().ToList();
                        int i = 1;
                        int j = 1;
                        foreach (var reason in reasonList)
                        {
                            if (i != reasonList.Count)
                            {
                                PaymentReasonTextBox.Value += reason.Name + ", ";
                            }
                            else
                            {
                                PaymentReasonTextBox.Value += reason.Name;
                            }
                            i++;
                        }
                        foreach (var mean in meanList)
                        {
                            if (j != meanList.Count)
                            {
                                PaymentMeanTextBox.Value += mean.FullName + ", ";
                            }
                            else
                            {
                                PaymentMeanTextBox.Value += mean.FullName;
                            }
                            j++;
                        }
                    }
                    else
                    {
                        PaymentReasonTextBox.Value = receiptData.Enrolling.PaymentList.FirstOrDefault().CashFlowType.Name;
                        PaymentMeanTextBox.Value = receiptData.Enrolling.PaymentList.FirstOrDefault().PaymentMean.FullName;
                        PaymentsTable.Visible = false;
                        Payments2Table.Visible = false;
                    }
                }
                else
                {
                    PaymentReasonTextBox.Value = string.Empty;
                    PaymentMeanTextBox.Value = string.Empty;
                }
                PaymentMean2TextBox.Value = PaymentMeanTextBox.Value;
                PaymentReason2TextBox.Value = PaymentReasonTextBox.Value;

                PaymentsTable.DataSource = receiptData.Enrolling.PaymentList;
                Payments2Table.DataSource = receiptData.Enrolling.PaymentList;
                PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();
                PrintDate2TextBox.Value = PrintDateTextBox.Value;
                FirstCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(0.5D));
                SecondCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(6D));
                if (receiptData.Enrolling.PaymentList.Count > 1)
                {
                    SignatureDoneByPanel.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    SignatureSchoolPanel.Location = new PointU(Unit.Inch(4.8D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    SignatureDoneBy2Panel.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    SignatureSchool2Panel.Location = new PointU(Unit.Inch(4.8D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);

                    WebSiteTextBox.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    WebSite2TextBox.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    AdressTextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    Adress2TextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);

                    PhoneTextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    Phone2TextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    PrintDateTextBox.Location = new PointU(Unit.Inch(6.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                    PrintDate2TextBox.Location = new PointU(Unit.Inch(6.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * receiptData.Enrolling.PaymentList.Count);
                }
                FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SchoolNameTextBox.Value = Program.CurrentSchool.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = Program.CurrentSchool.Phone;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = Program.CurrentSchool.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
                Logo2PictureBox.Value = LogoPictureBox.Value;

            }

        }
        public PaymentReceiptA4Report(TuitionReceiptData receiptData)
        {
            InitComponents();
            if (receiptData.TuitionPayment != null)
            {
                CopyLabel.Visible = receiptData.IsCopy;
                Copy2Label.Visible = receiptData.IsCopy;
                PaymentsTableAmountLabel.Value = Language.labelAmount.ToUpper();
                PaymentsTableAmount2Label.Value = PaymentsTableAmountLabel.Value;
                PaymentsTableReasonLabel.Value = Language.labelReason.ToUpper();
                PaymentsTableReason2Label.Value = PaymentsTableReasonLabel.Value;
                PaymentsTablePaymentPlaceLabel.Value = Language.labelPaymentMean.ToUpper();
                PaymentsTablePaymentPlace2Label.Value = PaymentsTablePaymentPlaceLabel.Value;
                PaymentsTableBalanceLabel.Value = Language.labelUnPaid.ToUpper();
                PaymentsTableBalance2Label.Value = PaymentsTableBalanceLabel.Value;
                PaymentIdNumberTextBox.Value = receiptData.TuitionPayment.IdNumber;
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = receiptData.TuitionPayment.Date.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = receiptData.TuitionPayment.Enrolling.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = receiptData.TuitionPayment.Enrolling.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = receiptData.TuitionPayment.Enrolling.SchoolClass.Name;
                StudentClass2TextBox.Value = receiptData.TuitionPayment.Enrolling.SchoolClass.Name;
                SchoolYearTextBox.Value = receiptData.TuitionPayment.Enrolling.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = receiptData.TuitionPayment.Amount.ToString() + " F CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    PaymentAmountLeterTextBox.Value = "(" + receiptData.TuitionPayment.Amount.ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                }
                else
                {
                    PaymentAmountLeterTextBox.Value = "(" + receiptData.TuitionPayment.Amount.ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                }
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = receiptData.TuitionPayment.Balance.ToString() + " F CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                PaymentReasonTextBox.Value = receiptData.TuitionPayment.CashFlowType.Name;
                PaymentMeanTextBox.Value=receiptData.TuitionPayment.PaymentMean.FullName;
                PaymentMean2TextBox.Value = PaymentMeanTextBox.Value;
                PaymentReason2TextBox.Value = PaymentReasonTextBox.Value;
                PaymentsTable.Visible=false;
                Payments2Table.Visible = false;
                PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();
                PrintDate2TextBox.Value = PrintDateTextBox.Value;
                FirstCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(0.5D));
                SecondCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(6D));                
                FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SchoolNameTextBox.Value = Program.CurrentSchool.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = Program.CurrentSchool.Phone;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = Program.CurrentSchool.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
                Logo2PictureBox.Value = LogoPictureBox.Value;

            }

        }
        public PaymentReceiptA4Report(SubscriptionReceiptData receiptData)
        {
            InitComponents();
            if (receiptData.Subscription != null)
            {
                var studentRoom=Program.StudentRoomList.FirstOrDefault(x => x.StudentId==receiptData.Subscription.StudentId && x.SchoolYearId== receiptData.Subscription.SchoolYearId);
                var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == studentRoom.RoomId);
                var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
                CopyLabel.Visible = receiptData.IsCopy;
                Copy2Label.Visible = receiptData.IsCopy;
                PaymentsTableAmountLabel.Value = Language.labelAmount.ToUpper();
                PaymentsTableAmount2Label.Value = PaymentsTableAmountLabel.Value;
                PaymentsTableReasonLabel.Value = Language.labelReason.ToUpper();
                PaymentsTableReason2Label.Value = PaymentsTableReasonLabel.Value;
                PaymentsTablePaymentPlaceLabel.Value = Language.labelPaymentMean.ToUpper();
                PaymentsTablePaymentPlace2Label.Value = PaymentsTablePaymentPlaceLabel.Value;
                PaymentsTableBalanceLabel.Value = Language.labelUnPaid.ToUpper();
                PaymentsTableBalance2Label.Value = PaymentsTableBalanceLabel.Value;
                PaymentIdNumberTextBox.Value = $"# {receiptData.Subscription.IdNumber}";
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = receiptData.Subscription.StartDate.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = receiptData.Subscription.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = receiptData.Subscription.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = classOfRoom.Name;
                StudentClass2TextBox.Value = StudentClassTextBox.Value;
                SchoolYearTextBox.Value = receiptData.Subscription.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = receiptData.Subscription.Amount.ToString() + " F CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    PaymentAmountLeterTextBox.Value = "(" + receiptData.Subscription.Amount.ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                }
                else
                {
                    PaymentAmountLeterTextBox.Value = "(" + receiptData.Subscription.Amount.ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                }
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = "0 F CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                PaymentReasonTextBox.Value = receiptData.Subscription.CashFlowType.Name;
                PaymentReason2TextBox.Value = PaymentReasonTextBox.Value;
                PaymentMeanTextBox.Value = receiptData.Subscription.PaymentMean.FullName;
                PaymentMean2TextBox.Value = PaymentMeanTextBox.Value;
                PaymentsTable.Visible = false;
                Payments2Table.Visible = false;
                PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();
                PrintDate2TextBox.Value = PrintDateTextBox.Value;
                FirstCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(0.5D));
                SecondCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(6D));
                FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SchoolNameTextBox.Value = Program.CurrentSchool.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = Program.CurrentSchool.Phone;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = Program.CurrentSchool.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("logo.png");
                Logo2PictureBox.Value = LogoPictureBox.Value;

            }

        }
        private void InitComponents()
        {
            PaymentIdNumberTextBox.Value = string.Empty;
            PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
            PaymentDateTextBox.Value = string.Empty;
            PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
            StudentTextBox.Value = string.Empty;
            Student2TextBox.Value = StudentTextBox.Value;
            StudentIdNumberTextBox.Value = string.Empty;
            StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
            StudentClassTextBox.Value = string.Empty;
            StudentClass2TextBox.Value = StudentClassTextBox.Value;
            SchoolYearTextBox.Value = string.Empty; ;
            SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
            PaymentAmountTextBox.Value = string.Empty; ;
            PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
            PaymentAmountLeterTextBox.Value = string.Empty;
            PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
            PaymentBalanceTextBox.Value = string.Empty;
            PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
            PaymentReasonTextBox.Value = string.Empty;
            PaymentMeanTextBox.Value = string.Empty;
            PaymentMean2TextBox.Value = PaymentMeanTextBox.Value;
            PaymentReason2TextBox.Value = PaymentReasonTextBox.Value;

            SchoolNameTextBox.Value = string.Empty;
            SchoolName2TextBox.Value = SchoolNameTextBox.Value;
            WebSiteTextBox.Value = string.Empty;
            WebSite2TextBox.Value = WebSiteTextBox.Value;
            PhoneTextBox.Value = string.Empty;
            Phone2TextBox.Value = PhoneTextBox.Value;
            AdressTextBox.Value = string.Empty;
            Adress2TextBox.Value = AdressTextBox.Value;
            LogoPictureBox.Value = string.Empty;
            Logo2PictureBox.Value = LogoPictureBox.Value;
        }
       private void InitVisiblity(int documentTemplateId)
        {
            if(documentTemplateId==0 || documentTemplateId == 1)
            {

                StudentLabelEN.Visible = false;
                Student2LabelEN.Visible = false;
                StudentClassLabelEN.Visible = false;
                StudentClass2LabelEN.Visible = false;
                PaymentAmountLabelEN.Visible = false;
                PaymentAmount2LabelEN.Visible = false;
                PaymentReasonLabelEN.Visible = false;
                PaymentReason2LabelEN.Visible = false;
                PaymentPlace2LabelEN.Visible = false;
                PaymentPlaceLabelEN.Visible = false;
                SchoolYearLabelEN.Visible = false;
                SchoolYear2LabelEN.Visible = false;
                PaymentBalance2LabelEN.Visible = false;
                PaymentBalanceLabelEN.Visible = false;

                StudentLabelFR.Value = documentTemplateId == 0 ? "Elève" : "Student";
                StudentClassLabelFR.Value = documentTemplateId == 0 ? "Classe" : "Class";
                PaymentAmountLabelFR.Value = documentTemplateId == 0 ? "Montant versé" : "Amount paid";
                PaymentReasonLabelFR.Value = documentTemplateId == 0 ? "Pour" : "For";
                PaymentPlaceLabelFR.Value = documentTemplateId == 0 ? "Mode paiement        :" : "Payment mean";
                SchoolYearLabelFR.Value = documentTemplateId == 0 ?"Anné scolaire" :  "School year";
                PaymentBalanceLabelFR.Value = documentTemplateId == 0 ? "Reste à payer" :"Balance";
                ReferenceLabel.Value = documentTemplateId == 0 ? "REÇU" : "RECEIPT";
                PaymentsTableAmountLabel.Value=documentTemplateId == 0 ? "MONTANT":"AMOUNT";
                PaymentsTableReasonLabel.Value = documentTemplateId == 0 ? "MOTIF":"REASON";
                PaymentsTablePaymentPlaceLabel.Value = documentTemplateId == 0 ?"MOYEN DE PAIEMENT":"PAYMENT MEAN";
                PaymentsTableBalanceLabel.Value = documentTemplateId == 0 ?"IMPAYE":"INPAID";
                SignatureSchoolLabel.Value = documentTemplateId == 0 ? "ECOLE" : "SCHOOL";
                NoteTextBox.Value = documentTemplateId == 0 ? "NB: Un reçu est delivré par élève" : "NB:Each student is issued one receipt";
            }
            else
            {
                StudentLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Elève" : "Student";
                StudentLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Student" : "Elève";
                StudentClassLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Classe" : "Class";
                StudentClassLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Class" : "Classe";
                PaymentAmountLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Montant versé" : "Amount paid";
                PaymentAmountLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Amount paid" : "Montant versé";
                PaymentReasonLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Pour" : "For";
                PaymentReasonLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "For" : "Pour";
                PaymentPlaceLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Mode paiement" : "Payment mean";
                PaymentPlaceLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Payment mean" : "Mode paiement";
                SchoolYearLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Anné scolaire" : "School year";
                SchoolYearLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "School year" : "Anné scolaire";
                PaymentBalanceLabelFR.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Reste à payer" : "Balance";
                PaymentBalanceLabelEN.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Balance" : "Reste à payer";
                NoteTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "NB: Un reçu est delivré par élève (Each student is issued one receipt)" : "NB: Each student is issued one receipt (Un reçu est delivré par élève)";
                Student2LabelEN.Value = StudentLabelEN.Value;
                StudentClass2LabelEN.Value = StudentClassLabelEN.Value;
                PaymentAmount2LabelEN.Value = PaymentAmountLabelEN.Value;
                PaymentReason2LabelEN.Value = PaymentReasonLabelEN.Value;
                PaymentPlace2LabelEN.Value = PaymentPlaceLabelEN.Value;
                SchoolYear2LabelEN.Value = SchoolYearLabelEN.Value;
                PaymentBalance2LabelEN.Value = PaymentBalanceLabelEN.Value;

                ReferenceLabel.Value = "N°";
                PaymentsTableAmountLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "MONTANT/AMOUNT": "AMOUNT/MONTANT";
                PaymentsTableReasonLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "MOTIF/REASON": "REASON/MOTIF";
                PaymentsTablePaymentPlaceLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "M. DE PAIEMENT/P. MEAN": "P. MEAN/M. DE PAIEMENT";
                PaymentsTableBalanceLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "IMPAYE/INPAID": "INPAID/IMPAYE";
                SignatureSchoolLabel.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "ECOLE/SCHOOL" : "SCHOOL/ECOLE";
            }
            Reference2Label.Value = ReferenceLabel.Value;
            PaymentDateLabel.Value = "DATE";
            PaymentDate2Label.Value = PaymentDateLabel.Value;
            StudentIdNumberLabel.Value = "Matricule";
            StudentIdNumber2Label.Value = StudentIdNumberLabel.Value;
            Student2LabelFR.Value = StudentLabelFR.Value;
            StudentClass2LabelFR.Value = StudentClassLabelFR.Value;
            PaymentAmount2LabelFR.Value = PaymentAmountLabelFR.Value;
            PaymentReason2LabelFR.Value = PaymentReasonLabelFR.Value;
            PaymentPlace2LabelFR.Value = PaymentPlaceLabelFR.Value;
            SchoolYear2LabelFR.Value = SchoolYearLabelFR.Value;
            PaymentBalance2LabelFR.Value = PaymentBalanceLabelFR.Value;
            SignatureSchool2Label.Value = SignatureSchoolLabel.Value;
            PaymentsTableBalance2Label.Value = PaymentsTableBalanceLabel.Value;
            PaymentsTablePaymentPlace2Label.Value = PaymentsTablePaymentPlaceLabel.Value;
            PaymentsTableReason2Label.Value = PaymentsTableReasonLabel.Value;
            PaymentsTableAmount2Label.Value = PaymentsTableAmountLabel.Value;
            Note2TextBox.Value = NoteTextBox.Value;
        }
    }
}
