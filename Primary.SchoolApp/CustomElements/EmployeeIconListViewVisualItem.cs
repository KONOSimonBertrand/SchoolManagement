
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System;
using System.Drawing;
using SchoolManagement.Core.Model;
using Primary.SchoolApp.Utilities;

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
        Color themeColor;
        public EmployeeIconListViewVisualItem()
        {

        }
        public EmployeeIconListViewVisualItem(Color themeColor)
        {
            this.themeColor = themeColor;
        }
        private LightVisualElement employeeIdNumber = new();
        private LightVisualElement employeeName = new();
        private LightVisualElement employeeJob = new();
        private StackLayoutElement verticalContainer = new();
        private StackLayoutElement employeeHeaderContainer = new();
        private StackLayoutElement employeeFooterContainer = new();

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            verticalContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            verticalContainer.NotifyParentOnMouseInput = true;
            verticalContainer.ShouldHandleMouseInput = false;
            verticalContainer.StretchHorizontally = true;
            verticalContainer.StretchVertically = true;

            employeeHeaderContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            employeeHeaderContainer.NotifyParentOnMouseInput = true;
            employeeHeaderContainer.ShouldHandleMouseInput = false;
            employeeHeaderContainer.Children.Add(employeeIdNumber);
            employeeHeaderContainer.StretchHorizontally = true;

            employeeIdNumber.NotifyParentOnMouseInput = true;
            employeeIdNumber.ShouldHandleMouseInput = false;
            employeeIdNumber.StretchHorizontally = true;
            employeeIdNumber.CustomFont = AppUtilities.MainFont;
            employeeIdNumber.CustomFontSize = 9;
            employeeIdNumber.CustomFontStyle = FontStyle.Bold;
            employeeIdNumber.Margin = new System.Windows.Forms.Padding(5, 10, 0, 0);
            employeeIdNumber.TextAlignment = ContentAlignment.MiddleLeft;

            employeeFooterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            employeeFooterContainer.NotifyParentOnMouseInput = true;
            employeeFooterContainer.ShouldHandleMouseInput = false;
            employeeFooterContainer.StretchHorizontally = true;
            employeeFooterContainer.DrawFill = true;
            employeeFooterContainer.BackColor = Color.White;
            employeeFooterContainer.GradientStyle = GradientStyles.Solid;
            employeeFooterContainer.MinSize = new Size(0, 30);

            employeeName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            employeeName.StretchHorizontally = false;
            employeeName.Layout.LeftPart.Padding = new System.Windows.Forms.Padding(24, 0, 8, 0);

            employeeName.Alignment = ContentAlignment.MiddleCenter;
            employeeName.NotifyParentOnMouseInput = true;
            employeeName.ShouldHandleMouseInput = false;
            employeeName.CustomFont = AppUtilities.MainFont;
            employeeName.CustomFontSize = 12;
            employeeName.CustomFontStyle = FontStyle.Regular;

            employeeJob.StretchVertically = true;
            employeeFooterContainer.Children.Add(employeeJob);

            employeeJob.NotifyParentOnMouseInput = true;
            employeeJob.ShouldHandleMouseInput = false;
            employeeJob.StretchHorizontally = false;
            employeeJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            employeeJob.CustomFont = AppUtilities.MainFont;
            employeeJob.CustomFontSize = 9;
            employeeJob.CustomFontStyle = FontStyle.Regular;
            employeeJob.ForeColor = Color.FromArgb(200, 0, 0, 0);
            employeeJob.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);

            verticalContainer.Children.Add(employeeHeaderContainer);
            verticalContainer.Children.Add(employeeName);
            verticalContainer.Children.Add(employeeFooterContainer);

            Children.Add(verticalContainer);
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            DrawText = false;
            BackColor = Color.White;
            DrawFill = true;
            DrawBorder = false;
            employeeIdNumber.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            employeeName.ImageLayout = System.Windows.Forms.ImageLayout.None;
            employeeName.Margin = new System.Windows.Forms.Padding(24, 0, 0, 0);
            employeeName.Image = Resources.heartbeat_green;
            employeeName.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            employeeName.StretchHorizontally = true;
            employeeName.ImageAlignment = ContentAlignment.MiddleLeft;
            employeeName.TextAlignment = ContentAlignment.MiddleLeft;



            EmployeeEnrolling enrolling = Data.DataBoundItem as EmployeeEnrolling;
            if (enrolling != null)
            {
                employeeIdNumber.Text = enrolling.Employee.IdNumber;
                employeeName.Image = null;
                if (enrolling.Employee.FullName.Length >= 12)
                {
                    employeeName.Text = enrolling.Employee.FullName.Substring(0, 12) + "...";
                }
                else
                {
                    employeeName.Text = enrolling.Employee.FullName;
                }
                if (enrolling.Job.Name.Length >= 20)
                {
                    employeeJob.Text = enrolling.Job.Name.Substring(0, 20) + "...";
                }
                else
                {
                    employeeJob.Text = enrolling.Job.Name;

                }

                BackColor = AppUtilities.MainThemeColor;
                employeeIdNumber.ForeColor = Color.White;
                employeeName.ForeColor = Color.White;

            }
        }
    }
}
