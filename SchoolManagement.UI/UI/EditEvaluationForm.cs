﻿
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SchoolManagement.UI.Utilities;

namespace SchoolManagement.UI
{
    public partial class EditEvaluationForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        public RadTextBox FrenchNameTextBox { get => nameFrTextBox; }
        public RadTextBox EnglishTextBox { get=>nameEnTextBox; }
        public RadTextBox CodeTextBox { get => codeTextBox; }
        public RadSpinEditor SequenceSpinEditor {  get => sequenceSpinEditor; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public EditEvaluationForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }

        private void InitComponent()
        {
            this.nameFrLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameFrLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameFrLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameEnLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameEnLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameEnLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.codeLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.codeLabel.LabelElement.CustomFontSize = 10.5f;
            this.codeLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.codeLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameFrTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameFrTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameFrTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.nameEnTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.nameEnTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameEnTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.codeTextBox.TextBoxElement.CustomFont = ViewUtilities.MainFont;
            this.codeTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.codeTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceSpinEditor.SpinElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceSpinEditor.SpinElement.CustomFontSize = 10.5f;
            this.sequenceSpinEditor.ForeColor = Color.FromArgb(33, 33, 33);

            this.sequenceLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            this.sequenceLabel.LabelElement.CustomFontSize = 10.5f;
            this.sequenceLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.sequenceLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.nameFrLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.nameEnLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.nameFrTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.nameEnTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.codeTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameFrSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.nameEnSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.codeSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.sequenceSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = ViewUtilities.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            this.errorLabel.ForeColor = Color.Red;

        }

        private void InitEvent()
        {
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if (this.nameFrTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la désignation est requise!";
                this.nameFrTextBox.Focus();
                return false;
            }
            if (this.codeTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de l'abréviation de la désignation est requise!";
                this.codeTextBox.Focus();
                return false;
            }
            if (this.nameEnTextBox.Text == "")
            {
                this.errorLabel.Text = "La saisie de la désignation anglaise est requise!";
                this.nameEnTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
