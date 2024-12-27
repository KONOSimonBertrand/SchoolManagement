

using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Threading;
using Telerik.Reporting.Drawing;

namespace Primary.SchoolApp.Reporting
{
    internal class PaymentReceiptA4Report : SchoolManagement.UI.Reporting.PaymentReceiptA4Report
    {
        public PaymentReceiptA4Report() {
            InitComponents();
        }
        public PaymentReceiptA4Report(StudentEnrolling enrolling, bool isCopy, ClientApp clientApp)
        {
            InitComponents();
            if (enrolling != null)
            {
                Console.WriteLine(enrolling.SchoolClass.DocumentLanguage);
                CopyLabel.Visible = isCopy;
                Copy2Label.Visible = isCopy;
                InitVisiblity(enrolling.SchoolClass.DocumentLanguageId);

                
                PaymentIdNumberTextBox.Value = "#" + enrolling.Id;
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = enrolling.Date.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = enrolling.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = enrolling.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = enrolling.SchoolClass.Name;
                StudentClass2TextBox.Value = enrolling.SchoolClass.Name;
                SchoolYearTextBox.Value = enrolling.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = enrolling.PaymentList.Sum(a => a.Amount).ToString() + " CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                var lFR = "(" + enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                var lEN = "(" + enrolling.PaymentList.Sum(a => a.Amount).ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                if (enrolling.SchoolClass.DocumentLanguageId==0)
                {
                    PaymentAmountLeterTextBox.Value = lFR;
                }
                else
                {
                    if (enrolling.SchoolClass.DocumentLanguageId == 1)
                    {
                        PaymentAmountLeterTextBox.Value = lEN;
                    }
                    else
                    {
                        PaymentAmountLeterTextBox.Value = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? lFR.Replace(")", "") + "/"+lEN.Replace("(", "") : lEN.Replace(")", "") + "/"+lFR.Replace("(", "");
                    }
                }
               
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = enrolling.PaymentList.Sum(a => a.Balance).ToString() + " CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                if (enrolling.PaymentList.Count != 0)
                {
                    if (enrolling.PaymentList.Count > 1)
                    {
                        var meanList = enrolling.PaymentList.Select(x => x.PaymentMean).Distinct().ToList();
                        var reasonList = enrolling.PaymentList.Select(x => x.CashFlowType).Distinct().ToList();
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
                        PaymentReasonTextBox.Value = enrolling.PaymentList.FirstOrDefault().CashFlowType.Name;
                        PaymentMeanTextBox.Value = enrolling.PaymentList.FirstOrDefault().PaymentMean.FullName;
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

                PaymentsTable.DataSource = enrolling.PaymentList;
                Payments2Table.DataSource = enrolling.PaymentList;
                PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();
                PrintDate2TextBox.Value = PrintDateTextBox.Value;
                FirstCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(0.5D));
                SecondCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(6D));
                if (enrolling.PaymentList.Count > 1)
                {
                    SignatureDoneByPanel.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    SignatureSchoolPanel.Location = new PointU(Unit.Inch(4.8D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    SignatureDoneBy2Panel.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    SignatureSchool2Panel.Location = new PointU(Unit.Inch(4.8D), Unit.Inch(4.1D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);

                    WebSiteTextBox.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    WebSite2TextBox.Location = new PointU(Unit.Inch(0D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    AdressTextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    Adress2TextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(4.9D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);

                    PhoneTextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    Phone2TextBox.Location = new PointU(Unit.Inch(1.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    PrintDateTextBox.Location = new PointU(Unit.Inch(6.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                    PrintDate2TextBox.Location = new PointU(Unit.Inch(6.1D), Unit.Inch(5D) - Unit.Inch(0.1D) * enrolling.PaymentList.Count);
                }
                FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SchoolNameTextBox.Value = clientApp.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = clientApp.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = clientApp.Contact;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = clientApp.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = clientApp.LogoUrl;
                Logo2PictureBox.Value = LogoPictureBox.Value;

            }

        }
        public PaymentReceiptA4Report(TuitionPayment payment, bool isCopy, ClientApp clientApp)
        {
            InitComponents();
            if (payment != null)
            {
                CopyLabel.Visible = isCopy;
                Copy2Label.Visible = isCopy;
                PaymentsTableAmountLabel.Value = Language.labelAmount.ToUpper();
                PaymentsTableAmount2Label.Value = PaymentsTableAmountLabel.Value;
                PaymentsTableReasonLabel.Value = Language.labelReason.ToUpper();
                PaymentsTableReason2Label.Value = PaymentsTableReasonLabel.Value;
                PaymentsTablePaymentPlaceLabel.Value = Language.labelPaymentMean.ToUpper();
                PaymentsTablePaymentPlace2Label.Value = PaymentsTablePaymentPlaceLabel.Value;
                PaymentsTableBalanceLabel.Value = Language.labelUnPaid.ToUpper();
                PaymentsTableBalance2Label.Value = PaymentsTableBalanceLabel.Value;
                PaymentIdNumberTextBox.Value = payment.IdNumber;
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = payment.Date.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = payment.Enrolling.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = payment.Enrolling.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = payment.Enrolling.SchoolClass.Name;
                StudentClass2TextBox.Value = payment.Enrolling.SchoolClass.Name;
                SchoolYearTextBox.Value = payment.Enrolling.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = payment.Amount.ToString() + " F CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    PaymentAmountLeterTextBox.Value = "(" + payment.Amount.ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                }
                else
                {
                    PaymentAmountLeterTextBox.Value = "(" + payment.Amount.ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                }
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = payment.Balance.ToString() + " F CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                PaymentReasonTextBox.Value = payment.CashFlowType.Name;
                PaymentMeanTextBox.Value=payment.PaymentMean.FullName;
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
                SchoolNameTextBox.Value = clientApp.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = clientApp.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = clientApp.Contact;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = clientApp.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = clientApp.LogoUrl;
                Logo2PictureBox.Value = LogoPictureBox.Value;

            }

        }
        public PaymentReceiptA4Report(Subscription subscription, bool isCopy, ClientApp clientApp)
        {
            InitComponents();
            if (subscription != null)
            {
                var studentRoom=Program.StudentRoomList.FirstOrDefault(x => x.StudentId==subscription.StudentId && x.SchoolYearId== subscription.SchoolYearId);
                var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == studentRoom.RoomId);
                var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
                CopyLabel.Visible = isCopy;
                Copy2Label.Visible = isCopy;
                PaymentsTableAmountLabel.Value = Language.labelAmount.ToUpper();
                PaymentsTableAmount2Label.Value = PaymentsTableAmountLabel.Value;
                PaymentsTableReasonLabel.Value = Language.labelReason.ToUpper();
                PaymentsTableReason2Label.Value = PaymentsTableReasonLabel.Value;
                PaymentsTablePaymentPlaceLabel.Value = Language.labelPaymentMean.ToUpper();
                PaymentsTablePaymentPlace2Label.Value = PaymentsTablePaymentPlaceLabel.Value;
                PaymentsTableBalanceLabel.Value = Language.labelUnPaid.ToUpper();
                PaymentsTableBalance2Label.Value = PaymentsTableBalanceLabel.Value;
                PaymentIdNumberTextBox.Value = $"# {subscription.IdNumber}";
                PaymentIdNumber2TextBox.Value = PaymentIdNumberTextBox.Value;
                PaymentDateTextBox.Value = subscription.StartDate.ToShortDateString();
                PaymentDate2TextBox.Value = PaymentDateTextBox.Value;
                StudentTextBox.Value = subscription.Student.FullName;
                Student2TextBox.Value = StudentTextBox.Value;
                StudentIdNumberTextBox.Value = subscription.Student.IdNumber;
                StudentIdNumber2TextBox.Value = StudentIdNumberTextBox.Value;
                StudentClassTextBox.Value = classOfRoom.Name;
                StudentClass2TextBox.Value = StudentClassTextBox.Value;
                SchoolYearTextBox.Value = subscription.SchoolYear.Name;
                SchoolYear2TextBox.Value = SchoolYearTextBox.Value;
                PaymentAmountTextBox.Value = subscription.Amount.ToString() + " F CFA";
                PaymentAmount2TextBox.Value = PaymentAmountTextBox.Value;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    PaymentAmountLeterTextBox.Value = "(" + subscription.Amount.ToLetter(CountryLanguage.French, Currency.CFA) + ")";
                }
                else
                {
                    PaymentAmountLeterTextBox.Value = "(" + subscription.Amount.ToLetter(CountryLanguage.English, Currency.CFA) + ")";
                }
                PaymentAmountLeter2TextBox.Value = PaymentAmountLeterTextBox.Value;
                PaymentBalanceTextBox.Value = "0 F CFA";
                PaymentBalance2TextBox.Value = PaymentBalanceTextBox.Value;
                PaymentReasonTextBox.Value = subscription.CashFlowType.Name;
                PaymentReason2TextBox.Value = PaymentReasonTextBox.Value;
                PaymentMeanTextBox.Value = subscription.PaymentMean.FullName;
                PaymentMean2TextBox.Value = PaymentMeanTextBox.Value;
                PaymentsTable.Visible = false;
                Payments2Table.Visible = false;
                PrintDateTextBox.Value = Language.labelPrintOn + "  " + DateTime.Now.ToString();
                PrintDate2TextBox.Value = PrintDateTextBox.Value;
                FirstCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(0.5D));
                SecondCopyPanel.Location = new PointU(Unit.Inch(0.2D), Unit.Inch(6D));
                FirstCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SecondCopyPanel.Size = new SizeU(Unit.Inch(7.804D), Unit.Inch(5.1D));
                SchoolNameTextBox.Value = clientApp.Name;
                SchoolName2TextBox.Value = SchoolNameTextBox.Value;
                WebSiteTextBox.Value = clientApp.WebSite;
                WebSite2TextBox.Value = WebSiteTextBox.Value;
                PhoneTextBox.Value = clientApp.Contact;
                Phone2TextBox.Value = PhoneTextBox.Value;
                AdressTextBox.Value = clientApp.Address;
                Adress2TextBox.Value = AdressTextBox.Value;
                LogoPictureBox.Value = clientApp.LogoUrl;
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
