namespace SchoolManagement.UI.CustomControls
{
    partial class SchoolingCostInfo
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
            trancheValueLabel = new Telerik.WinControls.UI.RadLabel();
            amountSplitContainer = new Telerik.WinControls.UI.RadSplitContainer();
            amountSplitPanel = new Telerik.WinControls.UI.SplitPanel();
            amountTextBox = new Telerik.WinControls.UI.RadTextBox();
            amountSeparator = new Telerik.WinControls.UI.RadSeparator();
            amountLabel = new Telerik.WinControls.UI.RadLabel();
            trancheNumberSplitPanel = new Telerik.WinControls.UI.SplitPanel();
            trancheNumberTextBox = new Telerik.WinControls.UI.RadTextBox();
            trancheNumberSeparator = new Telerik.WinControls.UI.RadSeparator();
            trancheNumberLabel = new Telerik.WinControls.UI.RadLabel();
            costTypeTextBox = new Telerik.WinControls.UI.RadTextBox();
            costTypeSeparator = new Telerik.WinControls.UI.RadSeparator();
            costTypeLabel = new Telerik.WinControls.UI.RadLabel();
            classTextBox = new Telerik.WinControls.UI.RadTextBox();
            classSeparator = new Telerik.WinControls.UI.RadSeparator();
            classLabel = new Telerik.WinControls.UI.RadLabel();
            schoolYearTextBox = new Telerik.WinControls.UI.RadTextBox();
            schoolYearSeparator = new Telerik.WinControls.UI.RadSeparator();
            schoolYearLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trancheValueLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountSplitContainer).BeginInit();
            amountSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountSplitPanel).BeginInit();
            amountSplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).BeginInit();
            amountTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSplitPanel).BeginInit();
            trancheNumberSplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trancheNumberTextBox).BeginInit();
            trancheNumberTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTypeTextBox).BeginInit();
            costTypeTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)costTypeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTypeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classTextBox).BeginInit();
            classTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)classSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearTextBox).BeginInit();
            schoolYearTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)schoolYearSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearLabel).BeginInit();
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
            headerPanel.Size = new Size(314, 62);
            headerPanel.TabIndex = 19;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(224, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(45, 62);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(269, 0);
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
            titleInfoLabel.Size = new Size(314, 62);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "FRAIS SCOLAIRE";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(trancheValueLabel);
            editPanel.Controls.Add(amountSplitContainer);
            editPanel.Controls.Add(costTypeTextBox);
            editPanel.Controls.Add(costTypeLabel);
            editPanel.Controls.Add(classTextBox);
            editPanel.Controls.Add(classLabel);
            editPanel.Controls.Add(schoolYearTextBox);
            editPanel.Controls.Add(schoolYearLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(314, 430);
            editPanel.TabIndex = 20;
            // 
            // trancheValueLabel
            // 
            trancheValueLabel.AutoSize = false;
            trancheValueLabel.Dock = DockStyle.Top;
            trancheValueLabel.Location = new Point(0, 282);
            trancheValueLabel.Margin = new Padding(4, 5, 4, 5);
            trancheValueLabel.Name = "trancheValueLabel";
            trancheValueLabel.Size = new Size(314, 143);
            trancheValueLabel.TabIndex = 79;
            trancheValueLabel.Text = "Tranche(s):";
            // 
            // amountSplitContainer
            // 
            amountSplitContainer.Controls.Add(amountSplitPanel);
            amountSplitContainer.Controls.Add(trancheNumberSplitPanel);
            amountSplitContainer.Dock = DockStyle.Top;
            amountSplitContainer.Location = new Point(0, 210);
            amountSplitContainer.Name = "amountSplitContainer";
            // 
            // 
            // 
            amountSplitContainer.RootElement.MinSize = new Size(25, 25);
            amountSplitContainer.Size = new Size(314, 72);
            amountSplitContainer.SplitterWidth = 0;
            amountSplitContainer.TabIndex = 78;
            amountSplitContainer.TabStop = false;
            // 
            // amountSplitPanel
            // 
            amountSplitPanel.Controls.Add(amountTextBox);
            amountSplitPanel.Controls.Add(amountLabel);
            amountSplitPanel.Location = new Point(0, 0);
            amountSplitPanel.Name = "amountSplitPanel";
            // 
            // 
            // 
            amountSplitPanel.RootElement.MinSize = new Size(25, 25);
            amountSplitPanel.Size = new Size(157, 72);
            amountSplitPanel.TabIndex = 6;
            amountSplitPanel.TabStop = false;
            // 
            // amountTextBox
            // 
            amountTextBox.AutoSize = false;
            amountTextBox.Controls.Add(amountSeparator);
            amountTextBox.Dock = DockStyle.Top;
            amountTextBox.Location = new Point(0, 30);
            amountTextBox.Margin = new Padding(4, 5, 4, 5);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.ReadOnly = true;
            amountTextBox.Size = new Size(157, 40);
            amountTextBox.TabIndex = 75;
            // 
            // amountSeparator
            // 
            amountSeparator.Location = new Point(13, 32);
            amountSeparator.Margin = new Padding(4, 5, 4, 5);
            amountSeparator.Name = "amountSeparator";
            amountSeparator.Size = new Size(130, 4);
            amountSeparator.TabIndex = 61;
            amountSeparator.TabStop = false;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = false;
            amountLabel.Dock = DockStyle.Top;
            amountLabel.Location = new Point(0, 0);
            amountLabel.Margin = new Padding(4, 5, 4, 5);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(157, 30);
            amountLabel.TabIndex = 74;
            amountLabel.Text = "Montant:";
            // 
            // trancheNumberSplitPanel
            // 
            trancheNumberSplitPanel.Controls.Add(trancheNumberTextBox);
            trancheNumberSplitPanel.Controls.Add(trancheNumberLabel);
            trancheNumberSplitPanel.Location = new Point(157, 0);
            trancheNumberSplitPanel.Name = "trancheNumberSplitPanel";
            // 
            // 
            // 
            trancheNumberSplitPanel.RootElement.MinSize = new Size(25, 25);
            trancheNumberSplitPanel.Size = new Size(157, 72);
            trancheNumberSplitPanel.TabIndex = 7;
            trancheNumberSplitPanel.TabStop = false;
            // 
            // trancheNumberTextBox
            // 
            trancheNumberTextBox.AutoSize = false;
            trancheNumberTextBox.Controls.Add(trancheNumberSeparator);
            trancheNumberTextBox.Dock = DockStyle.Top;
            trancheNumberTextBox.Location = new Point(0, 30);
            trancheNumberTextBox.Margin = new Padding(4, 5, 4, 5);
            trancheNumberTextBox.MaxLength = 1;
            trancheNumberTextBox.Name = "trancheNumberTextBox";
            trancheNumberTextBox.ReadOnly = true;
            trancheNumberTextBox.Size = new Size(157, 40);
            trancheNumberTextBox.TabIndex = 75;
            // 
            // trancheNumberSeparator
            // 
            trancheNumberSeparator.Location = new Point(13, 32);
            trancheNumberSeparator.Margin = new Padding(4, 5, 4, 5);
            trancheNumberSeparator.Name = "trancheNumberSeparator";
            trancheNumberSeparator.Size = new Size(130, 4);
            trancheNumberSeparator.TabIndex = 61;
            trancheNumberSeparator.TabStop = false;
            // 
            // trancheNumberLabel
            // 
            trancheNumberLabel.AutoSize = false;
            trancheNumberLabel.Dock = DockStyle.Top;
            trancheNumberLabel.Location = new Point(0, 0);
            trancheNumberLabel.Margin = new Padding(4, 5, 4, 5);
            trancheNumberLabel.Name = "trancheNumberLabel";
            trancheNumberLabel.Size = new Size(157, 30);
            trancheNumberLabel.TabIndex = 73;
            trancheNumberLabel.Text = "Nbre de tranches:";
            // 
            // costTypeTextBox
            // 
            costTypeTextBox.AutoSize = false;
            costTypeTextBox.Controls.Add(costTypeSeparator);
            costTypeTextBox.Dock = DockStyle.Top;
            costTypeTextBox.Location = new Point(0, 170);
            costTypeTextBox.Margin = new Padding(4, 5, 4, 5);
            costTypeTextBox.Name = "costTypeTextBox";
            costTypeTextBox.ReadOnly = true;
            costTypeTextBox.Size = new Size(314, 40);
            costTypeTextBox.TabIndex = 58;
            // 
            // costTypeSeparator
            // 
            costTypeSeparator.Location = new Point(15, 32);
            costTypeSeparator.Margin = new Padding(4, 5, 4, 5);
            costTypeSeparator.Name = "costTypeSeparator";
            costTypeSeparator.Size = new Size(290, 4);
            costTypeSeparator.TabIndex = 12;
            costTypeSeparator.TabStop = false;
            // 
            // costTypeLabel
            // 
            costTypeLabel.AutoSize = false;
            costTypeLabel.Dock = DockStyle.Top;
            costTypeLabel.Location = new Point(0, 140);
            costTypeLabel.Margin = new Padding(4, 5, 4, 5);
            costTypeLabel.Name = "costTypeLabel";
            costTypeLabel.Size = new Size(314, 30);
            costTypeLabel.TabIndex = 57;
            costTypeLabel.Text = "Type de frais:";
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
            classTextBox.Size = new Size(314, 40);
            classTextBox.TabIndex = 56;
            // 
            // classSeparator
            // 
            classSeparator.Location = new Point(15, 32);
            classSeparator.Margin = new Padding(4, 5, 4, 5);
            classSeparator.Name = "classSeparator";
            classSeparator.Size = new Size(290, 4);
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
            classLabel.Size = new Size(314, 30);
            classLabel.TabIndex = 55;
            classLabel.Text = "Classe:";
            // 
            // schoolYearTextBox
            // 
            schoolYearTextBox.AutoSize = false;
            schoolYearTextBox.Controls.Add(schoolYearSeparator);
            schoolYearTextBox.Dock = DockStyle.Top;
            schoolYearTextBox.Location = new Point(0, 30);
            schoolYearTextBox.Margin = new Padding(4, 5, 4, 5);
            schoolYearTextBox.Name = "schoolYearTextBox";
            schoolYearTextBox.ReadOnly = true;
            schoolYearTextBox.Size = new Size(314, 40);
            schoolYearTextBox.TabIndex = 6;
            // 
            // schoolYearSeparator
            // 
            schoolYearSeparator.Location = new Point(15, 32);
            schoolYearSeparator.Margin = new Padding(4, 5, 4, 5);
            schoolYearSeparator.Name = "schoolYearSeparator";
            schoolYearSeparator.Size = new Size(290, 4);
            schoolYearSeparator.TabIndex = 6;
            schoolYearSeparator.TabStop = false;
            // 
            // schoolYearLabel
            // 
            schoolYearLabel.AutoSize = false;
            schoolYearLabel.Dock = DockStyle.Top;
            schoolYearLabel.Location = new Point(0, 0);
            schoolYearLabel.Margin = new Padding(4, 5, 4, 5);
            schoolYearLabel.Name = "schoolYearLabel";
            schoolYearLabel.Size = new Size(314, 30);
            schoolYearLabel.TabIndex = 5;
            schoolYearLabel.Text = "Année scolaire:";
            // 
            // SchoolingCostInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "SchoolingCostInfo";
            Size = new Size(314, 493);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trancheValueLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountSplitContainer).EndInit();
            amountSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)amountSplitPanel).EndInit();
            amountSplitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)amountTextBox).EndInit();
            amountTextBox.ResumeLayout(false);
            amountTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSplitPanel).EndInit();
            trancheNumberSplitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trancheNumberTextBox).EndInit();
            trancheNumberTextBox.ResumeLayout(false);
            trancheNumberTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTypeTextBox).EndInit();
            costTypeTextBox.ResumeLayout(false);
            costTypeTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)costTypeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTypeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)classTextBox).EndInit();
            classTextBox.ResumeLayout(false);
            classTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)classSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearTextBox).EndInit();
            schoolYearTextBox.ResumeLayout(false);
            schoolYearTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)schoolYearSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearLabel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadButton editButton;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadLabel titleInfoLabel;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox costTypeTextBox;
        private Telerik.WinControls.UI.RadSeparator costTypeSeparator;
        private Telerik.WinControls.UI.RadLabel costTypeLabel;
        private Telerik.WinControls.UI.RadTextBox classTextBox;
        private Telerik.WinControls.UI.RadSeparator classSeparator;
        private Telerik.WinControls.UI.RadLabel classLabel;
        private Telerik.WinControls.UI.RadTextBox schoolYearTextBox;
        private Telerik.WinControls.UI.RadSeparator schoolYearSeparator;
        private Telerik.WinControls.UI.RadLabel schoolYearLabel;
        private Telerik.WinControls.UI.RadSplitContainer amountSplitContainer;
        private Telerik.WinControls.UI.SplitPanel amountSplitPanel;
        private Telerik.WinControls.UI.RadTextBox amountTextBox;
        private Telerik.WinControls.UI.RadSeparator amountSeparator;
        private Telerik.WinControls.UI.RadLabel amountLabel;
        private Telerik.WinControls.UI.SplitPanel trancheNumberSplitPanel;
        private Telerik.WinControls.UI.RadTextBox trancheNumberTextBox;
        private Telerik.WinControls.UI.RadSeparator trancheNumberSeparator;
        private Telerik.WinControls.UI.RadLabel trancheNumberLabel;
        private Telerik.WinControls.UI.RadLabel trancheValueLabel;
    }
}
