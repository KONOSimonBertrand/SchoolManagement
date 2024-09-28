namespace SchoolManagement.UI.CustomControls
{
    partial class SchoolRoomInfo
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
            studentsCountLabel = new Telerik.WinControls.UI.RadLabel();
            classTextBox = new Telerik.WinControls.UI.RadTextBox();
            classSeparator = new Telerik.WinControls.UI.RadSeparator();
            classLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)studentsCountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classTextBox).BeginInit();
            classTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)classSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).BeginInit();
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
            headerPanel.Size = new Size(359, 40);
            headerPanel.TabIndex = 17;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(279, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(40, 40);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(319, 0);
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
            titleInfoLabel.Size = new Size(359, 40);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(studentsCountLabel);
            editPanel.Controls.Add(classTextBox);
            editPanel.Controls.Add(classLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 40);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(359, 181);
            editPanel.TabIndex = 18;
            // 
            // studentsCountLabel
            // 
            studentsCountLabel.AutoSize = false;
            studentsCountLabel.Dock = DockStyle.Top;
            studentsCountLabel.Location = new Point(0, 140);
            studentsCountLabel.Margin = new Padding(4, 5, 4, 5);
            studentsCountLabel.Name = "studentsCountLabel";
            studentsCountLabel.Size = new Size(359, 30);
            studentsCountLabel.TabIndex = 59;
            studentsCountLabel.Text = "Nombre d'élèves ";
            // 
            // classTextBox
            // 
            classTextBox.AutoSize = false;
            classTextBox.Controls.Add(classSeparator);
            classTextBox.Dock = DockStyle.Top;
            classTextBox.Location = new Point(0, 100);
            classTextBox.Margin = new Padding(4, 5, 4, 5);
            classTextBox.Name = "classTextBox";
            classTextBox.ReadOnly = true;
            classTextBox.Size = new Size(359, 40);
            classTextBox.TabIndex = 58;
            // 
            // classSeparator
            // 
            classSeparator.Location = new Point(15, 32);
            classSeparator.Margin = new Padding(4, 5, 4, 5);
            classSeparator.Name = "classSeparator";
            classSeparator.Size = new Size(330, 4);
            classSeparator.TabIndex = 12;
            classSeparator.TabStop = false;
            // 
            // classLabel
            // 
            classLabel.AutoSize = false;
            classLabel.Dock = DockStyle.Top;
            classLabel.Location = new Point(0, 70);
            classLabel.Margin = new Padding(4, 5, 4, 5);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(359, 30);
            classLabel.TabIndex = 57;
            classLabel.Text = "Classe:";
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
            nameSeparator.Size = new Size(330, 4);
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
            // SchoolRoomInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SchoolRoomInfo";
            Size = new Size(359, 259);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)studentsCountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)classTextBox).EndInit();
            classTextBox.ResumeLayout(false);
            classTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)classSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox classTextBox;
        private Telerik.WinControls.UI.RadSeparator classSeparator;
        private Telerik.WinControls.UI.RadLabel classLabel;
        private Telerik.WinControls.UI.RadLabel studentsCountLabel;
    }
}
