namespace SchoolManagement.UI
{
    partial class EditSerialKeyForm
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
            components = new System.ComponentModel.Container();
            editPanel = new Telerik.WinControls.UI.RadPanel();
            serialKeyUserLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeySeparator = new Telerik.WinControls.UI.RadSeparator();
            serialKeyTextBox = new Telerik.WinControls.UI.RadTextBox();
            serialKeyLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            serialKeyTypeLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyDurationLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeySeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(serialKeyDurationLabel);
            editPanel.Controls.Add(serialKeyTypeLabel);
            editPanel.Controls.Add(serialKeyUserLabel);
            editPanel.Controls.Add(serialKeySeparator);
            editPanel.Controls.Add(serialKeyTextBox);
            editPanel.Controls.Add(serialKeyLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(655, 202);
            editPanel.TabIndex = 114;
            // 
            // serialKeyUserLabel
            // 
            serialKeyUserLabel.AutoSize = false;
            serialKeyUserLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyUserLabel.Location = new Point(9, 96);
            serialKeyUserLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyUserLabel.Name = "serialKeyUserLabel";
            serialKeyUserLabel.Size = new Size(636, 30);
            serialKeyUserLabel.TabIndex = 11;
            serialKeyUserLabel.Text = "Utilisateur:";
            // 
            // serialKeySeparator
            // 
            serialKeySeparator.Location = new Point(4, 87);
            serialKeySeparator.Margin = new Padding(4, 5, 4, 5);
            serialKeySeparator.Name = "serialKeySeparator";
            serialKeySeparator.Size = new Size(636, 4);
            serialKeySeparator.TabIndex = 10;
            serialKeySeparator.TabStop = false;
            // 
            // serialKeyTextBox
            // 
            serialKeyTextBox.AutoSize = false;
            serialKeyTextBox.Location = new Point(4, 35);
            serialKeyTextBox.Margin = new Padding(4, 5, 4, 5);
            serialKeyTextBox.Multiline = true;
            serialKeyTextBox.Name = "serialKeyTextBox";
            serialKeyTextBox.Size = new Size(636, 51);
            serialKeyTextBox.TabIndex = 9;
            // 
            // serialKeyLabel
            // 
            serialKeyLabel.AutoSize = false;
            serialKeyLabel.Location = new Point(4, 5);
            serialKeyLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyLabel.Name = "serialKeyLabel";
            serialKeyLabel.Size = new Size(636, 30);
            serialKeyLabel.TabIndex = 8;
            serialKeyLabel.Text = "Code Client:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 214);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(390, 30);
            errorLabel.TabIndex = 117;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(523, 214);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 30);
            closeButton.TabIndex = 116;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(398, 214);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 30);
            saveButton.TabIndex = 115;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // serialKeyTypeLabel
            // 
            serialKeyTypeLabel.AutoSize = false;
            serialKeyTypeLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyTypeLabel.Location = new Point(9, 128);
            serialKeyTypeLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyTypeLabel.Name = "serialKeyTypeLabel";
            serialKeyTypeLabel.Size = new Size(636, 30);
            serialKeyTypeLabel.TabIndex = 12;
            serialKeyTypeLabel.Text = "Type de licence:";
            // 
            // serialKeyDurationLabel
            // 
            serialKeyDurationLabel.AutoSize = false;
            serialKeyDurationLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            serialKeyDurationLabel.Location = new Point(9, 162);
            serialKeyDurationLabel.Margin = new Padding(4, 5, 4, 5);
            serialKeyDurationLabel.Name = "serialKeyDurationLabel";
            serialKeyDurationLabel.Size = new Size(636, 30);
            serialKeyDurationLabel.TabIndex = 13;
            serialKeyDurationLabel.Text = "Date d'expiration:";
            // 
            // EditSerialKeyForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 251);
            Controls.Add(editPanel);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            MaximizeBox = false;
            Name = "EditSerialKeyForm";
            Text = "Serial Key";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeySeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadSeparator serialKeySeparator;
        private Telerik.WinControls.UI.RadTextBox serialKeyTextBox;
        private Telerik.WinControls.UI.RadLabel serialKeyLabel;
        private ErrorProvider errorProvider;
        private Telerik.WinControls.UI.RadLabel serialKeyUserLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyDurationLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyTypeLabel;
    }
}