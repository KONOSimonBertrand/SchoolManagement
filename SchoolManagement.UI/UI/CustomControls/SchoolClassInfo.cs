
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class SchoolClassInfo : UserControl
    {
        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox GroupTextBox { get => groupTextBox; }
        public RadLabel SubjectsCountLabel { get => subjectsCountLabel; }
        #endregion
        public SchoolClassInfo()
        {
            InitializeComponent();
            InitComponent();
            InitEvents();
            InitLanguage();
        }

        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
            subjectsCountLabel.MouseMove += Label_MouseMove;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void InitComponent()
        {
            this.headerPanel.RootElement.EnableElementShadow = false;
           
            this.titleInfoLabel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.LabelElement.CustomFont =Utilities.ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.nameLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.groupLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.groupTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.groupTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.subjectsCountLabel.Image = Resources.eye;
            this.subjectsCountLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.subjectsCountLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.subjectsCountLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.subjectsCountLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectsCountLabel.ForeColor = Utilities.ViewUtilities.MainThemeColor;

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
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subjectsCountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.groupTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            subjectsCountLabel.LabelElement.ToolTipText = "Cliquer ici pour consulter les matières enseignées";
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

       private void InitLanguage()
        {
            nameLabel.Text = Languages.Language.labelDesignation;
            groupLabel.Text = Languages.Language.labelGroup;
        }
    }
}
