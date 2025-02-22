namespace SchoolManagement.UI.CustomControls
{
    partial class SchoolInfo
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
            serialKeyPanel = new Telerik.WinControls.UI.RadPanel();
            serialKeyButton = new Telerik.WinControls.UI.RadButton();
            serialKeyLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyUserLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyDurationLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyTypeLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serialKeyPanel).BeginInit();
            serialKeyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serialKeyButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).BeginInit();
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
            headerPanel.Size = new Size(354, 40);
            headerPanel.TabIndex = 18;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Right;
            editButton.Location = new Point(274, 0);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(40, 40);
            editButton.TabIndex = 2;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(314, 0);
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
            titleInfoLabel.Size = new Size(354, 40);
            titleInfoLabel.TabIndex = 1;
            titleInfoLabel.Text = "INFOS";
            // 
            // editPanel
            // 
            editPanel.Controls.Add(serialKeyDurationLabel);
            editPanel.Controls.Add(serialKeyTypeLabel);
            editPanel.Controls.Add(serialKeyUserLabel);
            editPanel.Controls.Add(serialKeyPanel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 40);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(354, 158);
            editPanel.TabIndex = 19;
            // 
            // serialKeyPanel
            // 
            serialKeyPanel.Controls.Add(serialKeyButton);
            serialKeyPanel.Controls.Add(serialKeyLabel);
            serialKeyPanel.Dock = DockStyle.Top;
            serialKeyPanel.Location = new Point(0, 0);
            serialKeyPanel.Margin = new Padding(4, 5, 4, 5);
            serialKeyPanel.Name = "serialKeyPanel";
            serialKeyPanel.Size = new Size(354, 40);
            serialKeyPanel.TabIndex = 19;
            // 
            // serialKeyButton
            // 
            serialKeyButton.Dock = DockStyle.Right;
            serialKeyButton.Location = new Point(314, 0);
            serialKeyButton.Margin = new Padding(4, 5, 4, 5);
            serialKeyButton.Name = "serialKeyButton";
            serialKeyButton.Size = new Size(40, 40);
            serialKeyButton.TabIndex = 2;
            // 
            // serialKeyLabel
            // 
            serialKeyLabel.AutoSize = false;
            serialKeyLabel.Dock = DockStyle.Fill;
            serialKeyLabel.Location = new Point(0, 0);
            serialKeyLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyLabel.Name = "serialKeyLabel";
            serialKeyLabel.Size = new Size(354, 40);
            serialKeyLabel.TabIndex = 1;
            serialKeyLabel.Text = "SERIAL KEY";
            // 
            // serialKeyUserLabel
            // 
            serialKeyUserLabel.AutoSize = false;
            serialKeyUserLabel.Dock = DockStyle.Top;
            serialKeyUserLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyUserLabel.Location = new Point(0, 40);
            serialKeyUserLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyUserLabel.Name = "serialKeyUserLabel";
            serialKeyUserLabel.Size = new Size(354, 30);
            serialKeyUserLabel.TabIndex = 21;
            serialKeyUserLabel.Text = "Utilisateur:";
            // 
            // serialKeyDurationLabel
            // 
            serialKeyDurationLabel.AutoSize = false;
            serialKeyDurationLabel.Dock = DockStyle.Top;
            serialKeyDurationLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyDurationLabel.Location = new Point(0, 100);
            serialKeyDurationLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyDurationLabel.Name = "serialKeyDurationLabel";
            serialKeyDurationLabel.Size = new Size(354, 30);
            serialKeyDurationLabel.TabIndex = 24;
            serialKeyDurationLabel.Text = "Date d'expiration:";
            // 
            // serialKeyTypeLabel
            // 
            serialKeyTypeLabel.AutoSize = false;
            serialKeyTypeLabel.Dock = DockStyle.Top;
            serialKeyTypeLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyTypeLabel.Location = new Point(0, 70);
            serialKeyTypeLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyTypeLabel.Name = "serialKeyTypeLabel";
            serialKeyTypeLabel.Size = new Size(354, 30);
            serialKeyTypeLabel.TabIndex = 23;
            serialKeyTypeLabel.Text = "Type de licence:";
            // 
            // SchoolInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Name = "SchoolInfo";
            Size = new Size(354, 209);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serialKeyPanel).EndInit();
            serialKeyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serialKeyButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadButton editButton;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadLabel titleInfoLabel;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadPanel serialKeyPanel;
        private Telerik.WinControls.UI.RadButton serialKeyButton;
        private Telerik.WinControls.UI.RadLabel serialKeyLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyUserLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyDurationLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyTypeLabel;
    }
}
