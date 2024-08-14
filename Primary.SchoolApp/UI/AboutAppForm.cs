
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
