using Primary.SchoolApp.UI;
using SchoolManagement.Application.SchoolYears;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Primary.SchoolApp
{
    public partial class MainForm : SchoolManagement.UI.MainForm
    {
        private bool isLogOut;// si true se deconnecter
        private readonly ISchoolYearService schoolYearService;
        public MainForm(ISchoolYearService schoolYearReadService)
        {
            InitializeComponent();
            schoolYearService = schoolYearReadService;
            InitSettingPage();
            InitMainEvents();
        }
       
   
        private void InitMainEvents()
        {
            AboutButton.Click += AboutButton_Click;
            ChangePasswordMenu.Click += ChangePasswordMenu_Click;
            LogOutMenu.Click += LogOutMenu_Click;
            FormClosing += MainForm_FormClosing;
        }

        #region Events
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogOut)
            {
                LogOut();
            }
        }

        private void LogOutMenu_Click(object sender, System.EventArgs e)
        {
            LogOut();
        }

        private void ChangePasswordMenu_Click(object sender, System.EventArgs e)
        {
            RadMessageBox.Show("Implementation en cours....");
        }

        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            var form = new AboutAppForm();
            form.ShowDialog();
        }
        #endregion

        #region Methodes
        // se deconnecter du système
        private void LogOut()
        {

            DialogResult dialogResult = RadMessageBox.Show("Voulez-vous vous déconnecter de l'application ?", "Déconnexion de l'application", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                isLogOut = true;
                this.Close();
                Application.OpenForms["LoginForm"].Show();

            }

        }
        #endregion

    }
}
