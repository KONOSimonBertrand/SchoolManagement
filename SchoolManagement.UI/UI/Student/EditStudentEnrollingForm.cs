using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EditStudentEnrollingForm : RadForm
    {
        public RadButton SaveButton { get=>saveButton;}
        public RadButton CloseButton { get=>closeButton;}
        public RadDateTimePicker EnrollingDateTimePicker { get=>dateTimePicker;}
        public RadDropDownList StudentDropDownList {  get=>studentDropDownList;}
        public RadButton AddStudentButton { get=>addStudentButton;}
        public RadDropDownList ClassDropDownList {  get=>classDropDownList;}
        public RadButton AddClassButton { get=>addClassButton;}
        public RadButton AddRoomButton { get=>addRoomButton;}
        public RadDropDownList RoomDropDownList {  get=>roomDropDownList;}
        public RadTextBox OldSchoolTextBox { get=>oldSchoolTextBox;}
        public RadDropDownList RepeaterDropDownList {  get=>repeaterDropDownList;}
        public RadTextBox AmountTextBox { get=>amountTextBox;}
        public RadTextBox IdTransactionTextBox { get=>IdTransactionTextBox;}
        public RadGridView PaymentsGridView { get=>paymentsGridView;}
        public RadLabel ErrorLabel { get=>errorLabel;}
        public ErrorProvider DataErrorProvider { get=>errorProvider;}
        public RadTextBox DoneByTextBox { get=>doneByTextBox;}
        public RadTextBox SchoolYearTexBox { get=>schoolYearTextBox;}
        public RadLabel SchoolFeeValueLabel { get => schoolFeeValueLabel; }
        public EditStudentEnrollingForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            studentDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;
            this.errorLabel.ForeColor = Color.Red;

            this.classDropDownList.RootElement.EnableElementShadow = false;
            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.roomLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.oldSchoolLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolLabel.LabelElement.CustomFontSize = 10.5f;
            this.oldSchoolLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.oldSchoolLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.repeaterLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterLabel.LabelElement.CustomFontSize = 10.5f;
            this.repeaterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.repeaterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;
            this.doneByLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.doneByLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolFeeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolFeeLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolFeeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolFeeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolFeeValueLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolFeeValueLabel.LabelElement.CustomFontSize = 12.5f;
            this.schoolFeeValueLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.divisionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.divisionLabel.LabelElement.CustomFontSize = 10.5f;
            this.divisionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.divisionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.oldSchoolTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.oldSchoolTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.doneByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.doneByTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);


            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);


            this.repeaterDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterDropDownList.RootElement.CustomFontSize = 10.5f;
            this.repeaterDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.repeaterDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);


            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.roomDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            foreach (Telerik.WinControls.UI.SplitPanel sp in this.schoolYearSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (Telerik.WinControls.UI.SplitPanel sp in this.studentSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
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

            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.oldSchoolTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.oldSchoolLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.repeaterLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.roomLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.divisionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.oldSchoolSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.repeaterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearSplitContainer.RootElement.EnableElementShadow = false;
            this.studentSplitContainer.RootElement.EnableElementShadow = false;
            this.amountSplitContainer.RootElement.EnableElementShadow = false;

            addStudentButton.RootElement.ToolTipText = Language.messageClickToAddStudent;
            addStudentButton.Image = ViewUtilities.GetImage("Add");
            addStudentButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addStudentButton.ButtonElement.Padding = new Padding(0);
            addClassButton.RootElement.ToolTipText = Language.messageClickToAddClass;
            addClassButton.Image = ViewUtilities.GetImage("Add");
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.ButtonElement.Padding = new Padding(0);
            addRoomButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            addRoomButton.Image = ViewUtilities.GetImage("Add");
            addRoomButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addRoomButton.ButtonElement.Padding = new Padding(0);

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";

            this.roomDropDownList.DisplayMember = "Name";
            this.roomDropDownList.ValueMember = "Id";


            this.repeaterDropDownList.Items.Add(new RadListDataItem(Language.labelNo, 0));
            this.repeaterDropDownList.Items.Add(new RadListDataItem(Language.labelYes, 1));
            this.repeaterDropDownList.SelectedIndex = 0;
            this.repeaterDropDownList.DropDownStyle = RadDropDownStyle.DropDownList;

        }

        private void InitLanguage()
        {

            //"<html>" + Language.labelStudent + ":" + "<color=Red>*";
            schoolYearLabel.Text=Language.labelSchoolYear  ;
            dateLabel.Text= "<html>" + Language.labelEnrollingDate + ":" + "<color=Red>*";
            studentLabel.Text= "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            classLabel.Text="<html>" + Language.labelClass + ":" + "<color=Red>*";
            roomLabel.Text="<html>" + Language.labelRoom + ":" + "<color=Red>*";
            oldSchoolLabel.Text = Language.labelOldSchool;
            repeaterLabel.Text = Language.labelRepeater;
            amountLabel.Text = "<html>" + Language.labelAmountPaid + ":" + "<color=Red>*";
            divisionLabel.Text=Language.labelSharing;
            schoolFeeLabel.Text = Language.labelSchoolingFee;
            doneByLabel.Text=Language.labelPaymentDoneBy;
        }

        private void InitEvent()
        {
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
            studentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
            classDropDownList.SelectedIndexChanged += ClassDropDownList_SelectedIndexChanged;
            roomDropDownList.SelectedIndexChanged += RoomDropDownList_SelectedIndexChanged;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }
        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (studentDropDownList.SelectedIndex < 0)
            {
                addStudentButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addStudentButton.RootElement.ToolTipText = Language.messageClickToAddStudent;
            }
            else
            {
                addStudentButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addStudentButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void ClassDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (classDropDownList.SelectedIndex < 0)
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addClassButton.RootElement.ToolTipText = Language.messageClickToAddClass;
            }
            else
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addClassButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void RoomDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (roomDropDownList.SelectedIndex < 0)
            {
                addRoomButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addRoomButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            }
            else
            {
                addRoomButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addRoomButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();

            if (dateTimePicker.Text == "")
            {
                errorProvider.SetError(dateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.studentDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(studentDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.studentDropDownList.Focus();
                return false;
            }
            if (this.repeaterDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(repeaterDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.repeaterDropDownList.Focus();
                return false;
            }
            if (this.classDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(classDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.classDropDownList.Focus();
                return false;
            }
            if (this.roomDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(roomDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.roomDropDownList.Focus();
                return false;
            }
            if (amountTextBox.Text == string.Empty)
            {
                errorProvider.SetError(amountTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.amountTextBox.Focus();
                return false;
            }
            
            
            
            return true;
        }
    }
}
