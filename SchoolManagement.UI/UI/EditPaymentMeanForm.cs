



using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace SchoolManagement.UI
{
    public partial class EditPaymentMeanForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList TypeDropDownList { get => typeDropDownList; }
        public RadTextBox AccountTextBox { get => accountTextBox; }
        public RadSpinEditor SequenceSpinEditor { get=> sequenceSpinEditor; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditPaymentMeanForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }

        private void InitComponent()
        {
            this.nameLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.accountLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.accountLabel.LabelElement.CustomFontSize = 10.5f;
            this.accountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.accountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.typeLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.typeLabel.LabelElement.CustomFontSize = 10.5f;
            this.typeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.typeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.accountTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.accountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.accountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceSpinEditor.SpinElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;

            this.levelLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.levelLabel.LabelElement.CustomFontSize = 10.5f;
            this.levelLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.levelLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.typeDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.typeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.typeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.typeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.typeDropDownList.Items.Add(new RadListDataItem("Banque", "Banque"));
            this.typeDropDownList.Items.Add(new RadListDataItem("Caisse Scolaire", "Caisse Scolaire"));
            this.typeDropDownList.Items.Add(new RadListDataItem("Compte Scolaire", "Compte Scolaire"));
            this.typeDropDownList.Items.Add(new RadListDataItem("Mobile Money", "Mobile Money"));
            this.typeDropDownList.SelectedIndex = 0;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.typeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.accountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.typeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.levelSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.shortNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.errorLabel.ForeColor = Color.Red;

        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";

            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la désignation est requise!";
                this.nameTextBox.Focus();
                return false;
            }
            if (this.typeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "Le choix de la catégorie est requis!";
                this.typeDropDownList.Focus();
                return false;
            }
            return true;
        }
    }
}
