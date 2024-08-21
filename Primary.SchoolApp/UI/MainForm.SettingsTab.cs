
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.UI.CustomControls;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private SchoolYearInfo schoolYearInfo;
        private SchoolGroupInfo schoolGroupInfo;
        private SchoolClassInfo schoolClassInfo;
        private SchoolRoomInfo schoolRoomInfo;
        private CashFlowTypeInfo cashFlowTypeInfo;
        private PaymentMeanInfo paymentMeanInfo;
        private SchoolingCostInfo schoolingCostInfo;
        private SubscriptionFeesInfo subscriptionFeeInfo;
        private SubjectGroupInfo subjectGroupInfo;
        private SubjectInfo subjectInfo;
        private EvaluationSessionInfo evaluationSessionInfo;
        private RatingSystemInfo ratingSystemInfo;
        private JobInfo jobInfo;
        private EmployeeGroupInfo employeeGroupInfo;
        private UserInfo userInfo;
        private bool isFirstLoadingBasicData = false;//  détermine si c'est le premier chargement des données de base
        private readonly List<UserControl> settingPageUserControlList = new();
       
        private void InitSettingPage()
        {
            InitSettingPageComponents();
            InitSettingPageCustomControls();
            InitSettingModule();
            InitSettingPageEvents();
        }
        //initialisation des composantes de la page setting
        private void InitSettingPageComponents()
        {
            SettingExportToExcelButton.Enabled = false;
            SettingGridView.ReadOnly = true;
            SettingGridView.EnableFiltering = true;
            SettingGridView.EnableCustomFiltering = true;
            SettingGridView.ShowFilteringRow = false;
            SettingGridView.AutoGenerateColumns = false;
        }
        //initialisation des modules a afficher sur la page setting
        private void InitSettingModule()
        {
            ListViewDataItemGroup settingGroup = new()
            {
                Text = Language.labelSettings.ToUpper()
            };
            this.SettingLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { settingGroup });
            ListViewDataItem itemSchoolYear = new()
            {
                Key = 1,
                Value = Language.labelSchoolYears
            };
            ListViewDataItem itemGroup = new()
            {
                Key = 2,
                Value = Language.labelClassGroups
            };
            ListViewDataItem itemClass = new()
            {
                Key = 3,
                Value = Language.labelClasss
            };
            ListViewDataItem itemRoom = new()
            {
                Key = 4,
                Value = Language.labelRooms
            };
            ListViewDataItem itemCashFlowSetting = new()
            {
                Key = 5,
                Value = Language.labelCashFlowTypes
            };
            ListViewDataItem itemPaymentMean = new()
            {
                Key = 6,
                Value = Language.labelPaymentMeans
            };
            ListViewDataItem itemSchoolingCost = new()
            {
                Key = 7,
                Value = Language.labelSchoolingFee
            };
            ListViewDataItem itemSubscriptionFees = new()
            {
                Key = 8,
                Value = Language.labelSubscriptionFee
            };
            ListViewDataItem itemSubjectGroup = new()
            {
                Key = 9,
                Value = Language.labelSubjectGroups
            };
            ListViewDataItem itemSubject = new()
            {
                Key = 10,
                Value = Language.labelSubjects
            };
            ListViewDataItem itemEvaluationSession = new()
            {
                Key = 11,
                Value = Language.labelEvaluationSessions
            };
            ListViewDataItem itemEvaluationSystem = new()
            {
                Key = 12,
                Value = Language.labelMarkSystems
            };
            ListViewDataItem itemJob = new()
            {
                Key = 13,
                Value =Language.labelTypeJobs
            };
            ListViewDataItem itemEmployeeGroup = new()
            {
                Key = 14,
                Value = Language.labelEmployeeGroups
            };
            ListViewDataItem itemUser = new()
            {
                Key = 15,
                Value = Language.labelUsers
            };
           


            itemSchoolYear.Group = settingGroup;
            itemGroup.Group = settingGroup;
            itemClass.Group = settingGroup;
            itemSchoolingCost.Group = settingGroup;
            itemPaymentMean.Group = settingGroup;
            itemCashFlowSetting.Group = settingGroup;
            itemSubjectGroup.Group = settingGroup;
            itemSubject.Group = settingGroup;
            itemEvaluationSession.Group = settingGroup;
            itemEvaluationSystem.Group = settingGroup;
            itemJob.Group = settingGroup;
            itemEmployeeGroup.Group = settingGroup;
            itemUser.Group = settingGroup;
            itemSubscriptionFees.Group = settingGroup;
            SettingLeftListView.Items.Add(itemSchoolYear);
            SettingLeftListView.Items.Add(itemGroup);
            SettingLeftListView.Items.Add(itemClass);
            SettingLeftListView.Items.Add(itemRoom);
            SettingLeftListView.Items.Add(itemCashFlowSetting);
            SettingLeftListView.Items.Add(itemPaymentMean);
            SettingLeftListView.Items.Add(itemSchoolingCost);
            SettingLeftListView.Items.Add(itemSubscriptionFees);
            SettingLeftListView.Items.Add(itemSubjectGroup);
            SettingLeftListView.Items.Add(itemSubject);
            SettingLeftListView.Items.Add(itemEvaluationSession);
            SettingLeftListView.Items.Add(itemEvaluationSystem);
            SettingLeftListView.Items.Add(itemJob);
            SettingLeftListView.Items.Add(itemEmployeeGroup);
            SettingLeftListView.Items.Add(itemUser);

            SettingSearchModuleDropDownList.Items.Add(itemGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemClass.Text);
            SettingSearchModuleDropDownList.Items.Add(itemRoom.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolYear.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolingCost.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubscriptionFees.Text);
            SettingSearchModuleDropDownList.Items.Add(itemCashFlowSetting.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubject.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationSession.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationSystem.Text);
            SettingSearchModuleDropDownList.Items.Add(itemJob.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEmployeeGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemUser.Text);
            SettingLeftListView.ShowCheckBoxes = false;
            SettingLeftListView.SelectedIndex = 0;
        }
        //initialisation des contrôles utilisateurs personnalisés 
        private void InitSettingPageCustomControls()
        {

            schoolYearInfo = new SchoolYearInfo
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolYearInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            schoolYearInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(schoolYearInfo);
            settingPageUserControlList.Add(schoolYearInfo);
            schoolGroupInfo = new SchoolGroupInfo
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolGroupInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            schoolGroupInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolGroupInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(schoolGroupInfo);
            settingPageUserControlList.Add(schoolGroupInfo);
            schoolClassInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolClassInfo.SubjectsCountLabel.DoubleClick += MenuShowSubjectOfClass_Click;
            schoolClassInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            schoolClassInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(schoolClassInfo);
            settingPageUserControlList.Add(schoolClassInfo);
            schoolRoomInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolRoomInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            schoolRoomInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(schoolRoomInfo);
            settingPageUserControlList.Add(schoolRoomInfo);
            cashFlowTypeInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            cashFlowTypeInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            cashFlowTypeInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(cashFlowTypeInfo);
            settingPageUserControlList.Add(cashFlowTypeInfo);
            paymentMeanInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            paymentMeanInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            paymentMeanInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(paymentMeanInfo);
            settingPageUserControlList.Add(paymentMeanInfo);
            schoolingCostInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            schoolingCostInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            schoolingCostInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(schoolingCostInfo);
            settingPageUserControlList.Add(schoolingCostInfo);

            subscriptionFeeInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            subscriptionFeeInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            subscriptionFeeInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(subscriptionFeeInfo);
            settingPageUserControlList.Add(subscriptionFeeInfo);

            // add subjectGroupInfo control user
            subjectGroupInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            subjectGroupInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            subjectGroupInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(subjectGroupInfo);
            settingPageUserControlList.Add(subjectGroupInfo);
            // add subjectInfo control user
            subjectInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            subjectInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            subjectInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(subjectInfo);
            settingPageUserControlList.Add(subjectInfo);
            //add evaluation type user control
            evaluationSessionInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            evaluationSessionInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            evaluationSessionInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(evaluationSessionInfo);
            settingPageUserControlList.Add(evaluationSessionInfo);
            //add rating system user control
            ratingSystemInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            ratingSystemInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            ratingSystemInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(ratingSystemInfo);
            settingPageUserControlList.Add(ratingSystemInfo);
            //add job info user control
            jobInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            jobInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            jobInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(jobInfo);
            settingPageUserControlList.Add(jobInfo);
            //add employee group info user control
            employeeGroupInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            employeeGroupInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            employeeGroupInfo.EditButton.Click += SettingEditButton_Click;
            SettingInfoRightPanel.Controls.Add(employeeGroupInfo);
            settingPageUserControlList.Add(employeeGroupInfo);
            //add user info user control
            userInfo = new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };
            userInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                SettingInfoRightPanel.Visible = false;
            };
            userInfo.EditButton.Click += SettingEditButton_Click;
            userInfo.ModuleCount.DoubleClick += MenuShowUserModule_Click;
            userInfo.RoomCount.DoubleClick += MenuShowUserRoom_Click;
            SettingInfoRightPanel.Controls.Add(userInfo);
            settingPageUserControlList.Add(userInfo);
        }
        //initialise les évenements relatifs aux contrôles Windows Forms de la page setting
        private void InitSettingPageEvents()
        {
            SettingSearchTextBox.TextChanged += SettingSearchTextBox_TextChanged;
            SettingLeftListView.SelectedItemChanged += SettingLeftListView_SelectedItemChanged;
            SettingGridView.CurrentRowChanged += SettingGridView_CurrentRowChanged;
            SettingGridView.CustomFiltering += SettingGridView_CustomFiltering;
            SettingSearchModuleDropDownList.SelectedIndexChanged += SettingSearchModuleDropDownList_SelectedIndexChanged;
            SettingGridView.ContextMenuOpening += SettingGridView_ContextMenuOpening;
            SettingAddButton.Click += SettingAddButton_Click;
            //déclenche l'évenement  SettingLeftListView.SelectedItemChanged pour un premier affichage
            SettingLeftListView.SelectedItem = null;
            SettingLeftListView.SelectedItem = SettingLeftListView.Items.FirstOrDefault();
        }

        #region Methodes
        // affiche les informations d'une année scolaire sur le contrôle personnalisé SchoolYearInfo
        private void LoadSelectedSchoolYearDetail(SchoolYear schoolYear)
        {
            schoolYearInfo.TitleInfoLabel.Text = "INFO ...";
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter.ToString();
            schoolYearInfo.NameTextBox.Text = schoolYear.Name;
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter?.ToString("dd/MM/yyyy");
            schoolYearInfo.EndDateTextBox.Text = schoolYear.EndThirdQuarter?.ToString("dd/MM/yyyy");
        }
        // affiche les info d'un group de classe
        private void LoadSelectedSchoolGroupDetail(SchoolGroup schoolGroup)
        {
            schoolGroupInfo.TitleInfoLabel.Text = "INFO ...";
            schoolGroupInfo.NameTextBox.Text = schoolGroup.Name;

        }
        // affiche les info d'une classe
        private void LoadSelectedSchoolClassDetail(SchoolClass schoolClass)
        {
            schoolClassInfo.TitleInfoLabel.Text = "INFO ...";
            schoolClassInfo.NameTextBox.Text = schoolClass.Name;
            schoolClassInfo.GroupTextBox.Text = schoolClass.Group.Name;
            schoolClassInfo.SubjectsCountLabel.Text =  Language.labelSubjectTaught+": "+ schoolClassService.GetClassSubjectList(schoolClass.Id).Result.Count;
        }
        // affiche les info d'une salle classe
        private void LoadSelectedSchoolRoomDetail(SchoolRoom room)
        {
            schoolRoomInfo.TitleInfoLabel.Text = "INFO ...";
            if (room != null)
            {
                schoolRoomInfo.NameTextBox.Text = room.Name;
                schoolRoomInfo.ClassTextBox.Text = room.SchoolClass.Name;
            }
        }
        // affiche les info d'un type de trésorerie
        private void LoadSelectedCashFlowTypeDetail(CashFlowType cashFlowType)
        {
            cashFlowTypeInfo.TitleInfoLabel.Text = "INFO";
            if (cashFlowType != null)
            {
                cashFlowTypeInfo.NameTextBox.Text = cashFlowType.Name;
                cashFlowTypeInfo.CategoryTextBox.Text = cashFlowType.CategoryName;
                cashFlowTypeInfo.TypeTextBox.Text = cashFlowType.TypeName;
            }
        }
        // affiche les info d'un moyen de paiement
        private void LoadSelectedPaymentMeanDetail(PaymentMean paymentMean)
        {
            paymentMeanInfo.TitleInfoLabel.Text = "INFO ...";
            if (paymentMean != null)
            {
                paymentMeanInfo.NameTextBox.Text = paymentMean.Name;
                paymentMeanInfo.AccountTextBox.Text = paymentMean.Account;
                paymentMeanInfo.TypeTextBox.Text = paymentMean.Type;
            }
        }
        // affiche les info d'un frais scolaire
        private void LoadSelectedSchoolingCostDetail(SchoolingCost cost)
        {
            schoolingCostInfo.TitleInfoLabel.Text = "INFO ...";
            if (cost != null)
            {
                var getData = schoolingCostService.GetSchoolingCostItems(cost.Id);
                schoolingCostInfo.SchoolYearTextBox.Text = cost.SchoolYear.Name;
                schoolingCostInfo.ClassTextBox.Text = cost.SchoolClass.Name;
                schoolingCostInfo.CostTypeTextBox.Text = cost.CashFlowType.Name;
                schoolingCostInfo.TrancheNumberTextBox.Text = cost.TrancheNumber.ToString();
                schoolingCostInfo.AmountTextBox.Text = cost.Amount.ToString();
                int i = 1;
                schoolingCostInfo.TrancheNumberTextBox.TextBoxElement.ToolTipText = string.Empty;
                schoolingCostInfo.TranchesLabel.Text = string.Empty;
                schoolingCostInfo.TranchesLabel.TextAlignment = ContentAlignment.TopCenter;
                schoolingCostInfo.TranchesLabel.Text = $"***********{Language.labelInstallments}***********\n";
                foreach (var line in getData.Result)
                {
                    schoolingCostInfo.TrancheNumberTextBox.TextBoxElement.ToolTipText += "N°: " +
                          i + " "+Language.labelAmount+": " + line.Amount + " "+ Language.labelDuration+": " + line.DeadLine.ToString("dd - MM - yyyy") + "\n";
                    schoolingCostInfo.TranchesLabel.Text += i + "- " + line.Amount + " "+Language.labelDelay + ": " + line.DeadLine.ToString("dd - MM - yyyy") + "\n";
                    i++;
                }
            }
        }
        // affiche les info d'un frais d'abonnement
        private void LoadSelectedSubscriptionFeeDetail(SubscriptionFee subscriptionFee)
        {
            subscriptionFeeInfo.TitleInfoLabel.Text = "INFO..." ;
            if (subscriptionFee != null)
            {
                subscriptionFeeInfo.SchoolYearTextBox.Text = subscriptionFee.SchoolYear.Name;
                subscriptionFeeInfo.SubscriptionTypeTextBox.Text = subscriptionFee.CashFlowType.Name;
                subscriptionFeeInfo.AmountTextBox.Text = subscriptionFee.Amount.ToString();
            }
        }
        // affiche les info d'un groupe de matières
        private void LoadSelectedSubjectGroupDetail(SubjectGroup subjectGroup)
        {
            if (subjectGroup != null)
            {
                subjectGroupInfo.TitleInfoLabel.Text = "INFO...";
                subjectGroupInfo.NameTextBox.Text = subjectGroup.FullName;
            }
        }
        // affiche les info d'une de matière
        private void LoadSelectedSubjectDetail(Subject subject)
        {
            if (subject != null)
            {
                subjectInfo.TitleInfoLabel.Text = "INFO...";
                subjectInfo.NameTextBox.Text = subject.FullName;
            }
        }
        // affiche les info d'une session d'évaluation
        private void LoadSelectedEvaluationSesssionDetail(EvaluationSession evaluationSession)
        {
            if (evaluationSession != null)
            {
                evaluationSessionInfo.TitleInfoLabel.Text = "INFO...";
                evaluationSessionInfo.NameTextBox.Text = evaluationSession.DefaultName;
            }
        }
        // affiche les info d'un système d'appréciation
        private void LoadSelectedRatingSystemDetail(RatingSystem ratingSystem)
        {
            if (ratingSystem != null)
            {
                ratingSystemInfo.TitleInfoLabel.Text = "INFO...";
                ratingSystemInfo.NameTextBox.Text = ratingSystem.DefaultName;
                ratingSystemInfo.MaxNoteTextBox.Text = ratingSystem.MaxNote.ToString();
                ratingSystemInfo.MinNoteTextBox.Text = ratingSystem.MinNote.ToString();
            }
        }
        // affiche les info d'une fonction employé
        private void LoadSelectedJobDetail(Job job)
        {
            if (job != null)
            {
                jobInfo.TitleInfoLabel.Text = "INFO...";
                jobInfo.NameTextBox.Text = job.Name;
            }
        }
        // affiche les info d'un groupe employé
        private void LoadSelectedEmployeeGroupDetail(EmployeeGroup group)
        {
            if (group != null)
            {
                employeeGroupInfo.TitleInfoLabel.Text = "INFO...";
                employeeGroupInfo.NameTextBox.Text = group.Name;
            }
        }
        // affiche les info d'un utilisateur 
        private void LoadSelectedUserDetail(User user)
        {
            if (user != null)
            {
                userInfo.TitleInfoLabel.Text = "INFO...";
                userInfo.NameTextBox.Text = user.Name;
                userInfo.LoginTextBox.Text = user.UserName;
                var modules = userService.GetUserModuleList(user.Id).Result;
                var rooms = userService.GetUserRoomList(user.Id).Result;
                var defautModule = modules.FirstOrDefault(m => m.IsDefault == true);
                userInfo.DefaultModuleTextBox.Text = defautModule != null ? defautModule.Module.Name : string.Empty;
                userInfo.ModuleCount.Text = $"{Language.labelModules}: {modules.Count.ToString()}/ {Program.ModuleList.Count}";
                userInfo.ModuleCount.Image = Utilities.AppUtilities.GetImage("Eye");
                userInfo.RoomCount.Text = $"{Language.labelRooms}: {rooms.Count.ToString()}/{Program.SchoolRoomList.Count}";
                userInfo.RoomCount.Image = Utilities.AppUtilities.GetImage("Eye");
            }
        }
        //chargement la liste des années scolaires dans le datagridview de la page setting
        private async void LoadSchoolYearListToSettingGridView()
        {
            var getData = schoolYearService.GetSchoolYearList();
            CreateSchoolYearColumnsForSettingGridView();
            //chargement des données
            Program.SchoolYearList = await getData;
            SettingGridView.DataSource = Program.SchoolYearList;
        }
        private void CreateSchoolYearColumnsForSettingGridView()
        {
            GridViewTextBoxColumn yearNameColum = new("Name");
            GridViewDateTimeColumn startFirstQuarterColum = new("StartFirstQuarter");
            GridViewDateTimeColumn endFirstQuarterColum = new("EndFirstQuarter");
            GridViewDateTimeColumn startSecondQuarterColum = new("StartSecondQuarter");
            GridViewDateTimeColumn endSecondQuarterColum = new("EndSecondQuarter");
            GridViewDateTimeColumn startThirdQuarterColum = new("StartThirdQuarter");
            GridViewDateTimeColumn endThirdQuarterColum = new("EndThirdQuarter");
            GridViewTextBoxColumn yearStateColum = new("State");
            startFirstQuarterColum.Format = DateTimePickerFormat.Custom;
            startFirstQuarterColum.CustomFormat = "dd/MM/yyyy";
            startFirstQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            endFirstQuarterColum.Format = DateTimePickerFormat.Custom;
            endFirstQuarterColum.CustomFormat = "dd/MM/yyyy";
            endFirstQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            startSecondQuarterColum.Format = DateTimePickerFormat.Custom;
            startSecondQuarterColum.CustomFormat = "dd/MM/yyyy";
            startSecondQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            endSecondQuarterColum.Format = DateTimePickerFormat.Custom;
            endSecondQuarterColum.CustomFormat = "dd/MM/yyyy";
            endSecondQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            startThirdQuarterColum.Format = DateTimePickerFormat.Custom;
            startThirdQuarterColum.CustomFormat = "dd/MM/yyyy";
            startThirdQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            endThirdQuarterColum.Format = DateTimePickerFormat.Custom;
            endThirdQuarterColum.CustomFormat = "dd/MM/yyyy";
            endThirdQuarterColum.FormatString = "{0:dd/MM/yyyy}";
            yearNameColum.HeaderText = Language.labelDesignation;
            startFirstQuarterColum.HeaderText = Language.labelStartFirstQuarter;
            endFirstQuarterColum.HeaderText = Language.labelEndFirstQuarter;
            startSecondQuarterColum.HeaderText = Language.labelStartSecondQuarter;
            endSecondQuarterColum.HeaderText = Language.labelEndSecondQuarter;
            startThirdQuarterColum.HeaderText = Language.labelStartThirdQuarter;
            endThirdQuarterColum.HeaderText = Language.labelEndThirdQuarter;
            yearStateColum.HeaderText = Language.labelStatut;
            SettingGridView.Columns.Add(yearNameColum);
            SettingGridView.Columns.Add(startFirstQuarterColum);
            SettingGridView.Columns.Add(endFirstQuarterColum);
            SettingGridView.Columns.Add(startSecondQuarterColum);
            SettingGridView.Columns.Add(endSecondQuarterColum);
            SettingGridView.Columns.Add(startThirdQuarterColum);
            SettingGridView.Columns.Add(endThirdQuarterColum);
            SettingGridView.Columns.Add(yearStateColum);
        }
        //chargement des groupes de classes dans le datagridview de la page setting
        private async void LoadSchoolGroupListToSettingGridView()
        {
            var getData = schoolGroupService.GetSchoolGroupList();
            CreateSchoolGroupColumnsForSettingGridView();
            Program.SchoolGroupList = await getData;
            SettingGridView.DataSource = Program.SchoolGroupList;

        }
        private void CreateSchoolGroupColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = Language.labelDesignation;
            sequenceColum.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(sequenceColum);
        }
        //chargement des  classes dans le datagridview de la page setting
        private async void LoadSchoolClassListToSettingGridView()
        {
            var getData = schoolClassService.GetSchoolClassList();
            CreateSchoolClassColumnsForSettingGridView();
            Program.SchoolClassList = await getData;
            SettingGridView.DataSource = Program.SchoolClassList;

        }
        private void CreateSchoolClassColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn groupColum = new("Group.Name");
            GridViewTextBoxColumn bookColum = new("BookTypeName");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = Language.labelDesignation;
            groupColum.HeaderText = Language.labelGroup;
            bookColum.HeaderText = Language.labelBookModel;
            sequenceColum.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(groupColum);
            SettingGridView.Columns.Add(bookColum);
            SettingGridView.Columns.Add(sequenceColum);
        }
        //chargement des  salles de classe dans le datagridview de la page setting
        private async void LoadSchoolRoomListToSettingGridView()
        {
            var getData = schoolRoomService.GetSchoolRoomList();
            CreateSchoolRoomColumnsForSettingGridView();
            Program.SchoolRoomList = await getData;
            SettingGridView.DataSource = Program.SchoolRoomList;

        }
        private void CreateSchoolRoomColumnsForSettingGridView()
        {
            SettingGridView.MasterTemplate.Reset();
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn classColum = new("SchoolClass.Name");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = Language.labelDesignation;
            classColum.HeaderText = Language.labelClass;
            sequenceColum.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(classColum);
            SettingGridView.Columns.Add(sequenceColum);

        }
        //chargement des  types de flux de tresorerie dans le datagridview de la page setting
        private async void LoadCashFlowTypeListToSettingGridView()
        {
            var getData = cashFlowTypeService.GetCashFlowTypeList();
            CreateCashFlowTypeColumnsForSettingGridView();
            Program.CashFlowTypeList = await getData;
            SettingGridView.DataSource = Program.CashFlowTypeList;

        }
        private void CreateCashFlowTypeColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn classColum = new("CategoryName");
            GridViewTextBoxColumn typeColum = new("TypeName");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = Language.labelDesignation;
            classColum.HeaderText = Language.labelCategory;
            typeColum.HeaderText = Language.labelType;
            sequenceColum.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(classColum);
            SettingGridView.Columns.Add(typeColum);
            SettingGridView.Columns.Add(sequenceColum);
        }
        //chargement des  moyens de paiement dans le datagridview de la page setting
        private async void LoadPaymentMeanListToSettingGridView()
        {
            var getData = paymentMeanService.GetPaymentMeanList();
            CreatePaymentMeanColumnsForSettingGridView();
            Program.PaymentMeanList = await getData;
            SettingGridView.DataSource = Program.PaymentMeanList;

        }
        private void CreatePaymentMeanColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn accountColum = new("Account");
            GridViewTextBoxColumn typeColum = new(Language.labelType);
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = Language.labelDesignation;
            accountColum.HeaderText = Language.labelAccount;
            typeColum.HeaderText = Language.labelType;
            sequenceColum.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(accountColum);
            SettingGridView.Columns.Add(typeColum);
            SettingGridView.Columns.Add(sequenceColum);
        }
        //chargement des frais scolaires dans le datagridview de la page setting
        private async void LoadSchoolingCostListToSettingGridView()
        {
            var getData = schoolingCostService.GetSchoolingCostList();
            CreateSchoolingCostColumnsForSettingGridView();
            Program.SchoolingCostList = await getData;
            SettingGridView.DataSource = Program.SchoolingCostList;

        }
        private void CreateSchoolingCostColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn classColumn = new("SchoolClass.Name");
            GridViewTextBoxColumn costTypeColumn = new("CashFlowType.Name");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDecimalColumn trancheNumberColumn = new("TrancheNumber");
            GridViewCheckBoxColumn payableColumn = new("IsPayable");
            GridViewTextBoxColumn yearColumn = new("SchoolYear.Name");
            classColumn.HeaderText = Language.labelClass;
            costTypeColumn.HeaderText =Language.labelFeeType;
            amountColumn.HeaderText = Language.labelAmount;
            trancheNumberColumn.HeaderText = Language.labelTrancheNumber;
            payableColumn.HeaderText = Language.labelExigible;
            yearColumn.HeaderText = Language.labelSchoolYear;
            SettingGridView.Columns.Add(classColumn);
            SettingGridView.Columns.Add(costTypeColumn);
            SettingGridView.Columns.Add(amountColumn);
            SettingGridView.Columns.Add(trancheNumberColumn);
            SettingGridView.Columns.Add(payableColumn);
            SettingGridView.Columns.Add(yearColumn);
        }
        //chargement des frais d'abonnement dans le datagridview de la page setting
        private async void LoadSubscriptionFeeListToSettingGridView()
        {
            var getData = subscriptionFeeService.GetSubscriptionFeeList();
            CreateSubscriptionFeeColumnsForSettingGridView();
            Program.SubscriptionFeeList = await getData;
            SettingGridView.DataSource = Program.SubscriptionFeeList;

        }
        private void CreateSubscriptionFeeColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn subscriptionTypeColumn = new("CashFlowType.Name");
            GridViewDecimalColumn amountColumn = new("Amount");
            GridViewDecimalColumn durationColumn = new("Duration");
            GridViewTextBoxColumn yearColumn = new("SchoolYear.Name");
            subscriptionTypeColumn.HeaderText = Language.labelSubscription;
            amountColumn.HeaderText = Language.labelAmount;
            durationColumn.HeaderText = Language.labelDuration;
            yearColumn.HeaderText = Language.labelSchoolYear;
            SettingGridView.Columns.Add(subscriptionTypeColumn);
            SettingGridView.Columns.Add(amountColumn);
            SettingGridView.Columns.Add(durationColumn);
            SettingGridView.Columns.Add(yearColumn);
        }
        //chargement des groupes de matières dans le datagridview de la page setting
        private async void LoadSubjectGroupListToSettingGridView()
        {
            var getData = subjectGroupService.GetSubjectGroupList();
            CreateSubjectGroupColumnsForSettingGridView();
            Program.SubjectGroupList = await getData;
            SettingGridView.DataSource = Program.SubjectGroupList;

        }
        private void CreateSubjectGroupColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColumn = new(Language.fieldName);
            GridViewTextBoxColumn fullNameColumn = new GridViewTextBoxColumn("FullName");
            GridViewTextBoxColumn sequenceColumn = new("Sequence");
            nameColumn.HeaderText = Language.labelDesignation;
            fullNameColumn.HeaderText = Language.labelFullName;
            sequenceColumn.HeaderText = Language.labelSequence;
            SettingGridView.Columns.Add(nameColumn);
            SettingGridView.Columns.Add(fullNameColumn);
            SettingGridView.Columns.Add(sequenceColumn);
        }
        //chargement des matières dans le datagridview de la page setting
        private async void LoadSubjectListToSettingGridView()
        {
            var getData = subjectService.GetSubjectList();
            CreateSubjectColumnsForSettingGridView();
            Program.SubjectList = await getData;
            SettingGridView.DataSource = Program.SubjectList;

        }
        private void CreateSubjectColumnsForSettingGridView()
        {
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColumn = new(Language.fieldName);
            GridViewTextBoxColumn fullNameColumn = new GridViewTextBoxColumn("FullName");
            GridViewTextBoxColumn sequenceColumn = new("Sequence");
            nameColumn.HeaderText = Language.labelDesignation;
            sequenceColumn.HeaderText = Language.labelSequence;
            fullNameColumn.HeaderText = Language.labelFullName;
            SettingGridView.Columns.Add(nameColumn);
            SettingGridView.Columns.Add(fullNameColumn);
            SettingGridView.Columns.Add(sequenceColumn);
        }
        //chargement des sessions d'évaluation dans le datagridview de la page setting
        private async void LoadEvaluationSessionListToSettingGridView()
        {
            var getData = evaluationSessionService.GetEvaluationSessionList();
            CreateEvaluationSessionColumnsForSettingGridView();
            Program.EvaluationSessionList = await getData;
            SplitEvaluationSessionList();
            SettingGridView.MasterTemplate.DataSource = Program.EvaluationSessionParentList;
            SettingGridView.Templates[0].DataSource = Program.EvaluationSessionChildList;
            SettingGridView.Refresh();
            SettingGridView.BestFitColumns();
            SettingGridView.Templates[0].BestFitColumns();


        }
        private void CreateEvaluationSessionColumnsForSettingGridView()
        {
            using (SettingGridView.DeferRefresh())
            {
                SettingGridView.Columns.Clear();
                SettingGridView.Templates.Clear();
                SettingGridView.Relations.Clear();
                GridViewTextBoxColumn codeColumn = new("Code");
                GridViewTextBoxColumn nameColumn = new(Language.fieldName);
                GridViewTextBoxColumn sequenceColumn = new("Sequence");
                nameColumn.HeaderText = Language.labelDesignation;
                codeColumn.HeaderText = Language.labelCode;
                sequenceColumn.HeaderText = Language.labelSequence;
                codeColumn.IsVisible = false;
                SettingGridView.Columns.Add(codeColumn);
                SettingGridView.Columns.Add(nameColumn);
                SettingGridView.Columns.Add(sequenceColumn);

                //
                GridViewTemplate template = new GridViewTemplate();
                GridViewTextBoxColumn parentCodeColumn = new("ParentCode");
                GridViewTextBoxColumn childNameColumn = new(Language.fieldName);
                GridViewTextBoxColumn sequenceTColumn = new("Sequence");
                parentCodeColumn.HeaderText = Language.labelCode;
                childNameColumn.HeaderText = Language.labelDesignation;
                sequenceTColumn.HeaderText = Language.labelSequence;
                parentCodeColumn.IsVisible = false;
                template.Columns.Add(parentCodeColumn);
                template.Columns.Add(childNameColumn);
                template.Columns.Add(sequenceTColumn);
                SettingGridView.Templates.Add(template);

                GridViewRelation relation = new GridViewRelation(SettingGridView.MasterTemplate, template);
                relation.RelationName = "ParentChild";
                relation.ParentColumnNames.Add("Code");
                relation.ChildColumnNames.Add("ParentCode");
                this.SettingGridView.Relations.Add(relation);
            }

        }
        //chargement des systèmes d'appréciations dans le datagridview de la page setting
        private async void LoadRatingSystemListToSettingGridView()
        {
            var getData = ratingSystemService.GetRatingSystemList();
            CreateRatingSystemColumnsForSettingGridView();
            Program.RatingSystemList = await getData;
            SettingGridView.DataSource = Program.RatingSystemList;
            SettingGridView.BestFitColumns();
        }
        private void CreateRatingSystemColumnsForSettingGridView()
        {
            using (SettingGridView.DeferRefresh())
            {
                SettingGridView.Columns.Clear();
                GridViewTextBoxColumn nameColumn = new(Language.fieldName);
                GridViewTextBoxColumn descriptionColumn = new(Language.fieldDescription);
                GridViewDecimalColumn maxNoteColumn = new("MaxNote");
                GridViewDecimalColumn minNoteColumn = new("MinNote");
                nameColumn.HeaderText = Language.labelAppreciation;
                descriptionColumn.HeaderText = Language.labelDescription;
                maxNoteColumn.HeaderText = Language.labelMaxNote;
                minNoteColumn.HeaderText = Language.labelMinNote;
                SettingGridView.Columns.Add(nameColumn);
                SettingGridView.Columns.Add(descriptionColumn);
                SettingGridView.Columns.Add(maxNoteColumn);
                SettingGridView.Columns.Add(minNoteColumn);
            }

        }
        //chargement la liste des fonctions employé dans le datagridview de la page setting
        private async void LoadJobListToSettingGridView()
        {
            var getData = jobService.GetJobList();
            CreateJobColumnsForSettingGridView();
            //chargement des données
            Program.JobList = await getData;
            SettingGridView.DataSource = Program.JobList;
        }
        private void CreateJobColumnsForSettingGridView()
        {
            GridViewTextBoxColumn nameColumn = new("Name");
            nameColumn.HeaderText = Language.labelDesignation;
            SettingGridView.Columns.Add(nameColumn);
        }
        //chargement la liste des groupes employé dans le datagridview de la page setting
        private async void LoadEmployeeGroupListToSettingGridView()
        {
            var getData = employeeGroupService.GetEmployeeGroupList();
            CreateEmployeeGroupColumnsForSettingGridView();
            //chargement des données
            Program.EmployeeGroupList = await getData;
            SettingGridView.DataSource = Program.EmployeeGroupList;
        }
        private void CreateEmployeeGroupColumnsForSettingGridView()
        {
            GridViewTextBoxColumn nameColumn = new("Name");
            nameColumn.HeaderText = Language.labelDesignation;
            SettingGridView.Columns.Add(nameColumn);
        }
        //chargement la liste des utilisateurs dans le datagridview de la page setting
        private async void LoadUserListToSettingGridView()
        {
            var getData = userService.GetUserList();
            CreateUserColumnsForSettingGridView();
            //chargement des données
            Program.UserList = await getData;
            SettingGridView.DataSource = Program.UserList;
        }
        private void CreateUserColumnsForSettingGridView()
        {
            GridViewTextBoxColumn loginColumn = new("UserName");
            GridViewTextBoxColumn nameColumn = new("Name");
            loginColumn.HeaderText = Language.labelUser;
            nameColumn.HeaderText = Language.labelName;
            SettingGridView.Columns.Add(loginColumn);
            SettingGridView.Columns.Add(nameColumn);
        }
        // show school year UI for edit
        private void ShowSchoolYearEditForm(SchoolYear schoolYear)
        {
            if (schoolYear != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolYearForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSchoolYear;
                form.Icon = this.Icon;
                form.Init(schoolYear);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SchoolYear>();
                    SettingGridView.DataSource = Program.SchoolYearList;
                }
            }
            else
            {
                RadMessageBox.Show("Année scolaire inconnue");
            }
        }
        // show school year UI for add new 
        private void ShowSchoolYearAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolYearForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSchoolYear;
            form.Icon=this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolYearService.GetSchoolYear(form.NameTextBox.Text).Result;
                Program.SchoolYearList.Add(data);
                SettingGridView.DataSource = new List<SchoolYear>();
                SettingGridView.DataSource = Program.SchoolYearList;
            }
        }
        // show school group UI for edit
        private void ShowSchoolGroupEditForm(SchoolGroup schoolGroup)
        {
            if (schoolGroup != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelGroup;
                form.Icon = this.Icon;
                form.Init(schoolGroup);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SchoolGroup>();
                    SettingGridView.DataSource = Program.SchoolGroupList;
                }
            }
            else
            {
                RadMessageBox.Show("Groupe inconnu");
            }

        }
        // show school group UI for add new
        private void ShowSchoolGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelGroup;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolGroupService.GetSchoolGroup(form.NameTextBox.Text).Result;
                Program.SchoolGroupList.Add(data);
                SettingGridView.DataSource = new List<SchoolGroup>();
                SettingGridView.DataSource = Program.SchoolGroupList;
            }
        }
        // show school class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass schoolClass)
        {
            if (schoolClass != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.Init(schoolClass);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SchoolClass>();
                    SettingGridView.DataSource = Program.SchoolClassList;
                }
            }
            else
            {
                RadMessageBox.Show("Classe inconnue");
            }
        }
        // show school class UI to add new 
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClass;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolClassService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                SettingGridView.DataSource = new List<SchoolClass>();
                SettingGridView.DataSource = Program.SchoolClassList;
            }
        }
        // show school room UI for edit
        private void ShowSchoolRoomEditForm(SchoolRoom room)
        {
            if (room != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolRoomForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelRoom;
                form.Icon=this.Icon;
                form.Init(room);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SchoolRoom>();
                    SettingGridView.DataSource = Program.SchoolRoomList;
                }
            }
            else
            {
                RadMessageBox.Show("Salle de Classe inconnue");
            }
        }
        // show school room UI to add new 
        private void ShowSchoolRoomAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolRoomForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelRoom;
            form.Icon=this.Icon;
            
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolRoomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                Program.SchoolRoomList.Add(data);
                SettingGridView.DataSource = new List<SchoolRoom>();
                SettingGridView.DataSource = Program.SchoolRoomList;
            }
        }
        // show CashFlowType UI for edit
        private void ShowCashFlowTypeEditForm(CashFlowType type)
        {
            if (type != null)
            {
                var form = Program.ServiceProvider.GetService<EditCashFlowTypeForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelCashFlowType;
                form.Init(type);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<CashFlowType>();
                    SettingGridView.DataSource = Program.CashFlowTypeList;
                }
            }
            else
            {
                RadMessageBox.Show("Type de flux de trésorerie inconnu");
            }
        }
        // show  cashflowtype UI to add new 
        private void ShowCashFlowTypeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddCashFlowTypeForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelCashFlowType;
            form.Icon=this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = cashFlowTypeService.GetCashFlowType(form.NameTextBox.Text).Result;
                Program.CashFlowTypeList.Add(data);
                SettingGridView.DataSource = new List<CashFlowType>();
                SettingGridView.DataSource = Program.CashFlowTypeList;
            }
        }
        // show PaymentMean UI for edit
        private void ShowPaymentMeanEditForm(PaymentMean item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditPaymentMeanForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelPaymentMean;
                form.Init(item);
                form.Icon=this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<PaymentMean>();
                    SettingGridView.DataSource = Program.PaymentMeanList;
                }
            }
            else
            {
                RadMessageBox.Show("Type de flux de trésorerie inconnu");
            }
        }
        // show PaymentMean UI to add new 
        private void ShowPaymentMeanAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddPaymentMeanForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelPaymentMean;
            form.Icon = this.Icon;           
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = paymentMeanService.GetPaymentMean(form.NameTextBox.Text).Result;
                Program.PaymentMeanList.Add(data);
                SettingGridView.DataSource = new List<PaymentMean>();
                SettingGridView.DataSource = Program.PaymentMeanList;
            }
        }

        // show schoolingCost UI for edit
        private void ShowSchoolingCostEditForm(SchoolingCost item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolingCostForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSchoolingFee;
                form.Init(item);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SchoolingCost>();
                    SettingGridView.DataSource = Program.SchoolingCostList;
                }
            }
            else
            {
                RadMessageBox.Show("Type de flux de trésorerie inconnu");
            }
        }
        // show SchoolingCost UI to add new 
        private void ShowSchoolingCostAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolingCostForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSchoolingFee;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int classId = int.Parse(form.ClassDropDownList.SelectedValue.ToString());
                int yearId = int.Parse(form.SchoolYearDropDownList.SelectedValue.ToString());
                int costTypeId = int.Parse(form.CostTypeDropDownList.SelectedValue.ToString());
                var data = schoolingCostService.GetSchoolingCost(classId, costTypeId, yearId).Result;
                Program.SchoolingCostList.Add(data);
                SettingGridView.DataSource = new List<SchoolingCost>();
                SettingGridView.DataSource = Program.SchoolingCostList;
            }
        }
        // show schoolingCost UI for edit
        private void ShowSubscriptionFeeEditForm(SubscriptionFee item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubscriptionFeeForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSubscriptionFee;
                form.Init(item);
                form.Icon=this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SubscriptionFee>();
                    SettingGridView.DataSource = Program.SubscriptionFeeList;
                }
            }
            else
            {
                RadMessageBox.Show("Type de flux de trésorerie inconnu");
            }
        }
        // show SchoolingCost UI to add new 
        private void ShowSubscriptionFeeAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubscriptionFeeForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubscriptionFee;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int schoolYearId = int.Parse(form.SchoolYearDropDownList.SelectedValue.ToString());
                int subscriptionTypeId = int.Parse(form.SubscriptionTypeDropDownList.SelectedValue.ToString());
                var data = subscriptionFeeService.GetSubscriptionFee(subscriptionTypeId, schoolYearId).Result;
                Program.SubscriptionFeeList.Add(data);
                SettingGridView.DataSource = new List<SubscriptionFee>();
                SettingGridView.DataSource = Program.SubscriptionFeeList;
            }
        }
        // show subject group UI for edit
        private void ShowSubjectGroupEditForm(SubjectGroup item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSubjectGroup;
                form.Init(item);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<SubjectGroup>();
                    SettingGridView.DataSource = Program.SubjectGroupList;
                }
            }
            else
            {
                RadMessageBox.Show("Groupe inconnu");
            }
        }
        // show Subject group UI to add new 
        private void ShowSubjectGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubjectGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubjectGroup;
            form.Icon= this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string name = form.FrenchNameTextBox.Text;
                var data = subjectGroupService.GetSubjectGroup(name).Result;
                Program.SubjectGroupList.Add(data);
                SettingGridView.DataSource = new List<SubjectGroup>();
                SettingGridView.DataSource = Program.SubjectGroupList;
            }
        }
        // show subject UI for edit
        private void ShowSubjectEditForm(Subject item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditSubjectForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelSubject;
                form.Init(item);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<Subject>();
                    SettingGridView.DataSource = Program.SubjectList;
                }
            }
            else
            {
                RadMessageBox.Show("Matière inconnue");
            }
        }
        // show Subject UI to add new 
        private void ShowSubjectAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSubjectForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelSubject;
            form.Icon=this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string name = form.FrenchNameTextBox.Text;
                var data = subjectService.GetSubject(name).Result;
                Program.SubjectList.Add(data);
                SettingGridView.DataSource = new List<Subject>();
                SettingGridView.DataSource = Program.SubjectList;
            }
        }
        // show evaluation type UI for edit
        private void ShowEvaluationSessionEditForm(EvaluationSession item)
        {
            if (item != null)
            {
                var form = Program.ServiceProvider.GetService<EditEvaluationSessionForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEvaluationSession;
                form.Init(item);
                form.Icon= this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.MasterTemplate.DataSource = new List<EvaluationSession>();
                    SettingGridView.Templates[0].DataSource = new List<EvaluationSessionChild>();
                    SettingGridView.MasterTemplate.DataSource = Program.EvaluationSessionParentList;
                    SettingGridView.Templates[0].DataSource = Program.EvaluationSessionChildList;
                }
            }
            else
            {
                RadMessageBox.Show("Session inconnue");
            }
        }
        // show Rating system UI for add new
        private void ShowRatingSystemAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddRatingSystemForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelMarkSystem;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = ratingSystemService.GetRatingSystem(form.FrenchNameDropDownList.Text).Result;
                Program.RatingSystemList.Add(data);
                SettingGridView.DataSource = new List<RatingSystem>();
                SettingGridView.DataSource = Program.RatingSystemList;
            }
        }
        // show  Rating system UI for edit
        private void ShowRatingSystemEditForm(RatingSystem ratingSystem)
        {
            if (ratingSystem != null)
            {
                var form = Program.ServiceProvider.GetService<EditRatingSystemForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelMarkSystem;
                form.Init(ratingSystem);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<RatingSystem>();
                    SettingGridView.DataSource = Program.RatingSystemList;
                }
            }
            else
            {
                RadMessageBox.Show("Système inconnu");
            }
        }
        // show job UI for add
        private void ShowJobAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddJobForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelJob;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = jobService.GetJob(form.NameTextBox.Text).Result;
                Program.JobList.Add(data);
                SettingGridView.DataSource = new List<Job>();
                SettingGridView.DataSource = Program.JobList;
            }

        }
        // show job UI for edit
        private void ShowJobEditForm(Job job)
        {
            if (job != null)
            {
                var form = Program.ServiceProvider.GetService<EditJobForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelJob;
                form.Init(job);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<Job>();
                    SettingGridView.DataSource = Program.JobList;
                }
            }
            else
            {
                RadMessageBox.Show("Fonction inconnue");
            }

        }
        // show employee group UI for add
        private void ShowEmployeeGroupAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddEmployeeGroupForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelEmployeeGroup;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = employeeGroupService.GetEmployeeGroup(form.NameTextBox.Text).Result;
                Program.EmployeeGroupList.Add(data);
                SettingGridView.DataSource = new List<EmployeeGroup>();
                SettingGridView.DataSource = Program.EmployeeGroupList;
            }

        }
        // show employee group UI for edit
        private void ShowEmployeeGroupEditForm(EmployeeGroup group)
        {
            if (group != null)
            {
                var form = Program.ServiceProvider.GetService<EditEmployeeGroupForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEmployeeGroup;
                form.Icon = this.Icon;
                form.Init(group);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<EmployeeGroup>();
                    SettingGridView.DataSource = Program.EmployeeGroupList;
                }
            }
            else
            {
                RadMessageBox.Show("Fonction inconnue");
            }

        }
        // show user UI for add
        private void ShowUserAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddUserForm>();
            form.Text = Language.labelAdd + ":.." + Language.labelUser;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = userService.GetUser(form.LoginTextBox.Text).Result;
                Program.UserList.Add(data);
                SettingGridView.DataSource = new List<User>();
                SettingGridView.DataSource = Program.UserList;
            }

        }
        // show user UI for edit
        private void ShowUserEditForm(User user)
        {
            if (user != null)
            {
                var form = Program.ServiceProvider.GetService<EditUserForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelUser;
                form.Init(user);
                form.Icon = this.Icon;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SettingGridView.DataSource = new List<User>();
                    SettingGridView.DataSource = Program.UserList;
                }
            }
            else
            {
                RadMessageBox.Show("Utilisateur  inconnu");
            }

        }
        // rend visible le user control selectionnee, les autre invisible
        private void SetVisibleSelectedSettingPageUserControl(UserControl userControl)
        {
            if (userControl != null)
            {
                if (SettingGridView.RowCount > 0) userControl.Visible = true;
                foreach (var item in settingPageUserControlList.Where(u => u.Name != userControl.Name && u.Visible))
                {
                    item.Visible = false;
                }

            }
            else
            {
                foreach (var item in settingPageUserControlList.Where(u => u.Visible))
                {
                    item.Visible = false;
                }
            }


        }

        //load basic data like school year, student, room,....
      
        //sépare les sessions d'évaluation en mère-fille
        private void SplitEvaluationSessionList()
        {
            Program.EvaluationSessionChildList = new List<EvaluationSessionChild>();
            Program.EvaluationSessionParentList = new List<EvaluationSession>();
            foreach (var item in Program.EvaluationSessionList)
            {
                if (item.Code != "TERM01" && item.Code != "TERM02" && item.Code != "TERM03")
                {
                    Program.EvaluationSessionChildList.Add(item.ConvertToEvaluationSessionChild());
                }
                else
                {
                    Program.EvaluationSessionParentList.Add(item);
                }
            }
        }
        //génère les sessions d'évaluation manquantes
        private void GenerateEvaluationSessions()
        {
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "TERM01") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "TERM01",
                    FrenchName = "Premier Trimestre",
                    EnglishName = "First Trimester",
                    Sequence = 1
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "TERM02") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "TERM02",
                    FrenchName = "Deuxième Trimestre",
                    EnglishName = "Second Trimester",
                    Sequence = 2
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "TERM01") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "TERM03",
                    FrenchName = "Troisième Trimestre",
                    EnglishName = "Third Trimester",
                    Sequence = 3
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL01") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL01",
                    FrenchName = "EVALUATION N°1",
                    EnglishName = "EVALUATION N°1",
                    Sequence = 1
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL02") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {

                    Code = "EVAL02",
                    FrenchName = "EVALUATION N°2",
                    EnglishName = "EVALUATION N°2",
                    Sequence = 2
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL03") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL03",
                    FrenchName = "EVALUATION N°3",
                    EnglishName = "EVALUATION N°3",
                    Sequence = 3
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL04") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL04",
                    FrenchName = "EVALUATION N°4",
                    EnglishName = "EVALUATION N°4",
                    Sequence = 1
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL05") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL05",
                    FrenchName = "EVALUATION N°5",
                    EnglishName = "EVALUATION N°5",
                    Sequence = 2
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL06") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL06",
                    FrenchName = "EVALUATION N°6",
                    EnglishName = "EVALUATION N°6",
                    Sequence = 3
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL07") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL07",
                    FrenchName = "EVALUATION N°7",
                    EnglishName = "EVALUATION N°7",
                    Sequence = 1
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            if (Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL08") == null)
            {
                EvaluationSession type = new EvaluationSession()
                {
                    Code = "EVAL08",
                    FrenchName = "EVALUATION N°8",
                    EnglishName = "EVALUATION N°8",
                    Sequence = 2
                };
                var isDone = evaluationSessionService.CreateEvaluationSession(type).Result;
                if (isDone)
                {
                    Log log = new()
                    {
                        UserAction = $"Ajout  type d'évaluation {type.FrenchName}/{type.EnglishName} ",
                        UserId = clientApp.UserConnected.Id
                    };
                    logService.CreateLog(log);
                }
                else
                {
                    RadMessageBox.Show("Erreur d'enregistrement", "Enregistrement des données", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }

        }
        //affiche la liste matières d'une classe
        private void ShowSubjectsOfClass()
        {
            var form = Program.ServiceProvider.GetService<ClassSubjectsForm>();
            form.Icon = this.Icon;
            var currentItem = SettingGridView.CurrentRow.DataBoundItem as SchoolClass;
            form.Init(currentItem);
            form.Show();
        }
        //génère un relevé de note vide
        private async void GenerateEmptyClassReport(SchoolRoom selectedRoom, SchoolYear selectedYear, string language)
        {
            var form = Program.ServiceProvider.GetService<ReportViewerForm>();
            form.GenerateEmptyReportClassNote(selectedRoom, selectedYear, language);
            form.Icon = this.Icon;
            form.Text = selectedRoom.Name + ":.TEMPLATE RELEVE DE NOTES";
            form.Show();
            await Task.Delay(0);
        }
        #endregion

        #region Events
        private void SettingLeftListView_SelectedItemChanged(object sender, System.EventArgs e)
        {
            SettingSearchTextBox.Text = string.Empty;
            if (SettingLeftListView.SelectedItem != null)
            {
                SettingGridView.Relations.Clear();
                SettingGridView.Templates.Clear();
                SettingGridView.Columns.Clear();
                SettingGridView.DataSource = null;
                switch (SettingLeftListView.SelectedItem.Key)
                {
                    case 1:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddSchoolYear;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolYearListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolYearColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolYearList;
                        }
                        SetVisibleSelectedSettingPageUserControl(schoolYearInfo);
                        schoolYearInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        schoolYearInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 2:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddGroup;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolGroupListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolGroupColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolGroupList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(schoolGroupInfo);
                        schoolGroupInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        schoolGroupInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 3:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddClass;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolClassListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolClassColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolClassList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(schoolClassInfo);
                        schoolClassInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        schoolClassInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        schoolClassInfo.SubjectsCountLabel.Image = AppUtilities.GetImage("Eye");
                        break;
                    case 4:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddRoom;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolRoomListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolRoomColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolRoomList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(schoolRoomInfo);
                        schoolRoomInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        schoolRoomInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        schoolRoomInfo.StudentsCountLabel.Image = AppUtilities.GetImage("Eye");
                        break;
                    case 5:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddCashflowType;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadCashFlowTypeListToSettingGridView();
                        }
                        else
                        {
                            CreateCashFlowTypeColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.CashFlowTypeList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(cashFlowTypeInfo);
                        cashFlowTypeInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        cashFlowTypeInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 6:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddPaymentMean;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadPaymentMeanListToSettingGridView();
                        }
                        else
                        {
                            CreatePaymentMeanColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.PaymentMeanList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(paymentMeanInfo);
                        paymentMeanInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        paymentMeanInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 7:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddSchoolingFee;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolingCostListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolingCostColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolingCostList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(schoolingCostInfo);
                        schoolingCostInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        schoolingCostInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 8:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddSubscriptionFee;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSubscriptionFeeListToSettingGridView();
                        }
                        else
                        {
                            CreateSubscriptionFeeColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SubscriptionFeeList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(subscriptionFeeInfo);
                        subscriptionFeeInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        subscriptionFeeInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 9:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddGroup;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSubjectGroupListToSettingGridView();
                        }
                        else
                        {
                            CreateSubjectGroupColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SubjectGroupList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(subjectGroupInfo);
                        subjectGroupInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        subjectGroupInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 10:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddSubject;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSubjectListToSettingGridView();
                        }
                        else
                        {
                            CreateSubjectColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SubjectList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(subjectInfo);
                        subjectInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        subjectInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 11:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddEvaluationSession;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadEvaluationSessionListToSettingGridView();
                        }
                        else
                        {
                            CreateEvaluationSessionColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.EvaluationSessionParentList;
                            SettingGridView.Templates[0].DataSource = Program.EvaluationSessionChildList;
                            SettingGridView.Refresh();
                            SettingGridView.BestFitColumns();
                            SettingGridView.Templates[0].BestFitColumns();
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(evaluationSessionInfo);
                        evaluationSessionInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        evaluationSessionInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 12:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddMarkSystem;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadRatingSystemListToSettingGridView();
                        }
                        else
                        {
                            CreateRatingSystemColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.RatingSystemList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(ratingSystemInfo);
                        ratingSystemInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        ratingSystemInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 13:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddJob;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadJobListToSettingGridView();
                        }
                        else
                        {
                            CreateJobColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.JobList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(jobInfo);
                        jobInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        jobInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 14:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddGroup;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadEmployeeGroupListToSettingGridView();
                        }
                        else
                        {
                            CreateEmployeeGroupColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.EmployeeGroupList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(employeeGroupInfo);
                        employeeGroupInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        employeeGroupInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    case 15:
                        this.SettingAddButton.ButtonElement.ToolTipText = Language.messageClickToAddUser;
                        if (!isFirstLoadingBasicData)
                        {
                            LoadUserListToSettingGridView();
                        }
                        else
                        {
                            CreateUserColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.UserList;
                            isFirstLoadingBasicData = false;
                        }
                        SetVisibleSelectedSettingPageUserControl(userInfo);
                        userInfo.CloseButton.Image = AppUtilities.GetImage("Close");
                        userInfo.EditButton.Image = AppUtilities.GetImage("Edit");
                        break;
                    default:
                        SetVisibleSelectedSettingPageUserControl(null);
                        break;

                }
                SettingGridView.BestFitColumns();
                if (SettingGridView.Rows.Count > 0)
                {
                    SettingExportToExcelButton.Enabled = true;
                }
                else
                {
                    SettingExportToExcelButton.Enabled = false;
                }
            }
        }

        //filtre les ligne du datagridview du la setting page en fonction du contenu du controle  SettingSearchTextBox
        private void SettingGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (SettingSearchTextBox.Text != string.Empty)
            {
                if (SettingLeftListView.SelectedItem != null)
                {
                    switch (SettingLeftListView.SelectedItem.Key)
                    {
                        case 1:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 2:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 3:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["Group.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 4:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["SchoolClass.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 5:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["CategoryName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["TypeName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 6:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["Account"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells[Language.labelType].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 7:
                            e.Row.IsVisible = e.Row.Cells["SchoolClass.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["CashFlowType.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["SchoolYear.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 8:
                            e.Row.IsVisible = e.Row.Cells["CashFlowType.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["SchoolYear.Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 9:
                            e.Row.IsVisible = e.Row.Cells[Language.fieldName].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ;
                            break;
                        case 10:
                            e.Row.IsVisible = e.Row.Cells[Language.fieldName].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ;
                            break;
                        case 11:
                            e.Row.IsVisible = e.Row.Cells[Language.fieldName].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 12:
                            e.Row.IsVisible = e.Row.Cells[Language.fieldName].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells[Language.fieldDescription].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 13:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 14:
                            e.Row.IsVisible = e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 15:
                            e.Row.IsVisible = e.Row.Cells["UserName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["Name"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                    }
                }
            }
        }

        private void SettingSearchModuleDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (SettingSearchModuleDropDownList.SelectedIndex > -1)
            {
                foreach (var item in SettingLeftListView.Items)
                {
                    if (item.Text.Trim() == SettingSearchModuleDropDownList.Text)
                    {
                        SettingLeftListView.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void SettingGridView_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                SettingInfoRightPanel.Visible = true;
                switch (SettingLeftListView.SelectedItem.Key)
                {
                    case 1:
                        LoadSelectedSchoolYearDetail(SettingGridView.CurrentRow.DataBoundItem as SchoolYear);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!schoolYearInfo.Visible) schoolYearInfo.Visible = true;
                        }
                        break;
                    case 2:
                        LoadSelectedSchoolGroupDetail(SettingGridView.CurrentRow.DataBoundItem as SchoolGroup);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!schoolGroupInfo.Visible) schoolGroupInfo.Visible = true;
                        }
                        break;
                    case 3:
                        LoadSelectedSchoolClassDetail(SettingGridView.CurrentRow.DataBoundItem as SchoolClass);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!schoolClassInfo.Visible) schoolClassInfo.Visible = true;
                        }
                        break;
                    case 4:
                        LoadSelectedSchoolRoomDetail(SettingGridView.CurrentRow.DataBoundItem as SchoolRoom);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!schoolRoomInfo.Visible) schoolRoomInfo.Visible = true;
                        }
                        break;
                    case 5:
                        LoadSelectedCashFlowTypeDetail(SettingGridView.CurrentRow.DataBoundItem as CashFlowType);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!cashFlowTypeInfo.Visible) cashFlowTypeInfo.Visible = true;
                        }
                        break;
                    case 6:
                        LoadSelectedPaymentMeanDetail(SettingGridView.CurrentRow.DataBoundItem as PaymentMean);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!paymentMeanInfo.Visible) paymentMeanInfo.Visible = true;
                        }
                        break;
                    case 7:
                        LoadSelectedSchoolingCostDetail(SettingGridView.CurrentRow.DataBoundItem as SchoolingCost);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!schoolingCostInfo.Visible) schoolingCostInfo.Visible = true;
                        }
                        break;
                    case 8:
                        LoadSelectedSubscriptionFeeDetail(SettingGridView.CurrentRow.DataBoundItem as SubscriptionFee);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!subscriptionFeeInfo.Visible) subscriptionFeeInfo.Visible = true;
                        }
                        break;
                    case 9:
                        LoadSelectedSubjectGroupDetail(SettingGridView.CurrentRow.DataBoundItem as SubjectGroup);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!subjectGroupInfo.Visible) subjectGroupInfo.Visible = true;
                        }
                        break;
                    case 10:
                        LoadSelectedSubjectDetail(SettingGridView.CurrentRow.DataBoundItem as Subject);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!subjectInfo.Visible) subjectInfo.Visible = true;
                        }
                        break;
                    case 11:
                        LoadSelectedEvaluationSesssionDetail(SettingGridView.CurrentRow.DataBoundItem as EvaluationSession);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!evaluationSessionInfo.Visible) evaluationSessionInfo.Visible = true;
                        }
                        break;
                    case 12:
                        LoadSelectedRatingSystemDetail(SettingGridView.CurrentRow.DataBoundItem as RatingSystem);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!ratingSystemInfo.Visible) ratingSystemInfo.Visible = true;
                        }
                        break;
                    case 13:
                        LoadSelectedJobDetail(SettingGridView.CurrentRow.DataBoundItem as Job);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!jobInfo.Visible) jobInfo.Visible = true;
                        }
                        break;
                    case 14:
                        LoadSelectedEmployeeGroupDetail(SettingGridView.CurrentRow.DataBoundItem as EmployeeGroup);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!employeeGroupInfo.Visible) employeeGroupInfo.Visible = true;
                        }
                        break;
                    case 15:
                        LoadSelectedUserDetail(SettingGridView.CurrentRow.DataBoundItem as User);
                        if (SettingGridView.RowCount > 0)
                        {
                            if (!userInfo.Visible) userInfo.Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                SettingInfoRightPanel.Visible = false;
            }
        }

        private void SettingAddButton_Click(object sender, EventArgs e)
        {
            switch (SettingLeftListView.SelectedItem.Key)
            {
                case 1:
                    ShowSchoolYearAddForm();
                    break;
                case 2:
                    ShowSchoolGroupAddForm();
                    break;
                case 3:
                    ShowSchoolClassAddForm();
                    break;
                case 4:
                    ShowSchoolRoomAddForm();
                    break;
                case 5:
                    ShowCashFlowTypeAddForm();
                    break;
                case 6:
                    ShowPaymentMeanAddForm();
                    break;
                case 7:
                    ShowSchoolingCostAddForm();
                    break;
                case 8:
                    ShowSubscriptionFeeAddForm();
                    break;
                case 9:
                    ShowSubjectGroupAddForm();
                    break;
                case 10:
                    ShowSubjectAddForm();
                    break;
                case 11:
                    GenerateEvaluationSessions();
                    LoadEvaluationSessionListToSettingGridView();
                    break;
                case 12:
                    ShowRatingSystemAddForm();
                    break;
                case 13:
                    ShowJobAddForm();
                    break;
                case 14:
                    ShowEmployeeGroupAddForm();
                    break;
                case 15:
                    ShowUserAddForm();
                    break;
                default:
                    RadMessageBox.Show("Not Implemented");
                    break;
            }
        }
        // permet la modification des entite telles que année scolaire, classes, moyens de paiement, ...
        private void SettingEditButton_Click(object sender, EventArgs e)
        {
            switch (SettingLeftListView.SelectedItem.Key)
            {
                case 1:
                    ShowSchoolYearEditForm(SettingGridView.CurrentRow.DataBoundItem as SchoolYear);
                    break;
                case 2:
                    ShowSchoolGroupEditForm(SettingGridView.CurrentRow.DataBoundItem as SchoolGroup);
                    break;
                case 3:
                    ShowSchoolClassEditForm(SettingGridView.CurrentRow.DataBoundItem as SchoolClass);
                    break;
                case 4:
                    ShowSchoolRoomEditForm(SettingGridView.CurrentRow.DataBoundItem as SchoolRoom);
                    break;
                case 5:
                    ShowCashFlowTypeEditForm(SettingGridView.CurrentRow.DataBoundItem as CashFlowType);
                    break;
                case 6:
                    ShowPaymentMeanEditForm(SettingGridView.CurrentRow.DataBoundItem as PaymentMean);
                    break;
                case 7:
                    ShowSchoolingCostEditForm(SettingGridView.CurrentRow.DataBoundItem as SchoolingCost);
                    break;
                case 8:
                    ShowSubscriptionFeeEditForm(SettingGridView.CurrentRow.DataBoundItem as SubscriptionFee);
                    break;
                case 9:
                    ShowSubjectGroupEditForm(SettingGridView.CurrentRow.DataBoundItem as SubjectGroup);
                    break;
                case 10:
                    ShowSubjectEditForm(SettingGridView.CurrentRow.DataBoundItem as Subject);
                    break;
                case 11:
                    ShowEvaluationSessionEditForm(SettingGridView.CurrentRow.DataBoundItem as EvaluationSession);
                    break;
                case 12:
                    ShowRatingSystemEditForm(SettingGridView.CurrentRow.DataBoundItem as RatingSystem);
                    break;
                case 13:
                    ShowJobEditForm(SettingGridView.CurrentRow.DataBoundItem as Job);
                    break;
                case 14:
                    ShowEmployeeGroupEditForm(SettingGridView.CurrentRow.DataBoundItem as EmployeeGroup);
                    break;
                case 15:
                    ShowUserEditForm(SettingGridView.CurrentRow.DataBoundItem as User);
                    break;
                default:
                    RadMessageBox.Show("En cours d'implementation");
                    break;
            }
        }

        // recherche les lignes du datagridview conrrespondantes au contenu du contrôle SettingSearchTextBox
        private void SettingSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // fait appel à la méthode SettingGridView_CustomFiltering
            SettingGridView.MasterTemplate.Refresh();
        }
        private void SettingGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                RadMenuItem menuEdit = new(Language.labelEdit)
                {
                    Image = AppUtilities.GetImage("Edit")
                };
                menuEdit.Click += SettingEditButton_Click;
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuEdit);
                switch (SettingLeftListView.SelectedItem.Key)
                {
                    case 1:
                        var currentYear = SettingGridView.CurrentRow.DataBoundItem as SchoolYear;
                        var message = currentYear.IsClosed == false ? Language.messageCloseSchoolYear : Language.messageActivateSchoolYear;
                        RadMenuItem menuChangeSchoolYearStatus = new(message);
                        menuChangeSchoolYearStatus.Image = currentYear.IsClosed == false ? AppUtilities.GetImage("Lock") : AppUtilities.GetImage("Unlock");
                        e.ContextMenu.Items.Add(menuChangeSchoolYearStatus);
                        menuChangeSchoolYearStatus.Click += MenuChangeSchoolYearStatus_Click;
                        break;
                    case 3:
                        RadMenuItem menuShowSubjectOfClass = new(Language.labelSubjectTaught);
                        menuShowSubjectOfClass.Image = AppUtilities.GetImage("Eye");
                        menuShowSubjectOfClass.ToolTipText = Language.messageClickToSee;
                        menuShowSubjectOfClass.Click += MenuShowSubjectOfClass_Click;
                        RadMenuItem menuGenerateEmptyClassReport = new(Language.labelGenerateEmptyClassReport);
                        menuGenerateEmptyClassReport.Image = AppUtilities.GetImage("File");
                        menuGenerateEmptyClassReport.Click += MenuGenerateEmptyClassReport_Click;
                        e.ContextMenu.Items.Add(menuShowSubjectOfClass);
                        e.ContextMenu.Items.Add(menuGenerateEmptyClassReport);
                        break;
                    case 4:
                        RadMenuItem menuShowStudentOfClass = new(Language.titleStudentList);
                        menuShowStudentOfClass.Image = AppUtilities.GetImage("Eye");
                        menuShowStudentOfClass.ToolTipText = Language.messageClickToSee;
                        menuShowStudentOfClass.Click += MenuShowStudentOfClass_Click; ;
                        RadMenuItem menuGenerateEmptyRoomReport = new(Language.labelGenerateEmptyClassReport);
                        menuGenerateEmptyRoomReport.Image = AppUtilities.GetImage("File");
                        menuGenerateEmptyRoomReport.Click += MenuGenerateEmptyClassReport_Click;
                        e.ContextMenu.Items.Add(menuShowStudentOfClass);
                        e.ContextMenu.Items.Add(menuGenerateEmptyRoomReport);
                        break;
                    case 7:
                        RadMenuItem menuDuplicateSchoolingFee = new(Language.labelDuplicateForCurrentYear);
                        menuDuplicateSchoolingFee.Image = AppUtilities.GetImage("Duplicate");
                        menuDuplicateSchoolingFee.Click += MenuDuplicateSchoolingFee_Click;
                        e.ContextMenu.Items.Add(menuDuplicateSchoolingFee);
                        break;
                    case 8:
                        RadMenuItem menuDuplicateSubscriptionFee = new(Language.labelDuplicateForCurrentYear);
                        menuDuplicateSubscriptionFee.Image = AppUtilities.GetImage("Duplicate");
                        menuDuplicateSubscriptionFee.Click += MenuDuplicateSubscriptionFee_Click;
                        e.ContextMenu.Items.Add(menuDuplicateSubscriptionFee);
                        break;
                    case 15:
                        RadMenuItem menuShowUserModule = new(Language.labelUserModule);
                        menuShowUserModule.Image = AppUtilities.GetImage("Eye");
                        menuShowUserModule.ToolTipText = Language.messageClickToSee;
                        menuShowUserModule.Click += MenuShowUserModule_Click;
                        RadMenuItem menuShowUserRoom = new(Language.labelUserRoom);
                        menuShowUserRoom.Image = AppUtilities.GetImage("Eye");
                        menuShowUserRoom.ToolTipText = Language.messageClickToSee;
                        menuShowUserRoom.Click += MenuShowUserRoom_Click;
                        e.ContextMenu.Items.Add(menuShowUserModule);
                        e.ContextMenu.Items.Add(menuShowUserRoom);
                        break;

                }
            }
                
        }
        //dupiquer les frais d'abonnement pour l'année en cours
        private void MenuDuplicateSubscriptionFee_Click(object sender, EventArgs e)
        {
            var openYear = Program.CurrentSchoolYear;
            if (openYear.IsClosed == false)
            {
                if (SettingGridView.CurrentRow.DataBoundItem is SubscriptionFee selectedRecord)
                {
                    var result = RadMessageBox.Show(this, Language.messageConfirmeDuplicateFee + " " + openYear.Name, Language.labelSchoolingFee, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft);
                    if (result == DialogResult.Yes)
                    {
                        var newRecord = new SubscriptionFee
                        {
                            SchoolYear = openYear,
                            SchoolYearId = openYear.Id,
                            Duration= selectedRecord.Duration,
                            CashFlowType= selectedRecord.CashFlowType,
                            CashFlowTypeId= selectedRecord.CashFlowTypeId,
                            Amount = selectedRecord.Amount,
                        };
                        //vérification de l'existance si trouvé pas d'enregistrement
                        if (subscriptionFeeService.GetSubscriptionFee(newRecord.CashFlowTypeId, newRecord.SchoolYearId).Result == null)
                        {
                            bool isDone = subscriptionFeeService.CreateSubscriptionFee(newRecord).Result;
                            if (isDone == true)
                            {
                                Log log = new()
                                {
                                    UserAction = $"Ajout  des frais d'abonnement {newRecord.CashFlowType.Name} pour l'année scolaire {newRecord.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(log);

                                // récupération de nouvel enregistrement pour editer
                                newRecord.Id = subscriptionFeeService.GetSubscriptionFee(newRecord.CashFlowTypeId, newRecord.SchoolYearId).Result.Id;
                                Program.SubscriptionFeeList.Add(newRecord);
                                ShowSubscriptionFeeEditForm(newRecord);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(this, Language.messageFeeAlreadyExist, Language.labelSchoolingFee, MessageBoxButtons.OK, RadMessageIcon.Info);

                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageRequireOpenYear, Language.labelSchoolingFee, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        // duplique les frais de scolarité pour l'année en cours
        private void MenuDuplicateSchoolingFee_Click(object sender, EventArgs e)
        {
            var openYear = Program.CurrentSchoolYear;
            if (openYear.IsClosed == false)
            {
               if (SettingGridView.CurrentRow.DataBoundItem is SchoolingCost selectedRecord)
                {
                    var result = RadMessageBox.Show(this, Language.messageConfirmeDuplicateFee+" " + openYear.Name, Language.labelSchoolingFee, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft);
                    if (result == DialogResult.Yes)
                    {
                        var newRecord = new SchoolingCost
                        {
                            SchoolYear = openYear,
                            SchoolYearId = openYear.Id,
                            SchoolClass = selectedRecord.SchoolClass,
                            SchoolClassId = selectedRecord.SchoolClassId,
                            CashFlowType = selectedRecord.CashFlowType,
                            CashFlowTypeId = selectedRecord.CashFlowTypeId,
                            IsPayable = selectedRecord.IsPayable,
                            TrancheNumber = selectedRecord.TrancheNumber,
                            Amount = selectedRecord.Amount,
                            SchoolingCostItems= schoolingCostService.GetSchoolingCostItems(selectedRecord.Id).Result
                        };
                        //vérification de l'existance si trouvé pas d'enregistrement
                        if(schoolingCostService.GetSchoolingCost(newRecord.SchoolClassId, newRecord.CashFlowTypeId, newRecord.SchoolYearId).Result == null)
                        {
                            bool isDone = schoolingCostService.CreateSchoolingCost(newRecord).Result;
                            if (isDone == true)
                            {
                                Log log = new()
                                {
                                    UserAction = $"Ajout  des frais scolaires {newRecord.CashFlowType.Name} pour la classe {newRecord.SchoolClass.Name} pour l'année scolaire {newRecord.SchoolYear.Name}  par l'utisateur  {clientApp.UserConnected.Name} ",
                                    UserId = clientApp.UserConnected.Id
                                };
                                logService.CreateLog(log);

                                // récupération de nouvel enregistrement pour editer
                                newRecord.Id = schoolingCostService.GetSchoolingCost(newRecord.SchoolClassId, newRecord.CashFlowTypeId, newRecord.SchoolYearId).Result.Id;
                                Program.SchoolingCostList.Add(newRecord);
                                ShowSchoolingCostEditForm(newRecord);
                            }
                            else
                            {
                                RadMessageBox.Show(Language.messageAddError);
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(this, Language.messageFeeAlreadyExist, Language.labelSchoolingFee, MessageBoxButtons.OK, RadMessageIcon.Info);

                        }
                    }
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageRequireOpenYear, Language.labelSchoolingFee, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        private void MenuShowUserRoom_Click(object sender, EventArgs e)
        {
            if (SettingGridView.CurrentRow.DataBoundItem is User user)
            {
                var form = Program.ServiceProvider.GetService<UserRoomsForm>();
                form.Text=user.Name+":.. "+Language.labelRooms;
                form.Icon = this.Icon;
                form.Init(user);
                form.Show();
            }
        }

        private void MenuShowUserModule_Click(object sender, EventArgs e)
        {
           
            if(SettingGridView.CurrentRow.DataBoundItem is User user)
            {
                var form = Program.ServiceProvider.GetService<UserModulesForm>();
                form.Text = user.Name + ":.. " + Language.labelModules;
                form.Icon=this.Icon;
                form.Init(user);
                form.Show();
            }
        }

        private void MenuShowStudentOfClass_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show("En cous d'implémentation");
        }

        //génère un relevé de note vide
        private void MenuGenerateEmptyClassReport_Click(object sender, EventArgs e)
        {
            
            switch (SettingLeftListView.SelectedItem.Key)
            {
                case 3:
                    if (SettingGridView.CurrentRow.DataBoundItem is SchoolClass selectedClass)
                    {
                        foreach (var room in Program.SchoolRoomList)
                        {
                            if (room.ClassId == selectedClass.Id)
                            {
                                GenerateEmptyClassReport(room, Program.CurrentSchoolYear, "FR");
                            }
                        }
                    }
                    break; 
                case 4:
                    if (SettingGridView.CurrentRow.DataBoundItem is SchoolRoom selectedRoom)
                    {
                        GenerateEmptyClassReport(selectedRoom, Program.CurrentSchoolYear, "FR");
                    }
                    break;
            }

        }        

        private void MenuShowSubjectOfClass_Click(object sender, EventArgs e)
        {
            ShowSubjectsOfClass();
        }      

        private void MenuChangeSchoolYearStatus_Click(object sender, EventArgs e)
        {
            var currentYear = SettingGridView.CurrentRow.DataBoundItem as SchoolYear;
            var message = currentYear.IsClosed == false ? Language.messageAskCloseSchoolYear : Language.messageAskActivateSchoolYear;
            var result = RadMessageBox.Show(this, message+" " + currentYear.Name, Language.labelSchoolYears.ToUpper(), MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft);
            if (result == DialogResult.Yes)
            {
                if (schoolYearService.ChangeSchoolYearStatus(currentYear).Result)
                {
                    var messageResult = currentYear.IsClosed == true ? Language.messageSuccesCloseSchoolYear : Language.messageSuccesActivateSchoolYear;
                    RadMessageBox.Show(this, messageResult, Language.labelSchoolYears.ToUpper(), MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    RadMessageBox.Show(this, "Erreur...", Language.labelSchoolYears.ToUpper(), MessageBoxButtons.OK, RadMessageIcon.Error);

                }
            }
        }
        #endregion
        //get images in file ressource

    }
}
