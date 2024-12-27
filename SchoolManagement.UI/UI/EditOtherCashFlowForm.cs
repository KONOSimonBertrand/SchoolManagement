

using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;

namespace SchoolManagement.UI
{
    public partial class EditOtherCashFlowForm : RadForm
    {

        public RadDateTimePicker TransactionDateTimePicker { get => dateTimePicker; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadDropDownList CashFlowTypeDropDownList {  get => cashFlowTypeDropDownList; }
        public RadTextBox DoneByTextBox { get => doneByTextBox; }
        public RadTextBox NoteTextBox { get => noteTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public EditOtherCashFlowForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.dateLabel.Text = "<html>" + Language.labelDateTransaction + ":" + "<color=Red>*";
            this.amountLabel.Text = "<html>" + Language.labelAmount + ":" + "<color=Red>*";
            this.cashFlowTypeLabel.Text = "<html>" + Language.labelReason+ ":" + "<color=Red>*";
            this.doneByLabel.Text =Language.labelOrdoredBy+":";
            closeButton.Text = Language.labelCancel;
            saveButton.Text = Language.labelSave;
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TxtChanging);
        }

        private void TxtChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;
            this.doneByLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.doneByLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            cashFlowTypeDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            cashFlowTypeDropDownList.DropDownListElement.EnableElementShadow = false;
            cashFlowTypeDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.cashFlowTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.cashFlowTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.cashFlowTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.cashFlowTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.cashFlowTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.cashFlowTypeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.cashFlowTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.cashFlowTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;


            this.amountLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.noteLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.doneByTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.doneByTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.amountTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.noteTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;

            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.noteLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.cashFlowTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.noteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.cashFlowTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            errorLabel.ForeColor = Color.Red;
            this.dateTimePicker.Value = DateTime.Now;
            this.cashFlowTypeDropDownList.DisplayMember = "Name";
            this.cashFlowTypeDropDownList.ValueMember = "Id";
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (dateTimePicker.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(dateTimePicker, Language.messageFillField);
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.amountTextBox.Text == "" || double.Parse(this.amountTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(amountTextBox,Language.messageFillField);
                this.amountTextBox.Focus();
                return false;
            }
            if (this.cashFlowTypeDropDownList.Text == "")
            {
                this.errorProvider.SetError(cashFlowTypeDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.cashFlowTypeDropDownList.Focus();
                return false;
            }
            if (this.cashFlowTypeDropDownList.SelectedIndex<0)
            {
                this.errorProvider.SetError(cashFlowTypeDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.cashFlowTypeDropDownList.Focus();
                return false;
            }
            return true;
        }
    }
}
