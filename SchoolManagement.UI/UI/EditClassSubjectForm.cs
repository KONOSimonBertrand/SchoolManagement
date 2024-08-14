
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditClassSubjectForm : RadForm
    {

        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList GroupDropDownList { get => groupDropDownList; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadButton AddSubjectButton { get => addSubjectButton; }
        public RadButton AddGroupButton { get => addGroupButton; }
        public RadTextBox CoeficientTextBox { get => coefTextBox; }
        public RadTextBox NoteOnTextBox { get => noteOnTextBox; }
        public RadDropDownList SubjectDropDownList {  get => subjectDropDownList; }
        public RadDropDownList SectionDropDownList {  get => sectionDropDownList; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditClassSubjectForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
            EnitEvent();
        }
        private void InitComponent()
        {
           
            //this.subjectDropDownList.RootElement.EnableElementShadow = false;
            //this.groupDropDownList.RootElement.EnableElementShadow = false;

            this.groupLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sectionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sectionLabel.LabelElement.CustomFontSize = 10.5f;
            this.sectionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sectionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.subjectLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteOnLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteOnLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteOnLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteOnLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.coefLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.coefLabel.LabelElement.CustomFontSize = 10.5f;
            this.coefLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.coefLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.coefTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.coefTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.coefTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteOnTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteOnTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteOnTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;

            this.groupDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.groupDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.sectionDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.sectionDropDownList.RootElement.CustomFontSize = 10.5f;
            this.sectionDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.sectionDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.sectionDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subjectLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteOnLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.coefLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sectionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.coefTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteOnTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;
            this.coefSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteOnSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sectionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            addGroupButton.Image = Resources.plus;
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);
            addSubjectButton.RootElement.ToolTipText = Language.messageClickToAddSubject;
            addSubjectButton.Image = Resources.plus;
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addSubjectButton.ButtonElement.Padding = new Padding(0);

            this.groupDropDownList.DisplayMember = Language.fieldName;
            this.groupDropDownList.ValueMember = "Id";
            this.groupDropDownList.SelectedIndex = -1;

            this.subjectDropDownList.DisplayMember = Language.fieldName;
            this.subjectDropDownList.ValueMember = "Id";
            this.subjectDropDownList.SelectedIndex = -1;

            this.sectionDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
            this.sectionDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
            this.sectionDropDownList.SelectedIndex = 0;
        }
        private void EnitEvent()
        {
            this.noteOnTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
            this.coefTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
            subjectDropDownList.SelectedIndexChanged += SubjectDropDownList_SelectedIndexChanged;
            groupDropDownList.SelectedIndexChanged += GroupDropDownList_SelectedIndexChanged;

        }
        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
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

        private void SubjectDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (subjectDropDownList.SelectedIndex < 0)
            {
                addSubjectButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addSubjectButton.RootElement.ToolTipText = Language.messageClickToAddSubject;
            }
            else
            {
                addSubjectButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addSubjectButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;

            if (this.subjectDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
               // this.errorLabel.Text = "La sélection d'une matière est requise!";
                this.subjectDropDownList.Focus();
                return false;
            }
            if (this.groupDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.groupDropDownList.Focus();
                return false;
            }
            if (this.noteOnTextBox.Text == "" || double.Parse(this.noteOnTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.noteOnTextBox.Focus();
                return false;
            }
            if (this.coefTextBox.Text == "" || double.Parse(this.coefTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.coefTextBox.Focus();
                return false;
            }
            if (this.sectionDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.sectionDropDownList.Focus();
                return false;
            }

            return true;
        }
   private void InitLanguage()
        {
            this.subjectLabel.Text = Language.labelSubject;
            this.groupLabel.Text=Language.labelGroup;
            this.coefLabel.Text=Language.labelCoefficient;
            this.sequenceLabel.Text=Language.labelSequence;
            this.noteOnLabel.Text = Language.labelNotedOn;
        }
    }
}
