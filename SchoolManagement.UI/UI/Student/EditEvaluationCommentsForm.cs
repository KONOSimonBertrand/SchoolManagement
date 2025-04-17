

using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class EditEvaluationCommentsForm : RadForm
    {
        public CommandBarLabel EvaluationLabel { get => evaluationLabel; }
        public CommandBarButton PrintButton { get => printButton; }
        public CommandBarButton ExportToExelButton { get => exportToExelButton; }
        public CommandBarLabel GroupLabel { get => groupLabel; }
        public CommandBarDropDownList GroupDropDownList { get => groupDropDownList; }
        public CommandBarLabel ClassroomLabel { get => classLabel; }
        public CommandBarDropDownList ClassroomDropDownList { get => classroomDropDownList; }
        public SearchTextBox FilterTextBox { get => filterTextBox; }
        public RadGridView DataGridView { get => dataGridView; }
        public ErrorProvider ErrorProvider { get => errorProvider; }
        public EditEvaluationCommentsForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
            InitLanguage();
        }
        private void InitLanguage()
        {
            filterLabel.Text = Language.LabelFilter + ":";
            classLabel.Text = "<html>" + Language.labelRoom + ":" + "<color=Red>*";
            groupLabel.Text = "<html>" + Language.labelSection + ":" + "<color=Red>*";
        }
        private void InitEvent()
        {

        }
        private void InitComponent()
        {
            this.filterLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.filterLabel.LabelElement.CustomFontSize = 10.5f;
            this.filterLabel.TextAlignment = ContentAlignment.BottomLeft;
            this.filterLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.classroomDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            foreach (RadControl c in this.informationPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            this.informationPanel.RootElement.EnableElementShadow = false;

            exportToExelButton.Image = ViewUtilities.GetImage("Excel");
            printButton.Image = ViewUtilities.GetImage("Printer");
        }
        public bool IsValidData()
        {
            if (this.classroomDropDownList.SelectedIndex< 0)
            {
                this.classroomDropDownList.Focus();
                return false;
            }
           
            return true;
        }
    }
}
