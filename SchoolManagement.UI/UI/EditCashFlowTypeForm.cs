using Telerik.WinControls;
using Telerik.WinControls.UI;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Languages;

namespace SchoolManagement.UI
{
    public partial class EditCashFlowTypeForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList CategoryDropDownList { get => categoryDropDownList; }
        public RadDropDownList DomainDropDownList { get => domainDropDownList; }
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
            this.domainLabel.Text=Language.labelDomain;
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
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.categoryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.categoryLabel.LabelElement.CustomFontSize = 10.5f;
            this.categoryLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.categoryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.domainLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.domainLabel.LabelElement.CustomFontSize = 10.5f;
            this.domainLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.domainLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.descriptionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionLabel.LabelElement.CustomFontSize = 10.5f;
            this.descriptionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.descriptionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.descriptionTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.descriptionTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.categoryDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.categoryDropDownList.RootElement.CustomFontSize = 10.5f;
            this.categoryDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.categoryDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.categoryDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.domainDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.domainDropDownList.RootElement.CustomFontSize = 10.5f;
            this.domainDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.domainDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.domainDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            domainDropDownList.Items.Add(new RadListDataItem("Finance", "Finance"));
            domainDropDownList.Items.Add(new RadListDataItem("Transport", "Transport"));
            domainDropDownList.Items.Add(new RadListDataItem("Cantine", "Cantine"));
            domainDropDownList.Items.Add(new RadListDataItem("Activité Périscolaire", "Activité Périscolaire"));
            domainDropDownList.Items.Add(new RadListDataItem("Autre", "Autre"));

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.descriptionTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.typeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.domainSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.descriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            RadListDataItem scItem = new RadListDataItem("Frais de scolarité", "FS");
            RadListDataItem stItem = new RadListDataItem("Abonnement", "AB");
            RadListDataItem saItem = new RadListDataItem("Salaire", "SA");
            RadListDataItem deItem = new RadListDataItem("Dépense", "DE");
            RadListDataItem apItem = new RadListDataItem("Approvisionnement", "AP");
            categoryDropDownList.Items.Add(scItem);
            categoryDropDownList.Items.Add(stItem);
            categoryDropDownList.Items.Add(saItem);
            categoryDropDownList.Items.Add(deItem);
            categoryDropDownList.Items.Add(apItem);
            this.errorLabel.ForeColor = Color.Red;

        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";

            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la désignation est requise!";
                this.nameTextBox.Focus();
                return false;
            }
            if (this.categoryDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'une catégorie est requise!";
                this.categoryDropDownList.Focus();
                return false;
            }

            return true;
        }

    }
}
