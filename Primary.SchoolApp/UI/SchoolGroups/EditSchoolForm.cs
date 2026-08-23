

using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;

namespace Primary.SchoolApp.UI
{
    internal class EditSchoolForm:SchoolManagement.UI.EditSchoolForm
    {
        private readonly ISchoolService schoolService;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        public EditSchoolForm(ISchoolService schoolService, ClientApp clientApp, ILogService logService)
        {
            this.schoolService = schoolService;
            this.clientApp = clientApp;
            this.logService = logService;
            InitEvents();
        }
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            this.EvaluationModelDropDownList.ToolTipTextNeeded += EvaluationModelDropDownList_ToolTipTextNeeded;
        }

        private void EvaluationModelDropDownList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            switch (EvaluationModelDropDownList.SelectedValue.ToString())
            {
                case "0":
                    e.ToolTipText = "---------------STRUCTURE---------------\n" +
                            "PREMIER TRIMESTRE (TRIM1)\n" +
                            "  Evaluation N°1 (EVAL01)\n" +
                            "  Evaluation N°2 (EVAL02)\n" +
                            "  Evaluation N°3 (EVAL03)\n" +
                            "DEUXIEME TRIMESTRE (TRIM2)\n" +
                            "  Evaluation N°4 (EVAL04)\n" +
                            "  Evaluation N°5 (EVAL05)\n" +
                            "  Evaluation N°6 (EVAL06)\n" +
                            "TROISIEME TRIMESTRE (TRIM3)\n" +
                            "  Evaluation N°7 (EVAL04)\n" +
                            "  Evaluation N°8 (EVAL05)\n" +
                            "---------------CALCUL---------------\n" +
                            "   TRIM1=((EVAL01+EVAL02+EVAL03)/3)\n" +
                            "   TRIM2=((EVAL04+EVAL05+EVAL06)/3)\n" +
                            "   TRIM3=((EVAL07+EVAL08)/2)";
                    break;
                case "1":
                    e.ToolTipText = "---------------STRUCTURE---------------\n" +
                            "PREMIER TRIMESTRE (TRIM1)\n" +
                            "  Devoir Surveilé N°1 (EVAL01)\n" +
                            "  Devoir Surveilé N°2 (EVAL02)\n" +
                            "  Devoir Contrôle Conitu N°1 (EVAL03)\n" +
                            "  Mini Section N°1 (EVAL04)\n" +
                            "DEUXIEME TRIMESTRE (TRIM2)\n" +
                            "  Devoir Surveilé N°3 (EVAL05)\n" +
                            "  Devoir Surveilé N°4 (EVAL06)\n" +
                            "  Devoir Contrôle Conitu N°2 (EVAL07)\n" +
                            "  Mini Section N°2 (EVAL08)\n" +
                            "TROISIEME TRIMESTRE (TRIM3)\n" +
                            "  Devoir Surveilé N°5 (EVAL09)\n" +
                            "  Devoir Surveilé N°6 (EVAL10)\n" +
                            "  Session Intense (EVAL11)\n" +
                            "---------------CALCUL---------------\n" +
                            "   TRIM1=(((EVAL01+EVAL02+EVAL03)/3)*0,3)+(EVAL04*0,7)\n" +
                            "   TRIM2=(((EVAL05+EVAL06+EVAL07)/3)*0,3)+(EVAL08*0,7)\n" +
                            "   TRIM3=(((EVAL09+EVAL10)/2)*0,3)+(EVAL11*0,7)";
                    break;

                default:
                    e.ToolTipText = "Inconnu";
                    break;
            }
        }

        internal void InitStartup()
        {
            this.NameTextBox.Text = Program.CurrentSchool.Name;
            this.MottoTextBox.Text = Program.CurrentSchool.Motto;
            this.EvaluationModelDropDownList.SelectedValue = Program.CurrentSchool.EvaluationModel;
            this.ReceiptModelDropDownList.SelectedValue = Program.CurrentSchool.ReceiptModel;
            this.CityTextBox.Text = Program.CurrentSchool.City;
            this.PostBoxTextBox.Text = Program.CurrentSchool.PostBox;
            this.AddressTextBox.Text = Program.CurrentSchool.Address;
            this.PhoneTextBox.Text = Program.CurrentSchool.Phone;
            this.WebsiteTextBox.Text = Program.CurrentSchool.WebSite;
            this.EmailTextBox.Text = Program.CurrentSchool.Email;
            this.FacebookTextBox.Text = Program.CurrentSchool.FaceBook;
            this.HeadMasterTypeDropDownList.SelectedValue = Program.CurrentSchool.HeadMasterType;
            this.HeadMasterNameTextBox.Text = Program.CurrentSchool.HeadMasterName;
            this.HeadMasterSexDropDownList.SelectedValue = Program.CurrentSchool.HeadMasterSex;
            this.StudentPictureDirectoryTextBox.Text = Program.CurrentSchool.StudentPictureDirectory;
            this.EmployeePictureDirectoryTextBox.Text = Program.CurrentSchool.EmployeePictureDirectory;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData()) {

                Program.CurrentSchool.Name = this.NameTextBox.Text;
                Program.CurrentSchool.Motto = this.MottoTextBox.Text;
                Program.CurrentSchool.EvaluationModel = Convert.ToInt32(this.EvaluationModelDropDownList.SelectedValue.ToString());
                Program.CurrentSchool.City = this.CityTextBox.Text;
                Program.CurrentSchool.PostBox = this.PostBoxTextBox.Text;
                Program.CurrentSchool.Address = this.AddressTextBox.Text;
                Program.CurrentSchool.Phone = this.PhoneTextBox.Text;
                Program.CurrentSchool.WebSite = this.WebsiteTextBox.Text;
                Program.CurrentSchool.Email = this.EmailTextBox.Text;
                Program.CurrentSchool.FaceBook = this.FacebookTextBox.Text;
                Program.CurrentSchool.HeadMasterName = this.HeadMasterNameTextBox.Text;
                Program.CurrentSchool.HeadMasterType = Convert.ToInt32(this.HeadMasterTypeDropDownList.SelectedValue.ToString());
                Program.CurrentSchool.HeadMasterSex= this.HeadMasterSexDropDownList.SelectedValue.ToString();
                Program.CurrentSchool.StudentPictureDirectory = this.StudentPictureDirectoryTextBox.Text;
                Program.CurrentSchool.EmployeePictureDirectory = this.EmployeePictureDirectoryTextBox.Text;
                Program.CurrentSchool.ReceiptModel = Convert.ToInt32(this.ReceiptModelDropDownList.SelectedValue.ToString());
                bool isDone = schoolService.UpdateSchoolAsync(Program.CurrentSchool).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Modification des informationn de l'école par l'utisateur  {clientApp.UserConnected.Name} sur le poste {clientApp.IpAddress}",
                        User = clientApp.UserConnected,
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.ErrorLabel.Text = Language.messageUpdateError;
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            NameTextBox.Focus();
        }
    }
}
