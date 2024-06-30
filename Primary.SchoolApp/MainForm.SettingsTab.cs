
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.UI.CustomControls;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private SchoolYearInfo schoolYearInfo;
        private ICollection<SchoolYear> schoolYears;
        private void InitSettingPage()
        {
            InitSettingPageComponents();
            InitSettingPageCustomControls();
            InitSettingPageEvents();
            InitSettingModule();
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
            ListViewDataItem itemSchoolingCost = new()
            {
                Key = 5,
                Value = "Frais Scolaires"
            };
            ListViewDataItem itemStudent = new()
            {
                Key = 6,
                Value = "Elèves"
            };
            ListViewDataItem itemUser = new()
            {
                Key = 7,
                Value = "Utilisateurs"
            };
            ListViewDataItem itemOtherSetting = new()
            {
                Key = 8,
                Value = "Autres Configurations"
            };
            ListViewDataItem itemCashFlowSetting = new()
            {
                Key = 9,
                Value = "Types de Flux de Trésorerie"
            };
            ListViewDataItem itemSubjectGroup = new()
            {
                Key = 10,
                Value = "Groupes de Matières"
            };
            ListViewDataItem itemSubject = new()
            {
                Key = 11,
                Value = "Matières"
            };
            ListViewDataItem itemEvaluationType = new()
            {
                Key = 12,
                Value = "Sessions d'Evaluation"
            };
            ListViewDataItem itemEmployeeGroup = new()
            {
                Key = 13,
                Value = "Groupes d'Employés"
            };
            ListViewDataItem itemEmployee = new()
            {
                Key = 14,
                Value = "Employés"
            };
            ListViewDataItem itemEvaluationSystem = new()
            {
                Key = 15,
                Value = "Système d'Appréciation"
            };
            ListViewDataItem itemSubscriptionFees = new()
            {
                Key = 17,
                Value = "Frais d'Abonnement"
            };
            ListViewDataItem itemJob = new()
            {
                Key = 18,
                Value = "Type de Fonction"
            };
            ListViewDataItem itemRoom = new()
            {
                Key = 19,
                Value = "Salles de Classe"
            };
            ListViewDataItem itemPaymentMean = new()
            {
                Key = 20,
                Value = "Moyens de Paiement"
            };

            itemSchoolYear.Group = settingGroup;
            itemGroup.Group = settingGroup;
            itemClass.Group = settingGroup;
            itemSchoolingCost.Group = settingGroup;
            itemPaymentMean.Group = settingGroup;
            itemCashFlowSetting.Group = settingGroup;
            itemStudent.Group = settingGroup;
            itemSubjectGroup.Group = settingGroup;
            itemSubject.Group = settingGroup;
            itemEvaluationType.Group = settingGroup;
            itemEvaluationSystem.Group = settingGroup;
            itemJob.Group = settingGroup;
            itemEmployeeGroup.Group = settingGroup;
            itemEmployee.Group = settingGroup;
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
            SettingLeftListView.Items.Add(itemStudent);
            SettingLeftListView.Items.Add(itemSubjectGroup);
            SettingLeftListView.Items.Add(itemSubject);
            SettingLeftListView.Items.Add(itemEvaluationType);
            SettingLeftListView.Items.Add(itemEvaluationSystem);
            SettingLeftListView.Items.Add(itemJob);
            SettingLeftListView.Items.Add(itemEmployeeGroup);
            SettingLeftListView.Items.Add(itemEmployee);
            SettingLeftListView.Items.Add(itemUser);
            SettingLeftListView.Items.Add(itemOtherSetting);

            SettingSearchModuleDropDownList.Items.Add(itemGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemClass.Text);
            SettingSearchModuleDropDownList.Items.Add(itemRoom.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolYear.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSchoolingCost.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubscriptionFees.Text);
            SettingSearchModuleDropDownList.Items.Add(itemCashFlowSetting.Text);
            SettingSearchModuleDropDownList.Items.Add(itemStudent.Text);
            SettingSearchModuleDropDownList.Items.Add(itemSubject.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationType.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEvaluationSystem.Text);
            SettingSearchModuleDropDownList.Items.Add(itemJob.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEmployeeGroup.Text);
            SettingSearchModuleDropDownList.Items.Add(itemEmployee.Text);
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
        }

        #region Methodes
        // affiche les informations d'une année scolaire sur le contrôle personnalisé SchoolYearInfo
        private void LoadSelectedSchoolYearDetail(SchoolYear schoolYear)
        {
            if (schoolYearInfo.Visible == false) schoolYearInfo.Visible = true;
            schoolYearInfo.TitleInfoLabel.Text = "INFOS SUR L'ANNEE SCOLAIRE";
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter.ToString();
            schoolYearInfo.NameTextBox.Text = schoolYear.Name;
            schoolYearInfo.StartDateTextBox.Text = schoolYear.StartFirstQuarter?.ToString("dd-MM-yyyy");
            schoolYearInfo.EndDateTextBox.Text = schoolYear.EndThirdQuarter?.ToString("dd-MM-yyyy");
        }

        //chargement des groupes de classes dans le datagridview de la page setting
        private void LoadSchoolGroupListToSettingGridView()
        {
            GridViewTextBoxColumn nameColum = new("Name");
            GridViewTextBoxColumn sequenceColum = new("Sequence");
            nameColum.HeaderText = "Désignation";
            sequenceColum.HeaderText = "Séquence";
            SettingGridView.Columns.Add(nameColum);
            SettingGridView.Columns.Add(sequenceColum);

        }
        //chargement la liste des années scolaires dans le datagridview de la page setting
        private void LoadSchoolYearListToSettingGridView()
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
            //chargement des données
            SettingGridView.DataSource = GetSchoolYears().Result;
        }
        //extraction de la liste des années scolaires de la source de données du système

        private void ShowSchoolYearEditForm(SchoolYear schoolYear)
        {
            if (schoolYear != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolYearForm>();
                form.Init(schoolYear);
                form.ShowDialog(this);
            }
            else
            {
                RadMessageBox.Show("Année scolaire inconnue");
            }
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
                schoolYearInfo.Visible = (int)SettingLeftListView.SelectedItem.Key == 1;
                switch (SettingLeftListView.SelectedItem.Key)
                {
                    case 1:
                        LoadSchoolYearListToSettingGridView();
                        SettingSearchTextBox.NullText = "Rechercher par Désignation";
                        break;
                    case 2:
                        LoadSchoolGroupListToSettingGridView();
                        SettingSearchTextBox.NullText = "Rechercher par Désignation";
                        break;
                    default:
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
                        break;
                    case 2:
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
            RadMessageBox.Show("En cours d'implementation");
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

        #region Services
        private async Task<List<SchoolYear>> GetSchoolYears()
        {
            return await schoolYearService.GetAllSchoolYears();
        }

        #endregion
    }
}
