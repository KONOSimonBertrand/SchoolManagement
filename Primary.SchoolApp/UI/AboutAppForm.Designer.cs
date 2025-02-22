namespace Primary.SchoolApp.UI
{
    partial class AboutAppForm
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
            radLabel8 = new Telerik.WinControls.UI.RadLabel();
            radLabel4 = new Telerik.WinControls.UI.RadLabel();
            radLabel2 = new Telerik.WinControls.UI.RadLabel();
            radLabel1 = new Telerik.WinControls.UI.RadLabel();
            logoPictureBox = new System.Windows.Forms.PictureBox();
            serialKeyDurationLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyTypeLabel = new Telerik.WinControls.UI.RadLabel();
            serialKeyUserLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)radLabel8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radLabel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // radLabel8
            // 
            radLabel8.Location = new System.Drawing.Point(31, 94);
            radLabel8.Margin = new System.Windows.Forms.Padding(5);
            radLabel8.Name = "radLabel8";
            radLabel8.Size = new System.Drawing.Size(282, 21);
            radLabel8.TabIndex = 19;
            radLabel8.Text = "TEL: 237 679 72 83 44/+33 06 01 24 89 20";
            radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel4
            // 
            radLabel4.Location = new System.Drawing.Point(14, 63);
            radLabel4.Margin = new System.Windows.Forms.Padding(5);
            radLabel4.Name = "radLabel4";
            radLabel4.Size = new System.Drawing.Size(204, 21);
            radLabel4.TabIndex = 12;
            radLabel4.Text = "Copyright © 2024 SUITS TECH";
            // 
            // radLabel2
            // 
            radLabel2.Location = new System.Drawing.Point(243, 26);
            radLabel2.Margin = new System.Windows.Forms.Padding(5);
            radLabel2.Name = "radLabel2";
            radLabel2.Size = new System.Drawing.Size(81, 21);
            radLabel2.TabIndex = 17;
            radLabel2.Text = "Version 2.0";
            // 
            // radLabel1
            // 
            radLabel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radLabel1.Location = new System.Drawing.Point(14, 14);
            radLabel1.Margin = new System.Windows.Forms.Padding(5);
            radLabel1.Name = "radLabel1";
            radLabel1.Size = new System.Drawing.Size(121, 33);
            radLabel1.TabIndex = 18;
            radLabel1.Text = "School App";
            // 
            // logoPictureBox
            // 
            logoPictureBox.Location = new System.Drawing.Point(165, 3);
            logoPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new System.Drawing.Size(70, 53);
            logoPictureBox.TabIndex = 11;
            logoPictureBox.TabStop = false;
            // 
            // serialKeyDurationLabel
            // 
            serialKeyDurationLabel.AutoSize = false;
            serialKeyDurationLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serialKeyDurationLabel.Location = new System.Drawing.Point(14, 158);
            serialKeyDurationLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            serialKeyDurationLabel.Name = "serialKeyDurationLabel";
            serialKeyDurationLabel.Size = new System.Drawing.Size(435, 30);
            serialKeyDurationLabel.TabIndex = 22;
            serialKeyDurationLabel.Text = "Date d'expiration:";
            // 
            // serialKeyTypeLabel
            // 
            serialKeyTypeLabel.AutoSize = false;
            serialKeyTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serialKeyTypeLabel.Location = new System.Drawing.Point(14, 124);
            serialKeyTypeLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            serialKeyTypeLabel.Name = "serialKeyTypeLabel";
            serialKeyTypeLabel.Size = new System.Drawing.Size(435, 30);
            serialKeyTypeLabel.TabIndex = 21;
            serialKeyTypeLabel.Text = "Type de licence:";
            // 
            // serialKeyUserLabel
            // 
            serialKeyUserLabel.AutoSize = false;
            serialKeyUserLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            serialKeyUserLabel.Location = new System.Drawing.Point(14, 92);
            serialKeyUserLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            serialKeyUserLabel.Name = "serialKeyUserLabel";
            serialKeyUserLabel.Size = new System.Drawing.Size(435, 30);
            serialKeyUserLabel.TabIndex = 20;
            serialKeyUserLabel.Text = "Utilisateur:";
            // 
            // AboutAppForm
            // 
            AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(454, 233);
            Controls.Add(serialKeyDurationLabel);
            Controls.Add(serialKeyTypeLabel);
            Controls.Add(serialKeyUserLabel);
            Controls.Add(radLabel8);
            Controls.Add(radLabel4);
            Controls.Add(radLabel2);
            Controls.Add(radLabel1);
            Controls.Add(logoPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutAppForm";
            Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)radLabel8).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel4).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)radLabel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyDurationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyTypeLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)serialKeyUserLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private Telerik.WinControls.UI.RadLabel serialKeyDurationLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyTypeLabel;
        private Telerik.WinControls.UI.RadLabel serialKeyUserLabel;
    }
}