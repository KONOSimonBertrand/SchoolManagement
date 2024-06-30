using Telerik.WinControls.UI;

namespace SchoolManagement.UI
{
    public class TimeTableFactory : IAppointmentFactory
    {
        public IEvent CreateNewAppointment()
        {
            return new TimeTable();
        }
    }
}
