using System;


using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditTuitionDiscountForm : RadForm
    {

        #region Properties
        public RadTextBox StudentTextBox { get=>studentTextBox;}
        public RadTextBox ClassTextBox {  get=>classTextBox;}
        public RadTextBox SchoolYearTextBox { get=>schoolYearTextBox;}
        public RadDropDownList CashFlowTypeDropDownList { get => costTypeDropDownList; }
        public RadTextBox  CostTextBox { get => costTextBox;}
        public RadTextBox DiscountTextBox { get => discountTextBox;}
        public RadTextBox ReasonTextBox { get => reasonTextBox;}
        public RadTextBox OrdoredByTextBox { get => ordoredByTextBox;}
        public RadLabel ErrorLabel { get => errorLabel;}
        public ErrorProvider ErrorProvider { get => errorProvider;}
        public RadButton SaveButton { get => saveButton;}
        public RadButton CloseButton { get => closeButton;}
        #endregion
        public EditTuitionDiscountForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text =Language.labelStudent;
            this.classLabel.Text = Language.labelClass;
            this.schoolYearLabel.Text = Language.labelSchoolYear;
            this.costTypeLabel.Text = "<html>" + Language.labelSchoolingFee + ":" + "<color=Red>*";
            costLabel.Text=Language.labelAmount;
            discountLabel.Text = "<html>" + Language.labelDiscountAmount + ":" + "<color=Red>*";
            ordoredByLabel.Text = "<html>" + Language.labelOrdoredBy + ":" + "<color=Red>*";
            this.closeButton.Text=Language.labelCancel;
            this.saveButton.Text=Language.labelSave;
        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.discountTextBox.TextChanging += AmountTextBox_TextChanging;
        }

        private void InitComponent()
        {

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costTypeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeLabel.LabelElement.CustomFontSize = 10.5f;
            this.costTypeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.costTypeLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.discountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.discountLabel.LabelElement.CustomFontSize = 10.5f;
            this.discountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reasonLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.reasonLabel.LabelElement.CustomFontSize = 10.5f;
            this.reasonLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.restToPayLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.costLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.costLabel.LabelElement.CustomFontSize = 10.5f;
            this.costLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.ordoredByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.ordoredByLabel.LabelElement.CustomFontSize = 10.5f;
            this.ordoredByLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.studentTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.studentTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.studentTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.costTypeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.costTypeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.costTypeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.costTypeDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.costTypeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.discountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.discountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.discountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.reasonTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.reasonTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.reasonTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.costTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.costTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.costTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.ordoredByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.ordoredByTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.ordoredByTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;


            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }


            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costTypeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.discountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reasonLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.costLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.ordoredByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.costTypeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.studentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.reasonTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.discountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.costTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.ordoredByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costTypeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.discountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.reasonSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.costSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.ordoredBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.errorLabel.ForeColor = Color.Red;
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
            this.errorProvider.Clear();
            if (this.costTypeDropDownList.SelectedItem == null)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(costTypeDropDownList, Language.messageFillField);
                this.costTypeDropDownList.Focus();
                return false;
            }

            if (this.discountTextBox.Text == "" || double.Parse(this.discountTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(discountTextBox, Language.messageFillField);
                this.discountTextBox.Focus();
                return false;
            }

            if (double.Parse(this.discountTextBox.Text) > double.Parse(this.costTextBox.Text))
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(discountTextBox, Language.messagePaymentGreaterThanToPaid); this.errorLabel.Text = "Le montant de la réduction est suéprieur au type de frais";
                this.discountTextBox.Focus();
                return false;
            }
            if (this.ordoredByTextBox.Text == "" || double.Parse(this.discountTextBox.Text) < 1)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(ordoredByTextBox, Language.messageFillField);
                this.ordoredByTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
