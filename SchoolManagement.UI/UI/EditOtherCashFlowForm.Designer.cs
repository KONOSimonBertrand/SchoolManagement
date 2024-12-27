namespace SchoolManagement.UI
{
    partial class EditOtherCashFlowForm
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
            cashFlowTypeSeparator = new Telerik.WinControls.UI.RadSeparator();
            cashFlowTypeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            cashFlowTypeLabel = new Telerik.WinControls.UI.RadLabel();
            amountSeparator = new Telerik.WinControls.UI.RadSeparator();
            doneBySeparator = new Telerik.WinControls.UI.RadSeparator();
            noteSeparator = new Telerik.WinControls.UI.RadSeparator();
            noteLabel = new Telerik.WinControls.UI.RadLabel();
            doneByLabel = new Telerik.WinControls.UI.RadLabel();
            amountLabel = new Telerik.WinControls.UI.RadLabel();
            dateSeparator = new Telerik.WinControls.UI.RadSeparator();
            dateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            dateLabel = new Telerik.WinControls.UI.RadLabel();
            noteTextBox = new Telerik.WinControls.UI.RadTextBox();
            doneByTextBox = new Telerik.WinControls.UI.RadTextBox();
            amountTextBox = new Telerik.WinControls.UI.RadTextBox();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doneBySeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doneByLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noteTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doneByTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(cashFlowTypeSeparator);
            editPanel.Controls.Add(cashFlowTypeDropDownList);
            editPanel.Controls.Add(cashFlowTypeLabel);
            editPanel.Controls.Add(amountSeparator);
            editPanel.Controls.Add(doneBySeparator);
            editPanel.Controls.Add(noteSeparator);
            editPanel.Controls.Add(noteLabel);
            editPanel.Controls.Add(doneByLabel);
            editPanel.Controls.Add(amountLabel);
            editPanel.Controls.Add(dateSeparator);
            editPanel.Controls.Add(dateTimePicker);
            editPanel.Controls.Add(dateLabel);
            editPanel.Controls.Add(noteTextBox);
            editPanel.Controls.Add(doneByTextBox);
            editPanel.Controls.Add(amountTextBox);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(806, 246);
            editPanel.TabIndex = 129;
            // 
            // cashFlowTypeSeparator
            // 
            cashFlowTypeSeparator.Location = new Point(305, 60);
            cashFlowTypeSeparator.Margin = new Padding(4, 5, 4, 5);
            cashFlowTypeSeparator.Name = "cashFlowTypeSeparator";
            cashFlowTypeSeparator.Size = new Size(481, 4);
            cashFlowTypeSeparator.TabIndex = 144;
            cashFlowTypeSeparator.TabStop = false;
            // 
            // cashFlowTypeDropDownList
            // 
            cashFlowTypeDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cashFlowTypeDropDownList.DropDownAnimationEnabled = true;
            cashFlowTypeDropDownList.DropDownHeight = 159;
            cashFlowTypeDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            cashFlowTypeDropDownList.Location = new Point(305, 30);
            cashFlowTypeDropDownList.Margin = new Padding(4, 5, 4, 5);
            cashFlowTypeDropDownList.MinimumSize = new Size(0, 30);
            cashFlowTypeDropDownList.Name = "cashFlowTypeDropDownList";
            cashFlowTypeDropDownList.Size = new Size(481, 35);
            cashFlowTypeDropDownList.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)cashFlowTypeDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.BorderPrimitive)cashFlowTypeDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)cashFlowTypeDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)cashFlowTypeDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)cashFlowTypeDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)cashFlowTypeDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cashFlowTypeLabel
            // 
            cashFlowTypeLabel.AutoSize = false;
            cashFlowTypeLabel.Location = new Point(305, 0);
            cashFlowTypeLabel.Margin = new Padding(4, 5, 4, 5);
            cashFlowTypeLabel.Name = "cashFlowTypeLabel";
            cashFlowTypeLabel.Size = new Size(481, 30);
            cashFlowTypeLabel.TabIndex = 143;
            cashFlowTypeLabel.Text = "Motif:";
            // 
            // amountSeparator
            // 
            amountSeparator.Location = new Point(155, 60);
            amountSeparator.Margin = new Padding(4, 5, 4, 5);
            amountSeparator.Name = "amountSeparator";
            amountSeparator.Size = new Size(144, 4);
            amountSeparator.TabIndex = 141;
            amountSeparator.TabStop = false;
            // 
            // doneBySeparator
            // 
            doneBySeparator.Location = new Point(4, 128);
            doneBySeparator.Margin = new Padding(4, 5, 4, 5);
            doneBySeparator.Name = "doneBySeparator";
            doneBySeparator.Size = new Size(639, 4);
            doneBySeparator.TabIndex = 140;
            doneBySeparator.TabStop = false;
            // 
            // noteSeparator
            // 
            noteSeparator.Location = new Point(4, 227);
            noteSeparator.Margin = new Padding(4, 5, 4, 5);
            noteSeparator.Name = "noteSeparator";
            noteSeparator.Size = new Size(639, 4);
            noteSeparator.TabIndex = 132;
            noteSeparator.TabStop = false;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = false;
            noteLabel.Location = new Point(4, 137);
            noteLabel.Margin = new Padding(4, 5, 4, 5);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(639, 30);
            noteLabel.TabIndex = 131;
            noteLabel.Text = "Note:";
            // 
            // doneByLabel
            // 
            doneByLabel.AutoSize = false;
            doneByLabel.Location = new Point(4, 68);
            doneByLabel.Margin = new Padding(4, 5, 4, 5);
            doneByLabel.Name = "doneByLabel";
            doneByLabel.Size = new Size(639, 30);
            doneByLabel.TabIndex = 131;
            doneByLabel.Text = "Ordonnateur:";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = false;
            amountLabel.Location = new Point(155, 0);
            amountLabel.Margin = new Padding(4, 5, 4, 5);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(144, 30);
            amountLabel.TabIndex = 138;
            amountLabel.Text = "Montant:";
            // 
            // dateSeparator
            // 
            dateSeparator.Location = new Point(4, 60);
            dateSeparator.Margin = new Padding(4, 5, 4, 5);
            dateSeparator.Name = "dateSeparator";
            dateSeparator.Size = new Size(145, 4);
            dateSeparator.TabIndex = 135;
            dateSeparator.TabStop = false;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarSize = new Size(290, 320);
            dateTimePicker.Location = new Point(4, 30);
            dateTimePicker.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker.MinimumSize = new Size(0, 30);
            dateTimePicker.Name = "dateTimePicker";
            // 
            // 
            // 
            dateTimePicker.RootElement.MinSize = new Size(0, 30);
            dateTimePicker.Size = new Size(145, 36);
            dateTimePicker.TabIndex = 0;
            dateTimePicker.TabStop = false;
            dateTimePicker.Text = "lundi 29 janvier 2018";
            dateTimePicker.Value = new DateTime(2018, 1, 29, 16, 2, 10, 371);
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = false;
            dateLabel.Location = new Point(4, 0);
            dateLabel.Margin = new Padding(4, 5, 4, 5);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(145, 30);
            dateLabel.TabIndex = 134;
            dateLabel.Text = "Date:";
            // 
            // noteTextBox
            // 
            noteTextBox.AutoSize = false;
            noteTextBox.Location = new Point(4, 167);
            noteTextBox.Margin = new Padding(4, 5, 4, 5);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(639, 59);
            noteTextBox.TabIndex = 4;
            // 
            // doneByTextBox
            // 
            doneByTextBox.AutoSize = false;
            doneByTextBox.Location = new Point(4, 98);
            doneByTextBox.Margin = new Padding(4, 5, 4, 5);
            doneByTextBox.Name = "doneByTextBox";
            doneByTextBox.Size = new Size(639, 36);
            doneByTextBox.TabIndex = 3;
            // 
            // amountTextBox
            // 
            amountTextBox.AutoSize = false;
            amountTextBox.Location = new Point(155, 30);
            amountTextBox.Margin = new Padding(4, 5, 4, 5);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(144, 36);
            amountTextBox.TabIndex = 1;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(4, 254);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(527, 30);
            errorLabel.TabIndex = 132;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(674, 254);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 36);
            closeButton.TabIndex = 6;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(549, 254);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 36);
            saveButton.TabIndex = 5;
            saveButton.Text = "Enregistrer";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditOtherCashFlowForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 340);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditOtherCashFlowForm";
            Text = "Cash Flow";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)cashFlowTypeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)doneBySeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)doneByLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)noteTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)doneByTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator amountSeparator;
        private Telerik.WinControls.UI.RadSeparator doneBySeparator;
        private Telerik.WinControls.UI.RadSeparator noteSeparator;
        private Telerik.WinControls.UI.RadLabel doneByLabel;
        private Telerik.WinControls.UI.RadLabel amountLabel;
        private Telerik.WinControls.UI.RadSeparator dateSeparator;
        private Telerik.WinControls.UI.RadDateTimePicker dateTimePicker;
        private Telerik.WinControls.UI.RadLabel dateLabel;
        private Telerik.WinControls.UI.RadTextBox doneByTextBox;
        private Telerik.WinControls.UI.RadTextBox amountTextBox;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadLabel noteLabel;
        private Telerik.WinControls.UI.RadTextBox noteTextBox;
        private ErrorProvider errorProvider;
        private Telerik.WinControls.UI.RadSeparator cashFlowTypeSeparator;
        private Telerik.WinControls.UI.RadDropDownList cashFlowTypeDropDownList;
        private Telerik.WinControls.UI.RadLabel cashFlowTypeLabel;
    }
}