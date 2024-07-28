namespace SchoolManagement.UI.CustomControls
{
    partial class UserInfo
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
            moduleCountLabel = new Telerik.WinControls.UI.RadLabel();
            defaultModuleTextBox = new Telerik.WinControls.UI.RadTextBox();
            defaultModuleSeparator = new Telerik.WinControls.UI.RadSeparator();
            defaultModuleLabel = new Telerik.WinControls.UI.RadLabel();
            loginTextBox = new Telerik.WinControls.UI.RadTextBox();
            loginSeparator = new Telerik.WinControls.UI.RadSeparator();
            loginLabel = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)moduleCountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)defaultModuleTextBox).BeginInit();
            defaultModuleTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)defaultModuleSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)defaultModuleLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginTextBox).BeginInit();
            loginTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loginSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginLabel).BeginInit();
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
            editPanel.Controls.Add(moduleCountLabel);
            editPanel.Controls.Add(defaultModuleTextBox);
            editPanel.Controls.Add(defaultModuleLabel);
            editPanel.Controls.Add(loginTextBox);
            editPanel.Controls.Add(loginLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 62);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(315, 406);
            editPanel.TabIndex = 20;
            // 
            // moduleCountLabel
            // 
            moduleCountLabel.AutoSize = false;
            moduleCountLabel.Dock = DockStyle.Top;
            moduleCountLabel.Location = new Point(0, 210);
            moduleCountLabel.Margin = new Padding(4, 5, 4, 5);
            moduleCountLabel.Name = "moduleCountLabel";
            moduleCountLabel.Size = new Size(315, 30);
            moduleCountLabel.TabIndex = 65;
            moduleCountLabel.Text = "Modules alloués:";
            // 
            // defaultModuleTextBox
            // 
            defaultModuleTextBox.AutoSize = false;
            defaultModuleTextBox.Controls.Add(defaultModuleSeparator);
            defaultModuleTextBox.Dock = DockStyle.Top;
            defaultModuleTextBox.Location = new Point(0, 170);
            defaultModuleTextBox.Margin = new Padding(4, 5, 4, 5);
            defaultModuleTextBox.Name = "defaultModuleTextBox";
            defaultModuleTextBox.ReadOnly = true;
            defaultModuleTextBox.Size = new Size(315, 40);
            defaultModuleTextBox.TabIndex = 64;
            // 
            // defaultModuleSeparator
            // 
            defaultModuleSeparator.Location = new Point(15, 32);
            defaultModuleSeparator.Margin = new Padding(4, 5, 4, 5);
            defaultModuleSeparator.Name = "defaultModuleSeparator";
            defaultModuleSeparator.Size = new Size(283, 4);
            defaultModuleSeparator.TabIndex = 12;
            defaultModuleSeparator.TabStop = false;
            // 
            // defaultModuleLabel
            // 
            defaultModuleLabel.AutoSize = false;
            defaultModuleLabel.Dock = DockStyle.Top;
            defaultModuleLabel.Location = new Point(0, 140);
            defaultModuleLabel.Margin = new Padding(4, 5, 4, 5);
            defaultModuleLabel.Name = "defaultModuleLabel";
            defaultModuleLabel.Size = new Size(315, 30);
            defaultModuleLabel.TabIndex = 63;
            defaultModuleLabel.Text = "Module par défaut:";
            // 
            // loginTextBox
            // 
            loginTextBox.AutoSize = false;
            loginTextBox.Controls.Add(loginSeparator);
            loginTextBox.Dock = DockStyle.Top;
            loginTextBox.Location = new Point(0, 100);
            loginTextBox.Margin = new Padding(4, 5, 4, 5);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.ReadOnly = true;
            loginTextBox.Size = new Size(315, 40);
            loginTextBox.TabIndex = 62;
            // 
            // loginSeparator
            // 
            loginSeparator.Location = new Point(15, 32);
            loginSeparator.Margin = new Padding(4, 5, 4, 5);
            loginSeparator.Name = "loginSeparator";
            loginSeparator.Size = new Size(283, 4);
            loginSeparator.TabIndex = 6;
            loginSeparator.TabStop = false;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = false;
            loginLabel.Dock = DockStyle.Top;
            loginLabel.Location = new Point(0, 70);
            loginLabel.Margin = new Padding(4, 5, 4, 5);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(315, 30);
            loginLabel.TabIndex = 61;
            loginLabel.Text = "Login:";
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
            nameTextBox.TabIndex = 8;
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
            nameLabel.TabIndex = 7;
            nameLabel.Text = "Nom:";
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(editPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "UserInfo";
            Size = new Size(315, 374);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)titleInfoLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)moduleCountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)defaultModuleTextBox).EndInit();
            defaultModuleTextBox.ResumeLayout(false);
            defaultModuleTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)defaultModuleSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)defaultModuleLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginTextBox).EndInit();
            loginTextBox.ResumeLayout(false);
            loginTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loginSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginLabel).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox defaultModuleTextBox;
        private Telerik.WinControls.UI.RadSeparator defaultModuleSeparator;
        private Telerik.WinControls.UI.RadLabel defaultModuleLabel;
        private Telerik.WinControls.UI.RadTextBox loginTextBox;
        private Telerik.WinControls.UI.RadSeparator loginSeparator;
        private Telerik.WinControls.UI.RadLabel loginLabel;
        private Telerik.WinControls.UI.RadLabel moduleCountLabel;
    }
}
