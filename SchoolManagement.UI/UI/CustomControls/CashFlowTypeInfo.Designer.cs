namespace SchoolManagement.UI.CustomControls
{
    partial class CashFlowTypeInfo
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
            typeTextBox = new Telerik.WinControls.UI.RadTextBox();
            typeSeparator = new Telerik.WinControls.UI.RadSeparator();
            typeLabel = new Telerik.WinControls.UI.RadLabel();
            categoryTextBox = new Telerik.WinControls.UI.RadTextBox();
            categorySeparator = new Telerik.WinControls.UI.RadSeparator();
            categoryLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)typeTextBox).BeginInit();
            typeTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)typeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoryTextBox).BeginInit();
            categoryTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categorySeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoryLabel).BeginInit();
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
            headerPanel.Size = new Size(455, 62);
            headerPanel.TabIndex = 18;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(365, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(45, 62);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(410, 0);
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
            titleInfoLabel.Size = new Size(455, 62);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS SUR LE TYPE";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(typeTextBox);
            editPanel.Controls.Add(typeLabel);
            editPanel.Controls.Add(categoryTextBox);
            editPanel.Controls.Add(categoryLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(455, 230);
            editPanel.TabIndex = 19;
            // 
            // typeTextBox
            // 
            typeTextBox.AutoSize = false;
            typeTextBox.Controls.Add(typeSeparator);
            typeTextBox.Dock = DockStyle.Top;
            typeTextBox.Location = new Point(0, 170);
            typeTextBox.Margin = new Padding(4, 5, 4, 5);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.ReadOnly = true;
            typeTextBox.Size = new Size(455, 40);
            typeTextBox.TabIndex = 2;
            // 
            // typeSeparator
            // 
            typeSeparator.Location = new Point(10, 34);
            typeSeparator.Margin = new Padding(4, 5, 4, 5);
            typeSeparator.Name = "typeSeparator";
            typeSeparator.Size = new Size(385, 4);
            typeSeparator.TabIndex = 12;
            typeSeparator.TabStop = false;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = false;
            typeLabel.Dock = DockStyle.Top;
            typeLabel.Location = new Point(0, 140);
            typeLabel.Margin = new Padding(4, 5, 4, 5);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(455, 30);
            typeLabel.TabIndex = 59;
            typeLabel.Text = "Type:";
            // 
            // categoryTextBox
            // 
            categoryTextBox.AutoSize = false;
            categoryTextBox.Controls.Add(categorySeparator);
            categoryTextBox.Dock = DockStyle.Top;
            categoryTextBox.Location = new Point(0, 100);
            categoryTextBox.Margin = new Padding(4, 5, 4, 5);
            categoryTextBox.Name = "categoryTextBox";
            categoryTextBox.ReadOnly = true;
            categoryTextBox.Size = new Size(455, 40);
            categoryTextBox.TabIndex = 1;
            // 
            // categorySeparator
            // 
            categorySeparator.Location = new Point(10, 34);
            categorySeparator.Margin = new Padding(4, 5, 4, 5);
            categorySeparator.Name = "categorySeparator";
            categorySeparator.Size = new Size(385, 4);
            categorySeparator.TabIndex = 12;
            categorySeparator.TabStop = false;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = false;
            categoryLabel.Dock = DockStyle.Top;
            categoryLabel.Location = new Point(0, 70);
            categoryLabel.Margin = new Padding(4, 5, 4, 5);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(455, 30);
            categoryLabel.TabIndex = 6;
            categoryLabel.Text = "Catégorie:";
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
            nameTextBox.Size = new Size(455, 40);
            nameTextBox.TabIndex = 0;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(10, 34);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(380, 4);
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
            nameLabel.Size = new Size(455, 30);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Désignation:";
            // 
            // CashFlowTypeInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "CashFlowTypeInfo";
            Size = new Size(455, 366);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)typeTextBox).EndInit();
            typeTextBox.ResumeLayout(false);
            typeTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)typeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoryTextBox).EndInit();
            categoryTextBox.ResumeLayout(false);
            categoryTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categorySeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoryLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox categoryTextBox;
        private Telerik.WinControls.UI.RadSeparator categorySeparator;
        private Telerik.WinControls.UI.RadLabel categoryLabel;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel typeLabel;
        private Telerik.WinControls.UI.RadTextBox typeTextBox;
        private Telerik.WinControls.UI.RadSeparator typeSeparator;
    }
}
