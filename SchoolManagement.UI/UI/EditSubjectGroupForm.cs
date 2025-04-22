
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSubjectGroupForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox FrenchNameTextBox { get => nameFrTextBox; }
        public RadTextBox EnglishhNameTextBox { get => nameEnTextBox; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditSubjectGroupForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameFrLabel.Text = Language.labelFrenchName;
            this.nameEnLabel.Text = Language.labelEnglishName;
            this.sequenceLabel.Text = Language.labelSequence;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {
            this.nameFrLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameFrLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameFrLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameEnLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameEnLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameEnLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameFrTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.nameEnTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameFrTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameEnTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;
            this.nameFrSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameEnSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.errorLabel.ForeColor = Color.Red;
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            this.ThemeNameChanged += EditSubjectGroupForm_ThemeNameChanged;
        }

        private void EditSubjectGroupForm_ThemeNameChanged(object source, ThemeNameChangedEventArgs args)
        {
            if (ThemeResolutionService.ApplicationThemeName != "Windows11Dark")
            {
                this.nameFrTextBox.ForeColor = Color.FromArgb(33, 33, 33);
                this.nameEnTextBox.ForeColor = Color.FromArgb(33, 33, 33);
                this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
                this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.nameFrTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(this.nameFrTextBox, Language.messageFillField);
                this.nameFrTextBox.Focus();
                return false;
            }
            if (this.nameEnTextBox.Text == "")
            {

                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(this.nameEnTextBox, Language.messageFillField);
                this.nameEnTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
