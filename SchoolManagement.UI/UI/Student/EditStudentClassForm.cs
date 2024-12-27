
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditStudentClassForm : RadForm
    {
        public RadLabel StudentLabel { get => studentLabel; }
        public RadTextBox StudentTextBox { get => studentTextBox; }
        public RadLabel ClassLabel { get => classLabel; }
        public RadDropDownList ClassDropDownList {  get => classDropDownList; }
        public RadDropDownList RoomDropDownList { get => roomDropDownList; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel RoomLabel { get => roomLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditStudentClassForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text=Language.labelStudent+":";
            this.classLabel.Text = $"<html>{Language.labelClass}:<color=Red>*";
            this.roomLabel.Text = $"<html>{Language.labelRoom}:<color=Red>*";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
           
           

            if (this.classDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.classDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.classDropDownList.Focus();
                return false;
            }
            if (this.roomDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(roomDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.roomDropDownList.Focus();
                return false;
            }
            return true;
        }
        private void InitComponent()
        {
           
            this.classDropDownList.RootElement.EnableElementShadow = false;
            this.roomDropDownList.RootElement.EnableElementShadow = false;
            this.errorLabel.ForeColor = Color.Red;
            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.roomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.roomLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.roomDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.studentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.roomLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";
            this.classDropDownList.SelectedIndex = -1;

            this.roomDropDownList.DisplayMember = "Name";
            this.roomDropDownList.ValueMember = "Id";
            this.roomDropDownList.SelectedIndex = -1;

        }
    }
}
