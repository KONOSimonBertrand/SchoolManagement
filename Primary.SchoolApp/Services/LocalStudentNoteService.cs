using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Primary.SchoolApp.DTO.DTOItem;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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

                    rating = GetLanguageGroup(classGroup, bookId) == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                }
                evaluationNoteList.Add(new(item.Id, student, subject, subjectGroup, item.Note, noteAsString, noteWithMax, item.NoteCoef, item.NotedOn, rating, item.Position));
            }
            return evaluationNoteList;
        }
        // Récupération des notes du trimestre
        public async Task<List<TermRecord>> GetTermNoteListByRoom(int roomId, int schoolYearId, int bookId, string termCode)
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
        public async Task<List<AverageRecord>> GetTermAverageListByRoom(int roomId, int schoolYearId, int bookId,string termCode)
        {
            var evaluationCodes = GetEvaluationCodeOfTerm(termCode);
            var averageList = new List<AverageRecord>();
            var allEvalList = new List<AverageRecord>();
            var eval1 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval2 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval3 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            var eval1AverageList = await GetEvaluationAverageListByRoom(roomId, eval1!=null?eval1.Id:100, schoolYearId, bookId);
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
        private double ComputeFinalAverage(AverageRecord firstAverage, AverageRecord secondAverage, AverageRecord thirdAverage)
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

       public async Task<List<DisciplineItemRecord>> GetDisciplineItems(int classId,int schoolYearId)
        {
            List<DisciplineItemRecord> disciplineItems = new();
            var items = await disciplineService.GetDisciplineListByClass(classId, schoolYearId);
            foreach(var item in items)
            {
                disciplineItems.Add(item.AsDisciplineRecord());
            }
            return disciplineItems;
        }

        public async Task<List<DisciplineItemRecord>> GetDisciplineItems(int schoolYearId)
        {
            List<DisciplineItemRecord> disciplineItems = new();
            var items = await disciplineService.GetDisciplineListBySchoolYear(schoolYearId);
            foreach (var item in items)
            {
                disciplineItems.Add(item.AsDisciplineRecord());
            }
            return disciplineItems;
        }
    }
}
