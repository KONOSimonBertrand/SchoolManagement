namespace SchoolManagement.UI
{
    partial class EditSchoolRoomForm
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
            sequenceSeparator = new Telerik.WinControls.UI.RadSeparator();
            sequenceSpinEditor = new Telerik.WinControls.UI.RadSpinEditor();
            sequenceLabel = new Telerik.WinControls.UI.RadLabel();
            addClassButton = new Telerik.WinControls.UI.RadButton();
            classSeparator = new Telerik.WinControls.UI.RadSeparator();
            classDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            nameSeparator = new Telerik.WinControls.UI.RadSeparator();
            classLabel = new Telerik.WinControls.UI.RadLabel();
            nameTextBox = new Telerik.WinControls.UI.RadTextBox();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addClassButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).BeginInit();
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
            editPanel.Controls.Add(sequenceSeparator);
            editPanel.Controls.Add(sequenceSpinEditor);
            editPanel.Controls.Add(sequenceLabel);
            editPanel.Controls.Add(addClassButton);
            editPanel.Controls.Add(classSeparator);
            editPanel.Controls.Add(classDropDownList);
            editPanel.Controls.Add(nameSeparator);
            editPanel.Controls.Add(classLabel);
            editPanel.Controls.Add(nameTextBox);
            editPanel.Controls.Add(nameLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(739, 140);
            editPanel.TabIndex = 19;
            // 
            // sequenceSeparator
            // 
            sequenceSeparator.Location = new Point(0, 128);
            sequenceSeparator.Margin = new Padding(4, 5, 4, 5);
            sequenceSeparator.Name = "sequenceSeparator";
            sequenceSeparator.Size = new Size(345, 4);
            sequenceSeparator.TabIndex = 115;
            sequenceSeparator.TabStop = false;
            // 
            // sequenceSpinEditor
            // 
            sequenceSpinEditor.Location = new Point(0, 97);
            sequenceSpinEditor.MinimumSize = new Size(0, 30);
            sequenceSpinEditor.Name = "sequenceSpinEditor";
            // 
            // 
            // 
            sequenceSpinEditor.RootElement.MinSize = new Size(0, 30);
            sequenceSpinEditor.Size = new Size(345, 30);
            sequenceSpinEditor.TabIndex = 114;
            // 
            // sequenceLabel
            // 
            sequenceLabel.AutoSize = false;
            sequenceLabel.Location = new Point(0, 67);
            sequenceLabel.Margin = new Padding(4, 5, 4, 5);
            sequenceLabel.Name = "sequenceLabel";
            sequenceLabel.Size = new Size(345, 30);
            sequenceLabel.TabIndex = 83;
            sequenceLabel.Text = "Séquence:";
            // 
            // addClassButton
            // 
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.Location = new Point(711, 30);
            addClassButton.Margin = new Padding(4, 5, 4, 5);
            addClassButton.Name = "addClassButton";
            addClassButton.Size = new Size(20, 30);
            addClassButton.TabIndex = 70;
            // 
            // classSeparator
            // 
            classSeparator.Location = new Point(351, 61);
            classSeparator.Margin = new Padding(4, 5, 4, 5);
            classSeparator.Name = "classSeparator";
            classSeparator.Size = new Size(340, 6);
            classSeparator.TabIndex = 69;
            classSeparator.TabStop = false;
            // 
            // classDropDownList
            // 
            classDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            classDropDownList.DropDownAnimationEnabled = true;
            classDropDownList.DropDownHeight = 159;
            classDropDownList.Location = new Point(351, 30);
            classDropDownList.Margin = new Padding(4, 5, 4, 5);
            classDropDownList.MinimumSize = new Size(0, 30);
            classDropDownList.Name = "classDropDownList";
            classDropDownList.Size = new Size(358, 30);
            classDropDownList.TabIndex = 68;
            ((Telerik.WinControls.UI.RadDropDownListElement)classDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // nameSeparator
            // 
            nameSeparator.Location = new Point(0, 61);
            nameSeparator.Margin = new Padding(4, 5, 4, 5);
            nameSeparator.Name = "nameSeparator";
            nameSeparator.Size = new Size(345, 4);
            nameSeparator.TabIndex = 67;
            nameSeparator.TabStop = false;
            // 
            // classLabel
            // 
            classLabel.AutoSize = false;
            classLabel.Location = new Point(358, 0);
            classLabel.Margin = new Padding(4, 5, 4, 5);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(345, 30);
            classLabel.TabIndex = 64;
            classLabel.Text = "Classe:";
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = false;
            nameTextBox.Location = new Point(0, 30);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(345, 30);
            nameTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = false;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Margin = new Padding(4, 5, 4, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(345, 30);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Désignation:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 190);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(731, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(586, 150);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 30);
            closeButton.TabIndex = 112;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(461, 150);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 30);
            saveButton.TabIndex = 111;
            saveButton.Text = "Enregistrer";
            // 
            // EditSchoolRoomForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 227);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            Name = "EditSchoolRoomForm";
            Text = "EditSchoolRoomForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sequenceSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceSpinEditor).EndInit();
            ((System.ComponentModel.ISupportInitialize)sequenceLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)addClassButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).EndInit();
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
        private Telerik.WinControls.UI.RadButton addClassButton;
        private Telerik.WinControls.UI.RadSeparator classSeparator;
        private Telerik.WinControls.UI.RadDropDownList classDropDownList;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadLabel classLabel;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadLabel sequenceLabel;
        private Telerik.WinControls.UI.RadSeparator sequenceSeparator;
        private Telerik.WinControls.UI.RadSpinEditor sequenceSpinEditor;
    }
}