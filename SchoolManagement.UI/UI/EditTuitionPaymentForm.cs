
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace SchoolManagement.UI
{
    public partial class EditTuitionPaymentForm : RadForm
    {
        public RadDropDownList StudentDropDownList { get=>studentDropDownList;}
        public RadTextBox ClassTextBox { get=>classTextBox;}
        public RadTextBox SchoolYearTextBox { get=>schoolYearTextBox;}
        public RadDateTimePicker PaymentDateTimePicker { get=>dateTimePicker;}
        public RadDropDownList ReasonDropDownList { get=>cashFlowTypeDropDownList;}
        public RadTextBox CostTextBox { get=>costTextBox;}
        public RadTextBox DiscountTextBox { get=>discountTextBox;}
        public RadTextBox PaidTextBox { get=>paidTextBox;}
        public RadTextBox UnpaidTextBox { get=>unPaidTextBox;}
        public RadTextBox AmountTextBox { get=>amountTextBox;}
        public RadDropDownList PaymentMeanDropDownList { get=>paymentMeanDropDownList;} 
        public RadDateTimePicker TransactionDateTimePicker { get => transactionDateTimePicker;}
        public RadTextBox TransactionIdTextBox { get=>transactionIdTextBox;}
        public RadTextBox DoneByTextBox { get=>doneByTextBox;}
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel ErroLabel { get=>errorLabel;}
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditTuitionPaymentForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            this.classLabel.Text = Language.labelClass;
            this.schoolYearLabel.Text = Language.labelSchoolYear;
            this.dateLabel.Text = "<html> Date: <color=Red>*";
            cashFlowTypeLabel.Text =  "<html>" + Language.labelReason + ":" + "<color=Red>*";
            costLabel.Text = Language.labelAmount;
            discountLabel.Text = Language.labelDiscount;
            paidLabel.Text = Language.labelPaid;
            unPaidLabel.Text = Language.labelUnPaid;
            amountLabel.Text = "<html>" + Language.labelAmountPaid + ":" + "<color=Red>*";
            paymentMeanLabel.Text = "<html>" + Language.labelPaymentMean + ":" + "<color=Red>*";
            transactionDateLabel.Text= "<html>" + Language.labelDateTransaction + ":" + "<color=Red>*";
            transactionIdLabel.Text=Language.labelIdTransaction;
            doneByLabel.Text=Language.labelPaymentDoneBy;
            saveButton.Text = Language.labelSave;
            closeButton.Text=Language.labelCancel;
        }

            private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.amountTextBox.TextChanging += AmountTextBox_TextChanging;
        }
        private void AmountTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            
            studentDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            studentDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.cashFlowTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.cashFlowTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.cashFlowTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.transactionDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.unPaidLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.unPaidLabel.LabelElement.CustomFontSize = 10.5f;
            this.unPaidLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.unPaidLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costLabel.LabelElement.CustomFontSize = 10.5f;
            this.costLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.costLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;
            this.doneByLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.doneByLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.paymentMeanLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanLabel.LabelElement.CustomFontSize = 10.5f;
            this.paymentMeanLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.paymentMeanLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.discountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.discountLabel.LabelElement.CustomFontSize = 10.5f;
            this.discountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.discountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.paidLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paidLabel.LabelElement.CustomFontSize = 10.5f;
            this.paidLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.paidLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionIdLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionIdLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.transactionIdLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);


            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.classTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.doneByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.doneByTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.cashFlowTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.cashFlowTypeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.cashFlowTypeDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.paymentMeanDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanDropDownList.RootElement.CustomFontSize = 10.5f;
            this.paymentMeanDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.paymentMeanDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.cashFlowTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.paymentMeanDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.CustomFormat = "d/MM/yyyy";
            this.transactionDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.transactionDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.unPaidTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.unPaidTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.unPaidTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.costTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.costTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.costTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.discountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.discountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.discountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.paidTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.paidTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.paidTextBox.ForeColor = Color.FromArgb(33, 33, 33);


            this.transactionIdTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.transactionIdTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;


            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.cashFlowTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.unPaidLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paidLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.discountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.cashFlowTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.transactionIdLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.unPaidTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.costTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.discountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.paidTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.cashFlowTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.unPaidSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.discountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paidSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.cashFlowTypeDropDownList.DisplayMember = "Name";
            this.cashFlowTypeDropDownList.ValueMember = "Id";
            
            this.paymentMeanDropDownList.DisplayMember = "FullName";
            this.paymentMeanDropDownList.ValueMember = "Id";

            this.dateTimePicker.Value = DateTime.Now;
            this.transactionDateTimePicker.Value = DateTime.Now;
            this.errorLabel.ForeColor = Color.Red;
            this.amountTextBox.Text = "0";
            this.unPaidTextBox.Text = "0";
            this.discountTextBox.Text = "0";
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();

            if (this.studentDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(studentDropDownList, Language.messageFillField);
                this.studentDropDownList.Focus();
                return false;
            }
          
            
            if (dateTimePicker.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(dateTimePicker, Language.messageFillField);
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.cashFlowTypeDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(cashFlowTypeDropDownList, Language.messageFillField);
                this.cashFlowTypeDropDownList.Focus();
                return false;
            }

            if (this.amountTextBox.Text == "" || double.Parse(this.amountTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(amountTextBox, Language.messageFillField);
                this.amountTextBox.Focus();
                return false;
            }

            if (double.Parse(this.amountTextBox.Text) > double.Parse(this.unPaidTextBox.Text))
            {
                this.errorLabel.Text = Language.messagePaymentGreaterThanToPaid;
                this.errorProvider.SetError(amountTextBox, Language.messagePaymentGreaterThanToPaid);
                this.amountTextBox.Focus();
                return false;
            }
            if (transactionDateTimePicker.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(transactionDateTimePicker, Language.messageFillField);
                this.transactionDateTimePicker.Focus();
                return false;
            }

            if (this.paymentMeanDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(paymentMeanDropDownList, Language.messageFillField);
                this.paymentMeanDropDownList.Focus();
                return false;
            }
           
            return true;
        }

    }
}
