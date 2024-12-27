using System;
using System.Drawing;
using Telerik.WinControls.Layouts;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.IO;
using SchoolManagement.UI.Localization;
using Primary.SchoolApp.Utilities;

namespace Primary.SchoolApp.CustomElements
{
    public class StudentEnrollingIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }
        private LightVisualElement imageElement;
        private LightVisualElement studentNameElement;
        private LightVisualElement studentIdNumberElement;
        private LightVisualElement roomElement;
        private LightVisualElement balanceElement;
        private LightVisualElement healthElement;
        private StackLayoutElement footerLayout ;
        private StackLayoutPanel mainLayout;

        private readonly ClientApp clientApp;
        public StudentEnrollingIconListViewVisualItem() { }
        public StudentEnrollingIconListViewVisualItem(ClientApp clientApp) {
            this.clientApp = clientApp;
        }
        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            mainLayout = new StackLayoutPanel
            {
                Orientation = System.Windows.Forms.Orientation.Vertical,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
                StretchHorizontally = true,
                StretchVertically = true
            };

            footerLayout = new StackLayoutElement
            {
                Orientation = System.Windows.Forms.Orientation.Horizontal,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
                StretchHorizontally = true,
                DrawFill = true,
                BackColor = Color.White,
                GradientStyle = GradientStyles.Solid,
                //MinSize = new System.Drawing.Size(0, 30)
            };

            imageElement = new LightVisualElement
            {
                DrawText = false,
                ImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                StretchVertically = false,
                Margin = new System.Windows.Forms.Padding(10, 5, 10, 5),
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(imageElement);

            studentNameElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 12,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(studentNameElement);

            studentIdNumberElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(studentIdNumberElement);

            roomElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                ForeColor = Color.FromArgb(255, 114, 118, 125),
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(roomElement);

            balanceElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont= CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
                TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText,
            };

            healthElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                Alignment= ContentAlignment.MiddleRight,
                TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
                Text=Language.labelHealth
            };
            footerLayout.Children.Add(balanceElement);
            footerLayout.Children.Add(healthElement);
            mainLayout.Children.Add(footerLayout);
            

            this.Children.Add(mainLayout);

            this.Padding = new Padding(5);
            this.Shape = new RoundRectShape(3);
            this.BorderColor = Color.FromArgb(255, 110, 153, 210);
            this.BorderGradientStyle = GradientStyles.Solid;
            this.DrawBorder = true;
            this.DrawFill = true;
            this.BackColor = Color.FromArgb(255, 230, 238, 254);
            this.GradientStyle = GradientStyles.Solid;
        }

        protected override void SynchronizeProperties()
        {
            StudentEnrollingDTO enrolling = this.Data.DataBoundItem as StudentEnrollingDTO;
            
            if (enrolling != null)
            {
                healthElement.Image=enrolling.HealthImage;
                balanceElement.Image =enrolling.Balance>0? Resources.balance_red : Resources.balance_green;
                this.imageElement.Image = GetStudentImage(enrolling);
                this.studentIdNumberElement.Text = $"{Language.labelStudentId}: {enrolling.Student.IdNumber}";
                this.studentNameElement.ImageLayout = System.Windows.Forms.ImageLayout.None;
                if (enrolling.Student.FullName.Length >= 12)
                {
                    this.studentNameElement.Text = enrolling.Student.FullName.Substring(0, 12) + "...";
                }
                else
                {
                    this.studentNameElement.Text = enrolling.Student.FullName;
                }

                if (enrolling.SchoolClass.Name.Length >= 12)
                {
                    roomElement.Text = $"{Language.labelClass}: {enrolling.SchoolClass.Name.Substring(0, 12)}...";
                }
                else
                {
                    roomElement.Text = $"{Language.labelClass}: {enrolling.SchoolClass.Name}";
                }
               balanceElement.Text = $"{enrolling.Balance}";
                this.BackColor = AppUtilities.MainThemeColor;
                studentIdNumberElement.ForeColor = Color.White;
                roomElement.ForeColor = Color.White;
                studentNameElement.ForeColor = Color.White;
                healthElement.ForeColor = Color.FromArgb(200, 0, 0, 0);
                healthElement.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);
                balanceElement.ForeColor = Color.FromArgb(200, 0, 0, 0);
            }
            
            
        }

        protected override SizeF MeasureOverride(SizeF availableSize)
        {
            SizeF measuredSize = base.MeasureOverride(availableSize);

            this.mainLayout.Measure(measuredSize);

            return measuredSize;
        }

        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            base.ArrangeOverride(finalSize);

            this.mainLayout.Arrange(new RectangleF(PointF.Empty, finalSize));

            return finalSize;
        }
      private Bitmap GetStudentImage(StudentEnrollingDTO enrolling)
        {
            
            Bitmap image = null;
            if (File.Exists(enrolling.PictureUrl))
            {

                image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Student.PictureUrl))
                {
                   image = new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(114, 114));
                }
                else
                {
                    var url = clientApp.StudentPitureFolder + "/" + enrolling.Student.IdNumber;
                    if (File.Exists(url))
                    {
                        image = new Bitmap(Image.FromFile(url), new Size(114, 114));
                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.no_image);
                        image =new Bitmap( Image.FromStream(ms));
                    }
                }

            }
            return image;
        }
    }
}
