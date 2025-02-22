namespace SchoolManagement.UI.Reporting
{
    partial class Subreport3NoteReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.dataPanel = new Telerik.Reporting.Panel();
            this.subjectTextBox = new Telerik.Reporting.TextBox();
            this.noteMaxTextBox = new Telerik.Reporting.TextBox();
            this.firstNoteTextBox = new Telerik.Reporting.TextBox();
            this.ratingTextBox = new Telerik.Reporting.TextBox();
            this.secondNoteTextBox = new Telerik.Reporting.TextBox();
            this.finalNoteTextBox = new Telerik.Reporting.TextBox();
            this.thirdNoteTextBox = new Telerik.Reporting.TextBox();
            this.positionTextBox = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.15D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.dataPanel});
            this.detail.Name = "detail";
            // 
            // dataPanel
            // 
            this.dataPanel.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subjectTextBox,
            this.noteMaxTextBox,
            this.firstNoteTextBox,
            this.ratingTextBox,
            this.secondNoteTextBox,
            this.finalNoteTextBox,
            this.thirdNoteTextBox,
            this.positionTextBox});
            this.dataPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.2D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.9D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.dataPanel.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.51D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.subjectTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.subjectTextBox.Style.Font.Name = "Times New Roman";
            this.subjectTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.subjectTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.subjectTextBox.Value = "=SubjectName";
            // 
            // noteMaxTextBox
            // 
            this.noteMaxTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.52D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.noteMaxTextBox.Name = "noteMaxTextBox";
            this.noteMaxTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.433D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.noteMaxTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.noteMaxTextBox.Style.Font.Bold = true;
            this.noteMaxTextBox.Style.Font.Name = "Times New Roman";
            this.noteMaxTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.noteMaxTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.noteMaxTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.noteMaxTextBox.Value = "=MaxNote";
            // 
            // firstNoteTextBox
            // 
            this.firstNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.962D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.firstNoteTextBox.Name = "firstNoteTextBox";
            this.firstNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.firstNoteTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.firstNoteTextBox.Style.Font.Name = "Times New Roman";
            this.firstNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.firstNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.firstNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.firstNoteTextBox.Value = "=FirstNoteString";
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.ratingTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ratingTextBox.Style.Font.Name = "Times New Roman";
            this.ratingTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ratingTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ratingTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ratingTextBox.Value = "=Rated";
            // 
            // secondNoteTextBox
            // 
            this.secondNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.548D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.secondNoteTextBox.Name = "secondNoteTextBox";
            this.secondNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.secondNoteTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.secondNoteTextBox.Style.Font.Name = "Times New Roman";
            this.secondNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.secondNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.secondNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.secondNoteTextBox.Value = "=SecondNoteString";
            // 
            // finalNoteTextBox
            // 
            this.finalNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.72D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.finalNoteTextBox.Name = "finalNoteTextBox";
            this.finalNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.finalNoteTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.finalNoteTextBox.Style.Font.Name = "Times New Roman";
            this.finalNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.finalNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.finalNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.finalNoteTextBox.Value = "=FinalNoteString";
            // 
            // thirdNoteTextBox
            // 
            this.thirdNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.134D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.thirdNoteTextBox.Name = "thirdNoteTextBox";
            this.thirdNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.thirdNoteTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.thirdNoteTextBox.Style.Font.Name = "Times New Roman";
            this.thirdNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.thirdNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.thirdNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.thirdNoteTextBox.Value = "=ThirdNoteString";
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.706D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.positionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.positionTextBox.Style.Font.Name = "Times New Roman";
            this.positionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.positionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.positionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.positionTextBox.Value = "=Rank";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Detail3NotesReport
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.Add(new Telerik.Reporting.Filter("= Fields.GroupId", Telerik.Reporting.FilterOperator.Equal, "= Parameters.GroupID.Value"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "DetailNotesReport";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "GroupID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "0";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(8.268D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.Panel dataPanel;
        private Telerik.Reporting.TextBox subjectTextBox;
        private Telerik.Reporting.TextBox noteMaxTextBox;
        private Telerik.Reporting.TextBox firstNoteTextBox;
        private Telerik.Reporting.TextBox ratingTextBox;
        private Telerik.Reporting.TextBox secondNoteTextBox;
        private Telerik.Reporting.TextBox finalNoteTextBox;
        private Telerik.Reporting.TextBox thirdNoteTextBox;
        private Telerik.Reporting.TextBox positionTextBox;
    }
}