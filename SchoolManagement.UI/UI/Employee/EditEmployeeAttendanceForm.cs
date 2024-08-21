

using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
namespace SchoolManagement.UI
{
    public partial class EditEmployeeAttendanceForm : RadForm
    {
        public RadDropDownList RoomDropDownList { get => roomDropDownList; }
        public RadDropDownList SubjectDropDownList {  get => subjectDropDownList; }
        public RadDateTimePicker AttendanceDateTimePicker {  get => dateTimePicker; }
        public RadDateTimePicker StartDateTimePicker {  get => startDateTimePicker; }
        public RadDateTimePicker EndDateTimePicker { get => endDateTimePicker; }
        public RadTextBox DescriptionTextBox { get => descriptionTextBox; }
        public RadButton RoomAddButton { get => roomAddButton; }
        public RadButton SubjectAddButton { get => subjectAddButton; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditEmployeeAttendanceForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.dateLabel.Text = "<html>Date:<color=Red>*";
            this.roomLabel.Text = "<html>" + Language.labelClasss + ":" + "<color=Red>*";  
            this.subjectLabel.Text = "<html>" + Language.labelSubject + ":" + "<color=Red>*"; 
            this.startLabel.Text = "<html>" + Language.labelStartHour + ":" + "<color=Red>*";
            this.endLabel.Text = "<html>"+ Language.labelEndHour+ ":" + "<color=Red>*";
        }

        private void InitEvent()
        {
            roomDropDownList.SelectedIndexChanged += RoomDropDownList_SelectedIndexChanged;
            subjectDropDownList.SelectedIndexChanged += SubjectDropDownList_SelectedIndexChanged;
            closeButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubjectDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (subjectDropDownList.SelectedIndex < 0)
            {
                subjectAddButton.Image = Utilities.ViewUtilities.GetImage("Add");
                subjectAddButton.RootElement.ToolTipText = Language.messageClickToAddSubject;
            }
            else
            {
                subjectAddButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                subjectAddButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

        private void RoomDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (roomDropDownList.SelectedIndex < 0)
            {
                roomAddButton.Image = Utilities.ViewUtilities.GetImage("Add");
                roomAddButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            }
            else
            {
                roomAddButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                roomAddButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

        private void InitComponent()
        {
            this.roomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.startLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.startLabel.LabelElement.CustomFontSize = 10.5f;
            this.startLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.endLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.endLabel.LabelElement.CustomFontSize = 10.5f;
            this.endLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.roomDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.roomDropDownList.RootElement.CustomFontSize = 10.5f;
            this.roomDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.roomDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.roomDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.roomDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.subjectDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.startDateTimePicker.CustomFormat = "HH:mm";
            this.endDateTimePicker.CustomFormat = "HH:mm";
            this.startDateTimePicker.ShowUpDown=true;
            this.endDateTimePicker.ShowUpDown = true;

            descriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            subjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            roomAddButton.RootElement.ToolTipText = Language.messageClickToAdd;
            roomAddButton.Image = ViewUtilities.GetImage("Add");
            roomAddButton.ImageAlignment = ContentAlignment.MiddleCenter;
            roomAddButton.ButtonElement.Padding = new Padding(0);

            subjectAddButton.RootElement.ToolTipText = Language.messageClickToAdd;
            subjectAddButton.Image = ViewUtilities.GetImage("Add");
            subjectAddButton.ImageAlignment = ContentAlignment.MiddleCenter;
            subjectAddButton.ButtonElement.Padding = new Padding(0);
            roomDropDownList.DisplayMember = "Name";
            roomDropDownList.ValueMember = "Id";
            roomDropDownList.SelectedIndex = -1;

            subjectDropDownList.DisplayMember = Language.fieldName;
            subjectDropDownList.ValueMember = "Id";
            subjectDropDownList.SelectedIndex = -1;
            errorLabel.ForeColor=Color.Red;

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.closeButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.closeButton.ButtonElement.CustomFontSize = 10.5f;
            this.closeButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);


            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.roomDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.roomDropDownList.Focus();
                return false;
            }
            if (this.subjectDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.subjectDropDownList.Focus();
                return false;
            }
            if (this.dateTimePicker.Text == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.startDateTimePicker.Text == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.startDateTimePicker.Focus();
                return false;
            }
            if (this.endDateTimePicker.Text == string.Empty)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.endDateTimePicker.Focus();
                return false;
            }
            if (this.endDateTimePicker.Value < this.startDateTimePicker.Value)
            {
                this.errorLabel.Text = Language.messageEndHourGreaterThanStartHour;
                this.endDateTimePicker.Focus();
                return false;
            }
            return true;
        }

    }
}
