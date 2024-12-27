using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Services
{
    public class LocalStudentNoteService
    {
        private readonly IStudentNoteService studentNoteService;
  
        public LocalStudentNoteService(IStudentNoteService studentNoteService)
        {
            this.studentNoteService = studentNoteService;
        }
        // récupération des notes d'une évaluation,calcul des moyennes et classement
        public async Task<List<AverageRecord>> GetEvaluationAverageListByRoom(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            var averageList = new List<AverageRecord>();
            var notesToOrder = new List<StudentNote>();
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var extractedData = await studentNoteService.GetNotesByRoomAsync(roomId, evaluationId, schoolYearId);
            var evaluation = extractedData.Where(x => x.BookId == bookId);
            var idStudentList = evaluation.Select(x => x.StudentId).Distinct().ToList();
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            foreach (var studentId in idStudentList)
            {
                //get student subject list
                var idSubjectList = evaluation.Where(x=> x.StudentId == studentId).Select(x => x.SubjectId).Distinct();
                //calcul de la moyenne
                double sumCoef = 0;//somme de coefficients
                double sumNote = 0;// somme de notes
                double average = 0;
                if (classOfRoom.AverageFormula == 0)
                {
                    sumNote = evaluation.Where(x => x.StudentId == studentId).Sum(x => x.Note);
                    var sumMaxNote = evaluation.Where(x => x.StudentId == studentId).Sum(x => x.NotedOn);
                    average = sumMaxNote > 0 ? (sumNote * 20) / sumMaxNote : 0;
                }
                else
                {
                    foreach (var subjectId in idSubjectList)
                    {
                        var evaluationLine = evaluation.First(x => x.SubjectId == subjectId && x.StudentId == studentId);
                        double note20 = evaluationLine.Note * 20 / evaluationLine.NotedOn;// on ramene la note a 20;
                        var subjectNote = note20 * evaluationLine.NoteCoef;
                        sumCoef += evaluationLine.NoteCoef;
                        sumNote += subjectNote;
                    }
                    average = sumCoef > 0 ? sumNote / sumCoef : 0;
                }
                var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == studentId);
                notesToOrder.Add(new()
                {
                    Id = studentId,
                    Note = average,
                    NotedOn= sumNote,
                    StudentId = studentId,
                    Student = student,
                });
            }
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageOfRoom(room, bookId));
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = classOfRoom.NoteIsTruncate == false ? double.Parse(item.Note.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(item.Note, 2);
                if (systemRating != null)
                {

                    rating = GetLanguageOfRoom(room, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note,item.NotedOn, rating, item.Position));
            }
            return averageList;
        }
        // récupération des notes d'une évaluation et classement.
        public async Task<List<EvaluationRecord>> GetEvaluationNoteListByRoom(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            var listOfNoteOrdored = new List<StudentNote>();
            var evaluationNoteList = new List<EvaluationRecord>();
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var extractedData = await studentNoteService.GetNotesByRoomAsync(roomId, evaluationId, schoolYearId);
            var notesToOrder = extractedData.Where(x => x.BookId == bookId).ToList();
            //get distinct subject id
            var subjectList = extractedData.Select(x => x.SubjectId).Distinct();
            //generate order list by subject
            foreach (var subjectId in subjectList)
            {
                var notes = notesToOrder.Where(x => x.SubjectId == subjectId).ToList();
                listOfNoteOrdored.AddRange(GenerateOrderedWithPosition(notes, GetLanguageOfRoom(room, bookId)));
            }
            foreach (var item in listOfNoteOrdored)
            {
                var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == item.StudentId);
                //get subject, subject group
                var classSubject = Program.ClassSubjectList.FirstOrDefault(x => x.ClassId==room.ClassId && x.SubjectId == item.SubjectId);
                var subject= classSubject.Subject;
                var subjectGroup=classSubject.Group;
                //get rating
                var note20 = item.NotedOn == 20 ? item.Note : GetNote20(item.Note, item.NotedOn);
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note20 && x.MaxNote >= note20);
                var rating = string.Empty;
                var noteWithMax=$"{item.Note}/{item.NotedOn}";
                var noteAsString=item.Note.ToString();
                if (systemRating != null)
                {

                    rating = GetLanguageOfRoom(room, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                evaluationNoteList.Add(new(item.Id, student, subject,subjectGroup, item.Note,noteAsString,noteWithMax,item.NoteCoef,item.NotedOn, rating, item.Position));
            }
            return evaluationNoteList;
        }

        //get average for first tem
        public async Task<List<AverageRecord>> GetFirstTermAverageListByRoom(int roomId,  int schoolYearId, int bookId)
        {
            var averageList = new List<AverageRecord>();
            var allEvalList = new List<AverageRecord>();
            var eval1 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL01");
            var eval2 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL02");
            var eval3 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL03");
            var eval1AverageList=  await GetEvaluationAverageListByRoom(roomId,eval1.Id,schoolYearId,bookId);
            var eval2AverageList = await GetEvaluationAverageListByRoom(roomId, eval2.Id, schoolYearId, bookId);
            var eval3AverageList = await GetEvaluationAverageListByRoom(roomId, eval3.Id, schoolYearId, bookId);
            allEvalList.AddRange(eval1AverageList);
            allEvalList.AddRange(eval2AverageList);
            allEvalList.AddRange(eval3AverageList);
            var students = allEvalList.Select(x => x.Student).Distinct(); 
            var notesToOrder= new List<StudentNote>();
            foreach (var student in students)
            {
                var eval1Note= eval1AverageList.FirstOrDefault(x=>x.Student.Id==student.Id);
                var eval2Note = eval2AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval3Note = eval3AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                double average = 0;
                double sumNote = 0;
                if (eval1Note != null)
                {
                    if (eval2Note != null)
                    {
                        if (eval3Note != null)
                        {
                            sumNote = (eval1Note.Average + eval2Note.Average + eval3Note.Average);
                            average =sumNote/3;
                        }
                        else
                        {
                            sumNote = (eval1Note.Average + eval2Note.Average);
                            average = sumNote / 2;
                        }
                    }
                    else
                    {
                        if(eval3Note != null)
                        {
                            sumNote = (eval1Note.Average + eval3Note.Average);
                            average = sumNote/2;
                        }
                        else
                        {
                            sumNote = eval1Note.Average;
                            average = sumNote;
                        }
                    }
                }
                else
                {
                    if(eval2Note!= null)
                    {
                        if(eval3Note!= null)
                        {
                            sumNote = (eval2Note.Average + eval3Note.Average);
                            average = sumNote/2;
                        }
                        else
                        {
                            sumNote= eval2Note.Average;
                            average = sumNote;
                        }
                    }
                    else
                    {
                        if (eval3Note != null)
                        {
                            sumNote = eval3Note.Average;
                            average =sumNote;
                        }
                    }
                }
                notesToOrder.Add(new()
                {
                    Id = student.Id,
                    Note = average,
                    NotedOn=sumNote,
                    StudentId = student.Id,
                    Student = student,
                });
            }
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageOfRoom(room, bookId));
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = classOfRoom.NoteIsTruncate == false ? double.Parse(item.Note.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(item.Note, 2);
                if (systemRating != null)
                {
                    rating = GetLanguageOfRoom(room, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note,item.NotedOn, rating, item.Position));
            }
            return averageList;
        }
        //get average for second tem
        public async Task<List<AverageRecord>> GetSecondTermAverageListByRoom(int roomId, int schoolYearId, int bookId)
        {
            var averageList = new List<AverageRecord>();
            var allEvalList = new List<AverageRecord>();
            var eval1 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL04");
            var eval2 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL05");
            var eval3 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL06");
            var eval1AverageList = await GetEvaluationAverageListByRoom(roomId, eval1.Id, schoolYearId, bookId);
            var eval2AverageList = await GetEvaluationAverageListByRoom(roomId, eval2.Id, schoolYearId, bookId);
            var eval3AverageList = await GetEvaluationAverageListByRoom(roomId, eval3.Id, schoolYearId, bookId);
            allEvalList.AddRange(eval1AverageList);
            allEvalList.AddRange(eval2AverageList);
            allEvalList.AddRange(eval3AverageList);
            double sumNote = 0;
            var students = allEvalList.Select(x => x.Student).Distinct();
            var notesToOrder = new List<StudentNote>();
            foreach (var student in students)
            {
                var eval1Note = eval1AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval2Note = eval2AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval3Note = eval3AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                double average = 0;
                if (eval1Note != null)
                {
                    if (eval2Note != null)
                    {
                        if (eval3Note != null)
                        {
                            sumNote = (eval1Note.Average + eval2Note.Average + eval3Note.Average);
                            average = sumNote/ 3;
                        }
                        else
                        {
                            sumNote = (eval1Note.Average + eval2Note.Average);
                            average =sumNote /2;
                        }
                    }
                    else
                    {
                        if (eval3Note != null)
                        {
                            sumNote = (eval1Note.Average + eval3Note.Average);
                            average = sumNote/2;
                        }
                        else
                        {
                            sumNote = eval1Note.Average;
                            average = sumNote;
                        }
                    }
                }
                else
                {
                    if (eval2Note != null)
                    {
                        if (eval3Note != null)
                        {
                            sumNote = (eval2Note.Average + eval3Note.Average);
                            average = sumNote/2;
                        }
                        else
                        {
                            sumNote = eval2Note.Average;
                            average = sumNote;
                        }
                    }
                    else
                    {
                        if (eval3Note != null)
                        {
                            sumNote = eval3Note.Average;
                            average = sumNote;
                        }
                    }
                }
                notesToOrder.Add(new()
                {
                    Id = student.Id,
                    Note = average,
                    NotedOn=sumNote,
                    StudentId = student.Id,
                    Student = student,
                });
            }
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageOfRoom(room, bookId));
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = classOfRoom.NoteIsTruncate == false ? double.Parse(item.Note.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(item.Note, 2);
                if (systemRating != null)
                {
                    rating = GetLanguageOfRoom(room, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note,item.NotedOn, rating, item.Position));
            }
            return averageList;
        }
        //get average for third tem
        public async Task<List<AverageRecord>> GetThirdTermAverageListByRoom(int roomId, int schoolYearId, int bookId)
        {
            var averageList = new List<AverageRecord>();
            var allEvalList = new List<AverageRecord>();
            var eval1 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL07");
            var eval2 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == "EVAL08");
            var eval1AverageList = await GetEvaluationAverageListByRoom(roomId, eval1.Id, schoolYearId, bookId);
            var eval2AverageList = await GetEvaluationAverageListByRoom(roomId, eval2.Id, schoolYearId, bookId);
            allEvalList.AddRange(eval1AverageList);
            allEvalList.AddRange(eval2AverageList);
            var students = allEvalList.Select(x => x.Student).Distinct();
            var notesToOrder = new List<StudentNote>();
            foreach (var student in students)
            {
                var eval1Note = eval1AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval2Note = eval2AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                double average = 0;
                double sumNote = 0;
                if (eval1Note != null)
                {
                    if (eval2Note != null)
                    {
                        sumNote = (eval1Note.Average + eval2Note.Average);
                        average = sumNote / 2;
                    }
                    else
                    {
                        sumNote= eval1Note.Average;
                        average = sumNote;
                    }
                }
                else
                {
                    if (eval2Note != null)
                    {
                        sumNote= eval1Note.Average;
                        average = sumNote;
                    }
                }
                notesToOrder.Add(new()
                {
                    Id = student.Id,
                    Note = average,
                    NotedOn=sumNote,
                    StudentId = student.Id,
                    Student = student,
                });
            }
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageOfRoom(room, bookId));
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = classOfRoom.NoteIsTruncate == false ? double.Parse(item.Note.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(item.Note, 2);
                if (systemRating != null)
                {
                    rating = GetLanguageOfRoom(room, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note,item.NotedOn, rating, item.Position));
            }
            return averageList;
        }
        // order de value and add de position
        public static IOrderedEnumerable<StudentNote> GenerateOrderedWithPosition(List<StudentNote> notes, string language)
        {

            var listOrdered = notes.OrderByDescending(n => n.Note);
            //definition du rang
            int position = 1;
            foreach (var n in listOrdered)
            {
                if (position == 1)
                {
                    n.Position = language == "FR" ? "1ᵉʳ" : "1ˢᵗ";
                }
                else
                {
                    if (position == 2)
                    {
                        n.Position = language == "FR" ? (position) + "ᵉ" : "2ⁿᵈ";
                    }
                    else
                    {
                        if (position == 3)
                        {
                            n.Position = language == "FR" ? (position) + "ᵉ" : "3ʳᵈ";
                        }
                        else
                        {
                            n.Position = language == "FR" ? (position) + "ᵉ" : position + "ᵗʰ";
                        }
                    }
                }
                position++;
            }
            var tableOrdered = listOrdered.ToArray();
            //recherche des rangs exeaquo
            for (int i = 1; i < tableOrdered.Length; i++)
            {
                if (tableOrdered[i].Note == tableOrdered[i - 1].Note)
                {
                    tableOrdered[i].Position = tableOrdered[i - 1].Position + " ex";
                    if (tableOrdered[i - 1].Position.Length > 3)
                        tableOrdered[i].Position = tableOrdered[i - 1].Position.Substring(0, 3) + " ex";

                }
            }
            return listOrdered;
        }

        //extraction de la langue associée au des documents de la  classe
        public static string GetLanguageOfClass(SchoolClass selectedClass,int bookId)
        {
            if (selectedClass.DocumentLanguageId == 1 || selectedClass.DocumentLanguageId == 2 && bookId == 1)
            {
               return "EN";
            }
            return "FR";
        }

        //extraction de la langue associée au des documents de la salle de classe
        public static string GetLanguageOfRoom(SchoolRoom selectedRoom, int bookId)
        {
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedRoom.ClassId);

            if (classOfRoom.DocumentLanguageId == 1 || classOfRoom.DocumentLanguageId == 2 && bookId == 1)
            {
                return "EN";
            }
            return "FR";
        }
    
        // retourne la note sur 20. ceci est nécessaire pour des matières dont la note max est >20
       public static double GetNote20(double note,double notedOn)
        {
            double coef = 0;
            if (notedOn != 0) coef = 20 / notedOn;
            return Math.Abs(note) * coef;
        }
    }
}
