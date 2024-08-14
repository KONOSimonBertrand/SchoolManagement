using SchoolManagement.UI.Localization;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public partial class UploadPictureForm : RadForm
    {
        public RadButton SaveButton { get => saveButton; }
        public RadButton CloseButton { get => closeButton; }
        RadButton TakePhotoButton {  get => takePhotoButton; }
        RadButton DeletePhotoButton {  get => deletePhotoButton; }
        public RadWebCam PhotoWebCam {  get => photoWebCam; }
        public RadButton ImportPictureButton {  get => importPictureButton; }
        public RadLabel SchoolInformationLabel { get => schoolInformationLabel; }
        public RadLabel PersonalInformationLabel { get => personalInformationLabel; }
        public RadPanel PhotoPanel { get => photoPanel; }
        public RadLabel NameLabel { get => nameLabel; }
        public RadLabel ErrorLabel { get => errorLabel; }
        public string UrlPicture { get; set; }
        public  Image DefaultImage { get; set; }
        public UploadPictureForm()
        {
            InitializeComponent();
            InitComponent();
            InitEvent();
        }
        private void InitComponent()
        {
           
            foreach (RadControl c in this.informationsPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }
            informationsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            DefaultImage = Resources.no_image;
            this.importPictureButton.RootElement.ToolTipText = "Cliquer ici pour importer une image";
            this.takePhotoButton.RootElement.ToolTipText = "Cliquer ici pour prendre une photo via la webcam";
            this.SetPanelImage(this.DefaultImage);
            RadButtonElement stopCameraButton = new RadButtonElement();
            stopCameraButton.SetDefaultValueOverride(RadButtonElement.PaddingProperty, new Padding(3));
            stopCameraButton.TextElement.CustomFont = "Font Awesome 5 Free Solid";
            stopCameraButton.TextElement.CustomFontSize = 12;
            stopCameraButton.Text = "\uf00d";
            this.photoWebCam.WebCamElement.LeftElementsStack.Children.Add(stopCameraButton);

            this.photoWebCam.WebCamElement.ToggleRecordingButton.Visibility = ElementVisibility.Collapsed;
            this.photoWebCam.Hide();

            this.takePhotoButton.Text = "\ue500";
            this.deletePhotoButton.Text = "\ue10C";
            this.takePhotoButton.RootElement.BackColor = Color.Transparent;
            this.deletePhotoButton.RootElement.BackColor = Color.Transparent;
          
            stopCameraButton.Click += this.StopCameraButtonClick;
            errorLabel.ForeColor = Color.Red;
        }
        private void PictureButton_Click(object sender, EventArgs e)
        {
            this.errorLabel.Text = "";
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files | *.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UrlPicture = openFileDialog.FileName;
                    Bitmap bitmap = new Bitmap(Image.FromFile(openFileDialog.FileName), new Size(114, 114));
                    this.SetPanelImage(bitmap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void SavePictureInFoleder(Image image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image files | *.jpg;*.jpeg;*.png";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                UrlPicture= saveFileDialog.FileName;
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
               var imageToSave= GetResizeImage(image);
                imageToSave.Save(fs,System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        
        private void InitEvent()
        {
            this.importPictureButton.Click += PictureButton_Click;
            closeButton.Click += CloseButton_Click;
            this.takePhotoButton.Click += new System.EventHandler(this.TakePhotoButton_Click);
            this.photoWebCam.SnapshotTaken += PhotoWebCam_SnapshotTaken;
            this.deletePhotoButton.Click += DeletePhotoButton_Click;
        }

        private void PhotoWebCam_SnapshotTaken(object sender, SnapshotTakenEventArgs e)
        {
            this.StopCamera();
            SavePictureInFoleder(e.Snapshot);
            this.SetPanelImage(e.Snapshot);
            this.deletePhotoButton.Enabled = true;
        }

        private void TakePhotoButton_Click(object sender, EventArgs e)
        {
            this.StartCamera();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StopCameraButtonClick(object sender, EventArgs e)
        {
            this.StopCamera();
        }
        private void DeletePhotoButton_Click(object sender, EventArgs e)
        {
            this.SetPanelImage(this.DefaultImage);
            this.deletePhotoButton.Enabled = false;
        }
        private void StartCamera()
        {
            this.takePhotoButton.Visible = false;
            this.deletePhotoButton.Visible = false;
            this.photoWebCam.Visible = true;
            this.photoWebCam.Start();
        }
        private void StopCamera()
        {
            this.photoWebCam.Stop();
            if (this.photoWebCam.IsPreviewingSnapshot)
            {
                this.photoWebCam.DiscardSnapshot();
            }

            this.photoWebCam.Hide();
            this.takePhotoButton.Visible = true;
            this.deletePhotoButton.Visible = true;
        }
        public  void SetPanelImage(Image image)
        {          
            this.photoPanel.BackgroundImage = GetResizeImage(image);
        }
        private Image GetResizeImage(Image image)
        {
            float widthCoefficient = this.photoWebCam.Width / (float)image.Width;
            float heightCoefficient = this.photoWebCam.Height / (float)image.Height;
            float scaleCoeff = Math.Min(widthCoefficient, heightCoefficient);
            Size scaledSize = new Size((int)(image.Width * scaleCoeff), (int)(image.Height * scaleCoeff));
            return new Bitmap(image, scaledSize);
        }
        public bool IsValidData()
        {
            this.errorLabel.Text = "";
            if(UrlPicture == string.Empty)
            {
                this.errorLabel.Text = Language.messageTakeSelectPicture;
                return false;
            }
            return true;
        }
        }
}
