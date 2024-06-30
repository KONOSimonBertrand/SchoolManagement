using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolYearForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadLabel ErrorLabel {  get => errorLabel; }
        public RadDateTimePicker StartFirstQuarter {get=> startFirstQuarterDateTimePicker;}
        public RadDateTimePicker EndFirstQuarter {get=> endFirstQuarterDateTimePicker;}
        public RadDateTimePicker StartSecondQuarter {get=> startSecondQuarterDateTimePicker;}
        public RadDateTimePicker EndSecondQuarter {get=> endSecondQuarterDateTimePicker;}
        public RadDateTimePicker StartThirdQuarter {get=> startThirdQuarterDateTimePicker;}
        public RadDateTimePicker EndThirdQuarter {get=> endThirdQuarterDateTimePicker;}

        public EditSchoolYearForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }
        private void InitComponent()
        {

            this.nameLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.startFirstQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.startFirstQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.startFirstQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.startFirstQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.endFirstQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.endFirstQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.endFirstQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.endFirstQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.startSecondQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.startSecondQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.startSecondQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.startSecondQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.endSecondQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.endSecondQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.endSecondQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.endSecondQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.startThirdQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.startThirdQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.startThirdQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.startThirdQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.endThirdQuarterLabel.LabelElement.CustomFont = UiUtilities.MainFont;
            this.endThirdQuarterLabel.LabelElement.CustomFontSize = 10.5f;
            this.endThirdQuarterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.endThirdQuarterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = UiUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.startFirstQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.startFirstQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.startFirstQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.startFirstQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startFirstQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.startFirstQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startFirstQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startFirstQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.endFirstQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.endFirstQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.endFirstQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.endFirstQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endFirstQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.endFirstQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endFirstQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endFirstQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.startSecondQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.startSecondQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.startSecondQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.startSecondQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startSecondQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.startSecondQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startSecondQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startSecondQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.endSecondQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.endSecondQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.endSecondQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.endSecondQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endSecondQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.endSecondQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endSecondQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endSecondQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.startThirdQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.startThirdQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.startThirdQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.startThirdQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startThirdQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.startThirdQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startThirdQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startThirdQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.endThirdQuarterDateTimePicker.DateTimePickerElement.CustomFont = UiUtilities.MainFont;
            this.endThirdQuarterDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.endThirdQuarterDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.endThirdQuarterDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endThirdQuarterDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.endThirdQuarterDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endThirdQuarterDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endThirdQuarterDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);


            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }


            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startFirstQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endFirstQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startSecondQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endSecondQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startThirdQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endThirdQuarterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);


            this.saveButton.ButtonElement.CustomFont = UiUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.startFirstQuarterDateTimePicker.Value = DateTime.Now;
            this.endFirstQuarterDateTimePicker.Value = DateTime.Now;
            this.startSecondQuarterDateTimePicker.Value = DateTime.Now;
            this.endSecondQuarterDateTimePicker.Value = DateTime.Now;
            this.startThirdQuarterDateTimePicker.Value = DateTime.Now;
            this.endThirdQuarterDateTimePicker.Value = DateTime.Now;
        }
    private void InitEvent()
        {
            this.closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;
            if (this.nameTextBox.Text.Length < 9 || this.nameTextBox.Text.Length > 9)
            {
                this.errorLabel.Text = "Format incorrect! Exemple: 2019-2020";
                this.nameTextBox.Focus();
                return false;
            }

            if (this.nameTextBox.Text.Contains("-") == false)
            {
                this.errorLabel.Text = "Format incorrect! Exemple: 2019-2020";
                this.nameTextBox.Focus();
                return false;
            }

            if (int.TryParse(this.nameTextBox.Text.Substring(0, 4), out int y) == false)
            {
                this.errorLabel.Text = "Format incorrect! Exemple: 2019-2020";
                this.nameTextBox.Focus();
                return false;
            }
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la désignation est requise!";
                this.nameTextBox.Focus();
                return false;
            }
            if (this.startFirstQuarterDateTimePicker.Text == string.Empty)
            {
                this.errorLabel.Text = "La saisie de la date de début est requise!";
                this.startFirstQuarterDateTimePicker.Focus();
                return false;
            }
            if (this.endFirstQuarterDateTimePicker.Text == string.Empty)
            {
                this.errorLabel.Text = "La saisie de la date de fin est requise!";
                this.endFirstQuarterDateTimePicker.Focus();
                return false;
            }
            if (this.endFirstQuarterDateTimePicker.Value < this.startFirstQuarterDateTimePicker.Value)
            {
                this.errorLabel.Text = "La date de fin est inférieure à la date de fin!";
                this.endFirstQuarterDateTimePicker.Focus();
                return false;
            }


            return true;
        }


    }
}
