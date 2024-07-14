

using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolClassForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList GroupDropDownList {  get => groupDropDownList; }
        public RadDropDownList BookTypeDropDownList {  get => bookTypeDropDownList; }
        public RadSpinEditor SequenceSpinEditor {  get => sequenceSpinEditor; }
        public RadButton AddGroupButton { get => addGroupButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditSchoolClassForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
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
            this.bookTypeLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.bookTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.bookTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.bookTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.groupLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.bookModelLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.bookModelLabel.LabelElement.CustomFontSize = 10.5f;
            this.bookModelLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.bookModelLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sequenceLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

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

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;
            this.bookTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.bookTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.codeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addGroupButton.RootElement.ToolTipText = "Cliquer ici pour ajouter un nouveau groupe";
            addGroupButton.Image = Resources.plus;
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);
            this.groupDropDownList.DisplayMember = "Name";
            this.groupDropDownList.ValueMember = "Id";
            this.groupDropDownList.SelectedIndex = -1;

            this.bookTypeDropDownList.Items.Add(new RadListDataItem("Français uniquement", 0));
            this.bookTypeDropDownList.Items.Add(new RadListDataItem("Anglais uniquement", 1));
            this.bookTypeDropDownList.Items.Add(new RadListDataItem("Français & Anglais", 2));
            this.bookTypeDropDownList.SelectedIndex = 0;

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


            if (this.groupDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection du groupe est requise!";
                this.groupDropDownList.Focus();
                return false;
            }

            return true;
        }

        private void GroupDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (groupDropDownList.SelectedIndex < 0)
            {
                addGroupButton.Image = Resources.plus;
                addGroupButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer une nouveau groupe";
            }
            else
            {
                addGroupButton.Image = Resources.edit;
                addGroupButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations du groupe";
            }
        }

    }
}
