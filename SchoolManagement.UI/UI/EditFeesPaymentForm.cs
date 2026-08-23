
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditFeesPaymentForm : RadForm
    {
        public RadDropDownList StudentDropDownList { get => studentDropDownList; }
        public RadTextBox ClassTextBox { get => classTextBox; }
        public RadTextBox SchoolYearTextBox { get => schoolYearTextBox; }
        public RadDateTimePicker TransactionDateTimePicker { get => transactionDateTimePicker; }
        public RadTextBox TransactionIdTextBox { get => transactionIdTextBox; }
        public RadDropDownList PaymentMeanDropDownList { get => paymentMeanDropDownList; }
        public RadTextBox DoneByTextBox { get => doneByTextBox; }
        public RadDropDownList FeesDropDownList { get => feesDropDownList; }
        public RadLabel AmountLabel { get => amountLabel; }
        public RadTextBox AmountTextBox { get => amountTextBox; }
        public RadSeparator AmountSeparator { get => amountSeparator; }
        public RadDateTimePicker StartDateTimePicker { get => startDateTimePicker; }
        public RadDateTimePicker EndDateTimePicker { get => endDateTimePicker; }
        public RadLabel StartDateLabel { get => startDateLabel; }
        public RadLabel EndDateLabel { get => endDateLabel; }
        public RadSeparator StartDateSeparator { get => startDateSeparator; }
        public RadSeparator EndDateSeparator { get => endDateSeparator; }
        public RadButton AddInvoiceItemButton { get => addInvoiceItemButton; }
        public RadButton RemoveInvoiceItemButton { get => removeInvoiceItemButton; }
        public RadListView InvoiceItemListView { get => invoiceItemListView; }
        public RadListView InvoiceTotalListView { get => invoiceTotalListView; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadPanel EditPanel { get => editPanel; }
        public RadPanel InvoicePanel { get => invoicePanel; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider DataErrorProvider { get => errorProvider; }
        public EditFeesPaymentForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
            InitEvent();
            InitListView();
        }
        private void InitComponent()
        {
            studentDropDownList.DropDownListElement.EnableElementShadow = false;
            this.errorLabel.ForeColor = Color.Red;

            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.classLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.classLabel.LabelElement.CustomFontSize = 10.5f;
            this.classLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.schoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            this.schoolYearLabel.TextAlignment = ContentAlignment.BottomLeft;

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

            this.classTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.classTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.schoolYearTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.schoolYearTextBox.TextBoxElement.CustomFontSize = 10.5f;

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

            this.studentDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.studentDropDownList.RootElement.CustomFontSize = 10.5f;
            this.studentDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

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
            this.editPanel.RootElement.EnableElementShadow = false;
            this.invoicePanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            foreach (RadControl c in this.invoicePanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.classTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.schoolYearTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.amountTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.doneByTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.transactionIdTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.classLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.schoolYearLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.amountLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.endDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.startDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.doneByLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.transactionDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.paymentMeanDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.transactionIdLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.classSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.schoolYearSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.amountSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.doneBySeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.paymentMeanSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionIdSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.transactionDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.feesSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;



            this.studentDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.studentDropDownList.ValueMember = "Id";


            this.paymentMeanDropDownList.DisplayMember = "Name";
            this.paymentMeanDropDownList.ValueMember = "Id";


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
            studentLabel.Text = "<html>" + Language.labelStudent + ":" + "<color=Red>*";
            classLabel.Text = "<html>" + Language.labelClass + ":" + "<color=Red>*";
            startDateLabel.Text = "<html>" + Language.LabelQuantity + ":" + "<color=Red>*";
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
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            invoiceTotalListView.CellFormatting += new ListViewCellFormattingEventHandler(InvoiceTotalListView_CellFormatting);
            invoiceItemListView.CellFormatting += new ListViewCellFormattingEventHandler(InvoiceItemListView_CellFormatting);

        }

        private void InitListView()
        {

            ListViewDetailColumn nameColumn = new("Item")
            {
                Width = InvoiceTotalListView.Width / 2
            };
            this.InvoiceItemListView.Columns.Add(nameColumn);
            ListViewDetailColumn priceColumn = new("Price")
            {
                Width = InvoiceTotalListView.Width / 2
            };
            this.InvoiceItemListView.Columns.Add(priceColumn);



            ListViewDetailColumn totalToPaidLabelColumn = new("Total")
            {
                Width = InvoiceTotalListView.Width / 2
            };
            InvoiceTotalListView.Columns.Add(totalToPaidLabelColumn);
            ListViewDetailColumn totalToPaidPriceColumn = new("TotalPrice")
            {
                Width = InvoiceTotalListView.Width / 2
            };
            InvoiceTotalListView.Columns.Add(totalToPaidPriceColumn);

            ListViewDataItem item = new();
            InvoiceTotalListView.Items.Add(item);
            item["Total"] = "TOTAL";
            item["TotalPrice"] = string.Format("{0:C2}", 0);

        }
        private void TextBox_Changing(object sender, TextChangingEventArgs e)
        {
            e.Cancel = !Helper.Helper.IsNumber(e.NewValue);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();

            if (this.studentDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(studentDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.studentDropDownList.Focus();
                return false;
            }

            if (transactionDateTimePicker.Text == "")
            {
                errorProvider.SetError(transactionDateTimePicker, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.transactionDateTimePicker.Focus();
                return false;
            }
            if(this.paymentMeanDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(paymentMeanDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.paymentMeanDropDownList.Focus();
                return false;
            }
            return true;
        }

        private void InvoiceItemListView_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            if (e.CellElement is DetailListViewDataCellElement cell)
            {
                if (cell.Text != string.Empty)
                {
                    if (decimal.TryParse(cell.Text, out decimal price))
                    {
                        cell.Text = new string(' ', 5) + string.Format("{0:C2}", price);
                    }
                    else
                    {
                        cell.Text = new string(' ', 2) + string.Format("{0}", cell.Text);
                    }

                    e.CellElement.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BorderGradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local);
                }
            }
        }

        private void InvoiceTotalListView_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            this.InvoiceItemListView_CellFormatting(sender, e);
            if (e.CellElement is DetailListViewDataCellElement cell && cell.Text != string.Empty)
            {

                if (decimal.TryParse(cell.Text.AsSpan(3), out decimal price))
                {
                    Color color = Color.FromArgb(255, 104, 20, 6);
                    if (TelerikHelper.IsDarkTheme(this.InvoiceItemListView.ThemeName))
                    {
                        color = Color.FromArgb(255, 255, 255, 255);
                    }

                    int indent = 4;
                    if (price >= 10)
                    {
                        indent = 3;
                    }

                    cell.Text = new string(' ', indent) + string.Format("{0:C2}", price);
                    e.CellElement.ForeColor = color;
                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                }

                e.CellElement.Font = new Font(e.CellElement.Font.Name, e.CellElement.Font.Size, FontStyle.Bold);
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }

    }
}
