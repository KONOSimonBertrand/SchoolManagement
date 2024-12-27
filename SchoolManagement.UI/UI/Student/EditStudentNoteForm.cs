
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditStudentNoteForm : RadForm
    {
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadTextBox ClassTextBox { get => classTextBox; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadTextBox EvaluationTextBox { get => evaluationTextBox; }
        public RadDropDownList SubjectDropDownList {  get => subjectDropDownList; }
        public RadTextBox NoteCoefTextBox { get => noteCoefTextBox; }
        public RadDropDownList GroupDropDownList { get => groupDropDownList; }
        public RadTextBox NoteTextBox { get => noteTextBox; }
        public RadTextBox NoteMaxTextBox { get => noteMaxTextBox; }
        public RadTextBox CommentTextBox { get => commentTextBox; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton {  get => closeButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadSeparator GroupSeparator {  get => groupSeparator; }
        public RadLabel GroupLabel { get => groupLabel; }

        public EditStudentNoteForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            classLabel.Text = Language.LabelClassroom + ":";
            schoolYearLabel.Text = Language.labelSchoolYear + ":";
            evaluationLabel.Text=Language.labelEvaluationSession + ":";
            subjectLabel.Text = "<html>" + Language.labelSubject + ":" + "<color=Red>*";
            noteCoefLabel.Text=Language.labelCoefficient+":";
            noteMaxLabel.Text = Language.labelMaxNote + ":";
            groupLabel.Text= "<html>" + Language.labelSection + ":" + "<color=Red>*";
            noteLabel.Text = "<html>" + Language.labelNote + ":" + "<color=Red>*";
            commentLabel.Text=Language.LabelComment + ":";
        }

        private void InitEvent()
        {
            closeButton.Click += (s, e) => { this.Close(); };
            noteTextBox.TextChanging += (s, e) => { e.Cancel=!ViewUtilities.IsNumber(e.NewValue); };
        }

        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            studentDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.evaluationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationLabel.LabelElement.CustomFontSize = 10.5f;
            this.evaluationLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.subjectLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.groupLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.commentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.commentLabel.LabelElement.CustomFontSize = 10.5f;
            this.commentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.commentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteCoefLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteCoefLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteCoefLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteCoefLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteMaxLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteMaxLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteMaxLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.classTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.evaluationTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.evaluationTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.groupDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.commentTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.commentTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.commentTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteCoefTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteCoefTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteCoefTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteMaxTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteMaxTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;


            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subjectLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.commentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.evaluationLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteMaxLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);


            this.subjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.commentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteCoefTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteMaxTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.evaluationTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteCoefSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteMaxSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.commentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.noteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.evaluationSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.errorLabel.ForeColor = Color.Red;
        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.studentDropDownList.SelectedIndex < 0)
            {
              
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(studentDropDownList, Language.messageFillField);
                this.studentDropDownList.Focus();
                return false;
            }
            if (this.evaluationTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(evaluationTextBox, Language.messageFillField);
                return false;
            }
            if (this.groupDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(groupDropDownList, Language.messageFillField);
                this.groupDropDownList.Focus();
                return false;
            }
            if (this.subjectDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(subjectDropDownList, Language.messageFillField);
                this.subjectDropDownList.Focus();
                return false;
            }
            if (this.noteTextBox.Text == "" || double.Parse(this.noteTextBox.Text) < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                this.errorProvider.SetError(noteTextBox, Language.messageFillField);
                this.noteTextBox.Focus();
                return false;
            }
            
            return true;
        }
    }
}
