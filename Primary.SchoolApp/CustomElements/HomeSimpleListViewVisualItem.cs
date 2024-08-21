

using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Drawing;
using System.Linq;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.CustomElements
{
    internal class HomeSimpleListViewVisualItem : SimpleListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
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

            if (Data.Group != null)
            {
                if (this.Data.Group.Text.ToUpper() == Language.labelStudentsByGroup.ToUpper())
                {
                    this.countImage.Image = null;
                    this.countElement.Text = GetStudentBySchoolGroup((int)this.dataItem.Key);
                }
                else
                {
                    if (this.Data.Group.Text.ToUpper() == Language.labelStudentsByClass.ToUpper())
                    {
                        this.countImage.Image = null;
                        this.countElement.Text = GetStudentByClass((int)this.dataItem.Key);
                    }
                    else
                    {
                        if (this.Data.Group.Text.ToUpper() == Language.labelTuitionFees.ToUpper())
                        {
                            this.countImage.Image = null;
                            this.countElement.Text = GetStudentByTuitionFeeStatus((int)this.dataItem.Key);
                        }
                        else
                        {
                            if (this.Data.Group.Text.ToUpper() == Language.labelHealthStatus.ToUpper())
                            {
                                this.countImage.Image = null;
                                this.countElement.Text = GetStudentByStatusHealth((int)this.dataItem.Key);
                            }
                            else
                            {
                                if (this.Data.Group.Text.ToUpper() == Language.labelInsolvency.ToUpper())
                                {
                                    this.countImage.Image = null;
                                    this.countElement.Text = GetStudentByInsolvency((int)this.dataItem.Key);
                                }
                                else
                                {
                                    if (this.Data.Group.Text.ToUpper() == Language.labelSolvency.ToUpper())
                                    {
                                        this.countImage.Image = null;
                                        this.countElement.Text = GetStudentBySolvency((int)this.dataItem.Key);
                                    }
                                    else
                                    {
                                        if (this.Data.Group.Text.ToUpper() == Language.labelStudentsByStatus.ToUpper())
                                        {
                                            this.countImage.Image = null;
                                            this.countElement.Text = GetStudentByStatus((int)this.dataItem.Key);
                                        }
                                        else
                                        {
                                            this.countImage.Image = null;
                                            this.countElement.Text = "0";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            

        }
        private string GetStudentBySchoolGroup(int id)
        {
           int count = 0;
           count= Program.StudentEnrollingList.Where(i => i.IsActive && i.SchoolClass.Group.Id == id).Count();
            return count.ToString();
        }
        private string GetStudentByClass(int id)
        {
            int count = 0;
            count = Program.StudentEnrollingList.Where(i => i.IsActive && i.SchoolClass.Id == id).Count();
            return count.ToString();
        }
        private string GetStudentByStatusHealth(int status)
        {
            int count = 0;
            count = Program.StudentEnrollingList.Where(i => i.IsActive && i.Student.Health==status).Count();          
            return count.ToString();
        }

        // recherche les nombre d'élèves par statut de paiement
        private string GetStudentByTuitionFeeStatus(int paymentType)
        {
            int count = 0;
            
            return count.ToString();
        }
        // extraction des eleves insolvable
        private string GetStudentByInsolvency(int paymentType)
        {
            int count = 0;
           
            return count.ToString();
        }
        //extraction des eleves solvables
        private string GetStudentBySolvency(int paymentType)
        {
            int count = 0;
            
            return count.ToString();
        }
        //extraction des eleves actif
        private string GetStudentByStatus(int status)
        {
            bool boolStatus = false;
            if (status == 1) boolStatus = true;
            var count=Program.StudentEnrollingList.Where(x=>x.IsActive== boolStatus).Count();
            return count.ToString();
        }

    }
}
