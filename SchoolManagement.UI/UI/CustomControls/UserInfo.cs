using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class UserInfo : UserControl
    {
        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox LoginTextBox { get => loginTextBox; }
        public RadTextBox DefaultModuleTextBox { get => defaultModuleTextBox; }
        public RadLabel ModuleCount { get=>moduleCountLabel; }
        public RadLabel RoomCount { get => roomCountLabel; }
        #endregion
        public UserInfo()
        {
            InitializeComponent();
            InitComponent();
            InitEvents();
            InitLanguage();
        }

        private void InitComponent()
        {
            this.headerPanel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.LabelElement.CustomFont = ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.loginLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.loginLabel.LabelElement.CustomFontSize = 10.5f;
            this.loginLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.loginLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.defaultModuleLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.defaultModuleLabel.LabelElement.CustomFontSize = 10.5f;
            this.defaultModuleLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.defaultModuleLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.moduleCountLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.moduleCountLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.moduleCountLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.moduleCountLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.moduleCountLabel.LabelElement.CustomFontSize = 10.5f;

            this.roomCountLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.roomCountLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.roomCountLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.roomCountLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.roomCountLabel.LabelElement.CustomFontSize = 10.5f;


            this.loginTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.loginTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.loginTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.defaultModuleTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.defaultModuleTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.defaultModuleTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

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

            this.loginLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.defaultModuleLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.loginTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.defaultModuleTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.loginSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.defaultModuleSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
        }

        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
            moduleCountLabel.MouseMove += Label_MouseMove;
            roomCountLabel.MouseMove += Label_MouseMove;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void InitLanguage()
        {
            nameLabel.Text = Language.labelName;
            this.loginLabel.Text = Language.labelUserName;
            this.moduleCountLabel.Text = Language.labelModules;
            this.defaultModuleLabel.Text = Language.labelDefaultModule;
            this.roomCountLabel.Text = Language.labelRooms;
        }
        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
