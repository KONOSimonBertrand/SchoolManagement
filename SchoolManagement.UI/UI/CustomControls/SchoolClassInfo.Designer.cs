namespace SchoolManagement.UI.CustomControls
{
    partial class SchoolClassInfo
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
            subjectsCountLabel = new Telerik.WinControls.UI.RadLabel();
            groupTextBox = new Telerik.WinControls.UI.RadTextBox();
            groupSeparator = new Telerik.WinControls.UI.RadSeparator();
            groupLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)subjectsCountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupTextBox).BeginInit();
            groupTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupLabel).BeginInit();
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
            headerPanel.Size = new Size(359, 62);
            headerPanel.TabIndex = 17;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(269, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(45, 62);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(314, 0);
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
            titleInfoLabel.Size = new Size(359, 62);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(subjectsCountLabel);
            editPanel.Controls.Add(groupTextBox);
            editPanel.Controls.Add(groupLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(359, 176);
            editPanel.TabIndex = 18;
            // 
            // subjectsCountLabel
            // 
            subjectsCountLabel.AutoSize = false;
            subjectsCountLabel.Dock = DockStyle.Top;
            subjectsCountLabel.Location = new Point(0, 140);
            subjectsCountLabel.Margin = new Padding(4, 5, 4, 5);
            subjectsCountLabel.Name = "subjectsCountLabel";
            subjectsCountLabel.Size = new Size(359, 30);
            subjectsCountLabel.TabIndex = 59;
            subjectsCountLabel.Text = "Matières enseignées ";
            // 
            // groupTextBox
            // 
            groupTextBox.AutoSize = false;
            groupTextBox.Controls.Add(groupSeparator);
            groupTextBox.Dock = DockStyle.Top;
            groupTextBox.Location = new Point(0, 100);
            groupTextBox.Margin = new Padding(4, 5, 4, 5);
            groupTextBox.Name = "groupTextBox";
            groupTextBox.ReadOnly = true;
            groupTextBox.Size = new Size(359, 40);
            groupTextBox.TabIndex = 58;
            // 
            // groupSeparator
            // 
            groupSeparator.Location = new Point(15, 32);
            groupSeparator.Margin = new Padding(4, 5, 4, 5);
            groupSeparator.Name = "groupSeparator";
            groupSeparator.Size = new Size(331, 4);
            groupSeparator.TabIndex = 12;
            groupSeparator.TabStop = false;
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = false;
            groupLabel.Dock = DockStyle.Top;
            groupLabel.Location = new Point(0, 70);
            groupLabel.Margin = new Padding(4, 5, 4, 5);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(359, 30);
            groupLabel.TabIndex = 57;
            groupLabel.Text = "Groupe:";
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
            nameTextBox.Size = new Size(359, 40);
            nameTextBox.TabIndex = 6;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(15, 32);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(331, 4);
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
            nameLabel.Size = new Size(359, 30);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Désignation:";
            // 
            // SchoolClassInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SchoolClassInfo";
            Size = new Size(359, 251);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)subjectsCountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupTextBox).EndInit();
            groupTextBox.ResumeLayout(false);
            groupTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)groupSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox groupTextBox;
        private Telerik.WinControls.UI.RadSeparator groupSeparator;
        private Telerik.WinControls.UI.RadLabel groupLabel;
        private Telerik.WinControls.UI.RadLabel subjectsCountLabel;
    }
}
