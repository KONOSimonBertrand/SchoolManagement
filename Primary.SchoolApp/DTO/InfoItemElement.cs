
using System.Text.RegularExpressions;
using System;
using Telerik.WinControls.UI;
using System.Drawing;

namespace Primary.SchoolApp.DTO
{
    internal class InfoItemElement : RadListVisualItem
    {

        #region Fields

        LightVisualElement imageElement;
        LightVisualElement headerElement;
        LightVisualElement descriptionElement;
        StackLayoutElement stackElement;
     

        #endregion

        #region Overrides

        protected override void InitializeFields()
        {
            base.InitializeFields();
            this.ClipDrawing = true;
        }

        protected override void CreateChildElements()
        {
            imageElement = new LightVisualElement();
            imageElement.StretchHorizontally = false;
            imageElement.StretchVertically = true;
            imageElement.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            imageElement.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            imageElement.NotifyParentOnMouseInput = true;
            this.Children.Add(imageElement);

            stackElement = new StackLayoutElement();
            stackElement.StretchVertically = true;
            stackElement.FitInAvailableSize = true;
            stackElement.Orientation = System.Windows.Forms.Orientation.Vertical;
            stackElement.StretchVertically = true;
            stackElement.NotifyParentOnMouseInput = true;
            this.Children.Add(stackElement);

            headerElement = new LightVisualElement();
            headerElement.StretchVertically = false;
            headerElement.TextAlignment = ContentAlignment.MiddleLeft;
            headerElement.Font = new System.Drawing.Font("Segoe UI", 9.25f, FontStyle.Bold);
            headerElement.TextWrap = true;
            headerElement.NotifyParentOnMouseInput = true;
            stackElement.Children.Add(headerElement);

            descriptionElement = new LightVisualElement();
            descriptionElement.StretchVertically = false;
            descriptionElement.Font = new System.Drawing.Font("Segoe UI", 9.25f);
            descriptionElement.TextAlignment = ContentAlignment.MiddleLeft;
            descriptionElement.TextWrap = true;
            descriptionElement.NotifyParentOnMouseInput = true;
            descriptionElement.AutoEllipsis = true;
            stackElement.Children.Add(descriptionElement);

           
        }

        protected override SizeF MeasureOverride(SizeF availableSize)
        {
            SizeF originalAvailableSize = availableSize;
            SizeF desiredSize = SizeF.Empty;

            System.Windows.Forms.Padding borderThickness = this.GetBorderThickness(false);
            availableSize.Width -= borderThickness.Horizontal + this.Padding.Horizontal;
            availableSize.Height -= borderThickness.Vertical + this.Padding.Vertical;

            imageElement.Measure(availableSize);
            availableSize.Width -= imageElement.DesiredSize.Width;

            stackElement.Measure(availableSize);

            desiredSize.Width = imageElement.DesiredSize.Width + stackElement.DesiredSize.Width;
            desiredSize.Height = Math.Max(imageElement.DesiredSize.Height, stackElement.DesiredSize.Height);

            desiredSize.Width += borderThickness.Horizontal + this.Padding.Horizontal;
            desiredSize.Height += borderThickness.Vertical + this.Padding.Vertical;

            desiredSize.Width = Math.Min(desiredSize.Width, originalAvailableSize.Width);
            desiredSize.Height = Math.Min(desiredSize.Height, originalAvailableSize.Height);

            return desiredSize;
        }

        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            RectangleF clientRect = GetClientRectangle(finalSize);
            float x = clientRect.X;

            imageElement.Arrange(new RectangleF(x, clientRect.Y, imageElement.DesiredSize.Width, imageElement.DesiredSize.Height));
            x += imageElement.DesiredSize.Width;
            stackElement.Arrange(new RectangleF(x, clientRect.Y, stackElement.DesiredSize.Width, stackElement.DesiredSize.Height));

            return finalSize;
        }

        public override void Synchronize()
        {
            base.Synchronize();

            InfoItem item = (InfoItem)this.Data.DataBoundItem;
            this.headerElement.Text = item.Title;
            this.descriptionElement.Text=item.Description;
            this.headerElement.ForeColor= item.Color=="Red"? Color.Red:Color.Green;
        }

       
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(RadListVisualItem);
            }
        }

        #endregion


        #region Properties

        

        public LightVisualElement HeaderElement
        {
            get
            {
                return this.headerElement;
            }
        }

        #endregion

    }
}
