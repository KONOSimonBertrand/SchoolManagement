

using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class RatingSystemInfo : UserControl
    {
        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox MinNoteTextBox { get => noteMinTextBox; }
        public RadTextBox MaxNoteTextBox { get => noteMaxTextBox; }
        public RatingSystemInfo()
        {
            InitializeComponent();
            InitComponent();
            InitEvents();
            InitLanguage();
        }

        private void InitComponent()
        {
            this.titleInfoLabel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.LabelElement.CustomFont = ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteMinLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteMinLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteMinLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteMinLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteMaxLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteMaxLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteMaxLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteMaxTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteMaxTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteMinTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteMinTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteMinTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.editButton.Image = Resources.edit;
            this.editButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations";

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = Resources.not_clean;
            this.closeButton.RootElement.ToolTipText = "Cliquer ici pour fermer";

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteMaxLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteMinLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteMinTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteMaxTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteMinSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteMaxSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

        }
        private void InitLanguage()
        {
            nameLabel.Text = Language.labelAppreciation;
            noteMaxLabel.Text = Language.labelMaxNote;
            noteMinLabel.Text = Language.labelMinNote;
        }
        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
