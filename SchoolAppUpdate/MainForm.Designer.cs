namespace SchoolAppUpdate
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveUsersButton = new Telerik.WinControls.UI.RadButton();
            hasUserPasswordButton = new Telerik.WinControls.UI.RadButton();
            appStatusStrip = new Telerik.WinControls.UI.RadStatusStrip();
            radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            taskWaitingBarElement = new Telerik.WinControls.UI.RadWaitingBarElement();
            taskPanel = new Telerik.WinControls.UI.RadPanel();
            reportPanel = new Telerik.WinControls.UI.RadPanel();
            reportLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)saveUsersButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hasUserPasswordButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appStatusStrip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskPanel).BeginInit();
            taskPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportPanel).BeginInit();
            reportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // saveUsersButton
            // 
            saveUsersButton.Location = new Point(30, 30);
            saveUsersButton.Margin = new Padding(30, 30, 30, 30);
            saveUsersButton.Name = "saveUsersButton";
            saveUsersButton.Size = new Size(528, 54);
            saveUsersButton.TabIndex = 0;
            saveUsersButton.Text = "Utilisateurs: Envoyer dans la nouvelle base de données";
            // 
            // hasUserPasswordButton
            // 
            hasUserPasswordButton.Location = new Point(30, 108);
            hasUserPasswordButton.Margin = new Padding(38, 38, 38, 38);
            hasUserPasswordButton.Name = "hasUserPasswordButton";
            hasUserPasswordButton.Size = new Size(528, 54);
            hasUserPasswordButton.TabIndex = 0;
            hasUserPasswordButton.Text = "Utilisateurs: Encoder les mots de passe";
            // 
            // appStatusStrip
            // 
            appStatusStrip.Items.AddRange(new Telerik.WinControls.RadItem[] { radLabelElement1, taskWaitingBarElement });
            appStatusStrip.Location = new Point(0, 509);
            appStatusStrip.Margin = new Padding(19, 19, 19, 19);
            appStatusStrip.Name = "appStatusStrip";
            appStatusStrip.Size = new Size(1374, 31);
            appStatusStrip.TabIndex = 2;
            // 
            // radLabelElement1
            // 
            radLabelElement1.Name = "radLabelElement1";
            appStatusStrip.SetSpring(radLabelElement1, false);
            radLabelElement1.Text = "Traitement";
            radLabelElement1.TextWrap = true;
            // 
            // taskWaitingBarElement
            // 
            taskWaitingBarElement.AutoSize = false;
            taskWaitingBarElement.Bounds = new Rectangle(0, 0, 66, 23);
            taskWaitingBarElement.Name = "taskWaitingBarElement";
            appStatusStrip.SetSpring(taskWaitingBarElement, false);
            taskWaitingBarElement.Text = "Traitement en cours";
            // 
            // taskPanel
            // 
            taskPanel.Controls.Add(saveUsersButton);
            taskPanel.Controls.Add(hasUserPasswordButton);
            taskPanel.Dock = DockStyle.Left;
            taskPanel.Location = new Point(0, 0);
            taskPanel.Margin = new Padding(10, 10, 10, 10);
            taskPanel.Name = "taskPanel";
            taskPanel.Size = new Size(578, 509);
            taskPanel.TabIndex = 4;
            // 
            // reportPanel
            // 
            reportPanel.AutoScroll = true;
            reportPanel.Controls.Add(reportLabel);
            reportPanel.Dock = DockStyle.Fill;
            reportPanel.Location = new Point(578, 0);
            reportPanel.Margin = new Padding(10, 10, 10, 10);
            reportPanel.Name = "reportPanel";
            reportPanel.Size = new Size(796, 509);
            reportPanel.TabIndex = 5;
            // 
            // reportLabel
            // 
            reportLabel.AutoScroll = true;
            reportLabel.AutoSize = false;
            reportLabel.Dock = DockStyle.Fill;
            reportLabel.Location = new Point(0, 0);
            reportLabel.Margin = new Padding(12, 15, 12, 15);
            reportLabel.Name = "reportLabel";
            reportLabel.Size = new Size(796, 509);
            reportLabel.TabIndex = 80;
            // 
            // MainForm
            // 
            AutoScaleBaseSize = new Size(8, 20);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 540);
            Controls.Add(reportPanel);
            Controls.Add(taskPanel);
            Controls.Add(appStatusStrip);
            Name = "MainForm";
            Text = "SchoolAppUpdate";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)saveUsersButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)hasUserPasswordButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)appStatusStrip).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskPanel).EndInit();
            taskPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)reportPanel).EndInit();
            reportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)reportLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Telerik.WinControls.UI.RadButton saveUsersButton;
        private Telerik.WinControls.UI.RadButton hasUserPasswordButton;
        private Telerik.WinControls.UI.RadStatusStrip appStatusStrip;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadWaitingBarElement taskWaitingBarElement;
        private Telerik.WinControls.UI.RadPanel taskPanel;
        private Telerik.WinControls.UI.RadPanel reportPanel;
        private Telerik.WinControls.UI.RadLabel reportLabel;
    }
}
