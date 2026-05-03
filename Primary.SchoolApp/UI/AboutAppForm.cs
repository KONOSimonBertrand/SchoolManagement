
using Primary.SchoolApp.Utilities;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    public partial class AboutAppForm : RadForm
    {
        public AboutAppForm()
        {
            InitializeComponent();
            this.Text = "A Propos de School App";
            var serialKeytring = AppUtilities.ConvertHexToString(Program.CurrentSchool.SerialKey);
            var serialKeyData = serialKeytring.Split('@');
            if (serialKeyData.Length == 3)
            {
                serialKeyUserLabel.Text = $"{Language.labelUser}: {serialKeyData[0]}";
                serialKeyTypeLabel.Text = $"{Language.LabelLisenceType}: {AppUtilities.ToLisenceType(serialKeyData[1])}";
                serialKeyDurationLabel.Text = $"{Language.LabelExpiryDate}: {AppUtilities.GetExpiryDate(serialKeyData[1], serialKeyData[2])} ";
            }
            else
            {
                serialKeyUserLabel.Text = $"{Language.labelUser}:";
                serialKeyTypeLabel.Text = $"{Language.LabelLisenceType}: ";
                serialKeyDurationLabel.Text = $"{Language.LabelExpiryDate}: ";
            }
            switch (ThemeResolutionService.ApplicationThemeName)
            {
                case "Material":

                    this.Icon =Resources.icon_orange;
                    logoPictureBox.Image = Helper.GetImage(Resources.schoolapp_orange);
                    break;
                case "MaterialBlueGrey":

                    this.Icon =Resources.icon_green;
                    logoPictureBox.Image = Helper.GetImage(Resources.schoolapp_green);
                    break;
                case "MaterialPink":

                    this.Icon =Resources.icon_blue;
                    logoPictureBox.Image = Helper.GetImage(Resources.schoolapp_blue);
                    break;
                case "MaterialTeal":

                    this.Icon =Resources.icon_red;
                    logoPictureBox.Image =Helper.GetImage(Resources.schoolapp_red);
                    break;

                default:
                    this.Icon =Helper.GetIcon(Resources.icon_white);
                    logoPictureBox.Image =Helper.GetImage(Resources.schoolapp_white);
                    break;
            }
        }
    }
}
