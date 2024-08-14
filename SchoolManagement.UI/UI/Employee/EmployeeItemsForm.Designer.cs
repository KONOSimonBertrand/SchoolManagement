namespace SchoolManagement.UI
{
    partial class EmployeeItemsForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            dataGridView = new Telerik.WinControls.UI.RadGridView();
            radLabel3 = new Telerik.WinControls.UI.RadLabel();
            radLabel2 = new Telerik.WinControls.UI.RadLabel();
            radLabel1 = new Telerik.WinControls.UI.RadLabel();
            emailLabel = new Telerik.WinControls.UI.RadLabel();
            phoneLabel = new Telerik.WinControls.UI.RadLabel();
            addressLabel = new Telerik.WinControls.UI.RadLabel();
            schoolInformationLabel = new Telerik.WinControls.UI.RadLabel();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            varticalLineLabel = new Telerik.WinControls.UI.RadLabel();
            personalInformationLabel = new Telerik.WinControls.UI.RadLabel();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            pictureLabel = new Telerik.WinControls.UI.RadLabel();
            dataPanel = new Telerik.WinControls.UI.RadPanel();
            personPanel = new Telerik.WinControls.UI.RadPanel();
            filterTextBox = new CustomControls.SearchTextBox();
            exportButton = new Telerik.WinControls.UI.RadButton();
            printButton = new Telerik.WinControls.UI.RadButton();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emailLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)phoneLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addressLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolInformationLabel).BeginInit();
            schoolInformationLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)varticalLineLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personalInformationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).BeginInit();
            dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personPanel).BeginInit();
            personPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exportButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)printButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            // 
            // 
            // 
            dataGridView.MasterTemplate.AllowAddNewRow = false;
            dataGridView.MasterTemplate.AllowDeleteRow = false;
            dataGridView.MasterTemplate.AllowEditRow = false;
            dataGridView.MasterTemplate.ViewDefinition = tableViewDefinition3;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1073, 355);
            dataGridView.TabIndex = 4;
            // 
            // radLabel3
            // 
            radLabel3.BackColor = Color.Transparent;
            radLabel3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radLabel3.ForeColor = Color.FromArgb(27, 4, 69);
            radLabel3.Location = new Point(625, 113);
            radLabel3.Name = "radLabel3";
            radLabel3.Size = new Size(59, 25);
            radLabel3.TabIndex = 6;
            radLabel3.Text = "E-mail:";
            // 
            // radLabel2
            // 
            radLabel2.BackColor = Color.Transparent;
            radLabel2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radLabel2.ForeColor = Color.FromArgb(27, 4, 69);
            radLabel2.Location = new Point(622, 69);
            radLabel2.Name = "radLabel2";
            radLabel2.Size = new Size(90, 25);
            radLabel2.TabIndex = 6;
            radLabel2.Text = "Téléphone:";
            // 
            // radLabel1
            // 
            radLabel1.BackColor = Color.Transparent;
            radLabel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radLabel1.ForeColor = Color.FromArgb(27, 4, 69);
            radLabel1.Location = new Point(622, 30);
            radLabel1.Name = "radLabel1";
            radLabel1.Size = new Size(71, 25);
            radLabel1.TabIndex = 6;
            radLabel1.Text = "Adresse:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = false;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.ForeColor = Color.FromArgb(27, 4, 69);
            emailLabel.Location = new Point(718, 113);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(295, 20);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "kono.simon.bertrand@gmail.com";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = false;
            phoneLabel.BackColor = Color.Transparent;
            phoneLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phoneLabel.ForeColor = Color.FromArgb(27, 4, 69);
            phoneLabel.Location = new Point(718, 74);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(295, 20);
            phoneLabel.TabIndex = 5;
            phoneLabel.Text = "237 679 728 344";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = false;
            addressLabel.BackColor = Color.Transparent;
            addressLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addressLabel.ForeColor = Color.FromArgb(27, 4, 69);
            addressLabel.Location = new Point(718, 17);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(357, 47);
            addressLabel.TabIndex = 5;
            addressLabel.Text = "201 Jones Road Waltham MA 02451";
            // 
            // schoolInformationLabel
            // 
            schoolInformationLabel.BackColor = Color.Transparent;
            schoolInformationLabel.Controls.Add(errorLabel);
            schoolInformationLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schoolInformationLabel.ForeColor = Color.FromArgb(79, 76, 76);
            schoolInformationLabel.Location = new Point(23, 161);
            schoolInformationLabel.Name = "schoolInformationLabel";
            schoolInformationLabel.Size = new Size(1051, 25);
            schoolInformationLabel.TabIndex = 4;
            schoolInformationLabel.Text = "CM2 | Primaire | 2019-2020CM2 | Primaire | 2019-2020CM2 | Primaire | 2019-2020CM2 | Primaire | 2019-2020CM2 | Primaire | 2019-2020CM2";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(186, 37);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(451, 25);
            errorLabel.TabIndex = 69;
            // 
            // varticalLineLabel
            // 
            varticalLineLabel.AutoSize = false;
            varticalLineLabel.BackColor = Color.FromArgb(36, 24, 58);
            varticalLineLabel.BorderVisible = true;
            varticalLineLabel.Location = new Point(618, 19);
            varticalLineLabel.Name = "varticalLineLabel";
            varticalLineLabel.Size = new Size(1, 114);
            varticalLineLabel.TabIndex = 3;
            // 
            // personalInformationLabel
            // 
            personalInformationLabel.BackColor = Color.Transparent;
            personalInformationLabel.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            personalInformationLabel.ForeColor = Color.FromArgb(79, 76, 76);
            personalInformationLabel.Location = new Point(157, 64);
            personalInformationLabel.Margin = new Padding(3, 3, 0, 3);
            personalInformationLabel.Name = "personalInformationLabel";
            personalInformationLabel.Size = new Size(276, 30);
            personalInformationLabel.TabIndex = 2;
            personalInformationLabel.Text = "32 ans | masculin | 20-02-1983";
            // 
            // nameLabel
            // 
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Segoe UI Light", 32F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.ForeColor = Color.FromArgb(36, 24, 58);
            nameLabel.Location = new Point(154, 4);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(435, 64);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "KONO Simon Bertrand";
            // 
            // pictureLabel
            // 
            pictureLabel.Image = Resources.no_image;
            pictureLabel.Location = new Point(23, 24);
            pictureLabel.Name = "pictureLabel";
            pictureLabel.Size = new Size(114, 114);
            pictureLabel.TabIndex = 0;
            // 
            // dataPanel
            // 
            dataPanel.Controls.Add(dataGridView);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Location = new Point(0, 230);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(1073, 355);
            dataPanel.TabIndex = 7;
            // 
            // personPanel
            // 
            personPanel.BackColor = Color.FromArgb(191, 219, 255);
            personPanel.Controls.Add(filterTextBox);
            personPanel.Controls.Add(exportButton);
            personPanel.Controls.Add(printButton);
            personPanel.Controls.Add(closeButton);
            personPanel.Controls.Add(saveButton);
            personPanel.Controls.Add(radLabel3);
            personPanel.Controls.Add(radLabel2);
            personPanel.Controls.Add(radLabel1);
            personPanel.Controls.Add(emailLabel);
            personPanel.Controls.Add(phoneLabel);
            personPanel.Controls.Add(addressLabel);
            personPanel.Controls.Add(schoolInformationLabel);
            personPanel.Controls.Add(varticalLineLabel);
            personPanel.Controls.Add(personalInformationLabel);
            personPanel.Controls.Add(nameLabel);
            personPanel.Controls.Add(pictureLabel);
            personPanel.Dock = DockStyle.Top;
            personPanel.Location = new Point(0, 0);
            personPanel.Name = "personPanel";
            personPanel.Size = new Size(1073, 230);
            personPanel.TabIndex = 6;
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(23, 198);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.NullText = "Rechercher par ....";
            filterTextBox.Size = new Size(373, 30);
            filterTextBox.TabIndex = 7;
            // 
            // exportButton
            // 
            exportButton.ImageAlignment = ContentAlignment.MiddleCenter;
            exportButton.Location = new Point(770, 195);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(98, 30);
            exportButton.TabIndex = 1;
            exportButton.Text = "Exporter";
            // 
            // printButton
            // 
            printButton.ImageAlignment = ContentAlignment.MiddleCenter;
            printButton.Location = new Point(873, 194);
            printButton.Name = "printButton";
            printButton.Size = new Size(98, 30);
            printButton.TabIndex = 2;
            printButton.Text = "Imprimer";
            // 
            // closeButton
            // 
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.Location = new Point(974, 194);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(98, 30);
            closeButton.TabIndex = 3;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.ImageAlignment = ContentAlignment.MiddleCenter;
            saveButton.Location = new Point(657, 195);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(108, 30);
            saveButton.TabIndex = 0;
            saveButton.Text = "Enregistrer";
            // 
            // EmployeeRoomsForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 585);
            Controls.Add(dataPanel);
            Controls.Add(personPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeRoomsForm";
            Text = "Room list";
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel3).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emailLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)phoneLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)addressLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolInformationLabel).EndInit();
            schoolInformationLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)varticalLineLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)personalInformationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).EndInit();
            dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)personPanel).EndInit();
            personPanel.ResumeLayout(false);
            personPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filterTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)exportButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)printButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dataGridView;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel emailLabel;
        private Telerik.WinControls.UI.RadLabel phoneLabel;
        private Telerik.WinControls.UI.RadLabel addressLabel;
        private Telerik.WinControls.UI.RadLabel schoolInformationLabel;
        private Telerik.WinControls.UI.RadLabel varticalLineLabel;
        private Telerik.WinControls.UI.RadLabel personalInformationLabel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel pictureLabel;
        private Telerik.WinControls.UI.RadPanel dataPanel;
        private Telerik.WinControls.UI.RadPanel personPanel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadButton exportButton;
        private Telerik.WinControls.UI.RadButton printButton;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private SchoolManagement.UI.CustomControls.SearchTextBox filterTextBox;
    }
}