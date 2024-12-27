namespace SchoolManagement.UI.Reporting
{
    partial class BadgeReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BadgeReport));
            Telerik.Reporting.Barcodes.QRCodeEncoder qrCodeEncoder1 = new Telerik.Reporting.Barcodes.QRCodeEncoder();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.badgePictureBox = new Telerik.Reporting.PictureBox();
            this.studentPictureBox = new Telerik.Reporting.PictureBox();
            this.logoPictureBox = new Telerik.Reporting.PictureBox();
            this.studentLastNameTextBox = new Telerik.Reporting.TextBox();
            this.studentFirstNameTextBox = new Telerik.Reporting.TextBox();
            this.studentBirthDayFRLabel = new Telerik.Reporting.TextBox();
            this.studentBirthDayTexBox = new Telerik.Reporting.TextBox();
            this.studentMatriculeLabel = new Telerik.Reporting.TextBox();
            this.studentMatriculeTextBox = new Telerik.Reporting.TextBox();
            this.studentClassFRLabel = new Telerik.Reporting.TextBox();
            this.studentClassTextBox = new Telerik.Reporting.TextBox();
            this.schoolNameTextBox = new Telerik.Reporting.TextBox();
            this.idCardBarcode = new Telerik.Reporting.Barcode();
            this.expirationDateTextBox = new Telerik.Reporting.TextBox();
            this.studentBirthDayENLabel = new Telerik.Reporting.TextBox();
            this.studentClassENLabel = new Telerik.Reporting.TextBox();
            this.studentPhoneLabel = new Telerik.Reporting.TextBox();
            this.studentPhoneTextBox = new Telerik.Reporting.TextBox();
            this.signaturePictureBox = new Telerik.Reporting.PictureBox();
            this.schoolContactTextBox = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(5.901D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.badgePictureBox,
            this.studentPictureBox,
            this.logoPictureBox,
            this.studentLastNameTextBox,
            this.studentFirstNameTextBox,
            this.studentBirthDayFRLabel,
            this.studentBirthDayTexBox,
            this.studentMatriculeLabel,
            this.studentMatriculeTextBox,
            this.studentClassFRLabel,
            this.studentClassTextBox,
            this.schoolNameTextBox,
            this.idCardBarcode,
            this.expirationDateTextBox,
            this.studentBirthDayENLabel,
            this.studentClassENLabel,
            this.studentPhoneLabel,
            this.studentPhoneTextBox,
            this.signaturePictureBox,
            this.schoolContactTextBox});
            this.detail.Name = "detail";
            // 
            // badgePictureBox
            // 
            this.badgePictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.5D), Telerik.Reporting.Drawing.Unit.Cm(0.001D));
            this.badgePictureBox.MimeType = "image/png";
            this.badgePictureBox.Name = "badgePictureBox";
            this.badgePictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.7D), Telerik.Reporting.Drawing.Unit.Cm(5.5D));
            this.badgePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            // 
            // studentPictureBox
            // 
            this.studentPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.545D), Telerik.Reporting.Drawing.Unit.Cm(1.401D));
            this.studentPictureBox.MimeType = "image/png";
            this.studentPictureBox.Name = "studentPictureBox";
            this.studentPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4D), Telerik.Reporting.Drawing.Unit.Cm(3.2D));
            this.studentPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.7D), Telerik.Reporting.Drawing.Unit.Cm(0.05D));
            this.logoPictureBox.MimeType = "image/png";
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.45D), Telerik.Reporting.Drawing.Unit.Cm(1.29D));
            this.logoPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            // 
            // studentLastNameTextBox
            // 
            this.studentLastNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.8D), Telerik.Reporting.Drawing.Unit.Cm(0.301D));
            this.studentLastNameTextBox.Name = "studentLastNameTextBox";
            this.studentLastNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.studentLastNameTextBox.Style.Color = System.Drawing.Color.White;
            this.studentLastNameTextBox.Style.Font.Bold = true;
            this.studentLastNameTextBox.Style.Font.Name = "Calibri";
            this.studentLastNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.studentLastNameTextBox.TextWrap = false;
            this.studentLastNameTextBox.Value = "=Student.LastName";
            // 
            // studentFirstNameTextBox
            // 
            this.studentFirstNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.8D), Telerik.Reporting.Drawing.Unit.Cm(0.701D));
            this.studentFirstNameTextBox.Name = "studentFirstNameTextBox";
            this.studentFirstNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.studentFirstNameTextBox.Style.Color = System.Drawing.Color.White;
            this.studentFirstNameTextBox.Style.Font.Name = "Calibri";
            this.studentFirstNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentFirstNameTextBox.TextWrap = false;
            this.studentFirstNameTextBox.Value = "=Student.FirstName";
            // 
            // studentBirthDayFRLabel
            // 
            this.studentBirthDayFRLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(1.402D));
            this.studentBirthDayFRLabel.Name = "studentBirthDayFRLabel";
            this.studentBirthDayFRLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.1D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentBirthDayFRLabel.Style.Font.Name = "Calibri";
            this.studentBirthDayFRLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentBirthDayFRLabel.Value = "Née le";
            // 
            // studentBirthDayTexBox
            // 
            this.studentBirthDayTexBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.5D), Telerik.Reporting.Drawing.Unit.Cm(1.402D));
            this.studentBirthDayTexBox.Name = "studentBirthDayTexBox";
            this.studentBirthDayTexBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentBirthDayTexBox.Style.Font.Name = "Calibri";
            this.studentBirthDayTexBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentBirthDayTexBox.Value = "=Student.BirthDate.ToString(\"dd-MM-yyyy\")";
            // 
            // studentMatriculeLabel
            // 
            this.studentMatriculeLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(2.102D));
            this.studentMatriculeLabel.Name = "studentMatriculeLabel";
            this.studentMatriculeLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.34D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentMatriculeLabel.Style.Font.Name = "Calibri";
            this.studentMatriculeLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentMatriculeLabel.Value = "Matricule:";
            // 
            // studentMatriculeTexBox
            // 
            this.studentMatriculeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.5D), Telerik.Reporting.Drawing.Unit.Cm(2.102D));
            this.studentMatriculeTextBox.Name = "studentMatriculeTexBox";
            this.studentMatriculeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentMatriculeTextBox.Style.Font.Name = "Calibri";
            this.studentMatriculeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentMatriculeTextBox.Value = "=Student.ReferenceNumber";
            // 
            // studentClassFRLabel
            // 
            this.studentClassFRLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(2.502D));
            this.studentClassFRLabel.Name = "studentClassFRLabel";
            this.studentClassFRLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.34D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentClassFRLabel.Style.Font.Name = "Calibri";
            this.studentClassFRLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentClassFRLabel.Value = "Classe:";
            // 
            // studentClassTextBox
            // 
            this.studentClassTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.5D), Telerik.Reporting.Drawing.Unit.Cm(2.502D));
            this.studentClassTextBox.Name = "studentClassTextBox";
            this.studentClassTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6D), Telerik.Reporting.Drawing.Unit.Cm(0.599D));
            this.studentClassTextBox.Style.Font.Name = "Calibri";
            this.studentClassTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentClassTextBox.TextWrap = true;
            this.studentClassTextBox.Value = "=SchoolClass.Name";
            // 
            // schoolNameLabel
            // 
            this.schoolNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.6D), Telerik.Reporting.Drawing.Unit.Cm(4.701D));
            this.schoolNameTextBox.Name = "schoolNameLabel";
            this.schoolNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.5D), Telerik.Reporting.Drawing.Unit.Cm(0.299D));
            this.schoolNameTextBox.Style.Color = System.Drawing.Color.White;
            this.schoolNameTextBox.Style.Font.Bold = true;
            this.schoolNameTextBox.Style.Font.Name = "Calibri";
            this.schoolNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.schoolNameTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.schoolNameTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.schoolNameTextBox.TextWrap = false;
            this.schoolNameTextBox.Value = "SCHOOL NAME";
            // 
            // idCardBarcode
            // 
            this.idCardBarcode.Encoder = qrCodeEncoder1;
            this.idCardBarcode.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.5D), Telerik.Reporting.Drawing.Unit.Cm(3.101D));
            this.idCardBarcode.Name = "idCardBarcode";
            this.idCardBarcode.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4D), Telerik.Reporting.Drawing.Unit.Cm(1.4D));
            this.idCardBarcode.Stretch = true;
            this.idCardBarcode.Style.Font.Name = "Calibri";
            this.idCardBarcode.Value = "=Fields.StudentName+\" \r\nMatricule:\"+Fields.Student.ReferenceNumber+\"\r\nClasse:\"+Fi" +
    "elds.SchoolClass.Name";
            // 
            // expirationDateTextBox
            // 
            this.expirationDateTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.7D), Telerik.Reporting.Drawing.Unit.Cm(1.402D));
            this.expirationDateTextBox.Name = "expirationDateTextBox";
            this.expirationDateTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.expirationDateTextBox.Style.Font.Bold = true;
            this.expirationDateTextBox.Style.Font.Name = "Calibri";
            this.expirationDateTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.expirationDateTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.expirationDateTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.expirationDateTextBox.Value = " 2024-2225";
            // 
            // studentBirthDayENLabel
            // 
            this.studentBirthDayENLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(1.702D));
            this.studentBirthDayENLabel.Name = "studentBirthDayENLabel";
            this.studentBirthDayENLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.3D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentBirthDayENLabel.Style.Font.Italic = true;
            this.studentBirthDayENLabel.Style.Font.Name = "Calibri";
            this.studentBirthDayENLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentBirthDayENLabel.Value = "Born on";
            // 
            // studentClassENLabel
            // 
            this.studentClassENLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(2.802D));
            this.studentClassENLabel.Name = "studentClassENLabel";
            this.studentClassENLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.34D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentClassENLabel.Style.Font.Italic = true;
            this.studentClassENLabel.Style.Font.Name = "Calibri";
            this.studentClassENLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentClassENLabel.Value = "Class:";
            // 
            // studentAdressLabel
            // 
            this.studentPhoneLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.1D), Telerik.Reporting.Drawing.Unit.Cm(3.202D));
            this.studentPhoneLabel.Name = "studentAdressLabel";
            this.studentPhoneLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.34D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentPhoneLabel.Style.Font.Name = "Calibri";
            this.studentPhoneLabel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentPhoneLabel.Value = "Contact:";
            // 
            // studentAdressTextBox
            // 
            this.studentPhoneTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.5D), Telerik.Reporting.Drawing.Unit.Cm(3.201D));
            this.studentPhoneTextBox.Name = "studentAdressTextBox";
            this.studentPhoneTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7D), Telerik.Reporting.Drawing.Unit.Cm(0.35D));
            this.studentPhoneTextBox.Style.Font.Name = "Calibri";
            this.studentPhoneTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.studentPhoneTextBox.Value = "=Student.Phone";
            // 
            // signaturePictureBox
            // 
            this.signaturePictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.1D), Telerik.Reporting.Drawing.Unit.Cm(3.101D));
            this.signaturePictureBox.MimeType = "image/png";
            this.signaturePictureBox.Name = "signaturePictureBox";
            this.signaturePictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4D), Telerik.Reporting.Drawing.Unit.Cm(1.4D));
            this.signaturePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            // 
            // contactTextBox
            // 
            this.schoolContactTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.5D), Telerik.Reporting.Drawing.Unit.Cm(5.001D));
            this.schoolContactTextBox.Name = "contactTextBox";
            this.schoolContactTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.6D), Telerik.Reporting.Drawing.Unit.Cm(0.299D));
            this.schoolContactTextBox.Style.Color = System.Drawing.Color.White;
            this.schoolContactTextBox.Style.Font.Bold = true;
            this.schoolContactTextBox.Style.Font.Name = "Calibri";
            this.schoolContactTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.5D);
            this.schoolContactTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.schoolContactTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.schoolContactTextBox.TextWrap = false;
            this.schoolContactTextBox.Value = "Tel. (237) 243 23 23 23 / 698 96 80 98 / 677 55 44 41, e-mail: \tinfo@softeducatio" +
    "n.net";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.236D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // BadgeReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1,
            this.pageHeaderSection1});
            this.Name = "BadgeReport";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.SkipBlankPages = true;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(21.057D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.PictureBox badgePictureBox;
        private Telerik.Reporting.PictureBox studentPictureBox;
        private Telerik.Reporting.PictureBox logoPictureBox;
        private Telerik.Reporting.TextBox studentLastNameTextBox;
        private Telerik.Reporting.TextBox studentFirstNameTextBox;
        private Telerik.Reporting.TextBox studentBirthDayFRLabel;
        private Telerik.Reporting.TextBox studentBirthDayTexBox;
        private Telerik.Reporting.TextBox studentMatriculeLabel;
        private Telerik.Reporting.TextBox studentMatriculeTextBox;
        private Telerik.Reporting.TextBox studentClassFRLabel;
        private Telerik.Reporting.TextBox studentClassTextBox;
        private Telerik.Reporting.TextBox schoolNameTextBox;
        private Telerik.Reporting.Barcode idCardBarcode;
        private Telerik.Reporting.TextBox expirationDateTextBox;
        private Telerik.Reporting.TextBox studentBirthDayENLabel;
        private Telerik.Reporting.TextBox studentClassENLabel;
        private Telerik.Reporting.TextBox studentPhoneLabel;
        private Telerik.Reporting.TextBox studentPhoneTextBox;
        private Telerik.Reporting.PictureBox signaturePictureBox;
        private Telerik.Reporting.TextBox schoolContactTextBox;
    }
}