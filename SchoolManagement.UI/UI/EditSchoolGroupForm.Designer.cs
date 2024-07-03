namespace SchoolManagement.UI
{
    partial class EditSchoolGroupForm
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
            levelSeparator = new Telerik.WinControls.UI.RadSeparator();
            sequenceSpinEditor = new Telerik.WinControls.UI.RadSpinEditor();
            sequenceLabel = new Telerik.WinControls.UI.RadLabel();
            nameSeparator = new Telerik.WinControls.UI.RadSeparator();
            nameTextBox = new Telerik.WinControls.UI.RadTextBox();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)levelSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(levelSeparator);
            editPanel.Controls.Add(sequenceSpinEditor);
            editPanel.Controls.Add(sequenceLabel);
            editPanel.Controls.Add(nameSeparator);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(637, 68);
            editPanel.TabIndex = 27;
            // 
            // levelSeparator
            // 
            levelSeparator.Location = new Point(423, 61);
            levelSeparator.Margin = new Padding(4, 5, 4, 5);
            levelSeparator.Name = "levelSeparator";
            levelSeparator.Size = new Size(190, 4);
            levelSeparator.TabIndex = 98;
            levelSeparator.TabStop = false;
            // 
            // sequenceSpinEditor
            // 
            sequenceSpinEditor.Location = new Point(423, 30);
            sequenceSpinEditor.MinimumSize = new Size(0, 30);
            sequenceSpinEditor.Name = "sequenceSpinEditor";
            // 
            // 
            // 
            sequenceSpinEditor.RootElement.MinSize = new Size(0, 30);
            sequenceSpinEditor.Size = new Size(190, 30);
            sequenceSpinEditor.TabIndex = 97;
            // 
            // sequenceLabel
            // 
            sequenceLabel.AutoSize = false;
            sequenceLabel.Location = new Point(423, 0);
            sequenceLabel.Margin = new Padding(4, 5, 4, 5);
            sequenceLabel.Name = "sequenceLabel";
            sequenceLabel.Size = new Size(190, 30);
            sequenceLabel.TabIndex = 96;
            sequenceLabel.Text = "Séquence:";
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(3, 61);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(412, 4);
            nameSeparator.TabIndex = 95;
            nameSeparator.TabStop = false;
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = false;
            nameTextBox.Location = new Point(3, 30);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(412, 30);
            nameTextBox.TabIndex = 93;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = false;
            nameLabel.Location = new Point(3, 0);
            nameLabel.Margin = new Padding(4, 5, 4, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(412, 30);
            nameLabel.TabIndex = 94;
            nameLabel.Text = "Désignation:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(3, 110);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(610, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(495, 75);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 30);
            closeButton.TabIndex = 112;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(370, 75);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 30);
            saveButton.TabIndex = 111;
            saveButton.Text = "Enregistrer";
            // 
            // EditSchoolGroupForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 140);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            Name = "EditSchoolGroupForm";
            Text = "EditSchoolGroupForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)levelSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator levelSeparator;
        private Telerik.WinControls.UI.RadSpinEditor sequenceSpinEditor;
        private Telerik.WinControls.UI.RadLabel sequenceLabel;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
    }
}