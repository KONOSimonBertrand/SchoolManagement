
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Scheduler.Dialogs;

namespace SchoolManagement.UI
{
    public partial class EditTimeTableForm : EditAppointmentDialog
    {
        public RadDropDownList SubjectDropDownList { get=>subjectDropDownList;  }
        public RadDropDownList TeacherDropDownList { get => teacherDropDownList; }
        public RadDropDownList DayDropDownList { get => daysDropDownList;   }
        public RadLabel ErrorLabel { get => errorLabel; }
        public RadDateTimePicker TeacherStartHourDateTimePicker { get =>teacherTimeIn; }
        public RadDateTimePicker TeacherEndHourDateTimePicker { get => teacherTimeOut; }
        public RadButton TeacherAddButton { get => addTeacherButton; }
        public RadButton SubjectAddButton { get => addSubjectButton; }
        public EditTimeTableForm()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitComponent()
        {
            labelLocation.LabelElement.CustomFont = ViewUtilities.MainFont;
            labelLocation.LabelElement.CustomFontSize = 10.5f;

            labelStatus.LabelElement.CustomFont = ViewUtilities.MainFont;
            labelStatus.LabelElement.CustomFontSize = 10.5f;

            this.labelStartTime.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelStartTime.LabelElement.CustomFontSize = 10.5f;

            this.labelEndTime.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelEndTime.LabelElement.CustomFontSize = 10.5f;

            this.labelTeacherTimeIn.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelTeacherTimeIn.LabelElement.CustomFontSize = 10.5f;

            this.labelTeacherTimeOut.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelTeacherTimeOut.LabelElement.CustomFontSize = 10.5f;

            this.labelSubject.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelSubject.LabelElement.CustomFontSize = 10.5f;

            this.labelBackground.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.labelBackground.LabelElement.CustomFontSize = 10.5f;

            this.subjectDropDownList.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.addSubjectButton.ButtonElement.Padding = new Padding(0);
            this.addSubjectButton.ImageAlignment = ContentAlignment.MiddleCenter;

            this.teacherDropDownList.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.addTeacherButton.ButtonElement.Padding = new Padding(0);
            this.addTeacherButton.ImageAlignment = ContentAlignment.MiddleCenter;

            this.cmbBackground.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.cmbBackground.RootElement.CustomFontSize = 10.5f;
            this.cmbBackground.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.FormElement.TitleBar.CustomFont = ViewUtilities.MainFont;

            this.radSeparator1.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            addTeacherButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            this.textBoxDescription.NullText = Language.labelMoreInfo;
            #region Subject Row
           labelSubject.Location = new Point(10, 5);
            subjectDropDownList.DropDownAnimationEnabled = true;
            subjectDropDownList.Location = new Point(10, 48);
            subjectDropDownList.TabIndex = 0;

            addSubjectButton.Location = new Point(580, 48);
            addSubjectButton.TabIndex = 1;
            #endregion Subject Row
            #region Teacher Row

            labelLocation.Location = new Point(10, 93);

            teacherDropDownList.DropDownAnimationEnabled = true;
            teacherDropDownList.Location = new Point(10, 130);
            teacherDropDownList.TabIndex = 2;

            addTeacherButton.Location = new Point(580, 130);
            addTeacherButton.TabIndex = 3;
            #endregion Teacher Row

            #region Status Row

            labelBackground.Location = new Point(10, 190);
            cmbBackground.Location = new Point(10, 230);
            cmbBackground.DropDownAnimationEnabled = true;
            cmbBackground.Width = 213;

            labelStatus.Location = new Point(228, 190);
            daysDropDownList.Location = new Point(228, 230);
            #endregion Status Row
            #region Start Row
            labelStartTime.Location = new Point(10, 290);
            labelStartTime.Size = new Size(71, 30);
            timeStart.Location = new Point(10, 330);

            labelTeacherTimeIn.Location = new Point(160, 290);
            teacherTimeIn.Location = new Point(160, 330);
            teacherTimeIn.Size = timeStart.Size;
            #endregion Start Row
            #region End Row
            labelEndTime.Location = new Point(10, 378);
            labelEndTime.Size = new Size(71, 30);
            timeEnd.Location = new Point(10, 418);

            labelTeacherTimeOut.Location = new Point(160, 378);
            teacherTimeOut.Location = new Point(160, 418);
            teacherTimeOut.Size = timeEnd.Size;
            #endregion End Row

            radSeparator1.Location = new Point(7, 500);
            radSeparator1.Width = 580;
            textBoxDescription.Location = new Point(5, 520);
            textBoxDescription.Height = 110;
            textBoxDescription.Width = 570;
            buttonOK.Width = 150;
            buttonCancel.Width = buttonOK.Width;
            buttonOK.Location = new Point(280, 650);
            buttonCancel.Location = new Point(440, 650);
            errorLabel.Top = buttonCancel.Top;
            //visibility

            this.txtSubject.Visible = false;
            this.txtLocation.Visible = false;
            this.cmbShowTimeAs.Visible = false;
            this.chkAllDay.Visible = false;
            this.labelResource.Visible = false;
            this.radLabelReminder.Visible = false;
            this.radDropDownListReminder.Visible = false;
            this.cmbResource.Visible = false;
            this.dateEnd.Visible = false;
            this.dateStart.Visible = false;
            this.labelEndTime.Visible = true;
            
            this.radSeparator2.Visible = false;
            this.radSeparator3.Visible = false;
            this.dateStart.Visible = false;
            this.dateEnd.Visible = false;
            this.checkedCmbResource.Visible = false;
            this.buttonRecurrence.Visible = false;
            this.buttonDelete.Visible = false;
            this.errorLabel.ForeColor = Color.Red;


            cmbBackground.Height=daysDropDownList.Height;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitComponent();
            InitLanguage();
        }
        private void InitLanguage()
        {

            this.labelSubject.Text = "<html>" + Language.labelSubject + ":" + "<color=Red>*";
            this.labelLocation.Text = "<html>" + Language.labelTeacher + ":" + "<color=Red>*";
            this.labelBackground.Text = "<html>" + Language.labelStatus + ":<color=Red>*";
            this.labelStatus.Text = "<html>" + Language.labelDay + ":<color=Red>*";
            this.labelStartTime.Text = "<html>" + Language.labelStartHour + ":" + "<color=Red>*";
            this.labelEndTime.Text = "<html>" + Language.labelEndHour + ":" + "<color=Red>*";
            this.labelTeacherTimeIn.Text = "<html>" + Language.labelTeacherIn + ":" + "<color=Red>*";
            this.labelTeacherTimeOut.Text = "<html>" + Language.labelTeacherOut + ":" + "<color=Red>*";
            buttonCancel.Text = Language.labelCancel;
            buttonOK.Text = Language.labelSave;
        }

        private void InitEvent()
        {
            subjectDropDownList.SelectedIndexChanged += SubjectDropDownList_SelectedIndexChanged;
            teacherDropDownList.SelectedIndexChanged += TeacherDropDownList_SelectedIndexChanged;
        }


        private void TeacherDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (teacherDropDownList.SelectedIndex < 0)
            {
                addTeacherButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addTeacherButton.RootElement.ToolTipText = Language.messageClickToAddEmployee;
            }
            else
            {
                addTeacherButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addTeacherButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

        private void SubjectDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (subjectDropDownList.SelectedIndex < 0)
            {
                addSubjectButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addSubjectButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            }
            else
            {
                addSubjectButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addSubjectButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
    }
}
