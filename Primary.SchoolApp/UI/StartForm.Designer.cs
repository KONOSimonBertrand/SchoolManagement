namespace Primary.SchoolApp.UI
{
    partial class StartForm
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
            this.lodingLabel = new Telerik.WinControls.UI.RadLabel();
            this.titleLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lodingLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // lodingLabel
            // 
            this.lodingLabel.AutoSize = false;
            this.lodingLabel.BackColor = System.Drawing.Color.Transparent;
            this.lodingLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lodingLabel.ForeColor = System.Drawing.Color.White;
            this.lodingLabel.Location = new System.Drawing.Point(191, 374);
            this.lodingLabel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lodingLabel.Name = "lodingLabel";
            this.lodingLabel.Size = new System.Drawing.Size(418, 38);
            this.lodingLabel.TabIndex = 6;
            this.lodingLabel.Text = "Démarrage en cours ... Veuilez patienter";
            this.lodingLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = false;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(4, 58);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(658, 38);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "SCHOOL APP";
            this.titleLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(530, 295);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.lodingLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SplashStartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            ((System.ComponentModel.ISupportInitialize)(this.lodingLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lodingLabel;
        private Telerik.WinControls.UI.RadLabel titleLabel;
    }
}