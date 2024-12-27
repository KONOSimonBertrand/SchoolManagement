using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace SchoolManagement.UI
{
    public partial class EditBadgeForm : RadForm
    {
        public RadButton CloseButton { get => closeButton; }
        public RadButton GenerateButton { get => saveButton; }
        public RadDropDownList ForDropDownList {  get => forDropDownList; }
        public RadDropDownList FormatDropDownList {  get => formatDropDownList; }
        public RadDateTimePicker StartDateTimePicker {  get => startDateTimePicker; }
        public RadDateTimePicker EndDateTimePicker {  get => endDateTimePicker; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditBadgeForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
            InitEvents();
        }
        private void InitEvents()
        {
            closeButton.Click += CloseButton_Click;
            this.formatDropDownList.SelectedIndexChanged += FormatDropDownList_SelectedIndexChanged;

        }


        private void FormatDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (formatDropDownList.SelectedIndex == 0)
            {
                this.startDateTimePicker.CustomFormat = "yyyy";
                this.endDateTimePicker.CustomFormat = "yyyy";
            }
            else
            {
                if (formatDropDownList.SelectedIndex == 1)
                {
                    this.startDateTimePicker.CustomFormat = "MM-yyyy";
                    this.endDateTimePicker.CustomFormat = "MM-yyyy";
                }
                else
                {
                    this.startDateTimePicker.CustomFormat = "dd-MM-yyyy";
                    this.endDateTimePicker.CustomFormat = "dd-MM-yyyy";
                }
            }
        }
        private void InitLanguage()
        {
            
            forLabel.Text = $"<html>{Language.LabelFor}:<color=Red>*";
            formatLabel.Text = $"<html>Format:<color=Red>*";
            startDateLabel.Text = $"<html>{Language.labelStart}:<color=Red>*";
            endDateLabel.Text = $"<html>{Language.labelEnd}:<color=Red>*";
            saveButton.Text = Language.LabelGenerate;
            closeButton.Text = Language.labelCancel;

        }

        private void InitComponent()
        {
            forDropDownList.DropDownListElement.EnableElementShadow = false;
            forDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;
            formatDropDownList.DropDownListElement.EnableElementShadow = false;
            formatDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.forLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.forLabel.LabelElement.CustomFontSize = 10.5f;
            this.forLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.formatLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.formatLabel.LabelElement.CustomFontSize = 10.5f;
            this.formatLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.startDateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.startDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.startDateLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.endDateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.endDateLabel.LabelElement.CustomFontSize = 10.5f;
            this.endDateLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.forDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.forDropDownList.RootElement.CustomFontSize = 10.5f;
            this.forDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.forDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.forDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.formatDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.formatDropDownList.RootElement.CustomFontSize = 10.5f;
            this.formatDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.formatDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.formatDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.startDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.startDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.startDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.startDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);
            this.startDateTimePicker.DateTimePickerElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.startDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.startDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.endDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endDateTimePicker.CustomFormat = "dd-MM-yyyy";
            this.endDateTimePicker.DateTimePickerElement.CalendarSize = new Size(350, 380);
            this.endDateTimePicker.DateTimePickerElement.TextBoxElement.Padding = new Padding(10, 0, 0, 0);
            this.endDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(0, 0, 10, 0);
            this.endDateTimePicker.DateTimePickerElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.endDateTimePicker.DateTimePickerElement.CustomFontSize = 10.5f;
            this.endDateTimePicker.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.forLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.formatLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.endDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.startDateLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.forSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.formatSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.startDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.endDateSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            formatDropDownList.Items.Add(new RadListDataItem("aaaa-aaaa", 0));
            formatDropDownList.Items.Add(new RadListDataItem("mm/aaaa-mm/aaaa", 1));
            formatDropDownList.Items.Add(new RadListDataItem("jj/mm/aaaa-jj/mm/aaaa", 2));
            formatDropDownList.SelectedValue = 0;
            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

            this.closeButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.closeButton.ButtonElement.CustomFontSize = 10.5f;
            this.closeButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.startDateTimePicker.Value = DateTime.Now;
            this.endDateTimePicker.Value = DateTime.Now.AddYears(1);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool IsValidData()
        {
            if (this.forDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(forDropDownList, Language.messageFillField);
                this.forDropDownList.Focus();
                return false;
            }
            if (this.formatDropDownList.SelectedIndex < 0)
            {
                errorProvider.SetError(formatDropDownList, Language.messageFillField);
                this.formatDropDownList.Focus();
                return false;
            }

            if (startDateTimePicker.Text == "")
            {
                errorProvider.SetError(startDateTimePicker, Language.messageFillField);
                this.startDateTimePicker.Focus();
                return false;
            }
            if (endDateTimePicker.Text == "")
            {
                errorProvider.SetError(endDateTimePicker, Language.messageFillField);
                this.endDateTimePicker.Focus();
                return false;
            }

            return true;
        }

        
    }
}
