
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class EditRatingSystemForm : SchoolManagement.UI.EditRatingSystemForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private string ratingSystemNameTracker;
        private readonly IRatingSystemService ratingSystemService;
        private RatingSystem ratingSystem;
        public EditRatingSystemForm(IRatingSystemService ratingSystemService, ILogService logService, ClientApp clientApp)
        {
            this.ratingSystemService = ratingSystemService;
            this.logService = logService;
            this.clientApp = clientApp;
            ratingSystemNameTracker = string.Empty;
            InitEvents();
            this.Text = Language.titleRatingSystemUpdate.ToUpper();
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            FrenchNameDropDownList.Focus();
        }
        internal void Init(RatingSystem ratingSystem)
        {
            this.ratingSystem = ratingSystem;
            ratingSystemNameTracker = ratingSystem.FrenchName;
            FrenchNameDropDownList.Text = ratingSystem.FrenchName;
            EnglishNameDropDownList.Text = ratingSystem.EnglishName;
            FrenchDescriptionDropDownList.Text = ratingSystem.FrenchDescription;
            EnglishDescriptionDropDownList.Text = ratingSystem.EnglishDescription;
            MaxNoteTextBox.Text = ratingSystem.MaxNote.ToString();
            MinNoteTextBox.Text = ratingSystem.MinNote.ToString();
            DomainDropDownList.SelectedValue = ratingSystem.Domain;


        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (!RatingSystemExist(FrenchNameDropDownList.Text))
                {
                    ratingSystem.FrenchName = FrenchNameDropDownList.Text;
                    ratingSystem.EnglishName = FrenchNameDropDownList.Text;
                    ratingSystem.FrenchDescription = FrenchNameDropDownList.Text;
                    ratingSystem.EnglishDescription = FrenchNameDropDownList.Text;
                    ratingSystem.MinNote = double.Parse(MinNoteTextBox.Text);
                    ratingSystem.MaxNote = double.Parse(MaxNoteTextBox.Text);
                    ratingSystem.Domain = DomainDropDownList.Text;
                    var isDone = ratingSystemService.UpdateRatingSystem(ratingSystem).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Mise à jour du  système d'appréciation {ratingSystem.FrenchName}/{ratingSystem.EnglishName} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageUpdateError;
                    }
                }
                else
                {
                    this.ErrorLabel.Text = Language.messageRatingSystemExist;
                }
            }
        }
        private bool RatingSystemExist(string frenchName)
        {
            if (ratingSystemNameTracker == frenchName) return false;
            var item = Program.RatingSystemList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return ratingSystemService.GetRatingSystem(frenchName).Result != null;
        }
    }
}
