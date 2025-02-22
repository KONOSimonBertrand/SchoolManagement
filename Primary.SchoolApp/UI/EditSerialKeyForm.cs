
using Microsoft.VisualBasic.ApplicationServices;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Primary.SchoolApp.UI
{
    internal class EditSerialKeyForm : SchoolManagement.UI.EditSerialKeyForm
    {
        private readonly ISchoolService schoolService;
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        public EditSerialKeyForm(ISchoolService schoolService, ILogService logService, ClientApp clientApp)
        {
            this.schoolService = schoolService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            this.FormClosed += OnFormClosed;
            this.SerialKeyTextBox.TextChanged += SerialKeyTextBox_TextChanged;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SerialKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            var serialKeytring = AppUtilities.ConvertHexToString(SerialKeyTextBox.Text);
            var serialKeyData = serialKeytring.Split('@');
            if (serialKeyData.Length == 3)
            {
                SerialKeyUserLabel.Text = $"{Language.labelUser}: {serialKeyData[0]}";
                SerialKeyTypeLabel.Text = $"{Language.LabelLisenceType}: {AppUtilities.ToLisenceType(serialKeyData[1])}";
                SerialKeyDurationLabel.Text = $"{Language.LabelExpiryDate}: {AppUtilities.GetExpiryDate(serialKeyData[1], serialKeyData[2])} ";
            }
            else
            {
                SerialKeyUserLabel.Text = $"{Language.labelUser}:";
                SerialKeyTypeLabel.Text = $"{Language.LabelLisenceType}: ";
                SerialKeyDurationLabel.Text = $"{Language.LabelExpiryDate}: ";
            }
        }

        public void InitStartup()
        {
            this.SerialKeyTextBox.Text=Program.CurrentSchool.SerialKey;
         }

        private void OnShown(object sender, EventArgs e)
        {
            SerialKeyTextBox.Focus();
        }
        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                if (AppUtilities.SerialKeyIsOk(Program.CurrentSchool.Name, SerialKeyTextBox.Text)) { 
                    Program.CurrentSchool.SerialKey = SerialKeyTextBox.Text;
                    var isDone=schoolService.UpdateSerialKeyAsync(Program.CurrentSchool.Id, SerialKeyTextBox.Text).Result;
                    if (isDone) {
                        Log log = new()
                        {
                            UserAction = $" Mise à jour de la licence  {this.SerialKeyTypeLabel.Text} par l'utilisateur {clientApp.UserConnected.Name}  sur le poste {clientApp.IpAddress} le {DateTime.Now} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                    }
                    Program.SerialKeyIsOK=false;
                    this.Close();
                }
                else
                {
                    RadMessageBox.Show(Language.LabelUnknowOrExpiredLisence);
                }
            }
        }

       
    }
}
