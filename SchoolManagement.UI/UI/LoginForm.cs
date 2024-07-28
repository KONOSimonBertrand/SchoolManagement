using SchoolManagement.UI.Languages;
using SchoolManagement.UI.Utilities;
using System.Globalization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class LoginForm : RadForm
    {

        public PictureBox PictureLogo{ get=>pictureLogo;}
        public RadTextBox PasswordTextBox{ get=>passwordTextBox;}
        public RadTextBox UserNameTextBox{ get=>userNameTextBox;}
        public RadButton ConnectionButton{ get=>connectionButton;}
        public RadButton OutButton {  get=>cancelButton;}
        public RadLabel ErrorLabel{ get=>errorLabel;}
        public RadDropDownList LanguageDropDownList {  get=>languageDropDownList;}

        private RadListDataItem frenchLanguage ;
        private RadListDataItem englishLanguage;
        public LoginForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitTheme();
        }
        private void InitEvent()
        {
            languageDropDownList.SelectedIndexChanged += LanguageDropDownList_SelectedIndexChanged;
        }

        private void LanguageDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
            InitLanguage();
        }

        private void InitComponent()
        {
            frenchLanguage = new("Français", "fr-FR");
            englishLanguage = new("Anglais", "en-GB");
            this.languageDropDownList.Items.Add(frenchLanguage);
            this.languageDropDownList.Items.Add(englishLanguage);

            this.languageLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.languageLabel.LabelElement.CustomFontSize = 10.5f;
            this.languageLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.languageLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.userNameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.userNameLabel.LabelElement.CustomFontSize = 10.5f;
            this.userNameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.userNameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.userNameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.userNameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.userNameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.passwordLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.passwordLabel.LabelElement.CustomFontSize = 10.5f;
            this.passwordLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.passwordLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.passwordTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.passwordTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.passwordTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.languageDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.languageDropDownList.RootElement.CustomFontSize = 10.5f;
            this.languageDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.languageDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.userNameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.passwordLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.languageLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.userNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.passwordTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.userNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.passwordSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            
            this.connectionButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.connectionButton.ButtonElement.CustomFontSize = 10.5f;
            this.connectionButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.cancelButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.cancelButton.ButtonElement.CustomFontSize = 10.5f;
            this.cancelButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            languageDropDownList.SelectedIndex = 0;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(LanguageDropDownList.SelectedValue.ToString());

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

        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;
            if (this.userNameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du nom utilisateur est requise!";
                this.userNameTextBox.Focus();
                return false;
            }
            if (this.passwordTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du mot de passe est requise!";
                this.passwordTextBox.Focus();
                return false;
            }
           
            return true;
        }
        private void InitLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(LanguageDropDownList.SelectedValue.ToString());
            languageLabel.Text = Language.labelLangue;
            passwordLabel.Text = Language.labelPassword;
            userNameLabel.Text = Language.labelUserName;
            OutButton.Text = Language.labelCancel;
            connectionButton.Text = Language.labelConnection;
            
            if (languageDropDownList.SelectedIndex == 0)
            {
                frenchLanguage.Text = "Français";
                englishLanguage.Text = "Anglais";
            }
            else
            {
                frenchLanguage.Text = "French";
                englishLanguage.Text = "English";
            }
        }
    }
}
