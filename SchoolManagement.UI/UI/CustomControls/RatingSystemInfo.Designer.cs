namespace SchoolManagement.UI.CustomControls
{
    partial class RatingSystemInfo
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
            noteMaxTextBox = new Telerik.WinControls.UI.RadTextBox();
            noteMaxSeparator = new Telerik.WinControls.UI.RadSeparator();
            noteMaxLabel = new Telerik.WinControls.UI.RadLabel();
            noteMinTextBox = new Telerik.WinControls.UI.RadTextBox();
            noteMinSeparator = new Telerik.WinControls.UI.RadSeparator();
            noteMinLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)noteMaxTextBox).BeginInit();
            noteMaxTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)noteMaxSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteMaxLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteMinTextBox).BeginInit();
            noteMinTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)noteMinSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteMinLabel).BeginInit();
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
            headerPanel.Size = new Size(289, 40);
            headerPanel.TabIndex = 19;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(209, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(40, 40);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(249, 0);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 40);
            closeButton.TabIndex = 2;
            // 
            // titleInfoLabel
            // 
            titleInfoLabel.AutoSize = false;
            titleInfoLabel.Dock = DockStyle.Fill;
            titleInfoLabel.Location = new Point(0, 0);
            titleInfoLabel.Margin = new Padding(4, 5, 4, 5);
            titleInfoLabel.Name = "titleInfoLabel";
            titleInfoLabel.Size = new Size(289, 40);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS SUR LE SYSTEME";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(noteMaxTextBox);
            editPanel.Controls.Add(noteMaxLabel);
            editPanel.Controls.Add(noteMinTextBox);
            editPanel.Controls.Add(noteMinLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 40);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(289, 406);
            editPanel.TabIndex = 20;
            // 
            // noteMaxTextBox
            // 
            noteMaxTextBox.AutoSize = false;
            noteMaxTextBox.Controls.Add(noteMaxSeparator);
            noteMaxTextBox.Dock = DockStyle.Top;
            noteMaxTextBox.Location = new Point(0, 170);
            noteMaxTextBox.Margin = new Padding(4, 5, 4, 5);
            noteMaxTextBox.Name = "noteMaxTextBox";
            noteMaxTextBox.ReadOnly = true;
            noteMaxTextBox.Size = new Size(289, 40);
            noteMaxTextBox.TabIndex = 12;
            // 
            // noteMaxSeparator
            // 
            noteMaxSeparator.Location = new Point(8, 32);
            noteMaxSeparator.Margin = new Padding(4, 5, 4, 5);
            noteMaxSeparator.Name = "noteMaxSeparator";
            noteMaxSeparator.Size = new Size(276, 4);
            noteMaxSeparator.TabIndex = 6;
            noteMaxSeparator.TabStop = false;
            // 
            // noteMaxLabel
            // 
            noteMaxLabel.AutoSize = false;
            noteMaxLabel.Dock = DockStyle.Top;
            noteMaxLabel.Location = new Point(0, 140);
            noteMaxLabel.Margin = new Padding(4, 5, 4, 5);
            noteMaxLabel.Name = "noteMaxLabel";
            noteMaxLabel.Size = new Size(289, 30);
            noteMaxLabel.TabIndex = 11;
            noteMaxLabel.Text = "Note Maximum:";
            // 
            // noteMinTextBox
            // 
            noteMinTextBox.AutoSize = false;
            noteMinTextBox.Controls.Add(noteMinSeparator);
            noteMinTextBox.Dock = DockStyle.Top;
            noteMinTextBox.Location = new Point(0, 100);
            noteMinTextBox.Margin = new Padding(4, 5, 4, 5);
            noteMinTextBox.Name = "noteMinTextBox";
            noteMinTextBox.ReadOnly = true;
            noteMinTextBox.Size = new Size(289, 40);
            noteMinTextBox.TabIndex = 10;
            // 
            // noteMinSeparator
            // 
            noteMinSeparator.Location = new Point(8, 32);
            noteMinSeparator.Margin = new Padding(4, 5, 4, 5);
            noteMinSeparator.Name = "noteMinSeparator";
            noteMinSeparator.Size = new Size(276, 4);
            noteMinSeparator.TabIndex = 6;
            noteMinSeparator.TabStop = false;
            // 
            // noteMinLabel
            // 
            noteMinLabel.AutoSize = false;
            noteMinLabel.Dock = DockStyle.Top;
            noteMinLabel.Location = new Point(0, 70);
            noteMinLabel.Margin = new Padding(4, 5, 4, 5);
            noteMinLabel.Name = "noteMinLabel";
            noteMinLabel.Size = new Size(289, 30);
            noteMinLabel.TabIndex = 9;
            noteMinLabel.Text = "Note Minimum :";
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
            nameTextBox.Size = new Size(289, 40);
            nameTextBox.TabIndex = 4;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(9, 32);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(276, 4);
            nameSeparator.TabIndex = 12;
            nameSeparator.TabStop = false;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = false;
            nameLabel.Dock = DockStyle.Top;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Margin = new Padding(4, 5, 4, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(289, 30);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Appréciation:";
            // 
            // RatingSystemInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "RatingSystemInfo";
            Size = new Size(289, 277);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)noteMaxTextBox).EndInit();
            noteMaxTextBox.ResumeLayout(false);
            noteMaxTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)noteMaxSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteMaxLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteMinTextBox).EndInit();
            noteMinTextBox.ResumeLayout(false);
            noteMinTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)noteMinSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteMinLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox noteMaxTextBox;
        private Telerik.WinControls.UI.RadSeparator noteMaxSeparator;
        private Telerik.WinControls.UI.RadLabel noteMaxLabel;
        private Telerik.WinControls.UI.RadTextBox noteMinTextBox;
        private Telerik.WinControls.UI.RadSeparator noteMinSeparator;
        private Telerik.WinControls.UI.RadLabel noteMinLabel;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadLabel nameLabel;
    }
}
