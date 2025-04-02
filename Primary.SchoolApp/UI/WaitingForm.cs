

using System.Drawing;

namespace Primary.SchoolApp.UI
{
    public partial class WaitingForm : Telerik.WinControls.UI.ShapedForm
    {
        public WaitingForm()
        {
            InitializeComponent();
            this.pictureBox1.Image= (Bitmap)(new ImageConverter()).ConvertFrom(Resources.Waiting); 
        }
    }
}
