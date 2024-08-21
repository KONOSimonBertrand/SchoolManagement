using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;
using MediaFoundation;
using System.ComponentModel;

namespace SchoolManagement.UI
{
    public partial class EditStudentEnrollingForm : RadForm
    {
        public EditStudentEnrollingForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            studentDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;
            this.errorLabel.ForeColor = Color.Red;

            this.classDropDownList.RootElement.EnableElementShadow = false;
            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.roomLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.oldSchoolLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolLabel.LabelElement.CustomFontSize = 10.5f;
            this.oldSchoolLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.oldSchoolLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.repeaterLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterLabel.LabelElement.CustomFontSize = 10.5f;
            this.repeaterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.repeaterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.paymentMeanLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanLabel.LabelElement.CustomFontSize = 10.5f;
            this.paymentMeanLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.paymentMeanLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionIdLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionIdLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.transactionIdLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionDateLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.transactionDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.divisionLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.divisionLabel.LabelElement.CustomFontSize = 10.5f;
            this.divisionLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.divisionLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.schoolYearTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.oldSchoolTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.oldSchoolTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.amountTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.transactionDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.transactionDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.dateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.transactionDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.transactionDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.paymentMeanDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanDropDownList.RootElement.CustomFontSize = 10.5f;
            this.paymentMeanDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.paymentMeanDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.repeaterDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterDropDownList.RootElement.CustomFontSize = 10.5f;
            this.repeaterDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.repeaterDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.transactionIdTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.transactionIdTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.roomDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.paymentMeanDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            foreach (Telerik.WinControls.UI.SplitPanel sp in this.schoolYearSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (Telerik.WinControls.UI.SplitPanel sp in this.studentSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (Telerik.WinControls.UI.SplitPanel sp in this.amountSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }

            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.oldSchoolTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;


            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.oldSchoolLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.repeaterLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.roomLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.divisionLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionIdLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.oldSchoolSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.repeaterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.schoolYearSplitContainer.RootElement.EnableElementShadow = false;
            this.studentSplitContainer.RootElement.EnableElementShadow = false;
            this.amountSplitContainer.RootElement.EnableElementShadow = false;

            addStudentButton.RootElement.ToolTipText = Language.messageClickToAddStudent;
            addStudentButton.Image = ViewUtilities.GetImage("Add");
            addClassButton.RootElement.ToolTipText = Language.messageClickToAddClass;
            addClassButton.Image = ViewUtilities.GetImage("Add");
            addRoomButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            addRoomButton.Image = ViewUtilities.GetImage("Add");
            addPaymentMeanButton.Image = ViewUtilities.GetImage("Add");
            addPaymentMeanButton.RootElement.ToolTipText = Language.messageClickToAddPaymentMean;

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";

            this.roomDropDownList.DisplayMember = "Name";
            this.roomDropDownList.ValueMember = "Id";

            this.paymentMeanDropDownList.DisplayMember = "FullName";
            this.paymentMeanDropDownList.ValueMember = "Id";
            this.paymentMeanDropDownList.SelectedIndex = -1;

            this.repeaterDropDownList.Items.Add(new RadListDataItem("Non", 0));
            this.repeaterDropDownList.Items.Add(new RadListDataItem("Oui", 1));
            this.repeaterDropDownList.SelectedIndex = 0;
            this.repeaterDropDownList.DropDownStyle = RadDropDownStyle.DropDownList;

        }

        private void InitLanguage()
        {
            throw new NotImplementedException();
        }

        private void InitEvent()
        {
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
            studentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
            classDropDownList.SelectedIndexChanged += ClassDropDownList_SelectedIndexChanged;
            roomDropDownList.SelectedIndexChanged += RoomDropDownList_SelectedIndexChanged;
            paymentMeanDropDownList.SelectedIndexChanged += PaymentMeanDropDownList_SelectedIndexChanged;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }
        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !ViewUtilities.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StudentDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (studentDropDownList.SelectedIndex < 0)
            {
                addStudentButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addStudentButton.RootElement.ToolTipText = Language.messageClickToAddStudent;
            }
            else
            {
                addStudentButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addStudentButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void ClassDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (classDropDownList.SelectedIndex < 0)
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addClassButton.RootElement.ToolTipText = Language.messageClickToAddClass;
            }
            else
            {
                addClassButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addClassButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void RoomDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (roomDropDownList.SelectedIndex < 0)
            {
                addRoomButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addRoomButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            }
            else
            {
                addRoomButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addRoomButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }
        private void PaymentMeanDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (paymentMeanDropDownList.SelectedIndex < 0)
            {
                addPaymentMeanButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addPaymentMeanButton.RootElement.ToolTipText = Language.messageClickToAddPaymentMean;
            }
            else
            {
                addPaymentMeanButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addPaymentMeanButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (dateTimePicker.Text == "")
            {
                this.errorLabel.Text = "La saisie de la date est requise!";
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.studentDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'un élève est requise!";
                this.studentDropDownList.Focus();
                return false;
            }
            if (this.classDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'une classe est requise!";
                this.classDropDownList.Focus();
                return false;
            }
            if (this.roomDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection d'une salle est requise!";
                this.roomDropDownList.Focus();
                return false;
            }
            if (double.Parse(this.amountTextBox.Text) == 0)
            {
                this.errorLabel.Text = "La saisie du montant est requise!";
                this.amountTextBox.Focus();
                return false;
            }
            if (this.paymentMeanDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = "La sélection du moyen paiement est requise!";
                this.paymentMeanDropDownList.Focus();
                return false;
            }
            if (transactionDateTimePicker.Text == "")
            {
                this.errorLabel.Text = "La saisie de la date de la transaction est requise!";
                this.transactionDateTimePicker.Focus();
                return false;
            }
            //if (inscription.Divisions.Sum(m => m.Amount) != double.Parse(this.amountTextBox.Text))
            //{
            //    this.errorLabel.Text = "La répartition du montant versé est incorrecte!";
            //    return false;
            //}
            //if (this.paymentMeanDropDownList.SelectedIndex > -1)
            //{
            //    var paiementMean = paymentMeanDropDownList.SelectedItem.DataBoundItem as PaymentMean;
            //    if (paiementMean.Type == "Compte Scolaire")
            //    {
            //        var amount = double.Parse(this.amountTextBox.Text);
            //        var student = studentDropDownList.SelectedItem.DataBoundItem as Student;
            //        student.Account = student.GetAccountBalance();
            //        if (student.Account < amount)
            //        {
            //            this.errorLabel.Text = "Le sole du compte [" + student.Account + " FCFA]  est inférieur au montant à payer!";
            //            return false;
            //        }
            //    }
            //}
            return true;
        }
    }
}
