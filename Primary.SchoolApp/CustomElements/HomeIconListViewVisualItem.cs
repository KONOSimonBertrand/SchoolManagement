using System;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Primary.SchoolApp.Utilities;
using System.Drawing;
using Primary.SchoolApp.DTO;
using SchoolManagement.UI.Localization;

namespace Primary.SchoolApp.CustomElements
{
    internal class HomeIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }

        private LightVisualElement studentIdNumber = new LightVisualElement();
        private LightVisualElement className = new LightVisualElement();
        private LightVisualElement studentName = new LightVisualElement();
        private LightVisualElement unPaidAmount = new LightVisualElement();
        private StackLayoutElement verticalContainer = new StackLayoutElement();
        private StackLayoutElement enrollingHeaderContainer = new StackLayoutElement();
        private StackLayoutElement enrollingFooterContainer = new StackLayoutElement();

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            verticalContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            verticalContainer.NotifyParentOnMouseInput = true;
            verticalContainer.ShouldHandleMouseInput = false;
            verticalContainer.StretchHorizontally = true;
            verticalContainer.StretchVertically = true;

            enrollingHeaderContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            enrollingHeaderContainer.NotifyParentOnMouseInput = true;
            enrollingHeaderContainer.ShouldHandleMouseInput = false;
            enrollingHeaderContainer.Children.Add(studentIdNumber);
            enrollingHeaderContainer.Children.Add(className);
            enrollingHeaderContainer.StretchHorizontally = true;

            studentIdNumber.NotifyParentOnMouseInput = true;
            studentIdNumber.ShouldHandleMouseInput = false;
            studentIdNumber.StretchHorizontally = true;
            studentIdNumber.CustomFont = AppUtilities.MainFont;
            studentIdNumber.CustomFontSize = 9;
            studentIdNumber.CustomFontStyle = FontStyle.Bold;
            studentIdNumber.Margin = new System.Windows.Forms.Padding(5, 10, 0, 0);
            studentIdNumber.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

            className.NotifyParentOnMouseInput = true;
            className.ShouldHandleMouseInput = false;
            className.StretchHorizontally = false;
            className.CustomFont = AppUtilities.MainFont;
            className.CustomFontSize = 9;
            className.CustomFontStyle = FontStyle.Regular;
            className.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);

            enrollingFooterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            enrollingFooterContainer.NotifyParentOnMouseInput = true;
            enrollingFooterContainer.ShouldHandleMouseInput = false;
            enrollingFooterContainer.StretchHorizontally = true;
            enrollingFooterContainer.DrawFill = true;
            enrollingFooterContainer.BackColor = Color.White;
            enrollingFooterContainer.GradientStyle = GradientStyles.Solid;
            enrollingFooterContainer.MinSize = new System.Drawing.Size(0, 30);

            studentName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            studentName.StretchHorizontally = false;
            studentName.Layout.LeftPart.Padding = new System.Windows.Forms.Padding(24, 0, 8, 0);

            studentName.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            studentName.NotifyParentOnMouseInput = true;
            studentName.ShouldHandleMouseInput = false;
            studentName.CustomFont = AppUtilities.MainFont;
            studentName.CustomFontSize = 12;
            studentName.CustomFontStyle = FontStyle.Regular;

            unPaidAmount.StretchVertically = true;
            enrollingFooterContainer.Children.Add(unPaidAmount);

            unPaidAmount.NotifyParentOnMouseInput = true;
            unPaidAmount.ShouldHandleMouseInput = false;
            unPaidAmount.StretchHorizontally = false;
            unPaidAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            unPaidAmount.CustomFont = AppUtilities.MainFont;
            unPaidAmount.CustomFontSize = 9;
            unPaidAmount.CustomFontStyle = FontStyle.Regular;
            unPaidAmount.ForeColor = Color.FromArgb(200, 0, 0, 0);
            unPaidAmount.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);

            verticalContainer.Children.Add(enrollingHeaderContainer);
            verticalContainer.Children.Add(studentName);
            verticalContainer.Children.Add(enrollingFooterContainer);

            this.Children.Add(this.verticalContainer);
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            this.DrawText = false;
            this.BackColor = Color.White;
            this.DrawFill = true;
            this.DrawBorder = false;
            studentIdNumber.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            studentName.ImageLayout = System.Windows.Forms.ImageLayout.None;
            studentName.Margin = new System.Windows.Forms.Padding(24, 0, 0, 0);
            studentName.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            studentName.StretchHorizontally = true;
            studentName.ImageAlignment = ContentAlignment.MiddleLeft;
            studentName.TextAlignment = ContentAlignment.MiddleLeft;



            StudentEnrollingDTO enrolling = this.Data.DataBoundItem as StudentEnrollingDTO;
            if (enrolling != null)
            {
                studentIdNumber.Text = enrolling.Student.IdNumber;
                studentName.Image = enrolling.HealthImage;
                if (enrolling.Student.FullName.Length >= 12)
                {
                    studentName.Text = enrolling.Student.FullName.Substring(0, 12) + "...";
                }
                else
                {
                    studentName.Text = enrolling.Student.FullName;
                }

                if (enrolling.SchoolClass.Name.Length >= 12)
                {
                    className.Text = enrolling.SchoolClass.Name.Substring(0, 12) + "...";
                }
                else
                {
                    className.Text = enrolling.SchoolClass.Name;
                }
                unPaidAmount.Text =$"{Language.labelUnPaid}: {enrolling.Balance}";
                this.BackColor = AppUtilities.MainThemeColor;
                studentIdNumber.ForeColor = Color.White;
                className.ForeColor = Color.White;
                studentName.ForeColor = Color.White;
            }
        }
    }
}
