using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class SchoolInfo : UserControl
    {
        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel SerialKeyLabel { get => serialKeyLabel; }
        public RadLabel SerialKeyUserLabel { get => serialKeyUserLabel; }
        public RadLabel SerialKeyTypeLabel { get => serialKeyTypeLabel; }
        public RadLabel SerialKeyDurationLabel { get => serialKeyDurationLabel; }
        public RadButton SerialKeyButton { get => serialKeyButton; }
        public SchoolInfo()
        {
            InitializeComponent();
            InitComponent();
            InitEvents();
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
            this.titleInfoLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.serialKeyLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.editButton.Image = ViewUtilities.GetImage("Edit");
            this.editButton.RootElement.ToolTipText = Language.messageClickToEdit;

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = ViewUtilities.GetImage("Close");
            this.closeButton.RootElement.ToolTipText = Language.messageClickToClose;

            this.serialKeyButton.RootElement.EnableElementShadow = false;
            this.serialKeyButton.ButtonElement.Padding = new Padding(0);
            this.serialKeyButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.serialKeyButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.serialKeyButton.Image = ViewUtilities.GetImage("Edit");
            this.serialKeyButton.RootElement.ToolTipText = Language.messageClickToEdit;

            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.ButtonElement.Padding = new Padding(0);
            editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            editButton.ButtonElement.Padding = new Padding(0);
            serialKeyButton.ImageAlignment = ContentAlignment.MiddleCenter;
            serialKeyButton.ButtonElement.Padding = new Padding(0);
        }
    }
}
