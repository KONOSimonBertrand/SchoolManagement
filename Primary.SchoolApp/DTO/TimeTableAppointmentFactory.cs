

using Telerik.WinControls.UI;

namespace Primary.SchoolApp.DTO
{
    public class TimeTableAppointmentFactory : IAppointmentFactory
    {
        public IEvent CreateNewAppointment()
        {
            return new TimeTableAppointment();
        }
    }
}
