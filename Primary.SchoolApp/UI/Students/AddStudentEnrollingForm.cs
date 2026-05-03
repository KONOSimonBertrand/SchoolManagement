using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.CustomElements;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Extensions;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static Telerik.WinControls.UI.DateInput;

namespace Primary.SchoolApp.UI
{
    internal class AddStudentEnrollingForm : SchoolManagement.UI.EditStudentEnrollingForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IPaymentMeanService paymentMeanService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly IPrintService printService;
        private readonly ClientApp clientApp;
        private SchoolYear selectedSchoolYear;
        private readonly IReceiptService receiptService;
        private readonly List<Subscription> subscriptionsToAdd;
        private readonly List<TuitionPayment> tuitionPaymentsToAdd;
        private readonly List<SchoolSupplie> schoolSuppliesToAdd;
        private readonly List<ReceiptItem> paymentList;
        private readonly ILogger<AddStudentEnrollingForm> logger;
        public AddStudentEnrollingForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, IPaymentMeanService paymentMeanService, ClientApp clientApp, IPrintService printService,
                                ISchoolClassService classService, ISchoolRoomService roomService, IStudentEnrollingService studentEnrollingService, IReceiptService receiptService, ILogger<AddStudentEnrollingForm> logger)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
            this.paymentMeanService = paymentMeanService;
            this.classService = classService;
            this.roomService = roomService;
            this.studentEnrollingService = studentEnrollingService;
            this.receiptService = receiptService;
            this.clientApp = clientApp;
            this.printService = printService;
            this.logger = logger;
            selectedSchoolYear = new SchoolYear();
            subscriptionsToAdd = new List<Subscription>();
            tuitionPaymentsToAdd = new List<TuitionPayment>();
            schoolSuppliesToAdd = new List<SchoolSupplie>();
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            PaymentMeanDropDownList.DataSource = Program.PaymentMeanList;
            PaymentMeanDropDownList.SelectedIndex = -1;
            paymentList = new List<ReceiptItem>();
            InitListView();
            InitEvents();
            CheckPermissions();
        }

        private void InitListView()
        {



            ListViewDetailColumn nameColumn = new("Product")
            {
                Width = FeesDropDownList.Width
            };
            this.InvoiceItemListView.Columns.Add(nameColumn);
            ListViewDetailColumn priceColumn = new("Price")
            {
                Width = AmountTextBox.Width
            };
            this.InvoiceItemListView.Columns.Add(priceColumn);



            ListViewDetailColumn totalToPaidLabelColumn = new("Total")
            {
                Width = FeesDropDownList.Width
            };
            InvoiceTotalListView.Columns.Add(totalToPaidLabelColumn);
            ListViewDetailColumn totalToPaidPriceColumn = new("TotalPrice")
            {
                Width = AmountTextBox.Width
            };
            InvoiceTotalListView.Columns.Add(totalToPaidPriceColumn);

        }

        // Chargement des frais à payer.
        private void LoadFeesList(int classId)
        {

            var InfoItemList = new List<FeeItem>();
            int i = 0;
            foreach (var fs in Program.SchoolingCostList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = fs.Amount,
                    Quantity = 1,
                    Name = fs.CashFlowType.Name,
                    Category = fs.CashFlowType.Category,
                    Description = $"{fs.CashFlowType.Name} | {fs.Amount} FCFA",
                    Tag = fs
                }
                    );
            }

            foreach (var ab in Program.SubscriptionFeeList.Where(x => x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = ab.Amount,
                    Quantity = 1,
                    Name = ab.CashFlowType.Name,
                    Category = ab.CashFlowType.Category,
                    Description = $"{ab.CashFlowType.Name} | {ab.Amount} FCFA",
                    Tag = ab
                }
                    );
            }

            foreach (var ff in Program.SchoolSupplieFeeList.Where(x => x.SchoolClassId == classId && x.SchoolYearId == selectedSchoolYear.Id))
            {
                InfoItemList.Add(new()
                {
                    Id = i++,
                    UnitPrice = ff.Amount,
                    Name = ff.CashFlowType.Name,
                    Category = ff.CashFlowType.Category,
                    Quantity = ff.RequiredQuantity,
                    Description = $"{ff.CashFlowType.Name} | {ff.Amount} FCFA",
                    Tag = ff
                }
                    );
            }

            FeesDropDownList.DataSource = null;
            FeesDropDownList.ValueMember = "Id";
            FeesDropDownList.DisplayMember = "Description";
            FeesDropDownList.DataSource = InfoItemList;

        }

        internal void Init(SchoolYear schoolYear)
        {
            EnrollingDateTimePicker.Value = DateTime.Now;
            selectedSchoolYear = schoolYear;
            AmountTextBox.Text = "0";
            AmountTextBox.Enabled = Program.UserConnected.Modules.Any(m => m.ModuleId == 3 && m?.AllowCreate == true);
            AddStudentButton.Enabled = Program.UserConnected.Modules.Any(m => m.ModuleId == 2);
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            AddStudentButton.Click += AddStudentButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            AddRoomButton.Click += AddRoomButton_Click;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;
            AmountTextBox.TextChanged += AmountTextBox_TextChanged;
            AmountTextBox.KeyDown += AmountTextBox_KeyDown; ;
            FeesDropDownList.SelectedValueChanged += FeesDropDownList_SelectedValueChanged;
            AddInvoiceItemButton.Click += AddInvoiceItemButton_Click;
            RemoveInvoiceItemButton.Click += RemoveInvoiceItemButton_Click;
            InvoiceItemListView.SelectedItemChanged += InvoiceItemListView_SelectedItemChanged;
            // StudentDropDownList.SelectedValueChanged += StudentDropDownList_SelectedValueChanged;
            StudentDropDownList.TextChanged += StudentDropDownList_TextChanged;
            StudentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;

        }

        private void AmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddInvoiceItem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (StudentDropDownList.SelectedIndex != -1)
            {
                if (StudentDropDownList.SelectedItem != null)
                {
                    if (StudentDropDownList.SelectedItem.Tag is Student student)
                    {
                        DateTime today = DateTime.Now;
                        int age = today.Year - student.BirthDate.Year;
                        if (student.BirthDate > today.AddYears(-age))
                        {
                            age--;
                        }

                        string info = string.Format("{0} {1} | {2} | {3}", age.ToString(), Language.LabelYearOld.ToLower(), student.Sex == "M" ? Language.LabelMale : Language.LabelFemale, student.BirthDate.ToString("dd/MM/yyyy"));
                        DoneByTextBox.Text = student.FullName;
                        StudentDropDownList.RootElement.ToolTipText = $"{student.FullName}\r {info}\r {Language.labelStudentId}: {student.IdNumber}\r{Language.labelPhone}: {student.Phone}\r {Language.labelAddress}: {student.Address}";
                    }
                    else
                    {
                        DoneByTextBox.Text = string.Empty;
                        StudentDropDownList.RootElement.ToolTipText = string.Empty;
                    }
                }
            }
        }

        private CancellationTokenSource searchCancellationTokenSource;

        private async Task SearchStudentsAsync(string searchItem, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(300, cancellationToken);
                var students = await studentService.GetStudentListsync(searchItem, cancellationToken);
                if (cancellationToken.IsCancellationRequested) return;
                StudentDropDownList.BeginUpdate();
                StudentDropDownList.Items.Clear();
                StudentDropDownList.AutoCompleteDataSource = null;
                foreach (var student in students)
                {
                    var item = new RadListDataItem
                    {
                        Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                        Value = student.Id,
                        Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                        Tag = student
                    };

                    StudentDropDownList.Items.Add(item);
                    StudentDropDownList.ShowDropDown();
                }
                StudentDropDownList.EndUpdate();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la recherche d'élèves");
            }
        }
        private async void StudentDropDownList_TextChanged(object sender, EventArgs e)
        {
            string searchItem = StudentDropDownList.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchItem) || searchItem.Length < 3)
            {
                if (StudentDropDownList.Items.Count > 0)
                    StudentDropDownList.Items.Clear();
                return;
            }
            if (searchItem.Contains('|'))
            {
                return;
            }

            searchCancellationTokenSource?.Cancel();
            searchCancellationTokenSource = new CancellationTokenSource();
            var token = searchCancellationTokenSource.Token;

            await SearchStudentsAsync(searchItem, token);
        }

        private void InvoiceItemListView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (InvoiceItemListView?.SelectedItem?.Tag is FeeItem receiptItem)
            {
                RemoveInvoiceItemButton.Enabled = true;
            }
        }

        private void RemoveInvoiceItemButton_Click(object sender, EventArgs e)
        {
            if (InvoiceItemListView.SelectedItem != null)
            {
                var feeItem = InvoiceItemListView.SelectedItem.Tag as FeeItem;

                int cashFlowTypeId = 0;
                switch (feeItem.Category)
                {
                    case "FS":
                        cashFlowTypeId = (feeItem.Tag as SchoolingCost)?.CashFlowTypeId ?? 0;
                        tuitionPaymentsToAdd.Remove(tuitionPaymentsToAdd.FirstOrDefault(t => t.CashFlowTypeId == cashFlowTypeId));
                        break;
                    case "AB":
                        cashFlowTypeId = (feeItem.Tag as SubscriptionFee)?.CashFlowTypeId ?? 0;
                        subscriptionsToAdd.Remove(subscriptionsToAdd.FirstOrDefault(s => s.CashFlowTypeId == cashFlowTypeId));
                        break;
                    case "FF":
                        cashFlowTypeId = (feeItem.Tag as SchoolSupplieFee)?.CashFlowTypeId ?? 0;
                        schoolSuppliesToAdd.Remove(schoolSuppliesToAdd.FirstOrDefault(s => s.CashFlowTypeId == cashFlowTypeId));
                        break;
                    default:

                        break;
                }
                this.InvoiceItemListView.Items.Remove(InvoiceItemListView.SelectedItem);
                decimal total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                InvoiceTotalListView.Items.Clear();
                ListViewDataItem totalItem = new();
                InvoiceTotalListView.Items.Add(totalItem);
                totalItem["Total"] = "Total";
                totalItem["TotalPrice"] = string.Format("{0} CFA", total);
                if (InvoiceItemListView.Items.Count == 0)
                {
                    RemoveInvoiceItemButton.Enabled = false;
                }
                paymentList.Remove(new ReceiptItem{
                    Id = feeItem.Id,
                }
                );
            }
        }

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
                ErrorProvider.SetError(this.PaymentMeanDropDownList, Language.messageFillField);
                this.ErrorLabel.Text = Language.messageFillField;
                this.PaymentMeanDropDownList.Focus();
                return;
            }
            ErrorLabel.Text = string.Empty;
            ErrorProvider.Clear();

            if (FeesDropDownList.SelectedIndex < 0)
            {
                ErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                FeesDropDownList.Focus();
                return;
            }
            if (double.TryParse(AmountTextBox.Text, out double amount) == false)
            {
                ErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                AmountTextBox.Focus();
                return;
            }

            if (amount <= 0)
            {
                ErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                AmountTextBox.Focus();
                return;
            }

            if (FeesDropDownList?.SelectedItem.DataBoundItem is FeeItem feeItem)
            {
                if (feeItem.Total < amount && feeItem.Category != "FF")
                {
                    ErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                    ErrorLabel.Text = $"{Language.labelAmountPaid}({amount}) > {Language.LabelFeesToPay}({feeItem.Total})";
                    AmountTextBox.Focus();
                    return;
                }

                // On vérifie si ça déjà été ajouté
                if (InvoiceItemListView.Items.Any(item => item["Product"].ToString() == feeItem.Name))
                {
                    ErrorProvider.SetError(FeesDropDownList, Language.messageFillField);
                    ErrorLabel.Text = Language.messageDataAlreadyExist;
                    FeesDropDownList.Focus();
                    return;
                }
                ListViewDataItem dataItem = new()
                {
                    Tag = feeItem
                };
                InvoiceItemListView.Items.Add(dataItem);
                dataItem["Product"] = feeItem.Name;
                dataItem["Price"] = string.Format("{0}", feeItem.Category != "FF" ? amount * 1 : feeItem.Total * amount);
                dataItem.Tag = feeItem;

                decimal total = InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"]));
                InvoiceTotalListView.Items.Clear();
                ListViewDataItem totalItem = new();
                InvoiceTotalListView.Items.Add(totalItem);
                totalItem["Total"] = "Total";
                totalItem["TotalPrice"] = string.Format("{0} CFA", total);
                FeesDropDownList.SelectedIndex = -1;
                AmountTextBox.Text = "0";

                switch (feeItem.Category)
                {
                    case "FS":
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
                            Balance=feeItem.Total-amount
                        });

                        break;
                    case "AB":
                        subscriptionsToAdd.Add(new Subscription()
                        {
                            Amount = amount,
                            CashFlowTypeId = (feeItem.Tag as SubscriptionFee)?.CashFlowTypeId ?? 0,
                            CashFlowType = (feeItem.Tag as SubscriptionFee).CashFlowType,
                            StartDate = StartDateTimePicker.Value,
                            EndDate = EndDateTimePicker.Value,
                            StudentId = (StudentDropDownList.SelectedItem?.DataBoundItem as Student)?.Id ?? 0,
                            Student = (StudentDropDownList.SelectedItem?.DataBoundItem as Student),
                            Discount = 0,
                            DoneBy = DoneByTextBox.Text,
                            SchoolYearId = selectedSchoolYear.Id,
                            SchoolYear = selectedSchoolYear,
                            TransactionDate = TransactionDateTimePicker.Value,
                            PaymentMean = PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean,
                            PaymentMeanId = (PaymentMeanDropDownList.SelectedItem?.DataBoundItem as PaymentMean)?.Id ?? 0,
                            TransactionId = TransactionIdTextBox.Text,
                            IsValidated = false,
                            Id = subscriptionsToAdd.Count + 1,
                        });

                        break;
                    case "FF":
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
                            Balance = (double)((feeItem.Tag as SchoolSupplieFee) ?.RequiredQuantity-amount)
                        }
                            );
                        break;
                }

                paymentList.Add(new ReceiptItem
                {
                    Id = feeItem.Id,
                    UnitPrice = amount,
                    Quantity = feeItem.Quantity,
                    For = feeItem.Name,
                    Balance = (feeItem.Tag as SchoolSupplieFee)?.RequiredQuantity - amount ?? feeItem.Total-amount,
                    Discount=0
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

        private void FeesDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FeesDropDownList.SelectedItem?.DataBoundItem is FeeItem receiptItem)
            {
                string info = string.Empty;
                this.AmountLabel.Visible = true;
                this.AmountTextBox.Visible = true;
                this.AmountSeparator.Visible = true;
                switch (receiptItem.Category)
                {
                    case "FS":
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.StartDateTimePicker.Visible = false;
                        this.EndDateTimePicker.Visible = false;
                        this.StartDateSeparator.Visible = false;
                        this.EndDateSeparator.Visible = false;
                        this.StartDateLabel.Visible = false;
                        this.EndDateLabel.Visible = false;
                        var fs = receiptItem.Tag as SchoolingCost;
                        info = $"{receiptItem.Name}\r {Language.labelAmount}: {receiptItem.Total}\r {Language.labelTrancheNumber}: {fs.TrancheNumber}";
                        break;
                    case "AB":
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
                    case "FF":
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

        private void OnShown(object sender, EventArgs e)
        {
            this.StudentDropDownList.Focus();
        }
        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem?.DataBoundItem is SchoolClass selectedRecord)
            {
                ClassDropDownList.RootElement.ToolTipText = selectedRecord.Name;
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedRecord.Id);
                var payments = GetInitialPaymentList(selectedRecord.Id);
                var amountToPaid = payments.Sum(x => x.Balance);
                // chargement de la liste des frais scolaire
                LoadFeesList(selectedRecord.Id);
                // ajout total des frais scolarité
                string totalText = Language.labelTuitionFees;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalText = $"{totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.French, Currency.CFA)}) ";
                }
                else
                {
                    totalText = $"{totalText}: {amountToPaid} CFA ( {amountToPaid.ToLetter(CountryLanguage.English, Currency.CFA)}) ";
                }
                InvoiceItemListView.Items.Clear();
                FeesTotalLabel.Text = totalText;
            }
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            if (RoomDropDownList.SelectedItem != null)
            {
                if (RoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom record)
                {
                    ShowSchoolRoomEditForm(record);
                }
            }
            else
            {
                ShowSchoolRoomAddForm();
            }
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem != null)
            {
                if (ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass record)
                {
                    ShowSchoolClassEditForm(record);
                }
            }
            else
            {
                ShowSchoolClassAddForm();
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.DataBoundItem is Student record)
                {
                    ShowStudentEditForm(record);
                }
            }
            else
            {
                ShowStudentAddForm();
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                var selectedStudent = StudentDropDownList.SelectedItem.Tag as Student;
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                var selectedRoom = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;

                if (!IsRecordExist(selectedStudent.Id, selectedSchoolYear.Id))
                {
                    if (!PaymentsExist())
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmEnrollingWithoutPayment, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                    var enrollingToAdd = new StudentEnrolling()
                    {
                        Date = EnrollingDateTimePicker.Value,
                        SchoolYear = selectedSchoolYear,
                        SchoolYearId = selectedSchoolYear.Id,
                        StudentId = selectedStudent.Id,
                        Student = selectedStudent,
                        ClassId = selectedClass.Id,
                        SchoolClass = selectedClass,
                        IsRepeater = (int)RepeaterDropDownList.SelectedValue != 0,
                        OldSchool = OldSchoolTextBox.Text,
                        DoneBy = DoneByTextBox.Text,
                    };
                    //enregistrement de l'inscription
                    var saveEnrollingIsDone = await studentEnrollingService.CreateStudentEnrollingAsync(enrollingToAdd);
                    if (saveEnrollingIsDone)
                    {
                        //enregistrement du log
                        Log logEnrol = new()
                        {
                            UserAction = $"Ajout de l'inscription de l'élève {enrollingToAdd.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        };
                        await logService.CreateLog(logEnrol);
                        logger.LogInformation("Ajout de l'inscription de l'élève {StudentName}  par l'utilisateur {UserName} sur le poste {IpAddress}", enrollingToAdd.Student.FullName, clientApp.UserConnected.UserName, clientApp.IpAddress);
                        //affectation d'une salle de classe
                        var studentRoom = new StudentRoom()
                        {
                            Room = selectedRoom,
                            RoomId = selectedRoom.Id,
                            StudentId = selectedStudent.Id,
                            Student = selectedStudent,
                            SchoolYear = selectedSchoolYear,
                            SchoolYearId = selectedSchoolYear.Id,
                            Note = Language.labelRegistration
                        };
                        var saveRoomIsDone = await studentEnrollingService.CreateStudentRoomAsync(studentRoom);
                        if (saveRoomIsDone)
                        {
                            Log logRoom = new()
                            {
                                UserAction = $"Affectation de la salle {studentRoom.Room.Name} à l'élève {studentRoom.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logRoom);
                            logger.LogInformation("Affectation de la salle {RoomName} à l'élève {StudentName}  par l'utilisateur {UserName}", studentRoom.Room.Name, studentRoom.Student.FullName, clientApp.UserConnected.UserName);
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
                                opFor += " & " + Language.LabelSupplies;
                            }
                            var paymentReceipt = await receiptService.CreateReceiptAsync(new Receipt()
                            {

                                SchoolYearId = selectedSchoolYear.Id,
                                SchoolYear = selectedSchoolYear,
                                Date = DateTime.Now,
                                Amount = (double)InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"])),
                                OpDoneBy = DoneByTextBox.Text,
                                OpFor = opFor,

                            });
                        }

                        if (PaymentsExist())
                        {
                            // Récupération de l'inscription précédemment enregistré
                            var enrolling = await studentEnrollingService.GetStudentEnrollingAsync(selectedStudent.Id, selectedSchoolYear.Id);
                            if (enrolling != null)
                            {
                                enrollingToAdd.Id = enrolling.Id;
                            }
                        }
                        //impression du reçu
                        await printService.PrintPaymentReceiptAsync(enrollingToAdd, false);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageAddError;
                    }
                }
                else
                {
                    DataErrorProvider.SetError(StudentDropDownList, Language.messageEnrollingExist);
                    ErrorLabel.Text = Language.messageEnrollingExist;
                }

            }
        }


        // show student UI for edit
        private void ShowStudentEditForm(Student student)
        {
            if (student != null)
            {
                var form = Program.ServiceProvider.GetService<EditStudentForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelStudent;
                form.Icon = this.Icon;
                form.Init(student);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                    StudentDropDownList.DataSource = null;
                    StudentDropDownList.DataSource = Program.StudentList;
                    StudentDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show student UI for add new
        private void ShowStudentAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddStudentForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelStudent;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                Program.StudentList.Add(data);
                StudentDropDownList.DataSource = null;
                StudentDropDownList.DataSource = Program.StudentList;
                StudentDropDownList.SelectedValue = data;
            }
        }
        // show class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.Icon = this.Icon;
                form.InitStartup(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassDropDownList.DataSource = null;
                    ClassDropDownList.DataSource = Program.SchoolClassList;
                    ClassDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show class UI for add new
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClass;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                ClassDropDownList.DataSource = null;
                ClassDropDownList.DataSource = Program.SchoolClassList;
                ClassDropDownList.SelectedValue = data;
            }
        }
        // show room UI for edit
        private void ShowSchoolRoomEditForm(SchoolRoom record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolRoomForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelRoom;
                form.Icon = this.Icon;
                form.Init(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                    RoomDropDownList.DataSource = null;
                    RoomDropDownList.DataSource = Program.SchoolRoomList;
                    RoomDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show room UI for add new
        private void ShowSchoolRoomAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolRoomForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelRoom;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                Program.SchoolRoomList.Add(data);
                RoomDropDownList.DataSource = null;
                RoomDropDownList.DataSource = Program.SchoolRoomList;
                RoomDropDownList.SelectedValue = data;
            }
        }
        //vérifie l'existence
        private bool IsRecordExist(int studentId, int schoolYearId)
        {
            if (Program.StudentEnrollingList.Where(x => x.StudentId == studentId && x.SchoolYearId == schoolYearId).Any())
            {
                return true;
            }
            else
            {
                return studentEnrollingService.GetStudentEnrollingAsync(studentId, schoolYearId).Result != null;
            }
        }

        // vérifie le paiement sera effectué lors de l'inscription
        private bool PaymentsExist()
        {
            double amount = 0;
            double.TryParse(AmountTextBox.Text, out amount);
            if (amount == 0)
            {
                return false;
            }
            return true;
        }


        // Génère une liste de payements pour l'initialisation du payments gridview
        private List<TuitionPayment> GetInitialPaymentList(int classId)
        {
            var recordList = new List<TuitionPayment>();
            //Récupération des frais  scolaires exigibles de l'année en cours.
            var feeList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            foreach (var fee in feeList)
            {
                recordList.Add(
                    new TuitionPayment()
                    {
                        CashFlowType = fee.CashFlowType,
                        CashFlowTypeId = fee.CashFlowType.Id,
                        Amount = 0,
                        Date = DateTime.Now,
                        TransactionDate = DateTime.Now,
                        PaymentMean = Program.PaymentMeanList.FirstOrDefault(),
                        PaymentMeanId = Program.PaymentMeanList.FirstOrDefault().Id,
                        Balance = feeList.Where(x => x.CashFlowTypeId == fee.CashFlowTypeId).Sum(x => x.Amount)
                    }
                    );
            }
            return recordList;
        }

        private void CheckPermissions()
        {
            this.InvoicePanel.Visible = Program.UserConnected.CanCreateTuitionFee();
        }
    }
}
