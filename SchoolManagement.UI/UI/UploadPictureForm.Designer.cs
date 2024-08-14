namespace SchoolManagement.UI
{
    partial class UploadPictureForm
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
            informationsPanel = new Telerik.WinControls.UI.RadPanel();
            photoPanel = new Telerik.WinControls.UI.RadPanel();
            takePhotoButton = new Telerik.WinControls.UI.RadButton();
            circleShape1 = new Telerik.WinControls.CircleShape();
            photoWebCam = new Telerik.WinControls.UI.RadWebCam();
            deletePhotoButton = new Telerik.WinControls.UI.RadButton();
            errorLabel = new Telerik.WinControls.UI.RadLabel();
            closeButton = new Telerik.WinControls.UI.RadButton();
            saveButton = new Telerik.WinControls.UI.RadButton();
            importPictureButton = new Telerik.WinControls.UI.RadButton();
            schoolInformationLabel = new Telerik.WinControls.UI.RadLabel();
            personalInformationLabel = new Telerik.WinControls.UI.RadLabel();
            nameLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)informationsPanel).BeginInit();
            informationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)photoPanel).BeginInit();
            photoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)takePhotoButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoWebCam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deletePhotoButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)importPictureButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schoolInformationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personalInformationLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // informationsPanel
            // 
            informationsPanel.BackColor = Color.FromArgb(191, 219, 255);
            informationsPanel.Controls.Add(photoPanel);
            informationsPanel.Controls.Add(errorLabel);
            informationsPanel.Controls.Add(closeButton);
            informationsPanel.Controls.Add(saveButton);
            informationsPanel.Controls.Add(importPictureButton);
            informationsPanel.Controls.Add(schoolInformationLabel);
            informationsPanel.Controls.Add(personalInformationLabel);
            informationsPanel.Controls.Add(nameLabel);
            informationsPanel.Dock = DockStyle.Top;
            informationsPanel.Location = new Point(0, 0);
            informationsPanel.Name = "informationsPanel";
            informationsPanel.Size = new Size(952, 372);
            informationsPanel.TabIndex = 8;
            // 
            // photoPanel
            // 
            photoPanel.BackgroundImage = Resources.no_image;
            photoPanel.BackgroundImageLayout = ImageLayout.Center;
            photoPanel.Controls.Add(takePhotoButton);
            photoPanel.Controls.Add(photoWebCam);
            photoPanel.Controls.Add(deletePhotoButton);
            photoPanel.Location = new Point(7, 3);
            photoPanel.Name = "photoPanel";
            photoPanel.Padding = new Padding(30, 20, 30, 20);
            // 
            // 
            // 
            photoPanel.RootElement.EnableElementShadow = false;
            photoPanel.Size = new Size(296, 288);
            photoPanel.TabIndex = 69;
            ((Telerik.WinControls.UI.RadPanelElement)photoPanel.GetChildAt(0)).Padding = new Padding(30, 20, 30, 20);
            ((Telerik.WinControls.Primitives.FillPrimitive)photoPanel.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.FillPrimitive)photoPanel.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.Primitives.BorderPrimitive)photoPanel.GetChildAt(0).GetChildAt(1)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)photoPanel.GetChildAt(0).GetChildAt(1)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // takePhotoButton
            // 
            takePhotoButton.Location = new Point(114, 93);
            takePhotoButton.Name = "takePhotoButton";
            takePhotoButton.Size = new Size(64, 64);
            takePhotoButton.TabIndex = 1;
            takePhotoButton.Text = "P";
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).Text = "P";
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).EnableElementShadow = false;
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).EnableFocusBorder = false;
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).EnableFocusBorderAnimation = false;
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).EnableHighlight = false;
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).EnableBorderHighlight = false;
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).Padding = new Padding(1, 1, 0, 0);
            ((Telerik.WinControls.UI.RadButtonElement)takePhotoButton.GetChildAt(0)).Shape = circleShape1;
            ((Telerik.WinControls.Primitives.FillPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.FillPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(0)).Opacity = 0.7D;
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).CustomFont = "TelerikWebUI";
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).CustomFontSize = 24F;
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.TextPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).Alignment = ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)takePhotoButton.GetChildAt(0).GetChildAt(2)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // photoWebCam
            // 
            photoWebCam.AutoStart = false;
            photoWebCam.Location = new Point(7, 7);
            photoWebCam.Name = "photoWebCam";
            photoWebCam.Size = new Size(280, 274);
            photoWebCam.TabIndex = 0;
            ((Telerik.WinControls.UI.LightVisualElement)photoWebCam.GetChildAt(0)).DrawFill = true;
            ((Telerik.WinControls.UI.LightVisualElement)photoWebCam.GetChildAt(0)).GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            ((Telerik.WinControls.UI.LightVisualElement)photoWebCam.GetChildAt(0)).BackColor = Color.Black;
            // 
            // deletePhotoButton
            // 
            deletePhotoButton.Enabled = false;
            deletePhotoButton.Location = new Point(188, 112);
            deletePhotoButton.Name = "deletePhotoButton";
            deletePhotoButton.Size = new Size(26, 26);
            deletePhotoButton.TabIndex = 2;
            deletePhotoButton.Text = "D";
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).Text = "D";
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).EnableElementShadow = false;
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).EnableFocusBorder = false;
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).EnableFocusBorderAnimation = true;
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).EnableHighlight = false;
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).EnableBorderHighlight = false;
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).ToolTipText = "Take Photo";
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).Padding = new Padding(1, 1, 0, 0);
            ((Telerik.WinControls.UI.RadButtonElement)deletePhotoButton.GetChildAt(0)).Shape = circleShape1;
            ((Telerik.WinControls.Primitives.FillPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(0)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.FillPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(0)).Opacity = 0.7D;
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).CustomFont = "TelerikWebUI";
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).CustomFontSize = 12F;
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ((Telerik.WinControls.Primitives.TextPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(1).GetChildAt(1)).Alignment = ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)deletePhotoButton.GetChildAt(0).GetChildAt(2)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = false;
            errorLabel.Location = new Point(394, 115);
            errorLabel.Margin = new Padding(4, 5, 4, 5);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(284, 56);
            errorLabel.TabIndex = 68;
            // 
            // closeButton
            // 
            closeButton.ImageAlignment = ContentAlignment.MiddleCenter;
            closeButton.Location = new Point(832, 335);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(114, 30);
            closeButton.TabIndex = 7;
            closeButton.Text = "Annuler";
            // 
            // saveButton
            // 
            saveButton.ImageAlignment = ContentAlignment.MiddleCenter;
            saveButton.Location = new Point(712, 335);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(114, 30);
            saveButton.TabIndex = 7;
            saveButton.Text = "Enregistrer";
            // 
            // importPictureButton
            // 
            importPictureButton.ImageAlignment = ContentAlignment.MiddleCenter;
            importPictureButton.Location = new Point(594, 335);
            importPictureButton.Name = "importPictureButton";
            importPictureButton.Size = new Size(114, 30);
            importPictureButton.TabIndex = 7;
            importPictureButton.Text = "Importer";
            // 
            // schoolInformationLabel
            // 
            schoolInformationLabel.BackColor = Color.Transparent;
            schoolInformationLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schoolInformationLabel.ForeColor = Color.FromArgb(79, 76, 76);
            schoolInformationLabel.Location = new Point(14, 297);
            schoolInformationLabel.Name = "schoolInformationLabel";
            schoolInformationLabel.Size = new Size(943, 25);
            schoolInformationLabel.TabIndex = 4;
            schoolInformationLabel.Text = "CM2 | Primaire | 2019-2020 CM2 | Primaire | 2019-2020 CM2 | Primaire | 2019-2020 CM2 | Primaire | 2019-2020 CM2 | Primaire";
            // 
            // personalInformationLabel
            // 
            personalInformationLabel.BackColor = Color.Transparent;
            personalInformationLabel.Font = new Font("Segoe UI", 14.5F, FontStyle.Regular, GraphicsUnit.Point);
            personalInformationLabel.ForeColor = Color.FromArgb(79, 76, 76);
            personalInformationLabel.Location = new Point(332, 64);
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
            nameLabel.Location = new Point(329, 4);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(435, 64);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "KONO Simon Bertrand";
            // 
            // UploadPictureForm
            // 
            AutoScaleBaseSize = new Size(7, 15);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 400);
            Controls.Add(informationsPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UploadPictureForm";
            Text = "StudentPictureForm";
            ((System.ComponentModel.ISupportInitialize)informationsPanel).EndInit();
            informationsPanel.ResumeLayout(false);
            informationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)photoPanel).EndInit();
            photoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)takePhotoButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoWebCam).EndInit();
            ((System.ComponentModel.ISupportInitialize)deletePhotoButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)importPictureButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)schoolInformationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)personalInformationLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nameLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadPanel informationsPanel;
        private Telerik.WinControls.UI.RadButton saveButton;
        private Telerik.WinControls.UI.RadButton importPictureButton;
        private Telerik.WinControls.UI.RadLabel schoolInformationLabel;
        private Telerik.WinControls.UI.RadLabel personalInformationLabel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.CircleShape circleShape1;
        private Telerik.WinControls.UI.RadPanel photoPanel;
        private Telerik.WinControls.UI.RadButton takePhotoButton;
        private Telerik.WinControls.UI.RadWebCam photoWebCam;
        private Telerik.WinControls.UI.RadButton deletePhotoButton;
        private Telerik.WinControls.UI.RadButton closeButton;
    }
}