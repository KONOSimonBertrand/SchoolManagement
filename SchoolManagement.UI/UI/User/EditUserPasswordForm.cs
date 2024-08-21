
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
namespace SchoolManagement.UI
{
    public partial class EditUserPasswordForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox OldPasswordTextBox { get => oldPasswordTextBox; }
        public RadTextBox NewPasswordTextBox { get => newPasswordTextBox; }
        public RadToggleButton ShowPassWordToggleButton { get => showPasswordToggleButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditUserPasswordForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.oldPasswordLabel.Text = Language.labelOldPassword;
            this.newPasswordLabel.Text = Language.labelNewPasswors;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {

            this.oldPasswordLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.oldPasswordLabel.LabelElement.CustomFontSize = 10.5f;
            this.oldPasswordLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.oldPasswordLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.newPasswordLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.newPasswordLabel.LabelElement.CustomFontSize = 10.5f;
            this.newPasswordLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.newPasswordLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.newPasswordTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.newPasswordTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.newPasswordTextBox.ForeColor = Color.FromArgb(33, 33, 33);


            this.oldPasswordTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.oldPasswordTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.oldPasswordTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.oldPasswordLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.newPasswordLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.newPasswordTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.oldPasswordTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.oldPasswordSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.newPasswordSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            showPasswordToggleButton.RootElement.ToolTipText = Language.messageClickToSeePassword;
            showPasswordToggleButton.Image = ViewUtilities.GetImage("View");
            showPasswordToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            showPasswordToggleButton.ButtonElement.Padding = new Padding(0);

            this.errorLabel.ForeColor = Color.Red;
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            showPasswordToggleButton.CheckStateChanged += ShowPasswordToggleButton_CheckStateChanged; ;
           
        }

        private void ShowPasswordToggleButton_CheckStateChanged(object sender, EventArgs e)
        {
            if (showPasswordToggleButton.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off) {
                showPasswordToggleButton.Image = ViewUtilities.GetImage("View");
                showPasswordToggleButton.RootElement.ToolTipText = Language.messageClickToSeePassword;
                newPasswordTextBox.PasswordChar = '*';
            }
            else
            {
                showPasswordToggleButton.Image = ViewUtilities.GetImage("Hide");
                showPasswordToggleButton.RootElement.ToolTipText = Language.messageClickToHidePassword;
                newPasswordTextBox.PasswordChar= '\0';
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";

            if (this.oldPasswordTextBox.Text.Trim() == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.oldPasswordTextBox.Focus();
                return false;
            }
            if (this.newPasswordTextBox.Text.Trim() == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.newPasswordTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
