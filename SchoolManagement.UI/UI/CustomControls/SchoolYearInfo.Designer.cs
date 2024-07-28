namespace SchoolManagement.UI.CustomControls
{
    partial class SchoolYearInfo
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Telerik.WinControls.UI.RadPanel();
            editButton = new Telerik.WinControls.UI.RadButton();
            closeButton = new Telerik.WinControls.UI.RadButton();
            titleInfoLabel = new Telerik.WinControls.UI.RadLabel();
            editPanel = new Telerik.WinControls.UI.RadPanel();
            endDateTextBox = new Telerik.WinControls.UI.RadTextBox();
            endDateSeparator = new Telerik.WinControls.UI.RadSeparator();
            endDateLabel = new Telerik.WinControls.UI.RadLabel();
            startDateTextBox = new Telerik.WinControls.UI.RadTextBox();
            startDateSeparator = new Telerik.WinControls.UI.RadSeparator();
            startDateLabel = new Telerik.WinControls.UI.RadLabel();
            nameTextBox = new Telerik.WinControls.UI.RadTextBox();
            nameSeparator = new Telerik.WinControls.UI.RadSeparator();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endDateTextBox).BeginInit();
            endDateTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endDateSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endDateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startDateTextBox).BeginInit();
            startDateTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)startDateSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startDateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).BeginInit();
            nameTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(editButton);
            headerPanel.Controls.Add(closeButton);
            headerPanel.Controls.Add(titleInfoLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(4, 5, 4, 5);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(315, 62);
            headerPanel.TabIndex = 19;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(225, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(45, 62);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(270, 0);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(45, 62);
            closeButton.TabIndex = 2;
            // 
            // titleInfoLabel
            // 
            titleInfoLabel.AutoSize = false;
            titleInfoLabel.Dock = DockStyle.Fill;
            titleInfoLabel.Location = new Point(0, 0);
            titleInfoLabel.Margin = new Padding(4, 5, 4, 5);
            titleInfoLabel.Name = "titleInfoLabel";
            titleInfoLabel.Size = new Size(315, 62);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS ";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(endDateTextBox);
            editPanel.Controls.Add(endDateLabel);
            editPanel.Controls.Add(startDateTextBox);
            editPanel.Controls.Add(startDateLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(315, 226);
            editPanel.TabIndex = 21;
            // 
            // endDateTextBox
            // 
            endDateTextBox.AutoSize = false;
            endDateTextBox.Controls.Add(endDateSeparator);
            endDateTextBox.Dock = DockStyle.Top;
            endDateTextBox.Location = new Point(0, 170);
            endDateTextBox.Margin = new Padding(4, 5, 4, 5);
            endDateTextBox.Name = "endDateTextBox";
            endDateTextBox.ReadOnly = true;
            endDateTextBox.Size = new Size(315, 40);
            endDateTextBox.TabIndex = 10;
            // 
            // endDateSeparator
            // 
            endDateSeparator.Location = new Point(15, 32);
            endDateSeparator.Margin = new Padding(4, 5, 4, 5);
            endDateSeparator.Name = "endDateSeparator";
            endDateSeparator.Size = new Size(283, 4);
            endDateSeparator.TabIndex = 6;
            endDateSeparator.TabStop = false;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = false;
            endDateLabel.Dock = DockStyle.Top;
            endDateLabel.Location = new Point(0, 140);
            endDateLabel.Margin = new Padding(4, 5, 4, 5);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(315, 30);
            endDateLabel.TabIndex = 9;
            endDateLabel.Text = "Fin:";
            // 
            // startDateTextBox
            // 
            startDateTextBox.AutoSize = false;
            startDateTextBox.Controls.Add(startDateSeparator);
            startDateTextBox.Dock = DockStyle.Top;
            startDateTextBox.Location = new Point(0, 100);
            startDateTextBox.Margin = new Padding(4, 5, 4, 5);
            startDateTextBox.Name = "startDateTextBox";
            startDateTextBox.ReadOnly = true;
            startDateTextBox.Size = new Size(315, 40);
            startDateTextBox.TabIndex = 8;
            // 
            // startDateSeparator
            // 
            startDateSeparator.Location = new Point(15, 32);
            startDateSeparator.Margin = new Padding(4, 5, 4, 5);
            startDateSeparator.Name = "startDateSeparator";
            startDateSeparator.Size = new Size(283, 4);
            startDateSeparator.TabIndex = 6;
            startDateSeparator.TabStop = false;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = false;
            startDateLabel.Dock = DockStyle.Top;
            startDateLabel.Location = new Point(0, 70);
            startDateLabel.Margin = new Padding(4, 5, 4, 5);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(315, 30);
            startDateLabel.TabIndex = 7;
            startDateLabel.Text = "Début:";
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = false;
            nameTextBox.Controls.Add(nameSeparator);
            nameTextBox.Dock = DockStyle.Top;
            nameTextBox.Location = new Point(0, 30);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.ReadOnly = true;
            nameTextBox.Size = new Size(315, 40);
            nameTextBox.TabIndex = 6;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(15, 32);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(283, 4);
            nameSeparator.TabIndex = 6;
            nameSeparator.TabStop = false;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = false;
            nameLabel.Dock = DockStyle.Top;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Margin = new Padding(4, 5, 4, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(315, 30);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Désignation:";
            // 
            // SchoolYearInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "SchoolYearInfo";
            Size = new Size(315, 305);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)endDateTextBox).EndInit();
            endDateTextBox.ResumeLayout(false);
            endDateTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endDateSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)endDateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)startDateTextBox).EndInit();
            startDateTextBox.ResumeLayout(false);
            startDateTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)startDateSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)startDateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).EndInit();
            nameTextBox.ResumeLayout(false);
            nameTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadButton editButton;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadLabel titleInfoLabel;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadTextBox startDateTextBox;
        private Telerik.WinControls.UI.RadSeparator startDateSeparator;
        private Telerik.WinControls.UI.RadLabel startDateLabel;
        private Telerik.WinControls.UI.RadLabel endDateLabel;
        private Telerik.WinControls.UI.RadTextBox endDateTextBox;
        private Telerik.WinControls.UI.RadSeparator endDateSeparator;
    }
}
