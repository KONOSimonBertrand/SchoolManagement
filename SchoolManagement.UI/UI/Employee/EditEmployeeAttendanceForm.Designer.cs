namespace SchoolManagement.UI
{
    partial class EditEmployeeAttendanceForm
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
            saveButton = new Telerik.WinControls.UI.RadButton();
            closeButton = new Telerik.WinControls.UI.RadButton();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            editPanel = new Telerik.WinControls.UI.RadPanel();
            subjectDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            roomDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            subjectSeparator = new Telerik.WinControls.UI.RadSeparator();
            roomSeparator = new Telerik.WinControls.UI.RadSeparator();
            endLabel = new Telerik.WinControls.UI.RadLabel();
            startLabel = new Telerik.WinControls.UI.RadLabel();
            dateLabel = new Telerik.WinControls.UI.RadLabel();
            subjectLabel = new Telerik.WinControls.UI.RadLabel();
            roomLabel = new Telerik.WinControls.UI.RadLabel();
            endDateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            startDateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            descriptionSeparator = new Telerik.WinControls.UI.RadSeparator();
            descriptionTextBox = new Telerik.WinControls.UI.RadTextBox();
            dateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            subjectAddButton = new Telerik.WinControls.UI.RadButton();
            roomAddButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)subjectDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subjectSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subjectLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endDateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startDateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)descriptionSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)descriptionTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subjectAddButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomAddButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(306, 319);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(109, 28);
            saveButton.TabIndex = 7;
            saveButton.Text = "Enregistrer";
            // 
            // closeButton
            // 
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.Location = new Point(424, 319);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(101, 28);
            closeButton.TabIndex = 8;
            closeButton.Text = "Annuler";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(12, 355);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(513, 25);
            errorLabel.TabIndex = 114;
            // 
            // editPanel
            // 
            editPanel.Controls.Add(subjectDropDownList);
            editPanel.Controls.Add(roomDropDownList);
            editPanel.Controls.Add(subjectSeparator);
            editPanel.Controls.Add(roomSeparator);
            editPanel.Controls.Add(endLabel);
            editPanel.Controls.Add(startLabel);
            editPanel.Controls.Add(dateLabel);
            editPanel.Controls.Add(subjectLabel);
            editPanel.Controls.Add(roomLabel);
            editPanel.Controls.Add(endDateTimePicker);
            editPanel.Controls.Add(startDateTimePicker);
            editPanel.Controls.Add(descriptionSeparator);
            editPanel.Controls.Add(descriptionTextBox);
            editPanel.Controls.Add(dateTimePicker);
            editPanel.Controls.Add(subjectAddButton);
            editPanel.Controls.Add(roomAddButton);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(536, 310);
            editPanel.TabIndex = 115;
            // 
            // subjectDropDownList
            // 
            subjectDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            subjectDropDownList.DropDownAnimationEnabled = true;
            subjectDropDownList.DropDownHeight = 159;
            subjectDropDownList.Location = new Point(8, 100);
            subjectDropDownList.Margin = new Padding(4, 5, 4, 5);
            subjectDropDownList.Name = "subjectDropDownList";
            // 
            // 
            // 
            subjectDropDownList.RootElement.StretchVertically = true;
            subjectDropDownList.Size = new Size(489, 30);
            subjectDropDownList.TabIndex = 91;
            ((Telerik.WinControls.UI.RadDropDownListElement)subjectDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)subjectDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)subjectDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadTextBoxItem)subjectDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).StretchVertically = true;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)subjectDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)subjectDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)subjectDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // roomDropDownList
            // 
            roomDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            roomDropDownList.DropDownAnimationEnabled = true;
            roomDropDownList.DropDownHeight = 159;
            roomDropDownList.Location = new Point(4, 30);
            roomDropDownList.Margin = new Padding(4, 5, 4, 5);
            roomDropDownList.Name = "roomDropDownList";
            // 
            // 
            // 
            roomDropDownList.RootElement.StretchVertically = true;
            roomDropDownList.Size = new Size(489, 30);
            roomDropDownList.TabIndex = 91;
            ((Telerik.WinControls.UI.RadDropDownListElement)roomDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadTextBoxItem)roomDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).StretchVertically = true;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)roomDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)roomDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)roomDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // subjectSeparator
            // 
            subjectSeparator.Location = new Point(4, 130);
            subjectSeparator.Margin = new Padding(4, 5, 4, 5);
            subjectSeparator.Name = "subjectSeparator";
            subjectSeparator.Size = new Size(489, 4);
            subjectSeparator.TabIndex = 89;
            subjectSeparator.TabStop = false;
            // 
            // roomSeparator
            // 
            roomSeparator.Location = new Point(4, 60);
            roomSeparator.Margin = new Padding(4, 5, 4, 5);
            roomSeparator.Name = "roomSeparator";
            roomSeparator.Size = new Size(489, 4);
            roomSeparator.TabIndex = 89;
            roomSeparator.TabStop = false;
            // 
            // endLabel
            // 
            endLabel.AutoSize = false;
            endLabel.Location = new Point(321, 140);
            endLabel.Margin = new Padding(4, 5, 4, 5);
            endLabel.Name = "endLabel";
            endLabel.Size = new Size(107, 24);
            endLabel.TabIndex = 65;
            endLabel.Text = "Heure fin:";
            // 
            // startLabel
            // 
            startLabel.AutoSize = false;
            startLabel.Location = new Point(183, 140);
            startLabel.Margin = new Padding(4, 5, 4, 5);
            startLabel.Name = "startLabel";
            startLabel.Size = new Size(107, 24);
            startLabel.TabIndex = 65;
            startLabel.Text = "Heure débuts:";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = false;
            dateLabel.Location = new Point(8, 140);
            dateLabel.Margin = new Padding(4, 5, 4, 5);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(167, 24);
            dateLabel.TabIndex = 65;
            dateLabel.Text = "Date:";
            // 
            // subjectLabel
            // 
            subjectLabel.AutoSize = false;
            subjectLabel.Location = new Point(4, 70);
            subjectLabel.Margin = new Padding(4, 5, 4, 5);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(489, 24);
            subjectLabel.TabIndex = 65;
            subjectLabel.Text = "Matière:";
            // 
            // roomLabel
            // 
            roomLabel.AutoSize = false;
            roomLabel.Location = new Point(4, 0);
            roomLabel.Margin = new Padding(4, 5, 4, 5);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(489, 24);
            roomLabel.TabIndex = 65;
            roomLabel.Text = "Classe:";
            // 
            // endDateTimePicker
            // 
            endDateTimePicker.CalendarSize = new Size(290, 320);
            endDateTimePicker.Location = new Point(321, 170);
            endDateTimePicker.Name = "endDateTimePicker";
            endDateTimePicker.Size = new Size(107, 24);
            endDateTimePicker.TabIndex = 6;
            endDateTimePicker.TabStop = false;
            endDateTimePicker.Text = "mercredi 14 août 2024";
            endDateTimePicker.Value = new DateTime(2024, 8, 14, 12, 59, 8, 264);
            // 
            // startDateTimePicker
            // 
            startDateTimePicker.CalendarSize = new Size(290, 320);
            startDateTimePicker.Location = new Point(183, 170);
            startDateTimePicker.Name = "startDateTimePicker";
            startDateTimePicker.Size = new Size(107, 24);
            startDateTimePicker.TabIndex = 5;
            startDateTimePicker.TabStop = false;
            startDateTimePicker.Text = "mercredi 14 août 2024";
            startDateTimePicker.Value = new DateTime(2024, 8, 14, 12, 59, 8, 264);
            // 
            // descriptionSeparator
            // 
            descriptionSeparator.Location = new Point(12, 206);
            descriptionSeparator.Name = "descriptionSeparator";
            descriptionSeparator.Size = new Size(517, 4);
            descriptionSeparator.TabIndex = 20;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(8, 210);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            // 
            // 
            // 
            descriptionTextBox.RootElement.StretchVertically = true;
            descriptionTextBox.Size = new Size(517, 92);
            descriptionTextBox.TabIndex = 17;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarSize = new Size(290, 320);
            dateTimePicker.Location = new Point(8, 170);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(167, 24);
            dateTimePicker.TabIndex = 4;
            dateTimePicker.TabStop = false;
            dateTimePicker.Text = "mercredi 14 août 2024";
            dateTimePicker.Value = new DateTime(2024, 8, 14, 12, 59, 8, 264);
            // 
            // subjectAddButton
            // 
            subjectAddButton.Location = new Point(499, 100);
            subjectAddButton.Name = "subjectAddButton";
            subjectAddButton.Size = new Size(26, 30);
            subjectAddButton.TabIndex = 3;
            // 
            // roomAddButton
            // 
            roomAddButton.Location = new Point(499, 30);
            roomAddButton.Name = "roomAddButton";
            roomAddButton.Size = new Size(26, 30);
            roomAddButton.TabIndex = 1;
            // 
            // EditEmployeeAttendanceForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            CancelButton = closeButton;
            ClientSize = new Size(536, 381);
            Controls.Add(editPanel);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditEmployeeAttendanceForm";
            Text = "Attendance";
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)subjectDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)subjectSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)endLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)startLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)subjectLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)endDateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)startDateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)descriptionSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)descriptionTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)subjectAddButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomAddButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator descriptionSeparator;
        private Telerik.WinControls.UI.RadTextBox descriptionTextBox;
        private Telerik.WinControls.UI.RadDateTimePicker dateTimePicker;
        private Telerik.WinControls.UI.RadButton subjectAddButton;
        private Telerik.WinControls.UI.RadButton roomAddButton;
        private Telerik.WinControls.UI.RadLabel endLabel;
        private Telerik.WinControls.UI.RadLabel dateLabel;
        private Telerik.WinControls.UI.RadLabel startLabel;
        private Telerik.WinControls.UI.RadLabel subjectLabel;
        private Telerik.WinControls.UI.RadLabel roomLabel;
        private Telerik.WinControls.UI.RadDateTimePicker endDateTimePicker;
        private Telerik.WinControls.UI.RadDateTimePicker startDateTimePicker;
        private Telerik.WinControls.UI.RadSeparator roomSeparator;
        private Telerik.WinControls.UI.RadDropDownList roomDropDownList;
        private Telerik.WinControls.UI.RadDropDownList subjectDropDownList;
        private Telerik.WinControls.UI.RadSeparator subjectSeparator;
    }
}