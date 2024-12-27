

using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EvaluationSessionStateForm:SchoolManagement.UI.EvaluationSessionStateForm
    {
        private readonly ILogService logService;
        private readonly ClientApp clientApp;
        private readonly IEvaluationSessionService evaluationSessionService;
        private EvaluationSession selectedSession;
        private List<EvaluationSessionState> oldStateList;
        private List<EvaluationSessionState> newStateList;
        public EvaluationSessionStateForm(ILogService logService, ClientApp clientApp, IEvaluationSessionService evaluationSessionService)
        {
            this.logService = logService;
            this.clientApp = clientApp;
            oldStateList = new List<EvaluationSessionState>();
            newStateList = new List<EvaluationSessionState>();
            this.evaluationSessionService = evaluationSessionService;
            InitEvents();
            CreateGridViewColumn();
        }
        //init events
        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            PrintButton.Click += (o, ev) => { AppUtilities.PrintGridView(DataGridView, Language.TitleEvaluationState); };
            ExportButton.Click += (o, ev) => { AppUtilities.ExportGridViewToExcel(DataGridView, Language.TitleEvaluationState); };
            FilterTextBox.TextChanged+= (o, ev) => { DataGridView.MasterTemplate.Refresh(); };
            DataGridView.CustomFiltering += DataGridView_CustomFiltering;
            DataGridView.ContextMenuOpening += DataGridView_ContextMenuOpening;
        }

        private void DataGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            //don't add  header's item
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                if(DataGridView.CurrentRow!=null && DataGridView.CurrentRow.DataBoundItem is EvaluationSessionState state)
                {
                    var title = state.IsClosed ? Language.LabelActivateEvaluation : Language.LabelCloseEvaluation;
                    var imageText = state.IsClosed ? "Unlock" : "Lock";
                    RadMenuItem changeStateMenu = new(title);
                    changeStateMenu.Image = AppUtilities.GetImage(imageText);
                    e.ContextMenu.Items.Add(changeStateMenu);
                    changeStateMenu.Click += (o, ev) => {
                        state.IsClosed = !state.IsClosed;
                        DataGridView.MasterTemplate.Refresh();
                        SaveState(state); 
                    };
                }
            }
        }

        // fillter datagrid view
        private void DataGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            if (FilterTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["SchoolYear.Name"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower()) ||
                     e.Row.Cells["State"].Value.ToString().ToLower().Contains(FilterTextBox.Text.ToLower());
            }
        }

        internal void InitStartup(EvaluationSession session)
        {
            selectedSession = session;
            this.Text = session.ToString() + ":.." + Language.TitleEvaluationState;
            LoadSessionStateList();
        }

        //load data to grid view
        private async void LoadSessionStateList()
        {
            if (selectedSession != null) {
                var statesFetch = await evaluationSessionService.GetEvaluationSessionStateListByEvaluationAsync(selectedSession.Id);
                oldStateList.AddRange(statesFetch);
                var yearList=statesFetch.Select(x=>x.SchoolYearId);
                var stateListToPush = new List<EvaluationSessionState>();
                stateListToPush.AddRange(oldStateList);
                foreach (var year in Program.SchoolYearList.Where(x=> yearList.Contains(x.Id)==false)) {
                    newStateList.Add(new EvaluationSessionState{
                        SchoolYearId = year.Id,
                        SchoolYear = year,
                        EvaluationId=selectedSession.Id,
                        EvaluationSession=selectedSession,
                        IsClosed=false,
                    });
                }
                stateListToPush.AddRange(newStateList);
                DataGridView.DataSource = stateListToPush;
            }
        }
        //Création des colonnes du datagridview
        private void CreateGridViewColumn()
        {
            DataGridView.AllowColumnChooser = false;
            DataGridView.ShowFilteringRow = false;
            DataGridView.AllowAddNewRow = false;
            DataGridView.AllowDragToGroup = false;
            DataGridView.AllowEditRow = true;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            DataGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.EnableFiltering = true;
            GridViewTextBoxColumn schoolYearColumn = new("SchoolYear.Name");
            GridViewTextBoxColumn stateColumn = new("State");
            GridViewCheckBoxColumn checkColumn = new("IsClosed");
            ;
            schoolYearColumn.HeaderText = Language.labelSchoolYear;
            stateColumn.HeaderText = Language.labelStatut;
            checkColumn.HeaderText = string.Empty;
            schoolYearColumn.ReadOnly = true;
            stateColumn.ReadOnly = true;
            checkColumn.ReadOnly = false;
            this.DataGridView.Columns.Add(schoolYearColumn);
            this.DataGridView.Columns.Add(stateColumn);
            this.DataGridView.Columns.Add(checkColumn);

            foreach (GridViewDataColumn col in this.DataGridView.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var row in DataGridView.Rows)
            {

                if (row.DataBoundItem is EvaluationSessionState state)
                {
                    SaveState(state);
                }
            }
        }
        private void SaveState(EvaluationSessionState state) {
            bool isDone;
            var logMessage = state.IsClosed ? $"Clôture du l'évaluation {state.EvaluationSession.FrenchName} de {state.SchoolYear.Name} " : $"Activation du l'évaluation {state.EvaluationSession.FrenchName} de {state.SchoolYear.Name} ";
            var errorMessage= Language.messageUpdateError;
            if (oldStateList.Contains(state)) {
                isDone=evaluationSessionService.UpdateEvaluationSessionStateAsync(state).Result;
            }
            else
            {
                errorMessage = Language.messageAddError;
                isDone = evaluationSessionService.CreateEvaluationSessionStateAsync(state).Result;
            }
            if (isDone)
            {
                //enregistrement du log
                Log log = new()
                {
                    UserAction = $"{logMessage}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                    UserId = clientApp.UserConnected.Id
                };
                logService.CreateLog(log);
                
            }
            else
            {
                RadMessageBox.Show(errorMessage,"SCHOOL APP",MessageBoxButtons.OK,RadMessageIcon.Error);
            }
        }
    }
}
