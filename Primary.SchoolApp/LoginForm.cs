using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Users;
using SchoolManagement.Core.Model;
using System;


namespace Primary.SchoolApp
{
    public partial class LoginForm : SchoolManagement.UI.LoginForm
    {
        private readonly ClientApp clientApp;
        private readonly IUserReadService userReadService;
        public LoginForm(ClientApp clientApp,IUserReadService userReadService)
        {
            InitializeComponent();
            PictureLogo.Image=AppResource.logo;
            //PictureLogo.SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clientApp = clientApp;
            this.userReadService = userReadService; 
            InitEvents();
        }
        private void InitEvents()
        {
            ConnectionButton.Click += ConnectionButton_Click;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
        }
        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ErrorLabel.Text.Trim().Length > 0)
            {
                ErrorLabel.Text = string.Empty;
            }
        }
        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ErrorLabel.Text.Trim().Length > 0)
            {
                ErrorLabel.Text = string.Empty;
            }
        }
        private void ConnectionButton_Click(object sender, EventArgs e) {
            if (this.IsValidData()) {
                clientApp.Name = "Windows Form";
                clientApp.ConnectionString = Program.ConnectionString;           
                var user= userReadService.GetUserAsync(UserNameTextBox.Text.Trim(), PasswordTextBox.Text.Trim()).Result;
                if (user!=null) {
                    clientApp.UserConnected = user;
                    var mainForm = Program.ServiceProvider.GetService<MainForm>();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    ErrorLabel.Text = "Nom utilisateur ou mot de passe incorrect !";
                    PasswordTextBox.Focus();
                }              
            }

        }

    }
}
