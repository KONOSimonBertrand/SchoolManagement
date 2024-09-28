using Telerik.WinControls;
using Telerik.WinControls.UI;
using SchoolManagement.UI.Utilities;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EditContactForm : RadForm
    {
        public RadGridView DataGridView { get=>dataGridView;}
        public RadButton SaveButton { get=>saveButton;}
        public RadButton CloseButton { get=>closeButton;}
        public RadButton SearchButton { get=>searchButton;}
        public RadTextBox StudentTextBox { get=>studentTextBox;}
        public RadTextBox IdCardTextBox { get=>idCardTextBox;}
        public RadTextBox NameTextBox { get=>fullNameTextBox;}
        public RadDropDownList SexDropDownList {  get=>sexDropDownList;}
        public RadDropDownList RelationshipDropDownList { get => relationshipDropDownList; }
        public RadTextBox PhoneTextBox { get=>phoneTextBox;}
        public RadTextBox EmailTextBox { get=>emailTextBox;}
        public RadTextBox AddressTextBox { get=>addressTextBox;}
        public RadTextBox JobTextBox { get=>jobTextBox;}
        public RadLabel ErrorLabel { get=>errorLabel;}
        public ErrorProvider ErrorProvider { get=>errorProvider;}
        public EditContactForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.studentLabel.Text=Language.labelStudent;
            this.idCardLabel.Text=Language.labelIdCard;
            this.phoneLabel.Text=Language.labelPhone;
            this.addressLabel.Text = Language.labelAddress;
            this.emailLabel.Text=Language.labelMail;
            this.jobLabel.Text=Language.labelJob;
            this.relationshipLabel.Text=Language.labelRelationship;

        }

        private void InitEvent()
        {
            this.idCardTextBox.GotFocus += ControlGetFocus;
            this.sexDropDownList.GotFocus += ControlGetFocus;
            this.studentTextBox.GotFocus += ControlGetFocus;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {
            this.dataGridView.Visible = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.errorLabel.ForeColor = Color.Red;
            this.sexDropDownList.Items.Add(new RadListDataItem("Masculin", "M"));
            this.sexDropDownList.Items.Add(new RadListDataItem("Feminin", "F"));
            this.relationshipDropDownList.DisplayMember= "Name";
            this.relationshipDropDownList.ValueMember = "Id";
          
            this.studentLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.studentLabel.LabelElement.CustomFontSize = 10.5f;
            this.studentLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.studentLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idCardLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.idCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.idCardLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.fullNameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.fullNameLabel.LabelElement.CustomFontSize = 10.5f;
            this.fullNameLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.sexLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sexLabel.LabelElement.CustomFontSize = 10.5f;
            this.sexLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.jobLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.jobLabel.LabelElement.CustomFontSize = 10.5f;
            this.jobLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.relationshipLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.relationshipLabel.LabelElement.CustomFontSize = 10.5f;
            this.relationshipLabel.ForeColor = Color.FromArgb(89, 89, 89);

            this.phoneLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.phoneLabel.LabelElement.CustomFontSize = 10.5f;
            this.phoneLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.phoneLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.emailLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.emailLabel.LabelElement.CustomFontSize = 10.5f;
            this.emailLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.emailLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.addressLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.addressLabel.LabelElement.CustomFontSize = 10.5f;
            this.addressLabel.ForeColor = Color.FromArgb(89, 89, 89);
            //this.addressLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.studentTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.studentTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.studentTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.idCardTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.idCardTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idCardTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.fullNameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.fullNameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.fullNameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sexDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.sexDropDownList.RootElement.CustomFontSize = 10.5f;
            this.sexDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.sexDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.jobTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.jobTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.jobTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.relationshipDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.relationshipDropDownList.RootElement.CustomFontSize = 10.5f;
            this.relationshipDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.relationshipDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            this.phoneTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.phoneTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.phoneTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.emailTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.emailTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.emailTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.addressTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.addressTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.addressTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            this.idCardSplitContainer.RootElement.EnableElementShadow = false;
            this.phoneSplitContainer.RootElement.EnableElementShadow = false;
            this.addressSplitContainer.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            foreach (SplitPanel sp in this.idCardSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.jobSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.phoneSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }
            foreach (SplitPanel sp in this.addressSplitContainer.SplitPanels)
            {
                sp.RootElement.EnableElementShadow = false;
                sp.SplitPanelElement.Border.Visibility = ElementVisibility.Collapsed;
                foreach (RadControl c in sp.Controls)
                {
                    c.RootElement.EnableElementShadow = false;
                }
            }

            this.studentLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.fullNameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.sexLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.phoneLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.addressLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.jobLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.relationshipLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.sexDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);
            this.relationshipDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.studentTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.fullNameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.phoneTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.addressTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.jobTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idCardTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.studentSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.fullNameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sexSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.phoneSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.jobSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.relationshiSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
           
        }
        private void ControlGetFocus(object sender, EventArgs e)
        {
            if (this.dataGridView.Visible == true) this.dataGridView.Visible = false;
        }
       
    
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.idCardTextBox.Text == "")
            {
                this.errorProvider.SetError(this.idCardTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.idCardTextBox.Focus();
                return false;
            }

            if (this.fullNameTextBox.Text == "")
            {
                this.errorProvider.SetError(this.fullNameTextBox, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.fullNameTextBox.Focus();
                return false;
            }

            if (this.sexDropDownList.SelectedItem == null)
            {
                this.errorProvider.SetError(this.sexDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.sexDropDownList.Focus();
                return false;
            }


            if (this.relationshipDropDownList.SelectedItem == null)
            {
                this.errorProvider.SetError(this.relationshipDropDownList, Language.messageFillField);
                this.errorLabel.Text = Language.messageFillField;
                this.relationshipDropDownList.Focus();
                return false;
            }

            return true;
        }
    }
}
