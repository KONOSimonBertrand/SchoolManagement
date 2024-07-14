namespace SchoolManagement.UI.CustomControls
{
    partial class PaymentMeanInfo
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
            accountTextBox = new Telerik.WinControls.UI.RadTextBox();
            accountSeparator = new Telerik.WinControls.UI.RadSeparator();
            accountLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)accountTextBox).BeginInit();
            accountTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountLabel).BeginInit();
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
            headerPanel.TabIndex = 20;
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
            titleInfoLabel.Text = "INFOS SUR NIVEAU";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(typeTextBox);
            editPanel.Controls.Add(typeLabel);
            editPanel.Controls.Add(accountTextBox);
            editPanel.Controls.Add(accountLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(315, 393);
            editPanel.TabIndex = 22;
            // 
            // typeTextBox
            // 
            typeTextBox.AutoSize = false;
            typeTextBox.Controls.Add(typeSeparator);
            typeTextBox.Dock = DockStyle.Top;
            typeTextBox.Location = new Point(0, 310);
            typeTextBox.Margin = new Padding(4, 5, 4, 5);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.ReadOnly = true;
            typeTextBox.Size = new Size(315, 62);
            typeTextBox.TabIndex = 2;
            // 
            // typeSeparator
            // 
            typeSeparator.Location = new Point(15, 51);
            typeSeparator.Margin = new Padding(4, 5, 4, 5);
            typeSeparator.Name = "typeSeparator";
            typeSeparator.Size = new Size(345, 6);
            typeSeparator.TabIndex = 6;
            typeSeparator.TabStop = false;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = false;
            typeLabel.Dock = DockStyle.Top;
            typeLabel.Location = new Point(0, 248);
            typeLabel.Margin = new Padding(4, 5, 4, 5);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(315, 62);
            typeLabel.TabIndex = 11;
            typeLabel.Text = "Catégorie:";
            // 
            // accountTextBox
            // 
            accountTextBox.AutoSize = false;
            accountTextBox.Controls.Add(accountSeparator);
            accountTextBox.Dock = DockStyle.Top;
            accountTextBox.Location = new Point(0, 186);
            accountTextBox.Margin = new Padding(4, 5, 4, 5);
            accountTextBox.Name = "accountTextBox";
            accountTextBox.ReadOnly = true;
            accountTextBox.Size = new Size(315, 62);
            accountTextBox.TabIndex = 1;
            // 
            // accountSeparator
            // 
            accountSeparator.Location = new Point(15, 51);
            accountSeparator.Margin = new Padding(4, 5, 4, 5);
            accountSeparator.Name = "accountSeparator";
            accountSeparator.Size = new Size(345, 6);
            accountSeparator.TabIndex = 6;
            accountSeparator.TabStop = false;
            // 
            // accountLabel
            // 
            accountLabel.AutoSize = false;
            accountLabel.Dock = DockStyle.Top;
            accountLabel.Location = new Point(0, 124);
            accountLabel.Margin = new Padding(4, 5, 4, 5);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new Size(315, 62);
            accountLabel.TabIndex = 6;
            accountLabel.Text = "Compte:";
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = false;
            nameTextBox.Controls.Add(nameSeparator);
            nameTextBox.Dock = DockStyle.Top;
            nameTextBox.Location = new Point(0, 62);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.ReadOnly = true;
            nameTextBox.Size = new Size(315, 62);
            nameTextBox.TabIndex = 0;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(15, 51);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(345, 6);
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
            nameLabel.Size = new Size(315, 62);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Désignation:";
            // 
            // PaymentMeanInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "PaymentMeanInfo";
            Size = new Size(315, 425);
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
            ((System.ComponentModel.ISupportInitialize)accountTextBox).EndInit();
            accountTextBox.ResumeLayout(false);
            accountTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)accountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox accountTextBox;
        private Telerik.WinControls.UI.RadSeparator accountSeparator;
        private Telerik.WinControls.UI.RadLabel accountLabel;
        private Telerik.WinControls.UI.RadTextBox typeTextBox;
        private Telerik.WinControls.UI.RadSeparator typeSeparator;
        private Telerik.WinControls.UI.RadLabel typeLabel;
    }
}
