
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net;
using System.Linq;
using System.Net.Sockets;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace Primary.SchoolApp
{
    public partial class LoginForm : SchoolManagement.UI.LoginForm
    {
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private readonly ILogService logService;
        private readonly ILogger<LoginForm> logger;
        public LoginForm(ClientApp clientApp, IUserService userService, ILogService logService, ILogger<LoginForm> logger)
        {
            ThemeResolutionService.ApplicationThemeName = "Material";
            PictureLogo.Image = Resources.logo;
            PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clientApp = clientApp;
            this.userService = userService;
            this.logService = logService;
            this.logger = logger;
            InitEvents();
            this.Text = Language.labelSignIn;
            ConnectionButton.Text = Language.labelLogIn;
            
        }
        private void InitEvents()
        {
            ConnectionButton.Click += ConnectionButton_Click;
            OutButton.Click += OutButton_Click;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
            this.Shown += OnShown;

        }
        private void OnShown(object sender, EventArgs e)
        {
            Program.SerialKeyIsOK = AppUtilities.SerialKeyIsOk(Program.CurrentSchool?.Name, Program.CurrentSchool?.SerialKey);
            this.UserNameTextBox.Focus();
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
        private async void  ConnectionButton_Click(object sender, EventArgs e)
        {
            if (this.IsValidData())
            {
                clientApp.Name = "Windows Form";
                User user = null;
                try
                {

                    if(await userService.AuthenticateUser(UserNameTextBox.Text.Trim(), PasswordTextBox.Text.Trim()))
                    {
                        logger.LogInformation($"Authentification de l'utilisateur {UserNameTextBox.Text.Trim()} réussie");
                        user = await userService.GetUser(UserNameTextBox.Text.Trim());
                        if (user != null)
                        {
                            //get ip address
                            var hostName = Dns.GetHostName();
                            var ipAddresses = Dns.GetHostAddresses(hostName).Where(x => x.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString());
                            if (ipAddresses.Any())
                            {
                                clientApp.IpAddress = ipAddresses.First().ToString();
                            }
                            else
                            {
                                clientApp.IpAddress = hostName;
                            }
                            user.Rooms = await userService.GetUserRoomList(user.Id);
                            user.Modules = await userService.GetUserModuleList(user.Id);
                            Log log = new()
                            {
                                UserAction = $" Connexion de l'utilisateur {user.UserName}  sur le poste {clientApp.IpAddress} le {DateTime.Now} ",
                                UserId = user.Id
                            };
                            Program.UserConnected = user;
                            var logResult = logService.CreateLog(log).Result;
                            logger.LogInformation($"Connexion de l'utisateur {Program.UserConnected.UserName}");
                        }
                    }
                    else
                    {
                        logger.LogWarning($"Authentification de l'utilisateur {UserNameTextBox.Text.Trim()} échouée");
                    }
                   
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Erreur lors de la connexion de l'utilisateur {UserNameTextBox.Text.Trim()}");
                }
                if (user != null)
                {
                    clientApp.UserConnected = user;
                    var mainForm = Program.ServiceProvider.GetService<MainForm>();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    ErrorLabel.Text = Language.messageBaduserBadPassword;
                    PasswordTextBox.Focus();
                }
            }

        }
        private void OutButton_Click(object sender, EventArgs e)
        {
            logger.LogInformation($"Arrêt de SchoolApp");
            Application.Exit();
        }
    
    }
}
