
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditEmployeeAccountTransactionForm : RadForm
    {
        public RadLabel ErrorLabel { get => errorLabel; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadTextBox ReasonTextBox { get => reasonTextBox; }
        public RadDateTimePicker TransactionDateTimePicker {  get => transactionDateTimePicker; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public EditEmployeeAccountTransactionForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.dateLabel.Text = "<html>Date:<color=Red>*";
            this.amountLabel.Text = $"<html>{Language.labelAmount} :<color=Red>*";
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text=Language.labelCancel;
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            this.amountTextBox.TextChanging += AmountTextBox_TextChanging;
        }

       

        private void AmountTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }

        private void InitComponent()
        {
            this.errorLabel.ForeColor = Color.Red;
            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reasonLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.reasonLabel.LabelElement.CustomFontSize = 10.5f;
            this.reasonLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.reasonLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.reasonTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.reasonTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.reasonTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.transactionDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.transactionDateTimePicker.DateTimePickerElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reasonLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.reasonTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.reasonSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.Value = DateTime.Now;
            this.transactionDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.transactionDateTimePicker.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.transactionDateTimePicker.Focus();
                return false;
            }
            if (this.amountTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.amountTextBox.Focus();
                return false;
            }
            
            if (this.amountTextBox.Text == "0")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.amountTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
