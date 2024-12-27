namespace SchoolManagement.UI
{
    partial class EditMedicalRecordForm
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
            studentSeparator = new Telerik.WinControls.UI.RadSeparator();
            dateSeparator = new Telerik.WinControls.UI.RadSeparator();
            healthSubjectSeparator = new Telerik.WinControls.UI.RadSeparator();
            descriptionSeparator = new Telerik.WinControls.UI.RadSeparator();
            descriptionTextBox = new Telerik.WinControls.UI.RadTextBox();
            descriptionLabel = new Telerik.WinControls.UI.RadLabel();
            healthSubjectDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            healthSubjectLabel = new Telerik.WinControls.UI.RadLabel();
            dateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            dateLabel = new Telerik.WinControls.UI.RadLabel();
            studentTextBox = new Telerik.WinControls.UI.RadTextBox();
            studentLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)descriptionSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)descriptionTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)descriptionLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentTextBox).BeginInit();
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
            editPanel.Controls.Add(studentSeparator);
            editPanel.Controls.Add(dateSeparator);
            editPanel.Controls.Add(healthSubjectSeparator);
            editPanel.Controls.Add(descriptionSeparator);
            editPanel.Controls.Add(descriptionTextBox);
            editPanel.Controls.Add(descriptionLabel);
            editPanel.Controls.Add(healthSubjectDropDownList);
            editPanel.Controls.Add(healthSubjectLabel);
            editPanel.Controls.Add(dateTimePicker);
            editPanel.Controls.Add(dateLabel);
            editPanel.Controls.Add(studentTextBox);
            editPanel.Controls.Add(studentLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(4, 5, 4, 5);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(508, 300);
            editPanel.TabIndex = 71;
            // 
            // studentSeparator
            // 
            studentSeparator.Location = new Point(0, 60);
            studentSeparator.Margin = new Padding(4, 5, 4, 5);
            studentSeparator.Name = "studentSeparator";
            studentSeparator.Size = new Size(500, 4);
            studentSeparator.TabIndex = 104;
            studentSeparator.TabStop = false;
            // 
            // dateSeparator
            // 
            dateSeparator.Location = new Point(0, 127);
            dateSeparator.Margin = new Padding(4, 5, 4, 5);
            dateSeparator.Name = "dateSeparator";
            dateSeparator.Size = new Size(171, 4);
            dateSeparator.TabIndex = 103;
            dateSeparator.TabStop = false;
            // 
            // healthSubjectSeparator
            // 
            healthSubjectSeparator.Location = new Point(179, 127);
            healthSubjectSeparator.Margin = new Padding(4, 5, 4, 5);
            healthSubjectSeparator.Name = "healthSubjectSeparator";
            healthSubjectSeparator.Size = new Size(321, 4);
            healthSubjectSeparator.TabIndex = 102;
            healthSubjectSeparator.TabStop = false;
            // 
            // descriptionSeparator
            // 
            descriptionSeparator.Location = new Point(0, 290);
            descriptionSeparator.Margin = new Padding(4, 5, 4, 5);
            descriptionSeparator.Name = "descriptionSeparator";
            descriptionSeparator.Size = new Size(500, 4);
            descriptionSeparator.TabIndex = 101;
            descriptionSeparator.TabStop = false;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.AcceptsReturn = true;
            descriptionTextBox.AutoSize = false;
            descriptionTextBox.Location = new Point(0, 164);
            descriptionTextBox.Margin = new Padding(4, 5, 4, 5);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(500, 125);
            descriptionTextBox.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = false;
            descriptionLabel.Location = new Point(0, 134);
            descriptionLabel.Margin = new Padding(4, 5, 4, 5);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(500, 30);
            descriptionLabel.TabIndex = 100;
            descriptionLabel.Text = "Description:";
            // 
            // healthSubjectDropDownList
            // 
            healthSubjectDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            healthSubjectDropDownList.DropDownAnimationEnabled = true;
            healthSubjectDropDownList.DropDownHeight = 159;
            healthSubjectDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            healthSubjectDropDownList.Location = new Point(179, 97);
            healthSubjectDropDownList.Margin = new Padding(4, 5, 4, 5);
            healthSubjectDropDownList.MinimumSize = new Size(0, 30);
            healthSubjectDropDownList.Name = "healthSubjectDropDownList";
            healthSubjectDropDownList.Size = new Size(321, 35);
            healthSubjectDropDownList.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)healthSubjectDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.BorderPrimitive)healthSubjectDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)healthSubjectDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)healthSubjectDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)healthSubjectDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)healthSubjectDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // healthSubjectLabel
            // 
            healthSubjectLabel.AutoSize = false;
            healthSubjectLabel.Location = new Point(179, 67);
            healthSubjectLabel.Margin = new Padding(4, 5, 4, 5);
            healthSubjectLabel.Name = "healthSubjectLabel";
            healthSubjectLabel.Size = new Size(321, 30);
            healthSubjectLabel.TabIndex = 97;
            healthSubjectLabel.Text = "Elément médical:";
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarSize = new Size(290, 320);
            dateTimePicker.Location = new Point(0, 97);
            dateTimePicker.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker.MinimumSize = new Size(0, 30);
            dateTimePicker.Name = "dateTimePicker";
            // 
            // 
            // 
            dateTimePicker.RootElement.MinSize = new Size(0, 30);
            dateTimePicker.Size = new Size(171, 36);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.TabStop = false;
            dateTimePicker.Text = "lundi 29 janvier 2018";
            dateTimePicker.Value = new DateTime(2018, 1, 29, 16, 2, 10, 371);
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = false;
            dateLabel.Location = new Point(0, 67);
            dateLabel.Margin = new Padding(4, 5, 4, 5);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(158, 30);
            dateLabel.TabIndex = 9;
            dateLabel.Text = "Date:";
            // 
            // studentTextBox
            // 
            studentTextBox.AutoSize = false;
            studentTextBox.Location = new Point(0, 30);
            studentTextBox.Margin = new Padding(4, 5, 4, 5);
            studentTextBox.Name = "studentTextBox";
            studentTextBox.ReadOnly = true;
            studentTextBox.Size = new Size(500, 36);
            studentTextBox.TabIndex = 0;
            // 
            // studentLabel
            // 
            studentLabel.AutoSize = false;
            studentLabel.Location = new Point(0, 0);
            studentLabel.Margin = new Padding(4, 5, 4, 5);
            studentLabel.Name = "studentLabel";
            studentLabel.Size = new Size(500, 30);
            studentLabel.TabIndex = 7;
            studentLabel.Text = "Elève:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 310);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(254, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(387, 310);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 36);
            closeButton.TabIndex = 112;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(262, 310);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 36);
            saveButton.TabIndex = 111;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditMedicalRecordForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 350);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditMedicalRecordForm";
            Text = "Information ";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)studentSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)descriptionSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)descriptionTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)descriptionLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)healthSubjectLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentTextBox).EndInit();
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
        private Telerik.WinControls.UI.RadSeparator studentSeparator;
        private Telerik.WinControls.UI.RadSeparator dateSeparator;
        private Telerik.WinControls.UI.RadSeparator healthSubjectSeparator;
        private Telerik.WinControls.UI.RadSeparator descriptionSeparator;
        private Telerik.WinControls.UI.RadTextBox descriptionTextBox;
        private Telerik.WinControls.UI.RadLabel descriptionLabel;
        private Telerik.WinControls.UI.RadDropDownList healthSubjectDropDownList;
        private Telerik.WinControls.UI.RadLabel healthSubjectLabel;
        private Telerik.WinControls.UI.RadDateTimePicker dateTimePicker;
        private Telerik.WinControls.UI.RadLabel dateLabel;
        private Telerik.WinControls.UI.RadTextBox studentTextBox;
        private Telerik.WinControls.UI.RadLabel studentLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private ErrorProvider errorProvider;
    }
}