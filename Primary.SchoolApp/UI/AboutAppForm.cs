
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

                    this.Icon = AppResource.icon_orange;
                    logoPictureBox.Image = AppResource.icon_orange1;
                    break;
                case "MaterialBlueGrey":

                    this.Icon = AppResource.icon_green;
                    logoPictureBox.Image = AppResource.icon_green1;
                    break;
                case "MaterialPink":

                    this.Icon = AppResource.icon_blue;
                    logoPictureBox.Image = AppResource.icon_blue1;
                    break;
                case "MaterialTeal":

                    this.Icon = AppResource.icon_red;
                    logoPictureBox.Image = AppResource.icon_red1;
                    break;

                default:
                    this.Icon = AppResource.icon_pink;
                    logoPictureBox.Image = AppResource.icon_pink1;
                    break;
            }
        }
    }
}
