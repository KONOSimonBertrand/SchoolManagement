
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditEmployeeGroupForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditEmployeeGroupForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameLabel.Text = "<html>" + Language.labelDesignation + ":" + "<color=Red>*";
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

      

        private void InitComponent()
        {
            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.errorLabel.ForeColor = Color.Red;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = string.Empty;
            this.errorProvider.Clear();
            if (this.nameTextBox.Text == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.nameTextBox, Language.messageFillField);
                this.nameTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
