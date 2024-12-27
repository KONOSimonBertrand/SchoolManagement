namespace SchoolManagement.UI
{
    partial class EvaluationSessionStateForm
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
            exportButton = new Telerik.WinControls.UI.RadButton();
            printButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            dataPanel = new Telerik.WinControls.UI.RadPanel();
            dataGridView = new Telerik.WinControls.UI.RadGridView();
            commandPanel = new Telerik.WinControls.UI.RadPanel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            filterTextBox = new CustomControls.SearchTextBox();
            ((System.ComponentModel.ISupportInitialize)exportButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)printButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).BeginInit();
            dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)commandPanel).BeginInit();
            commandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // exportButton
            // 
            exportButton.ImageAlignment = ContentAlignment.MiddleCenter;
            exportButton.Location = new Point(702, 12);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(108, 30);
            exportButton.TabIndex = 3;
            exportButton.Text = "Exporter";
            // 
            // printButton
            // 
            printButton.ImageAlignment = ContentAlignment.MiddleCenter;
            printButton.Location = new Point(588, 12);
            printButton.Name = "printButton";
            printButton.Size = new Size(108, 30);
            printButton.TabIndex = 2;
            printButton.Text = "Imprimer";
            // 
            // saveButton
            // 
            saveButton.ImageAlignment = ContentAlignment.MiddleCenter;
            saveButton.Location = new Point(474, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(108, 30);
            saveButton.TabIndex = 1;
            saveButton.Text = "Enregistrer";
            // 
            // dataPanel
            // 
            dataPanel.Controls.Add(dataGridView);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Location = new Point(0, 62);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(931, 503);
            dataPanel.TabIndex = 9;
            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            // 
            // 
            // 
            dataGridView.MasterTemplate.AllowAddNewRow = false;
            dataGridView.MasterTemplate.AllowDeleteRow = false;
            dataGridView.MasterTemplate.AllowEditRow = false;
            dataGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(931, 503);
            dataGridView.TabIndex = 4;
            // 
            // commandPanel
            // 
            commandPanel.BackColor = Color.FromArgb(191, 219, 255);
            commandPanel.Controls.Add(closeButton);
            commandPanel.Controls.Add(filterTextBox);
            commandPanel.Controls.Add(exportButton);
            commandPanel.Controls.Add(printButton);
            commandPanel.Controls.Add(saveButton);
            commandPanel.Dock = DockStyle.Top;
            commandPanel.Location = new Point(0, 0);
            commandPanel.Name = "commandPanel";
            commandPanel.Size = new Size(931, 62);
            commandPanel.TabIndex = 8;
            // 
            // closeButton
            // 
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.Location = new Point(816, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(98, 30);
            closeButton.TabIndex = 12;
            closeButton.Text = "Annuler";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(12, 12);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.NullText = "Rechercher par ....";
            filterTextBox.Size = new Size(453, 30);
            filterTextBox.TabIndex = 11;
            // 
            // EvaluationSessionStateForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 565);
            Controls.Add(dataPanel);
            Controls.Add(commandPanel);
            MaximizeBox = false;
            Name = "EvaluationSessionStateForm";
            Text = "Evaluation state";
            ((System.ComponentModel.ISupportInitialize)exportButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)printButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).EndInit();
            dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)commandPanel).EndInit();
            commandPanel.ResumeLayout(false);
            commandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Telerik.WinControls.UI.RadButton exportButton;
        private Telerik.WinControls.UI.RadButton printButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadPanel dataPanel;
        private Telerik.WinControls.UI.RadGridView dataGridView;
        private Telerik.WinControls.UI.RadPanel commandPanel;
        private CustomControls.SearchTextBox filterTextBox;
        private Telerik.WinControls.UI.RadButton closeButton;
    }
}