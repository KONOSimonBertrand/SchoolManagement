using static Primary.SchoolApp.DTO.DTOItem;
using System.Collections.Generic;
using SchoolManagement.UI.Localization;
using Telerik.WinControls.UI;
using System.Drawing;
using SchoolManagement.Core.Model;
using Primary.SchoolApp.Utilities;
using System.Linq;

namespace Primary.SchoolApp.UI
{
    internal class RecapNotesForm:SchoolManagement.UI.RecapNotesForm
    {
        public RecapNotesForm()
        {

        }
        public void InitStartUp(List<RecapNoteItem> dataSource,SchoolRoom room,string area)
        {
            CmdExport.Image = AppUtilities.GetImage("Excel");
            CmdPrint.Image = AppUtilities.GetImage("Printer");
            if (area == "room")
            {
                CmdTitle.Text = room!=null? room.Name :string.Empty;
            }
            else
            {
                var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
                var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
                CmdTitle.Text = area == "class" ? classOfRoom.Name : classGroup.Name;
            }
            
            CreateGridViewColumn(area);
            ReportGrid.DataSource = dataSource;
        }

        //Création des colonnes du datagridview
        private void CreateGridViewColumn(string area)
        {
           ReportGrid.ReadOnly = true;
            ReportGrid.AllowColumnChooser = true;
            ReportGrid.ShowFilteringRow = true;
            ReportGrid.AllowAddNewRow = false;
            ReportGrid.AllowDragToGroup = true;
            ReportGrid.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            ReportGrid.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            ReportGrid.EnableCustomFiltering = false;
            ReportGrid.EnableFiltering = true;
            GridViewTextBoxColumn studentIdColumn = new("StudentMatricule");
            GridViewTextBoxColumn studentNameColumn = new("StudentName");
            GridViewTextBoxColumn studentRoomColumn = new("StudentRoom");
            GridViewTextBoxColumn subjectColumn = new("SubjectName");
            GridViewDecimalColumn firstTermColumn = new("FirstTermAverage");
            GridViewDecimalColumn secondTermColumn = new("SecondTermAverage");
            GridViewDecimalColumn thirdTermColumn = new("ThirdTermAverage");
            GridViewDecimalColumn annualAverageColumn = new("AnnualAverage");
            GridViewTextBoxColumn appreciationColumn = new("Appreciation");
            GridViewTextBoxColumn positionColumn = new("Position");
            studentIdColumn.HeaderText = Language.labelStudentId;
            studentNameColumn.HeaderText = Language.labelStudent;
            subjectColumn.HeaderText = Language.labelSubject;
            studentRoomColumn.HeaderText = Language.labelClass;
            firstTermColumn.HeaderText = Language.LabelTerm1; 
            secondTermColumn.HeaderText = Language.LabelTerm2;
            thirdTermColumn.HeaderText = Language.LabelTerm3;
            annualAverageColumn.HeaderText = Language.LabelAverage;
            appreciationColumn.HeaderText = Language.labelAppreciation;
            positionColumn.HeaderText = Language.LabelPosition;
            this.ReportGrid.Columns.Add(studentIdColumn);
            this.ReportGrid.Columns.Add(studentNameColumn);
            if(area!="room") this.ReportGrid.Columns.Add(studentRoomColumn);
            this.ReportGrid.Columns.Add(subjectColumn);
            this.ReportGrid.Columns.Add(firstTermColumn);
            this.ReportGrid.Columns.Add(secondTermColumn);
            this.ReportGrid.Columns.Add(thirdTermColumn);
            this.ReportGrid.Columns.Add(annualAverageColumn);
            this.ReportGrid.Columns.Add(appreciationColumn);
            this.ReportGrid.Columns.Add(positionColumn);
            foreach (GridViewDataColumn col in this.ReportGrid.Columns)
            {
                col.HeaderTextAlignment = ContentAlignment.MiddleLeft;
            }
        }

    }
}
