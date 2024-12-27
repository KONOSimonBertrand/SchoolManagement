

using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EvaluationSessionStateForm : RadForm
    {
        public RadButton SaveButton { get=>saveButton;}
        public RadButton PrintButton { get=>printButton;}
        public RadButton ExportButton { get=>exportButton;}
        public RadButton CloseButton { get=>closeButton;}
        public SearchTextBox FilterTextBox { get=>filterTextBox;}
        public RadGridView DataGridView {get=>dataGridView;}
        public EvaluationSessionStateForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }

        private void InitLanguage()
        {
            this.saveButton.ButtonElement.ToolTipText = Language.messageClickToSave;
            this.printButton.ButtonElement.ToolTipText = Language.messageClickToPrint;
            this.exportButton.ButtonElement.ToolTipText = Language.messageClickToExport;
            this.saveButton.Text = Language.labelSave;
            this.printButton.Text = Language.labelPrint;
            this.exportButton.Text = Language.labelExport;
            filterTextBox.NullText = Language.MessageSearchBy + "...";

        }

        private void InitEvent()
        {
            closeButton.Click += (s, e) => { this.Close(); };
        }

        private void InitComponent()
        {
            commandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
        }
    }
}
