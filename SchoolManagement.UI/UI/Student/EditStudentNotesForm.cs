using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditStudentNotesForm : RadForm
    {
        public CommandBarLabel EvaluationLabel { get => evaluationLabel; }
        public CommandBarButton PrintButton { get => printButton; }
        public CommandBarButton ExportToExelButton { get => exportToExelButton; }
        public CommandBarLabel GroupLabel { get => groupLabel; }
        public CommandBarDropDownList GroupDropDownList {  get => groupDropDownList; }
        public CommandBarLabel ClassroomLabel {  get => classLabel; }
        public RadDropDownList SubjectDropDownList {  get => subjectDropDownList; }
        public SearchTextBox FilterTextBox { get => filterTextBox; }
        public RadGridView DataGridView { get => dataGridView; }
        public RadTextBox NoteMaxTextBox { get => noteMaxTextBox; }
        public RadTextBox NoteCoefTextBox { get => noteCoefTextBox; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditStudentNotesForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            filterLabel.Text = Language.LabelFilter+":";
            groupLabel.Text=Language.labelSection+ ":";
            classLabel.Text=Language.LabelClassroom + ":";
            subjectLabel.Text= "<html>" + Language.labelSubject + ":" + "<color=Red>*";
            noteMaxLabel.Text=Language.labelMaxNote + ":";
            noteCoefLabel.Text = Language.labelCoefficient + ":";
        }
        private void InitEvent()
        {
           
        }
        private void InitComponent()
        {
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.filterLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.filterLabel.LabelElement.CustomFontSize = 10.5f;
            this.filterLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.filterLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.noteCoefLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteCoefLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteCoefLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.noteCoefLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.noteMaxLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteMaxLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.noteMaxLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.noteCoefTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteCoefTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteCoefTextBox.ForeColor = Color.FromArgb(89, 89, 89);

            this.noteMaxTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.noteMaxTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteMaxTextBox.ForeColor = Color.FromArgb(89, 89, 89);

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            foreach (RadControl c in this.informationPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.informationPanel.RootElement.EnableElementShadow = false;
            this.subjectLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            exportToExelButton.Image = ViewUtilities.GetImage("Excel");
            printButton.Image = ViewUtilities.GetImage("Printer");
        }
        public bool IsValidData()
        {
            if (this.noteCoefTextBox.Text == "" || double.Parse(this.noteCoefTextBox.Text) < 0)
            {
                this.errorProvider.SetError(noteCoefTextBox, Language.messageFillField);
                this.subjectDropDownList.Focus();
                return false;
            }
            if (this.noteMaxTextBox.Text == "" || double.Parse(this.noteMaxTextBox.Text) < 0)
            {
                this.errorProvider.SetError(noteMaxTextBox, Language.messageFillField);
                this.subjectDropDownList.Focus();
                return false;
            }
            return true;
        }
    }
}
