
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EditSubscriptionForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadTextBox ClassTextBox { get => classTextBox; }
        public RadDropDownList SubscriptionDropDownList { get => subscriptionDropDownList; }
        public RadTextBox FeeTextBox { get => feeTextBox; }
        public RadTextBox DurationTextBox { get => durationTextBox; }
        public RadDateTimePicker StartDateTimePicker { get => startDateTimePicker; }
        public RadDateTimePicker EndDateTimePicker { get => endDateTimePicker; }
        public RadTextBox DiscountTextBox { get => discountTextBox; }
        public RadDropDownList PaymentMeanDropDownList { get => paymentMeanDropDownList; }
        public RadTextBox TransactionIdTextBox { get => transactionIdTextBox; }
        public RadDateTimePicker TransactionDateTimePicker { get => transactionDateTimePicker; }
        public RadTextBox DoneByTextBox { get => doneByTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }    
        public EditSubscriptionForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();           
        }

        private void InitLanguage()
        {
            studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            schoolYearLabel.Text = Language.labelSchoolYear + ":";
            classLabel.Text = Language.labelClass + ":";
            subscriptionLabel.Text = "<html>" + Language.labelSubscription + ":" + "<color=Red>*";
            dateLabel.Text = "<html>" + Language.labelStart + ":" + "<color=Red>*";
            endDateLabel.Text = "<html>" + Language.labelEnd + ":" + "<color=Red>*";
            paymentMeanLabel.Text = "<html>" + Language.labelPaymentMean + ":" + "<color=Red>*";
            discountLabel.Text = "<html>" + Language.labelDiscount + ":" + "<color=Red>*";
            feeLabel.Text = Language.labelSubscriptionFee + ":";
            transactionIdLabel.Text = Language.labelIdTransaction + ":";
            transactionDateLabel.Text = "<html>" + Language.labelDateTransaction + ":" + "<color=Red>*";
            durationLabel.Text = Language.labelDuration+":";
            doneByLabel.Text = Language.labelPaymentDoneBy + ":";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.discountTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !Helper.Helper.IsNumber(e.NewValue);
        }
        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            studentDropDownList.DropDownListElement.EnableElementShadow = false;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subscriptionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionLabel.LabelElement.CustomFontSize = 10.5f;
            this.subscriptionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.discountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.discountLabel.LabelElement.CustomFontSize = 10.5f;
            

            this.feeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.feeLabel.LabelElement.CustomFontSize = 10.5f;

            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;

            this.paymentMeanLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanLabel.LabelElement.CustomFontSize = 10.5f;

            this.transactionIdLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdLabel.LabelElement.CustomFontSize = 10.5f;

            this.transactionDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateLabel.LabelElement.CustomFontSize = 10.5f;


            this.durationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.durationLabel.LabelElement.CustomFontSize = 10.5f;

            this.endDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.endDateLabel.LabelElement.CustomFontSize = 10.5f;

            this.startDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.startDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.startDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.startDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.endDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.endDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.endDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.endDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.transactionDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.transactionDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.transactionDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.transactionDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;


            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.subscriptionDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.paymentMeanDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.doneByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.durationTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.durationTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.transactionIdTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.subscriptionDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subscriptionDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.paymentMeanDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanDropDownList.RootElement.CustomFontSize = 10.5f;
            this.paymentMeanDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.discountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.discountTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.feeTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.feeTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.editPanel.RootElement.EnableElementShadow = false;

            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }


            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subscriptionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.discountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.feeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.endDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.durationLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subscriptionDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.discountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.feeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.durationTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subscriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.discountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.feeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.durationSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.subscriptionDropDownList.DisplayMember = "Name";
            this.subscriptionDropDownList.ValueMember = "Id";

            this.startDateTimePicker.Value = DateTime.Now;
            this.endDateTimePicker.Value = DateTime.Now;
            this.transactionDateTimePicker.Value = DateTime.Now;

            this.paymentMeanDropDownList.DisplayMember = "FullName";
            this.paymentMeanDropDownList.ValueMember = "Id";
            feeTextBox.Text = "0";
            discountTextBox.Text = "0";
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;

            if (this.studentDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.studentDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.studentDropDownList.Focus();
                return false;
            }
           
            if (this.subscriptionDropDownList.SelectedItem == null)
            {
                this.errorProvider.SetError(this.subscriptionDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.subscriptionDropDownList.Focus();
                return false;
            }
            if (this.endDateTimePicker.Value < this.startDateTimePicker.Value)
            {
                this.errorProvider.SetError(this.endDateTimePicker, Language.messageEndDateGreaterThanStartDate);
                this.errorLabel.Text = Language.messageEndDateGreaterThanStartDate;
                this.endDateTimePicker.Focus();
                return false;
            }
            if (this.discountTextBox.Text == "")
            {
                this.errorProvider.SetError(this.discountTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.discountTextBox.Focus();
                return false;
            }

            if (this.paymentMeanDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.paymentMeanDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.paymentMeanDropDownList.Focus();
                return false;
            }
            if (transactionDateTimePicker.Text == "")
            {
                this.errorProvider.SetError(this.transactionDateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.transactionDateTimePicker.Focus();
                return false;
            }
          
            return true;
        }

    }
}
