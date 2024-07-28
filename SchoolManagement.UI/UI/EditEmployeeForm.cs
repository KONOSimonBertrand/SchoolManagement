using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Languages;


namespace SchoolManagement.UI
{
    public partial class EditEmployeeForm : RadForm
    {

        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadButton AddGroupButton { get => addGroupButton; }
        public RadButton AddJobButton { get => addJobButton; }
        public  RadDropDownList JobDropDownList {  get => jobDropDownList; }
        public RadDropDownList GroupDropDownList {  get => groupDropDownList; }
        public RadTextBox SalaryTextBox {  get => salaryTextBox; }
        public RadTextBox IdCardTextBox {  get => idCardTextBox; }
        public RadDateTimePicker HiringDateDateTimePicker {  get => hiringDateDateTimePicker; }
        public RadTextBox AddressTextBox {  get => addressTextBox; }
        public RadTextBox EmailTextBox {  get => emailTextBox; }
        public RadTextBox PhoneTextBox {  get => phoneTextBox; }
        public RadDateTimePicker BirthdayDateTimePicker {  get => birthdayDateTimePicker; }
        public RadDropDownList SexDropDownList {  get => sexDropDownList; }
        public RadTextBox FirstNameTextBox {  get => firstNameTextBox; }
        public RadTextBox LastNameTextBox {  get => lastNameTextBox; }
        public RadTextBox IdNumberTextBox {  get => idNumberTextBox; }
        public RadDropDownList NationalityDropDownList {  get => nationalityDropDownList; }
        public RadDropDownList ReligionDropDownList {  get => religionDropDownList; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditEmployeeForm()
        {
            InitializeComponent();
            InitComponent();
            InitTheme();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.idNumberLabel.Text = Language.labelEmployeeId;
            this.firstNameLabel.Text = Language.labelFirstName;
            this.lastNameLabel.Text = Language.labelLastName;
            this.sexLabel.Text = Language.labelSex;
            this.birthdayLabel.Text = Language.labelBirthDate;
            this.nationalityLabel.Text=Language.labelNativeCountry;
            this.phoneLabel.Text = Language.labelPhone;
            this.addressLabel.Text = Language.labelAdddress;
            this.idCardLabel.Text = Language.labelIdCard;
            this.hiringDateLabel.Text = Language.labelHiringDate;
            this.emailLabel.Text= Language.labelMail;
            this.jobLabel.Text = Language.labelJob;
            this.groupLabel.Text = Language.labelGroup;
            this.salaryLabel.Text = Language.labelSalary;
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

            this.hiringDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.hiringDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.hiringDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.hiringDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idCardLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.idCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.idCardLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.salaryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.salaryLabel.LabelElement.CustomFontSize = 10.5f;
            this.salaryLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.salaryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.groupLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.jobLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.jobLabel.LabelElement.CustomFontSize = 10.5f;
            this.jobLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.jobLabel.TextAlignment = ContentAlignment.BottomLeft;

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
            this.birthdayDateTimePicker.CustomFormat = "dd-MM-yyyy";
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

            this.hiringDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.hiringDateDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.hiringDateDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.hiringDateDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.hiringDateDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.hiringDateDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.hiringDateDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.hiringDateDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.idCardTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.idCardTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idCardTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.salaryTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.salaryTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.salaryTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.groupDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.groupDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.jobDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.jobDropDownList.RootElement.CustomFontSize = 10.5f;
            this.jobDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.jobDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.groupDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.jobDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            this.idNumberSplitContainer.RootElement.EnableElementShadow = false;
            this.sexSplitContainer.RootElement.EnableElementShadow = false;
            this.salarySplitContainer.RootElement.EnableElementShadow = false;
            this.phoneSplitContainer.RootElement.EnableElementShadow = false;
            this.hiringDateSplitContainer.RootElement.EnableElementShadow = false;
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

            foreach (SplitPanel sp in this.salarySplitContainer.SplitPanels)
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
            foreach (SplitPanel sp in this.hiringDateSplitContainer.SplitPanels)
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
            this.hiringDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sexLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.phoneLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.addressLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.salaryLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.jobLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.religionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nationalityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.sexDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.jobDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.nationalityDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.nationalityDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.idNumberTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.firstNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.lastNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.salaryTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idCardTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.idNumberSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.lastNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.firstNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthdaySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.hiringDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.salarySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.jobSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nationalitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.religionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.religionDropDownList.DataSource = ViewUtilities.Religions();
            this.religionDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.religionDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            addJobButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouvelle fonction";
            addJobButton.Image = Resources.plus;
            addJobButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addJobButton.ButtonElement.Padding = new Padding(0);

            this.jobDropDownList.DisplayMember = "Name";
            this.jobDropDownList.ValueMember = "Id";

            addGroupButton.RootElement.ToolTipText = "Cliquer ici pour ajouter un groupe";
            addGroupButton.Image = Resources.plus;
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);

            this.groupDropDownList.DisplayMember = "Name";
            this.groupDropDownList.ValueMember = "Id";
            this.nationalityDropDownList.Text = "Cameroun";
            this.errorLabel.ForeColor = Color.Red;
            salaryTextBox.Text = "0";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            jobDropDownList.SelectedIndexChanged += JobDropDownList_SelectedIndexChanged;
            groupDropDownList.SelectedIndexChanged += GroupDropDownList_SelectedIndexChanged;
            salaryTextBox.TextChanging += SalaryTextBox_TextChanging;
        }
        private void InitTheme()
        {
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":

                    this.Icon = Resources.icon_orange;
                    break;
                case "MaterialBlueGrey":

                    this.Icon = Resources.icon_green;
                    break;
                case "MaterialPink":

                    this.Icon = Resources.icon_blue;
                    break;
                case "MaterialTeal":

                    this.Icon = Resources.icon_red;
                    break;

                default:
                    this.Icon = Resources.icon_pink;
                    break;
            }
        }
        private void SalaryTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }

        private void GroupDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (groupDropDownList.SelectedIndex < 0)
            {
                addGroupButton.Image = Resources.plus;
                addGroupButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer un nouveau groupe d'employés";
            }
            else
            {
                addGroupButton.Image = Resources.edit;
                addGroupButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations du groupe";
            }
        }

        private void JobDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (jobDropDownList.SelectedIndex < 0)
            {
                addJobButton.Image = Resources.plus;
                addJobButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer une nouvelle fonction";
            }
            else
            {
                addJobButton.Image = Resources.edit;
                addJobButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de la fonction";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.idNumberTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du matricule est requise!";
                this.idNumberTextBox.Focus();
                return false;
            }

            if (this.lastNameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du nom est requise!";
                this.lastNameTextBox.Focus();
                return false;
            }
            //if (this.firstNameTextBox.Text == "")
            //{
            //    this.errorLabel.Text = "La saisie du prénom est requise!";
            //    this.firstNameTextBox.Focus();
            //    return false;
            //}
            if (this.sexDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = "La sélection du sexe est requise!";
                this.sexDropDownList.Focus();
                return false;
            }

            if (this.jobDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = "La sélection d'une fonction est requise!";
                this.jobDropDownList.Focus();
                return false;
            }
            if (this.groupDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = "La sélection du groupe est requise!";
                this.groupDropDownList.Focus();
                return false;
            }

            return true;
        }
    }
}
