
using Telerik.ReportViewer.WinForms;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class ReportViewerForm : RadForm
    {

        public ReportViewer ReportViewer { get => reportViewer; }
        public ReportViewerForm()
        {
            InitializeComponent();
        }
    }
}
