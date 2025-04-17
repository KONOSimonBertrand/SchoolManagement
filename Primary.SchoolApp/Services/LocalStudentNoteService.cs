using ClosedXML.Excel;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Services
{
    public class LocalStudentNoteService
    {
        private readonly IStudentNoteService studentNoteService;
        private readonly IDisciplineService disciplineService;

        public LocalStudentNoteService(IStudentNoteService studentNoteService, IDisciplineService disciplineService)
        {
            this.studentNoteService = studentNoteService;
            this.disciplineService = disciplineService;
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
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            foreach (var studentId in idStudentList)
            {
                //get student subject list
                var idSubjectList = evaluation.Where(x => x.StudentId == studentId).Select(x => x.SubjectId).Distinct();
                //calcul de la moyenne
                double sumCoef = 0;//somme de coefficients
                double sumNote = 0;// somme de notes
                double average = 0;
                if (classGroup.AverageFormula == 0)
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
                    NotedOn = sumNote,
                    StudentId = studentId,
                    Student = student,
                });
            }
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(classGroup, bookId));
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, classGroup);
                if (systemRating != null)
                {

                    rating = GetLanguageGroup(classGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note, item.NotedOn, rating, item.Position));
            }
            return averageList;
        }
        // récupération des notes d'une évaluation et classement.
        public async Task<List<EvaluationRecord>> GetEvaluationNoteListByRoom(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            var listOfNoteOrdored = new List<StudentNote>();
            var evaluationNoteList = new List<EvaluationRecord>();
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var language = GetLanguageGroup(classGroup, bookId);
            var extractedData = await studentNoteService.GetNotesByRoomAsync(roomId, evaluationId, schoolYearId);
            var notesToOrder = extractedData.Where(x => x.BookId == bookId).ToList();
            //get distinct subject id
            var subjectList = extractedData.Select(x => x.SubjectId).Distinct();
            //generate order list by subject
            foreach (var subjectId in subjectList)
            {
                var notes = notesToOrder.Where(x => x.SubjectId == subjectId).ToList();
                listOfNoteOrdored.AddRange(GenerateOrderedWithPosition(notes, GetLanguageGroup(classGroup, bookId)));
            }
            foreach (var item in listOfNoteOrdored)
            {
                var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == item.StudentId);
                //get subject, subject group
                var classSubject = Program.ClassSubjectList.FirstOrDefault(x => x.ClassId == room.ClassId && x.SubjectId == item.SubjectId);
                if (classSubject == null)
                {
                    var errorSubject=Program.SubjectList.FirstOrDefault(x => x.Id == item.SubjectId);
                    var errorSubjectName= errorSubject!=null? language=="FR"?errorSubject.FrenchName:errorSubject.EnglishName : string.Empty;
                    string errorMessage = $"La matière {errorSubjectName}  n 'est pas associée à la classe {classOfRoom.Name} : {AppUtilities.GetCurrentMethodName()}";
                    AppUtilities.AddLog(errorMessage);
                    throw new Exception(errorMessage);
                }
                var subject = classSubject.Subject;
                var subjectGroup = classSubject.Group;
                //get rating
                var note20 = item.NotedOn == 20 ? item.Note : GetNote20(item.Note, item.NotedOn);
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note20 && x.MaxNote >= note20);
                var rating = string.Empty;
                var noteWithMax = $"{item.Note}/{item.NotedOn}";
                var noteAsString = item.Note.ToString();
                if (systemRating != null)
                {

                    rating = language== "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                evaluationNoteList.Add(new(item.Id, student, subject, subjectGroup, item.Note, noteAsString, noteWithMax, item.NoteCoef, item.NotedOn, rating, item.Position));
            }
            return evaluationNoteList;
        }
        // Récupération des notes du trimestre
        public async Task<List<TermRecord>> GetTermNoteListByRoom(int roomId, string termCode, int schoolYearId, int bookId)
        {
            var evaluationCodes = GetEvaluationCodeOfTerm(termCode);
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var class_of_room = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var class_group = Program.SchoolGroupList.FirstOrDefault(x => x.Id == class_of_room.GroupId);
            var term_note_list = new List<TermRecord>();
            var eval01 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval02 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval03 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            // extraction des données des évaluations du trimestre
            var eval01_notes_task = GetEvaluationNoteListByRoom(roomId, eval01 != null ? eval01.Id : 100, schoolYearId, bookId);
            var eval02_notes_task = GetEvaluationNoteListByRoom(roomId, eval02 != null ? eval02.Id : 100, schoolYearId, bookId);
            var eval03_notes_task = GetEvaluationNoteListByRoom(roomId, eval03 != null ? eval03.Id : 100, schoolYearId, bookId);

            var eval01_notes = await eval01_notes_task;
            var eval02_notes = await eval02_notes_task;
            var eval03_notes = await eval03_notes_task;
            List<EvaluationRecord> term_evaluation_notes = new();
            term_evaluation_notes.AddRange(eval01_notes);
            term_evaluation_notes.AddRange(eval01_notes);
            term_evaluation_notes.AddRange(eval01_notes);

            var students = term_evaluation_notes.Select(x => x.Student).Distinct();
            var subjects = term_evaluation_notes.Select(x => x.Subject).Distinct();
            var subjects_elements = term_evaluation_notes.Select(x => (x.Subject, x.NotedOn, x.NoteCoef, x.SubjectGroup));
            List<StudentNote> students_notes = new();
            var eval_note_list = new List<EvaluationRecord>();
            // get note by subject and by student
            foreach (var subject in subjects)
            {
                var notes_to_ordered = new List<StudentNote>();
                int note_id = 0;
                foreach (var student in students)
                {
                    var eval01_note = eval01_notes.FirstOrDefault(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var eval02_note = eval02_notes.FirstOrDefault(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var eval03_note = eval03_notes.FirstOrDefault(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var final_note = GetFinalNote(eval01_note, eval02_note, eval03_note);
                    if (final_note != null){
                        eval_note_list.Add(final_note);
                        notes_to_ordered.Add(
                            new StudentNote()
                            {
                                Id = note_id++,
                                Subject = subject,
                                Note = AppUtilities.GetTruncateOrRoundingValue(final_note.Note, class_group),
                                NoteCoef = final_note.NoteCoef,
                                NotedOn = final_note.NotedOn,
                                StudentId = student.Id,
                                Student = student,
                                SubjectId = subject.Id,
                                BookId = bookId,
                            });
                    }
                }
                // on récupère la liste ordonée
                var notes_ordered = GenerateOrderedWithPosition(notes_to_ordered, GetLanguageGroup(class_group, bookId));
                // add Term Record
                foreach (var note in notes_ordered)
                {
                    var eval01_note = eval01_notes.FirstOrDefault(x => x.Student.Id == note.Student.Id && x.Subject.Id == subject.Id);
                    var eval02_note = eval02_notes.FirstOrDefault(x => x.Student.Id == note.Student.Id && x.Subject.Id == subject.Id);
                    var eval03_note = eval03_notes.FirstOrDefault(x => x.Student.Id == note.Student.Id && x.Subject.Id == subject.Id);
                    //get rating
                    var note20 = note.NotedOn == 20 ? note.Note : GetNote20(note.Note, note.NotedOn);
                    var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note20 && x.MaxNote >= note20);
                    term_note_list.Add(
                    new TermRecord(
                        note.Id,
                        note.Student,
                        note.Subject,
                        subjects_elements.FirstOrDefault(x => x.Subject.Id == subject.Id).SubjectGroup,
                        eval01_note != null ? eval01_note.Note : 0,
                        eval01_note != null ? eval01_note.Note.ToString() : string.Empty,
                        eval01_note != null ? eval01_note.NoteWithMax : string.Empty,
                        eval02_note != null ? eval02_note.Note : 0,
                        eval02_note != null ? eval02_note.Note.ToString() : string.Empty,
                        eval02_note != null ? eval02_note.NoteWithMax : string.Empty,
                        eval03_note != null ? eval03_note.Note : 0,
                        eval03_note != null ? eval03_note.Note.ToString() : string.Empty,
                        eval03_note != null ? eval03_note.NoteWithMax : string.Empty,
                        note.Note,
                        note.Note.ToString(),
                        $"{note.Note}/{note.NotedOn}",
                        note.NoteCoef,
                        note.NotedOn,
                        GetLanguageGroup(class_group, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName,
                        note.Position
                            )
                        );
                }
            }

            return term_note_list;
        }

        // Récupère des codes des évaluations d'un trimètre
        public static Dictionary<string, string> GetEvaluationCodeOfTerm(string termCode)
        {
            Dictionary<string, string> terms = new();
            switch (termCode)
            {
                case "TERM01":
                    terms.Add("FirstMonth", "EVAL01");
                    terms.Add("SecondMonth", "EVAL02");
                    terms.Add("ThirdMonth", "EVAL03");
                    break;
                case "TERM02":
                    terms.Add("FirstMonth", "EVAL04");
                    terms.Add("SecondMonth", "EVAL05");
                    terms.Add("ThirdMonth", "EVAL06");
                    break;
                case "TERM03":
                    terms.Add("FirstMonth", "EVAL07");
                    terms.Add("SecondMonth", "EVAL08");
                    terms.Add("ThirdMonth", "EVAL09");
                    break;
            }
            return terms;
        }

        //get term average
        public async Task<List<AverageRecord>> GetTermAverageListByRoom(int roomId, string termCode, int schoolYearId, int bookId)
        {
            var evaluationCodes = GetEvaluationCodeOfTerm(termCode);
            var averageList = new List<AverageRecord>();
            var allEvalList = new List<AverageRecord>();
            var eval1 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval2 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval3 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            var eval1AverageList = await GetEvaluationAverageListByRoom(roomId, eval1 != null ? eval1.Id : 100, schoolYearId, bookId);
            var eval2AverageList = await GetEvaluationAverageListByRoom(roomId, eval2 != null ? eval2.Id : 100, schoolYearId, bookId);
            var eval3AverageList = await GetEvaluationAverageListByRoom(roomId, eval3 != null ? eval3.Id : 100, schoolYearId, bookId);
            allEvalList.AddRange(eval1AverageList);
            allEvalList.AddRange(eval2AverageList);
            allEvalList.AddRange(eval3AverageList);
            var students = allEvalList.Select(x => x.Student).Distinct();
            var notesToOrder = new List<StudentNote>();
            foreach (var student in students)
            {
                var eval1Note = eval1AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval2Note = eval2AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval3Note = eval3AverageList.FirstOrDefault(x => x.Student.Id == student.Id);
                double average = ComputeFinalAverage(eval1Note, eval2Note, eval3Note);
                notesToOrder.Add(new()
                {
                    Id = student.Id,
                    Note = average,
                    NotedOn = 20,
                    StudentId = student.Id,
                    Student = student,
                });
            }
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(classGroup, bookId));
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, classGroup);
                if (systemRating != null)
                {
                    rating = GetLanguageGroup(classGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note, item.NotedOn, rating, item.Position));
            }
            return averageList;
        }

        // get annual average
        public async Task<List<AverageRecord>> GetAnnualAverageListByRoom(int roomId, int schoolYearId, int bookId)
        {
            List<AverageRecord> averageList = new();
            var getFirstTermAverages = GetTermAverageListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermAverages = GetTermAverageListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermAverages = GetTermAverageListByRoom(roomId, "TERM03", schoolYearId, bookId);

            var firstTermAverages = await getFirstTermAverages;
            var secondTermAverages = await getSecondTermAverages;
            var thirdTermAverages = await getThirdTermAverages;

            List<Student> students = new();
            students.AddRange(firstTermAverages.Select(x => x.Student));
            students.AddRange(secondTermAverages.Select(x => x.Student));
            students.AddRange(thirdTermAverages.Select(x => x.Student));
            var composedStudents = students.DistinctBy(x => x.Id);

            var notesToOrder = new List<StudentNote>();
            foreach (var student in composedStudents)
            {
                var noteTerm1 = firstTermAverages.FirstOrDefault(x => x.Student.Id == student.Id);
                var noteTerm2 = secondTermAverages.FirstOrDefault(x => x.Student.Id == student.Id);
                var noteTerm3 = thirdTermAverages.FirstOrDefault(x => x.Student.Id == student.Id);
                double average = ComputeFinalAverage(noteTerm1, noteTerm2, noteTerm3);
                notesToOrder.Add(new()
                {
                    Id = student.Id,
                    Note = average,
                    NotedOn = 20,
                    StudentId = student.Id,
                    Student = student,
                });
            }

            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            //get ordored average with position
            var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(classGroup, bookId));
            foreach (var item in orderedAverageList)
            {
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                //truncate or around note
                var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, classGroup);
                if (systemRating != null)
                {
                    rating = GetLanguageGroup(classGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                averageList.Add(new(item.Student, note, item.NotedOn, rating, item.Position));
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

        //extraction de la langue associée aux documents du groupe de classe
        public static string GetLanguageGroup(SchoolGroup selectedGroup, int bookId)
        {
            if (selectedGroup.DocumentLanguageId == 1 || selectedGroup.DocumentLanguageId == 2 && bookId == 1)
            {
                return "EN";
            }
            return "FR";
        }

        // retourne la note sur 20. ceci est nécessaire pour des matières dont la note max est >20
        public static double GetNote20(double note, double notedOn)
        {
            double coef = 0;
            if (notedOn != 0) coef = 20 / notedOn;
            return Math.Abs(note) * coef;
        }
        // get final note
        private double ComputeFinalNote(EvaluationRecord firstNote, EvaluationRecord secondNote, EvaluationRecord thirdNote)
        {
            double finalNote = 0;
            if (firstNote != null)
            {
                if (secondNote != null)
                {
                    if (thirdNote != null)
                    {
                        finalNote = (firstNote.Note + secondNote.Note + thirdNote.Note) / 3;
                    }
                    else
                    {
                        finalNote = (firstNote.Note + secondNote.Note) / 2;
                    }
                }
                else
                {
                    if (thirdNote != null)
                    {
                        finalNote = (firstNote.Note + thirdNote.Note) / 2;
                    }
                    else
                    {
                        finalNote = firstNote.Note;
                    }
                }
            }
            else
            {
                if (secondNote != null)
                {
                    if (thirdNote != null)
                    {
                        finalNote = (secondNote.Note + thirdNote.Note) / 2;
                    }
                    else
                    {
                        finalNote = secondNote.Note;
                    }
                }
                else
                {
                    if (thirdNote != null)
                    {
                        finalNote = thirdNote.Note;
                    }
                }
            }
            return finalNote;
        }
        public static double ComputeFinalAverage(AverageRecord firstAverage, AverageRecord secondAverage, AverageRecord thirdAverage)
        {
            double finalAverage = 0;
            if (firstAverage != null)
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.Average + secondAverage.Average + thirdAverage.Average) / 3;
                    }
                    else
                    {
                        finalAverage = (firstAverage.Average + secondAverage.Average) / 2;
                    }
                }
                else
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.Average + thirdAverage.Average) / 2;
                    }
                    else
                    {
                        finalAverage = firstAverage.Average;
                    }
                }
            }
            else
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (secondAverage.Average + thirdAverage.Average) / 2;
                    }
                    else
                    {
                        finalAverage = secondAverage.Average;
                    }
                }
                else
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = thirdAverage.Average;
                    }
                }
            }
            return finalAverage;
        }

        public static  double ComputeFinalAverage(TermRecord firstAverage, TermRecord secondAverage, TermRecord thirdAverage)
        {
            double finalAverage = 0;
            if (firstAverage != null)
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.FinalNote + secondAverage.FinalNote + thirdAverage.FinalNote) / 3;
                    }
                    else
                    {
                        finalAverage = (firstAverage.FinalNote + secondAverage.FinalNote) / 2;
                    }
                }
                else
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.FinalNote + thirdAverage.FinalNote) / 2;
                    }
                    else
                    {
                        finalAverage = firstAverage.FinalNote;
                    }
                }
            }
            else
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (secondAverage.FinalNote + thirdAverage.FinalNote) / 2;
                    }
                    else
                    {
                        finalAverage = secondAverage.FinalNote;
                    }
                }
                else
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = thirdAverage.FinalNote;
                    }
                }
            }
            return finalAverage;
        }
        public static double GetNotedOn(TermRecord firstAverage, TermRecord secondAverage, TermRecord thirdAverage)
        {
            if (firstAverage != null) return firstAverage.NotedOn;
            if (secondAverage != null) return secondAverage.NotedOn;
            if (thirdAverage != null) return thirdAverage.NotedOn;
            return 0;

        }
        public static double GetNoteCoef(TermRecord firstAverage, TermRecord secondAverage, TermRecord thirdAverage)
        {
            if (firstAverage != null) return firstAverage.NoteCoef;
            if (secondAverage != null) return secondAverage.NoteCoef;
            if (thirdAverage != null) return thirdAverage.NoteCoef;
            return 0;

        }
        private EvaluationRecord GetFinalNote(EvaluationRecord firstNote, EvaluationRecord secondNote, EvaluationRecord thirdNote)
        {

            double finalNote;
            if (firstNote != null)
            {
                if (secondNote != null)
                {
                    if (thirdNote != null)
                    {
                        finalNote = (firstNote.Note + secondNote.Note + thirdNote.Note) / 3;
                        return new EvaluationRecord(
                            firstNote.Id,
                            firstNote.Student,
                            firstNote.Subject,
                            firstNote.SubjectGroup, finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{firstNote.NotedOn}",
                            firstNote.NoteCoef,
                            firstNote.NotedOn,
                            firstNote.Rating,
                            firstNote.Position
                            );
                    }
                    else
                    {
                        finalNote = (firstNote.Note + secondNote.Note) / 2;
                        return new EvaluationRecord(
                            firstNote.Id,
                            firstNote.Student,
                            firstNote.Subject,
                            firstNote.SubjectGroup, finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{firstNote.NotedOn}",
                            firstNote.NoteCoef,
                            firstNote.NotedOn,
                            firstNote.Rating,
                            firstNote.Position
                            );
                    }
                }
                else
                {
                    if (thirdNote != null)
                    {
                        finalNote = (firstNote.Note + thirdNote.Note) / 2;
                        return new EvaluationRecord(
                            firstNote.Id,
                            firstNote.Student,
                            firstNote.Subject,
                            firstNote.SubjectGroup, finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{firstNote.NotedOn}",
                            firstNote.NoteCoef,
                            firstNote.NotedOn,
                            firstNote.Rating,
                            firstNote.Position
                            );
                    }
                    else
                    {
                        finalNote = firstNote.Note;
                        return new EvaluationRecord(
                            firstNote.Id,
                            firstNote.Student,
                            firstNote.Subject,
                            firstNote.SubjectGroup, finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{firstNote.NotedOn}",
                            firstNote.NoteCoef,
                            firstNote.NotedOn,
                            firstNote.Rating,
                            firstNote.Position
                            );
                    }
                }
            }
            else
            {
                if (secondNote != null)
                {
                    if (thirdNote != null)
                    {
                        finalNote = (secondNote.Note + thirdNote.Note) / 2;
                        return new EvaluationRecord(
                            secondNote.Id,
                            secondNote.Student,
                            secondNote.Subject,
                            secondNote.SubjectGroup, finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{secondNote.NotedOn}",
                            secondNote.NoteCoef,
                            secondNote.NotedOn,
                            secondNote.Rating,
                            secondNote.Position
                            );
                    }
                    else
                    {
                        return secondNote;
                    }
                }
                else
                {
                    return thirdNote;
                }
            }
        }
        private AverageRecord GetFinalAverage(AverageRecord firstAverage, AverageRecord secondAverage, AverageRecord thirdAverage)
        {

            double finalAverage;
            if (firstAverage != null)
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.Average + secondAverage.Average + thirdAverage.Average) / 3;
                        return new AverageRecord(
                            firstAverage.Student,
                            finalAverage,
                            firstAverage.TotalMark,
                            firstAverage.Rating,
                            firstAverage.Position
                            );
                    }
                    else
                    {
                        finalAverage = (firstAverage.Average + secondAverage.Average) / 2;
                        return new AverageRecord(
                           firstAverage.Student,
                           finalAverage,
                           firstAverage.TotalMark,
                           firstAverage.Rating,
                           firstAverage.Position
                           );
                    }
                }
                else
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (firstAverage.Average + thirdAverage.Average) / 2;
                        return new AverageRecord(
                           firstAverage.Student,
                           finalAverage,
                           firstAverage.TotalMark,
                           firstAverage.Rating,
                           firstAverage.Position
                           );
                    }
                    else
                    {
                        finalAverage = firstAverage.Average;
                        return new AverageRecord(
                           firstAverage.Student,
                           finalAverage,
                           firstAverage.TotalMark,
                           firstAverage.Rating,
                           firstAverage.Position
                           );
                    }
                }
            }
            else
            {
                if (secondAverage != null)
                {
                    if (thirdAverage != null)
                    {
                        finalAverage = (secondAverage.Average + thirdAverage.Average) / 2;
                        return new AverageRecord(
                            secondAverage.Student,
                            finalAverage,
                            secondAverage.TotalMark,
                            secondAverage.Rating,
                            secondAverage.Position
                            );
                    }
                    else
                    {
                        return secondAverage;
                    }
                }
                else
                {
                    return thirdAverage;
                }
            }
        }

        public async Task<List<DisciplineItemRecord>> GetDisciplineItemsByClass(int classId, int schoolYearId)
        {
            List<DisciplineItemRecord> disciplineItems = new();
            var items = await disciplineService.GetDisciplineListByClass(classId, schoolYearId);
            foreach (var item in items)
            {
                disciplineItems.Add(item.AsDisciplineRecord());
            }
            return disciplineItems;
        }

        public async Task<List<DisciplineItemRecord>> GetDisciplineItemsByRoom(int roomId, int schoolYearId)
        {
            List<DisciplineItemRecord> disciplineItems = new();
            var items = await disciplineService.GetDisciplineListByRoom(roomId, schoolYearId);
            foreach (var item in items)
            {
                disciplineItems.Add(item.AsDisciplineRecord());
            }
            return disciplineItems;
        }

        public async Task<List<DisciplineItemRecord>> GetDisciplineItemsBySchoolYear(int schoolYearId)
        {
            List<DisciplineItemRecord> disciplineItems = new();
            var items = await disciplineService.GetDisciplineListBySchoolYear(schoolYearId);
            foreach (var item in items)
            {
                disciplineItems.Add(item.AsDisciplineRecord());
            }
            return disciplineItems;
        }

        public async Task<List<RecapNoteItem>> GetRecapNotesByRoom(int roomId, int schoolYearId, int bookId)
        {
            List<RecapNoteItem> recapNotes = new();
            var room = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var language = GetLanguageGroup(classGroup, bookId);

            // extraction des moyennes annuelles
            var getAnnualAveragesTask = GetAnnualAverageListByRoom(roomId, schoolYearId, bookId);

            // extraction des moyennes trimestrielles
            var getFirstTermAverages = GetTermAverageListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermAverages = GetTermAverageListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermAverages = GetTermAverageListByRoom(roomId, "TERM03", schoolYearId, bookId);

            // Extraction des notes par trimestre
            var getTerm1NotesTask = GetTermNoteListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getTerm2NotesTask = GetTermNoteListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getTerm3NotesTask = GetTermNoteListByRoom(roomId, "TERM03", schoolYearId, bookId);

            var term1Notes = await getTerm1NotesTask;
            var term2Notes = await getTerm2NotesTask;
            var term3Notes = await getTerm3NotesTask;

            // Extraction de la liste des élèves
            List<Student> students = new();
            students.AddRange(term1Notes.Select(x => x.Student));
            students.AddRange(term2Notes.Select(x => x.Student));
            students.AddRange(term3Notes.Select(x => x.Student));
            var composedStudents = students.DistinctBy(x => x.Id);

            // Extraction de la liste des matières
            List<Subject> subjects = new();
            subjects.AddRange(term1Notes.Select(x => x.Subject));
            subjects.AddRange(term2Notes.Select(x => x.Subject));
            subjects.AddRange(term3Notes.Select(x => x.Subject));
            var composedSubjects = subjects.DistinctBy(x => x.Id);

            foreach (var subject in composedSubjects)
            {
                List<StudentNote> notesToOrder = new();
                List<TermRecord> termRecords = new();
                foreach (var student in composedStudents)
                {
                    var term1Note = term1Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term2Note = term2Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term3Note = term3Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    // get final note
                    var finalNote = ComputeFinalAverage(term1Note, term2Note, term3Note);
                    // get notedOn 
                    var notedOn= GetNotedOn(term1Note, term2Note, term3Note);
                    // get noteCoef 
                    var noteCoef = GetNoteCoef(term1Note, term2Note, term3Note);
                    termRecords.Add(
                        new(
                            0,
                            student,
                            subject,
                            null,
                            term1Note != null ? term1Note.FinalNote : 0,
                            term1Note != null ? term1Note.FinalNote.ToString() : string.Empty,
                            string.Empty,
                            term2Note != null ? term2Note.FinalNote : 0,
                            term2Note != null ? term2Note.FinalNote.ToString() : string.Empty,
                            string.Empty,
                            term3Note != null ? term3Note.FinalNote : 0,
                            term3Note != null ? term3Note.FinalNote.ToString() : string.Empty,
                            string.Empty,
                            finalNote,
                            finalNote.ToString(),
                            string.Empty,
                            noteCoef,
                            notedOn,
                            string.Empty,
                            string.Empty
                            )
                        );
                    notesToOrder.Add(
                        new StudentNote()
                        {
                            StudentId = student.Id,
                            SubjectId = subject.Id,
                            Student = student,
                            Subject = subject,
                            Note = finalNote,
                            NotedOn = 20,
                        }
                        );
                }
                var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(classGroup, bookId));
                foreach (var item in orderedAverageList)
                {

                    //truncate or around note
                    var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, classGroup);
                    //get rating
                    var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note && x.MaxNote >= note);
                    var rating = string.Empty;
                    if (systemRating != null)
                    {
                        rating = GetLanguageGroup(classGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                    }

                    var termNote = termRecords.Find(x => x.Student.Id == item.Student.Id);

                    recapNotes.Add(
                        new(
                            item.Student.IdNumber,
                            item.Student.FullName,
                            room.Name,
                            language == "FR" ? item.Subject.FrenchName : item.Subject.EnglishName,
                            termNote != null ? termNote.FirstNote : 0,
                            termNote != null ? $"{termNote.FirstNote}/ {termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.SecondNote : 0,
                            termNote != null ? $"{termNote.SecondNote}/{termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.ThirdNote : 0,
                            termNote != null ? $"{termNote.ThirdNote}/{termNote.NotedOn}" : string.Empty,
                            note,
                            $"{note}/20",
                            rating,
                            item.Position
                            )
                        );
                }
            }

            // Ajout des moyennes trimestrielle
            var firstTermAverages = await getFirstTermAverages;
            var secondTermAverages = await getSecondTermAverages;
            var thirdTermAverages = await getThirdTermAverages;
            var annualAverages = await getAnnualAveragesTask;
            List<AverageRecord> averageRecords = new();
            foreach (var student in composedStudents)
            {
                var term1Average = firstTermAverages.Find(x => x.Student.Id == student.Id);
                var term2Average = secondTermAverages.Find(x => x.Student.Id == student.Id);
                var term3Average = thirdTermAverages.Find(x => x.Student.Id == student.Id);
                var annualAverage = annualAverages.Find(x => x.Student.Id == student.Id);
                // get final note
                var finalNote = ComputeFinalAverage(term1Average, term2Average, term3Average);
                recapNotes.Add(
                  new(
                      student.IdNumber,
                      student.FullName,
                      room.Name,
                      language == "FR" ? "Moyenne" : "Average",
                      term1Average != null ? term1Average.Average : 0,
                      term1Average != null ? $"{term1Average.Average}/20" : string.Empty,
                      term2Average != null ? term2Average.Average : 0,
                      term2Average != null ? $"{term2Average.Average}/20" : string.Empty,
                      term3Average != null ? term3Average.Average : 0,
                      term3Average != null ? $"{term3Average.Average}/20" : string.Empty,
                      annualAverage != null ? annualAverage.Average : 0,
                      annualAverage != null ? $"{annualAverage.Average}/20" : string.Empty,
                      annualAverage != null ? annualAverage.Rating : string.Empty,
                      annualAverage != null ? annualAverage.Position: string.Empty
                      )
                  );

            }
            return recapNotes;

        }

        public async Task<List<RecapNoteItem>> GetRecapNotesByClass(int classId, int schoolYearId, int bookId)
        {
           // var watch = System.Diagnostics.Stopwatch.StartNew();
            List<RecapNoteItem> recapNotes = new();
            List<TermRecord> termNotes = new();
            List<TermRecord> term01Notes = new();
            List<TermRecord> term02Notes = new();
            List<TermRecord> term03Notes = new();
            List<AverageRecord> termAverages = new();
            List<AverageRecord> term01Averages = new();
            List<AverageRecord> term02Averages = new();
            List<AverageRecord> term03Averages = new();
            List<AverageRecord> annualAverages = new();
            IEnumerable<Student> composedStudents;
            IEnumerable<Subject> composedSubjects;
            // Récupération de la liste des salles de classe de l'identifiant de la classe
            var classrooms = Program.SchoolRoomList.Where(c => c.ClassId == classId).ToList();
            var selectedClass= Program.SchoolClassList.FirstOrDefault(x => x.Id == classId);
            var selectedGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            var language = GetLanguageGroup(selectedGroup, bookId);

            // Création d'une liste de taches à exécuter pour l'extraction des données
            Dictionary<int, Task<List<AverageRecord>>> annualAverageTasks = new();
            Dictionary<(int,string), Task<List<AverageRecord>>> term01AverageTasks = new();
            Dictionary<(int, string), Task<List<AverageRecord>>> term02AverageTasks = new();
            Dictionary<(int, string), Task<List<AverageRecord>>> term03AverageTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term01NoteTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term02NoteTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term03NoteTasks = new();
            foreach (var room in classrooms) {
                annualAverageTasks.Add(room.Id, GetAnnualAverageListByRoom(room.Id, schoolYearId, bookId));

                term01AverageTasks.Add((room.Id, "TERM01"), GetTermAverageListByRoom(room.Id, "TERM01", schoolYearId, bookId));
                term02AverageTasks.Add((room.Id, "TERM02"), GetTermAverageListByRoom(room.Id, "TERM02", schoolYearId, bookId));
                term03AverageTasks.Add((room.Id, "TERM03"), GetTermAverageListByRoom(room.Id, "TERM03", schoolYearId, bookId));

                term01NoteTasks.Add((room.Id, "TERM01"), GetTermNoteListByRoom(room.Id, "TERM01", schoolYearId, bookId));
                term02NoteTasks.Add((room.Id, "TERM02"), GetTermNoteListByRoom(room.Id, "TERM02", schoolYearId, bookId));
                term03NoteTasks.Add((room.Id, "TERM03"), GetTermNoteListByRoom(room.Id, "TERM03", schoolYearId, bookId));
            }

            // Extraction des moyennes 
            foreach (var room in classrooms)
            {
                if (term01NoteTasks.TryGetValue((room.Id, "TERM01"), out Task<List<TermRecord>> term01NoteTask))
                {
                    term01Notes.AddRange(await term01NoteTask);
                    termNotes.AddRange(term01Notes);
                }
                if (term02NoteTasks.TryGetValue((room.Id, "TERM02"), out Task<List<TermRecord>> term02NoteTask))
                {
                    term02Notes.AddRange(await term02NoteTask);
                    termNotes.AddRange(term02Notes);
                }
                if (term03NoteTasks.TryGetValue((room.Id, "TERM03"), out Task<List<TermRecord>> term03NoteTask))
                {
                    term03Notes.AddRange(await term03NoteTask);
                    termNotes.AddRange(term03Notes);
                }
            }

            // Extraction de la liste des élèves
            composedStudents = termNotes.Select(x => x.Student).DistinctBy(x => x.Id);
            // Extraction de la liste des matières
            composedSubjects= termNotes.Select(x => x.Subject).DistinctBy(x => x.Id);

            // Calcul des notes
            foreach (var subject in composedSubjects)
            {
                List<StudentNote> notesToOrder = new();
                List<TermRecord> termRecords = new();
                foreach (var student in composedStudents)
                {
                    var term1Note = term01Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term2Note = term02Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term3Note = term03Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    // get final note
                    if (term1Note != null || term2Note != null || term3Note != null)
                    {
                        var finalNote = ComputeFinalAverage(term1Note, term2Note, term3Note);
                        // get notedOn 
                        var notedOn = GetNotedOn(term1Note, term2Note, term3Note);
                        // get noteCoef 
                        var noteCoef = GetNoteCoef(term1Note, term2Note, term3Note);
                        termRecords.Add(
                            new(
                                0,
                                student,
                                subject,
                                null,
                                term1Note != null ? term1Note.FinalNote : 0,
                                term1Note != null ? term1Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                term2Note != null ? term2Note.FinalNote : 0,
                                term2Note != null ? term2Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                term3Note != null ? term3Note.FinalNote : 0,
                                term3Note != null ? term3Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                finalNote,
                                finalNote.ToString(),
                                string.Empty,
                                noteCoef,
                                notedOn,
                                string.Empty,
                                string.Empty
                                )
                            );
                        notesToOrder.Add(
                            new StudentNote()
                            {
                                StudentId = student.Id,
                                SubjectId = subject.Id,
                                Student = student,
                                Subject = subject,
                                Note = finalNote,
                                NotedOn = 20,
                            }
                            );
                    }
                }
                var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(selectedGroup, bookId));
                foreach (var item in orderedAverageList)
                {

                    //truncate or around note
                    var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, selectedGroup);
                    //get rating
                    var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note && x.MaxNote >= note);
                    var rating = string.Empty;
                    if (systemRating != null)
                    {
                        rating = GetLanguageGroup(selectedGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                    }

                    var termNote = termRecords.Find(x => x.Student.Id == item.Student.Id);
                    var roomSutdent = Program.StudentRoomList.FirstOrDefault(s => s.StudentId == item.Student.Id && s.SchoolYearId == schoolYearId);
                    recapNotes.Add(
                        new(
                            item.Student.IdNumber,
                            item.Student.FullName,
                            roomSutdent !=null? roomSutdent.Room.Name:string.Empty,
                            language == "FR" ? item.Subject.FrenchName : item.Subject.EnglishName,
                            termNote != null ? termNote.FirstNote : 0,
                            termNote != null ? $"{termNote.FirstNote}/ {termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.SecondNote : 0,
                            termNote != null ? $"{termNote.SecondNote}/{termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.ThirdNote : 0,
                            termNote != null ? $"{termNote.ThirdNote}/{termNote.NotedOn}" : string.Empty,
                            note,
                            $"{note}/20",
                            rating,
                            item.Position
                            )
                        );
                }
            }

            // Extraction des moyennes trimestrielles
            foreach (var room in classrooms)
            {

                if (term01AverageTasks.TryGetValue((room.Id, "TERM01"), out Task<List<AverageRecord>> term01AverageTask))
                {
                    term01Averages.AddRange(await term01AverageTask);
                    termAverages.AddRange(term01Averages);
                }
                if (term02AverageTasks.TryGetValue((room.Id, "TERM02"), out Task<List<AverageRecord>> term02AverageTask))
                {
                    term02Averages.AddRange(await term02AverageTask);
                    termAverages.AddRange(term02Averages);
                }
                if (term03AverageTasks.TryGetValue((room.Id, "TERM03"), out Task<List<AverageRecord>> term03AverageTask))
                {
                    term03Averages.AddRange(await term03AverageTask);
                    termAverages.AddRange(term03Averages);
                }

                if(annualAverageTasks.TryGetValue(room.Id,out var annualAverageTask))
                {
                    annualAverages.AddRange(await annualAverageTask);
                }
            }

            // Recherche des rang annuels par rapport la moyenne annuel
            List<StudentNote> annualNotesToOrder = new();
            // Création d'une liste de moyennes annuelles pour classer par ordre 
            foreach (var student in composedStudents)
            {
                var annualAverage = annualAverages.Find(x => x.Student.Id == student.Id);
                annualNotesToOrder.Add(
                       new StudentNote()
                       {
                           StudentId = student.Id,
                           Student = student,
                           Note = annualAverage != null ? annualAverage.Average : 0,
                           NotedOn = 20,
                       }
                       );            
            }
            var orderedAnnualAverageList = GenerateOrderedWithPosition(annualNotesToOrder, GetLanguageGroup(selectedGroup, bookId));

            foreach(var item in orderedAnnualAverageList)
            {

                //truncate or around note
                var annualAverage = AppUtilities.GetTruncateOrRoundingValue(item.Note, selectedGroup);
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                if (systemRating != null)
                {
                    rating = GetLanguageGroup(selectedGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                var term1Average = term01Averages.Find(x => x.Student.Id == item.Student.Id);
                var term2Average = term02Averages.Find(x => x.Student.Id == item.Student.Id);
                var term3Average = term03Averages.Find(x => x.Student.Id == item.Student.Id);
                var roomSutdent = Program.StudentRoomList.FirstOrDefault(s => s.StudentId == item.Student.Id && s.SchoolYearId == schoolYearId);
                recapNotes.Add(
                  new(
                      item.Student.IdNumber,
                      item.Student.FullName,
                      roomSutdent != null ? roomSutdent.Room.Name : string.Empty,
                      language == "FR" ? "Moyenne" : "Average",
                      term1Average != null ? term1Average.Average : 0,
                      term1Average != null ? $"{term1Average.Average}/20" : string.Empty,
                      term2Average != null ? term2Average.Average : 0,
                      term2Average != null ? $"{term2Average.Average}/20" : string.Empty,
                      term3Average != null ? term3Average.Average : 0,
                      term3Average != null ? $"{term3Average.Average}/20" : string.Empty,
                      annualAverage,
                      $"{annualAverage}/20",
                       rating,
                      item.Position
                      )
                  );

            }

            //watch.Stop();
            //Console.WriteLine($"Le temps de traitement est de {watch.ElapsedMilliseconds}");
            return recapNotes;

        }

        public async Task<List<RecapNoteItem>> GetRecapNotesByGroup(int groupId, int schoolYearId, int bookId)
        {
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            List<RecapNoteItem> recapNotes = new();
            List<TermRecord> termNotes = new();
            List<TermRecord> term01Notes = new();
            List<TermRecord> term02Notes = new();
            List<TermRecord> term03Notes = new();
            List<AverageRecord> termAverages = new();
            List<AverageRecord> term01Averages = new();
            List<AverageRecord> term02Averages = new();
            List<AverageRecord> term03Averages = new();
            List<AverageRecord> annualAverages = new();
            IEnumerable<Student> composedStudents;
            IEnumerable<Subject> composedSubjects;

            // Récupération de la liste des salles de classe de l'identifiant de la classe
            var classIdList=Program.SchoolClassList.Where(c=>c.GroupId == groupId).Select(c=>c.Id);
            var classrooms = Program.SchoolRoomList.Where(c => classIdList.Contains(c.ClassId));
            var selectedGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id ==groupId);
            var language = GetLanguageGroup(selectedGroup, bookId);

            // Création d'une liste de taches à exécuter pour l'extraction des données
            Dictionary<int, Task<List<AverageRecord>>> annualAverageTasks = new();
            Dictionary<(int, string), Task<List<AverageRecord>>> term01AverageTasks = new();
            Dictionary<(int, string), Task<List<AverageRecord>>> term02AverageTasks = new();
            Dictionary<(int, string), Task<List<AverageRecord>>> term03AverageTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term01NoteTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term02NoteTasks = new();
            Dictionary<(int, string), Task<List<TermRecord>>> term03NoteTasks = new();
            foreach (var room in classrooms)
            {
                annualAverageTasks.Add(room.Id, GetAnnualAverageListByRoom(room.Id, schoolYearId, bookId));

                term01AverageTasks.Add((room.Id, "TERM01"), GetTermAverageListByRoom(room.Id, "TERM01", schoolYearId, bookId));
                term02AverageTasks.Add((room.Id, "TERM02"), GetTermAverageListByRoom(room.Id, "TERM02", schoolYearId, bookId));
                term03AverageTasks.Add((room.Id, "TERM03"), GetTermAverageListByRoom(room.Id, "TERM03", schoolYearId, bookId));

                term01NoteTasks.Add((room.Id, "TERM01"), GetTermNoteListByRoom(room.Id, "TERM01", schoolYearId, bookId));
                term02NoteTasks.Add((room.Id, "TERM02"), GetTermNoteListByRoom(room.Id, "TERM02", schoolYearId, bookId));
                term03NoteTasks.Add((room.Id, "TERM03"), GetTermNoteListByRoom(room.Id, "TERM03", schoolYearId, bookId));
            }

            // Extraction des moyennes 
            foreach (var room in classrooms)
            {
                if (term01NoteTasks.TryGetValue((room.Id, "TERM01"), out Task<List<TermRecord>> term01NoteTask))
                {
                    term01Notes.AddRange(await term01NoteTask);
                    termNotes.AddRange(term01Notes);
                }
                if (term02NoteTasks.TryGetValue((room.Id, "TERM02"), out Task<List<TermRecord>> term02NoteTask))
                {
                    term02Notes.AddRange(await term02NoteTask);
                    termNotes.AddRange(term02Notes);
                }
                if (term03NoteTasks.TryGetValue((room.Id, "TERM03"), out Task<List<TermRecord>> term03NoteTask))
                {
                    term03Notes.AddRange(await term03NoteTask);
                    termNotes.AddRange(term03Notes);
                }
            }

            // Extraction de la liste des élèves
            composedStudents = termNotes.Select(x => x.Student).DistinctBy(x => x.Id);
            // Extraction de la liste des matières
            composedSubjects = termNotes.Select(x => x.Subject).DistinctBy(x => x.Id);

            // Calcul des notes
            foreach (var subject in composedSubjects)
            {
                List<StudentNote> notesToOrder = new();
                List<TermRecord> termRecords = new();
                foreach (var student in composedStudents)
                {
                    var term1Note = term01Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term2Note = term02Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    var term3Note = term03Notes.Find(x => x.Student.Id == student.Id && x.Subject.Id == subject.Id);
                    // get final note
                    if (term1Note!=null || term2Note!=null || term3Note != null)
                    {
                        var finalNote = ComputeFinalAverage(term1Note, term2Note, term3Note);
                        // get notedOn 
                        var notedOn = GetNotedOn(term1Note, term2Note, term3Note);
                        // get noteCoef 
                        var noteCoef = GetNoteCoef(term1Note, term2Note, term3Note);
                        termRecords.Add(
                            new(
                                0,
                                student,
                                subject,
                                null,
                                term1Note != null ? term1Note.FinalNote : 0,
                                term1Note != null ? term1Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                term2Note != null ? term2Note.FinalNote : 0,
                                term2Note != null ? term2Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                term3Note != null ? term3Note.FinalNote : 0,
                                term3Note != null ? term3Note.FinalNote.ToString() : string.Empty,
                                string.Empty,
                                finalNote,
                                finalNote.ToString(),
                                string.Empty,
                                noteCoef,
                                notedOn,
                                string.Empty,
                                string.Empty
                                )
                            );
                        notesToOrder.Add(
                            new StudentNote()
                            {
                                StudentId = student.Id,
                                SubjectId = subject.Id,
                                Student = student,
                                Subject = subject,
                                Note = finalNote,
                                NotedOn = 20,
                            }
                            );
                    } 
                }
                var orderedAverageList = GenerateOrderedWithPosition(notesToOrder, GetLanguageGroup(selectedGroup, bookId));
                foreach (var item in orderedAverageList)
                {

                    //truncate or around note
                    var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, selectedGroup);
                    //get rating
                    var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note && x.MaxNote >= note);
                    var rating = string.Empty;
                    if (systemRating != null)
                    {
                        rating = GetLanguageGroup(selectedGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                    }

                    var termNote = termRecords.Find(x => x.Student.Id == item.Student.Id);
                    var roomSutdent = Program.StudentRoomList.FirstOrDefault(s => s.StudentId == item.Student.Id && s.SchoolYearId == schoolYearId);
                    recapNotes.Add(
                        new(
                            item.Student.IdNumber,
                            item.Student.FullName,
                            roomSutdent != null ? roomSutdent.Room.Name : string.Empty,
                            language == "FR" ? item.Subject.FrenchName : item.Subject.EnglishName,
                            termNote != null ? termNote.FirstNote : 0,
                            termNote != null ? $"{termNote.FirstNote}/ {termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.SecondNote : 0,
                            termNote != null ? $"{termNote.SecondNote}/{termNote.NotedOn}" : string.Empty,
                            termNote != null ? termNote.ThirdNote : 0,
                            termNote != null ? $"{termNote.ThirdNote}/{termNote.NotedOn}" : string.Empty,
                            note,
                            $"{note}/20",
                            rating,
                            item.Position
                            )
                        );
                }
            }

            // Extraction des moyennes trimestrielles
            foreach (var room in classrooms)
            {

                if (term01AverageTasks.TryGetValue((room.Id, "TERM01"), out Task<List<AverageRecord>> term01AverageTask))
                {
                    term01Averages.AddRange(await term01AverageTask);
                    termAverages.AddRange(term01Averages);
                }
                if (term02AverageTasks.TryGetValue((room.Id, "TERM02"), out Task<List<AverageRecord>> term02AverageTask))
                {
                    term02Averages.AddRange(await term02AverageTask);
                    termAverages.AddRange(term02Averages);
                }
                if (term03AverageTasks.TryGetValue((room.Id, "TERM03"), out Task<List<AverageRecord>> term03AverageTask))
                {
                    term03Averages.AddRange(await term03AverageTask);
                    termAverages.AddRange(term03Averages);
                }

                if (annualAverageTasks.TryGetValue(room.Id, out var annualAverageTask))
                {
                    annualAverages.AddRange(await annualAverageTask);
                }
            }

            // Recherche des rang annuels par rapport la moyenne annuel
            List<StudentNote> annualNotesToOrder = new();
            // Création d'une liste de moyennes annuelles pour classer par ordre 
            foreach (var student in composedStudents)
            {
                var annualAverage = annualAverages.Find(x => x.Student.Id == student.Id);
                annualNotesToOrder.Add(
                       new StudentNote()
                       {
                           StudentId = student.Id,
                           Student = student,
                           Note = annualAverage != null ? annualAverage.Average : 0,
                           NotedOn = 20,
                       }
                       );
            }
            var orderedAnnualAverageList = GenerateOrderedWithPosition(annualNotesToOrder, GetLanguageGroup(selectedGroup, bookId));

            foreach (var item in orderedAnnualAverageList)
            {

                //truncate or around note
                var annualAverage = AppUtilities.GetTruncateOrRoundingValue(item.Note, selectedGroup);
                //get rating
                var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Moyenne" && x.MinNote <= item.Note && x.MaxNote >= item.Note);
                var rating = string.Empty;
                if (systemRating != null)
                {
                    rating = GetLanguageGroup(selectedGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                var term1Average = term01Averages.Find(x => x.Student.Id == item.Student.Id);
                var term2Average = term02Averages.Find(x => x.Student.Id == item.Student.Id);
                var term3Average = term03Averages.Find(x => x.Student.Id == item.Student.Id);
                var roomSutdent = Program.StudentRoomList.FirstOrDefault(s => s.StudentId == item.Student.Id && s.SchoolYearId == schoolYearId);
                recapNotes.Add(
                  new(
                      item.Student.IdNumber,
                      item.Student.FullName,
                      roomSutdent != null ? roomSutdent.Room.Name : string.Empty,
                      language == "FR" ? "Moyenne" : "Average",
                      term1Average != null ? term1Average.Average : 0,
                      term1Average != null ? $"{term1Average.Average}/20" : string.Empty,
                      term2Average != null ? term2Average.Average : 0,
                      term2Average != null ? $"{term2Average.Average}/20" : string.Empty,
                      term3Average != null ? term3Average.Average : 0,
                      term3Average != null ? $"{term3Average.Average}/20" : string.Empty,
                      annualAverage,
                      $"{annualAverage}/20",
                       rating,
                      item.Position
                      )
                  );

            }

            //watch.Stop();
            //Console.WriteLine($"Le temps de traitement est de {watch.ElapsedMilliseconds}");
            return recapNotes;

        }


        public async Task<DataTable> ImportNotes(string filePath,int roomId,int bookId)
        {
            DataTable dataTable = new();
            var classroom = Program.SchoolRoomList.FirstOrDefault(c => c.Id == roomId);
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var selectedGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            var language = GetLanguageGroup(selectedGroup, bookId);
            dataTable = ExcelToDataTable(filePath,true);
            await Task.Delay(0); 
            return dataTable;
        }


        private static DataTable ExcelToDataTable(string excelFileName, bool useHeader)
        {
            var dataTable= new DataTable();
            using (var workbook = new XLWorkbook(excelFileName))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault();
                var rowCount = worksheet.Rows().Count();
                var columnCount = worksheet.Columns().Count();
                // Si le nombre de lignes est inférieur  à 2 on arrête le processus.
                if (rowCount <2)
                {
                    return new DataTable(); 
                }
                // Si le nombre de colonnes est inférieur  à 3 on arrête le processus.
                if (columnCount < 3)
                {
                    return new DataTable();
                }
                // Create columns
                var headerRow= worksheet.Row(1);
                for (int i = 1; i <= columnCount; i++)
                {
                    var dataColumn= new DataColumn(headerRow.Cell(i).Value.ToString(),typeof(string));
                    dataTable.Columns.Add(dataColumn);
                }
                // Load data row
                for (int i = 2; i <= rowCount; i++)
                {
                    var selectedRow = worksheet.Row(i);
                    var dataRow = new object[columnCount];
                    int k= 0;
                    for (int j = 1; j < columnCount; j++)
                    {
                        dataRow[k] = selectedRow.Cell(j).Value;
                        k++;
                    }
                    dataTable.Rows.Add(dataRow);   
                }
               
            }
                
                return dataTable;
        }

    }
}
