using Telerik.WinControls;
using Telerik.WinControls.UI;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;
namespace SchoolManagement.UI
{
    public partial class EditCashFlowTypeForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList CategoryDropDownList { get => categoryDropDownList; }
        public RadDropDownList TransactionTypeDropDownList { get => transactionTypeDropDownList; }
        public RadDropDownList FlowTypeDropDownList { get => flowTypeDropDownList; }
        public RadDropDownList FlowDomainDropDownList { get => flowDomainDropDownList; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadTextBox DescriptionTextBox { get => descriptionTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditCashFlowTypeForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.descriptionLabel.Text = Language.labelDescription;
            this.categoryLabel.Text = Language.labelCategory;
            this.transactionTypeLabel.Text=Language.LabelTransactionType;
            this.flowTypeLabel.Text = Language.LabelFlowType;
            this.flowDomainLabel.Text = Language.LabelDomain;
            this.nameLabel.Text = Language.labelDesignation;
            this.sequenceLabel.Text= Language.labelSequence;
            this.saveButton.Text= Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void InitComponent()
        {
           
            this.categoryDropDownList.RootElement.EnableElementShadow = false;
            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.categoryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.categoryLabel.LabelElement.CustomFontSize = 10.5f;
            this.categoryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.flowTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.flowTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.flowTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.flowDomainLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.flowDomainLabel.LabelElement.CustomFontSize = 10.5f;
            this.flowDomainLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.descriptionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionLabel.LabelElement.CustomFontSize = 10.5f;
            this.descriptionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
          
            this.descriptionTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.categoryDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.categoryDropDownList.RootElement.CustomFontSize = 10.5f;
            this.categoryDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.categoryDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.transactionTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.transactionTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.transactionTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.transactionTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.flowTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.flowTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.flowTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.flowTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.flowDomainDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.flowDomainDropDownList.RootElement.CustomFontSize = 10.5f;
            this.flowDomainDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.flowDomainDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.categoryLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.flowTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.flowDomainLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.descriptionTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.typeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.descriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.flowTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.flowDomainSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
           
            this.errorLabel.ForeColor = Color.Red;

        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.nameTextBox, Language.messageFillField);
                this.nameTextBox.Focus();
                return false;
            }
            if (this.categoryDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.categoryDropDownList, Language.messageFillField);
                this.categoryDropDownList.Focus();
                return false;
            }
            if (this.flowDomainDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.flowDomainDropDownList, Language.messageFillField);
                this.flowDomainDropDownList.Focus();
                return false;
            }
            if (this.transactionTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.transactionTypeDropDownList, Language.messageFillField);
                this.transactionTypeDropDownList.Focus();
                return false;
            }
            if (this.flowTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(this.flowTypeDropDownList, Language.messageFillField);
                this.flowTypeDropDownList.Focus();
                return false;
            }
            return true;
        }

    }
}
