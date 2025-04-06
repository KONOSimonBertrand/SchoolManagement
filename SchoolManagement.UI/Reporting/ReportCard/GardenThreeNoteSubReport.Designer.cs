namespace SchoolManagement.UI.Reporting
{
    partial class GardenThreeNoteSubReport
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
            this.ratingTextBox = new Telerik.Reporting.TextBox();
            this.finalNoteTextBox = new Telerik.Reporting.TextBox();
            this.secondNoteTextBox = new Telerik.Reporting.TextBox();
            this.thirdNoteTextBox = new Telerik.Reporting.TextBox();
            this.firstNoteTextBox = new Telerik.Reporting.TextBox();
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
            this.ratingTextBox,
            this.finalNoteTextBox,
            this.secondNoteTextBox,
            this.thirdNoteTextBox,
            this.firstNoteTextBox});
            this.dataPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.2D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.9D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.dataPanel.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.subjectTextBox.Style.Font.Name = "Calibri";
            this.subjectTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.subjectTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.subjectTextBox.Value = "=SubjectName";
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.ratingTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ratingTextBox.Style.Font.Name = "Calibri";
            this.ratingTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ratingTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ratingTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ratingTextBox.Value = "=Rated";
            // 
            // finalNoteTextBox
            // 
            this.finalNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.finalNoteTextBox.Name = "finalNoteTextBox";
            this.finalNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.finalNoteTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.finalNoteTextBox.Style.Font.Name = "Calibri";
            this.finalNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.finalNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.finalNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.finalNoteTextBox.Value = "=FinalNoteString";
            // 
            // secondNoteTextBox
            // 
            this.secondNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.secondNoteTextBox.Name = "secondNoteTextBox";
            this.secondNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.secondNoteTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.secondNoteTextBox.Style.Font.Name = "Calibri";
            this.secondNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.secondNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.secondNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.secondNoteTextBox.Value = "=SecondNoteString";
            // 
            // thirdNoteTextBox
            // 
            this.thirdNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.thirdNoteTextBox.Name = "thirdNoteTextBox";
            this.thirdNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.thirdNoteTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.thirdNoteTextBox.Style.Font.Name = "Calibri";
            this.thirdNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.thirdNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.thirdNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.thirdNoteTextBox.Value = "=ThirdNoteString";
            // 
            // firstNoteTextBox
            // 
            this.firstNoteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.firstNoteTextBox.Name = "firstNoteTextBox";
            this.firstNoteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6D), Telerik.Reporting.Drawing.Unit.Inch(0.15D));
            this.firstNoteTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.firstNoteTextBox.Style.Font.Name = "Calibri";
            this.firstNoteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.firstNoteTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.firstNoteTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.firstNoteTextBox.Value = "=FirstNoteString";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // GardenDetail3NotesReport
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
        private Telerik.Reporting.TextBox ratingTextBox;
        private Telerik.Reporting.TextBox finalNoteTextBox;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox secondNoteTextBox;
        private Telerik.Reporting.TextBox thirdNoteTextBox;
        private Telerik.Reporting.TextBox firstNoteTextBox;
    }
}