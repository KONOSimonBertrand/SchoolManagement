using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Localization;

namespace SchoolManagement.UI
{
    public partial class EmployeeItemsForm : RadForm
    {


        //     Cette classe sert d'interface utilisateur pour:
        //     - Les versements d'un élève
        //     - Les dépôts d'un élève
        //     - Les abonnements d'un élève
        //     - Le dossier médical d'un élève
        //     - La fiche de discipline d'un élève
        //     - Les contacts d'un élève,
        //     
        //     
        //    
        //    
        //     

        /// <summary>
        /// Cette classe sert d'interface utilisateur pour:
        /// - Les salles de classe assignées à un employé
        /// - Les unités d'enseignement assignées à un employé
        /// - Les dépôts d'un employé sur son compte
        /// - La fiche de présences d'un employé
        ///  - Les notes sur un employé
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
        public CustomControls.SearchTextBox FilterTextBox {  get => filterTextBox; }    
        public EmployeeItemsForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            exportButton.Text=Language.labelExport;
            closeButton.Text=Language.labelCancel;
            printButton.Text = Language.labelPrint;
            saveButton.Text = Language.labelSave;
            filterTextBox.NullText = Language.messageResearch;
            this.Text = Language.titleRoomList;
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
