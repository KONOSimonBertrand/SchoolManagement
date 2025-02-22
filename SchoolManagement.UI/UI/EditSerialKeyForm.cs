

using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSerialKeyForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox SerialKeyTextBox { get => serialKeyTextBox; }
        public RadLabel SerialKeyUserLabel { get => serialKeyUserLabel; }
        public RadLabel SerialKeyTypeLabel {  get => serialKeyTypeLabel; }
        public RadLabel SerialKeyDurationLabel {  get => serialKeyDurationLabel; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditSerialKeyForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.serialKeyLabel.Text = "<html>Code:" + "<color=Red>*";
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void InitComponent()
        {
            this.serialKeyUserLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyUserLabel.LabelElement.CustomFontSize = 10.5f;
            this.serialKeyUserLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.serialKeyUserLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.serialKeyLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyLabel.LabelElement.CustomFontSize = 10.5f;
            this.serialKeyLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.serialKeyLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.serialKeyUserLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyUserLabel.LabelElement.CustomFontSize = 10.5f;
            this.serialKeyUserLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.serialKeyUserLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.serialKeyTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.serialKeyTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.serialKeyTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.serialKeyDurationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyDurationLabel.LabelElement.CustomFontSize = 10.5f;
            this.serialKeyDurationLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.serialKeyDurationLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.serialKeyTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.serialKeyTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.serialKeyTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }


            this.serialKeyUserLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.serialKeyDurationLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.serialKeyTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.serialKeyLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.serialKeyTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.serialKeySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.errorLabel.ForeColor = Color.Red;
            this.serialKeyUserLabel.Text=string.Empty;
            this.serialKeyTypeLabel.Text = string.Empty;
            this.serialKeyDurationLabel.Text = string.Empty;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.serialKeyTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.serialKeyTextBox, Language.messageFillField);
                this.serialKeyTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
