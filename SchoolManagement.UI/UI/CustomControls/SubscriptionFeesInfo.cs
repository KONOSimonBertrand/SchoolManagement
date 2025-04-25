

using MediaFoundation;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.CodeDom;
using System.Xml;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class SubscriptionFeesInfo : UserControl
    {
        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadTextBox SubscriptionTypeTextBox { get => subscriptionTypeTextBox; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        #endregion
        public SubscriptionFeesInfo()
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

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subscriptionTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.subscriptionTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.AmountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.AmountLabel.LabelElement.CustomFontSize = 10.5f;
            this.AmountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.subscriptionTypeTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionTypeTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities. MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = ViewUtilities.GetImage("Close");
            this.closeButton.RootElement.ToolTipText = Language.messageClickToClose;

            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.editButton.Image = ViewUtilities.GetImage("Edit");
            this.editButton.RootElement.ToolTipText = Language.messageClickToEdit;

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subscriptionTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.AmountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);


            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.subscriptionTypeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subscriptionTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.ButtonElement.Padding = new Padding(0);
            editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            editButton.ButtonElement.Padding = new Padding(0);
        }

        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Hide();
        }
        private void InitLanguage()
        {
            schoolYearLabel.Text = Language.labelSchoolYear;
             this.AmountLabel.Text = Language.labelAmount;
            this.subscriptionTypeLabel.Text = Language.labelSubscription;
        }
    }
}
