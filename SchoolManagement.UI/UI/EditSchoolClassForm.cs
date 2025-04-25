using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditSchoolClassForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadDropDownList GroupDropDownList { get => groupDropDownList; }
        public RadSpinEditor SequenceSpinEditor { get => sequenceSpinEditor; }
        public RadDropDownList ReportCardDropDownList { get => reportCardDropDownList; }

        public RadButton AddGroupButton { get => addGroupButton; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditSchoolClassForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.nameLabel.Text =  "<html>" + Language.labelDesignation + ":" + "<color=Red>*"; ;
            this.sequenceLabel.Text = Language.labelSequence;
            this.groupLabel.Text = "<html>" + Language.labelGroup + ":" + "<color=Red>*";
            this.saveButton.Text = Language.labelSave;
            this.reportCardLabel.Text = "<html>" + Language.LabelReportCardModel + ":" + "<color=Red>*";
            this.closeButton.Text = Language.labelCancel;
           
        }
        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            groupDropDownList.SelectedIndexChanged += GroupDropDownList_SelectedIndexChanged;
        }

      
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitComponent()
        {          
            this.groupLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupLabel.LabelElement.CustomFontSize = 10.5f;
            this.groupLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.sequenceLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;

            this.sequenceSpinEditor.SpinElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;

            this.groupDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.groupDropDownList.RootElement.CustomFontSize = 10.5f;
            this.groupDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.reportCardLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.reportCardLabel.LabelElement.CustomFontSize = 10.5f;
            this.reportCardLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.reportCardDropDownList.RootElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.reportCardDropDownList.RootElement.CustomFontSize = 10.5f;
            this.reportCardDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);


            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelDefaultModel, 0));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelKindergartenModelWithMark, 1));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelKindergartenModelWithoutMark, 2));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelPrimaryModel, 3));
            this.reportCardDropDownList.Items.Add(new RadListDataItem(Language.LabelHighSchoolModel, 4));
            this.reportCardSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.reportCardDropDownList.SelectedIndex = 0;

            this.groupDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.sequenceSpinEditor.SpinElement.ShowBorder = false;
            this.sequenceLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.groupLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.reportCardLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.groupSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.codeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.saveButton.ButtonElement.CustomFont = Utilities.ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;

            addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            addGroupButton.Image = ViewUtilities.GetImage("Add");
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.ButtonElement.Padding = new Padding(0);
            this.groupDropDownList.DisplayMember = "Name";
            this.groupDropDownList.ValueMember = "Id";
            this.groupDropDownList.SelectedIndex = -1;

            this.errorLabel.ForeColor = Color.Red;

        }

        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            errorProvider.Clear();
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(nameTextBox, Language.messageFillField);
                this.nameTextBox.Focus();
                return false;
            }


            if (this.groupDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(groupDropDownList, Language.messageFillField);
                this.groupDropDownList.Focus();
                return false;
            }
            if (this.reportCardDropDownList.SelectedIndex < 0)
            {
                this.errorLabel.Text = Language.messageFillField;
                errorProvider.SetError(reportCardDropDownList, Language.messageFillField);
                this.nameTextBox.Focus();
            }
            return true;
        }

        private void GroupDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (groupDropDownList.SelectedIndex < 0)
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Add");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToAddGroup;
            }
            else
            {
                addGroupButton.Image = Utilities.ViewUtilities.GetImage("Edit");
                addGroupButton.RootElement.ToolTipText = Language.messageClickToEdit;
            }
        }

    }
}
