


using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.Xml;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class SchoolingCostInfo : UserControl
    {
        #region Properties

        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadTextBox ClassTextBox { get => classTextBox; }
        public RadTextBox CostTypeTextBox { get => costTypeTextBox; }
        public RadTextBox TrancheNumberTextBox { get => trancheNumberTextBox; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadLabel TranchesLabel{ get => trancheValueLabel; }
        #endregion
        public SchoolingCostInfo()
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
            this.amountSplitContainer.RootElement.EnableElementShadow = false;
            
            this.titleInfoLabel.RootElement.EnableElementShadow = false;
            this.titleInfoLabel.LabelElement.CustomFont = ViewUtilities.MainFontMedium;
            this.titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            this.titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.costTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.costTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.trancheNumberLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.trancheNumberLabel.LabelElement.CustomFontSize = 10.5f;
            this.trancheNumberLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.trancheNumberLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.trancheValueLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.trancheValueLabel.LabelElement.CustomFontSize = 10.5f;
            this.trancheValueLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.trancheValueLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.trancheNumberTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.trancheNumberTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.trancheNumberTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.classTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.costTypeTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.costTypeTextBox.ForeColor = Color.FromArgb(33, 33, 33);


            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            foreach (Telerik.WinControls.UI.SplitPanel sp in this.amountSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = Resources.not_clean;
            this.closeButton.RootElement.ToolTipText = "Cliquer ici pour fermer";

            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.editButton.Image = Resources.edit;
            this.editButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations";

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.trancheNumberLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.trancheValueLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);


            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.costTypeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.trancheNumberTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.trancheNumberSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.ButtonElement.Padding = new Padding(0);
            editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            editButton.ButtonElement.Padding = new Padding(0);
        }

        private void InitLanguage()
        {
            schoolYearLabel.Text = Language.labelSchoolYear;
            classLabel.Text = Language.labelClass;
            this.amountLabel.Text = Language.labelAmount;
            this.trancheNumberLabel.Text = Language.labelTrancheNumber;
            this.costTypeLabel.Text = Language.labelFeeType;
        }

    }
}
