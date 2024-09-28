namespace SchoolManagement.UI
{
    partial class EditDisciplineSubjectForm
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
            sequenceSeparator = new Telerik.WinControls.UI.RadSeparator();
            sequenceSpinEditor = new Telerik.WinControls.UI.RadSpinEditor();
            sequenceLabel = new Telerik.WinControls.UI.RadLabel();
            nameEnSeparator = new Telerik.WinControls.UI.RadSeparator();
            nameFrSeparator = new Telerik.WinControls.UI.RadSeparator();
            nameEnTextBox = new Telerik.WinControls.UI.RadTextBox();
            nameEnLabel = new Telerik.WinControls.UI.RadLabel();
            nameFrTextBox = new Telerik.WinControls.UI.RadTextBox();
            nameFrLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameEnSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameFrSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameEnTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameEnLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameFrTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameFrLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(sequenceSeparator);
            editPanel.Controls.Add(sequenceSpinEditor);
            editPanel.Controls.Add(sequenceLabel);
            editPanel.Controls.Add(nameEnSeparator);
            editPanel.Controls.Add(nameFrSeparator);
            editPanel.Controls.Add(nameEnTextBox);
            editPanel.Controls.Add(nameEnLabel);
            editPanel.Controls.Add(nameFrTextBox);
            editPanel.Controls.Add(nameFrLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(820, 141);
            editPanel.TabIndex = 29;
            // 
            // sequenceSeparator
            // 
            sequenceSeparator.Location = new Point(2, 127);
            sequenceSeparator.Margin = new Padding(4, 5, 4, 5);
            sequenceSeparator.Name = "sequenceSeparator";
            sequenceSeparator.Size = new Size(135, 3);
            sequenceSeparator.TabIndex = 78;
            sequenceSeparator.TabStop = false;
            // 
            // sequenceSpinEditor
            // 
            sequenceSpinEditor.Location = new Point(2, 97);
            sequenceSpinEditor.MinimumSize = new Size(0, 30);
            sequenceSpinEditor.Name = "sequenceSpinEditor";
            // 
            // 
            // 
            sequenceSpinEditor.RootElement.MinSize = new Size(0, 30);
            sequenceSpinEditor.Size = new Size(135, 30);
            sequenceSpinEditor.TabIndex = 4;
            // 
            // sequenceLabel
            // 
            sequenceLabel.AutoSize = false;
            sequenceLabel.Location = new Point(2, 67);
            sequenceLabel.Margin = new Padding(4, 5, 4, 5);
            sequenceLabel.Name = "sequenceLabel";
            sequenceLabel.Size = new Size(135, 30);
            sequenceLabel.TabIndex = 77;
            sequenceLabel.Text = "Séquence:";
            // 
            // nameEnSeparator
            // 
            nameEnSeparator.Location = new Point(411, 60);
            nameEnSeparator.Margin = new Padding(4, 5, 4, 5);
            nameEnSeparator.Name = "nameEnSeparator";
            nameEnSeparator.Size = new Size(399, 3);
            nameEnSeparator.TabIndex = 74;
            nameEnSeparator.TabStop = false;
            // 
            // nameFrSeparator
            // 
            nameFrSeparator.Location = new Point(2, 60);
            nameFrSeparator.Margin = new Padding(4, 5, 4, 5);
            nameFrSeparator.Name = "nameFrSeparator";
            nameFrSeparator.Size = new Size(403, 3);
            nameFrSeparator.TabIndex = 72;
            nameFrSeparator.TabStop = false;
            // 
            // nameEnTextBox
            // 
            nameEnTextBox.AutoSize = false;
            nameEnTextBox.Location = new Point(411, 30);
            nameEnTextBox.Margin = new Padding(4, 5, 4, 5);
            nameEnTextBox.Name = "nameEnTextBox";
            nameEnTextBox.Size = new Size(399, 30);
            nameEnTextBox.TabIndex = 2;
            // 
            // nameEnLabel
            // 
            nameEnLabel.AutoSize = false;
            nameEnLabel.Location = new Point(411, 2);
            nameEnLabel.Margin = new Padding(4, 5, 4, 5);
            nameEnLabel.Name = "nameEnLabel";
            nameEnLabel.Size = new Size(403, 30);
            nameEnLabel.TabIndex = 7;
            nameEnLabel.Text = "Désignation Englaise:";
            // 
            // nameFrTextBox
            // 
            nameFrTextBox.AutoSize = false;
            nameFrTextBox.Location = new Point(2, 30);
            nameFrTextBox.Margin = new Padding(4, 5, 4, 5);
            nameFrTextBox.Name = "nameFrTextBox";
            nameFrTextBox.Size = new Size(403, 30);
            nameFrTextBox.TabIndex = 0;
            // 
            // nameFrLabel
            // 
            nameFrLabel.AutoSize = false;
            nameFrLabel.Location = new Point(2, 2);
            nameFrLabel.Margin = new Padding(4, 5, 4, 5);
            nameFrLabel.Name = "nameFrLabel";
            nameFrLabel.Size = new Size(403, 30);
            nameFrLabel.TabIndex = 5;
            nameFrLabel.Text = "Désignation:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(7, 150);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(557, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(692, 149);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 30);
            closeButton.TabIndex = 6;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(567, 149);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 30);
            saveButton.TabIndex = 5;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditDisciplineSubjectForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 190);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditDisciplineSubjectForm";
            Text = "EditEvaluationTypeForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameEnSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameFrSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameEnTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameEnLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameFrTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameFrLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSpinEditor sequenceSpinEditor;
        private Telerik.WinControls.UI.RadLabel sequenceLabel;
        private Telerik.WinControls.UI.RadSeparator nameEnSeparator;
        private Telerik.WinControls.UI.RadSeparator nameFrSeparator;
        private Telerik.WinControls.UI.RadTextBox nameEnTextBox;
        private Telerik.WinControls.UI.RadLabel nameEnLabel;
        private Telerik.WinControls.UI.RadTextBox nameFrTextBox;
        private Telerik.WinControls.UI.RadLabel nameFrLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadSeparator sequenceSeparator;
        private ErrorProvider errorProvider;
    }
}