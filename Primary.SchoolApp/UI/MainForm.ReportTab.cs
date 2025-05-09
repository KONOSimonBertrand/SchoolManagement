using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.CustomElements;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using Primary.SchoolApp.UI;
using Primary.SchoolApp.Utilities;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp
{
    public partial class MainForm
    {
        private string reportForToolTipText = string.Empty;
        private readonly Dictionary<int?, Dictionary<int,DataTable>> generalReportTaskResult = new();
        private readonly ListingService listingService;
        private ListingItem selectedReport;
        private void InitReportPage()
        {

            InitReportPageEvents();
            InitMainListView();
        }
        // Wired events
        private void InitReportPageEvents()
        {
            ReportMainListView.ItemDataBound += ReportMainListView_ItemDataBound;
            ReportMainListView.VisualItemFormatting += ReportMainListView_VisualItemFormatting;
            ReportMainListView.ToolTipTextNeeded += ReportMainListView_ToolTipTextNeeded;
            ReportMainListView.ItemMouseHover += ReportMainListView_ItemMouseHover;
            ReportMainListView.ItemMouseClick += ReportMainListView_ItemMouseClick;
            ReportMainListView.ItemMouseDoubleClick += async (sender, e) => await ReportMainListView_ItemMouseDoubleClick(sender,e);
            ReportMainListView.SelectedIndexChanged += ReportMainListView_SelectedIndexChanged;
            ReportSearchTextBox.TextChanged += ReportSearchTextBox_TextChanged;
        }
        private async Task ReportMainListView_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataBoundItem is ListingItem item)
            {
                selectedReport = item;
                if (this.TaskWaitingBar.Visibility == ElementVisibility.Hidden)
                {
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                }
                var task = Task.Run(GetReport);
                runningTaskCount++;
                this.TaskWaitingBar.Text = runningTaskCount.ToString();
                await task;
                int[] reports_with_detail = {9};
                if (generalReportTaskResult.TryGetValue(task.Id, out var result))
                {
                    var form = Program.ServiceProvider.GetService<GeneralReportForm>();
                    form.Icon = this.Icon;
                    form.TitleLabel.Text = Language.LanguageName=="EN"? item.EnglishName: item.FrenchName;
                    form.TitleLabel.Text = $"{form.TitleLabel.Text} :{Program.CurrentSchoolYear.Name}";
                    form.Text = form.TitleLabel.Text;
                    if (!reports_with_detail.Contains(item.Id))
                    {
                        form.IconViewToggleButton.Enabled=false;
                        form.ListViewToggleButton.Enabled = false;
                    }
                    else
                    {
                        form.IconViewToggleButton.ToggleState = ToggleState.On;
                    }
                    if (result.TryGetValue(1, out var dataTable))
                    {
                        LoadDataForIconView(form,item, dataTable);
                    }
                    
                        bool updatingReportToggleState = false;
                  
                    form.IconViewToggleButton.ToggleStateChanging += (s, e) => {
                        if (!updatingReportToggleState && e.OldValue == ToggleState.On)
                        {
                            e.Cancel = true;
                        }
                    };

                    form.ListViewToggleButton.ToggleStateChanging += (s, e) => {
                        if (!updatingReportToggleState && e.OldValue == ToggleState.On)
                        {
                            e.Cancel = true;
                        }
                    };

                    form.IconViewToggleButton.ToggleStateChanged += (s, e) => {

                        if (updatingReportToggleState)
                        {
                            return;
                        }
                        if (result.TryGetValue(1, out var dataTable))
                        {
                            LoadDataForIconView(form, item, dataTable);
                        }
                        updatingReportToggleState = true;
                        form.ListViewToggleButton.ToggleState = ToggleState.Off;
                        updatingReportToggleState = false;
                        
                    };

                    form.ListViewToggleButton.ToggleStateChanged += (s, e) => {

                        if (updatingReportToggleState)
                        {
                            return;
                        }
                        if (result.TryGetValue(2, out var detailDataTable))
                        {
                            LoadDataForDetailView(form, item, detailDataTable);
                        }
                        updatingReportToggleState = true;
                        form.IconViewToggleButton.ToggleState = ToggleState.Off;
                        updatingReportToggleState = false;
                        
                    };


                    form.PrintButton.Click += (sender, e) => {
                        AppUtilities.PrintGridView(form.ReportGrid, form.TitleLabel.Text);
                    };
                    form.ExportButton.Click += (sender, e) => {
                        AppUtilities.ExportGridViewToExcel(form.ReportGrid, form.TitleLabel.Text);
                    };
                    form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    generalReportTaskResult.Remove(task.Id);
                }

            }
        }
        private void LoadDataForDetailView(GeneralReportForm form,ListingItem item,DataTable dataTable)
        {
            if (form == null) return;
            if (item == null) return;
            if (dataTable == null) return;
            form.ReportGrid.MasterTemplate.Columns.Clear();
            form.ReportGrid.MasterTemplate.SummaryRowsBottom.Clear();
            form.ReportGrid.DataSource = null;
            form.ReportGrid.DataSource = dataTable;
            form.ReportGrid.BestFitColumns();
            GridViewSummaryRowItem summaryRow;
            string refColumn = Language.LanguageName == "EN" ? "REF" : "REF";
            string amountColumn = Language.LanguageName == "EN" ? "AMOUNT" : "MONTANT";
            switch (item.Id)
            {
                case 9:
                    form.ReportGrid.Columns[0].FormatString = "{0:dd-MM-yyyy}";
                    summaryRow = new GridViewSummaryRowItem {
                                          new (amountColumn, "{0}", GridAggregateFunction.Sum),
                                          new(refColumn,"{0}", GridAggregateFunction.Count)
                                        };
                    form.ReportGrid.MasterTemplate.SummaryRowsBottom.Add(summaryRow);
                    break;
            }
        }
        private void LoadDataForIconView(GeneralReportForm form, ListingItem item, DataTable dataTable)
        {
            if (form == null) return;
            if (item == null) return;
            if (dataTable == null) return;
            form.ReportGrid.MasterTemplate.Columns.Clear();
            form.ReportGrid.MasterTemplate.SummaryRowsBottom.Clear();
            form.ReportGrid.DataSource = null;
            form.ReportGrid.MasterTemplate.SummaryRowsBottom.Clear();
            form.ReportGrid.DataSource = dataTable;
            form.ReportGrid.BestFitColumns();
            GridViewSummaryRowItem summaryRow;
            var studentIdColumn = Language.LanguageName == "EN" ? "ID" : "MATRICULE";
            string unpaidColumn = Language.LanguageName == "EN" ? "UNPAID" : "IMPAYÉ";
            switch (item.Id)
            {
                case 6:
                    form.ReportGrid.Columns[4].FormatString = "{0:dd-MM-yyyy}";
                    break;
                case 7:
                    form.ReportGrid.Columns[4].FormatString = "{0:dd-MM-yyyy}";
                    form.ReportGrid.Columns[10].FormatString = "{0:dd-MM-yyyy}";
                    break;
                case 8:
                    form.ReportGrid.Columns[0].FormatString = "{0:dd-MM-yyyy}";
                    form.ReportGrid.Columns[5].FormatString = "{0:dd-MM-yyyy}";
                    summaryRow = new GridViewSummaryRowItem {
                                    new GridViewSummaryItem(studentIdColumn, " {0}", GridAggregateFunction.Count),
                                    new GridViewSummaryItem(unpaidColumn, " {0}", GridAggregateFunction.Sum)
                                };
                    form.ReportGrid.MasterTemplate.SummaryRowsBottom.Add(summaryRow);
                    break;
                case 9:
                    summaryRow = new GridViewSummaryRowItem
                    {
                        new(form.ReportGrid.Columns[1].Name, " {0}", GridAggregateFunction.Count) // Nbre total des élèves
                    };
                    for (int i=3;i< form.ReportGrid.ColumnCount;i++)
                    {
                        summaryRow.Add(new(form.ReportGrid.Columns[i].Name," {0}", GridAggregateFunction.Sum));
                    }
                    form.ReportGrid.MasterTemplate.SummaryRowsBottom.Add(summaryRow);
                    break;
            }
        }
        private void GetReport()
        {
            if(selectedReport == null) return;
            Task<Dictionary<int, DataTable>> task;
            switch (selectedReport.Id)
            {
                case 1:
                    task = listingService.GetClassList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result );
                    break;
                case 2:
                    task = listingService.GetRoomList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 3:
                    task = listingService.GetSubjectList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 4:
                    task = listingService.GetFeeSchoolList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 5:
                    task = listingService.GetFeeSubscriptionList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 6:
                    task = listingService.GetStudentList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 7:
                    task = listingService.GetEmployeeList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                case 8:
                    task = listingService.GetInscriptioList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;
                    case 9:
                    task = listingService.GetInscriptionPaymentList();
                    generalReportTaskResult.Add(Task.CurrentId, task.Result);
                    break;

            }

            runningTaskCount--;
            this.TaskWaitingBar.Text = runningTaskCount.ToString();
            if (runningTaskCount == 0)
            {
                this.TaskWaitingBar.StopWaiting();
                this.TaskWaitingBar.ResetWaiting();
                this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            }
        }

        private void ReportMainListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            e.ListViewElement.SelectedItem = e.Item;
        }

        private void ReportMainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportInfo();
        }

        private void ReportSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ReportSearchTextBox.Text == string.Empty)
            {
                ReportMainListView.FilterPredicate = null;
            }
            else
            {
                ReportMainListView.FilterPredicate = null;
                ReportMainListView.FilterPredicate = FilterReportPredicate;
            }
        }
        private bool FilterReportPredicate(ListViewDataItem item)
        {
            if (ReportSearchTextBox.Text != string.Empty)
            {
                if (item?.DataBoundItem is ListingItem listingItemitem)
                {
                    var nameSearch = Language.LanguageName == "FR" ? listingItemitem.FrenchName : listingItemitem.EnglishName;
                    if (nameSearch.ToLower().Contains(ReportSearchTextBox.Text.ToLower()))
                    {
                        return true;
                    }
                    var descriptionSearch = Language.LanguageName == "FR" ? listingItemitem.FrenchDescription : listingItemitem.EnglishDescription;
                    if (descriptionSearch.ToLower().Contains(ReportSearchTextBox.Text.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ReportMainListView_ItemMouseHover(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataBoundItem is ListingItem item)
            {
                reportForToolTipText = Language.LanguageName == "EN" ? item.EnglishDescription : item.FrenchDescription;
            }
        }

        private void ReportMainListView_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            try
            {
                var item = ReportMainListView.SelectedItem;
                e.Offset = new Size(e.Offset.Width + 20, e.Offset.Height + 20);
                e.ToolTipText = reportForToolTipText;
            }
            catch
            {
            }
        }

        private void ReportMainListView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            if (ReportMainListView.ViewType == ListViewType.IconsView)
            {
                //if (TelerikHelper.IsDarkTheme("Windows11Dark"))
                //{
                //}

                e.VisualItem.ImageLayout = ImageLayout.Center;
                e.VisualItem.ImageAlignment = ContentAlignment.MiddleCenter;
            }
        }

        private void ReportMainListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            e.Item.Image = AppUtilities.GetImage(Resources.report);
        }

        private void InitMainListView()
        {
            ReportMainListView.ViewType = ListViewType.IconsView;
            ReportMainListView.ItemSize = new Size(200, 120);
            ReportMainListView.ItemSpacing = 10;
            ReportMainListView.AllowEdit = false;
            ReportMainListView.EnableFiltering = true;
            ReportMainListView.HotTracking = false;
            var reportStore = ListingService.GetListingItems();
            if (Program.UserConnected.Name != "root")
            {
                ReportMainListView.DataSource = reportStore;
            }
            else
            {
                var modules = Program.UserConnected.Modules.Select(m => m.ModuleId);
                ReportMainListView.DataSource = reportStore.Where(r => modules.Contains(r.ModuleId));
            }
            ReportMainListView.DisplayMember = Language.fieldName;
            ReportMainListView.ValueMember = "Id";
        }

        private void ReportLeftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new ReportSimpleListViewVisualItem();
            }
        }



        private void LoadClassInfo()
        {

             ReportLeftListView.Groups.Clear();
             ReportLeftListView.Items.Clear();
            ListViewDataItemGroup reportRoomGroup = new();
            reportRoomGroup.Text = "SALLES DE CLASSE";
            reportRoomGroup.Key = 1;
            ListViewDataItemGroup reportStudentGroup = new();
            reportStudentGroup.Text = "ELEVES PAR CLASSE";
            reportStudentGroup.Key = 2;
            ListViewDataItemGroup reportTeacherGroup = new();
            reportTeacherGroup.Text = "ENSEIGNANTS PAR CLASSE";
            reportTeacherGroup.Key = 3;

             ReportLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { reportRoomGroup, reportStudentGroup, reportTeacherGroup });
            foreach (var item in Program.SchoolClassList)
            {
                ListViewDataItem dataItem = new();
                dataItem.Value = item.Name;
                dataItem.Key = item.Id;
                dataItem.Tag = item.Name;
                if (item.Name.Length > 14)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 14) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.Group = reportRoomGroup;
                 ReportLeftListView.Items.Add(dataItem);
            }
            foreach (var item in Program.SchoolClassList)
            {
                ListViewDataItem dataItem = new();
                dataItem.Value = item.Name;
                dataItem.Key = item.Id;
                dataItem.Tag = item.Name;
                if (item.Name.Length > 14)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 14) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.Group = reportStudentGroup;
                 ReportLeftListView.Items.Add(dataItem);
            }
            foreach (var item in Program.SchoolClassList)
            {
                ListViewDataItem dataItem = new();
                dataItem.Value = item.Name;
                dataItem.Key = item.Id;
                dataItem.Tag = item.Name;
                if (item.Name.Length > 14)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 14) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.Group = reportTeacherGroup;
                 ReportLeftListView.Items.Add(dataItem);
            }
            ReportLeftListView.ListViewElement.SynchronizeVisualItems();
        }

        private void LoadRoomInfo()
        {
             ReportLeftListView.Groups.Clear();
             ReportLeftListView.Items.Clear();
            ListViewDataItemGroup reportStudentGroup = new();
            reportStudentGroup.Text = "ELEVES PAR SALLE";
            reportStudentGroup.Key = 1;
            ListViewDataItemGroup reportTeacherGroup = new();
            reportTeacherGroup.Text = "ENSEIGNANTS PAR SALLE";
            reportTeacherGroup.Key = 2;
             ReportLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { reportStudentGroup, reportTeacherGroup });

            foreach (var item in Program.SchoolRoomList)
            {
                ListViewDataItem dataItem = new ListViewDataItem();
                dataItem.Value = item.Name;
                dataItem.Key = item.Id;
                dataItem.Tag = item.Name;
                if (item.Name.Length > 14)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 14) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.Group = reportStudentGroup;
                 ReportLeftListView.Items.Add(dataItem);
            }
            foreach (var item in Program.SchoolRoomList)
            {
                ListViewDataItem dataItem = new();
                dataItem.Value = item.Name;
                dataItem.Key = item.Id;
                dataItem.Tag = item.Name;
                if (item.Name.Length > 14)
                {
                    dataItem.Text = item.Name.ToUpper().Substring(0, 14) + "...";
                }
                else
                {
                    dataItem.Text = item.Name.ToUpper();
                }
                dataItem.Group = reportTeacherGroup;
                 ReportLeftListView.Items.Add(dataItem);
            }

             ReportLeftListView.ListViewElement.SynchronizeVisualItems();

        }
        private void LoadReportInfo()
        {
            if (ReportMainListView?.SelectedItem?.DataBoundItem is ListingItem report)
            {
                switch (report.Id)
                {
                    case 1:
                        LoadClassInfo();
                        break;
                    case 2:
                        LoadRoomInfo();
                        break;
                }
            }
        }

    }


}
