using MediaFoundation.Misc;
using SchoolManagement.UI.Localization;
using SchoolManagement.UI.Utilities;
using System.Security.Permissions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class ImportNotesForm : RadForm
    {
        public CommandBarLabel EvaluationLabel { get => evaluationLabel; }
        public CommandBarButton SaveButton { get => saveButton; }
        public CommandBarButton ImportButton { get => importButton; }
        public CommandBarLabel GroupLabel { get => groupLabel; }
        public CommandBarDropDownList GroupDropDownList { get => groupDropDownList; }
        public CommandBarLabel ClassroomLabel { get => classroomLabel; }
        public CommandBarDropDownList ClassroomDropDownList { get => classroomDropDownList; }
        public RadPanel InfoPanel { get => infoPanel; }
        public RadListControl InfoListControl { get => infoListControl; }
        public RadGridView DataGridView { get => dataGridView; }
        readonly RadWaitingBarElement taskWaitingBar = new();
        public RadWaitingBarElement TaskWaitingBar { get => taskWaitingBar; }
        public CommandBarHostItem WaitingBarHostItem { get => waitingBarHostItem; }
        public RadLabel InfoTitleLabel { get => infoTitleLabel; }
        public ImportNotesForm()
        {
            InitializeComponent();
            InitComponent();
            InitLanguage();
            waitingBarHostItem.MinSize = new Size(150, 8);
            taskWaitingBar.MinSize = new Size(150, 8);
            taskWaitingBar.EnableElementShadow = false;
            taskWaitingBar.Visibility = ElementVisibility.Hidden;
            waitingBarHostItem.HostedItem = taskWaitingBar;

        }

        private void InitLanguage()
        {
           groupLabel.Text = "<html>" + Language.labelSection + ":" + "<color=Red>*";
           classroomLabel.Text = "<html>" + Language.LabelClassroom + ":" + "<color=Red>*";
           importButton.ToolTipText=Language.labelImport;
           saveButton.ToolTipText = Language.labelSave;
           infoTitleLabel.Text=Language.LabelFileInformation;
        }
        private void InitComponent()
        {
            importButton.Image = ViewUtilities.GetImage("Import");
            saveButton.Image = ViewUtilities.GetImage("Save");
            saveButton.Visibility = ElementVisibility.Hidden;

            commandBarPanel.BackgroundImage = Resources.fasha_no_borders;
            commandBarPanel.BackgroundImageLayout = ImageLayout.Stretch;
            commandBarPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            commandBarPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            commandBarPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            infoListControl.ItemHeight = 80;

            infoPanel.Visible = false;
            infoPanel.Margin = new Padding(8);
            infoPanel.RootElement.EnableElementShadow = false;

            mainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            mainPanel.BackgroundImage = Resources.Background;
            mainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            mainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            dataGridView.Dock = DockStyle.Fill;
            dataGridView.RootElement.EnableElementShadow = false;
            dataGridView.GridViewElement.DrawFill = false;
            dataGridView.TableElement.Margin = new Padding(8, 8, 15, 8);
            dataGridView.BackColor = Color.Transparent;
            dataGridView.GridViewElement.DrawFill = true;
            dataGridView.AllowAddNewRow = false;
            dataGridView.EnableGrouping = false;


            classroomDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

           
        }
        public bool IsValidData()
        {
            
            if (classroomDropDownList.SelectedItem==null)
            {
                RadMessageBox.Show(Language.messageFillField,"SCHOOL APP",MessageBoxButtons.OK,RadMessageIcon.Error);
                classroomDropDownList.Focus();
                return false;
            }
            if (groupDropDownList.SelectedItem == null)
            {
                RadMessageBox.Show(Language.messageFillField, "SCHOOL APP", MessageBoxButtons.OK, RadMessageIcon.Error);
                groupDropDownList.Focus();
                return false;
            }
            return true;
        }
    }
}
