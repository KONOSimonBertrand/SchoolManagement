
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI.CustomControls
{
    public partial class EmployeeEnrollingInfo : UserControl
    {
        public RadLabel TitleInfoLabel { get => titleInfoLabel; }
        public RadButton EditButton { get => editButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel EmployeeLabel { get => employeeLabel; }
        public RadTextBox EmployeeTextBox { get => employeeTextBox; }
        public RadTextBox BirthDayTextBox { get=>birthdayTextBox; }
        public RadTextBox HiringDateTextBox { get => hiringDateTextBox; }
        public RadTextBox IdCardTextBox { get => idCardTextBox; }
        public RadTextBox PhoneTextBox { get => phoneTextBox; }
        public RadTextBox EmailTextBox { get => emailTextBox; }
        public RadTextBox AddressTextBox { get => addressTextBox; }
        public RadTextBox SexTextBox { get => sexTextBox; }
        public RadTextBox NationalityTextBox { get => nationalityTextBox; }
        public RadLabel SubjectsLabel { get => subjectsLabel; }
        public RadLabel RoomsLabel { get => roomsLabel; }
        public RadLabel NotesLabel { get => notesLabel; }
        public RadLabel AttendancesLabel { get => attendancesLabel; }
        public EmployeeEnrollingInfo()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
            InitEvents();
        }

        private void InitEvents()
        {
            this.closeButton.Click += CloseButton_Click;
            roomsLabel.MouseMove += Label_MouseMove;
            subjectsLabel.MouseMove += Label_MouseMove;
            attendancesLabel.MouseMove += Label_MouseMove;
            notesLabel.MouseMove += Label_MouseMove;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InitLanguage()
        {
            this.BirthdayLabel.Text = Language.labelBirthDate;
            this.hiringDateLabel.Text = Language.labelHiringDate;
            this.idCardLabel.Text = Language.labelIdCard;
            this.phoneLabel.Text = Language.labelPhone;
            this.emailLabel.Text=Language.labelMail;
            this.addressLabel.Text = Language.labelAddress;
            this.roomsLabel.Text = Language.labelRooms;
            this.subjectsLabel.Text = Language.labelSubjects;
            this.notesLabel.Text = Language.labelNotes;
            this.attendancesLabel.Text = Language.labelAttendances;
            this.nationalityLabel.Text = Language.labelNativeCountry;
            this.sexLabel.Text = Language.labelSex;
        }

        private void InitComponent()
        {
           
            this.headerPanel.RootElement.EnableElementShadow = false;
            this.roomsSplitPanel.RootElement.EnableElementShadow = false;
            this.notesSplitPanel.RootElement.EnableElementShadow = false;

            titleInfoLabel.RootElement.EnableElementShadow = false;
            titleInfoLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            titleInfoLabel.LabelElement.CustomFontSize = 10.5f;
            titleInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.employeeLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.employeeLabel.LabelElement.CustomFontSize = 10.5f;
            this.employeeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.employeeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomsLabel.Image = Utilities.ViewUtilities.GetImage("View");
            this.roomsLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.roomsLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.roomsLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.roomsLabel.LabelElement.CustomFontSize = 10.5f;

            this.subjectsLabel.Image = Utilities.ViewUtilities.GetImage("View");
            this.subjectsLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.subjectsLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.subjectsLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.subjectsLabel.LabelElement.CustomFontSize = 10.5f;

            this.notesLabel.Image = Utilities.ViewUtilities.GetImage("View");
            this.notesLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.notesLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.notesLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.notesLabel.LabelElement.CustomFontSize = 10.5f;

            this.attendancesLabel.Image = Utilities.ViewUtilities.GetImage("View");
            this.attendancesLabel.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.attendancesLabel.LabelElement.LabelImage.Padding = new Padding(0, -3, 0, 0);
            this.attendancesLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.attendancesLabel.LabelElement.CustomFontSize = 10.5f;

            this.employeeTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.employeeTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.employeeTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.BirthdayLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.BirthdayLabel.LabelElement.CustomFontSize = 10.5f;
            this.BirthdayLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.BirthdayLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.hiringDateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.hiringDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.hiringDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.hiringDateLabel.TextAlignment = ContentAlignment.BottomLeft;

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

            this.birthdayTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.birthdayTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.birthdayTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.hiringDateTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.hiringDateTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.hiringDateTextBox.ForeColor = Color.FromArgb(33, 33, 33);

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
            foreach (SplitPanel sp in this.roomSplitContainer.SplitPanels)
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

            this.employeeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.roomsLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.notesLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.BirthdayLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.hiringDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sexLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nationalityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.phoneLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.addressLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.employeeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.birthdayTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.hiringDateTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idCardTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sexTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nationalityTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.employeeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.birthdaySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.hiringDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nationalitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            roomsLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee;
            subjectsLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee; ;
            attendancesLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee;
            notesLabel.LabelElement.ToolTipText = Language.messageDoubleClickToSee; ;

            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.ButtonElement.Padding = new Padding(0);
            editButton.ImageAlignment = ContentAlignment.MiddleCenter;
            editButton.ButtonElement.Padding = new Padding(0);
        }
        private void Label_MouseMove(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;

        }
    }
}
