
using MediaFoundation;
using SchoolManagement.UI.Languages;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
namespace SchoolManagement.UI
{
    public partial class EditSubscriptionFeeForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList SchoolYearDropDownList {  get => schoolYearDropDownList; }
        public RadDropDownList SubscriptionTypeDropDownList {  get => subscriptionTypeDropDownList; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadSpinEditor DurationSpinEditor {  get => durationSpinEditor; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public RadButton AddSchoolYearButton {  get => addSchoolYearButton; }
        public RadButton AddSubscriptionTypeButton { get => addSubscriptionTypeButton; }
        public EditSubscriptionFeeForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.schoolYearLabel.Text = Language.labelSchoolYear;
            this.subscriptionTypeLabel.Text = Language.labelSubscription;
            this.amountLabel.Text = Language.labelAmount;
            this.durationLabel.Text = Language.labelDuration;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {

            this.schoolYearDropDownList.RootElement.EnableElementShadow = false;
            this.subscriptionTypeDropDownList.RootElement.EnableElementShadow = false;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.subscriptionTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.subscriptionTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.subscriptionTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.durationLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.durationLabel.LabelElement.CustomFontSize = 10.5f;
            this.durationLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.durationLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.durationSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.durationSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.durationSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            this.schoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.schoolYearDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.subscriptionTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.subscriptionTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.subscriptionTypeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.subscriptionTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.schoolYearDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.subscriptionTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;


            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.subscriptionTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.durationSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouvelle année scolaire";
            addSchoolYearButton.Image = Resources.plus;
            addSchoolYearButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addSchoolYearButton.ButtonElement.Padding = new Padding(0);
            addSubscriptionTypeButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouveau type d'abonnement";
            addSubscriptionTypeButton.Image = Resources.plus;
            addSubscriptionTypeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addSubscriptionTypeButton.ButtonElement.Padding = new Padding(0);
            this.schoolYearDropDownList.DisplayMember = "Name";
            this.schoolYearDropDownList.ValueMember = "Id";
            this.schoolYearDropDownList.SelectedIndex = -1;

            this.subscriptionTypeDropDownList.DisplayMember = "Name";
            this.subscriptionTypeDropDownList.ValueMember = "Id";
            this.subscriptionTypeDropDownList.SelectedIndex = -1;
            this.errorLabel.ForeColor = Color.Red;

        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.amountTextBox.TextChanging += AmountTextBox_TextChanging; ;
            schoolYearDropDownList.SelectedIndexChanged += SchoolYearDropDownList_SelectedIndexChanged; ;
            subscriptionTypeDropDownList.SelectedIndexChanged += SubscriptionTypeDropDownList_SelectedIndexChanged; ;


        }

        private void SubscriptionTypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (subscriptionTypeDropDownList.SelectedIndex < 0)
            {
                addSubscriptionTypeButton.Image = Resources.plus;
                addSubscriptionTypeButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer un nouveau type d'abonnement";
            }
            else
            {
                addSubscriptionTypeButton.Image = Resources.edit;
                addSubscriptionTypeButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de l'abonnement";
            }
        }

        private void SchoolYearDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (schoolYearDropDownList.SelectedIndex < 0)
            {
                addSchoolYearButton.Image = Resources.plus;
                addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer une nouvelle année scolaire";
            }
            else
            {
                addSchoolYearButton.Image = Resources.edit;
                addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de l'année scolaire";
            }
        }

        private void AmountTextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.schoolYearDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection de l'année scolaire est requise!";
                this.schoolYearDropDownList.Focus();
                return false;
            }

            if (this.subscriptionTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'un type d'abonnement est requise!";
                this.subscriptionTypeDropDownList.Focus();
                return false;
            }

            if (this.amountTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du montant est requise!";
                this.amountTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
