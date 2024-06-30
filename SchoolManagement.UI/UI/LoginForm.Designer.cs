namespace SchoolManagement.UI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connectionButton = new Telerik.WinControls.UI.RadButton();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            materialPinkTheme1 = new Telerik.WinControls.Themes.MaterialPinkTheme();
            materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            pictureLogo = new PictureBox();
            editPanel = new Telerik.WinControls.UI.RadPanel();
            passwordTextBox = new Telerik.WinControls.UI.RadTextBox();
            passwordSeparator = new Telerik.WinControls.UI.RadSeparator();
            passwordLabel = new Telerik.WinControls.UI.RadLabel();
            userNameTextBox = new Telerik.WinControls.UI.RadTextBox();
            userNameSeparator = new Telerik.WinControls.UI.RadSeparator();
            loginLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)connectionButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)passwordTextBox).BeginInit();
            passwordTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)passwordSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userNameTextBox).BeginInit();
            userNameTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userNameSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // connectionButton
            // 
            connectionButton.Location = new Point(5, 288);
            connectionButton.Margin = new Padding(10);
            connectionButton.Name = "connectionButton";
            connectionButton.Size = new Size(118, 30);
            connectionButton.TabIndex = 2;
            connectionButton.Text = "Connexion";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(130, 288);
            errorLabel.Margin = new Padding(12, 15, 12, 15);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(188, 40);
            errorLabel.TabIndex = 66;
            // 
            // pictureLogo
            // 
            pictureLogo.Dock = DockStyle.Top;
            pictureLogo.InitialImage = null;
            pictureLogo.Location = new Point(0, 0);
            pictureLogo.Margin = new Padding(3, 2, 3, 2);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(312, 131);
            pictureLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLogo.TabIndex = 67;
            pictureLogo.TabStop = false;
            // 
            // editPanel
            // 
            editPanel.Controls.Add(passwordTextBox);
            editPanel.Controls.Add(passwordLabel);
            editPanel.Controls.Add(userNameTextBox);
            editPanel.Controls.Add(loginLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 131);
            editPanel.Margin = new Padding(12, 15, 12, 15);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(312, 154);
            editPanel.TabIndex = 68;
            // 
            // passwordTextBox
            // 
            passwordTextBox.AutoSize = false;
            passwordTextBox.Controls.Add(passwordSeparator);
            passwordTextBox.Dock = DockStyle.Top;
            passwordTextBox.Location = new Point(0, 100);
            passwordTextBox.Margin = new Padding(12, 15, 12, 15);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(312, 40);
            passwordTextBox.TabIndex = 1;
            // 
            // passwordSeparator
            // 
            passwordSeparator.Location = new Point(12, 33);
            passwordSeparator.Margin = new Padding(12, 15, 12, 15);
            passwordSeparator.Name = "passwordSeparator";
            passwordSeparator.Size = new Size(300, 2);
            passwordSeparator.TabIndex = 6;
            passwordSeparator.TabStop = false;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = false;
            passwordLabel.Dock = DockStyle.Top;
            passwordLabel.Location = new Point(0, 70);
            passwordLabel.Margin = new Padding(12, 15, 12, 15);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(312, 30);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Mot de passe:";
            // 
            // userNameTextBox
            // 
            userNameTextBox.AutoSize = false;
            userNameTextBox.Controls.Add(userNameSeparator);
            userNameTextBox.Dock = DockStyle.Top;
            userNameTextBox.Location = new Point(0, 30);
            userNameTextBox.Margin = new Padding(12, 15, 12, 15);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(312, 40);
            userNameTextBox.TabIndex = 0;
            // 
            // userNameSeparator
            // 
            userNameSeparator.Location = new Point(12, 33);
            userNameSeparator.Margin = new Padding(12, 15, 12, 15);
            userNameSeparator.Name = "userNameSeparator";
            userNameSeparator.Size = new Size(300, 2);
            userNameSeparator.TabIndex = 7;
            userNameSeparator.TabStop = false;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = false;
            loginLabel.Dock = DockStyle.Top;
            loginLabel.Location = new Point(0, 0);
            loginLabel.Margin = new Padding(12, 15, 12, 15);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(312, 30);
            loginLabel.TabIndex = 5;
            loginLabel.Text = "Nom utilisateur:";
            // 
            // LoginForm
            // 
            AcceptButton = connectionButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 319);
            Controls.Add(editPanel);
            Controls.Add(pictureLogo);
            Controls.Add(errorLabel);
            Controls.Add(connectionButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connexion";
            ((System.ComponentModel.ISupportInitialize)connectionButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)passwordTextBox).EndInit();
            passwordTextBox.ResumeLayout(false);
            passwordTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)passwordSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)userNameTextBox).EndInit();
            userNameTextBox.ResumeLayout(false);
            userNameTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userNameSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Telerik.WinControls.UI.RadButton connectionButton;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.MaterialPinkTheme materialPinkTheme1;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private System.Windows.Forms.PictureBox pictureLogo;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox userNameTextBox;
        private Telerik.WinControls.UI.RadLabel loginLabel;
        private Telerik.WinControls.UI.RadLabel passwordLabel;
        private Telerik.WinControls.UI.RadTextBox passwordTextBox;
        private Telerik.WinControls.UI.RadSeparator passwordSeparator;
        private Telerik.WinControls.UI.RadSeparator userNameSeparator;
    }
}
