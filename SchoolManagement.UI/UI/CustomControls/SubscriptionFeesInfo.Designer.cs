namespace SchoolManagement.UI.CustomControls
{
    partial class SubscriptionFeesInfo
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
            amountTextBox = new Telerik.WinControls.UI.RadTextBox();
            amountSeparator = new Telerik.WinControls.UI.RadSeparator();
            AmountLabel = new Telerik.WinControls.UI.RadLabel();
            subscriptionTypeTextBox = new Telerik.WinControls.UI.RadTextBox();
            subscriptionTypeSeparator = new Telerik.WinControls.UI.RadSeparator();
            subscriptionTypeLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)amountTextBox).BeginInit();
            amountTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AmountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeTextBox).BeginInit();
            subscriptionTypeTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeLabel).BeginInit();
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
            headerPanel.Size = new Size(313, 62);
            headerPanel.TabIndex = 20;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(223, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(45, 62);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(268, 0);
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
            titleInfoLabel.Size = new Size(313, 62);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "FRAIS ABONNEMENT";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(amountTextBox);
            editPanel.Controls.Add(AmountLabel);
            editPanel.Controls.Add(subscriptionTypeTextBox);
            editPanel.Controls.Add(subscriptionTypeLabel);
            editPanel.Controls.Add(schoolYearTextBox);
            editPanel.Controls.Add(schoolYearLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(313, 218);
            editPanel.TabIndex = 21;
            // 
            // amountTextBox
            // 
            amountTextBox.AutoSize = false;
            amountTextBox.Controls.Add(amountSeparator);
            amountTextBox.Dock = DockStyle.Top;
            amountTextBox.Location = new Point(0, 170);
            amountTextBox.Margin = new Padding(4, 5, 4, 5);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.ReadOnly = true;
            amountTextBox.Size = new Size(313, 40);
            amountTextBox.TabIndex = 58;
            // 
            // amountSeparator
            // 
            amountSeparator.Location = new Point(15, 32);
            amountSeparator.Margin = new Padding(4, 5, 4, 5);
            amountSeparator.Name = "amountSeparator";
            amountSeparator.Size = new Size(278, 4);
            amountSeparator.TabIndex = 12;
            amountSeparator.TabStop = false;
            // 
            // AmountLabel
            // 
            AmountLabel.AutoSize = false;
            AmountLabel.Dock = DockStyle.Top;
            AmountLabel.Location = new Point(0, 140);
            AmountLabel.Margin = new Padding(4, 5, 4, 5);
            AmountLabel.Name = "AmountLabel";
            AmountLabel.Size = new Size(313, 30);
            AmountLabel.TabIndex = 57;
            AmountLabel.Text = "Montant:";
            // 
            // subscriptionTypeTextBox
            // 
            subscriptionTypeTextBox.AutoSize = false;
            subscriptionTypeTextBox.Controls.Add(subscriptionTypeSeparator);
            subscriptionTypeTextBox.Dock = DockStyle.Top;
            subscriptionTypeTextBox.Location = new Point(0, 100);
            subscriptionTypeTextBox.Margin = new Padding(4, 5, 4, 5);
            subscriptionTypeTextBox.Name = "subscriptionTypeTextBox";
            subscriptionTypeTextBox.ReadOnly = true;
            subscriptionTypeTextBox.Size = new Size(313, 40);
            subscriptionTypeTextBox.TabIndex = 56;
            // 
            // subscriptionTypeSeparator
            // 
            subscriptionTypeSeparator.Location = new Point(15, 32);
            subscriptionTypeSeparator.Margin = new Padding(4, 5, 4, 5);
            subscriptionTypeSeparator.Name = "subscriptionTypeSeparator";
            subscriptionTypeSeparator.Size = new Size(278, 4);
            subscriptionTypeSeparator.TabIndex = 12;
            subscriptionTypeSeparator.TabStop = false;
            // 
            // subscriptionTypeLabel
            // 
            subscriptionTypeLabel.AutoSize = false;
            subscriptionTypeLabel.Dock = DockStyle.Top;
            subscriptionTypeLabel.Location = new Point(0, 70);
            subscriptionTypeLabel.Margin = new Padding(4, 5, 4, 5);
            subscriptionTypeLabel.Name = "subscriptionTypeLabel";
            subscriptionTypeLabel.Size = new Size(313, 30);
            subscriptionTypeLabel.TabIndex = 55;
            subscriptionTypeLabel.Text = "Type d'abonnement:";
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
            schoolYearTextBox.Size = new Size(313, 40);
            schoolYearTextBox.TabIndex = 6;
            // 
            // schoolYearSeparator
            // 
            schoolYearSeparator.Location = new Point(15, 32);
            schoolYearSeparator.Margin = new Padding(4, 5, 4, 5);
            schoolYearSeparator.Name = "schoolYearSeparator";
            schoolYearSeparator.Size = new Size(278, 4);
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
            schoolYearLabel.Size = new Size(313, 30);
            schoolYearLabel.TabIndex = 5;
            schoolYearLabel.Text = "Année scolaire:";
            // 
            // SubscriptionFeesInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2, 2, 2, 2);
            Name = "SubscriptionFeesInfo";
            Size = new Size(313, 290);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)amountTextBox).EndInit();
            amountTextBox.ResumeLayout(false);
            amountTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)AmountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeTextBox).EndInit();
            subscriptionTypeTextBox.ResumeLayout(false);
            subscriptionTypeTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)subscriptionTypeLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox amountTextBox;
        private Telerik.WinControls.UI.RadSeparator amountSeparator;
        private Telerik.WinControls.UI.RadLabel AmountLabel;
        private Telerik.WinControls.UI.RadTextBox subscriptionTypeTextBox;
        private Telerik.WinControls.UI.RadSeparator subscriptionTypeSeparator;
        private Telerik.WinControls.UI.RadLabel subscriptionTypeLabel;
        private Telerik.WinControls.UI.RadTextBox schoolYearTextBox;
        private Telerik.WinControls.UI.RadSeparator schoolYearSeparator;
        private Telerik.WinControls.UI.RadLabel schoolYearLabel;
    }
}
