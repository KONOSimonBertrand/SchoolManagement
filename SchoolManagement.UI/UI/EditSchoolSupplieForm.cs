
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace SchoolManagement.UI
{
    public partial class EditSchoolSupplieForm : RadForm
    {
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadDateTimePicker PaymentDateTimePicker { get => dateTimePicker; }
        public RadDropDownList ReasonDropDownList { get => cashFlowTypeDropDownList; }
        public RadTextBox QuantityTextBox { get => quantityTextBox; }
        public RadDropDownList PaymentMeanDropDownList { get => paymentMeanDropDownList; }
        public RadDateTimePicker TransactionDateTimePicker { get => transactionDateTimePicker; }
        public RadTextBox TransactionIdTextBox { get => transactionIdTextBox; }
        public RadTextBox DoneByTextBox { get => doneByTextBox; }
        public RadButton AddButton { get => addButton; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel ErroLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadGridView DataGridView { get => dataGridView; }
        public RadLabel StudentInfoLabel { get => studentInfoLabel; }
        public RadLabel SchoolSupplieInfoLabel { get => schoolSupplieInfoLabel; }
        public EditSchoolSupplieForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            this.dateLabel.Text = "<html> Date: <color=Red>*";
            cashFlowTypeLabel.Text = "<html>" + Language.LabelSchoolSupplie + ":" + "<color=Red>*";
            quantityLabel.Text = "<html>" + Language.LabelQuantity+ ":" + "<color=Red>*";
            paymentMeanLabel.Text = "<html>" + Language.labelPaymentMean + ":" + "<color=Red>*";
            transactionDateLabel.Text = "<html>" + Language.labelDateTransaction + ":" + "<color=Red>*";
            transactionIdLabel.Text = Language.labelIdTransaction;
            doneByLabel.Text = Language.labelPaymentDoneBy;
            saveButton.Text = Language.labelSave;
            closeButton.Text = Language.labelCancel;
            this.addButton.Text = Language.labelAdd;
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.quantityTextBox.TextChanging += AmountTextBox_TextChanging;
        }

        private void AmountTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !Helper.Helper.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {

            studentDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            studentDropDownList.DropDownListElement.EnableElementShadow = false;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.cashFlowTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.cashFlowTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.quantityLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.quantityLabel.LabelElement.CustomFontSize = 10.5f;
            this.quantityLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;
            this.doneByLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.paymentMeanLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanLabel.LabelElement.CustomFontSize = 10.5f;
            this.paymentMeanLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionIdLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionIdLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);


            this.doneByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.cashFlowTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.cashFlowTypeDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.paymentMeanDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanDropDownList.RootElement.CustomFontSize = 10.5f;
            this.paymentMeanDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.cashFlowTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.paymentMeanDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.quantityTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.quantityTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.CustomFormat = "d/MM/yyyy";
            this.transactionDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.transactionDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);



            this.transactionIdTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.editPanel.RootElement.EnableElementShadow = false;


            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.cashFlowTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.quantityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.cashFlowTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.transactionIdLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.quantityTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.cashFlowTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.quantitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolSupplieInfoSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentInfoSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.cashFlowTypeDropDownList.DisplayMember = "Name";
            this.cashFlowTypeDropDownList.ValueMember = "Id";

            this.paymentMeanDropDownList.DisplayMember = "FullName";
            this.paymentMeanDropDownList.ValueMember = "Id";

            this.dateTimePicker.Value = DateTime.Now;
            this.transactionDateTimePicker.Value = DateTime.Now;
            this.errorLabel.ForeColor = Color.Red;
            this.quantityTextBox.Text = "0";
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

            if (this.quantityTextBox.Text == "" || double.Parse(this.quantityTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(quantityTextBox, Language.messageFillField);
                this.quantityTextBox.Focus();
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
