
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolForm : RadForm
    {
        public RadTextBox NameTextBox { get=>nameTextBox;}
        public RadTextBox MottoTextBox { get=>mottoTextBox;}
        public RadDropDownList EvaluationModelDropDownList {  get=>evaluationModelDropDownList;}
        public RadTextBox CityTextBox { get=>cityTextBox;}
        public RadTextBox PostBoxTextBox { get=>postBoxTextBox;}
        public RadTextBox AddressTextBox { get=>addressTextBox;}
        public RadTextBox PhoneTextBox { get=>phoneTextBox;}
        public RadTextBox WebsiteTextBox { get=>websiteTextBox;}
        public RadTextBox EmailTextBox { get=>emailTextBox;}
        public RadTextBox FacebookTextBox { get=>facebookTextBox;}
        public RadDropDownList HeadMasterTypeDropDownList {  get=>headMasterTypeDropDownList;}
        public RadTextBox HeadMasterNameTextBox {  get=>headMasterNameTextBox;}
        public RadDropDownList HeadMasterSexDropDownList {  get=>headMasterSexDropDownList;}
        public RadTextBox StudentPictureDirectoryTextBox { get=>studentPictureDirectoryTextBox;}
        public RadTextBox EmployeePictureDirectoryTextBox { get => employeePictureDirectoryTextBox; }
        public RadLabel ErrorLabel { get=>errorLabel;}
        public ErrorProvider ErrorProvider { get=>errorProvider;}   
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public EditSchoolForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameLabel.Text = "<html>" + Language.labelDesignation + ":" + "<color=Red>*";
            this.mottoLabel.Text = Language.LabelMotto;
            this.evaluationModelLabel.Text="<html>" + Language.LabelEvaluationModel + ":" + "<color=Red>*";
            this.cityLabel.Text = Language.LabelCity;
            this.postBoxLabel.Text=Language.LabelPostBox;
            this.addressLabel.Text=Language.LabelLocalization;
            this.websiteLabel.Text=Language.LabelWebsite;
            this.phoneLabel.Text = Language.labelPhone;
            this.emailLabel.Text=Language.labelMail;
            this.headMasterTypeLabel.Text = "<html>" + Language.LabelHeadMasterType + ":" + "<color=Red>*";
            this.headMasterNameLabel.Text = "<html>" + Language.LabelHeadMasterName + ":" + "<color=Red>*";
            this.headMasterSexLabel.Text = "<html>" + Language.LabelHeadMasterSex + ":" + "<color=Red>*";
            this.studentPictureDirectoryLabel.Text = Language.LabelStudentPictureDirectory;
            this.employeePictureDirectoryLabel.Text = Language.LabelEmployeePictureDirectory;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {
            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.mottoLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.mottoLabel.LabelElement.CustomFontSize = 10.5f;
            this.mottoLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.evaluationModelLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationModelLabel.LabelElement.CustomFontSize = 10.5f;
            this.evaluationModelLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.cityLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.cityLabel.LabelElement.CustomFontSize = 10.5f;
            this.cityLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.postBoxLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.postBoxLabel.LabelElement.CustomFontSize = 10.5f;
            this.postBoxLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.addressLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.addressLabel.LabelElement.CustomFontSize = 10.5f;
            this.addressLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.phoneLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.phoneLabel.LabelElement.CustomFontSize = 10.5f;
            this.phoneLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.websiteLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.websiteLabel.LabelElement.CustomFontSize = 10.5f;
            this.websiteLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.emailLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.emailLabel.LabelElement.CustomFontSize = 10.5f;
            this.emailLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.facebookLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.facebookLabel.LabelElement.CustomFontSize = 10.5f;
            this.facebookLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.facebookLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.headMasterTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.headMasterTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.headMasterNameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterNameLabel.LabelElement.CustomFontSize = 10.5f;
            this.headMasterNameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.headMasterSexLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterSexLabel.LabelElement.CustomFontSize = 10.5f;
            this.headMasterSexLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentPictureDirectoryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentPictureDirectoryLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentPictureDirectoryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.employeePictureDirectoryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.employeePictureDirectoryLabel.LabelElement.CustomFontSize = 10.5f;
            this.employeePictureDirectoryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.mottoTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.mottoTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.evaluationModelDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationModelDropDownList.RootElement.CustomFontSize = 10.5f;
            this.evaluationModelDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.cityTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.cityTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.postBoxTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.postBoxTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.addressTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.addressTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.phoneTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.phoneTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.websiteTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.websiteTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.emailTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.emailTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.facebookTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.facebookTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.headMasterTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.headMasterTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.headMasterNameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterNameTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.headMasterSexDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.headMasterSexDropDownList.RootElement.CustomFontSize = 10.5f;
            this.headMasterSexDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.studentPictureDirectoryTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.studentPictureDirectoryTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.employeePictureDirectoryTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.employeePictureDirectoryTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.mottoTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.cityTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.postBoxTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.websiteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.facebookTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.headMasterNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.studentPictureDirectoryTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.employeePictureDirectoryTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.mottoSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.evaluationModelSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.citySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.postBoxSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.websiteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.facebookSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.headMasterTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.headMasterNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.headMasterSexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentPictureDirectorySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.employeePictureDirectorySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;

            this.errorLabel.ForeColor = Color.Red;
            this.evaluationModelDropDownList.Items.Add(new RadListDataItem(Language.LabelFirstModel, 0));
            this.evaluationModelDropDownList.Items.Add(new RadListDataItem(Language.LabelSecondModel, 1));

            this.headMasterTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelTheDirector, 0));
            this.headMasterTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelTheProviseur, 1));
            this.headMasterTypeDropDownList.Items.Add(new RadListDataItem(Language.LabelThePrincipal, 2));
            this.headMasterSexDropDownList.Items.Add(new RadListDataItem(Language.LabelMale, "M"));
            this.headMasterSexDropDownList.Items.Add(new RadListDataItem(Language.LabelFemale, "F"));
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = string.Empty;

            if (this.nameTextBox.Text == string.Empty)
            {
                this.errorProvider.SetError(this.nameTextBox,Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.nameTextBox.Focus();
                return false;
            }
            if (this.evaluationModelDropDownList.SelectedIndex<0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(evaluationModelDropDownList, Language.messageFillField);
                this.mottoTextBox.Focus();
                return false;
            }
            if (this.headMasterNameTextBox.Text == string.Empty)
            {
                this.errorProvider.SetError(this.headMasterNameTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.nameTextBox.Focus();
                return false;
            }
            if (this.headMasterTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(headMasterTypeDropDownList, Language.messageFillField);
                this.mottoTextBox.Focus();
                return false;
            }
            if (this.headMasterSexDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(headMasterSexDropDownList, Language.messageFillField);
                this.mottoTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
