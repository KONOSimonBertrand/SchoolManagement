

using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolSupplieFeeForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList SchoolYearDropDownList {  get => schoolYearDropDownList; }
        public RadButton AddSchoolYearButton { get => addSchoolYearButton ; }
        public RadAutoCompleteBox ClassAutoCompleteBox {  get => classAutoCompleteBox; }
        public RadButton AddClassButton {  get => addClassButton; }
        public RadDropDownList CostTypeDropDownList {  get => costTypeDropDownList; }
        public RadButton AddCostTypeButton { get => addCostTypeButton; }
        public RadDropDownList CostPayableDropDownList { get => costPayableDropDownList; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadTextBox RequiredQuantityTextBox { get => requiredQuantityTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditSchoolSupplieFeeForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.schoolYearLabel.Text = Language.labelSchoolYear;
            this.classLabel.Text = Language.labelClass+"s";
            this.costTypeLabel.Text = Language.LabelSchoolSupplie;
            this.costPayableLabel.Text = Language.labelExigible;
            this.amountLabel.Text = Language.labelAmount;
            this.requiredQuantityLabel.Text = Language.LabelRequiredQuantity;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitEvent()
        {
            this.closeButton.Click += CloseButton_Click;
            classAutoCompleteBox.SelectionChanged += ClassAutoCompleteBox_SelectionChanged; ;
            costTypeDropDownList.SelectedIndexChanged += CostTypeDropDownList_SelectedIndexChanged;
            schoolYearDropDownList.SelectedIndexChanged += SchoolYearDropDownList_SelectedIndexChanged;
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TxtChanging);
            this.requiredQuantityTextBox.TextChanging += new TextChangingEventHandler(TxtChanging);
        }

        private void ClassAutoCompleteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (classAutoCompleteBox.SelectionLength > 0)
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de la classe";
               
            }
            else
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer ue nouvelle classe";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.schoolYearDropDownList.RootElement.EnableElementShadow = false;
            this.classAutoCompleteBox.RootElement.EnableElementShadow = false;
            this.costTypeDropDownList.RootElement.EnableElementShadow = false;
            this.costPayableDropDownList.RootElement.EnableElementShadow = false;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.costTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costPayableLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costPayableLabel.LabelElement.CustomFontSize = 10.5f;
            this.costPayableLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.requiredQuantityLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.requiredQuantityLabel.LabelElement.CustomFontSize = 10.5f;
            this.requiredQuantityLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.requiredQuantityTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.requiredQuantityTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.schoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            this.schoolYearDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.classAutoCompleteBox.RootElement.CustomFont = ViewUtilities.MainFont;
            this.classAutoCompleteBox.RootElement.CustomFontSize = 10.5f;

            this.costTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.costTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.costPayableDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.costPayableDropDownList.RootElement.CustomFontSize = 10.5f;
            this.costPayableDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.costTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.schoolYearDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }



            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.requiredQuantityTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costPayableLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.requiredQuantityLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costDueSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.requiredQuantitySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont =ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;

            addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouvelle année scolaire";
            addSchoolYearButton.Image = Resources.plus;
            addSchoolYearButton.DisplayStyle=DisplayStyle.Image;
            addSchoolYearButton.ButtonElement.Padding = new Padding(0);
            addSchoolYearButton.ImageAlignment=ContentAlignment.MiddleCenter;
            addClassButton.RootElement.ToolTipText = "Cliquer ici pour ajouter une nouvelle classe";
            addClassButton.Image = Resources.plus;
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.ButtonElement.Padding = new Padding(0);
            addCostTypeButton.RootElement.ToolTipText = "Cliquer ici pour ajouter un nouveau type de frais";
            addCostTypeButton.Image = Resources.plus;
            addCostTypeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addCostTypeButton.ButtonElement.Padding = new Padding(0);
            this.schoolYearDropDownList.DisplayMember = "Name";
            this.schoolYearDropDownList.ValueMember = "Id";
            this.schoolYearDropDownList.SelectedIndex = -1;

            classAutoCompleteBox.AutoCompleteDisplayMember = "Name";
            classAutoCompleteBox.AutoCompleteValueMember = "Id";

            this.costTypeDropDownList.DisplayMember = "Name";
            this.costTypeDropDownList.ValueMember = "Id";
            this.costTypeDropDownList.SelectedIndex = -1;

            var yesItem = new RadListDataItem("Oui", "True");
            yesItem.Selected = true;
            var noItem = new RadListDataItem("Non", "False");
            this.costPayableDropDownList.Items.Add(yesItem);
            this.costPayableDropDownList.Items.Add(noItem);
            errorLabel.ForeColor = Color.Red;
            requiredQuantityTextBox.NullText="<=6";
            addClassButton.Image = Utilities.ViewUtilities.GetImage("Add");
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorProvider.Clear();

            if (this.schoolYearDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection de l'année scolaire est requise!";
                this.errorProvider.SetError(schoolYearDropDownList, this.errorLabel.Text);
                this.schoolYearDropDownList.Focus();
                return false;
            }


            if (this.costTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'un type de frais est requise!";
                this.errorProvider.SetError(costTypeDropDownList, this.errorLabel.Text);
                this.costTypeDropDownList.Focus();
                return false;
            }

            if (this.amountTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du montant est requise!";
                this.errorProvider.SetError(amountTextBox, this.errorLabel.Text);
                this.amountTextBox.Focus();
                return false;
            }
            
            if (this.requiredQuantityTextBox.Text == ""|| this.requiredQuantityTextBox.Text == "0")
            {
                this.errorLabel.Text = "La saisie du nombre de tranches est requise!";
                this.errorProvider.SetError(requiredQuantityTextBox, this.errorLabel.Text);
                this.requiredQuantityTextBox.Focus();
                return false;
            }

            if (!this.classAutoCompleteBox.Items.Any())
            {
                this.errorLabel.Text = "La sélection d'une classe est requise!";
                this.errorProvider.SetError(classAutoCompleteBox, this.errorLabel.Text);
                this.classAutoCompleteBox.Focus();
                return false;
            }
            return true;
        }

        private void TxtChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !Helper.Helper.IsNumber(e.NewValue);
        }

        private void SchoolYearDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
            if (schoolYearDropDownList.SelectedIndex < 0)
            {
                addSchoolYearButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer une nouvelle année scolaire";
            }
            else
            {
                addSchoolYearButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addSchoolYearButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de l'année scolaire";
            }
        }
      
        private void CostTypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
            if (costTypeDropDownList.SelectedIndex < 0)
            {
                addCostTypeButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addCostTypeButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer un nouveau type de frais";
            }
            else
            {
                addCostTypeButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addCostTypeButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations du type de frais";
            }
        }

    }
}
