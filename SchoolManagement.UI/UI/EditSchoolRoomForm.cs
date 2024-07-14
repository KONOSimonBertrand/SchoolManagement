using MediaFoundation;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolRoomForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList ClassDropDownList { get => classDropDownList; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadButton AddClassButton { get => addClassButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditSchoolRoomForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            classDropDownList.SelectedIndexChanged += ClassDropDownList_SelectedIndexChanged;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.classDropDownList.RootElement.EnableElementShadow = false;

            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.classDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.classDropDownList.RootElement.CustomFontSize = 10.5f;
            this.classDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.classDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.sequenceLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sequenceSpinEditor.SpinElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }


            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addClassButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouvelle classe";
            addClassButton.Image = Resources.plus;
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.ButtonElement.Padding = new Padding(0);

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";
            this.classDropDownList.SelectedIndex = -1;
            this.errorLabel.ForeColor = Color.Red;

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


            if (this.classDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection de la salle est requise!";
                this.classDropDownList.Focus();
                return false;
            }

            return true;
        }

        private void ClassDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
            if (classDropDownList.SelectedIndex < 0)
            {
                addClassButton.Image = Resources.plus;
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer une nouvelle classe";
            }
            else
            {
                addClassButton.Image = Resources.edit;
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de la classe";
            }
        }

    }
}
