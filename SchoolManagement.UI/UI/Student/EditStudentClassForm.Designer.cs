namespace SchoolManagement.UI
{
    partial class EditStudentClassForm
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
            roomSeparator = new Telerik.WinControls.UI.RadSeparator();
            roomDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            roomLabel = new Telerik.WinControls.UI.RadLabel();
            studentTextBox = new Telerik.WinControls.UI.RadTextBox();
            classSeparator = new Telerik.WinControls.UI.RadSeparator();
            classDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            classLabel = new Telerik.WinControls.UI.RadLabel();
            studentSeparator = new Telerik.WinControls.UI.RadSeparator();
            studentLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roomSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(roomSeparator);
            editPanel.Controls.Add(roomDropDownList);
            editPanel.Controls.Add(roomLabel);
            editPanel.Controls.Add(studentTextBox);
            editPanel.Controls.Add(classSeparator);
            editPanel.Controls.Add(classDropDownList);
            editPanel.Controls.Add(classLabel);
            editPanel.Controls.Add(studentSeparator);
            editPanel.Controls.Add(studentLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(563, 136);
            editPanel.TabIndex = 37;
            // 
            // roomSeparator
            // 
            roomSeparator.Location = new Point(266, 128);
            roomSeparator.Margin = new Padding(4, 5, 4, 5);
            roomSeparator.Name = "roomSeparator";
            roomSeparator.Size = new Size(251, 4);
            roomSeparator.TabIndex = 127;
            roomSeparator.TabStop = false;
            // 
            // roomDropDownList
            // 
            roomDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            roomDropDownList.DropDownAnimationEnabled = true;
            roomDropDownList.DropDownHeight = 159;
            roomDropDownList.Location = new Point(266, 97);
            roomDropDownList.Margin = new Padding(4, 5, 4, 5);
            roomDropDownList.MinimumSize = new Size(0, 30);
            roomDropDownList.Name = "roomDropDownList";
            roomDropDownList.Size = new Size(259, 35);
            roomDropDownList.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)roomDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)roomDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)roomDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // roomLabel
            // 
            roomLabel.AutoSize = false;
            roomLabel.Location = new Point(266, 67);
            roomLabel.Margin = new Padding(4, 5, 4, 5);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(251, 30);
            roomLabel.TabIndex = 125;
            roomLabel.Text = "Salle:";
            // 
            // studentTextBox
            // 
            studentTextBox.AutoSize = false;
            studentTextBox.Location = new Point(0, 30);
            studentTextBox.Margin = new Padding(4, 5, 4, 5);
            studentTextBox.Name = "studentTextBox";
            studentTextBox.ReadOnly = true;
            studentTextBox.Size = new Size(517, 36);
            studentTextBox.TabIndex = 0;
            // 
            // classSeparator
            // 
            classSeparator.Location = new Point(0, 128);
            classSeparator.Margin = new Padding(4, 5, 4, 5);
            classSeparator.Name = "classSeparator";
            classSeparator.Size = new Size(251, 4);
            classSeparator.TabIndex = 120;
            classSeparator.TabStop = false;
            // 
            // classDropDownList
            // 
            classDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            classDropDownList.DropDownAnimationEnabled = true;
            classDropDownList.DropDownHeight = 159;
            classDropDownList.Location = new Point(0, 97);
            classDropDownList.Margin = new Padding(4, 5, 4, 5);
            classDropDownList.MinimumSize = new Size(0, 30);
            classDropDownList.Name = "classDropDownList";
            classDropDownList.Size = new Size(259, 35);
            classDropDownList.TabIndex = 1;
            ((Telerik.WinControls.UI.RadDropDownListElement)classDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // classLabel
            // 
            classLabel.AutoSize = false;
            classLabel.Location = new Point(0, 67);
            classLabel.Margin = new Padding(4, 5, 4, 5);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(251, 30);
            classLabel.TabIndex = 119;
            classLabel.Text = "Classe:";
            // 
            // studentSeparator
            // 
            studentSeparator.Location = new Point(0, 61);
            studentSeparator.Margin = new Padding(4, 5, 4, 5);
            studentSeparator.Name = "studentSeparator";
            studentSeparator.Size = new Size(517, 4);
            studentSeparator.TabIndex = 117;
            studentSeparator.TabStop = false;
            // 
            // studentLabel
            // 
            studentLabel.AutoSize = false;
            studentLabel.Location = new Point(0, 0);
            studentLabel.Margin = new Padding(4, 5, 4, 5);
            studentLabel.Name = "studentLabel";
            studentLabel.Size = new Size(488, 30);
            studentLabel.TabIndex = 116;
            studentLabel.Text = "Elève:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 146);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(238, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.Location = new Point(371, 146);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 36);
            closeButton.TabIndex = 4;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(246, 146);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 36);
            saveButton.TabIndex = 3;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditStudentClassForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(563, 190);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditStudentClassForm";
            Text = "EditStudentClassForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roomSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox studentTextBox;
        private Telerik.WinControls.UI.RadSeparator classSeparator;
        private Telerik.WinControls.UI.RadDropDownList classDropDownList;
        private Telerik.WinControls.UI.RadLabel classLabel;
        private Telerik.WinControls.UI.RadSeparator studentSeparator;
        private Telerik.WinControls.UI.RadLabel studentLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadSeparator roomSeparator;
        private Telerik.WinControls.UI.RadDropDownList roomDropDownList;
        private Telerik.WinControls.UI.RadLabel roomLabel;
        private ErrorProvider errorProvider;
    }
}