
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;

namespace SchoolManagement.UI.CustomControls
{
    public partial class SchoolYearInfo : UserControl
    {

        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox StartDateTextBox {  get => startDateTextBox; }
        public RadTextBox EndDateTextBox { get => endDateTextBox; }
        #endregion


        public SchoolYearInfo()
        {
            InitializeComponent();
            InitComponents();
            InitEvents();
        }
        private void InitComponents()
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

            this.startDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.startDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.startDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.startDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.endDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.endDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.endDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.endDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.startDateTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.startDateTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.startDateTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.endDateTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.endDateTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.endDateTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = DisplayStyle.Image;
            this.editButton.Image = Resources.edit;
            this.editButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations";

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = DisplayStyle.Image;
            this.closeButton.Image = Resources.not_clean;
            this.closeButton.RootElement.ToolTipText = "Cliquer ici pour fermer";

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.startDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.endDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.startDateTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.endDateTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
        }
        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}
