
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;
using System.Windows.Forms;

namespace SchoolManagement.UI
{
    public partial class EditMedicalRecordForm : RadForm
    {

        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox StudentTextBox { get => studentTextBox; }
        public RadDateTimePicker DateTimePicker { get => dateTimePicker; }
        public RadDropDownList HealthSubjectDropDownList {  get => healthSubjectDropDownList; }
        public RadTextBox DescriptionTextBox { get => descriptionTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }    
        public EditMedicalRecordForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
            dateTimePicker.Value = DateTime.Now;
            LoadReasonList();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text=Language.labelStudent;
            this.dateLabel.Text = "<html>Date:<color=Red>*";
            this.descriptionLabel.Text = "<html>Desciption:<color=Red>*";
            this.healthSubjectLabel.Text = $"<html>{Language.labelHealInformation}:<color=Red>*";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void InitComponent()
        {
            this.errorLabel.ForeColor = Color.Red;
            healthSubjectDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            healthSubjectDropDownList.DropDownListElement.EnableElementShadow = false;
            healthSubjectDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.healthSubjectLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.healthSubjectLabel.LabelElement.CustomFontSize = 10.5f;
            this.healthSubjectLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.healthSubjectLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.descriptionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionLabel.LabelElement.CustomFontSize = 10.5f;
            this.descriptionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.descriptionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.studentTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.studentTextBox.ForeColor = Color.FromArgb(33, 33, 33);


            this.descriptionTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.descriptionTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);


            this.healthSubjectDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.healthSubjectDropDownList.RootElement.CustomFontSize = 10.5f;
            this.healthSubjectDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.healthSubjectDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.healthSubjectDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.studentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.descriptionTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.healthSubjectLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.descriptionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.healthSubjectSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.descriptionSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
        }

        private void LoadReasonList()
        {
            List<string> medicalRecordList = new List<string>
            {
                  "Allergie",
                  "Aptitude Physique",
                  "Groupe Sanguin",
                  "Facteur Rhésus",
                    "Trouble de la Vision",
                   "Handicap",
                    "Maladie",
                    "Maladie Chronique",
                   "Déformation",
                   "Vaccin",
                   "Traitement médical"

            };
            this.healthSubjectDropDownList.DataSource = medicalRecordList;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.dateTimePicker.Text == string.Empty)
            {
                this.errorProvider.SetError(dateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.healthSubjectDropDownList.Text == "")
            {
                this.errorProvider.SetError(healthSubjectDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.healthSubjectDropDownList.Focus();
                return false;
            }
            if (this.descriptionTextBox.Text.Trim() == string.Empty)
            {
                this.errorProvider.SetError(this.descriptionTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.descriptionTextBox.Focus();
                return false;
            }

            return true;
        }


    }
}
