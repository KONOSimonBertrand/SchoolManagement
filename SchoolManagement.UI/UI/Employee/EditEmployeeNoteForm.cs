using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditEmployeeNoteForm : RadForm
    {
        public RadDropDownList SubjectDropDownList { get => subjectDropDownList; }
        public RadDateTimePicker NoteDateTimePicker { get => dateTimePicker; }
        public RadTextBox DescriptionTextBox { get => descriptionTextBox; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        private List<string> subjectList;
        public EditEmployeeNoteForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.dateLabel.Text = "<html>Date:<color=Red>*";
            this.subjectLabel.Text = "<html>" + Language.labelNoteSubject + ":" + "<color=Red>*";
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitComponent()
        {
            this.subjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.subjectLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.subjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.subjectDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.subjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";

            descriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            subjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
          
            errorLabel.ForeColor = Color.Red;

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
            LoadSubjects();
        }
        private void LoadSubjects()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
            {
                subjectList = new()
            {
                "Administrative notice",
                "Disciplinary note",
                "Note of congratulations",
                "Note of encouragement",
                "Termination Notice",
                "Assignment note",
                "Transfer note",
                "Pay increase note"
            };
            }
            else
            {
                subjectList = new()
            {
                "Note administrative",
                "Note disciplinaire",
                "Note de félicitation",
                "Note d'encouragement",
                "Note de licenciement",
                "Note d'affectation",
                "Note de mutation",
                "Note d'augmentation de salaire"
            };
            }
            
            subjectDropDownList.DataSource = subjectList;
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            
            if (this.subjectDropDownList.Text==string.Empty)
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
          
            return true;
        }
   
    
    }
}
