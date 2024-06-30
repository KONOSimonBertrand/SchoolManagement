namespace SchoolManagement.UI.CustomControls
{
    partial class DateNavigator
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            dateLabel = new Telerik.WinControls.UI.RadLabel();
            navigatorDateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            leftNavigationButton = new Telerik.WinControls.UI.RadButton();
            rightNavigationButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)dateLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigatorDateTimePicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftNavigationButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightNavigationButton).BeginInit();
            SuspendLayout();
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = false;
            dateLabel.Dock = DockStyle.Fill;
            dateLabel.Location = new Point(52, 0);
            dateLabel.Margin = new Padding(4, 5, 4, 5);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(189, 30);
            dateLabel.TabIndex = 6;
            // 
            // navigatorDateTimePicker
            // 
            navigatorDateTimePicker.AutoSize = false;
            navigatorDateTimePicker.Dock = DockStyle.Left;
            navigatorDateTimePicker.Location = new Point(0, 0);
            navigatorDateTimePicker.Margin = new Padding(4, 5, 4, 5);
            navigatorDateTimePicker.Name = "navigatorDateTimePicker";
            navigatorDateTimePicker.Size = new Size(52, 30);
            navigatorDateTimePicker.TabIndex = 7;
            navigatorDateTimePicker.TabStop = false;
            navigatorDateTimePicker.Text = "jeudi 18 mai 2017";
            navigatorDateTimePicker.Value = new DateTime(2017, 5, 18, 15, 37, 25, 339);
            // 
            // leftNavigationButton
            // 
            leftNavigationButton.Dock = DockStyle.Right;
            leftNavigationButton.Location = new Point(241, 0);
            leftNavigationButton.Margin = new Padding(4, 5, 4, 5);
            leftNavigationButton.Name = "leftNavigationButton";
            leftNavigationButton.Size = new Size(37, 30);
            leftNavigationButton.TabIndex = 5;
            // 
            // rightNavigationButton
            // 
            rightNavigationButton.Dock = DockStyle.Right;
            rightNavigationButton.Location = new Point(278, 0);
            rightNavigationButton.Margin = new Padding(4, 5, 4, 5);
            rightNavigationButton.Name = "rightNavigationButton";
            rightNavigationButton.Size = new Size(37, 30);
            rightNavigationButton.TabIndex = 4;
            // 
            // DateNavigator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateLabel);
            Controls.Add(navigatorDateTimePicker);
            Controls.Add(leftNavigationButton);
            Controls.Add(rightNavigationButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DateNavigator";
            Size = new Size(315, 30);
            ((System.ComponentModel.ISupportInitialize)dateLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigatorDateTimePicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftNavigationButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightNavigationButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Telerik.WinControls.UI.RadLabel dateLabel;
        private Telerik.WinControls.UI.RadDateTimePicker navigatorDateTimePicker;
        private Telerik.WinControls.UI.RadButton leftNavigationButton;
        private Telerik.WinControls.UI.RadButton rightNavigationButton;


    }
}
