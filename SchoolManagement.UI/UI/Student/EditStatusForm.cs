using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditStatusForm : RadForm
    {
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList ReasonDropDownList {  get => reasonDropDownList; }
        public EditStatusForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.reasonLabel.Text = $"<html>{Language.labelReason}:<color=Red>*";
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.errorLabel.ForeColor = Color.Red;
            this.reasonLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.reasonLabel.LabelElement.CustomFontSize = 10.5f;
            this.reasonLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.reasonLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reasonDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.reasonDropDownList.RootElement.CustomFontSize = 10.5f;
            this.reasonDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.reasonDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);
            this.reasonDropDownList.RootElement.EnableElementShadow = false;

            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.reasonLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reasonDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.reasonSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            List<string> frenchReasons = new();
            frenchReasons.Add("Fait partie des effectifs");
            frenchReasons.Add("Exclus");
            frenchReasons.Add("Affectation des parents");
            frenchReasons.Add("Ne fait plus partie des effectifs");
            frenchReasons.Add("Maladie");
            frenchReasons.Add("Absence");
            frenchReasons.Add("Décès");

            List<string> englishReasons = new();
            englishReasons.Add("Is student");
            englishReasons.Add("Excluded");
            englishReasons.Add("Assignment of parents");
            englishReasons.Add("No longer a student");
            englishReasons.Add("illness");
            englishReasons.Add("Absence");
            englishReasons.Add("Death");
            this.reasonDropDownList.DataSource= Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ?englishReasons: frenchReasons;
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();
            if (this.reasonDropDownList.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(this.reasonDropDownList, Language.messageFillField);
                this.reasonDropDownList.Focus();
                return false;
            }

            return true;
        }
    }
}
