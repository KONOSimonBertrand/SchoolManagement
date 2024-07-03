using MediaFoundation;
using SchoolManagement.UI.Utilities;
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
        public RadLabel ErrorLabel{ get=>errorLabel;}
        public LoginForm()
        {
            InitializeComponent();
            InitComponent();
            InitTheme();
        }

        private void InitComponent()
        {
            this.loginLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.loginLabel.LabelElement.CustomFontSize = 10.5f;
            this.loginLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.loginLabel.TextAlignment = ContentAlignment.BottomLeft;

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

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.loginLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.passwordLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.userNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.passwordTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.userNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.passwordSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.connectionButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.connectionButton.ButtonElement.CustomFontSize = 10.5f;
            this.connectionButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
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

    }
}
