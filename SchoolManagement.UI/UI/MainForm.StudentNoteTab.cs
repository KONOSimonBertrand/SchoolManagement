﻿using SchoolManagement.UI.CustomControls;
using SchoolManagement.UI.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class MainForm
    {
        public RadDropDownList StudentNoteSchoolYearDropDownList { get => studentNoteSchoolYearDropDownList; }
        public SearchTextBox StudentNoteSearchTextBox { get => studentNoteSearchTextBox; }
        public RadDropDownList StudentNoteRoomDropDownList {  get => studentNoteRoomDropDownList; }
        public RadDropDownList StudentNoteGroupDropDownList {  get => studentNoteGroupDropDownList; }
        public RadDropDownButton StudentNoteAddButton { get => studentNoteAddButton; }
        public RadMenuItem StudentNoteAddOneNoteMenu { get => studentNoteAddNoteMenu; }
        public RadMenuItem StudentNoteAddNotesMenu { get => studentNoteAddNotesMenu; }
        public RadMenuItem StudentNoteAddCommentMenu { get => studentNoteAddCommentMenu; }
        public RadMenuItem StudentNoteImportNoteMenu { get => studentNoteImportNoteMenu; }
        public RadButton StudentNoteExportToExcelButton {  get => studentNoteExportToExcelButton; }
        public RadToggleButton StudentNoteIconViewToggleButton {  get => studentNoteIconViewToggleButton; }
        public RadToggleButton StudentNoteListViewToggleButton {  get => studentNoteListViewToggleButton; }
        public RadGridView StudentNoteGridView {  get => studentNoteGridView; }
        public RadPanel StudentNoteInfoRightPanel {  get => studentNoteInfoRightPanel; }
        public RadListView StudentNoteLeftListView { get => studentNoteLeftListView; }
        private void InitStudentNotePage()
        {
            studentNoteMainPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            studentNoteMainPanel.BackgroundImage = Resources.Background;
            studentNoteMainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            studentNoteMainPanel.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;

            studentNoteNavigationPanel.BackgroundImage = Resources.fasha_no_borders;
            studentNoteNavigationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            studentNoteNavigationPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            studentNoteNavigationPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            studentNoteNavigationPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            studentNoteSearchPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            studentNoteSearchPanel.RootElement.EnableElementShadow = false;
            studentNoteSearchPanel.BackColor = Color.Transparent;
            studentNoteSearchPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            studentNoteEmptyPanel.PanelElement.PanelFill.BackColor = Color.Transparent;
            studentNoteEmptyPanel.BackColor = Color.Transparent;
            studentNoteEmptyPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            studentNoteEmptyPanel.RootElement.EnableElementShadow = false;

            studentNoteAddButton.RootElement.ToolTipText = "Cliquer ici pour ajouter des notes";
            studentNoteAddButton.TextAlignment = ContentAlignment.MiddleCenter;

            studentNoteExportToExcelButton.TextAlignment = ContentAlignment.MiddleCenter;
            studentNoteExportToExcelButton.ButtonElement.ToolTipText = "Cliquer ici pour exporter les données vers excel";

            studentNoteSearchTextBox.NullText = "Rechercher par élève et par matière";
            studentNoteIconViewToggleButton.ButtonElement.ToolTipText = "Vue groupée";
            studentNoteIconViewToggleButton.RootElement.EnableElementShadow = false;
            studentNoteIconViewToggleButton.ButtonElement.Padding = new Padding(0);
            studentNoteIconViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            studentNoteIconViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            studentNoteIconViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            studentNoteIconViewToggleButton.Text = "\ue025";
            studentNoteIconViewToggleButton.RootElement.CustomFontSize = 20;

            studentNoteListViewToggleButton.ButtonElement.ToolTipText = "Vue détaillée";
            studentNoteListViewToggleButton.RootElement.EnableElementShadow = false;
            studentNoteListViewToggleButton.ButtonElement.Padding = new Padding(0);
            studentNoteListViewToggleButton.ImageAlignment = ContentAlignment.MiddleCenter;
            studentNoteListViewToggleButton.TextAlignment = ContentAlignment.MiddleCenter;
            studentNoteListViewToggleButton.RootElement.CustomFont = "TelerikWebUI";
            studentNoteListViewToggleButton.RootElement.CustomFontSize = 20;
            studentNoteListViewToggleButton.Text = "\ue024";

            studentNoteLeftListView.ShowGroups = true;
            studentNoteLeftListView.EnableGrouping = true;
            studentNoteLeftListView.EnableCustomGrouping = true;
            studentNoteLeftListView.ShowCheckBoxes = true;
            studentNoteLeftListView.AllowEdit = false;
            studentNoteLeftListView.RootElement.EnableElementShadow = false;
            studentNoteLeftListView.HotTracking = false;
            studentNoteLeftListView.ListViewElement.Padding = new Padding(0, 16, 0, 0);

            studentNoteSchoolYearDropDownList.RootElement.EnableElementShadow = false;
            studentNoteSchoolYearDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            studentNoteSchoolYearDropDownList.RootElement.CustomFontSize = 10.5f;
            studentNoteSchoolYearDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            studentNoteSchoolYearDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            studentNoteRoomDropDownList.RootElement.EnableElementShadow = false;
            studentNoteRoomDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            studentNoteRoomDropDownList.RootElement.CustomFontSize = 10.5f;
            studentNoteRoomDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            studentNoteRoomDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            studentNoteGroupDropDownList.RootElement.EnableElementShadow = false;
            studentNoteGroupDropDownList.RootElement.CustomFont = ViewUtilities.MainFont;
            studentNoteGroupDropDownList.RootElement.CustomFontSize = 10.5f;
            studentNoteGroupDropDownList.ForeColor = Color.FromArgb(33, 33, 33);
            studentNoteGroupDropDownList.RootElement.Padding = new Padding(3, 0, 0, 0);

            studentNoteSchoolYearLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            studentNoteSchoolYearLabel.LabelElement.CustomFontSize = 10.5f;
            studentNoteSchoolYearLabel.ForeColor = Color.FromArgb(89, 89, 89);
            studentNoteSchoolYearLabel.TextAlignment = ContentAlignment.BottomCenter;

            studentNoteRoomLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            studentNoteRoomLabel.LabelElement.CustomFontSize = 10.5f;
            studentNoteRoomLabel.ForeColor = Color.FromArgb(89, 89, 89);
            studentNoteRoomLabel.TextAlignment = ContentAlignment.BottomCenter;

            studentNoteGroupLabel.LabelElement.CustomFont = ViewUtilities.MainFont;
            studentNoteGroupLabel.LabelElement.CustomFontSize = 10.5f;
            studentNoteGroupLabel.ForeColor = Color.FromArgb(89, 89, 89);
            studentNoteGroupLabel.TextAlignment = ContentAlignment.BottomCenter;

            studentNoteGridView.TableElement.CellSpacing = 10;
            studentNoteGridView.RootElement.EnableElementShadow = false;
            studentNoteGridView.GridViewElement.DrawFill = false;
            studentNoteGridView.TableElement.Margin = new Padding(15, 0, 15, 0);
            studentNoteGridView.BackColor = Color.Transparent;
            studentNoteGridView.GridViewElement.DrawFill = true;
            studentNoteGridView.AllowAddNewRow = false;
            studentNoteGridView.EnableGrouping = false;

            studentNoteInfoRightPanel.RootElement.EnableElementShadow = false;
            studentNoteInfoRightPanel.Visible = false;
            studentNoteEmptyPanel.RootElement.EnableElementShadow = false;


        }
    }
}
