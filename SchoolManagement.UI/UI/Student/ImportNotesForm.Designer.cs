using SchoolManagement.UI;

namespace SchoolManagement.UI
{
    partial class ImportNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportNotesForm));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            commandBarPanel = new Telerik.WinControls.UI.RadPanel();
            radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            evaluationLabel = new Telerik.WinControls.UI.CommandBarLabel();
            commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            importButton = new Telerik.WinControls.UI.CommandBarButton();
            saveButton = new Telerik.WinControls.UI.CommandBarButton();
            waitingBarHostItem = new Telerik.WinControls.UI.CommandBarHostItem();
            groupSeparator = new Telerik.WinControls.UI.CommandBarSeparator();
            classroomLabel = new Telerik.WinControls.UI.CommandBarLabel();
            classroomDropDownList = new Telerik.WinControls.UI.CommandBarDropDownList();
            groupLabel = new Telerik.WinControls.UI.CommandBarLabel();
            groupDropDownList = new Telerik.WinControls.UI.CommandBarDropDownList();
            commandBarHostItemClassroom = new Telerik.WinControls.UI.CommandBarHostItem();
            mainPanel = new Telerik.WinControls.UI.RadPanel();
            dataGridView = new Telerik.WinControls.UI.RadGridView();
            infoPanel = new Telerik.WinControls.UI.RadPanel();
            infoListControl = new Telerik.WinControls.UI.RadListControl();
            infoTitleLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)commandBarPanel).BeginInit();
            commandBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radCommandBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainPanel).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)infoPanel).BeginInit();
            infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)infoListControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)infoTitleLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // commandBarPanel
            // 
            commandBarPanel.Controls.Add(radCommandBar1);
            commandBarPanel.Dock = DockStyle.Top;
            commandBarPanel.Location = new Point(0, 0);
            commandBarPanel.Name = "commandBarPanel";
            commandBarPanel.Size = new Size(1548, 47);
            commandBarPanel.TabIndex = 0;
            // 
            // radCommandBar1
            // 
            radCommandBar1.Dock = DockStyle.Top;
            radCommandBar1.Location = new Point(0, 0);
            radCommandBar1.Name = "radCommandBar1";
            radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] { commandBarRowElement1 });
            radCommandBar1.Size = new Size(1548, 30);
            radCommandBar1.TabIndex = 3;
            // 
            // commandBarRowElement1
            // 
            commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarRowElement1.MinSize = new Size(25, 25);
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
            commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { evaluationLabel, commandBarSeparator2, importButton, saveButton, waitingBarHostItem, groupSeparator, classroomLabel, classroomDropDownList, groupLabel, groupDropDownList, commandBarHostItemClassroom });
            commandBarStripElement1.Name = "commandBarStripElement1";
            commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarStripElement1.UseCompatibleTextRendering = false;
            // 
            // evaluationLabel
            // 
            evaluationLabel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            evaluationLabel.DisplayName = "commandBarLabel1";
            evaluationLabel.Name = "evaluationLabel";
            evaluationLabel.Text = "Evaluation";
            evaluationLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            evaluationLabel.UseCompatibleTextRendering = false;
            // 
            // commandBarSeparator2
            // 
            commandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator2.DisplayName = "commandBarSeparator2";
            commandBarSeparator2.Name = "commandBarSeparator2";
            commandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarSeparator2.UseCompatibleTextRendering = false;
            commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // importButton
            // 
            importButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            importButton.DisplayName = "commandBarButton1";
            importButton.Image = (Image)resources.GetObject("importButton.Image");
            importButton.Name = "importButton";
            importButton.Text = "Importer";
            importButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            importButton.UseCompatibleTextRendering = false;
            // 
            // saveButton
            // 
            saveButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            saveButton.DisplayName = "commandBarButton1";
            saveButton.Image = (Image)resources.GetObject("saveButton.Image");
            saveButton.Name = "saveButton";
            saveButton.Text = "Enregistrer";
            saveButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            saveButton.ToolTipText = "Cliquer ici pour enregistrer les notes importées";
            saveButton.UseCompatibleTextRendering = false;
            // 
            // waitingBarHostItem
            // 
            waitingBarHostItem.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            waitingBarHostItem.DisplayName = "commandBarHostItem1";
            waitingBarHostItem.Name = "waitingBarHostItem";
            waitingBarHostItem.Text = "Waiting..";
            waitingBarHostItem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            waitingBarHostItem.UseCompatibleTextRendering = false;
            // 
            // groupSeparator
            // 
            groupSeparator.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupSeparator.DisplayName = "commandBarSeparator1";
            groupSeparator.Name = "groupSeparator";
            groupSeparator.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupSeparator.UseCompatibleTextRendering = false;
            groupSeparator.VisibleInOverflowMenu = false;
            // 
            // classroomLabel
            // 
            classroomLabel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            classroomLabel.DisplayName = "commandBarLabel1";
            classroomLabel.Name = "classroomLabel";
            classroomLabel.Text = "Salle de classe";
            classroomLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            classroomLabel.UseCompatibleTextRendering = false;
            // 
            // classroomDropDownList
            // 
            classroomDropDownList.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            classroomDropDownList.DisplayName = "commandBarDropDownList1";
            classroomDropDownList.DropDownAnimationEnabled = true;
            classroomDropDownList.MinSize = new Size(250, 22);
            classroomDropDownList.Name = "classroomDropDownList";
            classroomDropDownList.Text = "Salle de classe";
            classroomDropDownList.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            classroomDropDownList.UseCompatibleTextRendering = false;
            // 
            // groupLabel
            // 
            groupLabel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupLabel.DisplayName = "commandBarLabel1";
            groupLabel.Name = "groupLabel";
            groupLabel.Text = "Section";
            groupLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupLabel.UseCompatibleTextRendering = false;
            // 
            // groupDropDownList
            // 
            groupDropDownList.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupDropDownList.DisplayName = "commandBarDropDownList1";
            groupDropDownList.DropDownAnimationEnabled = true;
            groupDropDownList.MinSize = new Size(230, 22);
            groupDropDownList.Name = "groupDropDownList";
            groupDropDownList.Text = "Section";
            groupDropDownList.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            groupDropDownList.UseCompatibleTextRendering = false;
            // 
            // commandBarHostItemClassroom
            // 
            commandBarHostItemClassroom.DisplayName = "commandBarHostItemClassroom";
            commandBarHostItemClassroom.Name = "commandBarHostItemClassroom";
            commandBarHostItemClassroom.Text = "Salle de classe";
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(dataGridView);
            mainPanel.Controls.Add(infoPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 47);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1548, 416);
            mainPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            // 
            // 
            // 
            dataGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1220, 416);
            dataGridView.TabIndex = 51;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(infoListControl);
            infoPanel.Controls.Add(infoTitleLabel);
            infoPanel.Dock = DockStyle.Right;
            infoPanel.Location = new Point(1220, 0);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(328, 416);
            infoPanel.TabIndex = 49;
            // 
            // infoListControl
            // 
            infoListControl.Dock = DockStyle.Fill;
            infoListControl.ItemHeight = 24;
            infoListControl.Location = new Point(0, 21);
            infoListControl.Name = "infoListControl";
            infoListControl.Size = new Size(328, 395);
            infoListControl.TabIndex = 2;
            // 
            // infoTitleLabel
            // 
            infoTitleLabel.Dock = DockStyle.Top;
            infoTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            infoTitleLabel.ForeColor = Color.Black;
            infoTitleLabel.Location = new Point(0, 0);
            infoTitleLabel.Name = "infoTitleLabel";
            infoTitleLabel.Size = new Size(328, 21);
            infoTitleLabel.TabIndex = 0;
            infoTitleLabel.Text = "Informations sur le fichier";
            // 
            // ImportNotesForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 463);
            Controls.Add(mainPanel);
            Controls.Add(commandBarPanel);
            Name = "ImportNotesForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)commandBarPanel).EndInit();
            commandBarPanel.ResumeLayout(false);
            commandBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radCommandBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainPanel).EndInit();
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)infoPanel).EndInit();
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)infoListControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)infoTitleLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel commandBarPanel;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarLabel evaluationLabel;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton importButton;
        private Telerik.WinControls.UI.CommandBarButton saveButton;
        private Telerik.WinControls.UI.CommandBarHostItem waitingBarHostItem;
        private Telerik.WinControls.UI.CommandBarSeparator groupSeparator;
        private Telerik.WinControls.UI.CommandBarLabel classroomLabel;
        private Telerik.WinControls.UI.CommandBarDropDownList classroomDropDownList;
        private Telerik.WinControls.UI.CommandBarLabel groupLabel;
        private Telerik.WinControls.UI.CommandBarDropDownList groupDropDownList;
        private Telerik.WinControls.UI.RadPanel mainPanel;
        private Telerik.WinControls.UI.RadPanel infoPanel;
        private Telerik.WinControls.UI.RadGridView dataGridView;
        private Telerik.WinControls.UI.RadLabel infoTitleLabel;
        private Telerik.WinControls.UI.RadListControl infoListControl;
        private Telerik.WinControls.UI.CommandBarHostItem commandBarHostItemClassroom;
    }
}