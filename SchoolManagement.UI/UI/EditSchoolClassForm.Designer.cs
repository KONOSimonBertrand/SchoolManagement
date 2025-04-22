namespace SchoolManagement.UI
{
    partial class EditSchoolClassForm
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
            codeSeparator = new Telerik.WinControls.UI.RadSeparator();
            groupSeparator = new Telerik.WinControls.UI.RadSeparator();
            groupDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            addGroupButton = new Telerik.WinControls.UI.RadButton();
            nameTextBox = new Telerik.WinControls.UI.RadTextBox();
            groupLabel = new Telerik.WinControls.UI.RadLabel();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            sequenceLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            reportCardSeparator = new Telerik.WinControls.UI.RadSeparator();
            reportCardDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            reportCardLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)codeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addGroupButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportCardSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportCardDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportCardLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(sequenceSeparator);
            editPanel.Controls.Add(sequenceSpinEditor);
            editPanel.Controls.Add(codeSeparator);
            editPanel.Controls.Add(groupSeparator);
            editPanel.Controls.Add(groupDropDownList);
            editPanel.Controls.Add(addGroupButton);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(groupLabel);
            editPanel.Controls.Add(nameLabel);
            editPanel.Controls.Add(sequenceLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(752, 143);
            editPanel.TabIndex = 18;
            // 
            // sequenceSeparator
            // 
            sequenceSeparator.Location = new Point(356, 131);
            sequenceSeparator.Margin = new Padding(4, 5, 4, 5);
            sequenceSeparator.Name = "sequenceSeparator";
            sequenceSeparator.Size = new Size(109, 4);
            sequenceSeparator.TabIndex = 112;
            sequenceSeparator.TabStop = false;
            // 
            // sequenceSpinEditor
            // 
            sequenceSpinEditor.Location = new Point(356, 100);
            sequenceSpinEditor.MinimumSize = new Size(0, 30);
            sequenceSpinEditor.Name = "sequenceSpinEditor";
            sequenceSpinEditor.Size = new Size(109, 30);
            sequenceSpinEditor.TabIndex = 3;
            // 
            // codeSeparator
            // 
            codeSeparator.Location = new Point(4, 61);
            codeSeparator.Margin = new Padding(4, 5, 4, 5);
            codeSeparator.Name = "codeSeparator";
            codeSeparator.Size = new Size(345, 4);
            codeSeparator.TabIndex = 111;
            codeSeparator.TabStop = false;
            // 
            // groupSeparator
            // 
            groupSeparator.Location = new Point(356, 61);
            groupSeparator.Margin = new Padding(4, 5, 4, 5);
            groupSeparator.Name = "groupSeparator";
            groupSeparator.Size = new Size(328, 4);
            groupSeparator.TabIndex = 101;
            groupSeparator.TabStop = false;
            // 
            // groupDropDownList
            // 
            groupDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            groupDropDownList.DropDownHeight = 159;
            groupDropDownList.Location = new Point(356, 30);
            groupDropDownList.Margin = new Padding(4, 5, 4, 5);
            groupDropDownList.MinimumSize = new Size(0, 30);
            groupDropDownList.Name = "groupDropDownList";
            groupDropDownList.Size = new Size(328, 30);
            groupDropDownList.TabIndex = 1;
            ((Telerik.WinControls.UI.RadDropDownListElement)groupDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)groupDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)groupDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)groupDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)groupDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)groupDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // addGroupButton
            // 
            addGroupButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addGroupButton.Location = new Point(688, 30);
            addGroupButton.Margin = new Padding(4, 5, 4, 5);
            addGroupButton.Name = "addGroupButton";
            addGroupButton.Size = new Size(20, 30);
            addGroupButton.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = false;
            nameTextBox.Location = new Point(4, 30);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(345, 36);
            nameTextBox.TabIndex = 0;
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = false;
            groupLabel.Location = new Point(356, 0);
            groupLabel.Margin = new Padding(4, 5, 4, 5);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(292, 30);
            groupLabel.TabIndex = 90;
            groupLabel.Text = "Groupe:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = false;
            nameLabel.Location = new Point(4, 0);
            nameLabel.Margin = new Padding(4, 5, 4, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(345, 30);
            nameLabel.TabIndex = 89;
            nameLabel.Text = "Désignation:";
            // 
            // sequenceLabel
            // 
            sequenceLabel.AutoSize = false;
            sequenceLabel.Location = new Point(356, 69);
            sequenceLabel.Margin = new Padding(4, 5, 4, 5);
            sequenceLabel.Name = "sequenceLabel";
            sequenceLabel.Size = new Size(105, 30);
            sequenceLabel.TabIndex = 82;
            sequenceLabel.Text = "Séquence:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(6, 151);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(452, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(591, 150);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 36);
            closeButton.TabIndex = 5;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(466, 150);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 36);
            saveButton.TabIndex = 4;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // reportCardSeparator
            // 
            reportCardSeparator.Location = new Point(4, 133);
            reportCardSeparator.Margin = new Padding(4, 5, 4, 5);
            reportCardSeparator.Name = "reportCardSeparator";
            reportCardSeparator.Size = new Size(344, 4);
            reportCardSeparator.TabIndex = 126;
            reportCardSeparator.TabStop = false;
            // 
            // reportCardDropDownList
            // 
            reportCardDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            reportCardDropDownList.DropDownHeight = 159;
            reportCardDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            reportCardDropDownList.Location = new Point(4, 100);
            reportCardDropDownList.Margin = new Padding(4, 5, 4, 5);
            reportCardDropDownList.MinimumSize = new Size(0, 30);
            reportCardDropDownList.Name = "reportCardDropDownList";
            reportCardDropDownList.Size = new Size(344, 30);
            reportCardDropDownList.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)reportCardDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.BorderPrimitive)reportCardDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)reportCardDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)reportCardDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)reportCardDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)reportCardDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // reportCardLabel
            // 
            reportCardLabel.AutoSize = false;
            reportCardLabel.Location = new Point(4, 69);
            reportCardLabel.Margin = new Padding(4, 5, 4, 5);
            reportCardLabel.Name = "reportCardLabel";
            reportCardLabel.Size = new Size(344, 30);
            reportCardLabel.TabIndex = 125;
            reportCardLabel.Text = "Modèle de bulletin:";
            // 
            // EditSchoolClassForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 197);
            Controls.Add(reportCardSeparator);
            Controls.Add(reportCardDropDownList);
            Controls.Add(reportCardLabel);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditSchoolClassForm";
            Text = "EditSchoolClassForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).EndInit();
            ((System.ComponentModel.ISupportInitialize)codeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)addGroupButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportCardSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportCardDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportCardLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSpinEditor sequenceSpinEditor;
        private Telerik.WinControls.UI.RadSeparator codeSeparator;
        private Telerik.WinControls.UI.RadSeparator groupSeparator;
        private Telerik.WinControls.UI.RadDropDownList groupDropDownList;
        private Telerik.WinControls.UI.RadButton addGroupButton;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadLabel groupLabel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel sequenceLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadSeparator sequenceSeparator;
        private ErrorProvider errorProvider;
        private Telerik.WinControls.UI.RadSeparator reportCardSeparator;
        private Telerik.WinControls.UI.RadDropDownList reportCardDropDownList;
        private Telerik.WinControls.UI.RadLabel reportCardLabel;
    }
}