namespace SchoolManagement.UI
{
    partial class EditUserPasswordForm
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
            editPanel = new Telerik.WinControls.UI.RadPanel();
            showPasswordToggleButton = new Telerik.WinControls.UI.RadToggleButton();
            oldPasswordSeparator = new Telerik.WinControls.UI.RadSeparator();
            newPasswordSeparator = new Telerik.WinControls.UI.RadSeparator();
            oldPasswordTextBox = new Telerik.WinControls.UI.RadTextBox();
            oldPasswordLabel = new Telerik.WinControls.UI.RadLabel();
            newPasswordTextBox = new Telerik.WinControls.UI.RadTextBox();
            newPasswordLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)showPasswordToggleButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(showPasswordToggleButton);
            editPanel.Controls.Add(oldPasswordSeparator);
            editPanel.Controls.Add(newPasswordSeparator);
            editPanel.Controls.Add(oldPasswordTextBox);
            editPanel.Controls.Add(oldPasswordLabel);
            editPanel.Controls.Add(newPasswordTextBox);
            editPanel.Controls.Add(newPasswordLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(8, 10, 8, 10);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(388, 142);
            editPanel.TabIndex = 79;
            // 
            // showPasswordToggleButton
            // 
            showPasswordToggleButton.Location = new Point(354, 97);
            showPasswordToggleButton.Name = "showPasswordToggleButton";
            showPasswordToggleButton.Size = new Size(22, 30);
            showPasswordToggleButton.TabIndex = 105;
            showPasswordToggleButton.Text = " ";
            // 
            // oldPasswordSeparator
            // 
            oldPasswordSeparator.Location = new Point(2, 61);
            oldPasswordSeparator.Margin = new Padding(10, 12, 10, 12);
            oldPasswordSeparator.Name = "oldPasswordSeparator";
            oldPasswordSeparator.Size = new Size(343, 4);
            oldPasswordSeparator.TabIndex = 104;
            oldPasswordSeparator.TabStop = false;
            // 
            // newPasswordSeparator
            // 
            newPasswordSeparator.Location = new Point(2, 128);
            newPasswordSeparator.Margin = new Padding(10, 12, 10, 12);
            newPasswordSeparator.Name = "newPasswordSeparator";
            newPasswordSeparator.Size = new Size(343, 4);
            newPasswordSeparator.TabIndex = 103;
            newPasswordSeparator.TabStop = false;
            // 
            // oldPasswordTextBox
            // 
            oldPasswordTextBox.AutoSize = false;
            oldPasswordTextBox.Location = new Point(2, 30);
            oldPasswordTextBox.Margin = new Padding(8, 10, 8, 10);
            oldPasswordTextBox.Name = "oldPasswordTextBox";
            oldPasswordTextBox.PasswordChar = '*';
            oldPasswordTextBox.Size = new Size(343, 30);
            oldPasswordTextBox.TabIndex = 0;
            // 
            // oldPasswordLabel
            // 
            oldPasswordLabel.AutoSize = false;
            oldPasswordLabel.Location = new Point(2, 0);
            oldPasswordLabel.Margin = new Padding(8, 10, 8, 10);
            oldPasswordLabel.Name = "oldPasswordLabel";
            oldPasswordLabel.Size = new Size(343, 30);
            oldPasswordLabel.TabIndex = 72;
            oldPasswordLabel.Text = "Ancien mot de passe:";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.AutoSize = false;
            newPasswordTextBox.Location = new Point(2, 97);
            newPasswordTextBox.Margin = new Padding(8, 10, 8, 10);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.Size = new Size(343, 30);
            newPasswordTextBox.TabIndex = 1;
            // 
            // newPasswordLabel
            // 
            newPasswordLabel.AutoSize = false;
            newPasswordLabel.Location = new Point(2, 67);
            newPasswordLabel.Margin = new Padding(8, 10, 8, 10);
            newPasswordLabel.Name = "newPasswordLabel";
            newPasswordLabel.Size = new Size(343, 30);
            newPasswordLabel.TabIndex = 70;
            newPasswordLabel.Text = "Nouveau mot de passe:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(2, 189);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(369, 30);
            errorLabel.TabIndex = 119;
            // 
            // closeButton
            // 
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.Location = new Point(235, 149);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 30);
            closeButton.TabIndex = 3;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(110, 149);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 30);
            saveButton.TabIndex = 2;
            saveButton.Text = "Enregistrer";
            // 
            // EditUserPasswordForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(388, 222);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditUserPasswordForm";
            Text = "EditUserPasswordForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)showPasswordToggleButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)oldPasswordLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)newPasswordLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator oldPasswordSeparator;
        private Telerik.WinControls.UI.RadSeparator newPasswordSeparator;
        private Telerik.WinControls.UI.RadTextBox oldPasswordTextBox;
        private Telerik.WinControls.UI.RadLabel oldPasswordLabel;
        private Telerik.WinControls.UI.RadTextBox newPasswordTextBox;
        private Telerik.WinControls.UI.RadLabel newPasswordLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadToggleButton showPasswordToggleButton;
    }
}