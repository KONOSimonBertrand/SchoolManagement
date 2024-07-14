
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.UI.CustomControls;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private SubscriptionFeeInfo subscriptionFeeInfo;
        private SubjectGroupInfo subjectGroupInfo;
        private SubjectInfo subjectInfo;
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
            SettingAddButton.Enabled = false;
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
                Text = "PARAMETRES"
            };
            this.SettingLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { settingGroup });
            ListViewDataItem itemSchoolYear = new()
            {
                Key = 1,
                Value = "Années Scolaires"
            };
            ListViewDataItem itemGroup = new()
            {
                Key = 2,
                Value = "Groupes de Classes"
            };
            ListViewDataItem itemClass = new()
            {
                Key = 3,
                Value = "Classes"
            };
            ListViewDataItem itemRoom = new()
            {
                Key = 4,
                Value = "Salles de Classe"
            };
            ListViewDataItem itemCashFlowSetting = new()
            {
                Key = 5,
                Value = "Types de Flux de Trésorerie"
            };
            ListViewDataItem itemPaymentMean = new()
            {
                Key = 6,
                Value = "Moyens de Paiement"
            };
            ListViewDataItem itemSchoolingCost = new()
            {
                Key = 7,
                Value = "Frais Scolaires"
            };
            ListViewDataItem itemSubscriptionFees = new()
            {
                Key = 8,
                Value = "Frais d'Abonnement"
            };
            ListViewDataItem itemSubjectGroup = new()
            {
                Key = 9,
                Value = "Groupes de Matières"
            };
            ListViewDataItem itemSubject = new()
            {
                Key = 10,
                Value = "Matières"
            };
            ListViewDataItem itemEvaluationType = new()
            {
                Key = 11,
                Value = "Sessions d'Evaluation"
            };
            ListViewDataItem itemEvaluationSystem = new()
            {
                Key = 12,
                Value = "Système d'Appréciation"
            };
            ListViewDataItem itemJob = new()
            {
                Key = 13,
                Value = "Type de Fonction"
            };
            ListViewDataItem itemEmployeeGroup = new()
            {
                Key = 14,
                Value = "Groupes d'Employés"
            };
            ListViewDataItem itemUser = new()
            {
                Key = 15,
                Value = "Utilisateurs"
            };
            ListViewDataItem itemOtherSetting = new()
            {
                Key = 16,
                Value = "Autres Configurations"
            };
           

            itemSchoolYear.Group = settingGroup;
            itemGroup.Group = settingGroup;
            itemClass.Group = settingGroup;
            itemSchoolingCost.Group = settingGroup;
            itemPaymentMean.Group = settingGroup;
            itemCashFlowSetting.Group = settingGroup;
            itemSubjectGroup.Group = settingGroup;
            itemSubject.Group = settingGroup;
            itemEvaluationType.Group = settingGroup;
            itemEvaluationSystem.Group = settingGroup;
            itemJob.Group = settingGroup;
            itemEmployeeGroup.Group = settingGroup;
            itemUser.Group = settingGroup;
            itemOtherSetting.Group = settingGroup;
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
            SettingLeftListView.Items.Add(itemEvaluationType);
            SettingLeftListView.Items.Add(itemEvaluationSystem);
            SettingLeftListView.Items.Add(itemJob);
            SettingLeftListView.Items.Add(itemEmployeeGroup);
            SettingLeftListView.Items.Add(itemUser);
            SettingLeftListView.Items.Add(itemOtherSetting);

            SettingSearchModuleDropDownList.Items.Add(itemGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemClass.Text);
            SettingSearchModuleDropDownList.Items.Add(itemRoom.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolYear.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolingCost.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubscriptionFees.Text);
            SettingSearchModuleDropDownList.Items.Add(itemCashFlowSetting.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubject.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationType.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationSystem.Text);
            SettingSearchModuleDropDownList.Items.Add(itemJob.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEmployeeGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemUser.Text);
            SettingSearchModuleDropDownList.Items.Add(itemOtherSetting.Text);
            SettingLeftListView.ShowCheckBoxes = false;
            SettingLeftListView.SelectedIndex = 0;
        }
        //initialisation des contrôles personnalisés 
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
        }
        //initialise les évenements relatifs aux contrôles Windows Forms de la page setting
        private void InitSettingPageEvents()
        {
            SettingSearchTextBox.TextChanged += SettingSearchTextBox_TextChanged;
            SettingLeftListView.SelectedItemChanged += SettingLeftListView_SelectedItemChanged;
            SettingGridView.CurrentRowChanged += SettingGridView_CurrentRowChanged;
            SettingGridView.CustomFiltering += SettingGridView_CustomFiltering;
            SettingSearchModuleDropDownList.SelectedIndexChanged += SettingSearchModuleDropDownList_SelectedIndexChanged;
            SettingAddButton.Click += SettingAddButton_Click;
            //déclenche l'évenement  SettingLeftListView.SelectedItemChanged pour un premier affichage
            SettingLeftListView.SelectedItem = null;
            SettingLeftListView.SelectedItem = SettingLeftListView.Items.FirstOrDefault();
        }

        #region Methodes
        // affiche les informations d'une année scolaire sur le contrôle personnalisé SchoolYearInfo
        private void LoadSelectedSchoolYearDetail(SchoolYear schoolYear)
        {
            schoolYearInfo.TitleInfoLabel.Text = "INFOS SUR L'ANNEE SCOLAIRE";
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter.ToString();
            schoolYearInfo.NameTextBox.Text = schoolYear.Name;
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter?.ToString("dd-MM-yyyy");
            schoolYearInfo.EndDateTextBox.Text = schoolYear.EndThirdQuarter?.ToString("dd-MM-yyyy");
        }
        // affiche les info d'un group de classe
        private void LoadSelectedSchoolGroupDetail(SchoolGroup schoolGroup)
        {
            schoolGroupInfo.TitleInfoLabel.Text = "INFOS SUR LE GROUP";
            schoolGroupInfo.NameTextBox.Text = schoolGroup.Name;

        }
        // affiche les info d'une classe
        private void LoadSelectedSchoolClassDetail(SchoolClass schoolClass)
        {
            schoolClassInfo.TitleInfoLabel.Text = "INFOS SUR LA CLASSE";
            schoolClassInfo.NameTextBox.Text = schoolClass.Name;
            schoolClassInfo.GroupTextBox.Text = schoolClass.Group.Name;
        }
        // affiche les info d'une salle classe
        private void LoadSelectedSchoolRoomDetail(SchoolRoom room)
        {
            schoolRoomInfo.TitleInfoLabel.Text = "INFOS SUR LA SALLE DE CLASSE";
            if (room != null) {
                schoolRoomInfo.NameTextBox.Text = room.Name;
                schoolRoomInfo.ClassTextBox.Text = room.SchoolClass.Name;
            }
        }
        // affiche les info d'un type de trésorerie
        private void LoadSelectedCashFlowTypeDetail(CashFlowType cashFlowType)
        {
            cashFlowTypeInfo.TitleInfoLabel.Text = "INFOS SUR LE TYPE FLUX DE TRESORERIE";
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
            paymentMeanInfo.TitleInfoLabel.Text = "INFOS SUR LE MOYEN DE PAIEMENT";
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
            schoolingCostInfo.TitleInfoLabel.Text = "INFOS SUR FRAIS SCOLAIRE";
            if (cost != null)
            {
                var getData = schoolingCostService.GetSchoolingCostItems(cost.Id);
                schoolingCostInfo.SchoolYearTextBox.Text = cost.SchoolYear.Name;
                schoolingCostInfo.ClassTextBox.Text = cost.SchoolClass.Name;
                schoolingCostInfo.CostTypeTextBox.Text = cost.CashFlowType.Name;
                schoolingCostInfo.TrancheNumberTextBox.Text=cost.TrancheNumber.ToString();
                schoolingCostInfo.AmountTextBox.Text = cost.Amount.ToString();
                int i = 1;
                schoolingCostInfo.TrancheNumberTextBox.TextBoxElement.ToolTipText=string.Empty;
                schoolingCostInfo.TranchesLabel.Text=string.Empty;
                schoolingCostInfo.TranchesLabel.TextAlignment = ContentAlignment.TopCenter;
                schoolingCostInfo.TranchesLabel.Text = "***********Tranches***********\n";
                foreach (var line in getData.Result)
                {
                    schoolingCostInfo.TrancheNumberTextBox.TextBoxElement.ToolTipText  += "N°: " +
                          i+"  Montant: "+line.Amount+ "  Délais: " + line.DeadLine.ToString("dd - MM - yyyy") +"\n";
                    schoolingCostInfo.TranchesLabel.Text +=  i+"- "+ line.Amount + "  Délais: " + line.DeadLine.ToString("dd - MM - yyyy") + "\n";
                    i++;
                }
            }
        }
        // affiche les info d'un frais d'abonnement
        private void LoadSelectedSubscriptionFeeDetail(SubscriptionFee subscriptionFee)
        {
            subscriptionFeeInfo.TitleInfoLabel.Text = "INFOS SUR FRAIS D'ABONNEMENT";
            if (subscriptionFee != null)
            {
                subscriptionFeeInfo.SchoolYearTextBox.Text = subscriptionFee.SchoolYear.Name;
                subscriptionFeeInfo.SubscriptionTypeTextBox.Text = subscriptionFee.CashFlowType.Name;
                subscriptionFeeInfo.AmountTextBox.Text= subscriptionFee.Amount.ToString();
            }
        }
        // affiche les info d'un groupe de matières
        private void LoadSelectedSubjectGroupDetail(SubjectGroup subjectGroup)
        {
            if (subjectGroup != null)
            {
                subjectGroupInfo.NameTextBox.Text = subjectGroup.DefaultName;
            }
        }
        // affiche les info d'une de matière
        private void LoadSelectedSubjectDetail(Subject subject)
        {
            if (subject != null)
            {
                subjectInfo.NameTextBox.Text = subject.DefaultName;
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
            startFirstQuarterColum.CustomFormat = "dd-MM-yyyy";
            startFirstQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            endFirstQuarterColum.Format = DateTimePickerFormat.Custom;
            endFirstQuarterColum.CustomFormat = "dd-MM-yyyy";
            endFirstQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            startSecondQuarterColum.Format = DateTimePickerFormat.Custom;
            startSecondQuarterColum.CustomFormat = "dd-MM-yyyy";
            startSecondQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            endSecondQuarterColum.Format = DateTimePickerFormat.Custom;
            endSecondQuarterColum.CustomFormat = "dd-MM-yyyy";
            endSecondQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            startThirdQuarterColum.Format = DateTimePickerFormat.Custom;
            startThirdQuarterColum.CustomFormat = "dd-MM-yyyy";
            startThirdQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            endThirdQuarterColum.Format = DateTimePickerFormat.Custom;
            endThirdQuarterColum.CustomFormat = "dd-MM-yyyy";
            endThirdQuarterColum.FormatString = "{0:dd-MM-yyyy}";
            yearNameColum.HeaderText = "Désignation";
            startFirstQuarterColum.HeaderText = "Début 1ᵉʳ trimestre";
            endFirstQuarterColum.HeaderText = "Fin 1ᵉʳ trimestre";
            startSecondQuarterColum.HeaderText = "Début 2ᵉ trimestre";
            endSecondQuarterColum.HeaderText = "Fin 2ᵉ trimestre";
            startThirdQuarterColum.HeaderText = "Début 3ᵉ trimestre";
            endThirdQuarterColum.HeaderText = "Fin 3ᵉ trimestre";
            yearStateColum.HeaderText = "Etat";
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
            nameColum.HeaderText = "Désignation";
            sequenceColum.HeaderText = "Séquence";
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
            nameColum.HeaderText = "Désignation";
            groupColum.HeaderText = "Groupe";
            bookColum.HeaderText = "Modèle de bulletin";
            sequenceColum.HeaderText = "Séquence";
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
            SettingGridView.Columns.Clear();
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn classColum = new("SchoolClass.Name");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = "Désignation";
            classColum.HeaderText = "Classe";
            sequenceColum.HeaderText = "Séquence";
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
            nameColum.HeaderText = "Désignation";
            classColum.HeaderText = "Catégorie";
            typeColum.HeaderText = "Type";
            sequenceColum.HeaderText = "Séquence";
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
            GridViewTextBoxColumn typeColum = new("Type");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = "Désignation";
            accountColum.HeaderText = "Compte";
            typeColum.HeaderText = "Type";
            sequenceColum.HeaderText = "Séquence";
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
            classColumn.HeaderText = "Classe";
            costTypeColumn.HeaderText = "Type de frais";
            amountColumn.HeaderText = "Montant";
            trancheNumberColumn.HeaderText = "Nbre de tranches";
            payableColumn.HeaderText = "Exigible";
            yearColumn.HeaderText = "Année scolaire";
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
            subscriptionTypeColumn.HeaderText = "Abonnement";
            amountColumn.HeaderText = "Montant";
            durationColumn.HeaderText = "Durée";
            yearColumn.HeaderText = "Année scolaire";
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
            GridViewTextBoxColumn frenchNameColumn = new("FrenchName");
            GridViewTextBoxColumn englishNameColumn = new("EnglishName");
            GridViewTextBoxColumn sequenceColumn = new("Sequence");
            frenchNameColumn.HeaderText = "Désignation FR";
            englishNameColumn.HeaderText = "Désignation EN";
            sequenceColumn.HeaderText = "Séquence";
            SettingGridView.Columns.Add(frenchNameColumn);
            SettingGridView.Columns.Add(englishNameColumn);
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
            GridViewTextBoxColumn frenchNameColumn = new("FrenchName");
            GridViewTextBoxColumn englishNameColumn = new("EnglishName");
            GridViewTextBoxColumn sequenceColumn = new("Sequence");
            frenchNameColumn.HeaderText = "Désignation FR";
            englishNameColumn.HeaderText = "Désignation EN";
            sequenceColumn.HeaderText = "Séquence";
            SettingGridView.Columns.Add(frenchNameColumn);
            SettingGridView.Columns.Add(englishNameColumn);
            SettingGridView.Columns.Add(sequenceColumn);
        }
        // show school year UI for edit
        private void ShowSchoolYearEditForm(SchoolYear schoolYear)
        {
            if (schoolYear != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolYearForm>();
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
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var data = schoolYearService.GetSchoolYear(form.NameTextBox.Text).Result;
                Program.SchoolYearList.Add(data);
                SettingGridView.DataSource = new List<SchoolYear>();
                SettingGridView.DataSource = Program.SchoolYearList;
            }
        }
        // show school grou UI for edit
        private void ShowSchoolGroupEditForm(SchoolGroup schoolGroup)
        {
            if (schoolGroup != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolGroupForm>();
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
                form.Init(schoolClass);
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
                form.Init(room);
                form.ClientSize = new System.Drawing.Size(915, 280);
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
            form.ClientSize = new System.Drawing.Size(915, 280);
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
                form.Init(type);
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
                form.Init(item);
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
                form.Init(item);
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
                form.Init(item);
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
                form.Init(item);
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
                form.Init(item);
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
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string name = form.FrenchNameTextBox.Text;
                var data = subjectService.GetSubject(name).Result;
                Program.SubjectList.Add(data);
                SettingGridView.DataSource = new List<Subject>();
                SettingGridView.DataSource = Program.SubjectList;
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
        private async void LoadBasicData()
        {
            var getSchoolYearList = schoolYearService.GetSchoolYearList();
            var getSchoolGroupList = schoolGroupService.GetSchoolGroupList();
            var getClassList = schoolClassService.GetSchoolClassList();
            var getRoomList= schoolRoomService.GetSchoolRoomList();
            var getCashflowTypeList=cashFlowTypeService.GetCashFlowTypeList();
            var getPaymenMeantList=paymentMeanService.GetPaymentMeanList();
            var getSchoolingCostList = schoolingCostService.GetSchoolingCostList ();
            var getSubscripFeetionList=subscriptionFeeService.GetSubscriptionFeeList();
            var getSubjectGroupList= subjectGroupService.GetSubjectGroupList();
            var getSubjectList=subjectService.GetSubjectList();
            Program.SchoolYearList = await getSchoolYearList;
            Program.SchoolGroupList = await getSchoolGroupList;
            Program.SchoolClassList = await getClassList;
            Program.SchoolRoomList = await getRoomList;
            Program.CashFlowTypeList = await getCashflowTypeList;
            Program.PaymentMeanList= await getPaymenMeantList;
            Program.SchoolingCostList = await getSchoolingCostList;
            Program.SubscriptionFeeList=await getSubscripFeetionList;
            Program.SubjectGroupList = await getSubjectGroupList;
            Program.SubjectList= await getSubjectList;
            isFirstLoadingBasicData = true;
            PopulateSchoolYearOnDropDownList();
        }
        #endregion

        #region Events
        private void SettingLeftListView_SelectedItemChanged(object sender, System.EventArgs e)
        {
            SettingSearchTextBox.Text = string.Empty;
            if (SettingLeftListView.SelectedItem != null)
            {
                SettingGridView.Columns.Clear();
                SettingGridView.DataSource = null;
                switch (SettingLeftListView.SelectedItem.Key)
                {
                    case 1:
                        if (!isFirstLoadingBasicData)
                        {
                            LoadSchoolYearListToSettingGridView();
                        }
                        else
                        {
                            CreateSchoolYearColumnsForSettingGridView();
                            SettingGridView.DataSource = Program.SchoolYearList;
                        }
                        SettingSearchTextBox.NullText = "Rechercher par Désignation";
                        SetVisibleSelectedSettingPageUserControl(schoolYearInfo);
                        break;
                    case 2:
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
                        SettingSearchTextBox.NullText = "Rechercher par Désignation";
                        SetVisibleSelectedSettingPageUserControl(schoolGroupInfo);
                        break;
                    case 3:
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
                        SettingSearchTextBox.NullText = "Rechercher par Désignation ou par groupe";
                        SetVisibleSelectedSettingPageUserControl(schoolClassInfo);
                        break;
                    case 4:
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
                        SettingSearchTextBox.NullText = "Rechercher par Désignation ou par classe";
                        SetVisibleSelectedSettingPageUserControl(schoolRoomInfo);
                        break;
                    case 5:
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
                        SettingSearchTextBox.NullText = "Rechercher par Désignation ou par catégorie";
                        SetVisibleSelectedSettingPageUserControl(cashFlowTypeInfo);
                        break;
                    case 6:
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
                        SettingSearchTextBox.NullText = "Rechercher par Désignation, par compte et par type";
                        SetVisibleSelectedSettingPageUserControl(paymentMeanInfo);
                        break;
                    case 7:
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
                        SettingSearchTextBox.NullText = "Rechercher par classe, type de frais ou par année scolaire";
                        SetVisibleSelectedSettingPageUserControl(schoolingCostInfo);
                        break;
                    case 8:
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
                        SettingSearchTextBox.NullText = "Rechercher par abonnement ou par année scolaire";
                        SetVisibleSelectedSettingPageUserControl(subscriptionFeeInfo);
                        break;
                    case 9:
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
                        SettingSearchTextBox.NullText = "Rechercher par désignation";
                        SetVisibleSelectedSettingPageUserControl(subjectGroupInfo);
                        break;
                    case 10:
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
                        SettingSearchTextBox.NullText = "Rechercher par désignation";
                        SetVisibleSelectedSettingPageUserControl(subjectInfo);
                        break;
                    default:
                        SetVisibleSelectedSettingPageUserControl(null);
                        break;
                }
                SettingGridView.BestFitColumns();
                if (SettingGridView.Rows.Count > 0)
                {
                    SettingAddButton.Enabled = true;
                    SettingExportToExcelButton.Enabled = true;
                }
                else
                {
                    SettingAddButton.Enabled = false;
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
                                e.Row.Cells["Type"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
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
                            e.Row.IsVisible = e.Row.Cells["FrenchName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["EnglishName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
                            break;
                        case 10:
                            e.Row.IsVisible = e.Row.Cells["FrenchName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower()) ||
                                e.Row.Cells["EnglishName"].Value.ToString().ToLower().Contains(this.SettingSearchTextBox.Text.ToLower());
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
        #endregion


    }
}
