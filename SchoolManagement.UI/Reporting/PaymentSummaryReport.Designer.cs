using Telerik.Reporting;
namespace SchoolManagement.UI.Reporting
{
    partial class PaymentSummaryReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentSummaryReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.signatureLabel = new Telerik.Reporting.TextBox();
            this.shape2 = new Telerik.Reporting.Shape();
            this.totalTextBox = new Telerik.Reporting.TextBox();
            this.labelTotal = new Telerik.Reporting.TextBox();
            this.totalInLetterTextBox = new Telerik.Reporting.TextBox();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.headerPictureBox = new Telerik.Reporting.PictureBox();
            this.schoolYearTextBox = new Telerik.Reporting.TextBox();
            this.reasonLabel = new Telerik.Reporting.TextBox();
            this.amountLabel = new Telerik.Reporting.TextBox();
            this.dateLabel = new Telerik.Reporting.TextBox();
            this.reportTitleTextBox = new Telerik.Reporting.TextBox();
            this.studentLabel = new Telerik.Reporting.TextBox();
            this.studentTexBox = new Telerik.Reporting.TextBox();
            this.classLabel = new Telerik.Reporting.TextBox();
            this.classTextBox = new Telerik.Reporting.TextBox();
            this.studentIdLabel = new Telerik.Reporting.TextBox();
            this.studentIdTextBox = new Telerik.Reporting.TextBox();
            this.studentShape = new Telerik.Reporting.Shape();
            this.shape4 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.detail = new Telerik.Reporting.DetailSection();
            this.dateTextBox = new Telerik.Reporting.TextBox();
            this.amountTextBox = new Telerik.Reporting.TextBox();
            this.reasonTextBox = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.addressTextBox = new Telerik.Reporting.TextBox();
            this.contactTextBox = new Telerik.Reporting.TextBox();
            this.webSiteTextBox = new Telerik.Reporting.TextBox();
            this.schoolNameTextBox = new Telerik.Reporting.TextBox();
            this.facebookPictureBox = new Telerik.Reporting.PictureBox();
            this.schoolStatement = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape3 = new Telerik.Reporting.Shape();
            this.labelPrintDate = new Telerik.Reporting.TextBox();
            this.printDateTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(14.333D);
            this.groupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.signatureLabel,
            this.shape2,
            this.totalTextBox,
            this.labelTotal,
            this.totalInLetterTextBox});
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // signatureLabel
            // 
            this.signatureLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.019D), Telerik.Reporting.Drawing.Unit.Inch(0.821D));
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.15D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.signatureLabel.Style.Font.Bold = true;
            this.signatureLabel.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.signatureLabel.Value = "Signature";
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.989D), Telerik.Reporting.Drawing.Unit.Inch(1.5D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.11D), Telerik.Reporting.Drawing.Unit.Inch(0.035D));
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.totalTextBox.Style.Font.Bold = true;
            this.totalTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.totalTextBox.Value = "0";
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.35D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.05D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.labelTotal.Style.Font.Bold = true;
            this.labelTotal.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.labelTotal.Value = "TOTAL :";
            // 
            // total2TextBox
            // 
            this.totalInLetterTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.05D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.totalInLetterTextBox.Name = "total2TextBox";
            this.totalInLetterTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.05D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.totalInLetterTextBox.Style.Font.Bold = true;
            this.totalInLetterTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.totalInLetterTextBox.Value = " ";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(8.273D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.headerPictureBox,
            this.schoolYearTextBox,
            this.reasonLabel,
            this.amountLabel,
            this.dateLabel,
            this.reportTitleTextBox,
            this.studentLabel,
            this.studentTexBox,
            this.classLabel,
            this.classTextBox,
            this.studentIdLabel,
            this.studentIdTextBox,
            this.studentShape,
            this.shape4,
            this.shape5});
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // logoPictureBox
            // 
            this.headerPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.headerPictureBox.MimeType = "image/png";
            this.headerPictureBox.Name = "logoPictureBox";
            this.headerPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.1D), Telerik.Reporting.Drawing.Unit.Inch(0.94D));
            this.headerPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            // 
            // schoolYearTextBox
            // 
            this.schoolYearTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.079D), Telerik.Reporting.Drawing.Unit.Inch(1.04D));
            this.schoolYearTextBox.Name = "schoolYearTextBox";
            this.schoolYearTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.121D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.schoolYearTextBox.Style.Font.Bold = true;
            this.schoolYearTextBox.Style.Font.Italic = false;
            this.schoolYearTextBox.Style.Font.Name = "Times New Roman";
            this.schoolYearTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.schoolYearTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.schoolYearTextBox.Value = "Année scolaire : 2020 - 2021";
            // 
            // reasonLabel
            // 
            this.reasonLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9D), Telerik.Reporting.Drawing.Unit.Inch(3D));
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2D), Telerik.Reporting.Drawing.Unit.Inch(0.257D));
            this.reasonLabel.Style.BackgroundColor = System.Drawing.Color.Moccasin;
            this.reasonLabel.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonLabel.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonLabel.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonLabel.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonLabel.Style.Font.Bold = true;
            this.reasonLabel.Style.Font.Name = "Times New Roman";
            this.reasonLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.reasonLabel.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.reasonLabel.Value = "MOTIF";
            // 
            // amountLabel
            // 
            this.amountLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(3D));
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.257D));
            this.amountLabel.Style.BackgroundColor = System.Drawing.Color.Moccasin;
            this.amountLabel.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountLabel.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountLabel.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountLabel.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountLabel.Style.Font.Bold = true;
            this.amountLabel.Style.Font.Name = "Times New Roman";
            this.amountLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.amountLabel.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.amountLabel.Value = "MONTANT";
            // 
            // dateLabel
            // 
            this.dateLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.35D), Telerik.Reporting.Drawing.Unit.Inch(3D));
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.05D), Telerik.Reporting.Drawing.Unit.Inch(0.257D));
            this.dateLabel.Style.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dateLabel.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateLabel.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateLabel.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateLabel.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateLabel.Style.Font.Bold = true;
            this.dateLabel.Style.Font.Name = "Times New Roman";
            this.dateLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.dateLabel.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.dateLabel.Value = "DATE";
            // 
            // reportTitleTtextBox
            // 
            this.reportTitleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.588D), Telerik.Reporting.Drawing.Unit.Inch(1.522D));
            this.reportTitleTextBox.Name = "reportTitleTtextBox";
            this.reportTitleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.7D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.reportTitleTextBox.Style.Font.Bold = true;
            this.reportTitleTextBox.Style.Font.Name = "Times New Roman";
            this.reportTitleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.reportTitleTextBox.Style.Font.Underline = true;
            this.reportTitleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.reportTitleTextBox.Value = "RECAPITULATIF DES VERSEMENTS DES FRAIS SCOLAIRES";
            // 
            // studentLabel
            // 
            this.studentLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.388D), Telerik.Reporting.Drawing.Unit.Inch(1.964D));
            this.studentLabel.Name = "studentLabel";
            this.studentLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.612D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.studentLabel.Style.Font.Name = "Times New Roman";
            this.studentLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.studentLabel.Value = "Elève  : ";
            // 
            // studentTexBox
            // 
            this.studentTexBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.109D), Telerik.Reporting.Drawing.Unit.Inch(1.964D));
            this.studentTexBox.Name = "studentTexBox";
            this.studentTexBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.891D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.studentTexBox.Style.Font.Bold = true;
            this.studentTexBox.Style.Font.Name = "Times New Roman";
            this.studentTexBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.studentTexBox.Value = "KONO Simon Bertrand";
            // 
            // classLabel
            // 
            this.classLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.388D), Telerik.Reporting.Drawing.Unit.Inch(2.174D));
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.classLabel.Style.Font.Name = "Times New Roman";
            this.classLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.classLabel.Value = "Classe : ";
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.109D), Telerik.Reporting.Drawing.Unit.Inch(2.174D));
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.classTextBox.Style.Font.Bold = true;
            this.classTextBox.Style.Font.Name = "Times New Roman";
            this.classTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.classTextBox.Value = "CE1";
            // 
            // studentIdLabel
            // 
            this.studentIdLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.079D), Telerik.Reporting.Drawing.Unit.Inch(1.964D));
            this.studentIdLabel.Name = "studentIdLabel";
            this.studentIdLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.studentIdLabel.Style.Font.Name = "Times New Roman";
            this.studentIdLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.studentIdLabel.Value = "Matricule : ";
            // 
            // studentIdTextBox
            // 
            this.studentIdTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.879D), Telerik.Reporting.Drawing.Unit.Inch(1.964D));
            this.studentIdTextBox.Name = "studentIdTextBox";
            this.studentIdTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.studentIdTextBox.Style.Font.Bold = true;
            this.studentIdTextBox.Style.Font.Name = "Times New Roman";
            this.studentIdTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.studentIdTextBox.Value = "1234566DFS";
            // 
            // studentShape
            // 
            this.studentShape.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1D), Telerik.Reporting.Drawing.Unit.Inch(2.122D));
            this.studentShape.Name = "studentShape";
            this.studentShape.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.studentShape.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.9D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            // 
            // shape4
            // 
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.109D), Telerik.Reporting.Drawing.Unit.Inch(2.331D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.791D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            // 
            // shape5
            // 
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.879D), Telerik.Reporting.Drawing.Unit.Inch(2.122D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.29D), Telerik.Reporting.Drawing.Unit.Inch(0.052D));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.508D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.dateTextBox,
            this.amountTextBox,
            this.reasonTextBox});
            this.detail.Name = "detail";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.35D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.05D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.dateTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dateTextBox.Style.Font.Bold = false;
            this.dateTextBox.Style.Font.Name = "Times New Roman";
            this.dateTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.dateTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.dateTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.dateTextBox.Value = "=Date.ToShortDateString()";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.amountTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.amountTextBox.Style.Font.Bold = false;
            this.amountTextBox.Style.Font.Name = "Times New Roman";
            this.amountTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.amountTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.amountTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.amountTextBox.Value = "=Amount";
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.reasonTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.reasonTextBox.Style.Font.Bold = false;
            this.reasonTextBox.Style.Font.Name = "Times New Roman";
            this.reasonTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.reasonTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.reasonTextBox.Value = "=CostTypeName";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.689D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.addressTextBox,
            this.contactTextBox,
            this.webSiteTextBox,
            this.schoolNameTextBox,
            this.facebookPictureBox,
            this.schoolStatement,
            this.shape1,
            this.shape3,
            this.labelPrintDate,
            this.printDateTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox19
            // 
            this.addressTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15D), Telerik.Reporting.Drawing.Unit.Inch(0.065D));
            this.addressTextBox.Name = "textBox19";
            this.addressTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.872D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.addressTextBox.Style.Font.Name = "Comic Sans MS";
            this.addressTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            // 
            // contactTextBox
            // 
            this.contactTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15D), Telerik.Reporting.Drawing.Unit.Inch(0.245D));
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.086D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.contactTextBox.Style.Font.Name = "Comic Sans MS";
            this.contactTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.contactTextBox.Value = "Tel. (237) 243 23 23 23 / 698 96 80 98 / 677 55 44 41      ";
            // 
            // textBox26
            // 
            this.webSiteTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.35D), Telerik.Reporting.Drawing.Unit.Inch(0.445D));
            this.webSiteTextBox.Name = "textBox26";
            this.webSiteTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.391D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.webSiteTextBox.Style.Color = System.Drawing.Color.DodgerBlue;
            this.webSiteTextBox.Style.Font.Name = "Comic Sans MS";
            this.webSiteTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.webSiteTextBox.Value = " www.softeducation.net ";
            // 
            // textBox27
            // 
            this.schoolNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.95D), Telerik.Reporting.Drawing.Unit.Inch(0.445D));
            this.schoolNameTextBox.Name = "textBox27";
            this.schoolNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.schoolNameTextBox.Style.Font.Name = "Comic Sans MS";
            this.schoolNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.schoolNameTextBox.Value = "Soft Éducation";
            // 
            // pictureBox2
            // 
            this.facebookPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.75D), Telerik.Reporting.Drawing.Unit.Inch(0.41D));
            this.facebookPictureBox.MimeType = "image/png";
            this.facebookPictureBox.Name = "pictureBox2";
            this.facebookPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.2D), Telerik.Reporting.Drawing.Unit.Inch(0.18D));
            this.facebookPictureBox.Style.BackgroundImage.MimeType = "";
            this.facebookPictureBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.facebookPictureBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox28
            // 
            this.schoolStatement.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.35D), Telerik.Reporting.Drawing.Unit.Inch(0.465D));
            this.schoolStatement.Name = "textBox28";
            this.schoolStatement.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.709D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.schoolStatement.Style.Font.Name = "Comic Sans MS";
            this.schoolStatement.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5D);
            this.schoolStatement.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.schoolStatement.Value = "School Otherwise ";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.14D), Telerik.Reporting.Drawing.Unit.Inch(0.048D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.019D), Telerik.Reporting.Drawing.Unit.Inch(0.035D));
            this.shape1.Style.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.shape1.Style.Color = System.Drawing.Color.DeepSkyBlue;
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.14D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.019D), Telerik.Reporting.Drawing.Unit.Inch(0.035D));
            this.shape3.Style.BackgroundColor = System.Drawing.Color.Moccasin;
            this.shape3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.shape3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.shape3.Style.Color = System.Drawing.Color.Moccasin;
            this.shape3.Style.LineColor = System.Drawing.Color.Transparent;
            this.shape3.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(3D);
            // 
            // labelPrintDate
            // 
            this.labelPrintDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3D), Telerik.Reporting.Drawing.Unit.Inch(0.088D));
            this.labelPrintDate.Name = "labelPrintDate";
            this.labelPrintDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.labelPrintDate.Style.Font.Bold = false;
            this.labelPrintDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.labelPrintDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.labelPrintDate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.labelPrintDate.Value = "Date d\'impression :";
            // 
            // printDateTextBox
            // 
            this.printDateTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7D), Telerik.Reporting.Drawing.Unit.Inch(0.088D));
            this.printDateTextBox.Name = "printDateTextBox";
            this.printDateTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.printDateTextBox.Style.Font.Bold = false;
            this.printDateTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.printDateTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.printDateTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.printDateTextBox.Value = " ";
            // 
            // PaymentRecapReportFR
            // 
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping(null));
            group1.Groupings.Add(new Telerik.Reporting.Grouping(null));
            group1.Name = "group";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.detail,
            this.pageFooterSection1});
            this.Name = "TicketReport";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(21.082D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.TextBox reasonTextBox;
        private Telerik.Reporting.TextBox amountTextBox;
        private Telerik.Reporting.TextBox signatureLabel;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.TextBox addressTextBox;
        private Telerik.Reporting.TextBox contactTextBox;
        private Telerik.Reporting.TextBox webSiteTextBox;
        private Telerik.Reporting.TextBox schoolNameTextBox;
        private Telerik.Reporting.PictureBox facebookPictureBox;
        private Telerik.Reporting.TextBox schoolStatement;
        private Telerik.Reporting.TextBox dateTextBox;
        private Telerik.Reporting.TextBox totalTextBox;
        private Telerik.Reporting.TextBox labelTotal;
        private Telerik.Reporting.TextBox totalInLetterTextBox;
        private Telerik.Reporting.PictureBox headerPictureBox;
        private Telerik.Reporting.TextBox schoolYearTextBox;
        private Telerik.Reporting.TextBox reasonLabel;
        private Telerik.Reporting.TextBox amountLabel;
        private Telerik.Reporting.TextBox dateLabel;
        private Telerik.Reporting.TextBox reportTitleTextBox;
        private Telerik.Reporting.TextBox studentLabel;
        private Telerik.Reporting.TextBox studentTexBox;
        private Telerik.Reporting.TextBox classLabel;
        private Telerik.Reporting.TextBox classTextBox;
        private Telerik.Reporting.TextBox studentIdLabel;
        private Telerik.Reporting.TextBox studentIdTextBox;
        private Telerik.Reporting.Shape studentShape;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.TextBox labelPrintDate;
        private Telerik.Reporting.TextBox printDateTextBox;
    }
}