
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditUserForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadButton AddEmployeeButton { get => addEmployeeButton; }
        public RadDropDownList EmployeeDropDownList { get => employeeDropDownList; }
        public RadTextBox NameTextBox { get => nameTextBox; }
        public RadTextBox LoginTextBox { get => loginTextBox; }
        public RadTextBox EmailTextBox { get => emailTextBox; }
        public RadTextBox PasswordTextBox { get => passwordTextBox; }
        public RadLabel ErrorLabel { get => errorLabel; }

        public EditUserForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            this.employeeLabel.Text = Language.labelEmployee;
            this.nameLabel.Text = Language.labelName;
            this.loginLabel.Text = Language.labelUserName;
            this.passwordLabel.Text = Language.labelPassword;
            this.emailLabel.Text = Language.labelMail;
            this.saveButton.Text = Language.labelSave;
            this.closeButton.Text = Language.labelCancel;
        }
        private void InitComponent()
        {
            employeeDropDownList.DropDownListElement.MinSize = new System.Drawing.Size(200, 40);
            employeeDropDownList.DropDownListElement.EnableElementShadow = false;
            employeeDropDownList.DropDownListElement.FindDescendant<Telerik.WinControls.Primitives.FillPrimitive>().BackColor = Color.Transparent;

            this.employeeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.employeeLabel.LabelElement.CustomFontSize = 10.5f;
            this.employeeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.employeeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.loginLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.loginLabel.LabelElement.CustomFontSize = 10.5f;
            this.loginLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.loginLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.passwordLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.passwordLabel.LabelElement.CustomFontSize = 10.5f;
            this.passwordLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.passwordLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.emailLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.emailLabel.LabelElement.CustomFontSize = 10.5f;
            this.emailLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.emailLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.employeeDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            this.employeeDropDownList.RootElement.CustomFontSize = 10.5f;
            this.employeeDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            this.employeeDropDownList.DropDownListElement.Padding = new Padding(3, 0, 0, 0);

            this.loginTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.loginTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.loginTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.passwordTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.passwordTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.passwordTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.nameTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.emailTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.emailTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.emailTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.employeeDropDownList.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            this.employeeLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.loginLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.passwordLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.emailLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.loginTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.passwordTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.emailTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.loginSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.passwordSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.employeeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.emailSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            addEmployeeButton.RootElement.ToolTipText = "Cliquer ici pour ajouter un nouveau employé";
            addEmployeeButton.Image = Resources.plus;
            addEmployeeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addEmployeeButton.ButtonElement.Padding = new Padding(0);

            this.employeeDropDownList.DisplayMember = "FullNameWithIdNumber";
            this.employeeDropDownList.ValueMember = "Id";
            this.employeeDropDownList.SelectedIndex = -1;

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.saveButton.Text=Language.labelSave;
        }

        private void InitEvent()
        {
            closeButton.Click += CloseButton_Click;
            employeeDropDownList.SelectedIndexChanged += EmployeeDropDownList_SelectedIndexChanged;

        }

        private void EmployeeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (employeeDropDownList.SelectedIndex < 0)
            {
                addEmployeeButton.Image = Resources.plus;
                addEmployeeButton.RootElement.ToolTipText = "Cliquer ici pour enregistrer un nouvel employé";
            }
            else
            {
                addEmployeeButton.Image = Resources.edit;
                addEmployeeButton.RootElement.ToolTipText = "Cliquer ici pour modifier les informations de l'employé";
            }
        }

        public  bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;

            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du nom est requise!";
                this.nameTextBox.Focus();
                return false;
            }
            if (this.loginTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du login est requise!";
                this.loginTextBox.Focus();
                return false;
            }
            if (this.passwordTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie du mot de passe est requise!";
                this.passwordTextBox.Focus();
                return false;
            }
            return true;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
