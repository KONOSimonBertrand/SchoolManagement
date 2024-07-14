

using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolingCostForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadDropDownList SchoolYearDropDownList {  get => schoolYearDropDownList; }
        public RadButton AddSchoolYearButton { get => addSchoolYearButton ; }
        public RadDropDownList ClassDropDownList { get => classDropDownList; }
        public RadButton AddClassButton {  get => addClassButton; }
        public RadDropDownList CostTypeDropDownList {  get => costTypeDropDownList; }
        public RadButton AddCostTypeButton { get => addCostTypeButton; }
        public RadDropDownList CostPayableDropDownList { get => costPayableDropDownList; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadTextBox TrancheNumberTextBox { get => trancheNumberTextBox; }
        public RadGridView  TranchesGridView { get => tranchesGridView; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditSchoolingCostForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.closeButton.Click += CloseButton_Click;
            classDropDownList.SelectedIndexChanged += ClassDropDownList_SelectedIndexChanged;
            costTypeDropDownList.SelectedIndexChanged += CostTypeDropDownList_SelectedIndexChanged;
            schoolYearDropDownList.SelectedIndexChanged += SchoolYearDropDownList_SelectedIndexChanged;
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TxtChanging);
            this.trancheNumberTextBox.TextChanging += new TextChangingEventHandler(TxtChanging);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.schoolYearDropDownList.RootElement.EnableElementShadow = false;
            this.classDropDownList.RootElement.EnableElementShadow = false;
            this.costTypeDropDownList.RootElement.EnableElementShadow = false;
            this.costPayableDropDownList.RootElement.EnableElementShadow = false;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.costTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.costTypeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costPayableLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costPayableLabel.LabelElement.CustomFontSize = 10.5f;
            this.costPayableLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.costPayableLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.trancheNumberLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.trancheNumberLabel.LabelElement.CustomFontSize = 10.5f;
            this.trancheNumberLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.trancheNumberLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.tranchesGroupBox.GroupBoxElement.CustomFont = ViewUtilities.MainFont;
            this.tranchesGroupBox.GroupBoxElement.CustomFontSize = 10.5f;
            this.tranchesGroupBox.ForeColor = Color.FromArgb(89, 89, 89);

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.trancheNumberTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.trancheNumberTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.trancheNumberTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            this.schoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.schoolYearDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.classDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.classDropDownList.RootElement.CustomFontSize = 10.5f;
            this.classDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.classDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.costTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.costTypeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.costTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.costPayableDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.costPayableDropDownList.RootElement.CustomFontSize = 10.5f;
            this.costPayableDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.costPayableDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.costTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.schoolYearDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            tranchesGridView.GridViewElement.CustomFont = ViewUtilities.MainFont;
            tranchesGridView.GridViewElement.CustomFontSize = 10.5f;
            this.tranchesGridView.RootElement.EnableElementShadow = false;
            this.tranchesGridView.GridViewElement.DrawFill = false;
            this.tranchesGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            this.tranchesGridView.BackColor = Color.Transparent;
            this.tranchesGridView.GridViewElement.DrawFill = true;


            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.trancheNumberTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costPayableLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.trancheNumberLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costDueSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.trancheNumberSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont =ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

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

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";
            this.classDropDownList.SelectedIndex = -1;

            this.costTypeDropDownList.DisplayMember = "Name";
            this.costTypeDropDownList.ValueMember = "Id";
            this.costTypeDropDownList.SelectedIndex = -1;

            var yesItem = new RadListDataItem("Oui", "True");
            yesItem.Selected = true;
            var noItem = new RadListDataItem("Non", "False");
            this.costPayableDropDownList.Items.Add(yesItem);
            this.costPayableDropDownList.Items.Add(noItem);
            errorLabel.ForeColor = Color.Red;
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";

            if (this.schoolYearDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection de l'année scolaire est requise!";
                this.schoolYearDropDownList.Focus();
                return false;
            }

            if (this.classDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'une classe est requise!";
                this.classDropDownList.Focus();
                return false;
            }

            if (this.costTypeDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'un type de frais est requise!";
                this.costTypeDropDownList.Focus();
                return false;
            }

            if (this.amountTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du montant est requise!";
                this.amountTextBox.Focus();
                return false;
            }
            
            if (this.trancheNumberTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du nombre de tranches est requise!";
                this.trancheNumberTextBox.Focus();
                return false;
            }
            return true;
        }

        private void TxtChanging(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
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
        private void ClassDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            
            if (classDropDownList.SelectedIndex < 0)
            {
                addClassButton.Image = Resources.plus;
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer ue nouvelle classe";
            }
            else
            {
                addClassButton.Image = Resources.edit;
                addClassButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de la classe";
            }
        }
        private void CostTypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
            if (costTypeDropDownList.SelectedIndex < 0)
            {
                addCostTypeButton.Image = Resources.plus;
                addCostTypeButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer un nouveau type de frais";
            }
            else
            {
                addCostTypeButton.Image = Resources.edit;
                addCostTypeButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations du type de frais";
            }
        }

    }
}
