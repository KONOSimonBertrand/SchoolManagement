

using Primary.SchoolApp.Utilities;
using System;
using System.Drawing;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.CustomElements
{
    internal class EmployeeSimpleListViewVisualItem : SimpleListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
        }
        public EmployeeSimpleListViewVisualItem()
        {

        }

        private StackLayoutElement layout = new StackLayoutElement();
        private LightVisualElement countElement = new LightVisualElement();
        private LightVisualElement countImage = new LightVisualElement();
        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.layout.ShouldHandleMouseInput = false;
            this.countImage.ShouldHandleMouseInput = false;
            this.countElement.NotifyParentOnMouseInput = true;
            this.countElement.ShouldHandleMouseInput = false;
            this.countElement.StretchHorizontally = false;
            this.countElement.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.countElement.MinSize = countElement.MaxSize = new System.Drawing.Size(30, 0);
            this.countImage.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.countImage.ImageAlignment = ContentAlignment.MiddleRight;
            this.countImage.StretchHorizontally = true;

            this.layout.Children.Add(countImage);
            this.layout.Children.Add(countElement);
            this.layout.StretchHorizontally = true;
            this.Children.Add(layout);
        }
        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            this.DrawText = false;
            this.ToggleElement.Text = this.Text;

            this.ToggleElement.CustomFont = AppUtilities.MainFont;
            this.ToggleElement.CustomFontSize = 10.5f;
            this.ToggleElement.TextElement.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);

            this.countElement.CustomFont = AppUtilities.MainFont;
            this.countElement.CustomFontSize = 10.5f;
            this.countElement.CustomFontStyle = FontStyle.Regular;

            this.countImage.Image = null;
            this.countElement.Text = GetEmployeeByGroup((int)this.dataItem.Key);
          
        }

        private string GetEmployeeByGroup(int key)
        {
            return Program.EmployeeEnrollingList.Where(x => x.GroupId == key).Count().ToString();
        }
    }
    }
