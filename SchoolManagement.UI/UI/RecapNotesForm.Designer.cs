namespace SchoolManagement.UI
{
    partial class RecapNotesForm
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
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmdExport = new Telerik.WinControls.UI.CommandBarButton();
            this.cmdTitle = new Telerik.WinControls.UI.CommandBarLabel();
            this.titleCommandBarStripElement = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmdTitleSeparator = new Telerik.WinControls.UI.CommandBarSeparator();
            this.cmdPrint = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.reportGrid = new Telerik.WinControls.UI.RadGridView();
            this.reportCommandBar = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportCommandBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            this.commandBarStripElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.UseCompatibleTextRendering = false;
            // 
            // cmdExport
            // 
            this.cmdExport.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdExport.DisplayName = "cmdExport";
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Text = "cmdExport";
            this.cmdExport.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdExport.ToolTipText = "Cliquer ici pour exporter vers Excel";
            this.cmdExport.UseCompatibleTextRendering = false;
            // 
            // cmdTitle
            // 
            this.cmdTitle.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdTitle.DisplayName = "commandBarLabel1";
            this.cmdTitle.Name = "cmdTitle";
            this.cmdTitle.Text = "RAPPORT";
            this.cmdTitle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdTitle.UseCompatibleTextRendering = false;
            // 
            // titleCommandBarStripElement
            // 
            this.titleCommandBarStripElement.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.titleCommandBarStripElement.DisplayName = "commandBarStripElement1";
            this.titleCommandBarStripElement.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmdTitle,
            this.cmdTitleSeparator,
            this.cmdPrint,
            this.cmdExport});
            this.titleCommandBarStripElement.Name = "titleCommandBarStripElement";
            this.titleCommandBarStripElement.OverflowMenuMaxSize = new System.Drawing.Size(528, 0);
            this.titleCommandBarStripElement.OverflowMenuMinSize = new System.Drawing.Size(98, 49);
            this.titleCommandBarStripElement.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.titleCommandBarStripElement.UseCompatibleTextRendering = false;
            // 
            // cmdTitleSeparator
            // 
            this.cmdTitleSeparator.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdTitleSeparator.DisplayName = "commandBarSeparator1";
            this.cmdTitleSeparator.Name = "cmdTitleSeparator";
            this.cmdTitleSeparator.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdTitleSeparator.UseCompatibleTextRendering = false;
            this.cmdTitleSeparator.VisibleInOverflowMenu = false;
            // 
            // cmdPrint
            // 
            this.cmdPrint.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdPrint.DisplayName = "cmdPrint";
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Text = "Imprimer";
            this.cmdPrint.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmdPrint.ToolTipText = "Cliquer ici pour imprimer";
            this.cmdPrint.UseCompatibleTextRendering = false;
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(49, 49);
            this.commandBarRowElement2.Name = "commandBarRowElement1";
            this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.titleCommandBarStripElement});
            this.commandBarRowElement2.Text = "";
            this.commandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.UseCompatibleTextRendering = false;
            // 
            // reportGrid
            // 
            this.reportGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGrid.Location = new System.Drawing.Point(0, 80);
            this.reportGrid.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            // 
            // 
            // 
            this.reportGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.reportGrid.Name = "reportGrid";
            this.reportGrid.Size = new System.Drawing.Size(1318, 527);
            this.reportGrid.TabIndex = 74;
            // 
            // reportCommandBar
            // 
            this.reportCommandBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportCommandBar.Location = new System.Drawing.Point(0, 0);
            this.reportCommandBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.reportCommandBar.Name = "reportCommandBar";
            this.reportCommandBar.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
            this.reportCommandBar.Size = new System.Drawing.Size(1318, 80);
            this.reportCommandBar.TabIndex = 73;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.UseCompatibleTextRendering = false;
            // 
            // RecapNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 607);
            this.Controls.Add(this.reportGrid);
            this.Controls.Add(this.reportCommandBar);
            this.Name = "RecapNotesForm";
            this.Text = "RecapNotesForm";
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportCommandBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton cmdExport;
        private Telerik.WinControls.UI.CommandBarLabel cmdTitle;
        private Telerik.WinControls.UI.CommandBarStripElement titleCommandBarStripElement;
        private Telerik.WinControls.UI.CommandBarSeparator cmdTitleSeparator;
        private Telerik.WinControls.UI.CommandBarButton cmdPrint;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.RadGridView reportGrid;
        private Telerik.WinControls.UI.RadCommandBar reportCommandBar;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    }
}