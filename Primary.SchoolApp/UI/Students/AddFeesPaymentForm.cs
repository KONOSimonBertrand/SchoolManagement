
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.UI
{

    internal class AddFeesPaymentForm : SchoolManagement.UI.EditFeesPaymentForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISchoolSupplieService supplieService;
        private readonly IPrintService printService;
        private readonly ClientApp clientApp;
        private readonly IReceiptService receiptService;
        private readonly List<Subscription> subscriptionsToAdd;
        private readonly List<TuitionPayment> tuitionPaymentsToAdd;
        private readonly List<SchoolSupplie> schoolSuppliesToAdd;
        private readonly List<ReceiptItem> paymentList;
        private readonly ILogger<AddFeesPaymentForm> logger;
        private StudentEnrolling selectedEnrolling;
        private TypeFee selectedTypeFee;
        private List<TuitionPayment> tuitionPayments;
        private List<TuitionDiscount> tuitionDiscounts;
        public AddFeesPaymentForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, ISubscriptionService subscriptionService, ISchoolSupplieService supplieService, IPrintService printService, ClientApp clientApp, IReceiptService receiptService, ILogger<AddFeesPaymentForm> logger)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.subscriptionService = subscriptionService;
            this.supplieService = supplieService;
            this.printService = printService;
            this.clientApp = clientApp;
            this.receiptService = receiptService;
            this.logger = logger;
            subscriptionsToAdd = new List<Subscription>();
            tuitionPaymentsToAdd = new List<TuitionPayment>();
            schoolSuppliesToAdd = new List<SchoolSupplie>();
            paymentList = new List<ReceiptItem>();
            tuitionPayments = new List<TuitionPayment>();
            tuitionDiscounts = new List<TuitionDiscount>();
            selectedTypeFee = TypeFee.Unknown;
            PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            InitEvents();
        }


        public void Init(StudentEnrolling enrolling, TypeFee typeFee)
        {
            if (enrolling != null)
            {
                selectedTypeFee = typeFee;
                var item = new RadListDataItem
                {
                    Text = $"{enrolling.Student.LastName} {enrolling.Student.FirstName} | {enrolling.Student.IdNumber}",
                    Value = enrolling.Student.Id,
                    Image = File.Exists(enrolling.Student.PictureUrl) ? new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                    Tag = enrolling
                };

                StudentDropDownList.Items.Add(item);
                StudentDropDownList.SelectedIndex = 0;
            }
        }
        public void Init(List<StudentEnrolling> enrollings, TypeFee typeFee)
        {
            selectedTypeFee = typeFee;
            foreach (StudentEnrolling enrolling in enrollings)
            {
                var item = new RadListDataItem
                {
                    Text = $"{enrolling.Student.LastName} {enrolling.Student.FirstName} | {enrolling.Student.IdNumber}",
                    Value = enrolling.Student.Id,
                    Image = File.Exists(enrolling.Student.PictureUrl) ? new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                    Tag = enrolling
                };
                StudentDropDownList.Items.Add(item);
            }
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            StudentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
            FeesDropDownList.SelectedValueChanged += FeesDropDownList_SelectedValueChanged;
            InvoiceItemListView.SelectedItemChanged += InvoiceItemListView_SelectedItemChanged;
            RemoveInvoiceItemButton.Click += RemoveInvoiceItemButton_Click;
            AddInvoiceItemButton.Click += AddInvoiceItemButton_Click;
            AmountTextBox.KeyDown += AmountTextBox_KeyDown;
            InvoiceItemListView.KeyDown += InvoiceItemListView_KeyDown;
        }

        private void InvoiceItemListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                RemoveInvoiceItem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (InvoiceItemListView.Items.Count == 0)
                {
                    DataErrorProvider.SetError(InvoiceItemListView, Language.messageFillField);
                    this.ErrorLabel.Text = Language.messageFillField;
                    this.InvoiceItemListView.Focus();
                    return;
                }
                // Enregistrement du reçu de paiement
                if (InvoiceItemListView.Items.Any())
                {
                    var opFor = string.Empty;
                    if (tuitionPaymentsToAdd.Any())
                    {
                        opFor += Language.labelTuitionFees;
                    }
                    if (subscriptionsToAdd.Any())
                    {
                        opFor += " & " + Language.labelSubscriptions;
                    }
                    if (schoolSuppliesToAdd.Any())
                    {
                        opFor += " & " + Language.LabelSchoolSupplie;
                    }
                    var receipt = await receiptService.CreateReceiptAsync(new Receipt()
                    {
                        SchoolYearId = Program.CurrentSchoolYear.Id,
                        SchoolYear = Program.CurrentSchoolYear,
                        Date = DateTime.Now,
                        Amount = (double)InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"])),
                        OpDoneBy = DoneByTextBox.Text,
                        OpFor = opFor,
                        Balance = paymentList.Sum(x => x.Balance)
                    });
                    if (receipt != null)
                    {
                        Log logReceipt = new()
                        {
                            UserAction = $"Enregistrement du reçu de paiement N° {receipt.IdNumber} pour l'élève {selectedEnrolling?.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(logReceipt);
                        logger.LogInformation("Enregistrement du reçu de paiement N° {ReceiptId} pour l'élève {StudentName}  par l'utilisateur {UserName}", receipt.IdNumber, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);

                        // Enregistrement des frais
                        if (tuitionPaymentsToAdd.Count > 0)
                        {
                            foreach (var t in tuitionPaymentsToAdd)
                            {
                                t.EnrollingId = selectedEnrolling.Id;
                                t.Enrolling = selectedEnrolling;
                                t.Receipt = receipt;
                                t.ReceiptId = receipt.Id;
                                if (await cashFlowService.CreateTuitionPayment(t) == true)
                                {
                                    Log logTuitionPayment = new()
                                    {
                                        UserAction = $"Enregistrement du paiement de frais scolarité  {t?.CashFlowType?.Name} pour l'élève {selectedEnrolling?.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    await logService.CreateLog(logTuitionPayment);
                                    logger.LogInformation("Enregistrement du paiement de frais scolarité  {TuitionPaymentName} pour l'élève {StudentName}  par l'utilisateur {UserName}", t?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                                }
                                else
                                {
                                    logger.LogError("Une erreur est survenue lors de l'enregistrement du paiement de frais scolarité  {TuitionPaymentName} pour l'élève {StudentName}  par l'utilisateur {UserName}", t?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                                }
                            }
                        }
                        if (subscriptionsToAdd.Count > 0)
                        {
                            foreach (var s in subscriptionsToAdd)
                            {
                                s.Student = selectedEnrolling?.Student;
                                s.StudentId = selectedEnrolling.StudentId;
                                s.Receipt = receipt;
                                s.ReceiptId = receipt.Id;

                                if (await subscriptionService.CreateSubscriptionAsync(s) == true)
                                {
                                    Log logSubscription = new()
                                    {
                                        UserAction = $"Enregistrement de l'abonnement  {s?.CashFlowType?.Name} pour l'élève {selectedEnrolling?.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    await logService.CreateLog(logSubscription);
                                    logger.LogInformation("Enregistrement de l'abonnement {SubscriptionName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                                }
                                else
                                {
                                    logger.LogError("Une erreur est survenue lors de l'enregistrement de l'abonnement {SubscriptionName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName); ;
                                }
                            }
                        }
                        if (schoolSuppliesToAdd.Count > 0)
                        {
                            foreach (var s in schoolSuppliesToAdd)
                            {
                                s.Receipt = receipt;
                                s.ReceiptId = receipt.Id;
                                s.Enrolling = selectedEnrolling;
                                s.EnrollingId = selectedEnrolling.Id;
                                if (await supplieService.CreateSchoolSupplie(s) == true)
                                {
                                    Log logSupplie = new()
                                    {
                                        UserAction = $"Enregistrement  fourniture scolaire  {s?.CashFlowType?.Name} pour l'élève {selectedEnrolling?.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    await logService.CreateLog(logSupplie);
                                    logger.LogInformation("Enregistrement fourniture scolaire  {SupplieName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                                }
                                else
                                {
                                    logger.LogError("Une erreur est survenue lors de l'enregistrement fourniture scolaire  {SupplieName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                                }
                            }
                        }
                        //impression du reçu
                        var paymentReceipt = GetPaymentReceipt(receipt);
                        await printService.PrintPaymentReceiptAsync(paymentReceipt, false);
                    }
                    else
                    {
                        logger.LogError("Erreur lors de l'enregistrement du reçu de paiement pour l'élève {StudentName}  par l'utilisateur {UserName}", selectedEnrolling?.Student.FullName, clientApp.UserConnected.UserName);
                    }
                   
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Chargement des frais à payer.
        private async Task LoadFeesList(int classId, TypeFee typeFee)
        {
            if (StudentDropDownList.SelectedItem.Tag is StudentEnrolling enrolling)
            {
                var InfoItemList = new List<FeeItem>();
                int i = 0;
                switch (typeFee)
                {
                    case TypeFee.Unknown:
                        tuitionPayments = await cashFlowService.GetTuitionPaymentByEnrollingList(selectedEnrolling.Id);
                        tuitionDiscounts = await cashFlowService.GetTuitionDiscountByEnrollingList(selectedEnrolling.Id);
                        foreach (var fs in Program.SchoolingCostList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            var discountAmount = tuitionDiscounts.Where(x => x.CashFlowTypeId == fs.CashFlowTypeId).Sum(x => x.Discount);
                            var unPaidAmount = fs.Amount - (tuitionPayments.Where(x => x.CashFlowTypeId == fs.CashFlowTypeId).Sum(x => x.Amount) + discountAmount);
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = unPaidAmount,
                                Quantity = 1,
                                Discount = discountAmount,
                                Name = fs.CashFlowType.Name,
                                Category = TypeFee.TuitionFee,
                                Description = $"{fs.CashFlowType.Name} | {Language.labelDiscount}: {string.Format("{0:C2}", discountAmount)} | {Language.labelUnPaid}: {string.Format("{0:C2}", unPaidAmount)}",
                                Tag = fs
                            }
                                );
                        }

                        foreach (var ab in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = ab.Amount,
                                Quantity = 1,
                                Name = ab.CashFlowType.Name,
                                Category = TypeFee.Subscription,
                                Description = $"{ab.CashFlowType.Name} | {string.Format("{0:C2}", ab.Amount)}",
                                Tag = ab
                            }
                                );
                        }

                        foreach (var ff in Program.SchoolSupplieFeeList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = ff.Amount,
                                Name = ff.CashFlowType.Name,
                                Category = TypeFee.SchoolSupply,
                                Quantity = ff.RequiredQuantity,
                                Description = $"{ff.CashFlowType.Name} | {string.Format("{0:C2}", ff.Amount)}",
                                Tag = ff
                            }
                                );
                        }
                        break;
                    case TypeFee.TuitionFee:
                        tuitionPayments = await cashFlowService.GetTuitionPaymentByEnrollingList(selectedEnrolling.Id);
                        tuitionDiscounts = await cashFlowService.GetTuitionDiscountByEnrollingList(selectedEnrolling.Id);
                        foreach (var fs in Program.SchoolingCostList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            var discountAmount = tuitionDiscounts.Where(x => x.CashFlowTypeId == fs.CashFlowTypeId).Sum(x => x.Discount);
                            var unPaidAmount = fs.Amount - (tuitionPayments.Where(x => x.CashFlowTypeId == fs.CashFlowTypeId).Sum(x => x.Amount) + discountAmount);
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = unPaidAmount,
                                Quantity = 1,
                                Discount = discountAmount,
                                Name = fs.CashFlowType.Name,
                                Category = TypeFee.TuitionFee,
                                Description = $"{fs.CashFlowType.Name} | {Language.labelDiscount}: {string.Format("{0:C2}", discountAmount)} | {Language.labelUnPaid}: {string.Format("{0:C2}", unPaidAmount)}",
                                Tag = fs
                            }
                                );
                        }
                        break;
                    case TypeFee.Subscription:
                        foreach (var ab in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = ab.Amount,
                                Quantity = 1,
                                Name = ab.CashFlowType.Name,
                                Category = TypeFee.Subscription,
                                Description = $"{ab.CashFlowType.Name} | {string.Format("{0:C2}", ab.Amount)}",
                                Tag = ab
                            }
                                );
                        }
                        break;
                    case TypeFee.SchoolSupply:
                        foreach (var ff in Program.SchoolSupplieFeeList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == enrolling.SchoolYearId))
                        {
                            InfoItemList.Add(new()
                            {
                                Id = i++,
                                UnitPrice = ff.Amount,
                                Name = ff.CashFlowType.Name,
                                Category = TypeFee.SchoolSupply,
                                Quantity = ff.RequiredQuantity,
                                Description = $"{ff.CashFlowType.Name} | {string.Format("{0:C2}", ff.Amount)}",
                                Tag = ff
                            }
                                );
                        }
                        break;
                }
                FeesDropDownList.DataSource = null;
                FeesDropDownList.ValueMember = "Id";
                FeesDropDownList.DisplayMember = "Description";
                FeesDropDownList.DataSource = InfoItemList;
            }
        }

        private void FeesDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FeesDropDownList.SelectedItem?.DataBoundItem is FeeItem receiptItem)
            {
                string info = string.Empty;
                this.AmountLabel.Visible = true;
                this.AmountTextBox.Visible = true;
                this.AmountSeparator.Visible = true;
                this.AmountTextBox.ReadOnly = false;
                switch (receiptItem.Category)
                {
                    case TypeFee.TuitionFee:
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.StartDateTimePicker.Visible = false;
                        this.EndDateTimePicker.Visible = false;
                        this.StartDateSeparator.Visible = false;
                        this.EndDateSeparator.Visible = false;
                        this.StartDateLabel.Visible = false;
                        this.EndDateLabel.Visible = false;
                        var fs = receiptItem.Tag as SchoolingCost;
                        info = $"{receiptItem.Name}\r {Language.labelAmount}: {fs.Amount}\r {Language.labelTrancheNumber}: {fs.TrancheNumber}\r {Language.labelDiscount}: {receiptItem.Discount}";
                        break;
                    case TypeFee.Subscription:
                        this.AmountTextBox.ReadOnly = true;
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.StartDateTimePicker.Value = DateTime.Now;
                        this.EndDateTimePicker.Value = DateTime.Now.AddDays((receiptItem.Tag as SubscriptionFee)?.Duration ?? 0);
                        this.StartDateTimePicker.Visible = true;
                        this.EndDateTimePicker.Visible = true;
                        this.StartDateSeparator.Visible = true;
                        this.EndDateSeparator.Visible = true;
                        this.StartDateLabel.Visible = true;
                        this.EndDateLabel.Visible = true;
                        var ab = receiptItem.Tag as SubscriptionFee;
                        info = $"{receiptItem.Name}\r {Language.labelAmount}: {receiptItem.Total}\r {Language.labelDuration}: {ab.Duration}";
                        break;
                    case TypeFee.SchoolSupply:
                        this.AmountLabel.Text = Language.LabelQuantity;
                        this.AmountTextBox.Text = receiptItem.Quantity.ToString();
                        this.StartDateTimePicker.Visible = false;
                        this.EndDateTimePicker.Visible = false;
                        this.StartDateSeparator.Visible = false;
                        this.EndDateSeparator.Visible = false;
                        this.StartDateLabel.Visible = false;
                        this.EndDateLabel.Visible = false;
                        var ff = receiptItem.Tag as SchoolSupplieFee;
                        info = $"{receiptItem.Name}\r {Language.labelAmount}: {receiptItem.Total}\r {Language.LabelRequiredQuantity}: {ff.RequiredQuantity}";
                        break;
                    default:
                        this.AmountTextBox.ReadOnly = true;
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.StartDateTimePicker.Visible = false;
                        this.EndDateTimePicker.Visible = false;
                        this.StartDateSeparator.Visible = false;
                        this.EndDateSeparator.Visible = false;
                        this.StartDateLabel.Visible = false;
                        this.EndDateLabel.Visible = false;
                        break;
                }
                FeesDropDownList.RootElement.ToolTipText = info;
            }
        }

        private async void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (StudentDropDownList.SelectedIndex != -1 && StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.Tag is StudentEnrolling enrolling)
                {
                    selectedEnrolling = enrolling;
                    this.ClassTextBox.Text = enrolling.SchoolClass != null ? enrolling.SchoolClass?.Name : Program.SchoolClassList.FirstOrDefault(x => x.Id == enrolling.ClassId)?.Name;
                    this.SchoolYearTextBox.Text = Program.CurrentSchoolYear.Name;

                    await LoadFeesList(enrolling.ClassId, selectedTypeFee);
                    DateTime today = DateTime.Now;
                    int age = today.Year - enrolling.Student.BirthDate.Year;
                    if (enrolling.Student.BirthDate > today.AddYears(-age))
                    {
                        age--;
                    }

                    string info = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), enrolling.Student.Sex == "M" ? Language.LabelMale : Language.LabelFemale, enrolling.Student.BirthDate.ToString("dd/MM/yyyy"));
                    DoneByTextBox.Text = enrolling.Student.FullName;
                    StudentDropDownList.RootElement.ToolTipText = $"{enrolling.Student.FullName}\r {info}\r {Language.labelStudentId}: {enrolling.Student.IdNumber}\r{Language.labelPhone}: {enrolling.Student.Phone}\r {Language.labelAddress}: {enrolling.Student.Address}";
                }
                else
                {
                    DoneByTextBox.Text = string.Empty;
                    StudentDropDownList.RootElement.ToolTipText = string.Empty;
                }
            }
        }

        private void InvoiceItemListView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (InvoiceItemListView?.SelectedItem?.Tag is FeeItem receiptItem)
            {
                RemoveInvoiceItemButton.Enabled = true;
            }
        }

        // Permet de supprimer un item de la liste des items à payer
        private void RemoveInvoiceItemButton_Click(object sender, EventArgs e)
        {
            RemoveInvoiceItemButton.Enabled = false;
            RemoveInvoiceItem();
            RemoveInvoiceItemButton.Enabled = true;
        }
        // Permet de supprimer un item de la liste des items à payer
        private void RemoveInvoiceItem()
        {
            if (InvoiceItemListView.SelectedItem != null)
            {
                var feeItem = InvoiceItemListView.SelectedItem.Tag as FeeItem;

                int cashFlowTypeId = 0;
                switch (feeItem.Category)
                {
                    case TypeFee.TuitionFee:
                        cashFlowTypeId = (feeItem.Tag as SchoolingCost)?.CashFlowTypeId ?? 0;
                        tuitionPaymentsToAdd.Remove(tuitionPaymentsToAdd.FirstOrDefault(t => t.CashFlowTypeId == cashFlowTypeId));
                        break;
                    case TypeFee.Subscription:
                        cashFlowTypeId = (feeItem.Tag as SubscriptionFee)?.CashFlowTypeId ?? 0;
                        subscriptionsToAdd.Remove(subscriptionsToAdd.FirstOrDefault(s => s.CashFlowTypeId == cashFlowTypeId));
                        break;
                    case TypeFee.SchoolSupply:
                        cashFlowTypeId = (feeItem.Tag as SchoolSupplieFee)?.CashFlowTypeId ?? 0;
                        schoolSuppliesToAdd.Remove(schoolSuppliesToAdd.FirstOrDefault(s => s.CashFlowTypeId == cashFlowTypeId));
                        break;
                    default:

                        break;
                }
                this.InvoiceItemListView.Items.Remove(InvoiceItemListView.SelectedItem);
                decimal total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                double totalToDouble = double.Parse(total.ToString());
                string totalToLetter = string.Empty;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalToLetter = "(" + totalToDouble.ToLetter(CountryLanguage.French) + ")";
                }
                else
                {
                    totalToLetter = "(" + totalToDouble.ToLetter(CountryLanguage.English) + ")";
                }
                InvoiceTotalListView.Items.Clear();
                ListViewDataItem totalItem = new();
                InvoiceTotalListView.Items.Add(totalItem);
                totalItem["Total"] = "TOTAL";
                totalItem["TotalPrice"] = string.Format("{0:C2}", total) + " " + totalToLetter;
                if (InvoiceItemListView.Items.Count == 0)
                {
                    RemoveInvoiceItemButton.Enabled = false;
                }
                paymentList.Remove(new ReceiptItem
                {
                    Id = feeItem.Id,
                }
                );
            }
        }
        // Permet d'ajouter un item à la liste des items à payer
        private void AddInvoiceItemButton_Click(object sender, EventArgs e)
        {
            AddInvoiceItem();
        }
        /// <summary>
        ///  ajout  d'un item à la liste des items à payer et calcule le total à payer, vérifie aussi si l'item ajouté est déjà dans la liste ou pas et affiche les erreurs de saisie
        /// </summary>
        private void AddInvoiceItem()
        {
            if (!this.IsValidData()) return;
            if (this.PaymentMeanDropDownList.SelectedIndex < 0)
            {
                DataErrorProvider.SetError(this.PaymentMeanDropDownList, Language.messageFillField);
                this.ErrorLabel.Text = Language.messageFillField;
                this.PaymentMeanDropDownList.Focus();
                return;
            }
            ErrorLabel.Text = string.Empty;
            DataErrorProvider.Clear();

            if (FeesDropDownList.SelectedIndex < 0)
            {
                DataErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                FeesDropDownList.Focus();
                return;
            }
            if (double.TryParse(AmountTextBox.Text, out double amount) == false)
            {
                DataErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                AmountTextBox.Focus();
                return;
            }

            if (FeesDropDownList?.SelectedItem.DataBoundItem is FeeItem feeItem)
            {
                if (amount <= 0 && feeItem.Category != TypeFee.Subscription)
                {
                    DataErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = Language.messageFillField;
                    AmountTextBox.Focus();
                    return;
                }
                if (feeItem.Total < amount && feeItem.Category != TypeFee.SchoolSupply)
                {
                    DataErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = $"{Language.labelAmountPaid}({amount}) > {Language.LabelFeesToPay}({feeItem.Total})";
                    AmountTextBox.Focus();
                    return;
                }

                // On vérifie si ça déjà été ajouté
                if (InvoiceItemListView.Items.Any(item => item["Item"].ToString() == feeItem.Name))
                {
                    DataErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                    ErrorLabel.Text = Language.messageDataAlreadyExist;
                    FeesDropDownList.Focus();
                    return;
                }
                ListViewDataItem dataItem = new()
                {
                    Tag = feeItem
                };
                InvoiceItemListView.Items.Add(dataItem);
                dataItem["Item"] = feeItem.Name;
                dataItem["Price"] = string.Format("{0}", feeItem.Category != TypeFee.SchoolSupply ? amount * 1 : feeItem.UnitPrice * amount);

                decimal total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                double totalToDouble = double.Parse(total.ToString());
                ListViewDataItem totalItem = new();
                InvoiceTotalListView.Items.Clear();
                InvoiceTotalListView.Items.Add(totalItem);
                string totalToLetter = string.Empty;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalToLetter = "(" + totalToDouble.ToLetter(CountryLanguage.French) + ")";
                }
                else
                {
                    totalToLetter = "(" + totalToDouble.ToLetter(CountryLanguage.English) + ")";
                }
                totalItem["Total"] = "TOTAL";
                totalItem["TotalPrice"] = string.Format("{0:C2}", total) + " " + totalToLetter;
                FeesDropDownList.SelectedIndex = -1;
                AmountTextBox.Text = "0";
                double balance = 0;
                switch (feeItem.Category)
                {
                    case TypeFee.TuitionFee:
                        balance = feeItem.Total - amount;
                        tuitionPaymentsToAdd.Add(new TuitionPayment()
                        {
                            Amount = amount,
                            CashFlowTypeId = (feeItem.Tag as SchoolingCost)?.CashFlowTypeId ?? 0,
                            CashFlowType = (feeItem.Tag as SchoolingCost).CashFlowType,
                            DoneBy = DoneByTextBox.Text,
                            TransactionDate = TransactionDateTimePicker.Value,
                            PaymentMean = PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean,
                            PaymentMeanId = (PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean)?.Id ?? 0,
                            TransactionId = TransactionIdTextBox.Text,
                            IsValidated = false,
                            Date = DateTime.Now,
                            Note = string.Empty,
                            Id = tuitionPaymentsToAdd.Count + 1,
                            Balance = balance
                        });
                        break;
                    case TypeFee.Subscription:
                        subscriptionsToAdd.Add(new Subscription()
                        {
                            Amount = amount,
                            CashFlowTypeId = (feeItem.Tag as SubscriptionFee)?.CashFlowTypeId ?? 0,
                            CashFlowType = (feeItem.Tag as SubscriptionFee).CashFlowType,
                            StartDate = StartDateTimePicker.Value,
                            EndDate = EndDateTimePicker.Value,
                            StudentId = (StudentDropDownList.SelectedItem?.DataBoundItem as Student)?.Id ?? 0,
                            Student = (StudentDropDownList.SelectedItem?.DataBoundItem as Student),
                            DoneBy = DoneByTextBox.Text,
                            SchoolYearId = Program.CurrentSchoolYear.Id,
                            SchoolYear = Program.CurrentSchoolYear,
                            TransactionDate = TransactionDateTimePicker.Value,
                            PaymentMean = PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean,
                            PaymentMeanId = (PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean)?.Id ?? 0,
                            TransactionId = TransactionIdTextBox.Text,
                            IsValidated = false,
                            Id = subscriptionsToAdd.Count + 1,
                        });

                        break;
                    case TypeFee.SchoolSupply:
                        balance = (double)((feeItem.Tag as SchoolSupplieFee)?.RequiredQuantity - amount);
                        schoolSuppliesToAdd.Add(new SchoolSupplie()
                        {
                            Amount = (feeItem.Tag as SchoolSupplieFee)?.Amount * amount ?? 0,
                            Date = DateTime.Now,
                            CashFlowTypeId = (feeItem.Tag as SchoolSupplieFee)?.CashFlowTypeId ?? 0,
                            CashFlowType = (feeItem.Tag as SchoolSupplieFee)?.CashFlowType,
                            DoneBy = DoneByTextBox.Text,
                            TransactionDate = TransactionDateTimePicker.Value,
                            PaymentMean = PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean,
                            PaymentMeanId = (PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean)?.Id ?? 0,
                            TransactionId = TransactionIdTextBox.Text,
                            Quantity = amount,
                            IsValidated = false,
                            Id = schoolSuppliesToAdd.Count + 1,
                            Balance = balance
                        }
                            );
                        break;
                }
                double unitPrice = amount;
                double quantity = feeItem.Quantity;
                if (feeItem.Tag is SchoolSupplieFee supplieFee)
                {
                    unitPrice = supplieFee.Amount;
                    quantity = amount;
                    balance = (supplieFee.Amount * supplieFee.RequiredQuantity) - (unitPrice * quantity);
                    balance = balance < 0 ? 0 : balance;
                }
                paymentList.Add(new ReceiptItem
                {
                    Id = feeItem.Id,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    ItemName = feeItem.Category == TypeFee.SchoolSupply ? feeItem.Name + " (" + Language.LabelQuantity + ": " + quantity + ")" : feeItem.Name,
                    Balance = balance,
                    Discount = 0
                }
            );
                this.AmountLabel.Visible = false;
                this.AmountTextBox.Visible = false;
                this.AmountSeparator.Visible = false;
                this.StartDateTimePicker.Visible = false;
                this.EndDateTimePicker.Visible = false;
                this.StartDateSeparator.Visible = false;
                this.EndDateSeparator.Visible = false;
                this.StartDateLabel.Visible = false;
                this.EndDateLabel.Visible = false;
                this.FeesDropDownList.Focus();
            }
        }

        private void AmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Add)
            {
                AddInvoiceItem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
        }

        //Permet de créer reçu de paiement à partir d'une instance de receipt
        private PaymentReceipt GetPaymentReceipt(Receipt receipt)
        {
            var selectedClass = selectedEnrolling.SchoolClass;
            var selectedStudent = selectedEnrolling.Student;
            var studentIdNumber = selectedStudent != null ? selectedStudent.IdNumber : string.Empty;
            var studentName = selectedStudent != null ? selectedStudent.FullName : string.Empty;
            var receiptTitle = string.Empty;
            var transactionId = string.Empty;
            var transactionItems = new List<string>();
            var PaymentModes = new List<string>();
            if (tuitionPaymentsToAdd.Any())
            {
                transactionItems.AddRange(tuitionPaymentsToAdd.Select(x => x.TransactionId).Distinct().ToList());
                PaymentModes.AddRange(tuitionPaymentsToAdd.Select(x => x.PaymentMean?.Name).Distinct().ToList());
                receiptTitle += Language.labelTuitionFees;
            }
            if (subscriptionsToAdd.Any())
            {
                receiptTitle += " & " + Language.labelSubscriptions;
                transactionItems.AddRange(subscriptionsToAdd.Select(x => x.TransactionId).Distinct().ToList());
                PaymentModes.AddRange(subscriptionsToAdd.Select(x => x.PaymentMean?.Name).Distinct().ToList());
            }
            if (schoolSuppliesToAdd.Any())
            {
                receiptTitle += " & " + Language.LabelSchoolSupplie;
                transactionItems.AddRange(schoolSuppliesToAdd.Select(x => x.TransactionId).Distinct().ToList());
                PaymentModes.AddRange(schoolSuppliesToAdd.Select(x => x.PaymentMean?.Name).Distinct().ToList());
            }
            var receiptHeaderSection = new ReceiptHeaderSection(
                ReceiptNumber: receipt.IdNumber,
                ReceiptDate: DateTime.Now,
                ReceiptTitle: receiptTitle,
                StudentName: studentName,
                StudentId: studentIdNumber,
                StudentRoom: selectedClass?.Name,
                TransactionId: string.Join(", ", transactionItems.Distinct()),
                PaymentMode: string.Join(", ", PaymentModes.Distinct()),
                SchoolYear: Program.CurrentSchoolYear.Name
            );
            var receiptDetailSection = new ReceiptDetailSection(paymentList);
            var receiptFooterSection = new ReceiptFooterSection(string.Empty);
            return new PaymentReceipt(receiptHeaderSection, receiptDetailSection, receiptFooterSection);
        }

    }
}
