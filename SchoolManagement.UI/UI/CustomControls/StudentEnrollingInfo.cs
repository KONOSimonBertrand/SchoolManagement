
using MediaFoundation;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class StudentEnrollingInfo : UserControl
    {
        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel StudentLabel { get => studentLabel; }
        public RadTextBox StudentTextBox { get => studentTextBox; }
        public RadTextBox BirthDayTextBox { get => birthdayTextBox; }
        public RadTextBox BirthPlaceTextBox { get=>birthPlaceTextBox; }
        public RadTextBox EnrollingDateTextBox { get => enrollingDateTextBox; }
        public RadTextBox IdCardTextBox { get => idCardTextBox; }
        public RadTextBox PhoneTextBox { get => phoneTextBox; }
        public RadTextBox EmailTextBox { get => emailTextBox; }
        public RadTextBox AddressTextBox { get => addressTextBox; }
        public RadTextBox SexTextBox { get => sexTextBox; }
        public RadTextBox NationalityTextBox { get => nationalityTextBox; }
        public RadTextBox RoomTextBox { get => roomTextBox; }
        public RadLabel HealthFileLabel { get => healthLabel; }
        public RadLabel ContactsLabel { get => contactsLabel; }
        public RadLabel DisciplineFileLabel { get => disciplineLabel; }
        public RadLabel SubscriptionsLabel { get => subscriptionLabel; }
        public StudentEnrollingInfo()
        {
            InitializeComponent();
            InitComponents();
            InitEvents();
            InitLanguage();
        }


        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
            contactsLabel.MouseMove += Label_MouseMove;
            healthLabel.MouseMove += Label_MouseMove;
            subscriptionLabel.MouseMove += Label_MouseMove;
            disciplineLabel.MouseMove += Label_MouseMove;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InitLanguage()
        {
            this.BirthdayLabel.Text = Language.labelBirthDate;
            this.birthPlaceLabel.Text = Language.labelBirthPlace;
            this.idCardLabel.Text = Language.labelIdCard;
            this.phoneLabel.Text = Language.labelPhone;
            this.emailLabel.Text = Language.labelMail;
            this.addressLabel.Text = Language.labelAdddress;
            this.contactsLabel.Text = Language.labelRooms;
            this.healthLabel.Text = Language.labelSubjects;
            this.disciplineLabel.Text = Language.labelNotes;
            this.subscriptionLabel.Text = Language.labelAttendances;
            this.nationalityLabel.Text = Language.labelNativeCountry;
            this.sexLabel.Text = Language.labelSex;
        }

        private void InitComponents()
        {

            this.headerPanel.RootElement.EnableElementShadow = false;
            this.roomsSplitPanel.RootElement.EnableElementShadow = false;
            this.notesSplitPanel.RootElement.EnableElementShadow = false;
            this.enrollingDateSplitPanel.RootElement.EnableElementShadow = false;

            titleInfoLabel.RootElement.EnableElementShadow = false;
            titleInfoLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.studentLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.contactsLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.contactsLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.contactsLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.contactsLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.contactsLabel.LabelElement.CustomFontSize = 10.5f;

            this.healthLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.healthLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.healthLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.healthLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.healthLabel.LabelElement.CustomFontSize = 10.5f;

            this.disciplineLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.disciplineLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.disciplineLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.disciplineLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.disciplineLabel.LabelElement.CustomFontSize = 10.5f;

            this.subscriptionLabel.Image = Utilities.ViewUtilities.GetImage("Eye");
            this.subscriptionLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.subscriptionLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.subscriptionLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.subscriptionLabel.LabelElement.CustomFontSize = 10.5f;

            this.studentTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.studentTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.studentTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.BirthdayLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.BirthdayLabel.LabelElement.CustomFontSize = 10.5f;
            this.BirthdayLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.BirthdayLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.roomLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.enrollingDateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.enrollingDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.enrollingDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.enrollingDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.birthPlaceLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.birthPlaceLabel.LabelElement.CustomFontSize = 10.5f;
            this.birthPlaceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.birthPlaceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sexLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sexLabel.LabelElement.CustomFontSize = 10.5f;
            this.sexLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sexLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nationalityLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nationalityLabel.LabelElement.CustomFontSize = 10.5f;
            this.nationalityLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nationalityLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idCardLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.idCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.idCardLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.phoneLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.phoneLabel.LabelElement.CustomFontSize = 10.5f;
            this.phoneLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.phoneLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.emailLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.emailLabel.LabelElement.CustomFontSize = 10.5f;
            this.emailLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.emailLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.addressLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.addressLabel.LabelElement.CustomFontSize = 10.5f;
            this.addressLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.addressLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.roomTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.roomTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.enrollingDateTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.enrollingDateTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.enrollingDateTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.birthdayTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.birthdayTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.birthdayTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.birthPlaceTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.birthPlaceTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.birthPlaceTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sexTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sexTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.sexTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.nationalityTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nationalityTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nationalityTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.idCardTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.idCardTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idCardTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.phoneTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.phoneTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.phoneTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.emailTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.emailTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.emailTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.addressTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.addressTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.addressTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            foreach (SplitPanel sp in this.roomSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.dateSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.sexSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.idCardSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.contactSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            this.editButton.RootElement.EnableElementShadow = false;
            this.editButton.ButtonElement.Padding = new Padding(0);
            this.editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.editButton.DisplayStyle = DisplayStyle.Image;
            this.editButton.Image = Utilities.ViewUtilities.GetImage("Edit");
            this.editButton.RootElement.ToolTipText = Language.messageClickToEdit;

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = Utilities.ViewUtilities.GetImage("Close");
            this.closeButton.RootElement.ToolTipText = Language.messageClickToEdit;

            this.roomLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.contactsLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.disciplineLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subscriptionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.healthLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.enrollingDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.BirthdayLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.birthPlaceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sexLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nationalityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.phoneLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.addressLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.studentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.roomTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.enrollingDateTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.birthdayTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.birthPlaceTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idCardTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sexTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nationalityTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.enrollingDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthdaySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthPlaceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nationalitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            contactsLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee;
            healthLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee; ;
            subscriptionLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee;
            disciplineLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee; ;


        }
        private void Label_MouseMove(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;

        }
    }
}
