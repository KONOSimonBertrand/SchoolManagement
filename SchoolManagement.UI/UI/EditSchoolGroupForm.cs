using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
namespace SchoolManagement.UI
{
    public partial class EditSchoolGroupForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadDropDownList IsTruncateDropDownList { get => isTruncateDropDownList; }
        public RadDropDownList DocumentTemplateDropDownList { get => documentTemplateDropDownList; }
        public RadDropDownList AverageFormulaDropDownList { get => averageFormulaDropDownList; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditSchoolGroupForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameLabel.Text = "<html>" + Language.labelDesignation+ ":" + "<color=Red>*";
            this.sequenceLabel.Text=Language.labelSequence;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
            this.averageFormulaLabel.Text = "<html>" + Language.LabelAverageFormula + ":" + "<color=Red>*";
            this.isTruncateLabel.Text = Language.LabelEnableNoteTruncation + ":";
            this.documentTemplateLabel.Text = "<html>" + Language.LabelDocumentTemplate + ":" + "<color=Red>*";
            this.isTruncateDropDownList.Items.Add(new RadListDataItem(Language.labelYes, 1));
            this.isTruncateDropDownList.Items.Add(new RadListDataItem(Language.labelNo, 0));
            this.isTruncateDropDownList.SelectedValue = 0;


        }
        private void InitComponent()
        {
            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.documentTemplateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.documentTemplateLabel.LabelElement.CustomFontSize = 10.5f;
            this.documentTemplateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.documentTemplateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.isTruncateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.isTruncateLabel.LabelElement.CustomFontSize = 10.5f;
            this.isTruncateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.isTruncateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.averageFormulaLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.averageFormulaLabel.LabelElement.CustomFontSize = 10.5f;
            this.averageFormulaLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.averageFormulaLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.isTruncateDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.isTruncateDropDownList.RootElement.CustomFontSize = 10.5f;
            this.isTruncateDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.averageFormulaDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.averageFormulaDropDownList.RootElement.CustomFontSize = 10.5f;
            this.averageFormulaDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.documentTemplateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.averageFormulaLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.isTruncateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.bookTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.isTruncateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.averageFormulaSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelFrenchOnly, 0));
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelEnglishOnly, 1));
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelFrenchAndEnglish, 2));
            this.documentTemplateDropDownList.SelectedIndex = 0;


            this.averageFormulaDropDownList.Items.Add(new RadListDataItem(Language.LabelFormulaWithoutCoef, 0));
            this.averageFormulaDropDownList.Items.Add(new RadListDataItem(Language.LabelFormulaWithCoef, 1));
            this.averageFormulaDropDownList.SelectedIndex = 0;

            this.errorLabel.ForeColor = Color.Red;

        }
        private void InitEvent()
        {
            this.closeButton.Click += CloseButton_Click;
            this.ThemeNameChanged += EditSchoolGroupForm_ThemeNameChanged;
        }

        private void EditSchoolGroupForm_ThemeNameChanged(object source, ThemeNameChangedEventArgs args)
        {
            if (ThemeResolutionService.ApplicationThemeName != "Windows11Dark")
            {
                this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);
                this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);
                this.isTruncateDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
                this.averageFormulaDropDownList.ForeColor = Color.FromArgb(33, 33, 33);

            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(this.nameTextBox, Language.messageFillField);
                this.nameTextBox.Focus();
                return false;
            }
            if (this.averageFormulaDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(averageFormulaDropDownList, Language.messageFillField);
                this.nameTextBox.Focus();
            }
            if (this.documentTemplateDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(documentTemplateDropDownList, Language.messageFillField);
                this.nameTextBox.Focus();
            }

            return true;
        }
    }
}
