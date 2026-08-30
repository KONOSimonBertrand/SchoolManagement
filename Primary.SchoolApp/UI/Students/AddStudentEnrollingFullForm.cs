using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Extensions;
using Primary.SchoolApp.Mapping;
using Primary.SchoolApp.Services;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.UI
{
    internal class AddStudentEnrollingFullForm : SchoolManagement.UI.EditStudentEnrollingFullForm
    {
        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISchoolSupplieService supplieService;
        private readonly IPrintService printService;
        private readonly ClientApp clientApp;
        private SchoolYear selectedSchoolYear;
        private readonly IReceiptService receiptService;
        private readonly List<Subscription> subscriptionsToAdd;
        private readonly List<TuitionPayment> tuitionPaymentsToAdd;
        private readonly List<SchoolSupplie> schoolSuppliesToAdd;
        private readonly List<ReceiptItem> paymentList;
        private readonly ILogger<AddStudentEnrollingFullForm> logger;
        public AddStudentEnrollingFullForm(ILogService logService, IStudentService studentService, ICashFlowService cashFlowService, ClientApp clientApp, IPrintService printService,
                                ISchoolClassService classService, ISchoolRoomService roomService, IStudentEnrollingService studentEnrollingService, IReceiptService receiptService, ILogger<AddStudentEnrollingFullForm> logger,
                                ISubscriptionService subscriptionService, ISchoolSupplieService supplieService)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.cashFlowService = cashFlowService;
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
            InitEvents();
            CheckPermissions();
            this.subscriptionService = subscriptionService;
            this.supplieService = supplieService;
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
                    Category = TypeFee.TuitionFee,
                    Description = $"{fs.CashFlowType.Name} | {string.Format("{0:C2}",fs.Amount)}",
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
                    Category = TypeFee.Subscription,
                    Description = $"{ab.CashFlowType.Name} | {string.Format("{0:C2}", ab.Amount)}",
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
                    Category = TypeFee.SchoolSupply,
                    Quantity =ff.RequiredQuantity,
                    Description = $"{ff.CashFlowType.Name} | {string.Format("{0:C2}", ff.Amount)}",
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
            StudentDropDownList.TextChanged += StudentDropDownList_TextChanged;
            StudentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
            InvoiceItemListView.KeyDown += InvoiceItemListView_KeyDown;

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

        private void InvoiceItemListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                RemoveInvoiceItem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (StudentDropDownList.SelectedIndex != -1 && StudentDropDownList.SelectedItem != null)
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

        // Permet de supprimer un item de la liste des items à payer
        private void RemoveInvoiceItemButton_Click(object sender, EventArgs e)
        {
            RemoveInvoiceItem();
        }

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
            if (amount <= 0)
            {
                DataErrorProvider.SetError(AmountTextBox, Language.messageFillField);
                ErrorLabel.Text = Language.messageFillField;
                AmountTextBox.Focus();
                return;
            }
            if (FeesDropDownList?.SelectedItem.DataBoundItem is FeeItem feeItem)
            {
                
                if(feeItem.Total < amount && feeItem.Category != TypeFee.SchoolSupply)
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
                double price = amount;
                if (feeItem.Category == TypeFee.SchoolSupply) price = feeItem.UnitPrice * amount;
                dataItem["Item"] = feeItem.Name;
                dataItem["Price"] = string.Format("{0}", price);

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
                totalItem["TotalPrice"] = string.Format("{0:C2}", total)+ " "+totalToLetter;
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
                    case  TypeFee.Subscription:
                        subscriptionsToAdd.Add(new Subscription()
                        {
                            Amount = amount,
                            CashFlowTypeId = (feeItem.Tag as SubscriptionFee)?.CashFlowTypeId ?? 0,
                            CashFlowType = (feeItem.Tag as SubscriptionFee).CashFlowType,
                            StartDate = StartDateTimePicker.Value,
                            EndDate = EndDateTimePicker.Value,
                            DoneBy = DoneByTextBox.Text,
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
                if (feeItem.Tag  is SchoolSupplieFee supplieFee)
                {
                  unitPrice= supplieFee.Amount;
                  quantity= amount;
                  balance = (supplieFee.Amount * supplieFee.RequiredQuantity) - (unitPrice * quantity);
                  balance = balance < 0 ? 0 : balance;
                }
                paymentList.Add(new ReceiptItem
                {
                    Id = feeItem.Id,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    ItemName = feeItem.Category ==TypeFee.SchoolSupply?feeItem.Name+ " ("+Language.LabelQuantity+": "+ quantity+")" : feeItem.Name,
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

        private void FeesDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FeesDropDownList.SelectedItem?.DataBoundItem is FeeItem receiptItem)
            {
                string info = string.Empty;
                this.AmountLabel.Visible = true;
                this.AmountTextBox.Visible = true;
                this.AmountTextBox.ReadOnly = false;
                this.AmountSeparator.Visible = true;
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
                        info = $"{receiptItem.Name}\r {Language.labelAmount}: {receiptItem.Total}\r {Language.labelTrancheNumber}: {fs.TrancheNumber}";
                        break;
                    case TypeFee.Subscription:
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.AmountTextBox.ReadOnly = true;
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
                        this.AmountLabel.Text = Language.labelAmount;
                        this.AmountTextBox.Text = receiptItem.UnitPrice.ToString();
                        this.AmountTextBox.ReadOnly = true;
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
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.French)}) ";
                }
                else
                {
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.English)}) ";
                }
                InvoiceItemListView.Items.Clear();
                FeesTotalLabel.Text = totalText;
            }
        }

        // Permet l'ajout d'une salle de classe
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
        // Permet l'ajout d'une classe
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

        // permet l'ajout d'un élève, si un élève est sélectionné, on ouvre le formulaire d'édition de l'élève, sinon on ouvre le formulaire d'ajout d'un nouvel élève
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.Tag is Student student)
                {
                    ShowStudentEditForm(student);
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
                this.SaveButton.Enabled = false;
                var selectedStudent = StudentDropDownList.SelectedItem.Tag as Student;
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                var selectedRoom = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                // vérification d'une inscription liée à l'élève
                if (!IsRecordExist(selectedStudent.Id, selectedSchoolYear.Id))
                {
                    if (paymentList.Count == 0)
                    {
                        DialogResult dialogResult = RadMessageBox.Show(Language.messageConfirmEnrollingWithoutPayment, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                    //enregistrement de l'inscription
                    var saveEnrollingIsDone = await studentEnrollingService.CreateStudentEnrollingAsync(new StudentEnrolling()
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
                    }
                    );
                    if (saveEnrollingIsDone)
                    {
                        //enregistrement du log
                        await logService.CreateLog(new()
                        {
                            UserAction = $"Ajout de l'inscription de l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                            UserId = clientApp.UserConnected.Id
                        }
                        );
                        logger.LogInformation("Ajout de l'inscription de l'élève {StudentName}  par l'utilisateur {UserName} sur le poste {IpAddress}", selectedStudent.FullName, clientApp.UserConnected.UserName, clientApp.IpAddress);
                        //affectation d'une salle de classe
                        var saveRoomIsDone = await studentEnrollingService.CreateStudentRoomAsync(new StudentRoom()
                        {
                            Room = selectedRoom,
                            RoomId = selectedRoom.Id,
                            StudentId = selectedStudent.Id,
                            Student = selectedStudent,
                            SchoolYear = selectedSchoolYear,
                            SchoolYearId = selectedSchoolYear.Id,
                            Note = Language.labelRegistration
                        }
                        );
                        if (saveRoomIsDone)
                        {
                            Log logRoom = new()
                            {
                                UserAction = $"Affectation de la salle {selectedRoom.Name} à l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logRoom);
                            logger.LogInformation("Affectation de la salle {RoomName} à l'élève {StudentName}  par l'utilisateur {UserName}", selectedRoom.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                        }
                        else
                        {
                            logger.LogError("Erreur lors de l'affectation de la salle {RoomName} à l'élève {StudentName}  par l'utilisateur {UserName}", selectedRoom.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                        }
                        // Récupération de l'inscription précédemment enregistré
                        var enrollingAdded = await studentEnrollingService.GetStudentEnrollingAsync(selectedStudent.Id, selectedSchoolYear.Id);
                        if (enrollingAdded != null)
                        {
                            // Enregistrement du reçu de paiement
                            if (InvoiceItemListView.Items.Any())
                            {
                                var opFor = string.Empty;
                                if (tuitionPaymentsToAdd.Any())
                                {
                                    opFor += Language.labelTuitionFees;
                                }
                                if (subscriptionsToAdd.Any() && tuitionPaymentsToAdd.Any())
                                {
                                    opFor += " & " + Language.labelSubscriptions;
                                }
                                else
                                {
                                    if (subscriptionsToAdd.Any()) opFor = Language.labelSubscriptions;
                                }
                                if (schoolSuppliesToAdd.Any() && subscriptionsToAdd.Any() || schoolSuppliesToAdd.Any() && tuitionPaymentsToAdd.Any())
                                {
                                    opFor += " & " + Language.LabelSchoolSupplie;
                                }
                                else
                                {
                                    if (schoolSuppliesToAdd.Any()) opFor = Language.LabelSchoolSupplie;
                                }
                                var receipt = await receiptService.CreateReceiptAsync(new Receipt()
                                {
                                    SchoolYearId = selectedSchoolYear.Id,
                                    SchoolYear = selectedSchoolYear,
                                    Date = DateTime.Now,
                                    Amount = (double)InvoiceItemListView.Items.Sum(i => Convert.ToDecimal(i["Price"])),
                                    OpDoneBy = DoneByTextBox.Text,
                                    OpFor = opFor,
                                    Balance = paymentList.Sum(x => x.Balance)
                                });
                                if(receipt != null)
                                {
                                    Log logReceipt = new()
                                    {
                                        UserAction = $"Enregistrement du reçu de paiement N° {receipt.IdNumber} pour l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                        UserId = clientApp.UserConnected.Id
                                    };
                                    await logService.CreateLog(logReceipt);
                                    logger.LogInformation("Enregistrement du reçu de paiement N° {ReceiptId} pour l'élève {StudentName}  par l'utilisateur {UserName}", receipt.IdNumber, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                    // Enregistrement des frais
                                    if (tuitionPaymentsToAdd.Count > 0)
                                    {
                                        foreach (var t in tuitionPaymentsToAdd)
                                        {
                                            t.EnrollingId = enrollingAdded.Id;
                                            t.Enrolling = enrollingAdded;
                                            t.ReceiptId = receipt.Id;
                                            t.Receipt = receipt;
                                            if (await cashFlowService.CreateTuitionPayment(t) == true)
                                            {
                                                Log logTuitionPayment = new()
                                                {
                                                    UserAction = $"Enregistrement du paiement de frais scolarité  {t?.CashFlowType?.Name} pour l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                                    UserId = clientApp.UserConnected.Id
                                                };
                                                await logService.CreateLog(logTuitionPayment);
                                                logger.LogInformation("Enregistrement du paiement de frais scolarité  {TuitionPaymentName} pour l'élève {StudentName}  par l'utilisateur {UserName}", t?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                            else
                                            {
                                                logger.LogError("Une erreur est survenue lors de l'enregistrement du paiement de frais scolarité  {TuitionPaymentName} pour l'élève {StudentName}  par l'utilisateur {UserName}", t?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                        }
                                    }
                                    if (subscriptionsToAdd.Count > 0)
                                    {
                                        foreach (var s in subscriptionsToAdd)
                                        {
                                            s.EnrollingId = enrollingAdded.Id;
                                            s.Enrolling = enrollingAdded;
                                            s.Receipt = receipt;
                                            s.ReceiptId = receipt.Id;

                                            if (await subscriptionService.CreateSubscriptionAsync(s) == true)
                                            {
                                                Log logSubscription = new()
                                                {
                                                    UserAction = $"Enregistrement de l'abonnement  {s?.CashFlowType?.Name} pour l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                                    UserId = clientApp.UserConnected.Id
                                                };
                                                await logService.CreateLog(logSubscription);
                                                logger.LogInformation("Enregistrement de l'abonnement {SubscriptionName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                            else
                                            {
                                                logger.LogError("Une erreur est survenue lors de l'enregistrement de l'abonnement {SubscriptionName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                        }
                                    }
                                    if (schoolSuppliesToAdd.Count > 0)
                                    {
                                        foreach (var s in schoolSuppliesToAdd)
                                        {
                                            s.Receipt = receipt;
                                            s.ReceiptId = receipt.Id;
                                            s.Enrolling = enrollingAdded;
                                            s.EnrollingId = enrollingAdded.Id;
                                            if (await supplieService.CreateSchoolSupplie(s) == true)
                                            {
                                                Log logSupplie = new()
                                                {
                                                    UserAction = $"Enregistrement du fournitures scolaires  {s?.CashFlowType?.Name} pour l'élève {selectedStudent.FullName}  par l'utilisateur {clientApp.UserConnected.UserName}  sur le poste {clientApp.IpAddress}",
                                                    UserId = clientApp.UserConnected.Id
                                                };
                                                await logService.CreateLog(logSupplie);
                                                logger.LogInformation("Enregistrement  fourniture scolaire  {SupplieName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                            else
                                            {
                                                logger.LogError("Une erreur est survenue lors de l'enregistrement  fourniture scolaire  {SupplieName} pour l'élève {StudentName}  par l'utilisateur {UserName}", s?.CashFlowType?.Name, selectedStudent.FullName, clientApp.UserConnected.UserName);
                                            }
                                        }
                                    }
                                    //impression du reçu
                                    var receiptToPrint = receipt.AsReceiptDTO();
                                    AppUtilities.GenerateReceiptItems(receiptToPrint, tuitionPaymentsToAdd, subscriptionsToAdd, schoolSuppliesToAdd);
                                    Program.ReceiptList.Add(receiptToPrint);
                                    await printService.PrintReceiptAsync(receiptToPrint, false);
                                }
                                else
                                {
                                    logger.LogError("Erreur lors de l'enregistrement du reçu de paiement pour l'élève {StudentName}  par l'utilisateur {UserName}", selectedStudent.FullName, clientApp.UserConnected.UserName);
                                }
                               
                            }
                        }
                        this.DialogResult = DialogResult.OK;
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
                this.SaveButton.Enabled = true;
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
                    var item = new RadListDataItem
                    {
                        Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                        Value = student.Id,
                        Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                        Tag = student
                    };
                    StudentDropDownList.Items.Clear();
                    StudentDropDownList.DataSource = null;
                    StudentDropDownList.Items.Add(item);
                    StudentDropDownList.SelectedValue = student.Id;
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
                var student = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                var item = new RadListDataItem
                {
                    Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                    Value = student.Id,
                    Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                    Tag = student
                };
                StudentDropDownList.Items.Clear();
                StudentDropDownList.DataSource = null;
                StudentDropDownList.Items.Add(item);
                StudentDropDownList.SelectedValue = student.Id;
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

        // Permet d'afficher ou de masquer le panel des frais à payer selon les permissions de l'utilisateur connecté
        private void CheckPermissions()
        {
            this.InvoicePanel.Visible = Program.UserConnected.CanCreateTuitionFee();
            this.AddStudentButton.Visible = Program.UserConnected.CanCreateStudent();
            this.AddClassButton.Visible = Program.UserConnected.HasSettingPagePermission();
            this.AddRoomButton.Visible = Program.UserConnected.HasSettingPagePermission(); 
        }
      
    }
}
