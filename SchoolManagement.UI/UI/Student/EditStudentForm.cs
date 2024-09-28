
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EditStudentForm :RadForm
    {
        public RadButton SaveButton { get=>saveButton;}
        public RadButton CloseButton { get=>closeButton;}
        public RadTextBox IdNumberTextBox { get=>idNumberTextBox;}
        public RadTextBox FirstNameTextBox { get=>firstNameTextBox;}
        public RadTextBox LastNameTextBox { get=>lastNameTextBox;}
        public RadDropDownList SexDropDownList {  get=>sexDropDownList;}
        public RadDateTimePicker BirthDayDateTimePicker { get=>birthdayDateTimePicker;}
        public RadTextBox BirthPlaceTextBox { get=>birthPlaceTextBox;}
        public RadDropDownList NationalityDropDownList {  get=>nationalityDropDownList;}
        public RadTextBox PhoneTextBox { get=>phoneTextBox;}
        public RadTextBox EmailTextBox { get=>emailTextBox;}
        public RadTextBox AddressTextBox { get=>addressTextBox;}
        public RadTextBox IdCardTextBox { get=>idCardTextBox;}
        public RadDropDownList ReligionDropDownList {get=>religionDropDownList;}
        public RadLabel ErrorLabel { get=>errorLabel;}
        public ErrorProvider ErrorProvider { get=>errorProvider;}
        public EditStudentForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.idNumberLabel.Text = "<html>" + Language.labelStudentId + ":" + "<color=Red>*";
            this.firstNameLabel.Text = Language.labelFirstName;
            this.lastNameLabel.Text = "<html>" + Language.labelLastName + ":" + "<color=Red>*";
            this.sexLabel.Text = "<html>" + Language.labelSex + ":" + "<color=Red>*";
            this.birthdayLabel.Text = "<html>" + Language.labelBirthDate + ":" + "<color=Red>*";
            this.nationalityLabel.Text = Language.labelNativeCountry;
            this.phoneLabel.Text = Language.labelPhone;
            this.addressLabel.Text = Language.labelAddress;
            this.idCardLabel.Text = Language.labelIdCard;
            this.birthplaceLabel.Text = Language.labelBirthPlace;
            this.emailLabel.Text = Language.labelMail;
            this.religionLabel.Text = Language.labelReligion;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {
            this.sexDropDownList.Items.Add(new RadListDataItem("Masculin", "M"));
            this.sexDropDownList.Items.Add(new RadListDataItem("Feminin", "F"));

            this.idNumberLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.idNumberLabel.LabelElement.CustomFontSize = 10.5f;
            this.idNumberLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idNumberLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.lastNameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.lastNameLabel.LabelElement.CustomFontSize = 10.5f;
            this.lastNameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.lastNameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.firstNameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.firstNameLabel.LabelElement.CustomFontSize = 10.5f;
            this.firstNameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.firstNameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.birthdayLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.birthdayLabel.LabelElement.CustomFontSize = 10.5f;
            this.birthdayLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.birthdayLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sexLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sexLabel.LabelElement.CustomFontSize = 10.5f;
            this.sexLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sexLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.phoneLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.phoneLabel.LabelElement.CustomFontSize = 10.5f;
            this.phoneLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.phoneLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.emailLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.emailLabel.LabelElement.CustomFontSize = 10.5f;
            this.emailLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.emailLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.addressLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.addressLabel.LabelElement.CustomFontSize = 10.5f;
            this.addressLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.addressLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.birthplaceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.birthplaceLabel.LabelElement.CustomFontSize = 10.5f;
            this.birthplaceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.birthplaceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idCardLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.idCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.idCardLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.religionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.religionLabel.LabelElement.CustomFontSize = 10.5f;
            this.religionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.religionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nationalityLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nationalityLabel.LabelElement.CustomFontSize = 10.5f;
            this.nationalityLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nationalityLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idNumberTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.idNumberTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idNumberTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.firstNameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.firstNameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.firstNameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.lastNameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.lastNameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.lastNameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.birthdayDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.birthdayDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.birthdayDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.birthdayDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.birthdayDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.birthdayDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.birthdayDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.birthdayDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.sexDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.sexDropDownList.RootElement.CustomFontSize = 10.5f;
            this.sexDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.sexDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.nationalityDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.nationalityDropDownList.RootElement.CustomFontSize = 10.5f;
            this.nationalityDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.nationalityDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.religionDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.religionDropDownList.RootElement.CustomFontSize = 10.5f;
            this.religionDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.religionDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.phoneTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.phoneTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.phoneTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.emailTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.emailTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.emailTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.addressTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.addressTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.addressTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.birthPlaceTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.birthPlaceTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.birthPlaceTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.idCardTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.idCardTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idCardTextBox.ForeColor = Color.FromArgb(33, 33, 33);
            this.editPanel.RootElement.EnableElementShadow = false;
            this.idNumberSplitContainer.RootElement.EnableElementShadow = false;
            this.sexSplitContainer.RootElement.EnableElementShadow = false;
            this.phoneSplitContainer.RootElement.EnableElementShadow = false;
            this.addressSplitContainer.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            foreach (SplitPanel sp in this.idNumberSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }

            foreach (SplitPanel sp in this.sexSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }

            foreach (SplitPanel sp in this.phoneSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.addressSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            this.idNumberLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.lastNameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.firstNameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.birthdayLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.birthplaceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sexLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.phoneLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.addressLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.religionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nationalityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.sexDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.nationalityDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.nationalityDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.idNumberTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.firstNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.lastNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idCardTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.birthPlaceTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.idNumberSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.lastNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.firstNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthdaySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthplaceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nationalitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.religionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.religionDropDownList.DataSource = ViewUtilities.Religions();
            this.religionDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.religionDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.nationalityDropDownList.Text = "Cameroun";
            this.errorLabel.ForeColor = Color.Red;

        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValidData()
        {

            this.errorLabel.Text = string.Empty;
            errorProvider.Clear();
            if (this.idNumberTextBox.Text == string.Empty)
            {
                this.errorProvider.SetError(idNumberTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.idNumberTextBox.Focus();
                return false;
            }

            if (this.lastNameTextBox.Text == string.Empty)
            {
                this.errorProvider.SetError(lastNameTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.lastNameTextBox.Focus();
                return false;
            }
            if (this.birthdayDateTimePicker.Text== string.Empty)
            {
                this.errorProvider.SetError(birthdayDateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.birthdayDateTimePicker.Focus();
                return false;
            }
            if (this.sexDropDownList.SelectedItem == null)
            {
                this.errorProvider.SetError(sexDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.sexDropDownList.Focus();
                return false;
            }



            return true;
        }
    }
}
