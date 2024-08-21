namespace SchoolManagement.UI
{
    partial class UserRoomsForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            dataGridView = new Telerik.WinControls.UI.RadGridView();
            radLabel3 = new Telerik.WinControls.UI.RadLabel();
            radLabel2 = new Telerik.WinControls.UI.RadLabel();
            radLabel1 = new Telerik.WinControls.UI.RadLabel();
            emailLabel = new Telerik.WinControls.UI.RadLabel();
            phoneLabel = new Telerik.WinControls.UI.RadLabel();
            addressLabel = new Telerik.WinControls.UI.RadLabel();
            loginLabel = new Telerik.WinControls.UI.RadLabel();
            varticalLineLabel = new Telerik.WinControls.UI.RadLabel();
            employeeInformationLabel = new Telerik.WinControls.UI.RadLabel();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            employeePictureLabel = new Telerik.WinControls.UI.RadLabel();
            dataPanel = new Telerik.WinControls.UI.RadPanel();
            studentPanel = new Telerik.WinControls.UI.RadPanel();
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
            ((System.ComponentModel.ISupportInitialize)loginLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)varticalLineLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeInformationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeePictureLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).BeginInit();
            dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentPanel).BeginInit();
            studentPanel.SuspendLayout();
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
            dataGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1076, 343);
            dataGridView.TabIndex = 64;
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
            // loginLabel
            // 
            loginLabel.BackColor = Color.Transparent;
            loginLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.ForeColor = Color.FromArgb(79, 76, 76);
            loginLabel.Location = new Point(59, 140);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(40, 25);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "root";
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
            // employeeInformationLabel
            // 
            employeeInformationLabel.BackColor = Color.Transparent;
            employeeInformationLabel.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            employeeInformationLabel.ForeColor = Color.FromArgb(79, 76, 76);
            employeeInformationLabel.Location = new Point(157, 64);
            employeeInformationLabel.Margin = new Padding(3, 3, 0, 3);
            employeeInformationLabel.Name = "employeeInformationLabel";
            employeeInformationLabel.Size = new Size(276, 30);
            employeeInformationLabel.TabIndex = 2;
            employeeInformationLabel.Text = "32 ans | masculin | 20-02-1983";
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
            // employeePictureLabel
            // 
            employeePictureLabel.Location = new Point(23, 24);
            employeePictureLabel.Name = "employeePictureLabel";
            employeePictureLabel.Size = new Size(2, 2);
            employeePictureLabel.TabIndex = 0;
            // 
            // dataPanel
            // 
            dataPanel.Controls.Add(dataGridView);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Location = new Point(0, 222);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(1076, 343);
            dataPanel.TabIndex = 7;
            // 
            // studentPanel
            // 
            studentPanel.BackColor = Color.FromArgb(191, 219, 255);
            studentPanel.Controls.Add(filterTextBox);
            studentPanel.Controls.Add(exportButton);
            studentPanel.Controls.Add(printButton);
            studentPanel.Controls.Add(closeButton);
            studentPanel.Controls.Add(saveButton);
            studentPanel.Controls.Add(radLabel3);
            studentPanel.Controls.Add(radLabel2);
            studentPanel.Controls.Add(radLabel1);
            studentPanel.Controls.Add(emailLabel);
            studentPanel.Controls.Add(phoneLabel);
            studentPanel.Controls.Add(addressLabel);
            studentPanel.Controls.Add(loginLabel);
            studentPanel.Controls.Add(varticalLineLabel);
            studentPanel.Controls.Add(employeeInformationLabel);
            studentPanel.Controls.Add(nameLabel);
            studentPanel.Controls.Add(employeePictureLabel);
            studentPanel.Dock = DockStyle.Top;
            studentPanel.Location = new Point(0, 0);
            studentPanel.Name = "studentPanel";
            studentPanel.Size = new Size(1076, 222);
            studentPanel.TabIndex = 6;
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(22, 189);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.NullText = "Rechercher par ....";
            filterTextBox.Size = new Size(373, 30);
            filterTextBox.TabIndex = 12;
            // 
            // exportButton
            // 
            exportButton.ImageAlignment = ContentAlignment.MiddleCenter;
            exportButton.Location = new Point(769, 186);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(98, 30);
            exportButton.TabIndex = 9;
            exportButton.Text = "Exporter";
            // 
            // printButton
            // 
            printButton.ImageAlignment = ContentAlignment.MiddleCenter;
            printButton.Location = new Point(872, 185);
            printButton.Name = "printButton";
            printButton.Size = new Size(98, 30);
            printButton.TabIndex = 10;
            printButton.Text = "Imprimer";
            // 
            // closeButton
            // 
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.Location = new Point(973, 185);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(98, 30);
            closeButton.TabIndex = 11;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.ImageAlignment = ContentAlignment.MiddleCenter;
            saveButton.Location = new Point(656, 186);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(108, 30);
            saveButton.TabIndex = 8;
            saveButton.Text = "Enregistrer";
            // 
            // UserRoomsForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 565);
            Controls.Add(dataPanel);
            Controls.Add(studentPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserRoomsForm";
            Text = "EmployeeDepositsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView.MasterTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel3).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emailLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)phoneLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)addressLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)varticalLineLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeInformationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeePictureLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataPanel).EndInit();
            dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)studentPanel).EndInit();
            studentPanel.ResumeLayout(false);
            studentPanel.PerformLayout();
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
        private Telerik.WinControls.UI.RadLabel loginLabel;
        private Telerik.WinControls.UI.RadLabel varticalLineLabel;
        private Telerik.WinControls.UI.RadLabel employeeInformationLabel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel employeePictureLabel;
        private Telerik.WinControls.UI.RadPanel dataPanel;
        private Telerik.WinControls.UI.RadPanel studentPanel;
        private CustomControls.SearchTextBox filterTextBox;
        private Telerik.WinControls.UI.RadButton exportButton;
        private Telerik.WinControls.UI.RadButton printButton;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadButton saveButton;
    }
}
