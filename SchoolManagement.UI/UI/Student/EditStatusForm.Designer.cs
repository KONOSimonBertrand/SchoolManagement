namespace SchoolManagement.UI
{
    partial class EditStatusForm
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
            reasonSeparator = new Telerik.WinControls.UI.RadSeparator();
            reasonDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            reasonLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reasonSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reasonDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reasonLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(reasonSeparator);
            editPanel.Controls.Add(reasonDropDownList);
            editPanel.Controls.Add(reasonLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(420, 68);
            editPanel.TabIndex = 31;
            // 
            // reasonSeparator
            // 
            reasonSeparator.Location = new Point(13, 61);
            reasonSeparator.Margin = new Padding(4, 5, 4, 5);
            reasonSeparator.Name = "reasonSeparator";
            reasonSeparator.Size = new Size(391, 4);
            reasonSeparator.TabIndex = 138;
            reasonSeparator.TabStop = false;
            // 
            // reasonDropDownList
            // 
            reasonDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            reasonDropDownList.Dock = DockStyle.Top;
            reasonDropDownList.DropDownAnimationEnabled = true;
            reasonDropDownList.DropDownHeight = 159;
            reasonDropDownList.Location = new Point(0, 30);
            reasonDropDownList.Margin = new Padding(4, 5, 4, 5);
            reasonDropDownList.MinimumSize = new Size(0, 30);
            reasonDropDownList.Name = "reasonDropDownList";
            reasonDropDownList.Size = new Size(420, 35);
            reasonDropDownList.TabIndex = 127;
            ((Telerik.WinControls.UI.RadDropDownListElement)reasonDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)reasonDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)reasonDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)reasonDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)reasonDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)reasonDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = false;
            reasonLabel.Dock = DockStyle.Top;
            reasonLabel.Location = new Point(0, 0);
            reasonLabel.Margin = new Padding(4, 5, 4, 5);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(420, 30);
            reasonLabel.TabIndex = 126;
            reasonLabel.Text = "Motif:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 74);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(166, 30);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(299, 74);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(117, 36);
            closeButton.TabIndex = 112;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(174, 74);
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
            // EditStatusForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 113);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditStatusForm";
            Text = "Change student status";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reasonSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)reasonDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)reasonLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator reasonSeparator;
        private Telerik.WinControls.UI.RadDropDownList reasonDropDownList;
        private Telerik.WinControls.UI.RadLabel reasonLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private ErrorProvider errorProvider;
    }
}
