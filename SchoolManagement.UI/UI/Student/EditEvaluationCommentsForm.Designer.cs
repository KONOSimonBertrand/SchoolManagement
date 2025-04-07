namespace SchoolManagement.UI
{
    partial class EditEvaluationCommentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEvaluationCommentsForm));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            subjectsCommandBar = new Telerik.WinControls.UI.RadCommandBar();
            commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            evaluationLabel = new Telerik.WinControls.UI.CommandBarLabel();
            commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            saveButton = new Telerik.WinControls.UI.CommandBarButton();
            commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            printButton = new Telerik.WinControls.UI.CommandBarButton();
            exportToExelButton = new Telerik.WinControls.UI.CommandBarButton();
            groupSeparator = new Telerik.WinControls.UI.CommandBarSeparator();
            classLabel = new Telerik.WinControls.UI.CommandBarLabel();
            classroomDropDownList = new Telerik.WinControls.UI.CommandBarDropDownList();
            groupLabel = new Telerik.WinControls.UI.CommandBarLabel();
            groupDropDownList = new Telerik.WinControls.UI.CommandBarDropDownList();
            informationPanel = new Telerik.WinControls.UI.RadPanel();
            commandPanel = new Telerik.WinControls.UI.RadPanel();
            filterTextBox = new SchoolManagement.UI.CustomControls.SearchTextBox();
            filterLabel = new Telerik.WinControls.UI.RadLabel();
            dataGridView = new Telerik.WinControls.UI.RadGridView();
            commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)subjectsCommandBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)informationPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)commandPanel).BeginInit();
            commandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // subjectsCommandBar
            // 
            subjectsCommandBar.Dock = DockStyle.Top;
            subjectsCommandBar.Location = new Point(0, 0);
            subjectsCommandBar.Margin = new Padding(4);
            subjectsCommandBar.Name = "subjectsCommandBar";
            subjectsCommandBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] { commandBarRowElement1 });
            subjectsCommandBar.Size = new Size(1065, 59);
            subjectsCommandBar.TabIndex = 66;
            // 
            // commandBarRowElement1
            // 
            commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarRowElement1.MinSize = new Size(31, 31);
            commandBarRowElement1.Name = "commandBarRowElement1";
            commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] { commandBarStripElement1 });
            commandBarRowElement1.Text = "";
            commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarRowElement1.UseCompatibleTextRendering = false;
            // 
            // commandBarStripElement1
            // 
            commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarStripElement1.DisplayName = "commandBarStripElement1";
            commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { evaluationLabel, commandBarSeparator1, saveButton, commandBarSeparator2, printButton, exportToExelButton, groupSeparator, classLabel, classroomDropDownList, groupLabel, groupDropDownList });
            commandBarStripElement1.Name = "commandBarStripElement1";
            commandBarStripElement1.OverflowMenuMaxSize = new Size(338, 0);
            commandBarStripElement1.OverflowMenuMinSize = new Size(62, 31);
            commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarStripElement1.UseCompatibleTextRendering = false;
            // 
            // evaluationLabel
            // 
            evaluationLabel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            evaluationLabel.DisplayName = "commandBarLabel1";
            evaluationLabel.Name = "evaluationLabel";
            evaluationLabel.Text = "EVALUATION";
            evaluationLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            evaluationLabel.UseCompatibleTextRendering = false;
            // 
            // commandBarSeparator1
            // 
            commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator1.DisplayName = "commandBarSeparator1";
            commandBarSeparator1.Name = "commandBarSeparator1";
            commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator1.UseCompatibleTextRendering = false;
            commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // saveButton
            // 
            saveButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            saveButton.DisplayName = "commandBarButton1";
            saveButton.Image = (Image)resources.GetObject("saveButton.Image");
            saveButton.Name = "saveButton";
            saveButton.Text = "Enregistrer";
            saveButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            saveButton.ToolTipText = "Cliquer ici pour enregistrer";
            saveButton.UseCompatibleTextRendering = false;
            // 
            // commandBarSeparator2
            // 
            commandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator2.Name = "commandBarSeparator2";
            commandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator2.UseCompatibleTextRendering = false;
            commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // printButton
            // 
            printButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            printButton.DisplayName = "commandBarButton1";
            printButton.Image = (Image)resources.GetObject("printButton.Image");
            printButton.Name = "printButton";
            printButton.Text = "Imprimer";
            printButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            printButton.ToolTipText = "Cliquer ici pour imprimer";
            printButton.UseCompatibleTextRendering = false;
            // 
            // exportToExelButton
            // 
            exportToExelButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            exportToExelButton.DisplayName = "commandBarButton1";
            exportToExelButton.Image = (Image)resources.GetObject("exportToExelButton.Image");
            exportToExelButton.Name = "exportToExelButton";
            exportToExelButton.Text = "commandBarButton1";
            exportToExelButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            exportToExelButton.ToolTipText = "Cliquer ici pour exporter vers Excel";
            exportToExelButton.UseCompatibleTextRendering = false;
            // 
            // groupSeparator
            // 
            groupSeparator.DisplayName = "commandBarSeparator3";
            groupSeparator.Name = "groupSeparator";
            groupSeparator.VisibleInOverflowMenu = false;
            // 
            // classLabel
            // 
            classLabel.DisplayName = "commandBarLabel1";
            classLabel.Name = "classLabel";
            classLabel.Text = "Salle de classe";
            // 
            // classroomDropDownList
            // 
            classroomDropDownList.DisplayName = "commandBarDropDownList1";
            classroomDropDownList.DropDownAnimationEnabled = true;
            classroomDropDownList.MinSize = new Size(288, 28);
            classroomDropDownList.Name = "classroomDropDownList";
            classroomDropDownList.Text = "Salle de classe";
            // 
            // groupLabel
            // 
            groupLabel.DisplayName = "commandBarLabel1";
            groupLabel.Name = "groupLabel";
            groupLabel.Text = "Section";
            // 
            // groupDropDownList
            // 
            groupDropDownList.DisplayName = "commandBarDropDownList1";
            groupDropDownList.DropDownAnimationEnabled = true;
            groupDropDownList.DropDownHeight = 133;
            groupDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            groupDropDownList.MinSize = new Size(150, 28);
            groupDropDownList.Name = "groupDropDownList";
            groupDropDownList.Text = "Section";
            // 
            // informationPanel
            // 
            informationPanel.BackColor = Color.FromArgb(191, 219, 255);
            informationPanel.Dock = DockStyle.Top;
            informationPanel.Location = new Point(0, 59);
            informationPanel.Margin = new Padding(4);
            informationPanel.Name = "informationPanel";
            informationPanel.Size = new Size(1065, 12);
            informationPanel.TabIndex = 68;
            // 
            // commandPanel
            // 
            commandPanel.Controls.Add(filterTextBox);
            commandPanel.Controls.Add(filterLabel);
            commandPanel.Dock = DockStyle.Top;
            commandPanel.Location = new Point(0, 71);
            commandPanel.Margin = new Padding(5, 6, 5, 6);
            commandPanel.Name = "commandPanel";
            commandPanel.Size = new Size(1065, 56);
            commandPanel.TabIndex = 69;
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(107, 13);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.NullText = "Rechercher par ....";
            filterTextBox.Size = new Size(811, 30);
            filterTextBox.TabIndex = 2;
            // 
            // filterLabel
            // 
            filterLabel.Location = new Point(22, 19);
            filterLabel.Margin = new Padding(5, 6, 5, 6);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(37, 18);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "Filtrer:";
            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 127);
            dataGridView.Margin = new Padding(5, 6, 5, 6);
            // 
            // 
            // 
            dataGridView.MasterTemplate.AllowAddNewRow = false;
            dataGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            dataGridView.MasterTemplate.Caption = null;
            dataGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1065, 446);
            dataGridView.TabIndex = 3;
            // 
            // commandBarStripElement2
            // 
            commandBarStripElement2.DisplayName = "commandBarStripElement2";
            commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditEvaluationCommentsForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 573);
            Controls.Add(dataGridView);
            Controls.Add(commandPanel);
            Controls.Add(informationPanel);
            Controls.Add(subjectsCommandBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EditEvaluationCommentsForm";
            Text = "StudentNotesForm";
            ((System.ComponentModel.ISupportInitialize)subjectsCommandBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)informationPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)commandPanel).EndInit();
            commandPanel.ResumeLayout(false);
            commandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadCommandBar subjectsCommandBar;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarLabel evaluationLabel;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton printButton;
        private Telerik.WinControls.UI.CommandBarButton exportToExelButton;
        private Telerik.WinControls.UI.RadPanel informationPanel;
        private Telerik.WinControls.UI.RadPanel commandPanel;
        private Telerik.WinControls.UI.RadLabel filterLabel;
        private Telerik.WinControls.UI.RadGridView dataGridView;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton saveButton;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarDropDownList groupDropDownList;
        private Telerik.WinControls.UI.CommandBarSeparator groupSeparator;
        private Telerik.WinControls.UI.CommandBarLabel groupLabel;
        private Telerik.WinControls.UI.CommandBarLabel classLabel;
        private Telerik.WinControls.UI.CommandBarDropDownList classroomDropDownList;
        private ErrorProvider errorProvider;
        private CustomControls.SearchTextBox filterTextBox;
    }
}