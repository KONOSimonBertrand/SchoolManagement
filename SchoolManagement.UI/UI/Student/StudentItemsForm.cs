using SchoolManagement.UI.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace SchoolManagement.UI
{
    public partial class StudentItemsForm : RadForm
    {



        /// <summary>
        /// Cette classe sert d'interface utilisateur pour:
        /// - Les versements des frais scolaires
        /// - Les abonnements
        /// - Les dépôts d'un élève sur son compte
        /// - La fiche de présences d'un élève
        ///  - Les contacts d'un élève
        /// </summary>
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadButton PrintButton { get => printButton; }
        public RadButton ExportButton { get => exportButton; }
        public RadGridView DataGridView { get => dataGridView; }
        public RadLabel SchoolInformationLabel { get => schoolInformationLabel; }
        public RadLabel PersonalInformationLabel { get => personalInformationLabel; }
        public RadLabel PictureLabel { get => pictureLabel; }
        public RadLabel NameLabel { get => nameLabel; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public RadLabel AddressLabel { get => addressLabel; }
        public RadLabel PhoneLabel { get => phoneLabel; }
        public RadLabel EmailLabel { get => emailLabel; }
        public CustomControls.SearchTextBox FilterTextBox { get => filterTextBox; }
        public StudentItemsForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            exportButton.Text = Language.labelExport;
            closeButton.Text = Language.labelCancel;
            printButton.Text = Language.labelPrint;
            saveButton.Text = Language.labelAdd;
            filterTextBox.NullText = Language.messageResearch;
            this.Text = Language.titleRoomList;
            this.radLabel1.Text = Language.labelPhone + ":";
            this.radLabel2.Text = Language.labelAddress + ":";
            this.radLabel3.Text = Language.labelMail + ":";
        }


        private void InitComponent()
        {
            this.personPanel.RootElement.EnableElementShadow = false;

            foreach (RadControl c in this.personPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            personPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
        }
    }
}
