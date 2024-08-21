

using SchoolManagement.Core.Model;
using System;
using Telerik.WinControls.UI;
using static SchoolManagement.Core.Model.TimeTable;

namespace Primary.SchoolApp.DTO
{
    internal class TimeTableAppointment:Appointment
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int RoomId { get; set; }
        public int SchoolYearId { get; set; }
        public TimeTableState State { get; set; }
        public bool IsClosed { get; set; }
        public int DayId { get; set; }
        public SchoolManagement.Core.Model.DayOfWeek Day { get; set; }
        public DateTime TeacherIn { get; set; }
        public DateTime TeacherOut { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public virtual Subject Course { get; set; }
        public virtual Employee Teacher { get; set; }
        public virtual SchoolRoom Room { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual string Name { get; set; }

        public TimeTableAppointment() : base()
        {

        }
       
        
    }
}
