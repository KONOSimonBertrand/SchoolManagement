namespace SchoolManagement.UI
{
    partial class EditSchoolingCostForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            editPanel = new Telerik.WinControls.UI.RadPanel();
            tranchesGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            tranchesGridView = new Telerik.WinControls.UI.RadGridView();
            trancheNumberSeparator = new Telerik.WinControls.UI.RadSeparator();
            amountSeparator = new Telerik.WinControls.UI.RadSeparator();
            costDueSeparator = new Telerik.WinControls.UI.RadSeparator();
            costTypeSeparator = new Telerik.WinControls.UI.RadSeparator();
            trancheNumberTextBox = new Telerik.WinControls.UI.RadTextBox();
            amountTextBox = new Telerik.WinControls.UI.RadTextBox();
            trancheNumberLabel = new Telerik.WinControls.UI.RadLabel();
            amountLabel = new Telerik.WinControls.UI.RadLabel();
            addCostTypeButton = new Telerik.WinControls.UI.RadButton();
            costTypeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            costPayableDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            costPayableLabel = new Telerik.WinControls.UI.RadLabel();
            costTypeLabel = new Telerik.WinControls.UI.RadLabel();
            classSeparator = new Telerik.WinControls.UI.RadSeparator();
            schoolYearSeparator = new Telerik.WinControls.UI.RadSeparator();
            addClassButton = new Telerik.WinControls.UI.RadButton();
            classDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            addSchoolYearButton = new Telerik.WinControls.UI.RadButton();
            schoolYearDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            classLabel = new Telerik.WinControls.UI.RadLabel();
            schoolYearLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)editPanel).BeginInit();
            editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tranchesGroupBox).BeginInit();
            tranchesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tranchesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tranchesGridView.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costDueSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTypeSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addCostTypeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTypeDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costPayableDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costPayableLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTypeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addClassButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addSchoolYearButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearDropDownList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // editPanel
            // 
            editPanel.Controls.Add(tranchesGroupBox);
            editPanel.Controls.Add(trancheNumberSeparator);
            editPanel.Controls.Add(amountSeparator);
            editPanel.Controls.Add(costDueSeparator);
            editPanel.Controls.Add(costTypeSeparator);
            editPanel.Controls.Add(trancheNumberTextBox);
            editPanel.Controls.Add(amountTextBox);
            editPanel.Controls.Add(trancheNumberLabel);
            editPanel.Controls.Add(amountLabel);
            editPanel.Controls.Add(addCostTypeButton);
            editPanel.Controls.Add(costTypeDropDownList);
            editPanel.Controls.Add(costPayableDropDownList);
            editPanel.Controls.Add(costPayableLabel);
            editPanel.Controls.Add(costTypeLabel);
            editPanel.Controls.Add(classSeparator);
            editPanel.Controls.Add(schoolYearSeparator);
            editPanel.Controls.Add(addClassButton);
            editPanel.Controls.Add(classDropDownList);
            editPanel.Controls.Add(addSchoolYearButton);
            editPanel.Controls.Add(schoolYearDropDownList);
            editPanel.Controls.Add(classLabel);
            editPanel.Controls.Add(schoolYearLabel);
            editPanel.Dock = DockStyle.Top;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(575, 416);
            editPanel.TabIndex = 74;
            // 
            // tranchesGroupBox
            // 
            tranchesGroupBox.AccessibleRole = AccessibleRole.Grouping;
            tranchesGroupBox.Controls.Add(tranchesGridView);
            tranchesGroupBox.HeaderMargin = new Padding(1);
            tranchesGroupBox.HeaderText = "Tranches";
            tranchesGroupBox.Location = new Point(3, 220);
            tranchesGroupBox.Name = "tranchesGroupBox";
            tranchesGroupBox.Size = new Size(561, 193);
            tranchesGroupBox.TabIndex = 98;
            tranchesGroupBox.Text = "Tranches";
            // 
            // tranchesGridView
            // 
            tranchesGridView.Location = new Point(2, 21);
            // 
            // 
            // 
            tranchesGridView.MasterTemplate.AllowAddNewRow = false;
            tranchesGridView.MasterTemplate.AllowColumnChooser = false;
            tranchesGridView.MasterTemplate.AllowDeleteRow = false;
            tranchesGridView.MasterTemplate.AllowDragToGroup = false;
            tranchesGridView.MasterTemplate.AllowRowHeaderContextMenu = false;
            tranchesGridView.MasterTemplate.EnableGrouping = false;
            tranchesGridView.MasterTemplate.ShowFilteringRow = false;
            tranchesGridView.MasterTemplate.ViewDefinition = tableViewDefinition2;
            tranchesGridView.Name = "tranchesGridView";
            tranchesGridView.Size = new Size(557, 170);
            tranchesGridView.TabIndex = 10;
            // 
            // trancheNumberSeparator
            // 
            trancheNumberSeparator.Location = new Point(290, 208);
            trancheNumberSeparator.Margin = new Padding(4, 5, 4, 5);
            trancheNumberSeparator.Name = "trancheNumberSeparator";
            trancheNumberSeparator.Size = new Size(109, 4);
            trancheNumberSeparator.TabIndex = 97;
            trancheNumberSeparator.TabStop = false;
            // 
            // amountSeparator
            // 
            amountSeparator.Location = new Point(6, 208);
            amountSeparator.Margin = new Padding(4, 5, 4, 5);
            amountSeparator.Name = "amountSeparator";
            amountSeparator.Size = new Size(234, 4);
            amountSeparator.TabIndex = 96;
            amountSeparator.TabStop = false;
            // 
            // costDueSeparator
            // 
            costDueSeparator.Location = new Point(290, 132);
            costDueSeparator.Margin = new Padding(4, 5, 4, 5);
            costDueSeparator.Name = "costDueSeparator";
            costDueSeparator.Size = new Size(109, 5);
            costDueSeparator.TabIndex = 95;
            costDueSeparator.TabStop = false;
            // 
            // costTypeSeparator
            // 
            costTypeSeparator.Location = new Point(8, 132);
            costTypeSeparator.Margin = new Padding(4, 5, 4, 5);
            costTypeSeparator.Name = "costTypeSeparator";
            costTypeSeparator.Size = new Size(234, 5);
            costTypeSeparator.TabIndex = 94;
            costTypeSeparator.TabStop = false;
            // 
            // trancheNumberTextBox
            // 
            trancheNumberTextBox.AutoSize = false;
            trancheNumberTextBox.Location = new Point(290, 175);
            trancheNumberTextBox.Margin = new Padding(4, 5, 4, 5);
            trancheNumberTextBox.MaxLength = 1;
            trancheNumberTextBox.Name = "trancheNumberTextBox";
            trancheNumberTextBox.Size = new Size(109, 32);
            trancheNumberTextBox.TabIndex = 8;
            // 
            // amountTextBox
            // 
            amountTextBox.AutoSize = false;
            amountTextBox.Location = new Point(6, 175);
            amountTextBox.Margin = new Padding(4, 5, 4, 5);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(234, 32);
            amountTextBox.TabIndex = 7;
            // 
            // trancheNumberLabel
            // 
            trancheNumberLabel.AutoSize = false;
            trancheNumberLabel.Location = new Point(290, 143);
            trancheNumberLabel.Margin = new Padding(4, 5, 4, 5);
            trancheNumberLabel.Name = "trancheNumberLabel";
            trancheNumberLabel.Size = new Size(167, 32);
            trancheNumberLabel.TabIndex = 89;
            trancheNumberLabel.Text = "Nombre de tranches:";
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = false;
            amountLabel.Location = new Point(8, 143);
            amountLabel.Margin = new Padding(4, 5, 4, 5);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(234, 32);
            amountLabel.TabIndex = 87;
            amountLabel.Text = "Montant:";
            // 
            // addCostTypeButton
            // 
            addCostTypeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addCostTypeButton.Location = new Point(242, 103);
            addCostTypeButton.Margin = new Padding(4, 5, 4, 5);
            addCostTypeButton.Name = "addCostTypeButton";
            addCostTypeButton.Size = new Size(20, 30);
            addCostTypeButton.TabIndex = 5;
            // 
            // costTypeDropDownList
            // 
            costTypeDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            costTypeDropDownList.DropDownAnimationEnabled = true;
            costTypeDropDownList.DropDownHeight = 159;
            costTypeDropDownList.Location = new Point(6, 103);
            costTypeDropDownList.Margin = new Padding(4, 5, 4, 5);
            costTypeDropDownList.MinimumSize = new Size(0, 30);
            costTypeDropDownList.Name = "costTypeDropDownList";
            costTypeDropDownList.Size = new Size(234, 30);
            costTypeDropDownList.TabIndex = 4;
            ((Telerik.WinControls.UI.RadDropDownListElement)costTypeDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)costTypeDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)costTypeDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)costTypeDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)costTypeDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)costTypeDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // costPayableDropDownList
            // 
            costPayableDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            costPayableDropDownList.DropDownAnimationEnabled = true;
            costPayableDropDownList.DropDownHeight = 159;
            costPayableDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            costPayableDropDownList.Location = new Point(290, 103);
            costPayableDropDownList.Margin = new Padding(4, 5, 4, 5);
            costPayableDropDownList.MinimumSize = new Size(0, 30);
            costPayableDropDownList.Name = "costPayableDropDownList";
            costPayableDropDownList.Size = new Size(109, 30);
            costPayableDropDownList.TabIndex = 6;
            ((Telerik.WinControls.UI.RadDropDownListElement)costPayableDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.BorderPrimitive)costPayableDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)costPayableDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)costPayableDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)costPayableDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)costPayableDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // costPayableLabel
            // 
            costPayableLabel.AutoSize = false;
            costPayableLabel.Location = new Point(290, 71);
            costPayableLabel.Margin = new Padding(4, 5, 4, 5);
            costPayableLabel.Name = "costPayableLabel";
            costPayableLabel.Size = new Size(109, 32);
            costPayableLabel.TabIndex = 82;
            costPayableLabel.Text = "Frais exigible:";
            // 
            // costTypeLabel
            // 
            costTypeLabel.AutoSize = false;
            costTypeLabel.Location = new Point(8, 71);
            costTypeLabel.Margin = new Padding(4, 5, 4, 5);
            costTypeLabel.Name = "costTypeLabel";
            costTypeLabel.Size = new Size(234, 32);
            costTypeLabel.TabIndex = 81;
            costTypeLabel.Text = "Type de frais:";
            // 
            // classSeparator
            // 
            classSeparator.Location = new Point(290, 65);
            classSeparator.Margin = new Padding(4, 5, 4, 5);
            classSeparator.Name = "classSeparator";
            classSeparator.Size = new Size(234, 6);
            classSeparator.TabIndex = 80;
            classSeparator.TabStop = false;
            // 
            // schoolYearSeparator
            // 
            schoolYearSeparator.Location = new Point(6, 65);
            schoolYearSeparator.Margin = new Padding(4, 5, 4, 5);
            schoolYearSeparator.Name = "schoolYearSeparator";
            schoolYearSeparator.Size = new Size(234, 4);
            schoolYearSeparator.TabIndex = 79;
            schoolYearSeparator.TabStop = false;
            // 
            // addClassButton
            // 
            addClassButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addClassButton.Location = new Point(525, 32);
            addClassButton.Margin = new Padding(4, 5, 4, 5);
            addClassButton.Name = "addClassButton";
            addClassButton.Size = new Size(20, 30);
            addClassButton.TabIndex = 3;
            // 
            // classDropDownList
            // 
            classDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            classDropDownList.DropDownAnimationEnabled = true;
            classDropDownList.DropDownHeight = 159;
            classDropDownList.Location = new Point(290, 32);
            classDropDownList.Margin = new Padding(4, 5, 4, 5);
            classDropDownList.MinimumSize = new Size(0, 30);
            classDropDownList.Name = "classDropDownList";
            classDropDownList.Size = new Size(234, 30);
            classDropDownList.TabIndex = 2;
            ((Telerik.WinControls.UI.RadDropDownListElement)classDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)classDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)classDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // addSchoolYearButton
            // 
            addSchoolYearButton.ImageAlignment = ContentAlignment.MiddleCenter;
            addSchoolYearButton.Location = new Point(242, 32);
            addSchoolYearButton.Margin = new Padding(4, 5, 4, 5);
            addSchoolYearButton.Name = "addSchoolYearButton";
            addSchoolYearButton.Size = new Size(20, 30);
            addSchoolYearButton.TabIndex = 1;
            // 
            // schoolYearDropDownList
            // 
            schoolYearDropDownList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            schoolYearDropDownList.DropDownAnimationEnabled = true;
            schoolYearDropDownList.DropDownHeight = 159;
            schoolYearDropDownList.Location = new Point(6, 32);
            schoolYearDropDownList.Margin = new Padding(4, 5, 4, 5);
            schoolYearDropDownList.MinimumSize = new Size(0, 30);
            schoolYearDropDownList.Name = "schoolYearDropDownList";
            schoolYearDropDownList.Size = new Size(234, 30);
            schoolYearDropDownList.TabIndex = 0;
            ((Telerik.WinControls.UI.RadDropDownListElement)schoolYearDropDownList.GetChildAt(0)).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            ((Telerik.WinControls.Primitives.BorderPrimitive)schoolYearDropDownList.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)schoolYearDropDownList.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)schoolYearDropDownList.GetChildAt(0).GetChildAt(3)).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.AutoCompleteSuggestDropDownListElement)schoolYearDropDownList.GetChildAt(0).GetChildAt(3)).MaxSize = new Size(0, 1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)schoolYearDropDownList.GetChildAt(0).GetChildAt(3).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // classLabel
            // 
            classLabel.AutoSize = false;
            classLabel.Location = new Point(290, 0);
            classLabel.Margin = new Padding(4, 5, 4, 5);
            classLabel.Name = "classLabel";
            classLabel.Size = new Size(274, 32);
            classLabel.TabIndex = 74;
            classLabel.Text = "Classe:";
            // 
            // schoolYearLabel
            // 
            schoolYearLabel.AutoSize = false;
            schoolYearLabel.Location = new Point(6, 0);
            schoolYearLabel.Margin = new Padding(4, 5, 4, 5);
            schoolYearLabel.Name = "schoolYearLabel";
            schoolYearLabel.Size = new Size(267, 32);
            schoolYearLabel.TabIndex = 73;
            schoolYearLabel.Text = "Année scolaire:";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(0, 459);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(564, 25);
            errorLabel.TabIndex = 113;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(427, 423);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(133, 32);
            closeButton.TabIndex = 112;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(287, 423);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(133, 32);
            saveButton.TabIndex = 111;
            saveButton.Text = "Enregistrer";
            // 
            // EditSchoolingCostForm
            // 
            AcceptButton = saveButton;
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 491);
            Controls.Add(errorLabel);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(editPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditSchoolingCostForm";
            Text = "EditSchoolingCostForm";
            ((System.ComponentModel.ISupportInitialize)editPanel).EndInit();
            editPanel.ResumeLayout(false);
            editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tranchesGroupBox).EndInit();
            tranchesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tranchesGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)tranchesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)costDueSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTypeSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trancheNumberLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)amountLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)addCostTypeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTypeDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)costPayableDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)costPayableLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTypeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)classSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)addClassButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)classDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)addSchoolYearButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearDropDownList).EndInit();
            ((System.ComponentModel.ISupportInitialize)classLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolYearLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator trancheNumberSeparator;
        private Telerik.WinControls.UI.RadSeparator amountSeparator;
        private Telerik.WinControls.UI.RadSeparator costDueSeparator;
        private Telerik.WinControls.UI.RadSeparator costTypeSeparator;
        private Telerik.WinControls.UI.RadTextBox trancheNumberTextBox;
        private Telerik.WinControls.UI.RadTextBox amountTextBox;
        private Telerik.WinControls.UI.RadLabel trancheNumberLabel;
        private Telerik.WinControls.UI.RadLabel amountLabel;
        private Telerik.WinControls.UI.RadButton addCostTypeButton;
        private Telerik.WinControls.UI.RadDropDownList costTypeDropDownList;
        private Telerik.WinControls.UI.RadDropDownList costPayableDropDownList;
        private Telerik.WinControls.UI.RadLabel costPayableLabel;
        private Telerik.WinControls.UI.RadLabel costTypeLabel;
        private Telerik.WinControls.UI.RadSeparator classSeparator;
        private Telerik.WinControls.UI.RadSeparator schoolYearSeparator;
        private Telerik.WinControls.UI.RadButton addClassButton;
        private Telerik.WinControls.UI.RadDropDownList classDropDownList;
        private Telerik.WinControls.UI.RadButton addSchoolYearButton;
        private Telerik.WinControls.UI.RadDropDownList schoolYearDropDownList;
        private Telerik.WinControls.UI.RadLabel classLabel;
        private Telerik.WinControls.UI.RadLabel schoolYearLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadGroupBox tranchesGroupBox;
        private Telerik.WinControls.UI.RadGridView tranchesGridView;
    }
}