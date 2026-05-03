
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditStudentEnrollingForm : RadForm
    {

        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadPanel EditPanel { get => editPanel; }
        public RadPanel InvoicePanel { get => invoicePanel; }
        public RadDateTimePicker EnrollingDateTimePicker { get => dateTimePicker; }
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadButton AddStudentButton { get => addStudentButton; }
        public RadDropDownList ClassDropDownList { get => classDropDownList; }
        public RadButton AddClassButton { get => addClassButton; }
        public RadButton AddRoomButton { get => addRoomButton; }
        public RadDropDownList RoomDropDownList { get => roomDropDownList; }
        public RadTextBox OldSchoolTextBox { get => oldSchoolTextBox; }
        public RadDropDownList RepeaterDropDownList { get => repeaterDropDownList; }
        public RadDropDownList PaymentMeanDropDownList { get => paymentMeanDropDownList; }
        public RadDateTimePicker TransactionDateTimePicker { get => transactionDateTimePicker; }
        public RadTextBox TransactionIdTextBox { get => transactionIdTextBox; }
        public RadTextBox IdTransactionTextBox { get => IdTransactionTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider DataErrorProvider { get => errorProvider; }
        public RadTextBox DoneByTextBox { get => doneByTextBox; }
        public RadLabel QuantityLabel { get => startDateLabel; }
        public RadSeparator QuantitySeparetor { get => startDateSeparator; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadDateTimePicker StartDateTimePicker { get => startDateTimePicker; }
        public RadDateTimePicker EndDateTimePicker { get => endDateTimePicker; }
        public RadLabel StartDateLabel { get => startDateLabel; }
        public RadLabel EndDateLabel { get => endDateLabel; }
        public RadSeparator StartDateSeparator { get => startDateSeparator; }
        public RadSeparator EndDateSeparator { get => endDateSeparator; }
        public RadListView InvoiceItemListView { get => invoiceItemListView; }
        public RadListView InvoiceTotalListView { get => invoiceTotalListView; }
        public RadLabel AmountLabel { get => amountLabel; }
        public RadLabel FeesTotalLabel { get => feesTotalLabel; }
        public RadDropDownList FeesDropDownList { get => feesDropDownList; }
        public RadButton AddInvoiceItemButton { get => addInvoiceItemButton; }
        public RadButton RemoveInvoiceItemButton { get => removeInvoiceItemButton; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public RadSeparator AmountSeparator { get => amountSeparator; }
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
            this.errorLabel.ForeColor = Color.Red;

            this.classDropDownList.RootElement.EnableElementShadow = false;
            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.dateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 10.5f;
            this.dateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.roomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.roomLabel.LabelElement.CustomFontSize = 10.5f;
            this.roomLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.oldSchoolLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolLabel.LabelElement.CustomFontSize = 10.5f;
            this.oldSchoolLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.repeaterLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterLabel.LabelElement.CustomFontSize = 10.5f;
            this.repeaterLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.feesLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.feesLabel.LabelElement.CustomFontSize = 10.5f;
            this.feesLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.doneByLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.doneByLabel.LabelElement.CustomFontSize = 10.5f;
            this.doneByLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.startDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.startDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.startDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.amountLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.amountLabel.LabelElement.CustomFontSize = 10.5f;
            this.amountLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.endDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.endDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.endDateLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.feesTotalLabel.LabelElement.CustomFontSize = 10.5f;
            this.feesTotalLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.oldSchoolTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.oldSchoolTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.doneByTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.doneByTextBox.TextBoxElement.CustomFontSize = 10.5f;


            this.amountTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.amountTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.startDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.startDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.startDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.startDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.endDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.endDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.endDateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.endDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.dateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.dateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.dateTimePicker.DateTimePickerElement.CustomFont = ViewUtilities.MainFont;
            this.dateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.repeaterDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.repeaterDropDownList.RootElement.CustomFontSize = 10.5f;
            this.repeaterDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.transactionDateLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionDateLabel.TextAlignment = ContentAlignment.BottomLeft;


            this.paymentMeanLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanLabel.LabelElement.CustomFontSize = 10.5f;
            this.paymentMeanLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.transactionIdLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdLabel.LabelElement.CustomFontSize = 10.5f;
            this.transactionIdLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.paymentMeanDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.paymentMeanDropDownList.RootElement.CustomFontSize = 10.5f;
            this.paymentMeanDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.transactionDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.transactionDateTimePicker.CustomFormat = "d/MM/yyyy";
            this.transactionDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.transactionDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);

            this.transactionIdTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.transactionIdTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.studentDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.classDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.roomDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            foreach (RadControl c in this.invoicePanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.oldSchoolTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.oldSchoolLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.repeaterLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.roomLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.endDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.startDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.transactionIdLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.roomSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.oldSchoolSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.repeaterSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.dateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.feesTotalSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.feesSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;


            addStudentButton.RootElement.ToolTipText = Language.messageClickToAddStudent;
            addStudentButton.Image = ViewUtilities.GetImage("Add");
            addStudentButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addStudentButton.ButtonElement.Padding = new Padding(0);
            addClassButton.RootElement.ToolTipText = Language.messageClickToAddClass;
            addClassButton.Image = ViewUtilities.GetImage("Add");
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.ButtonElement.Padding = new Padding(0);
            addRoomButton.RootElement.ToolTipText = Language.messageClickToAddRoom;
            addRoomButton.Image = ViewUtilities.GetImage("Add");
            addRoomButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addRoomButton.ButtonElement.Padding = new Padding(0);

            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";

            this.classDropDownList.DisplayMember = "Name";
            this.classDropDownList.ValueMember = "Id";

            this.roomDropDownList.DisplayMember = "Name";
            this.roomDropDownList.ValueMember = "Id";

            this.paymentMeanDropDownList.DisplayMember = "Name";
            this.paymentMeanDropDownList.ValueMember = "Id";

            this.repeaterDropDownList.Items.Add(new RadListDataItem(Language.labelNo, 0));
            this.repeaterDropDownList.Items.Add(new RadListDataItem(Language.labelYes, 1));
            this.repeaterDropDownList.SelectedIndex = 0;
            this.repeaterDropDownList.DropDownStyle = RadDropDownStyle.DropDownList;

            amountTextBox.Text = "0";
            transactionDateTimePicker.Value = DateTime.Now;
            removeInvoiceItemButton.Enabled = false;
            amountLabel.Visible = false;
            amountSeparator.Visible = false;
            startDateLabel.Visible = false;
            startDateSeparator.Visible = false;
            endDateLabel.Visible = false;
            endDateSeparator.Visible = false;
            amountTextBox.Visible = false;
            endDateTimePicker.Visible = false;
            startDateTimePicker.Visible = false;
        }

        private void InitLanguage()
        {

            //"<html>" + Language.labelStudent + ":" + "<color=Red>*";
            dateLabel.Text = "<html>" + Language.labelEnrollingDate + ":" + "<color=Red>*";
            studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            classLabel.Text = "<html>" + Language.labelClass + ":" + "<color=Red>*";
            roomLabel.Text = "<html>" + Language.labelRoom + ":" + "<color=Red>*";
            startDateLabel.Text = "<html>" + Language.LabelQuantity + ":" + "<color=Red>*";
            oldSchoolLabel.Text = Language.labelOldSchool;
            repeaterLabel.Text = Language.labelRepeater;
            amountLabel.Text = "<html>" + Language.labelAmount + ":" + "<color=Red>*";
            startDateLabel.Text = "<html>" + Language.labelStart + ":" + "<color=Red>*";
            endDateLabel.Text = "<html>" + Language.labelEnd + ":" + "<color=Red>*";
            doneByLabel.Text = Language.labelPaymentDoneBy;
            feesLabel.Text = "<html>" + Language.LabelFeesToPay + ":" + "<color=Red>*";
            paymentMeanLabel.Text = "<html>" + Language.labelPaymentMean + ":" + "<color=Red>*";
            addInvoiceItemButton.RootElement.ToolTipText = Language.messageClickToAddToInvoice;
            removeInvoiceItemButton.RootElement.ToolTipText = Language.messageClickToRemoveFromInvoice;
            saveButton.Text = Language.labelSave;
            closeButton.Text = Language.labelCancel;

        }

        private void InitEvent()
        {
            this.amountTextBox.TextChanging += new TextChangingEventHandler(TextBox_Changing);
            studentDropDownList.SelectedIndexChanged += StudentDropDownList_SelectedIndexChanged;
            classDropDownList.SelectedIndexChanged += ClassDropDownList_SelectedIndexChanged;
            roomDropDownList.SelectedIndexChanged += RoomDropDownList_SelectedIndexChanged;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }
      

        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !Helper.Helper.IsNumber(e.NewValue);
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

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();

            if (dateTimePicker.Text == "")
            {
                errorProvider.SetError(dateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.dateTimePicker.Focus();
                return false;
            }
            if (this.studentDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(studentDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.studentDropDownList.Focus();
                return false;
            }
            if (this.repeaterDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(repeaterDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.repeaterDropDownList.Focus();
                return false;
            }
            if (this.classDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(classDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.classDropDownList.Focus();
                return false;
            }
            if (this.roomDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(roomDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.roomDropDownList.Focus();
                return false;
            }
           
            return true;
        }
    }
}
