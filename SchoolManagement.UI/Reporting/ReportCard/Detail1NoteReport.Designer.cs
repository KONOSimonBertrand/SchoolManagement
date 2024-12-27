namespace SchoolManagement.UI.Reporting
{
    partial class Detail1NoteReport
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
            this.notedOnTextBox = new Telerik.Reporting.TextBox();
            this.ratingTextBox = new Telerik.Reporting.TextBox();
            this.noteTextBox = new Telerik.Reporting.TextBox();
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
            this.notedOnTextBox,
            this.ratingTextBox,
            this.noteTextBox,
            this.PositionTextBox});
            this.dataPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.2D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.9D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.dataPanel.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.subjectTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.subjectTextBox.Style.Font.Name = "Times New Roman";
            this.subjectTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.subjectTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.subjectTextBox.Value = "=SubjectName";
            // 
            // notedOnTextBox
            // 
            this.notedOnTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.028D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.notedOnTextBox.Name = "notedOnTextBox";
            this.notedOnTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.55D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.notedOnTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.notedOnTextBox.Style.Font.Bold = true;
            this.notedOnTextBox.Style.Font.Name = "Times New Roman";
            this.notedOnTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.notedOnTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.notedOnTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.notedOnTextBox.Value = "=MaxNote";
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.131D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.433D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.ratingTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ratingTextBox.Style.Font.Name = "Times New Roman";
            this.ratingTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ratingTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ratingTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ratingTextBox.Value = "=Rated";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.578D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.55D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.noteTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.noteTextBox.Style.Font.Name = "Times New Roman";
            this.noteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.noteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.noteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.noteTextBox.Value = "=Note";
            // 
            // PositionTextBox
            // 
            this.PositionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.564D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.PositionTextBox.Name = "PositionTextBox";
            this.PositionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.433D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.PositionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.PositionTextBox.Style.Font.Name = "Times New Roman";
            this.PositionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.PositionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.PositionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PositionTextBox.Value = "=Rank";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Detail1NoteReport
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.Add(new Telerik.Reporting.Filter("=Fields.GroupId", Telerik.Reporting.FilterOperator.Equal, "= Parameters.GroupID.Value"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "DetailNoteMonth";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(5D));
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
        private Telerik.Reporting.Panel dataPanel;
        private Telerik.Reporting.TextBox subjectTextBox;
        private Telerik.Reporting.TextBox notedOnTextBox;
        private Telerik.Reporting.TextBox ratingTextBox;
        private Telerik.Reporting.TextBox noteTextBox;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox positionTextBox;
    }
}