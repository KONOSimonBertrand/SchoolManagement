namespace SchoolManagement.UI
{
    partial class GeneralReportForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralReportForm));
            reportPanel = new Telerik.WinControls.UI.RadPanel();
            reportGrid = new Telerik.WinControls.UI.RadGridView();
            commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            titleLabel = new Telerik.WinControls.UI.CommandBarLabel();
            titleBarSeparator = new Telerik.WinControls.UI.CommandBarSeparator();
            iconViewToggleButton = new Telerik.WinControls.UI.CommandBarToggleButton();
            listViewToggleButton = new Telerik.WinControls.UI.CommandBarToggleButton();
            viewBarSeparator = new Telerik.WinControls.UI.CommandBarSeparator();
            printButton = new Telerik.WinControls.UI.CommandBarButton();
            exportButton = new Telerik.WinControls.UI.CommandBarButton();
            reportCommandBar = new Telerik.WinControls.UI.RadCommandBar();
            ((System.ComponentModel.ISupportInitialize)reportPanel).BeginInit();
            reportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportGrid.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportCommandBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // reportPanel
            // 
            reportPanel.Controls.Add(reportGrid);
            reportPanel.Dock = DockStyle.Fill;
            reportPanel.Location = new Point(0, 55);
            reportPanel.Name = "reportPanel";
            reportPanel.Size = new Size(1344, 388);
            reportPanel.TabIndex = 13;
            // 
            // reportGrid
            // 
            reportGrid.Dock = DockStyle.Fill;
            reportGrid.Location = new Point(0, 0);
            // 
            // 
            // 
            reportGrid.MasterTemplate.AllowAddNewRow = false;
            reportGrid.MasterTemplate.AllowDeleteRow = false;
            reportGrid.MasterTemplate.AllowEditRow = false;
            reportGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            reportGrid.Name = "reportGrid";
            reportGrid.Size = new Size(1344, 388);
            reportGrid.TabIndex = 64;
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
            commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { titleLabel, titleBarSeparator, iconViewToggleButton, listViewToggleButton, viewBarSeparator, printButton, exportButton });
            commandBarStripElement1.Name = "commandBarStripElement1";
            commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            commandBarStripElement1.UseCompatibleTextRendering = false;
            // 
            // titleLabel
            // 
            titleLabel.DisplayName = "commandBarLabel1";
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "";
            // 
            // titleBarSeparator
            // 
            titleBarSeparator.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            titleBarSeparator.DisplayName = "commandBarSeparator1";
            titleBarSeparator.Name = "titleBarSeparator";
            titleBarSeparator.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            titleBarSeparator.UseCompatibleTextRendering = false;
            titleBarSeparator.VisibleInOverflowMenu = false;
            // 
            // iconViewToggleButton
            // 
            iconViewToggleButton.DisplayName = "commandBarToggleButton1";
            iconViewToggleButton.DrawImage = false;
            iconViewToggleButton.DrawText = true;
            iconViewToggleButton.Image = (Image)resources.GetObject("iconViewToggleButton.Image");
            iconViewToggleButton.Name = "iconViewToggleButton";
            iconViewToggleButton.Text = "Group";
            // 
            // listViewToggleButton
            // 
            listViewToggleButton.DisplayName = "commandBarToggleButton1";
            listViewToggleButton.DrawImage = false;
            listViewToggleButton.DrawText = true;
            listViewToggleButton.Image = (Image)resources.GetObject("listViewToggleButton.Image");
            listViewToggleButton.Name = "listViewToggleButton";
            listViewToggleButton.Text = "Detail";
            listViewToggleButton.TextImageRelation = TextImageRelation.Overlay;
            listViewToggleButton.TextWrap = false;
            // 
            // viewBarSeparator
            // 
            viewBarSeparator.DisplayName = "commandBarSeparator1";
            viewBarSeparator.Name = "viewBarSeparator";
            viewBarSeparator.VisibleInOverflowMenu = false;
            // 
            // printButton
            // 
            printButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            printButton.DisplayName = "commandBarButton1";
            printButton.DrawText = true;
            printButton.Image = (Image)resources.GetObject("printButton.Image");
            printButton.Name = "printButton";
            printButton.Text = "";
            printButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            printButton.TextWrap = true;
            printButton.ToolTipText = "Cliquer ici pour imprimer";
            printButton.UseCompatibleTextRendering = false;
            // 
            // exportButton
            // 
            exportButton.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            exportButton.DisplayName = "commandBarButton1";
            exportButton.Image = (Image)resources.GetObject("exportButton.Image");
            exportButton.Name = "exportButton";
            exportButton.Text = "commandBarButton1";
            exportButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            exportButton.ToolTipText = "Cliquer ici pour exporter vers Excel";
            exportButton.UseCompatibleTextRendering = false;
            // 
            // reportCommandBar
            // 
            reportCommandBar.Dock = DockStyle.Top;
            reportCommandBar.Location = new Point(0, 0);
            reportCommandBar.Name = "reportCommandBar";
            reportCommandBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] { commandBarRowElement1 });
            reportCommandBar.Size = new Size(1344, 55);
            reportCommandBar.TabIndex = 11;
            // 
            // GeneralReportForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 443);
            Controls.Add(reportPanel);
            Controls.Add(reportCommandBar);
            Name = "GeneralReportForm";
            Text = "ReportDetailForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)reportPanel).EndInit();
            reportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)reportGrid.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportCommandBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel reportPanel;
        private Telerik.WinControls.UI.RadGridView reportGrid;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarSeparator titleBarSeparator;
        private Telerik.WinControls.UI.CommandBarButton printButton;
        private Telerik.WinControls.UI.CommandBarButton exportButton;
        private Telerik.WinControls.UI.RadCommandBar reportCommandBar;
        private Telerik.WinControls.UI.CommandBarLabel titleLabel;
        private Telerik.WinControls.UI.CommandBarSeparator viewBarSeparator;
        private Telerik.WinControls.UI.CommandBarToggleButton iconViewToggleButton;
        private Telerik.WinControls.UI.CommandBarToggleButton listViewToggleButton;
    }
}