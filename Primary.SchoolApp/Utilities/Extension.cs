
using Primary.SchoolApp.DTO;
using SchoolManagement.Core.Model;
using System.Threading;

namespace Primary.SchoolApp.Utilities
{
    static class Extension
    {
        public static EvaluationSessionChild AsEvaluationSessionChild(this EvaluationSession session)
        {
            EvaluationSessionChild dto = new();
            dto.Code = session.Code;
            dto.Id = session.Id;
            dto.FrenchName = session.FrenchName;
            dto.EnglishName = session.EnglishName;
            dto.Sequence = session.Sequence;
            return dto;
        }
        public static TimeTableAppointment AsTimeTableAppointment(this TimeTable timetable)
        {
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
        public static TimeTable AsTimeTable(this TimeTableAppointment timetable)
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
        public static StudentEnrollingDTO AsStudentEnrollingDTO(this StudentEnrolling enrolling)
        {
            var dto = new StudentEnrollingDTO
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
        public static StudentEnrolling AsStudentEnrolling(this StudentEnrollingDTO enrolling)
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
        public static Contact AsContact(this ContactDTO contactDTO)
        {
            var contact = new Contact()
            {
                Address = contactDTO.Address,
                Email = contactDTO.Email,
                Id = contactDTO.Id,
                IdCard = contactDTO.IdCard,
                Job = contactDTO.Job,
                Name = contactDTO.Name,
                Phone = contactDTO.Phone,
                Relationship = contactDTO.Relationship,
                Sex = contactDTO.Sex,
                Student = contactDTO.Student,
                StudentId = contactDTO.StudentId,



            };
            return contact;
        }
        public static ContactDTO AsContactDTO(this Contact contact)
        {
            var contactDTO = new ContactDTO()
            {
                Address = contact.Address,
                Email = contact.Email,
                Id = contact.Id,
                IdCard = contact.IdCard,
                Job = contact.Job,
                Name = contact.Name,
                Phone = contact.Phone,
                Relationship = contact.Relationship,
                Sex = contact.Sex,
                Student = contact.Student,
                StudentId = contact.StudentId,
                RelationshipName = AppUtilities.GetRelationshipName(contact.Relationship),


            };
            return contactDTO;
        }

        public static StudentNoteDTO AsStudentNoteDTO(this StudentNote recordNote)
        {
            var dto = new StudentNoteDTO()
            {
                Id = recordNote.Id,
                BookId = recordNote.BookId,
                Comment = recordNote.Comment,
                Date = recordNote.Date,
                Evaluation = recordNote.Evaluation,
                EvaluationId = recordNote.EvaluationId,
                Note = recordNote.Note,
                NoteCoef = recordNote.NoteCoef,
                NotedOn = recordNote.NotedOn,
                Position = recordNote.Position,
                SchoolYear = recordNote.SchoolYear,
                SchoolYearId = recordNote.SchoolYearId,
                Student = recordNote.Student,
                StudentId = recordNote.StudentId,
                Subject = recordNote.Subject,
                SubjectId = recordNote.SubjectId,
            };
            return dto;
        }
        public static StudentNote AsStudentNote(this StudentNoteDTO recordNote)
        {
            var dto = new StudentNote()
            {
                Id = recordNote.Id,
                BookId = recordNote.BookId,
                Comment = recordNote.Comment,
                Date = recordNote.Date,
                Evaluation = recordNote.Evaluation,
                EvaluationId = recordNote.EvaluationId,
                Note = recordNote.Note,
                NoteCoef = recordNote.NoteCoef,
                NotedOn = recordNote.NotedOn,
                Position = recordNote.Position,
                SchoolYear = recordNote.SchoolYear,
                SchoolYearId = recordNote.SchoolYearId,
                Student = recordNote.Student,
                StudentId = recordNote.StudentId,
                Subject = recordNote.Subject,
                SubjectId = recordNote.SubjectId,
            };
            return dto;
        }

    }
}
