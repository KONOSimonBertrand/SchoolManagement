using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;
using MediaFoundation;

namespace SchoolManagement.UI
{
    public partial class EditEmployeeEnrollingForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadButton AddGroupButton { get => addGroupButton; }
        public RadButton AddJobButton { get => addJobButton; }
        public RadButton AddEmployeeButton { get => addEmployeeButton; }
        public RadDropDownList JobDropDownList { get => jobDropDownList; }
        public RadDropDownList GroupDropDownList { get => groupDropDownList; }
        public RadDropDownList EmployeeDropDownList {  get => employeeDropDownList; }
        public RadTextBox SalaryTextBox { get => salaryTextBox; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadDateTimePicker EnrollingDateTimePicker { get=>dateTimePicker; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditEmployeeEnrollingForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.schoolYearLabel.Text = Language.labelSchoolYear;
            this.employeeLabel.Text = Language.labelEmployee;
            this.groupLabel.Text = Language.labelGroup;
            this.jobLabel.Text = Language.labelJob;
            this.salaryLabel.Text = Language.labelSalary;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text=Language.labelCancel;
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            employeeDropDownList.SelectedIndexChanged += EmployeeDropDownList_SelectedIndexChanged;
            groupDropDownList.SelectedIndexChanged += GroupDropDownList_SelectedIndexChanged;
            jobDropDownList.SelectedIndexChanged += JobDropDownList_SelectedIndexChanged;
            salaryTextBox.TextChanging += SalaryTextBox_TextChanging;
        }
        private void SalaryTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            

            this.groupDropDownList.RootElement.EnableElementShadow = false;

            this.employeeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.employeeLabel.LabelElement.CustomFontSize = 10.5f;
            this.employeeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.employeeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);


            this.groupLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.jobLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.jobLabel.LabelElement.CustomFontSize = 10.5f;
            this.jobLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.jobLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.salaryLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.salaryLabel.LabelElement.CustomFontSize = 10.5f;
            this.salaryLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.salaryLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.employeeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.employeeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.employeeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.employeeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.jobDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.jobDropDownList.RootElement.CustomFontSize = 10.5f;
            this.jobDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.jobDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.groupDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.groupDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);


            this.salaryTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.salaryTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.salaryTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.employeeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.groupDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.jobDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.employeeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.jobLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.salaryLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.employeeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.salarySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.jobSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.salaryTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addEmployeeButton.RootElement.ToolTipText = Language.messageClickToAddEmployee;
            addEmployeeButton.Image = ViewUtilities.GetImage("Add");
            addEmployeeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addEmployeeButton.ButtonElement.Padding = new Padding(0);
            addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            addGroupButton.Image = ViewUtilities.GetImage("Add");
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);
            addJobButton.RootElement.ToolTipText = Language.messageClickToAddJob;
            addJobButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addJobButton.ButtonElement.Padding = new Padding(0);
            addJobButton.Image = ViewUtilities.GetImage("Add");

            this.employeeDropDownList.DisplayMember = "FullName";
            this.employeeDropDownList.ValueMember = "Id";
            this.employeeDropDownList.SelectedIndex = -1;

            this.groupDropDownList.DisplayMember = "Name";
            this.groupDropDownList.ValueMember = "Id";
            this.groupDropDownList.SelectedIndex = -1;

            this.jobDropDownList.DisplayMember = "Name";
            this.jobDropDownList.ValueMember = "Id";
            this.jobDropDownList.SelectedIndex = -1;
            salaryTextBox.Text = "0";
            this.errorLabel.ForeColor = Color.Red;


        }
        private void GroupDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (groupDropDownList.SelectedIndex < 0)
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            }
            else
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void JobDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (jobDropDownList.SelectedIndex < 0)
            {
                addJobButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addJobButton.RootElement.ToolTipText = Language.messageClickToAddJob;
            }
            else
            {
                addJobButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addJobButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void EmployeeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (employeeDropDownList.SelectedIndex < 0)
            {
                addEmployeeButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addEmployeeButton.RootElement.ToolTipText = Language.messageClickToAddEmployee;
            }
            else
            {
                addEmployeeButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addEmployeeButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.dateTimePicker.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.employeeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.employeeDropDownList.Focus();
                return false;
            }


            if (this.jobDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.jobDropDownList.Focus();
                return false;
            }
            if (this.groupDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.groupDropDownList.Focus();
                return false;
            }

            return true;
        }
    }
}
