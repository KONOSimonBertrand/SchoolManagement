
using SchoolManagement.UI.Languages;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditRatingSystemForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList FrenchNameDropDownList { get => nameFrDropDownList; }
        public RadDropDownList EnglishNameDropDownList { get => nameEnDropDownList; }
        public RadDropDownList FrenchDescriptionDropDownList { get => descriptionFrDropDownList; }
        public RadDropDownList EnglishDescriptionDropDownList { get => descriptionEnDropDownList; }
        public RadDropDownList DomainDropDownList { get => domainDropDownList; }
        public RadTextBox MaxNoteTextBox { get => maxNoteTextBox; }
        public RadTextBox MinNoteTextBox { get => minNoteTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }

        public EditRatingSystemForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameFrLabel.Text = Language.labelFrenchAppreciation;
            this.nameEnLabel.Text = Language.labelEnglishDescription;
            this.maxNoteLabel.Text=Language.labelMaxNote;
            this.minNoteLabel.Text=Language.labelMinNote;
            this.domainLabel.Text = Language.labelDomain;
            this.descriptionFrLabel.Text = Language.labelFrenchDescription;
            this.descriptionEnLabel.Text = Language.labelEnglishDescription;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            this.nameFrDropDownList.SelectedIndexChanged += NameDropDownListSelectedIndexChanged;
            minNoteTextBox.TextChanging += TxtChanging;
            maxNoteTextBox.TextChanging += TxtChanging;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;


            if (nameFrDropDownList.Text == "")
            {
                this.errorLabel.Text = "La saisie de l'appréciation est requise!";
                this.nameFrDropDownList.Focus();
                return false;
            }
            if (descriptionFrDropDownList.Text == "")
            {
                this.errorLabel.Text = "La saisie de la description est requise!";
                this.descriptionFrDropDownList.Focus();
                return false;
            }
            if (nameEnDropDownList.Text == "")
            {
                this.errorLabel.Text = "La saisie de l'appréciation anglaise est requise!";
                this.nameEnDropDownList.Focus();
                return false;
            }
            if (descriptionEnDropDownList.Text == "")
            {
                this.errorLabel.Text = "La saisie de la description anglaise est requise!";
                this.descriptionEnDropDownList.Focus();
                return false;
            }

            if (this.minNoteTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la note minimale est requise!";
                this.minNoteTextBox.Focus();
                return false;
            }
            if (this.maxNoteTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la note maximale est requise!";
                this.maxNoteTextBox.Focus();
                return false;
            }
            if (domainDropDownList.SelectedIndex<0)
            {
                this.errorLabel.Text = "Le choix du domaine est requise!";
                this.domainDropDownList.Focus();
                return false;
            }
            return true;
        }
        private void InitComponent()
        {
           
            this.nameFrDropDownList.RootElement.EnableElementShadow = false;
            this.nameEnDropDownList.RootElement.EnableElementShadow = false;
            this.descriptionFrDropDownList.RootElement.EnableElementShadow = false;
            this.descriptionEnDropDownList.RootElement.EnableElementShadow = false;

            this.nameFrLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameFrLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameFrLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameEnLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameEnLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameEnLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.descriptionFrLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionFrLabel.LabelElement.CustomFontSize = 10.5f;
            this.descriptionFrLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.descriptionFrLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.descriptionEnLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionEnLabel.LabelElement.CustomFontSize = 10.5f;
            this.descriptionEnLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.descriptionEnLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.minNoteLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.minNoteLabel.LabelElement.CustomFontSize = 10.5f;
            this.minNoteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.minNoteLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.maxNoteLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.maxNoteLabel.LabelElement.CustomFontSize = 10.5f;
            this.maxNoteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.maxNoteLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.domainLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.domainLabel.LabelElement.CustomFontSize = 10.5f;
            this.domainLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.domainLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.minNoteTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.minNoteTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.minNoteTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.maxNoteTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.maxNoteTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.maxNoteTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.nameFrDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrDropDownList.RootElement.CustomFontSize = 10.5f;
            this.nameFrDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.nameFrDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.nameEnDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnDropDownList.RootElement.CustomFontSize = 10.5f;
            this.nameEnDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.nameEnDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.descriptionFrDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionFrDropDownList.RootElement.CustomFontSize = 10.5f;
            this.descriptionFrDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.descriptionFrDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.descriptionEnDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.descriptionEnDropDownList.RootElement.CustomFontSize = 10.5f;
            this.descriptionEnDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.descriptionEnDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.domainDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.domainDropDownList.RootElement.CustomFontSize = 10.5f;
            this.domainDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.domainDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameFrLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameEnLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.descriptionFrLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.descriptionEnLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.domainLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.minNoteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.maxNoteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameFrSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameEnSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.descriptionFrSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.descriptionEnSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.minNoteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.maxNoteSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.domainSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            var nameFrList = new List<string>
            {
                "A+",
                "A",
                "ECA",
                "NA",
                "Exellent",
                "Très bien",
                "Bien",
                "Assez bien",
                "Passable",
                "Médiocre",
                "Mal",
                "Très mal",
                "Nul"
            };
            this.nameFrDropDownList.DataSource = nameFrList;
            var nameEnList = new List<string>
            {
                "A+",
                "ME",
                "AE",
                "NYE",
                "Exellent",
                "Very good",
                "Good",
                "Pretty good",
                "Passable",
                "Poor",
                "Bad",
                "Very bad",
                "Nul"
            };
            this.nameEnDropDownList.DataSource = nameEnList;
            var descriptionFrList = new List<string>
            {
                "Expert",
                "Acquis",
                "En Cours d'Acquisition",
                "Non Acquis",
                "Parfait",
                "Très bien",
                "Bien",
                "Assez bien",
                "Passable",
                "Médiocre",
                "Mal",
                "Très mal",
                "Nul"
            };
            this.descriptionFrDropDownList.DataSource = descriptionFrList;
            var descriptionEnList = new List<string>
            {
                "Expert",
                "Meeting Expectation",
                "Approaching Expectation",
                "Not Yet Expectation",
                "Perfect",
                "Very good",
                "Good",
                "Pretty good",
                "Passable",
                "Poor",
                "Bad",
                "Very bad",
                "Nul"
            };
            this.descriptionEnDropDownList.DataSource = descriptionEnList;
            this.domainDropDownList.Items.Add(new RadListDataItem("Note"));
            this.domainDropDownList.Items.Add(new RadListDataItem("Moyenne"));
        }
        private void TxtChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
        private void NameDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (nameFrDropDownList.Text)
            {
                case "Exellent":
                    descriptionFrDropDownList.Text = "Excellent";
                    nameEnDropDownList.Text = "Excellent";
                    descriptionEnDropDownList.Text = "Excellent";
                    minNoteTextBox.Text = "17";
                    maxNoteTextBox.Text = "20";
                    break;
                case "Très bien":
                    descriptionFrDropDownList.Text = "Très bien";
                    nameEnDropDownList.Text = "Very good";
                    descriptionEnDropDownList.Text = "Very good";
                    minNoteTextBox.Text = "16";
                    maxNoteTextBox.Text = "16,99";
                    break;
                case "Bien":
                    descriptionFrDropDownList.Text = "Bien";
                    nameEnDropDownList.Text = "Good";
                    descriptionEnDropDownList.Text = "Good";
                    minNoteTextBox.Text = "14";
                    maxNoteTextBox.Text = "15,99";
                    break;
                case "Assez bien":
                    descriptionFrDropDownList.Text = "Très bien";
                    nameEnDropDownList.Text = "Pretty good";
                    descriptionEnDropDownList.Text = "Pretty good";
                    minNoteTextBox.Text = "12";
                    maxNoteTextBox.Text = "13,99";
                    break;
                case "Passable":
                    descriptionFrDropDownList.Text = "Passable";
                    nameEnDropDownList.Text = "Passable";
                    descriptionEnDropDownList.Text = "Passable";
                    minNoteTextBox.Text = "10";
                    maxNoteTextBox.Text = "11,99";
                    break;
                case "Médiocre":
                    descriptionFrDropDownList.Text = "Passable";
                    nameEnDropDownList.Text = "Passable";
                    descriptionEnDropDownList.Text = "Passable";
                    minNoteTextBox.Text = "9";
                    maxNoteTextBox.Text = "9,99";
                    break;
                case "Insuffisant":
                    descriptionFrDropDownList.Text = "Insuffisant";
                    nameEnDropDownList.Text = "Weak";
                    descriptionEnDropDownList.Text = "Weak";
                    minNoteTextBox.Text = "8";
                    maxNoteTextBox.Text = "8,99";
                    break;
                case "Faible":
                    descriptionFrDropDownList.Text = "Faible";
                    nameEnDropDownList.Text = "Very weak";
                    descriptionEnDropDownList.Text = "Very weak";
                    minNoteTextBox.Text = "7";
                    maxNoteTextBox.Text = "7,99";
                    break;
                case "Très Faible":
                    descriptionFrDropDownList.Text = "Très Faible";
                    nameEnDropDownList.Text = "Poor";
                    descriptionEnDropDownList.Text = "Poor";
                    minNoteTextBox.Text = "5";
                    maxNoteTextBox.Text = "6,99";
                    break;
                case "Mauvais Travail":
                    descriptionFrDropDownList.Text = "Mauvais Travail";
                    nameEnDropDownList.Text = "Very Poor";
                    descriptionEnDropDownList.Text = "Very Poor";
                    minNoteTextBox.Text = "0";
                    maxNoteTextBox.Text = "5,99";
                    break;
                case "Nul":
                    descriptionFrDropDownList.Text = "Nul";
                    nameEnDropDownList.Text = "Nul";
                    descriptionEnDropDownList.Text = "Nul";
                    minNoteTextBox.Text = "0";
                    maxNoteTextBox.Text = "0";
                    break;
                case "A+":
                    descriptionFrDropDownList.Text = "Expert";
                    nameEnDropDownList.Text = "A+";
                    descriptionEnDropDownList.Text = "Expert";
                    minNoteTextBox.Text = "18";
                    maxNoteTextBox.Text = "20";
                    break;
                case "A":
                    descriptionFrDropDownList.Text = "Acquis";
                    nameEnDropDownList.Text = "ME";
                    descriptionEnDropDownList.Text = "Meeting Expectation";
                    minNoteTextBox.Text = "15";
                    maxNoteTextBox.Text = "17";

                    break;
                case "ECA":
                    descriptionFrDropDownList.Text = "En Cours d'Acquisition";
                    nameEnDropDownList.Text = "AE";
                    descriptionEnDropDownList.Text = "Approaching Expectation";
                    minNoteTextBox.Text = "10";
                    maxNoteTextBox.Text = "14";
                    break;
                case "NA":
                    descriptionFrDropDownList.Text = "Non Acquis";
                    nameEnDropDownList.Text = "NYE";
                    descriptionEnDropDownList.Text = "Not Yet Expectation";
                    minNoteTextBox.Text = "0";
                    maxNoteTextBox.Text = "9";
                    break;

            }
        }
    }
}
