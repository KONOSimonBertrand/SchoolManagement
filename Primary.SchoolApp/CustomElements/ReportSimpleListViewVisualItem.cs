

using Primary.SchoolApp.Utilities;
using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.CustomElements
{
    class ReportSimpleListViewVisualItem : SimpleListViewVisualItem
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
            this.countElement.MinSize = countElement.MaxSize = new System.Drawing.Size(80, 0);
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

            this.DrawText = true;
            this.ToggleElement.Text = this.Text;

            this.ToggleElement.CustomFont = AppUtilities.MainFont;
            this.ToggleElement.CustomFontSize = 10.5f;
            this.ToggleElement.TextElement.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.countElement.MinSize = countElement.MaxSize = new System.Drawing.Size(120, 0);

            this.countElement.CustomFont = AppUtilities.MainFont;
            this.countElement.CustomFontSize = 10.5f;
            this.countElement.CustomFontStyle = FontStyle.Regular;

            this.countImage.Image = AppUtilities.GetImage("Show");
            switch (this.Data.Group.Text)
            {
                case "VERSEMENT PAR GROUPE":
                    this.countElement.Text = GetPaymentByGroup((int)this.dataItem.Key);
                    break;
                case "VERSEMENT PAR CLASSE":
                    this.countElement.Text = GetPaymentByClass((int)this.dataItem.Key);
                    break;
                case "IMPAYES PAR GROUPE":
                    this.countElement.Text = GetUnpaidByGroup((int)this.dataItem.Key);
                    break;

                case "IMPAYES PAR CLASSE":
                    this.countElement.Text = GetUnpaidByClass((int)this.dataItem.Key);
                    break;
                case "REDUCTIONS":
                    this.countElement.Text = GetDiscountByCostType((int)this.dataItem.Key);
                    break;
                case "VIREMENT PAR GROUPE":
                    this.countElement.Text = GetSalaryByGroup((int)this.dataItem.Key);
                    break;
                case "VIREMENT PAR MOIS":
                    this.countElement.Text = GetSalaryByMoth((int)this.dataItem.Key);
                    break;
                case "MONTANT PAR TYPE":
                    this.countElement.Text = GetCashFlowByGroup((int)this.dataItem.Key);
                    break;
                case "MONTANT PAR MOIS":
                    this.countElement.Text = GetCashFlowByMonth((int)this.dataItem.Key);
                    break;
                case "ABONNEMENT PAR CLASSE":
                    this.countElement.Text = GetSubscriptionByClass((int)this.dataItem.Key);
                    break;
                case "ABONNEMENT PAR GROUPE":
                    this.countElement.Text = GetSubscriptionByGroup((int)this.dataItem.Key);
                    break;
                case "SALLES DE CLASSE":
                    this.countElement.Text = GetRoomByClass((int)this.dataItem.Key);
                    break;
                case "ELEVES PAR CLASSE":
                    this.countElement.Text = GetStudentByClass((int)this.dataItem.Key);
                    break;
                case "ENSEIGNANTS PAR CLASSE":
                    this.countElement.Text = GetTeacherByClass((int)this.dataItem.Key);
                    break;
                case "ELEVES PAR SALLE":
                    this.countElement.Text = GetStudentByRoom((int)this.dataItem.Key);
                    break;
                case "ENSEIGNANTS PAR SALLE":
                    this.countElement.Text = GetTeacherByRoom((int)this.dataItem.Key);
                    break;
                case "MATIERES PAR CLASSE":
                    this.countElement.Text = GetSubjectByClass((int)this.dataItem.Key);
                    break;
                case "MATIERES PAR GROUPE":
                    this.countElement.Text = GetSubjectByGroup((int)this.dataItem.Key);
                    break;
                case "EMPLOYÉ PAR GROUPE":
                    this.countElement.Text = GetEmployeeByGroup((int)this.dataItem.Key);
                    break;
                case "EFFECTIF PAR GROUPE":
                    this.countElement.Text = GetStudentBySchoolGroup((int)this.dataItem.Key);
                    break;
                case "EFFECTIF PAR CLASSE":
                    this.countElement.Text = GetStudentByClass((int)this.dataItem.Key);
                    break;
                case "FRAIS DE SCOLARITE":
                    this.countElement.Text = GetStudentByStatus(this.dataItem.Key.ToString());
                    break;
                case "ETAT DE SANTE":
                    this.countElement.Text = GetStudentByHealth((int)this.dataItem.Key);
                    break;
                case "INSOLVABILITE":
                    this.countElement.Text = GetStudentByInsolvency((int)this.dataItem.Key);
                    break;
                case "SOLVABILITE":
                    this.countElement.Text = "";
                    break;
                case "ETAT DES EFFECTIFS":
                    this.countElement.Text = GetStudentByStatus((int)this.dataItem.Key);
                    break;
                case "ETAT DES ABONNEMENTS":
                    this.countElement.Text = GetSubscriptionByStatus((int)this.dataItem.Key);
                    break;
                default:
                    this.countElement.Text = "0";
                    break;

            }
        }
        private string GetPaymentByGroup(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetPaymentByClass(int id)
        {
            double sum = 0;
            return sum.ToString();
        }
        private string GetUnpaidByClass(int id)
        {
            double sum = 0;
           
            return sum.ToString();
        }
        private string GetUnpaidByGroup(int id)
        {
            double sum = 0;

            
            return sum.ToString();
        }
        private string GetDiscountByCostType(int id)
        {

            double sum = 0;
            return sum.ToString();
        }
        private string GetSalaryByGroup(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetSalaryByMoth(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetCashFlowByGroup(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetCashFlowByMonth(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetNoteByClass(int id)
        {

            double sum = 0;
            double countNote = 0;
            double sumNote = 0;
            sum = countNote>0?sumNote / countNote:0;

            if (countNote == 0 || sumNote == 0)
            {
                sum = 0;
            }
            else
            {
                sum = double.Parse(sum.ToString("F", System.Globalization.CultureInfo.CurrentCulture));

            }

            return sum.ToString();
        }
        private string GetNoteByClass(int sessionId, int classId)
        {

            double sum = 0;
            double countNote = 0;
            double sumNote = 0;

            sum = sumNote / countNote;

            if (countNote == 0 || sumNote == 0)
            {
                sum = 0;
            }
            else
            {
                sum = double.Parse(sum.ToString("F", System.Globalization.CultureInfo.CurrentCulture));

            }
            var response = "M:" + sum.ToString() + ";A:" +  ";E:" ;
            return response;
        }
        private string GetSubscriptionByGroup(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetSubscriptionByClass(int id)
        {

            double sum = 0;


            return sum.ToString();
        }
        private string GetSubscriptionByStatus(int id)
        {

            int count = 0;
            if (id == 0)
            {
            }
            else
            {
            }

            return count.ToString();
        }
        //.......................

        private string GetRoomByClass(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetStudentByClass(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetTeacherByClass(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetStudentByRoom(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetTeacherByRoom(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetSubjectByClass(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetSubjectByGroup(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetEmployeeByGroup(int id)
        {
            int count = 0;
            return count.ToString();
        }
        private string GetStudentBySchoolGroup(int id)
        {
            int count = 0;


            return count.ToString();
        }
        private string GetStudentByStatus(string status)
        {
            int count = 0;

            return count.ToString();
        }
        private string GetStudentByHealth(int status)
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
            int count = 0;
            return count.ToString();
        }


    }
}
