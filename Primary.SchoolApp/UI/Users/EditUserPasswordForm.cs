
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;

namespace Primary.SchoolApp.UI
{
    public partial class EditUserPasswordForm : SchoolManagement.UI.EditUserPasswordForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IUserService userService;
        private int selectedUserId;
        public EditUserPasswordForm(IUserService userService, ILogService logService, ClientApp clientApp)
        {
            InitEvents();
            this.userService = userService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.Text = Language.titlePasswordUpdate;
            this.userService = userService;
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            OldPasswordTextBox.Focus();
        }
        internal void Init(int userId)
        {
            selectedUserId = userId;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (IsOldPassword(OldPasswordTextBox.Text))
                {
                    var isDone = userService.ChangePassword(selectedUserId, NewPasswordTextBox.Text).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour du mot de passe de {clientApp.UserConnected.UserName}  par l'utisateur  {clientApp.UserConnected.Name} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.Close();
                    }
                    else
                    {
                        ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    ErrorLabel.Text = Language.messageBadOldPassword;
                }
            }
        }
        private bool IsOldPassword(string oldPassword)
        {
            return oldPassword == clientApp.UserConnected.Password;
        }
    }
}
