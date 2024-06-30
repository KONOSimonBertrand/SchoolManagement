using SchoolManagement.UserInterface.Properties;
using System;
using System.Drawing;
using System.Linq;
using Telerik.WinControls.UI;

namespace SchoolManagement.UserInterface.UI
{
    public partial class MainForm : RadForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.FormElement.TitleBar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            RadPageViewPage calendarPage = new RadPageViewPage("Calendar");
            calendarPage.Image = Resources.ResourceManager.GetObject("calendar_32x32") as Image;
            mailUserControl1.mailTemplatePageView.Pages.Add(calendarPage);
            mailUserControl1.mailTemplatePageView.SelectedPageChanging += mailTemplatePageView_SelectedPageChanging;

            RadPageViewPage mailPage = new RadPageViewPage("Mail");
            mailPage.Image = Resources.ResourceManager.GetObject("mail_32x32") as Image;
            calendarUserControl1.calendarPageView.Pages.Insert(0, mailPage);
            calendarUserControl1.calendarPageView.SelectedPageChanging += calendarPageView_SelectedPageChanging;
        }

        void calendarPageView_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            if (e.Page.Text == "Mail")
            {
                e.Cancel = true;
                mailUserControl1.BringToFront();
            }
        }

        void mailTemplatePageView_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            if (e.Page.Text == "Calendar")
            {
                e.Cancel = true;
                calendarUserControl1.BringToFront();
            }
        }
    }
}
