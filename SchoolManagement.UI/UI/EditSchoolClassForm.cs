using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolClassForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList GroupDropDownList { get => groupDropDownList; }
        public RadDropDownList IsTruncateDropDownList { get => isTruncateDropDownList; }
        public RadDropDownList DocumentTemplateDropDownList { get => documentTemplateDropDownList; }
        public RadDropDownList ReportCardDropDownList {  get => reportCardDropDownList; }
        public RadDropDownList AverageFormulaDropDownList {  get => averageFormulaDropDownList; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadButton AddGroupButton { get => addGroupButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditSchoolClassForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameLabel.Text =  "<html>" + Language.labelDesignation + ":" + "<color=Red>*"; ;
            this.sequenceLabel.Text = Language.labelSequence;
            this.groupLabel.Text = "<html>" + Language.labelGroup + ":" + "<color=Red>*";
            this.averageFormulaLabel.Text = "<html>" + Language.LabelAverageFormula + ":" + "<color=Red>*";
            this.reportCardLabel.Text = "<html>" + Language.LabelReportCardModel+ ":" + "<color=Red>*";
            isTruncateLabel.Text = Language.LabelEnableNoteTruncation+":";
            this.documentTemplateLabel.Text =  "<html>" + Language.LabelDocumentTemplate + ":" + "<color=Red>*";
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
            this.isTruncateDropDownList.Items.Add(new RadListDataItem(Language.labelYes, 1));
            this.isTruncateDropDownList.Items.Add(new RadListDataItem(Language.labelNo, 0));
            this.isTruncateDropDownList.SelectedValue= 0;
        }
        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            groupDropDownList.SelectedIndexChanged += GroupDropDownList_SelectedIndexChanged;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.documentTemplateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.documentTemplateLabel.LabelElement.CustomFontSize = 10.5f;
            this.documentTemplateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.documentTemplateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.groupLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.isTruncateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.isTruncateLabel.LabelElement.CustomFontSize = 10.5f;
            this.isTruncateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.isTruncateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sequenceLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.averageFormulaLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.averageFormulaLabel.LabelElement.CustomFontSize = 10.5f;
            this.averageFormulaLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.averageFormulaLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reportCardLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.reportCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.reportCardLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.reportCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceSpinEditor.SpinElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);

            this.groupDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.groupDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.isTruncateDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.isTruncateDropDownList.RootElement.CustomFontSize = 10.5f;
            this.isTruncateDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.isTruncateDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.averageFormulaDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.averageFormulaDropDownList.RootElement.CustomFontSize = 10.5f;
            this.averageFormulaDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.averageFormulaDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.reportCardDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.reportCardDropDownList.RootElement.CustomFontSize = 10.5f;
            this.reportCardDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.reportCardDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;
            this.documentTemplateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.averageFormulaLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reportCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.isTruncateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.bookTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.codeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.isTruncateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.averageFormulaSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.reportCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            addGroupButton.Image = ViewUtilities.GetImage("Add");
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);
            this.groupDropDownList.DisplayMember = "Name";
            this.groupDropDownList.ValueMember = "Id";
            this.groupDropDownList.SelectedIndex = -1;
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelFrenchOnly, 0));
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelEnglishOnly, 1));
            this.documentTemplateDropDownList.Items.Add(new RadListDataItem(Language.labelFrenchAndEnglish, 2));
            this.documentTemplateDropDownList.SelectedIndex = 0;

            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelFoundationModel, 0));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelKindergartenModel, 1));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelPrimaryModel, 2));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelHighSchoolModel, 3));
            this.reportCardDropDownList.SelectedIndex = 0;

            this.averageFormulaDropDownList.Items.Add(new RadListDataItem(Language.LabelFormulaWithoutCoef, 0));
            this.averageFormulaDropDownList.Items.Add(new RadListDataItem(Language.LabelFormulaWithCoef, 1));
            this.averageFormulaDropDownList.SelectedIndex = 0;

            this.errorLabel.ForeColor = Color.Red;

        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(nameTextBox, Language.messageFillField);
                this.nameTextBox.Focus();
                return false;
            }


            if (this.groupDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(groupDropDownList, Language.messageFillField);
                this.groupDropDownList.Focus();
                return false;
            }

            return true;
        }

        private void GroupDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (groupDropDownList.SelectedIndex < 0)
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            }
            else
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

    }
}
