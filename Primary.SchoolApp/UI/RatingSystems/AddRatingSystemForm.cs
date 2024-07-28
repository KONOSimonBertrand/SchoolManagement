
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    public partial class AddRatingSystemForm : SchoolManagement.UI.EditRatingSystemForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IRatingSystemService ratingSystemService;
        public AddRatingSystemForm(IRatingSystemService ratingSystemService, ILogService logService, ClientApp clientApp)
        {
            InitializeComponent();
            this.ratingSystemService = ratingSystemService;
            this.logService = logService;
            this.clientApp = clientApp;
            InitEvents();
            this.Text = "AJOUT:.SYSTEME APPRECIATION";
        }

        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClientSize = new System.Drawing.Size(967, 361);
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
                        this.ErrorLabel.Text = "Erreur d'enregistrement";
                    }
                }
                else
                {
                    this.ErrorLabel.Text = "Ce système existe déjà ";
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
