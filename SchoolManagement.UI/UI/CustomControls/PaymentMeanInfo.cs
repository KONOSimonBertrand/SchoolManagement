

using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class PaymentMeanInfo : UserControl
    {
        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox AccountTextBox { get => accountTextBox; }
        public RadTextBox TypeTextBox { get => typeTextBox; }
        #endregion
        public PaymentMeanInfo()
        {
            InitializeComponent();
            InitComponent();
            InitEvents();
            InitLanguage();
        }

        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void InitComponent()
        {
            this.headerPanel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.LabelElement.CustomFont = ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.accountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.accountLabel.LabelElement.CustomFontSize = 10.5f;
            this.accountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.accountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.typeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.typeLabel.LabelElement.CustomFontSize = 10.5f;
            this.typeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.typeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);
            this.typeTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.typeTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.typeTextBox.ForeColor = Color.FromArgb(33, 33, 33);
            this.accountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.accountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.accountTextBox.ForeColor = Color.FromArgb(33, 33, 33);


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

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.accountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.typeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.accountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.typeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
        }
        private void InitLanguage()
        {
            nameLabel.Text = Language.labelDesignation;
            accountLabel.Text=Language.labelAccount;
            this.typeLabel.Text= Language.labelCategory;
        }
    }
}
