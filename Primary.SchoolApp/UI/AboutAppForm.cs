
using Primary.SchoolApp.Utilities;
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
                    logoPictureBox.Image =Resources.icon_orange1;
                    break;
                case "MaterialBlueGrey":

                    this.Icon =Resources.icon_green;
                    logoPictureBox.Image =Resources.icon_green1;
                    break;
                case "MaterialPink":

                    this.Icon =Resources.icon_blue;
                    logoPictureBox.Image =Resources.icon_blue1;
                    break;
                case "MaterialTeal":

                    this.Icon =Resources.icon_red;
                    logoPictureBox.Image =Resources.icon_red1;
                    break;

                default:
                    this.Icon =Resources.icon_pink;
                    logoPictureBox.Image =Resources.icon_pink1;
                    break;
            }
        }
    }
}
