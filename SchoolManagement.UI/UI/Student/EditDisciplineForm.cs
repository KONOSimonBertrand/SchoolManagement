
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EditDisciplineForm : RadForm
    {
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadTextBox ClassTextBox {  get => classTextBox; }
        public RadDateTimePicker DateTimePicker { get => dateTimePicker; }
        public RadDropDownList SubjectDropDownList {  get => subjectDropDownList; }
        public RadTextBox DurationTextBox { get => durationTextBox; }
        public RadDropDownList ReasonDropDownList {  get => reasonDropDownList; }
        public RadDropDownList EvaluationDropDownList {  get => evaluationDropDownList; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public EditDisciplineForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            classLabel.Text=Language.labelClass;
            this.dateLabel.Text= "<html> Date:" + "<color=Red>*";
            this.reasonLabel.Text = "<html>" + Language.labelReason+ ":" + "<color=Red>*";
            this.subjectLabel.Text = "<html>" + Language.labelDisciplineSubject + ":" + "<color=Red>*";
            this.durationLabel.Text= "<html>" + Language.labelDuration + ":" + "<color=Red>*";
            this.evaluationLabel.Text= "<html>" + Language.labelEvaluationSession+ ":" + "<color=Red>*";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.durationTextBox.TextChanging += TextChanging;


        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            studentDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            //reasonDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 30);
            reasonDropDownList.DropDownListElement.EnableElementShadow = false;
            reasonDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            //statusDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 30);
            subjectDropDownList.DropDownListElement.EnableElementShadow = false;
            subjectDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            evaluationDropDownList.DropDownListElement.EnableElementShadow = false;
            evaluationDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.evaluationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationLabel.LabelElement.CustomFontSize = 10.5f;
            this.evaluationLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.evaluationLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reasonLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.reasonLabel.LabelElement.CustomFontSize = 10.5f;
            this.reasonLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.reasonLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.subjectLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.durationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.durationLabel.LabelElement.CustomFontSize = 10.5f;
            this.durationLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.durationLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.durationTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.durationTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.durationTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.classTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
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

            this.reasonDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.reasonDropDownList.RootElement.CustomFontSize = 10.5f;
            this.reasonDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.reasonDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.evaluationDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.evaluationDropDownList.RootElement.CustomFontSize = 10.5f;
            this.evaluationDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.evaluationDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.reasonDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.evaluationDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;


            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.durationTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.subjectLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reasonLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.durationLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.reasonSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.durationSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.evaluationSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);


            LoadReasonList();
            
            subjectDropDownList.ValueMember = "Id";
            subjectDropDownList.DisplayMember = "DefaultName";

            this.evaluationDropDownList.DisplayMember = "DefaultName";
            this.evaluationDropDownList.ValueMember = "Id";

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";
            this.studentDropDownList.SelectedIndex = -1;
        }
        private void LoadReasonList()
        {
            List<string> frenchList = new List<string>
            {
                "Maladie",
                "Rendez-vous professionnel de santé",
                "Retour à la maison",
                "Billet médical",
                "Vacance",
                "Hospitalisation",
                "Exemption éducation physique",
                "Scolatisation à domicil",
                "Décès",
                "Obligation légale",
                "Absence motivée",
                "Problème familiale",
                "Manqué autobus",
                "Caution parentale",
                "Retard",
                "Entrevue autorisée",
                "Rencontre avec un intervenant interne",

            };
            List<string> englishList = new List<string>
            {
                "Disease",
                "Health professional appointment",
                "Back home",
                "Doctor's note",
                "Vacancy",
                "hospitalization",
                "Exemption physical education",
                "Home schooling",
                "Death",
                "Legal obligation",
                "Genuine absence",
                "Family problem",
                "Missed bus",
                "Parental guarantee",
                "Delay",
                "Interview authorized",
                "Meeting ",

            };
            this.reasonDropDownList.DataSource= Thread.CurrentThread.CurrentUICulture.Name == "en-GB"? englishList : frenchList;
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            this.errorLabel.ForeColor = Color.Red;
            if (this.studentDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.studentDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.studentDropDownList.Focus();
                return false;
            }

            if (this.subjectDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.subjectDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.subjectDropDownList.Focus();
                return false;
            }

            if (this.durationTextBox.Text == "")
            {
                this.errorProvider.SetError(this.durationTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.durationTextBox.Focus();
                return false;
            }
            if (this.evaluationDropDownList.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.evaluationDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.evaluationDropDownList.Focus();
                return false;
            }
            return true;
        }
        private void TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
    }
}
