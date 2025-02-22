
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System;
using System.Drawing;
using SchoolManagement.Core.Model;
using Primary.SchoolApp.Utilities;
using Telerik.WinControls.Layouts;
using System.Windows.Forms;
using Primary.SchoolApp.DTO;
using SchoolManagement.UI.Localization;
using System.IO;
using Telerik.WinControls.Primitives;

namespace Primary.SchoolApp.CustomElements
{
    internal class EmployeeIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }
        readonly Color themeColor;
        public EmployeeIconListViewVisualItem()
        {

        }
        public EmployeeIconListViewVisualItem(Color themeColor)
        {
            this.themeColor = themeColor;
        }
        private LightVisualElement imageElement;
        private LightVisualElement idNumberElement;
        private LightVisualElement nameElement ; //nom de l'em
        private LightVisualElement jobElement;
        private LightVisualElement dateElement;
        private StackLayoutElement footerLayout;
        private StackLayoutPanel mainLayout;


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

            nameElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 12,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(nameElement);

            idNumberElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            mainLayout.Children.Add(idNumberElement);

            dateElement = new LightVisualElement
            {
                TextAlignment = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 5, 10, 5),
                CustomFont = CustomFont = AppUtilities.MainFont,
                CustomFontSize = 9,
                CustomFontStyle = FontStyle.Regular,
                NotifyParentOnMouseInput = true,
                ShouldHandleMouseInput = false,
            };
            footerLayout.Children.Add(dateElement);

            jobElement = new LightVisualElement
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

            mainLayout.Children.Add(jobElement);
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
            base.SynchronizeProperties();
            this.DrawText = false;
            this.BackColor = Color.White;
            this.DrawFill = true;
            this.DrawBorder = false;
            if (this.Data.DataBoundItem is EmployeeEnrolling enrolling)
            {
                imageElement.Image = GetEmployeeImage(enrolling);
                idNumberElement.Text = $"{Language.labelStudentId}: {enrolling.Employee.IdNumber}";
                nameElement.ImageLayout = System.Windows.Forms.ImageLayout.None;
                dateElement.Text=enrolling.Date.ToShortDateString();
                if (enrolling.Employee.FullName.Length >= 12)
                {
                    nameElement.Text = enrolling.Employee.FullName.Substring(0, 12) + "...";
                }
                else
                {
                    nameElement.Text = enrolling.Employee.FullName;
                }

                if (enrolling.Job.Name.Length >= 14)
                {
                    jobElement.Text = $"{Language.labelJob}: {enrolling.Job.Name.Substring(0, 14)}...";
                }
                else
                {
                    jobElement.Text = $"{Language.labelJob}: {enrolling.Job.Name}";

                }
                this.BackColor = AppUtilities.MainThemeColor;
                idNumberElement.ForeColor = Color.White;
                jobElement.ForeColor = Color.White;
                nameElement.ForeColor = Color.White;
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
        private Bitmap GetEmployeeImage(EmployeeEnrolling enrolling)
        {

            Bitmap image = null;
            if (File.Exists(enrolling.PictureUrl))
            {

                image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new Size(114, 114));
            }
            else
            {
                //on cherche une photo par defaut
                if (File.Exists(enrolling.Employee.PictureUrl))
                {
                    image = new Bitmap(Image.FromFile(enrolling.Employee.PictureUrl), new Size(114, 114));
                }
                else
                {
                    var url = Program.CurrentSchool.EmployeePictureDirectory + "/" + enrolling.Employee.IdNumber;
                    if (File.Exists(url))
                    {
                        image = new Bitmap(Image.FromFile(url), new Size(114, 114));
                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.no_image);
                        image = new Bitmap(Image.FromStream(ms));
                    }
                }

            }
            return image;
        }
    }
}
