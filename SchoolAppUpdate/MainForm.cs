using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using Telerik.WinControls.UI;

namespace SchoolAppUpdate
{
    public partial class MainForm : RadForm
    {
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        public MainForm(IUserService userService, ClientApp clientApp)
        {
            this.userService = userService;
            this.clientApp = clientApp;
            this.clientApp.ConnectionString = Program.NewDataBaseConnectionString;
            InitializeComponent();
            InitEvents();
            taskWaitingBarElement.Size = new System.Drawing.Size(300, 20);
            taskWaitingBarElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
        }
        private void InitEvents()
        {
            hasUserPasswordButton.Click += HasUserPasswordButton_Click;
        }

        private async void HasUserPasswordButton_Click(object? sender, EventArgs e)
        {
            hasUserPasswordButton.Enabled = false;
            taskWaitingBarElement.StartWaiting();
            taskWaitingBarElement.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            string message="Extraction des utilisateurs de la base de données ....\n";
            reportLabel.Text = message;

            var users= await userService.GetUserList();
            message = $"Nombre d'utilisateurs extraits : {users.Count}\n";
            reportLabel.Text= reportLabel.Text+ message;
            foreach (var user in users)
            {
                if (!user.Password.Contains("$2a$11$"))
                {
                    var isDone = await userService.ChangePassword(user.Id, user.Password);
                    if (isDone)
                    {
                        message = $"Encodage du mot de passe de l'utilisateur {user.UserName} effectué avec succès \n";
                    }
                    else
                    {
                        message = $"Une erreur est survenue lord de l'encodage du mot de passe de l'utilisateur {user.UserName}\n";

                    }
                    await Task.Delay(1000);
                }
                else
                {
                    message = $"L'utilisateur {user.UserName} a déjà un mot de passe encodé\n";

                }


                reportLabel.Text = reportLabel.Text + message;

            }
            taskWaitingBarElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            hasUserPasswordButton.Enabled = true;
        }
    }
}
