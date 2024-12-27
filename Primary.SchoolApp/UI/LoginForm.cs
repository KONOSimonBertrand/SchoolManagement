
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Configuration;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net;
using System.Linq;
using System.Net.Sockets;
namespace Primary.SchoolApp
{
    public partial class LoginForm : SchoolManagement.UI.LoginForm
    {
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private readonly ILogService logService;
        public LoginForm(ClientApp clientApp, IUserService userService, ILogService logService)
        {
            ThemeResolutionService.ApplicationThemeName = "Material";
            PictureLogo.Image = Resources.logo;
            PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clientApp = clientApp;
            this.userService = userService;
            this.logService = logService;
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
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (this.IsValidData())
            {
                clientApp.Name = "Windows Form";
                User user = null;
                try
                {
                    user = userService.GetUser(UserNameTextBox.Text.Trim(), PasswordTextBox.Text.Trim()).Result;
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
                        user.Rooms = userService.GetUserRoomList(user.Id).Result;
                        user.Modules = userService.GetUserModuleList(user.Id).Result;
                        Log log = new()
                        {
                            UserAction = $" Connexion de l'utilisateur {user.UserName}  sur le poste {clientApp.IpAddress} le {DateTime.Now} ",
                            UserId = user.Id
                        };
                        Program.UserConnected=user;
                        var logResult = logService.CreateLog(log).Result;
                    }
                }
                catch (Exception ex)
                {
                    AppUtilities.AddLog(ex.Message);
                    AppUtilities.AddLog(ex.StackTrace);
                }
                if (user != null)
                {
                   
                    clientApp.Name= ConfigurationManager.AppSettings["ClientName"];
                    clientApp.Code = ConfigurationManager.AppSettings["ClientCode"];
                    clientApp.Contact = ConfigurationManager.AppSettings["ClientContact"];
                    clientApp.Address = ConfigurationManager.AppSettings["ClientAddress"];
                    clientApp.WebSite = ConfigurationManager.AppSettings["ClientWebSite"];                  
                    clientApp.LogoUrl = ConfigurationManager.AppSettings["ClientLogo"];
                    clientApp.StudentPitureFolder = ConfigurationManager.AppSettings["SudentPictureFolder"];
                    clientApp.EmployeePitureFolder = ConfigurationManager.AppSettings["EmployeePitureFolder"];
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
            Application.Exit();
        }
    }
}
