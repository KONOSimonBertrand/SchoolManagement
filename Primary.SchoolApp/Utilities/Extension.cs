
using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.Threading;

namespace Primary.SchoolApp.Utilities
{
    static class Extension
    {
        public static EvaluationSessionChild ConvertToEvaluationSessionChild(this EvaluationSession session)
        {
            EvaluationSessionChild dto = new();
            dto.Code = session.Code;
            dto.Id = session.Id;
            dto.FrenchName = session.FrenchName;
            dto.EnglishName = session.EnglishName;
            dto.Sequence=session.Sequence;
            return dto;
        }
        public static TimeTableAppointment ConvertToTimeTableAppointment(this TimeTable timetable) {
            var dto = new TimeTableAppointment
            {
                Id = timetable.Id,
                Description = timetable.Description,
                SubjectId = timetable.SubjectId,
                TeacherId = timetable.TeacherId,
                RoomId = timetable.RoomId,
                SchoolYearId = timetable.SchoolYearId,
                State = timetable.State,
                IsClosed = timetable.IsClosed,
                DayId = (int)timetable.StartHour.DayOfWeek,
                Day = timetable.Day,
                TeacherIn = timetable.TeacherIn,
                TeacherOut = timetable.TeacherOut,
                Start = timetable.StartHour,
                End = timetable.EndHour,
                Course = timetable.Course,
                Teacher = timetable.Teacher,
                SchoolYear = timetable.SchoolYear,
                Room = timetable.Room,
                Name = Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? timetable.Course.FrenchName : timetable.Course.EnglishName,
                Location = timetable.Teacher.FullName,
                BackgroundId = (int)timetable.State
            };
            return dto;
        }
        /// <summary>
        /// Converti l'object TimeTableAppointment qui représente un Appointment en object TimeTable
        /// </summary>
        public static TimeTable ConvertToTimeTable(this TimeTableAppointment timetable)
        {
            var dto = new TimeTable
            {
                Id = timetable.Id,
                Description = timetable.Description,
                SubjectId = timetable.SubjectId,
                TeacherId = timetable.TeacherId,
                RoomId = timetable.RoomId,
                SchoolYearId = timetable.SchoolYearId,
                State = timetable.State,
                IsClosed = timetable.IsClosed,
                DayId = timetable.DayId,
                Day = timetable.Day,
                TeacherIn = timetable.TeacherIn,
                TeacherOut = timetable.TeacherOut,
                StartHour = timetable.Start,
                EndHour = timetable.End,
                Course = timetable.Course,
                Teacher = timetable.Teacher,
                SchoolYear = timetable.SchoolYear,
                Room = timetable.Room
            };
            return dto;
        }

        public static StudentEnrollingDTO ConvertToStudentEnrollingDTO(this StudentEnrolling enrolling)
        {
            var dto = new StudentEnrollingDTO
            {
                Id = enrolling.Id,
                Date = enrolling.Date,
                SchoolYearId = enrolling.SchoolYearId,       
                StudentId = enrolling.StudentId,
                ClassId = enrolling.ClassId,
                OldSchool= enrolling.OldSchool,
                IsRepeater = enrolling.IsRepeater,
                IsActive = enrolling.IsActive,
                ReasonLeft = enrolling.ReasonLeft,
                PictureUrl = enrolling.PictureUrl,
                Student= enrolling.Student,
                SchoolClass = enrolling.SchoolClass,
                SchoolYear = enrolling.SchoolYear,     
            };
            return dto;
        }
        public static StudentEnrolling ConvertToStudentEnrolling(this StudentEnrollingDTO enrolling)
        {
            var dto = new StudentEnrolling
            {
                Id = enrolling.Id,
                Date = enrolling.Date,
                SchoolYearId = enrolling.SchoolYearId,
                StudentId = enrolling.StudentId,
                ClassId = enrolling.ClassId,
                OldSchool = enrolling.OldSchool,
                IsRepeater = enrolling.IsRepeater,
                IsActive = enrolling.IsActive,
                ReasonLeft = enrolling.ReasonLeft,
                PictureUrl = enrolling.PictureUrl,
                Student = enrolling.Student,
                SchoolClass = enrolling.SchoolClass,
                SchoolYear = enrolling.SchoolYear,
            };
            return dto;
        }

    }
}
