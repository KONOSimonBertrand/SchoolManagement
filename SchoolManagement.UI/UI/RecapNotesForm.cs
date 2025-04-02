using System;
using System.Collections.Generic;

using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class RecapNotesForm : RadForm
    {

        #region Properties
        public RadCommandBar ReportCommandBar { get => reportCommandBar; }
        public RadGridView ReportGrid { get => reportGrid; }
        public CommandBarButton CmdPrint { get => cmdPrint; }
        public CommandBarLabel CmdTitle { get => cmdTitle; }
        public CommandBarButton CmdExport {  get => cmdExport; }
        #endregion
        public RecapNotesForm()
        {
            InitializeComponent();
        }
    }
}
