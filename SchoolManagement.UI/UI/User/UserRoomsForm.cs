
using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class UserRoomsForm : RadForm
    {
        public RadGridView DataGridView { get => dataGridView; }
        public RadButton ExportButton { get => exportButton; }
        public RadButton PrintButton { get => printButton; }
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadLabel LoginLabel { get => loginLabel; }
        public RadLabel EmailLabel { get => emailLabel; }
        public RadLabel PhoneLabel { get => phoneLabel; }
        public RadLabel AddressLabel { get => addressLabel; }
        public RadLabel EmployeeInformationLabel { get => employeeInformationLabel; }
        public RadLabel NameLabel { get => nameLabel; }
        public RadLabel EmployeePictureLabel { get => employeePictureLabel; }
        public RadTextBox FilterTextBox { get => filterTextBox; }
        public UserRoomsForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            saveButton.Text = Language.labelSave;
            exportButton.Text = Language.labelExport;
            printButton.Text = Language.labelPrint;
            closeButton.Text = Language.labelCancel;

            saveButton.ButtonElement.ToolTipText = Language.messageClickToAdd;
            exportButton.ButtonElement.ToolTipText = Language.messageClickToExport;
            printButton.ButtonElement.ToolTipText = Language.messageClickToPrint;
            radLabel2.Text = Language.labelPhone;
            radLabel3.Text = Language.labelMail;
            radLabel1.Text = Language.labelAdddress;
            filterTextBox.NullText = Language.messageResearch;

        }
        private void InitComponent()
        {
            this.studentPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.studentPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            EmployeePictureLabel.Image = Resources.no_image;
            studentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
        }
    }
}
