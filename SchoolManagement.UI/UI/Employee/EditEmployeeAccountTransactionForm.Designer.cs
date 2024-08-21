namespace SchoolManagement.UI
{
    partial class EditEmployeeAccountTransactionForm
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
            dateSeparator = new Telerik.WinControls.UI.RadSeparator();
            transactionDateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            reasonSeparator = new Telerik.WinControls.UI.RadSeparator();
            amountSeparator = new Telerik.WinControls.UI.RadSeparator();
            reasonTextBox = new Telerik.WinControls.UI.RadTextBox();
            reasonLabel = new Telerik.WinControls.UI.RadLabel();
            amountTextBox = new Telerik.WinControls.UI.RadTextBox();
            amountLabel = new Telerik.WinControls.UI.RadLabel();
            dateLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionDateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reasonSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reasonTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reasonLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(dateSeparator);
            editPanel.Controls.Add(transactionDateTimePicker);
            editPanel.Controls.Add(reasonSeparator);
            editPanel.Controls.Add(amountSeparator);
            editPanel.Controls.Add(reasonTextBox);
            editPanel.Controls.Add(reasonLabel);
            editPanel.Controls.Add(amountTextBox);
            editPanel.Controls.Add(amountLabel);
            editPanel.Controls.Add(dateLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Margin = new Padding(5, 6, 5, 6);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(477, 151);
            editPanel.TabIndex = 60;
            // 
            // dateSeparator
            // 
            dateSeparator.Location = new Point(10, 66);
            dateSeparator.Margin = new Padding(5, 6, 5, 6);
            dateSeparator.Name = "dateSeparator";
            dateSeparator.Size = new Size(208, 4);
            dateSeparator.TabIndex = 113;
            dateSeparator.TabStop = false;
            // 
            // transactionDateTimePicker
            // 
            transactionDateTimePicker.AutoSize = false;
            transactionDateTimePicker.CalendarSize = new Size(290, 320);
            transactionDateTimePicker.Location = new Point(10, 35);
            transactionDateTimePicker.Margin = new Padding(5, 6, 5, 6);
            transactionDateTimePicker.Name = "transactionDateTimePicker";
            // 
            // 
            // 
            transactionDateTimePicker.RootElement.MinSize = new Size(0, 0);
            transactionDateTimePicker.Size = new Size(208, 30);
            transactionDateTimePicker.TabIndex = 120;
            transactionDateTimePicker.TabStop = false;
            transactionDateTimePicker.Text = "lundi 29 janvier 2018";
            transactionDateTimePicker.Value = new DateTime(2018, 1, 29, 16, 2, 10, 371);
            // 
            // reasonSeparator
            // 
            reasonSeparator.Location = new Point(10, 134);
            reasonSeparator.Margin = new Padding(5, 6, 5, 6);
            reasonSeparator.Name = "reasonSeparator";
            reasonSeparator.Size = new Size(458, 4);
            reasonSeparator.TabIndex = 119;
            reasonSeparator.TabStop = false;
            // 
            // amountSeparator
            // 
            amountSeparator.Location = new Point(225, 66);
            amountSeparator.Margin = new Padding(5, 6, 5, 6);
            amountSeparator.Name = "amountSeparator";
            amountSeparator.Size = new Size(243, 4);
            amountSeparator.TabIndex = 118;
            amountSeparator.TabStop = false;
            // 
            // reasonTextBox
            // 
            reasonTextBox.AutoSize = false;
            reasonTextBox.Location = new Point(10, 103);
            reasonTextBox.Margin = new Padding(5, 6, 5, 6);
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.Size = new Size(458, 30);
            reasonTextBox.TabIndex = 3;
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = false;
            reasonLabel.Location = new Point(10, 73);
            reasonLabel.Margin = new Padding(5, 6, 5, 6);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(458, 30);
            reasonLabel.TabIndex = 116;
            reasonLabel.Text = "Motif:";
            // 
            // amountTextBox
            // 
            amountTextBox.AutoSize = false;
            amountTextBox.Location = new Point(225, 35);
            amountTextBox.Margin = new Padding(5, 6, 5, 6);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(243, 30);
            amountTextBox.TabIndex = 2;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = false;
            amountLabel.Location = new Point(225, 5);
            amountLabel.Margin = new Padding(5, 6, 5, 6);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(243, 30);
            amountLabel.TabIndex = 114;
            amountLabel.Text = "Montant:";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = false;
            dateLabel.Location = new Point(10, 5);
            dateLabel.Margin = new Padding(5, 6, 5, 6);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(208, 30);
            dateLabel.TabIndex = 65;
            dateLabel.Text = "Date:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(1, 202);
            errorLabel.Margin = new Padding(5, 6, 5, 6);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(464, 38);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.Location = new Point(319, 160);
            closeButton.Margin = new Padding(5, 6, 5, 6);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(146, 38);
            closeButton.TabIndex = 115;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(163, 160);
            saveButton.Margin = new Padding(5, 6, 5, 6);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(146, 38);
            saveButton.TabIndex = 114;
            saveButton.Text = "Enregistrer";
            // 
            // EditEmployeeAccountTransactionForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(477, 241);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(errorLabel);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditEmployeeAccountTransactionForm";
            Text = "EditEmployeeDepositForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dateSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionDateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)reasonSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)reasonTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)reasonLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator reasonSeparator;
        private Telerik.WinControls.UI.RadSeparator amountSeparator;
        private Telerik.WinControls.UI.RadTextBox reasonTextBox;
        private Telerik.WinControls.UI.RadLabel reasonLabel;
        private Telerik.WinControls.UI.RadTextBox amountTextBox;
        private Telerik.WinControls.UI.RadLabel amountLabel;
        private Telerik.WinControls.UI.RadSeparator dateSeparator;
        private Telerik.WinControls.UI.RadLabel dateLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadDateTimePicker transactionDateTimePicker;
    }
}