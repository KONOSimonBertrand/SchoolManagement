
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class AddRatingSystemForm : SchoolManagement.UI.EditRatingSystemForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IRatingSystemService ratingSystemService;
        public AddRatingSystemForm(IRatingSystemService ratingSystemService, ILogService logService, ClientApp clientApp)
        {
            this.ratingSystemService = ratingSystemService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ClientSize);
            if (IsValidData())
            {
                if (!RatingSystemExist(FrenchNameDropDownList.Text))
                {
                    RatingSystem ratingSystem = new();
                    ratingSystem.FrenchName = FrenchNameDropDownList.Text;
                    ratingSystem.EnglishName = FrenchNameDropDownList.Text;
                    ratingSystem.FrenchDescription = FrenchNameDropDownList.Text;
                    ratingSystem.EnglishDescription = FrenchNameDropDownList.Text;
                    ratingSystem.MinNote = double.Parse(MinNoteTextBox.Text);
                    ratingSystem.MaxNote = double.Parse(MaxNoteTextBox.Text);
                    ratingSystem.Domain = DomainDropDownList.Text;
                    var isDone = ratingSystemService.CreateRatingSystem(ratingSystem).Result;
                    if (isDone)
                    {
                        Log log = new()
                        {
                            UserAction = $"Ajout du  système d'appréciation {ratingSystem.FrenchName}/{ratingSystem.EnglishName} ",
                            UserId = clientApp.UserConnected.Id
                        };
                        logService.CreateLog(log);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.ErrorLabel.Text = Language.messageAddError;
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
            var item = Program.RatingSystemList.FirstOrDefault(x => x.FrenchName == frenchName);
            if (item != null) return true;
            return ratingSystemService.GetRatingSystem(frenchName).Result != null;
        }
    }
}
