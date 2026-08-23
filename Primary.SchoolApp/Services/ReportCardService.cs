using Primary.SchoolApp.Utilities;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Primary.SchoolApp.DTO.DTOItem;


namespace Primary.SchoolApp.Services
{
    public class ReportCardService
    {
        private readonly LocalStudentNoteService localStudentNoteService;
        private readonly IStudentNoteService studentNoteService;
        private Dictionary<SchoolRoom, List<AverageRecord>> averageStore;
        public ReportCardService(LocalStudentNoteService localStudentNoteService,IStudentNoteService studentNoteService)
        {
            this.localStudentNoteService = localStudentNoteService;
            averageStore = new Dictionary<SchoolRoom, List<AverageRecord>>();
            this.studentNoteService = studentNoteService;
        }
        //bulletin scolaire d'une évaluation d'un élève
        public async Task<EvaluationReportCard> GetEvaluationReportCardByStudentAsync(int studentId, int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            // extraction des moyennes de la classe
            var evaluationAverageTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByRoom(roomId, schoolYearId);
            // Extraction des commentaires
            var getCommentTask = studentNoteService.GetCommentsByClassroomAsync(roomId, evaluationId, bookId, schoolYearId);
            #region Head Report
            // get data of head report
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == studentId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            var teacherName = string.Empty;
            if (teacher != null)
            {
                teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
            }
            var reportTitle = $"BULLETIN {evaluation.FrenchName}";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} SUMMARY MARK";
                language = "EN";
                if (teacher != null)
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }
            var disciplineItems = await getDisciplinesTask;
            var disciplinarySheet = disciplineItems.Where(d => d.Student.Id == studentId && d.Evaluation.Id==evaluationId).ToList();
            // create head of report card
            var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom, teacherName, language, evaluation.Code,disciplinarySheet);
            #endregion
            #region Detail Report

            // extraction des données de l'évaluation
            var data = await localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id);
            //extraction des groupes de matières de la classe de l'élève
            var groupList = classroomSujectList.Where(x => x.BookId == bookId).OrderBy(x => x.Sequence).Select(x => x.Group).DistinctBy(x => x.Id).ToList();
            //ectraction des notes de l'élève
            var studentNoteList = data.Where(x => x.Student.Id == studentId).ToList();
            //ectraction des matères sur lesquelles l'élève a été évalué
            var studentSubjectIdList = studentNoteList.Select(x => x.Subject.Id).Distinct().ToList();
            //extraction de la liste des matières de la classe sur lesquelles l'élève n'a pas été évalué
            var subjectIdNoMarkList = classroomSujectList.Where(x => studentSubjectIdList.Contains(x.SubjectId) == false && x.BookId == bookId).ToList();

            // Création des notes pour des matières sur lesquelles l'élève n'a pas été évalué
            foreach (var item in subjectIdNoMarkList)
            {
                studentNoteList.Add(new(0, student, item.Subject, item.Group, 0, string.Empty, string.Empty, item.Coefficient, item.NotedOn, string.Empty, string.Empty));
            }
            var detailSection = new DetailEvaluationReportCard(studentNoteList, groupList);
            #endregion
            #region Footer Report
            // calcul de la moyenne
            double sumCoef = 0;//somme de coefficients
            double sumNote = 0;// somme de notes
            double sumMaxNote = 0;
            double average = 0;
            if (classGroup.AverageFormula == 0)
            {
                sumNote = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.Note);
                sumMaxNote = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.NotedOn);
                sumCoef = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.NoteCoef);
                //average = sumMaxNote > 0 ? (sumNote * 20) / sumMaxNote : 0;
            }
            else
            {
                foreach (var subjectId in studentSubjectIdList)
                {
                    var evaluationLine = studentNoteList.First(x => x.Subject.Id == subjectId);
                    double note20 = evaluationLine.Note * 20 / evaluationLine.NotedOn;// on ramene la note a 20;
                    var subjectNote = note20 * evaluationLine.NoteCoef;
                    sumMaxNote += evaluationLine.Note * evaluationLine.NoteCoef;
                    sumCoef += evaluationLine.NoteCoef;
                    sumNote += subjectNote;
                }
                //average = sumCoef > 0 ? sumNote / sumCoef : 0;
            }
            // extraction de la moyenne de l'élève
            var evaluationAverage = await evaluationAverageTask;
            average = evaluationAverage.FirstOrDefault(x => x.Student.Id == studentId).Average;
            var position = evaluationAverage.FirstOrDefault(x => x.Student.Id == studentId).Position;
            var highestAverage = evaluationAverage.FirstOrDefault().Average;
            var lowestAverage = evaluationAverage.LastOrDefault().Average;
            var cAverage = evaluationAverage.Sum(x => x.Average) / evaluationAverage.Count;
            double classAverage = AppUtilities.GetTruncateOrRoundingValue(cAverage, classGroup);
            var comments = await getCommentTask;
            var comment = comments.FirstOrDefault(c => c.StudentId == studentId)?.Comment;
            var footerSection = new EvaluationFooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage, comment);
            #endregion
            return new EvaluationReportCard(headReportSection, detailSection, footerSection);
        }
        //bulletin  trimestrielle d'un élève
        public async Task<TermReportCard> GetTermReportCardByStudentAsync(int studentId, int roomId, int termId, int schoolYearId, int bookId)
        {
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByRoom(roomId, schoolYearId);
            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
            var evaluationIds = Program.EvaluationSessionList.Where(e => e.Mother == termId).Select(e => e.Id);
            string termCode = term != null ? term.Code : string.Empty;
            // liste des trimestres antérieurs
            List<string> reminderTerms = new();
            Dictionary<string, Task<List<AverageRecord>>> reminderTermsTask = new();
            Dictionary<string, List<AverageRecord>> reminderTermsTaskResult = new();
            if (termCode == "TERM02")
            {
                reminderTerms.Add("TERM01");
            }
            else
            {
                if (termCode == "TERM03")
                {
                    reminderTerms.Add("TERM01");
                    reminderTerms.Add("TERM02");
                }
            }
            var evaluationCodes = LocalStudentNoteService.GetEvaluationCodeOfTerm(termCode);
            var eval01 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval02 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval03 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            // Extraction des commentaires
            var term_comments_task = studentNoteService.GetCommentsByClassroomAsync(roomId, termId, bookId, schoolYearId);
            // Extraction des notes du trimestre
            var term_notes_task = localStudentNoteService.GetTermNoteListByRoom(roomId, termCode, schoolYearId, bookId);
            var term_averages_task = localStudentNoteService.GetTermAverageListByRoom(roomId, termCode, schoolYearId, bookId);
            foreach (var code in reminderTerms)
            {
                reminderTermsTask.Add(code, localStudentNoteService.GetTermAverageListByRoom(roomId, code, schoolYearId, bookId));
            }
            // extraction des moyennes des évaluations
            var eval01_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval01 != null ? eval01.Id : 100, schoolYearId, bookId);
            var eval02_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval02 != null ? eval02.Id : 100, schoolYearId, bookId);
            var eval03_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval03 != null ? eval03.Id : 100, schoolYearId, bookId);

            var term_notes = await term_notes_task;
            var student_notes = term_notes.Where(x => x.Student.Id == studentId).ToList();
            var subject_groups = student_notes.Select(x => x.SubjectGroup).Distinct().ToList();
            #region Head Report
            // get data of head report
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == studentId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            var teacherName = string.Empty;
            if (teacher != null)
            {
                teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
            }
            var reportTitle = string.Empty;
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                language = "EN";
                if (teacher != null)
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }
            var disciplineItems = await getDisciplinesTask;
            var disciplinarySheet=disciplineItems.Where(d=>d.Student.Id==studentId && evaluationIds.Contains(d.Evaluation.Id)).ToList();   
            // create head of report card
            var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom, teacherName, language, termCode, disciplinarySheet);
            #endregion
            #region Detail Report
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id);
            //ectraction des matères sur lesquelles l'élève a été évalué
            var student_subject_id_list = student_notes.Select(x => x.Subject.Id).Distinct().ToList();
            //extraction de la liste des matières de la classe sur lesquelles l'élève n'a pas été évalué
            var subject_noMark_id_List = classroomSujectList.Where(x => student_subject_id_list.Contains(x.SubjectId) == false && x.BookId == bookId).ToList();
            // Création des notes pour des matières sur lesquelles l'élève n'a pas été évalué
            foreach (var item in subject_noMark_id_List)
            {
                student_notes.Add(
                    new(
                        0,
                        student,
                        item.Subject,
                        item.Group,
                        0,
                        string.Empty,
                        string.Empty,
                        0,
                        string.Empty,
                        string.Empty,
                        0,
                        string.Empty,
                         string.Empty,
                         0,
                        string.Empty,
                         string.Empty,
                        item.Coefficient,
                        item.NotedOn,
                        string.Empty,
                        string.Empty));
            }
            var detailSection = new DetailTermReportCard(student_notes, subject_groups);
            #endregion
            #region Footer Report
            // calcul de la moyenne
            List<ReportItem> footerItems = new();
            double sumCoef = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NoteCoef);
            footerItems.Add(new("SumCoef", sumCoef.ToString()));
            double sumNotedOn = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NotedOn);
            footerItems.Add(new("SumNotedOn", sumNotedOn.ToString()));
            double sumFirstNote = student_notes.Where(x => x.FirstNoteAsString != string.Empty).Sum(x => x.FirstNote);
            footerItems.Add(sumFirstNote != 0 ? new("SumFirstNote", sumFirstNote.ToString()) : new("SumFirstNote", string.Empty));
            double sumSecondNote = student_notes.Where(x => x.SecondNoteAsString != string.Empty).Sum(x => x.SecondNote);
            footerItems.Add(sumSecondNote != 0 ? new("SumSecondNote", sumSecondNote.ToString()) : new("SumSecondNote", string.Empty));
            double sumThirdNote = student_notes.Where(x => x.ThirdNoteAsString != string.Empty).Sum(x => x.ThirdNote);
            footerItems.Add(sumThirdNote != 0 ? new("SumThirdNote", sumThirdNote.ToString()) : new("SumThirdNote", string.Empty));

            double sumFinalNote = Helper.RoundingValue(student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.FinalNote));
            footerItems.Add(sumFinalNote != 0 ? new("SumFinalNote", sumFinalNote.ToString()) : new("SumFinalNote", string.Empty));
            var term_averages = await term_averages_task;
            var eval01_averages = await eval01_averages_task;
            var eval02_averages = await eval02_averages_task;
            var eval03_averages = await eval03_averages_task;
            var eval01_averages_student = eval01_averages.FirstOrDefault(x => x.Student.Id == studentId);
            var eval02_averages_student = eval02_averages.FirstOrDefault(x => x.Student.Id == studentId);
            var eval03_averages_student = eval03_averages.FirstOrDefault(x => x.Student.Id == studentId);
            var term_averages_student = term_averages.FirstOrDefault(x => x.Student.Id == studentId);
            double firstMonthAverage = eval01_averages_student != null ? eval01_averages_student.Average : 0;
            footerItems.Add(firstMonthAverage != 0 ? new("FirstMonthAverage", firstMonthAverage.ToString()) : new("FirstMonthAverage", string.Empty));
            double secondMonthAverage = eval02_averages_student != null ? eval02_averages_student.Average : 0;
            footerItems.Add(secondMonthAverage != 0 ? new("SecondMonthAverage", secondMonthAverage.ToString()) : new("SecondMonthAverage", string.Empty));
            double thirdMonthAverage = eval03_averages_student != null ? eval03_averages_student.Average : 0;
            footerItems.Add(thirdMonthAverage != 0 ? new("ThirdMonthAverage", thirdMonthAverage.ToString()) : new("ThirdMonthAverage", string.Empty));
            double termAverage = term_averages_student != null ? term_averages_student.Average : 0;
            footerItems.Add(termAverage != 0 ? new("TermAverage", termAverage.ToString()) : new("TermAverage", string.Empty));
            string firstMonthPosition = eval01_averages_student != null ? eval01_averages_student.Position : string.Empty;
            footerItems.Add(new("FirstMonthPosition", firstMonthPosition));
            string firstMonthPositionWithStudentCount = eval01_averages_student != null ? firstMonthPosition + '/' + eval01_averages.Count : string.Empty;
            footerItems.Add(new("FirstMonthPositionWithStudentCount", firstMonthPositionWithStudentCount));
            string secondMonthPosition = eval02_averages_student != null ? eval02_averages_student.Position : string.Empty;
            string secondMonthPositionWithStudentCount = eval02_averages_student != null ? secondMonthPosition + '/' + eval02_averages.Count : string.Empty;
            footerItems.Add(new("SecondMonthPositionWithStudentCount", secondMonthPositionWithStudentCount));
            footerItems.Add(new("SecondMonthPosition", secondMonthPosition));
            string thirdMonthPosition = eval03_averages_student != null ? eval03_averages_student.Position : string.Empty;
            footerItems.Add(new("ThirdMonthPosition", thirdMonthPosition));
            string thirdMonthPositionWithStudentCount = eval03_averages_student != null ? thirdMonthPosition + '/' + eval03_averages.Count : string.Empty;
            footerItems.Add(new("ThirdMonthPositionWithStudentCount", thirdMonthPositionWithStudentCount));
            string termPosition = term_averages_student != null ? term_averages_student.Position : string.Empty;
            footerItems.Add(new("TermPosition", termPosition));
            string termPositionWithStudentCount = term_averages_student != null ? termPosition + '/' + term_averages.Count : string.Empty;
            footerItems.Add(new("TermPositionWithStudentCount", termPositionWithStudentCount));
            double firstMonthClassAverage = eval01_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval01_averages.Sum(x => x.Average) / eval01_averages.Count, classGroup) : 0;
            footerItems.Add(new("FirstMonthClassAverage", firstMonthClassAverage.ToString()));
            double secondMonthClassAverage = eval02_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval02_averages.Sum(x => x.Average) / eval02_averages.Count, classGroup) : 0;
            footerItems.Add(new("SecondMonthClassAverage", secondMonthClassAverage.ToString()));
            double thirdMonthClassAverage = eval03_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval03_averages.Sum(x => x.Average) / eval03_averages.Count, classGroup) : 0;
            footerItems.Add(new("ThirdMonthClassAverage", thirdMonthClassAverage.ToString()));
            double termClassAverage = AppUtilities.GetTruncateOrRoundingValue(term_averages.Sum(x => x.Average) / term_averages.Count, classGroup);
            footerItems.Add(new("TermClassAverage", termClassAverage.ToString()));
            double firstMonthHighestAverage = eval01_averages.Select(x => x.Average).OrderByDescending(x => x).First();
            footerItems.Add(new("FirstMonthHighestAverage", firstMonthHighestAverage.ToString()));
            double secondMonthHighestAverage = eval02_averages.Any() ? eval02_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
            footerItems.Add(new("SecondMonthHighestAverage", secondMonthHighestAverage.ToString()));
            double thirdMonthHighestAverage = eval03_averages.Any() ? eval03_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
            footerItems.Add(new("ThirdMonthHighestAverage", thirdMonthHighestAverage.ToString()));
            double termHighestAverage = term_averages.Any() ? term_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
            footerItems.Add(new("TermHighestAverage", termHighestAverage.ToString()));
            double firstMonthLowestAverage = eval01_averages.Any() ? eval01_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
            footerItems.Add(new("FirstMonthLowestAverage", firstMonthLowestAverage.ToString()));
            double secondMonthLowestAverage = eval02_averages.Any() ? eval02_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
            footerItems.Add(new("SecondMonthLowestAverage", secondMonthLowestAverage.ToString()));
            double thirdMonthLowestAverage = eval03_averages.Any() ? eval03_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
            footerItems.Add(new("ThirdMonthLowestAverage", thirdMonthLowestAverage.ToString()));
            double termLowestAverage = term_averages.Any() ? term_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
            footerItems.Add(new("TermLowestAverage", termLowestAverage.ToString()));

            var comments = await term_comments_task;
            var comment = comments.FirstOrDefault(c => c.StudentId == studentId)?.Comment;
            footerItems.Add(new("Comment", comment));
            // extraction des moyennes des trimestres antérieurs
            foreach (var code in reminderTerms)
            {
                if (reminderTermsTask.TryGetValue(code, out Task<List<AverageRecord>> task))
                {
                    var taskResult = await task;
                    reminderTermsTaskResult.Add(code, taskResult);
                }
            }
            if (reminderTermsTaskResult.TryGetValue("TERM01", out List<AverageRecord> term1Averages))
            {
                var term1Average = term1Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                footerItems.Add(new("FirstTermAverage", term1Average != null ? term1Average.Average.ToString() : string.Empty));
            }
            if (reminderTermsTaskResult.TryGetValue("TERM02", out List<AverageRecord> term2Averages))
            {
                var term2Average = term2Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                footerItems.Add(new("SecondTermAverage", term2Average != null ? term2Average.Average.ToString() : string.Empty));
            }
            if (termCode == "TERM03")
            {
                footerItems.Add(new("ThirdTermAverage",termAverage.ToString()));
                var term01 = footerItems.FirstOrDefault(x => x.Name == "FirstTermAverage" && x.Value!=string.Empty);
                var term02 = footerItems.FirstOrDefault(x => x.Name == "SecondTermAverage" && x.Value != string.Empty);
                double annualAverage = 0;
                if (term01 != null)
                {
                    if (term02 != null)
                    {
                        annualAverage = (termAverage + double.Parse(term01.Value) + double.Parse(term02.Value)) / 3;
                    }
                    else
                    {
                        annualAverage = (termAverage + double.Parse(term01.Value)) / 2;
                    }
                }
                else
                {
                    if (term02 != null)
                    {
                        annualAverage = (termAverage + double.Parse(term02.Value)) / 2;
                    }
                }
                footerItems.Add(new("AnnualAverage", AppUtilities.GetTruncateOrRoundingValue(annualAverage,classGroup).ToString()));
            }
            var footerSection = new ReportFooter(footerItems);
            #endregion
            return new TermReportCard(headReportSection, detailSection, footerSection);
        }

        //bulletins scolaires d'une évaluation d'une salle de classe
        public async Task<List<EvaluationReportCard>> GetEvaluationReportCardByClassRoomAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            List<EvaluationReportCard> result = new();

            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var selectedClassroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedClassroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);

            // extraction des moyennes de la classe
            var getEvaluationAveragesTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            //extraction des notes de la classe;
            var getEvaluationNotesTask = localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByRoom(roomId, schoolYearId);
            // Extraction des commenataires
            var getEvaluationCommentsTask = studentNoteService.GetCommentsByClassroomAsync(roomId, evaluationId, bookId, schoolYearId);
            var reportTitle = $"BULLETIN {evaluation.FrenchName}";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} SUMMARY MARK";
                language = "EN";
            }
            var evaluationAverageList = await getEvaluationAveragesTask;
            //extraction de la liste des élèves ayant composé
            var students = evaluationAverageList.Select(x => x.Student).ToList();
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == selectedClass.Id);
            //extraction des groupes de matières de la classe de l'élève
            var groupList = classroomSujectList.Where(x => x.BookId == bookId).OrderBy(x => x.Sequence).Select(x => x.Group).DistinctBy(x => x.Id).ToList();
            var evaluationNoteList = await getEvaluationNotesTask;
            var disciplineItems=await getDisciplinesTask;
            var comments= await getEvaluationCommentsTask;
            foreach (var student in students)
            {
                // create head of report card
                var disciplinarySheet = disciplineItems.Where(d => d.Student.Id == student.Id && d.Evaluation.Id==evaluationId).ToList();
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, selectedClassroom, "", language, evaluation.Code, disciplinarySheet);
                #region Detail Report


                //ectraction des notes de l'élève
                var studentNoteList = evaluationNoteList.Where(x => x.Student.Id == student.Id).ToList();
                //ectraction des matères sur lesquelles l'élève a été évalué
                var studentSubjectIdList = studentNoteList.Select(x => x.Subject.Id).Distinct().ToList();
                //extraction de la liste des matières de la classe sur lesquelles l'élève n'a pas été évalué
                var subjectIdNoMarkList = classroomSujectList.Where(x => studentSubjectIdList.Contains(x.SubjectId) == false && x.BookId == bookId).ToList();
                // Création des notes pour des matières sur lesquelles l'élève n'a pas été évalué
                foreach (var item in subjectIdNoMarkList)
                {
                    studentNoteList.Add(new(0, student, item.Subject, item.Group, 0, string.Empty, string.Empty, item.Coefficient, item.NotedOn, string.Empty, string.Empty));
                }
                var detailSection = new DetailEvaluationReportCard(studentNoteList, groupList);
                #endregion

                #region Footer Report
                // calcul de la moyenne
                double sumCoef = 0;//somme de coefficients
                double sumNote = 0;// somme de notes
                double sumMaxNote = 0;
                double average = 0;
                if (classGroup.AverageFormula == 0)
                {
                    sumNote = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.Note);
                    sumMaxNote = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.NotedOn);
                    sumCoef = studentNoteList.Where(x => x.NoteAsString != string.Empty).Sum(x => x.NoteCoef);
                    //average = sumMaxNote > 0 ? (sumNote * 20) / sumMaxNote : 0;
                }
                else
                {
                    foreach (var subjectId in studentSubjectIdList)
                    {
                        var evaluationLine = studentNoteList.First(x => x.Subject.Id == subjectId);
                        double note20 = evaluationLine.Note * 20 / evaluationLine.NotedOn;// on ramene la note a 20;
                        var subjectNote = note20 * evaluationLine.NoteCoef;
                        sumMaxNote += evaluationLine.Note * evaluationLine.NoteCoef;
                        sumCoef += evaluationLine.NoteCoef;
                        sumNote += subjectNote;
                    }
                    //average = sumCoef > 0 ? sumNote / sumCoef : 0;
                }
                // extraction de la moyenne de l'élève
                average = evaluationAverageList.FirstOrDefault(x => x.Student.Id == student.Id).Average;
                var position = evaluationAverageList.FirstOrDefault(x => x.Student.Id == student.Id).Position;
                var highestAverage = evaluationAverageList.FirstOrDefault().Average;
                var lowestAverage = evaluationAverageList.LastOrDefault().Average;
                var cAverage = evaluationAverageList.Sum(x => x.Average) / evaluationAverageList.Count;
                double classAverage = AppUtilities.GetTruncateOrRoundingValue(cAverage, classGroup);
                var comment=comments.FirstOrDefault(c=>c.StudentId == student.Id)?.Comment;
                var footerSection = new EvaluationFooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage,comment);
                #endregion
                result.Add(new EvaluationReportCard(headReportSection, detailSection, footerSection));
            }
            return result;
        }
        //bulletins scolaires d'un trimestre d'une salle de classe
        public async Task<List<TermReportCard>> GetTermReportCardByClassRoomAsync(int roomId, int termId, int schoolYearId, int bookId)
        {
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByRoom(roomId, schoolYearId);
            List<TermReportCard> reportCards = new();
            // liste des trimestres antérieurs
            List<string> reminderTerms = new();
            Dictionary<string, Task<List<AverageRecord>>> reminderTermsTask = new();
            Dictionary<string, List<AverageRecord>> reminderTermsTaskResult = new();
            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
            string termCode = term != null ? term.Code : string.Empty;
            if (termCode == "TERM02")
            {
                reminderTerms.Add("TERM01");
            }
            else
            {
                if (termCode == "TERM03")
                {
                    reminderTerms.Add("TERM01");
                    reminderTerms.Add("TERM02");
                }
            }
            var evaluationIds = Program.EvaluationSessionChildList.Where(e => e.Mother == termId).Select(d=>d.Id);
            var evaluationCodes = LocalStudentNoteService.GetEvaluationCodeOfTerm(termCode);
            var eval01 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval02 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval03 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));

            // Extraction des notes du trimestre
            var term_notes_task = localStudentNoteService.GetTermNoteListByRoom(roomId, termCode, schoolYearId, bookId);
            var term_averages_task = localStudentNoteService.GetTermAverageListByRoom(roomId, termCode, schoolYearId, bookId);
            // Extraction des commentaires
            var term_comments_task = studentNoteService.GetCommentsByClassroomAsync(roomId, termId,bookId, schoolYearId);
            foreach (var code in reminderTerms)
            {
                reminderTermsTask.Add(code, localStudentNoteService.GetTermAverageListByRoom(roomId, code, schoolYearId, bookId));
            }
            // extraction des moyennes des évaluations
            var eval01_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval01 != null ? eval01.Id : 100, schoolYearId, bookId);
            var eval02_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval02 != null ? eval02.Id : 100, schoolYearId, bookId);
            var eval03_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval03 != null ? eval03.Id : 100, schoolYearId, bookId);
            // Récupération des info de la salle de classe;
            var selectedClassroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedClassroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == selectedClass.Id);
            var teacherName = string.Empty;
            if (teacher != null)
            {
                teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
            }
            var reportTitle = string.Empty;
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                language = "EN";
                if (teacher != null)
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }

            var term_notes = await term_notes_task;
            //extraction de la liste des élèves ayant composé
            var students = term_notes.Select(x => x.Student).Distinct().ToList();
            // extraction des groupes de matiières
            var subject_groups = term_notes.Select(x => x.SubjectGroup).Distinct().ToList();
            // extraction des moyennes des trimestres antérieurs
            foreach (var code in reminderTerms)
            {
                if (reminderTermsTask.TryGetValue(code, out Task<List<AverageRecord>> task))
                {
                    var taskResult = await task;
                    reminderTermsTaskResult.Add(code, taskResult);
                }
            }
            var disciplineItems = await getDisciplinesTask;
            var term_comments= await term_comments_task;
            // Production des bulletins
            foreach (var student in students)
            {
                var student_notes = term_notes.Where(x => x.Student.Id == student.Id).ToList();
                var disciplinarySheet=disciplineItems.Where(d=>d.Student.Id==student.Id && evaluationIds.Contains(d.Evaluation.Id)).ToList();
                // create head of report card
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, selectedClassroom, teacherName, language, termCode, disciplinarySheet);
                #region Detail Report

                //ectraction des matères sur lesquelles l'élève a été évalué
                var student_subject_id_list = student_notes.Select(x => x.Subject.Id).Distinct().ToList();
                //extraction de la liste des matières de la classe sur lesquelles l'élève n'a pas été évalué
                var subject_noMark_id_List = classroomSujectList.Where(x => student_subject_id_list.Contains(x.SubjectId) == false && x.BookId == bookId).ToList();
                // Création des notes pour des matières sur lesquelles l'élève n'a pas été évalué
                foreach (var item in subject_noMark_id_List)
                {
                    student_notes.Add(
                        new(
                            0,
                            student,
                            item.Subject,
                            item.Group,
                            0,
                            string.Empty,
                            string.Empty,
                            0,
                            string.Empty,
                            string.Empty,
                            0,
                            string.Empty,
                             string.Empty,
                             0,
                            string.Empty,
                             string.Empty,
                            item.Coefficient,
                            item.NotedOn,
                            string.Empty,
                            string.Empty));
                }
                var detailSection = new DetailTermReportCard(student_notes, subject_groups);

                #endregion

                #region Footer Report
                // calcul de la moyenne
                List<ReportItem> footerItems = new();
                double sumCoef = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NoteCoef);
                footerItems.Add(new("SumCoef", sumCoef.ToString()));
                double sumNotedOn = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NotedOn);
                footerItems.Add(new("SumNotedOn", sumNotedOn.ToString()));
                double sumFirstNote = student_notes.Where(x => x.FirstNoteAsString != string.Empty).Sum(x => x.FirstNote);
                footerItems.Add(sumFirstNote != 0 ? new("SumFirstNote", sumFirstNote.ToString()) : new("SumFirstNote", string.Empty));
                double sumSecondNote = student_notes.Where(x => x.SecondNoteAsString != string.Empty).Sum(x => x.SecondNote);
                footerItems.Add(sumSecondNote != 0 ? new("SumSecondNote", sumSecondNote.ToString()) : new("SumSecondNote", string.Empty));
                double sumThirdNote = student_notes.Where(x => x.ThirdNoteAsString != string.Empty).Sum(x => x.ThirdNote);
                footerItems.Add(sumThirdNote != 0 ? new("SumThirdNote", sumThirdNote.ToString()) : new("SumThirdNote", string.Empty));

                double sumFinalNote = Helper.RoundingValue(student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.FinalNote));
                footerItems.Add(sumFinalNote != 0 ? new("SumFinalNote", sumFinalNote.ToString()) : new("SumFinalNote", string.Empty));
                var term_averages = await term_averages_task;
                var eval01_averages = await eval01_averages_task;
                var eval02_averages = await eval02_averages_task;
                var eval03_averages = await eval03_averages_task;
                var eval01_averages_student = eval01_averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval02_averages_student = eval02_averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var eval03_averages_student = eval03_averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var term_averages_student = term_averages.FirstOrDefault(x => x.Student.Id == student.Id);
                double firstMonthAverage = eval01_averages_student != null ? eval01_averages_student.Average : 0;
                footerItems.Add(firstMonthAverage != 0 ? new("FirstMonthAverage", firstMonthAverage.ToString()) : new("FirstMonthAverage", string.Empty));
                double secondMonthAverage = eval02_averages_student != null ? eval02_averages_student.Average : 0;
                footerItems.Add(secondMonthAverage != 0 ? new("SecondMonthAverage", secondMonthAverage.ToString()) : new("SecondMonthAverage", string.Empty));
                double thirdMonthAverage = eval03_averages_student != null ? eval03_averages_student.Average : 0;
                footerItems.Add(thirdMonthAverage != 0 ? new("ThirdMonthAverage", thirdMonthAverage.ToString()) : new("ThirdMonthAverage", string.Empty));
                double termAverage = term_averages_student != null ? term_averages_student.Average : 0;
                footerItems.Add(termAverage != 0 ? new("TermAverage", termAverage.ToString()) : new("TermAverage", string.Empty));
                string firstMonthPosition = eval01_averages_student != null ? eval01_averages_student.Position : string.Empty;
                footerItems.Add(new("FirstMonthPosition", firstMonthPosition));
                string firstMonthPositionWithStudentCount = eval01_averages_student != null ? firstMonthPosition + '/' + eval01_averages.Count : string.Empty;
                footerItems.Add(new("FirstMonthPositionWithStudentCount", firstMonthPositionWithStudentCount));
                string secondMonthPosition = eval02_averages_student != null ? eval02_averages_student.Position : string.Empty;
                footerItems.Add(new("SecondMonthPosition", secondMonthPosition));
                string secondMonthPositionWithStudentCount = eval02_averages_student != null ? secondMonthPosition + '/' + eval02_averages.Count : string.Empty;
                footerItems.Add(new("SecondMonthPositionWithStudentCount", secondMonthPositionWithStudentCount));
                string thirdMonthPosition = eval03_averages_student != null ? eval03_averages_student.Position : string.Empty;
                footerItems.Add(new("ThirdMonthPosition", thirdMonthPosition));
                string thirdMonthPositionWithStudentCount = eval03_averages_student != null ? thirdMonthPosition + '/' + eval03_averages.Count : string.Empty;
                footerItems.Add(new("ThirdMonthPositionWithStudentCount", thirdMonthPositionWithStudentCount));
                string termPosition = term_averages_student != null ? term_averages_student.Position : string.Empty;
                footerItems.Add(new("TermPosition", termPosition));
                string termPositionWithStudentCount = term_averages_student != null ? termPosition + '/' + term_averages.Count : string.Empty;
                footerItems.Add(new("TermPositionWithStudentCount", termPositionWithStudentCount));
                double firstMonthClassAverage = eval01_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval01_averages.Sum(x => x.Average) / eval01_averages.Count, classGroup) : 0;
                footerItems.Add(new("FirstMonthClassAverage", firstMonthClassAverage.ToString()));
                double secondMonthClassAverage = eval02_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval02_averages.Sum(x => x.Average) / eval02_averages.Count, classGroup) : 0;
                footerItems.Add(new("SecondMonthClassAverage", secondMonthClassAverage.ToString()));
                double thirdMonthClassAverage = eval03_averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(eval03_averages.Sum(x => x.Average) / eval03_averages.Count, classGroup) : 0;
                footerItems.Add(new("ThirdMonthClassAverage", thirdMonthClassAverage.ToString()));
                double termClassAverage = AppUtilities.GetTruncateOrRoundingValue(term_averages.Sum(x => x.Average) / term_averages.Count, classGroup);
                footerItems.Add(new("TermClassAverage", termClassAverage.ToString()));
                double firstMonthHighestAverage = eval01_averages.Select(x => x.Average).OrderByDescending(x => x).First();
                footerItems.Add(new("FirstMonthHighestAverage", firstMonthHighestAverage.ToString()));
                double secondMonthHighestAverage = eval02_averages.Any() ? eval02_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("SecondMonthHighestAverage", secondMonthHighestAverage.ToString()));
                double thirdMonthHighestAverage = eval03_averages.Any() ? eval03_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("ThirdMonthHighestAverage", thirdMonthHighestAverage.ToString()));
                double termHighestAverage = term_averages.Any() ? term_averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("TermHighestAverage", termHighestAverage.ToString()));
                double firstMonthLowestAverage = eval01_averages.Any() ? eval01_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("FirstMonthLowestAverage", firstMonthLowestAverage.ToString()));
                double secondMonthLowestAverage = eval02_averages.Any() ? eval02_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("SecondMonthLowestAverage", secondMonthLowestAverage.ToString()));
                double thirdMonthLowestAverage = eval03_averages.Any() ? eval03_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("ThirdMonthLowestAverage", thirdMonthLowestAverage.ToString()));
                double termLowestAverage = term_averages.Any() ? term_averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("TermLowestAverage", termLowestAverage.ToString()));
                
                if (reminderTermsTaskResult.TryGetValue("TERM01", out List<AverageRecord> term1Averages))
                {
                    var term1Average = term1Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                    footerItems.Add(new("FirstTermAverage", term1Average != null ? term1Average.Average.ToString() : string.Empty));
                }
                if (reminderTermsTaskResult.TryGetValue("TERM02", out List<AverageRecord> term2Averages))
                {
                    var term2Average = term2Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                    footerItems.Add(new("SecondTermAverage", term2Average != null ? term2Average.Average.ToString() : string.Empty));
                }
                if (termCode == "TERM03")
                {
                    footerItems.Add(new("ThirdTermAverage", termAverage.ToString()));
                    var term01 = footerItems.FirstOrDefault(x => x.Name == "FirstTermAverage" && x.Value != string.Empty);
                    var term02 = footerItems.FirstOrDefault(x => x.Name == "SecondTermAverage" && x.Value != string.Empty);
                    double annualAverage = 0;
                    if (term01 != null)
                    {
                        if (term02 != null)
                        {
                            annualAverage = (termAverage + double.Parse(term01.Value) + double.Parse(term02.Value)) / 3;
                        }
                        else
                        {
                            annualAverage = (termAverage + double.Parse(term01.Value)) / 2;
                        }
                    }
                    else
                    {
                        if (term02 != null)
                        {
                            annualAverage = (termAverage + double.Parse(term02.Value)) / 2;
                        }
                    }
                    footerItems.Add(new("AnnualAverage", AppUtilities.GetTruncateOrRoundingValue(annualAverage, classGroup).ToString()));
                }

                var comment = term_comments.FirstOrDefault(c => c.StudentId == student.Id)?.Comment;
                footerItems.Add(new("Comment",comment));
                var footerSection = new ReportFooter(footerItems);
               
                
                #endregion

                // ajout du bulletin
                reportCards.Add(new TermReportCard(headReportSection, detailSection, footerSection));
            }

            return reportCards;
        }
        // Bulletins scolaires d'une année d'une salle de classe
        public async Task<List<TermReportCard>> GetAnnualReportCardByClassRoomAsync(int roomId, int schoolYearId, int bookId)
        {
            List<TermReportCard> reportCards = new();
            List<TermRecord> annualNoteListe = new();
            // Récupération des info de la salle de classe;
            var selectedClassroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == selectedClassroom.ClassId);
            var selectedClassGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            var language = LocalStudentNoteService.GetLanguageGroup(selectedClassGroup, bookId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            var teacherName = string.Empty;
            if (teacher != null)
            {
                if (language == "FR")
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
                }
                else
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }
            var reportTitle = string.Empty;

            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == selectedClass.Id);

            // extraction élements disciplinaire 
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByRoom(roomId, schoolYearId);

            // extraction des moyennes annuelles
            var getAnnualAveragesTask = localStudentNoteService.GetAnnualAverageListByRoom(roomId, schoolYearId, bookId);

            // extraction des moyennes trimestrielles
            var getFirstTermAveragesTask = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermAveragesTask = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermAveragesTask = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM03", schoolYearId, bookId);

            // Extraction des notes par trimestre
            var getFirstTermNotesTask = localStudentNoteService.GetTermNoteListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermNotesTask = localStudentNoteService.GetTermNoteListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermNotesTask = localStudentNoteService.GetTermNoteListByRoom(roomId, "TERM03", schoolYearId, bookId);

            // Extraction des commentaires

            var getCommentsTask = studentNoteService.GetCommentsBySchoolYearAsync(roomId, bookId, schoolYearId);

            var term1Notes = await getFirstTermNotesTask;
            var term2Notes = await getSecondTermNotesTask;
            var term3Notes = await getThirdTermNotesTask;

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
                    var finalNote = LocalStudentNoteService.ComputeFinalAverage(term1Note, term2Note, term3Note);
                    finalNote = AppUtilities.GetTruncateOrRoundingValue(finalNote, selectedClassGroup);
                    // get notedOn 
                    var notedOn = LocalStudentNoteService.GetNotedOn(term1Note, term2Note, term3Note);
                    // get noteCoef 
                    var noteCoef = LocalStudentNoteService.GetNoteCoef(term1Note, term2Note, term3Note);
                    // get subject group 
                    var subjectGroup = classroomSujectList.FirstOrDefault(x => x.SubjectId == subject.Id);
                    termRecords.Add(
                        new(
                            0,
                            student,
                            subject,
                            subjectGroup.Group,
                            term1Note != null ? term1Note.FinalNote : 0,
                            term1Note != null ? term1Note.FinalNote.ToString() : string.Empty,
                            term1Note != null ? $"{term1Note.FinalNote}/{notedOn}" : string.Empty,
                            term2Note != null ? term2Note.FinalNote : 0,
                            term2Note != null ? term2Note.FinalNote.ToString() : string.Empty,
                            term2Note != null ? $"{term2Note.FinalNote}/{notedOn}" : string.Empty,
                            term3Note != null ? term3Note.FinalNote : 0,
                            term3Note != null ? term3Note.FinalNote.ToString() : string.Empty,
                            term3Note != null ? $"{term3Note.FinalNote}/{notedOn}" : string.Empty,
                            finalNote,
                            finalNote.ToString(),
                            $"{finalNote}/{notedOn}",
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
                            NotedOn = notedOn,
                            NoteCoef= noteCoef
                        }
                        );
                }
                // On génère une liste ordonnée par ordre de mérite
                var orderedAverageList = LocalStudentNoteService.GenerateOrderedWithPosition(notesToOrder, language);
                foreach (var item in orderedAverageList)
                {
                    //truncate or around note
                    var note = AppUtilities.GetTruncateOrRoundingValue(item.Note, selectedClassGroup);
                    var note20 = LocalStudentNoteService.GetNote20(note, item.NotedOn);
                    //get rating
                    var systemRating = Program.RatingSystemList.FirstOrDefault(x => x.Domain == "Note" && x.MinNote <= note20 && x.MaxNote >= note20);
                    var rating = string.Empty;
                    if (systemRating != null)
                    {
                        rating = language == "FR" ? systemRating.FrenchName : systemRating.EnglishName;
                    }

                    var termNote = termRecords.Find(x => x.Student.Id == item.Student.Id);

                    annualNoteListe.Add(
                        new(
                            0,
                            termNote.Student,
                            termNote.Subject,
                            termNote.SubjectGroup,
                            termNote.FirstNote,
                            termNote.FirstNoteAsString,
                            termNote.FirstNoteWithMax,
                            termNote.SecondNote,
                            termNote.SecondNoteAsString,
                            termNote.SecondNoteWithMax,
                            termNote.ThirdNote,
                            termNote.ThirdNoteAsString,
                            termNote.ThirdNoteWithMax,
                            termNote.FinalNote,
                            termNote.FinalNoteAsString,
                            termNote.FinalNoteWithMax,
                            termNote.NoteCoef,
                            termNote.NotedOn,
                            rating,
                            item.Position
                            )
                        );
                }
            }


            // extraction des groupes de matiières
            var subject_groups = annualNoteListe.Select(x => x.SubjectGroup).Distinct().ToList();
            var disciplineItems = await getDisciplinesTask;
            // Récupération des moyennes trimestrielles
            var term1Averages = await getFirstTermAveragesTask;
            var term2Averages = await getSecondTermAveragesTask;
            var term3Averages = await getThirdTermAveragesTask;
            // Récupération des moyennes annuelles
            var annualAverages = await getAnnualAveragesTask;
            //Récupération des commentaire
            var comments= await getCommentsTask;
            // Production des bulletins
            foreach (var student in composedStudents)
            {
                var student_notes = annualNoteListe.Where(x => x.Student.Id == student.Id).ToList();
                var disciplinarySheet = disciplineItems.Where(d => d.Student.Id == student.Id).ToList();
                // create head of report card
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, selectedClassroom, teacherName, language, string.Empty,disciplinarySheet);
                #region Detail Report


                var detailSection = new DetailTermReportCard(student_notes, subject_groups);

                #endregion

                #region Footer Report
                // calcul de la moyenne
                List<ReportItem> footerItems = new();
                double sumCoef = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NoteCoef);
                footerItems.Add(new("SumCoef", sumCoef.ToString()));
                double sumNotedOn = student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.NotedOn);
                footerItems.Add(new("SumNotedOn", sumNotedOn.ToString()));
                double sumFirstNote = student_notes.Where(x => x.FirstNoteAsString != string.Empty).Sum(x => x.FirstNote);
                sumFirstNote = AppUtilities.GetTruncateOrRoundingValue(sumFirstNote, selectedClassGroup);
                footerItems.Add(sumFirstNote != 0 ? new("SumFirstNote", sumFirstNote.ToString()) : new("SumFirstNote", string.Empty));
                double sumSecondNote = student_notes.Where(x => x.SecondNoteAsString != string.Empty).Sum(x => x.SecondNote);
                sumSecondNote = AppUtilities.GetTruncateOrRoundingValue(sumSecondNote, selectedClassGroup);
                footerItems.Add(sumSecondNote != 0 ? new("SumSecondNote", sumSecondNote.ToString()) : new("SumSecondNote", string.Empty));
                double sumThirdNote = student_notes.Where(x => x.ThirdNoteAsString != string.Empty).Sum(x => x.ThirdNote);
                sumThirdNote = AppUtilities.GetTruncateOrRoundingValue(sumThirdNote, selectedClassGroup);
                footerItems.Add(sumThirdNote != 0 ? new("SumThirdNote", sumThirdNote.ToString()) : new("SumThirdNote", string.Empty));
                double sumFinalNote = Helper.RoundingValue(student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.FinalNote));
                footerItems.Add(sumFinalNote != 0 ? new("SumFinalNote", sumFinalNote.ToString()) : new("SumFinalNote", string.Empty));

              
                var term01_averages_student = term1Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var term02_averages_student = term2Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var term03_averages_student = term3Averages.FirstOrDefault(x => x.Student.Id == student.Id);
                var annual_averages_student = annualAverages.FirstOrDefault(x => x.Student.Id == student.Id);
                double firstTermAverage = term01_averages_student != null ? term01_averages_student.Average : 0;
                footerItems.Add(firstTermAverage != 0 ? new("FirstTermAverage", firstTermAverage.ToString()) : new("FirstTermAverage", string.Empty));
                double secondTermAverage = term02_averages_student != null ? term02_averages_student.Average : 0;
                footerItems.Add(secondTermAverage != 0 ? new("SecondTermAverage", secondTermAverage.ToString()) : new("SecondTermAverage", string.Empty));
                double thirdAverageAverage = term03_averages_student != null ? term03_averages_student.Average : 0;
                footerItems.Add(thirdAverageAverage != 0 ? new("ThirdTermAverage", thirdAverageAverage.ToString()) : new("ThirdTermAverage", string.Empty));
                double annualAverage = annual_averages_student != null ? annual_averages_student.Average : 0;
                footerItems.Add(annualAverage != 0 ? new("AnnualAverage", annualAverage.ToString()) : new("AnnualAverage", string.Empty));
                string firstTermPosition = term01_averages_student != null ? term01_averages_student.Position : string.Empty;
                footerItems.Add(new("FirstTermPosition", firstTermPosition));
                string firstTermPositionWithStudentCount = term01_averages_student != null ? firstTermPosition + '/' + term1Averages.Count : string.Empty;
                footerItems.Add(new("FirstTermPositionWithStudentCount", firstTermPositionWithStudentCount));
                string secondTermPosition = term02_averages_student != null ? term02_averages_student.Position : string.Empty;
                footerItems.Add(new("SecondTermPosition", secondTermPosition));
                string secondTermPositionWithStudentCount = term02_averages_student != null ? secondTermPosition + '/' + term2Averages.Count : string.Empty;
                footerItems.Add(new("SecondTermPositionWithStudentCount", secondTermPositionWithStudentCount));
                string thirdTermPosition = term03_averages_student != null ? term03_averages_student.Position : string.Empty;
                footerItems.Add(new("ThirdTermPosition", thirdTermPosition));
                string thirdTermPositionWithStudentCount = term03_averages_student != null ? thirdTermPosition + '/' + term3Averages.Count : string.Empty;
                footerItems.Add(new("ThirdTermPositionWithStudentCount", thirdTermPositionWithStudentCount));
                string annualPosition = annual_averages_student != null ? annual_averages_student.Position : string.Empty;
                footerItems.Add(new("AnnualPosition", annualPosition));
                string annualPositionWithStudentCount = annual_averages_student != null ? annualPosition + '/' + annualAverages.Count : string.Empty;
                footerItems.Add(new("AnnualPositionWithStudentCount", annualPositionWithStudentCount));

                double firstTermClassAverage = term1Averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(term1Averages.Sum(x => x.Average) / term1Averages.Count, selectedClassGroup) : 0;
                footerItems.Add(new("FirstTermClassAverage", firstTermClassAverage.ToString()));
                double secondTermClassAverage = term2Averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(term2Averages.Sum(x => x.Average) / term2Averages.Count, selectedClassGroup) : 0;
                footerItems.Add(new("SecondTermClassAverage", secondTermClassAverage.ToString()));
                double thirdTermClassAverage = term3Averages.Count != 0 ? AppUtilities.GetTruncateOrRoundingValue(term3Averages.Sum(x => x.Average) / term3Averages.Count, selectedClassGroup) : 0;
                footerItems.Add(new("ThirdTermClassAverage", thirdTermClassAverage.ToString()));
                double annualClassAverage = AppUtilities.GetTruncateOrRoundingValue(annualAverages.Sum(x => x.Average) / annualAverages.Count, selectedClassGroup);
                footerItems.Add(new("AnnualClassAverage", annualClassAverage.ToString()));
                double firstTermHighestAverage = term1Averages.Select(x => x.Average).OrderByDescending(x => x).First();
                footerItems.Add(new("FirstTermHighestAverage", firstTermHighestAverage.ToString()));
                double secondTermHighestAverage = term2Averages.Any() ? term2Averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("SecondTermHighestAverage", secondTermHighestAverage.ToString()));
                double thirdTermHighestAverage = term3Averages.Any() ? term3Averages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("ThirdTermHighestAverage", thirdTermHighestAverage.ToString()));
                double annualHighestAverage = annualAverages.Any() ? annualAverages.Select(x => x.Average).OrderByDescending(x => x).First() : 0;
                footerItems.Add(new("AnnualHighestAverage", annualHighestAverage.ToString()));
                double firstTermLowestAverage = term1Averages.Any() ? term1Averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("FirstTermLowestAverage", firstTermLowestAverage.ToString()));
                double secondTermLowestAverage = term2Averages.Any() ? term2Averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("SecondTermLowestAverage", secondTermLowestAverage.ToString()));
                double thirdTermLowestAverage = term3Averages.Any() ? term3Averages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("ThirdTermLowestAverage", thirdTermLowestAverage.ToString()));
                double annualLowestAverage = annualAverages.Any() ? annualAverages.Select(x => x.Average).OrderBy(x => x).First() : 0;
                footerItems.Add(new("AnnualLowestAverage", annualLowestAverage.ToString()));
                // on récupère le dernier commentaire s'il y a plussieurs
                var student_comments=comments.Where(c=>c.StudentId==student.Id).OrderByDescending(c=>c.Id);
                var comment= student_comments.FirstOrDefault()?.Comment;
                footerItems.Add(new("Comment", comment));
                var footerSection = new ReportFooter(footerItems);
                #endregion

                // ajout du bulletin
                reportCards.Add(new TermReportCard(headReportSection, detailSection, footerSection));
            }

            return reportCards;
        }


        // Procès verbal  d'une l'évaluation pour salle de classe
        public async Task<ClassroomReport> GetEvaluationReportByClassRoomAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            // extraction des moyennes de la classe
            var getAveragesTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var getNotesTask = localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            // get data of head report
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var totalStudent = Program.StudentRoomList.Count(x => x.SchoolYearId == schoolYearId && x.RoomId == roomId);
            var reportTitle = $"PROCE VERBAL {evaluation.FrenchName}";
            var schoolYearLabel = $"Année scolaire {schoolYear.Name}";
            var classroomLabel = $"{classroom.Name}. Effectif: {totalStudent}";
            //extraction des matières avec note max et groupe de la classe 
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id && x.BookId == bookId).OrderBy(x => x.Sequence);
            var sumMaxOrCoef = classGroup.AverageFormula == 0 ? $"Total des notes max: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total des coefficients:{classroomSujectList.Sum(x => x.Coefficient)}";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} CLASS REPORT";
                schoolYearLabel = $"Academic year {schoolYear.Name}";
                classroomLabel = $"{classroom.Name}. Class size: {totalStudent}";
                sumMaxOrCoef = classGroup.AverageFormula == 0 ? $"Total of max mark: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total of coefficient:{classroomSujectList.Sum(x => x.Coefficient)}";
                language = "EN";
            }
            if (classGroup.DocumentLanguageId == 2)
            {
                classroomLabel = bookId == 1 ? $"{classroom.Name}: Anglophone. Class size: {totalStudent}" : $"{classroom.Name}: Francophone. Effectif: {totalStudent}";
            }

            // extraction des données de l'évaluation
            var notes = await getNotesTask;
            var averages = await getAveragesTask;
            //get subjects evaluated
            var subjectEvaluatedList = notes.Select(x => (x.Subject, x.NotedOn, x.NoteCoef)).DistinctBy(x => x.Subject.Id);
            // get subjects to create subject column
            List<(Subject Subject, double NotedOn, double NoteCoef)> subjectToPutInReport = new();
            foreach (var item in classroomSujectList)
            {
                if (subjectEvaluatedList.Any(x => x.Subject.Id == item.SubjectId))
                {
                    subjectToPutInReport.Add(subjectEvaluatedList.FirstOrDefault(x => x.Subject.Id == item.SubjectId));
                }
            }
            // if we have some subjects evaluated which removed to class suject
            // complete de list of subject to input to the report
            if (subjectEvaluatedList.Count() > subjectToPutInReport.Count)
            {
                foreach (var item in subjectEvaluatedList)
                {
                    if (!subjectToPutInReport.Any(x => x.Subject.Id == item.Subject.Id))
                    {
                        subjectToPutInReport.Add(item);
                    }
                }
            }
            // create columns and data structure for report
            DataTable dataTable = new();
            List<string> columns = new()
            {
                "N°",
                language == "FR" ? "NOMS & PRENOMS" : "FIRST & LAST NAMES",
                language == "FR" ? "MATRICULE" : "ID",
                language == "FR" ? "SEXE" : "SEX"
            };
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Student", typeof(string));
            dataTable.Columns.Add("StudentId", typeof(string));
            dataTable.Columns.Add("Sex", typeof(string));
            foreach (var item in subjectToPutInReport)
            {
                var finalName = string.Empty;
                var subjectName = string.Empty;
                if (language == "FR")
                {
                    subjectName = item.Subject.FrenchName.Length >= 31 ? item.Subject.FrenchName.Substring(0, 29) : item.Subject.FrenchName;
                }
                else
                {
                    subjectName = item.Subject.EnglishName.Length >= 31 ? item.Subject.EnglishName.Substring(0, 29) : item.Subject.EnglishName;
                }
                finalName = classGroup.AverageFormula == 0 ? $"{subjectName} \n Max: {item.NotedOn}" : $"{subjectName} \n Coef: {item.NoteCoef}";
                columns.Add(finalName);
                dataTable.Columns.Add("subject" + item.Subject.Id, typeof(string));
            }

            columns.Add("TOTAL");
            columns.Add(language == "FR" ? "MOYENNE / 20" : "AVERAGE / 20");
            columns.Add(language == "FR" ? "RANG" : "POSITION");
            columns.Add(language == "FR" ? "OBSERVATION" : "GRADING");
            dataTable.Columns.Add("Total", typeof(double));
            dataTable.Columns.Add("Average", typeof(double));
            dataTable.Columns.Add("Position", typeof(string));
            dataTable.Columns.Add("Grading", typeof(string));

            //get students
            var students = averages.Select(x => x.Student).OrderBy(x => x.FullName);
            int rowId = 1;
            foreach (var student in students)
            {
                object[] row = new object[columns.Count];
                row[0] = rowId;
                row[1] = student.FullName;
                row[2] = student.IdNumber;
                row[3] = student.Sex;
                int columnId = 4;
                foreach (var item in subjectToPutInReport)
                {
                    var evaluationLine = notes.FirstOrDefault(x => x.Student.Id == student.Id && x.Subject.Id == item.Subject.Id);
                    row[columnId] = evaluationLine != null ? evaluationLine.NoteAsString : string.Empty;
                    columnId++;
                }
                // colonne Total
                row[columnId++] = averages.FirstOrDefault(x => x.Student.Id == student.Id).TotalMark;
                // colonne Moyenne
                row[columnId++] = averages.FirstOrDefault(x => x.Student.Id == student.Id).Average;
                // colonne Rang
                row[columnId++] = averages.FirstOrDefault(x => x.Student.Id == student.Id).Position;
                // colonne Observation
                row[columnId++] = string.Empty;
                dataTable.Rows.Add(row);
                rowId++;
            }
            // create head report
            ClassroomReportHeader headerSection = new(
                      new() {
                          new("Language",language),
                          new("ReportTitle",reportTitle),
                          new("SchoolYear",schoolYearLabel),
                          new("ClassRoom",classroomLabel),
                          new("SumMaxOrCoef",sumMaxOrCoef)
                      }, columns
                );
            //create detail of report
            ClassroomReportDetail detailSection = new(dataTable);
            // create footer report
            var studentsOfClassroom = Program.StudentRoomList.Where(x => x.SchoolYearId == schoolYearId && x.RoomId == roomId).Select(x => x.Student).ToList();
            var classroomSizeFemale = studentsOfClassroom.Count(x => x.Sex == "F");
            var classroomSizeMale = studentsOfClassroom.Count(x => x.Sex == "M");
            var classroomSizeTotal = studentsOfClassroom.Count;
            var evaluatedFemale = averages.Count(x => x.Student.Sex == "F");
            var evaluatedMale = averages.Count(x => x.Student.Sex == "M");
            var evaluatedTotal = averages.Count;
            var averageFemale = averages.Count(x => x.Student.Sex == "F" && x.Average >= 10);
            var averageMale = averages.Count(x => x.Student.Sex == "M" && x.Average >= 10);
            var averageTotal = averages.Count(x => x.Average >= 10);
            var passedFemale = averageFemale * 100 / evaluatedFemale;
            var passedMale = averageMale * 100 / evaluatedMale;
            var passedTotal = averageTotal * 100 / evaluatedTotal;
            var classroomSizeDescription = language == "FR" ? "M: Maculin, F: Féminin, T: Total" : "M: Male, F: Female, T: Total";
            var generalAverageLabel = language == "FR" ? "Moyenne générale" : "General average";
            var ga = (averages.Sum(x => x.Average) / evaluatedTotal);
            var gaf = AppUtilities.GetTruncateOrRoundingValue(ga, classGroup);
            var generalAverage = $"{generalAverageLabel}: {gaf}";
            var lowestAverageLabel = language == "FR" ? "Plus petite moyenne" : "Lowest average";
            var lowestAverage = $"{lowestAverageLabel}: {averages.LastOrDefault().Average}";
            var highestAverageLabel = language == "FR" ? "Plus grande moyenne" : "Highest average";
            var highestAverage = $"{highestAverageLabel}: {averages.FirstOrDefault().Average}";
            ReportFooter footerSection = new(
                      new() {
                          new("ClassroomSizeFemale",classroomSizeFemale.ToString()),
                          new("ClassroomSizeMale", classroomSizeMale.ToString()),
                          new("ClassroomSizeTotal",classroomSizeTotal.ToString()),
                          new("EvaluatedFemale",evaluatedFemale.ToString()),
                          new("EvaluatedMale", evaluatedMale.ToString()),
                          new("EvaluatedTotal",evaluatedTotal.ToString()),
                          new("AverageFemale",averageFemale.ToString()),
                          new("AverageMale", averageMale.ToString()),
                          new("AverageTotal",averageTotal.ToString()),
                          new("PassedFemale",passedFemale.ToString()),
                          new("PassedMale", passedMale.ToString()),
                          new("PassedTotal",passedTotal.ToString()),
                          new("ClassroomSizeDescription",classroomSizeDescription),
                          new("GeneralAverage", generalAverage),
                          new("LowestAverage",lowestAverage),
                          new("HighestAverage",highestAverage),
                      }
                );

            return new(headerSection, detailSection, footerSection);
        }
        // Procès verbal  d'un trimestre' pour salle de classe
        public async Task<ClassroomReport> GetTermReportByClassRoomAsync(int roomId, int termId, int schoolYearId, int bookId)
        {
            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
            string termCode = term != null ? term.Code : string.Empty;
            // extraction des moyennes de la classe
            var getAveragesTask = localStudentNoteService.GetTermAverageListByRoom(roomId, termCode, schoolYearId, bookId);
            var getNotesTask = localStudentNoteService.GetTermNoteListByRoom(roomId, termCode, schoolYearId, bookId);
            // get data of head report
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var totalStudent = Program.StudentRoomList.Count(x => x.SchoolYearId == schoolYearId && x.RoomId == roomId);
            var reportTitle = $"PROCE VERBAL {term.FrenchName}";
            var schoolYearLabel = $"Année scolaire {schoolYear.Name}";
            var classroomLabel = $"{classroom.Name}. Effectif: {totalStudent}";
            //extraction des matières avec note max et groupe de la classe 
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id && x.BookId == bookId).OrderBy(x => x.Sequence);
            var sumMaxOrCoef = classGroup.AverageFormula == 0 ? $"Total des notes max: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total des coefficients:{classroomSujectList.Sum(x => x.Coefficient)}";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{term.EnglishName} CLASS REPORT";
                schoolYearLabel = $"Academic year {schoolYear.Name}";
                classroomLabel = $"{classroom.Name}. Class size: {totalStudent}";
                sumMaxOrCoef = classGroup.AverageFormula == 0 ? $"Total of max mark: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total of coefficient:{classroomSujectList.Sum(x => x.Coefficient)}";
                language = "EN";
            }
            if (classGroup.DocumentLanguageId == 2)
            {
                classroomLabel = bookId == 1 ? $"{classroom.Name}: Anglophone. Class size: {totalStudent}" : $"{classroom.Name}: Francophone. Effectif: {totalStudent}";
            }

            // extraction des données de l'évaluation
            var notes = await getNotesTask;
            var averages = await getAveragesTask;
            //get subjects evaluated
            var subjectEvaluatedList = notes.Select(x => (x.Subject, x.NotedOn, x.NoteCoef)).DistinctBy(x => x.Subject.Id);
            // get subjects to create subject column
            List<(Subject Subject, double NotedOn, double NoteCoef)> subjectToPutInReport = new();
            foreach (var item in classroomSujectList)
            {
                if (subjectEvaluatedList.Any(x => x.Subject.Id == item.SubjectId))
                {
                    subjectToPutInReport.Add(subjectEvaluatedList.FirstOrDefault(x => x.Subject.Id == item.SubjectId));
                }
            }
            // if we have some subjects evaluated which removed to class suject
            // complete de list of subject to input to the report
            if (subjectEvaluatedList.Count() > subjectToPutInReport.Count)
            {
                foreach (var item in subjectEvaluatedList)
                {
                    if (!subjectToPutInReport.Any(x => x.Subject.Id == item.Subject.Id))
                    {
                        subjectToPutInReport.Add(item);
                    }
                }
            }
            // create columns and data structure for report
            DataTable dataTable = new();
            List<string> columns = new()
            {
                "N°",
                language == "FR" ? "NOMS & PRENOMS" : "FIRST & LAST NAMES",
                language == "FR" ? "MATRICULE" : "ID",
                language == "FR" ? "SEXE" : "SEX"
            };
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Student", typeof(string));
            dataTable.Columns.Add("StudentId", typeof(string));
            dataTable.Columns.Add("Sex", typeof(string));
            foreach (var item in subjectToPutInReport)
            {
                var finalName = string.Empty;
                var subjectName = string.Empty;
                if (language == "FR")
                {
                    subjectName = item.Subject.FrenchName.Length >= 31 ? item.Subject.FrenchName.Substring(0, 29) : item.Subject.FrenchName;
                }
                else
                {
                    subjectName = item.Subject.EnglishName.Length >= 31 ? item.Subject.EnglishName.Substring(0, 29) : item.Subject.EnglishName;
                }
                finalName = classGroup.AverageFormula == 0 ? $"{subjectName} \n Max: {item.NotedOn}" : $"{subjectName} \n Coef: {item.NoteCoef}";
                columns.Add(finalName);
                dataTable.Columns.Add("subject" + item.Subject.Id, typeof(string));
            }

            columns.Add("TOTAL");
            columns.Add(language == "FR" ? "MOYENNE / 20" : "AVERAGE / 20");
            columns.Add(language == "FR" ? "RANG" : "POSITION");
            columns.Add(language == "FR" ? "OBSERVATION" : "GRADING");
            dataTable.Columns.Add("Total", typeof(double));
            dataTable.Columns.Add("Average", typeof(double));
            dataTable.Columns.Add("Position", typeof(string));
            dataTable.Columns.Add("Grading", typeof(string));

            //get students
            var students = averages.Select(x => x.Student).OrderBy(x => x.FullName);
            int rowId = 1;
            foreach (var student in students)
            {
                object[] row = new object[columns.Count];
                row[0] = rowId;
                row[1] = student.FullName;
                row[2] = student.IdNumber;
                row[3] = student.Sex;
                int columnId = 4;
                foreach (var item in subjectToPutInReport)
                {
                    var evaluationLine = notes.FirstOrDefault(x => x.Student.Id == student.Id && x.Subject.Id == item.Subject.Id);
                    row[columnId] = evaluationLine != null ? evaluationLine.FinalNoteAsString : string.Empty;
                    columnId++;
                }
                // colonne Total 
                row[columnId++] = AppUtilities.GetTruncateOrRoundingValue(notes.Where(x => x.Student.Id == student.Id).Sum(x => x.FinalNote), classGroup);
                // colonne Moyenne
                row[columnId++] = averages.FirstOrDefault(x => x.Student.Id == student.Id).Average;
                // colonne Rang
                row[columnId++] = averages.FirstOrDefault(x => x.Student.Id == student.Id).Position;
                // colonne Observation
                row[columnId++] = string.Empty;
                dataTable.Rows.Add(row);
                rowId++;
            }
            // create head report
            ClassroomReportHeader headerSection = new(
                      new() {
                          new("Language",language),
                          new("ReportTitle",reportTitle),
                          new("SchoolYear",schoolYearLabel),
                          new("ClassRoom",classroomLabel),
                          new("SumMaxOrCoef",sumMaxOrCoef)
                      }, columns
                );
            //create detail of report
            ClassroomReportDetail detailSection = new(dataTable);
            // create footer report
            var studentsOfClassroom = Program.StudentRoomList.Where(x => x.SchoolYearId == schoolYearId && x.RoomId == roomId).Select(x => x.Student).ToList();
            var classroomSizeFemale = studentsOfClassroom.Count(x => x.Sex == "F");
            var classroomSizeMale = studentsOfClassroom.Count(x => x.Sex == "M");
            var classroomSizeTotal = studentsOfClassroom.Count;
            double evaluatedFemale = averages.Count(x => x.Student.Sex == "F");
            double evaluatedMale = averages.Count(x => x.Student.Sex == "M");
            double evaluatedTotal = averages.Count;
            double averageFemale = averages.Count(x => x.Student.Sex == "F" && x.Average >= 10);
            double averageMale = averages.Count(x => x.Student.Sex == "M" && x.Average >= 10);
            double averageTotal = averages.Count(x => x.Average >= 10);
            double passedFemale = averageFemale * 100 / evaluatedFemale;
            double passedMale = averageMale * 100 / evaluatedMale;
            double passedTotal = averageTotal * 100 / evaluatedTotal;
            var classroomSizeDescription = language == "FR" ? "M: Maculin, F: Féminin, T: Total" : "M: Male, F: Female, T: Total";
            var generalAverageLabel = language == "FR" ? "Moyenne générale" : "General average";
            var ga = (averages.Sum(x => x.Average) / evaluatedTotal);
            var gaf = AppUtilities.GetTruncateOrRoundingValue(ga, classGroup);
            var generalAverage = $"{generalAverageLabel}: {gaf}";
            var lowestAverageLabel = language == "FR" ? "Plus petite moyenne" : "Lowest average";
            var lowestAverage = $"{lowestAverageLabel}: {averages.LastOrDefault().Average}";
            var highestAverageLabel = language == "FR" ? "Plus grande moyenne" : "Highest average";
            var highestAverage = $"{highestAverageLabel}: {averages.FirstOrDefault().Average}";
            ReportFooter footerSection = new(
                      new() {
                          new("ClassroomSizeFemale",classroomSizeFemale.ToString()),
                          new("ClassroomSizeMale", classroomSizeMale.ToString()),
                          new("ClassroomSizeTotal",classroomSizeTotal.ToString()),
                          new("EvaluatedFemale",evaluatedFemale.ToString()),
                          new("EvaluatedMale", evaluatedMale.ToString()),
                          new("EvaluatedTotal",evaluatedTotal.ToString()),
                          new("AverageFemale",averageFemale.ToString()),
                          new("AverageMale", averageMale.ToString()),
                          new("AverageTotal",averageTotal.ToString()),
                          new("PassedFemale",Helper.RoundingValue(passedFemale).ToString()),
                          new("PassedMale", Helper.RoundingValue(passedMale).ToString()),
                          new("PassedTotal",Helper.RoundingValue(passedTotal).ToString()),
                          new("ClassroomSizeDescription",classroomSizeDescription),
                          new("GeneralAverage", generalAverage),
                          new("LowestAverage",lowestAverage),
                          new("HighestAverage",highestAverage),
                      }
                );

            return new(headerSection, detailSection, footerSection);
        }
        // Statistiques d'une évaluation d'un groupe de classes
        public async Task<ClassGroupReport> GetEvaluationReportByClassGroupAsync(int groupId, int evaluationId, int schoolYearId, int bookId)
        {
            // get data of head report

            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == groupId);
            var reportTitle = $"STATISTIQUES {evaluation.FrenchName}";
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var language = "FR";
            var schoolYearLabel = $"Année scolaire {schoolYear.Name}";
            var classGroupLabel = classGroup.Name;
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} STATISTIC REPORT";
                schoolYearLabel = $"Academic year {schoolYear.Name}";
                classGroupLabel = classGroup.Name;
                language = "EN";
            }
            // récupération des classes du groupe
            var classList = Program.SchoolClassList.Where(c => c.GroupId == groupId);
            // récupération des salles de classe du groupe
            var classroomList = Program.SchoolRoomList.Where(r => classList.Any(c => c.Id == r.ClassId)).OrderBy(r => r.Sequence);
            // create columns and data structure for report
            DataTable dataTable = new();
            List<string> columns = new()
            {
                "N°",
                language == "FR" ? "CLASSE" : "CLASS",
                language == "FR" ? "NOMBRE D'ELEVES" : "NUMBER OF STUDENT",
                language == "FR" ? "COMPOSE" : "COMPOSED",
                language == "FR" ? "ABSTENTION" : "ABSTENTION",
                language == "FR" ? "MOYENNE GENERALE" : "GENERAL AVERAGE",
                language == "FR" ? "ADMIS" : "ADMITTED",
                language == "FR" ? "RECALE" : "FAILED",
                language == "FR" ? "% ADMIS" : "% ADMITED",
                language == "FR" ? "% RECALE" : "% FAILED",
            };
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Classroom", typeof(string));
            dataTable.Columns.Add("ClassSize", typeof(int));
            dataTable.Columns.Add("Composed", typeof(int));
            dataTable.Columns.Add("Abstention", typeof(int));
            dataTable.Columns.Add("GeneralAverage", typeof(double));
            dataTable.Columns.Add("Admitted", typeof(int));
            dataTable.Columns.Add("Failed", typeof(int));
            dataTable.Columns.Add("AdmittedP", typeof(double));
            dataTable.Columns.Add("FailedP", typeof(double));

            // injection des données
            int rowId = 1;
            int roomSizeSum = 0;
            double composedCountSum = 0;
            double abstentionCountSum = 0;
            double generalAverageSum = 0;
            double admittedCountSum = 0;
            double failedCountSum = 0;
            int composedClassCount = 0; // permet de calculer la moyenne générale du groupe
            foreach (var room in classroomList)
            {
                var averages = await localStudentNoteService.GetEvaluationAverageListByRoom(room.Id, evaluationId, schoolYearId, bookId);
                var roomSize = Program.StudentRoomList.Count(x => x.RoomId == room.Id && x.SchoolYearId == schoolYearId);
                roomSizeSum += roomSize;
                double composedCount = averages.Count;
                composedCountSum += composedCount;
                double abstentionCount = roomSize - composedCount;
                abstentionCountSum += abstentionCount;
                double generalAverage = composedCount > 0 ? averages.Sum(x => x.Average) / composedCount : 0;
                generalAverageSum += generalAverage;
                double admittedCount = averages.Count(x => x.Average >= 10);
                admittedCountSum += admittedCount;
                double failedCount = averages.Count(x => x.Average < 10);
                failedCountSum += failedCount;
                double admittedCountP = composedCount > 0 ? admittedCount * 100 / composedCount : 0;
                double failedCountP = composedCount > 0 ? failedCount * 100 / composedCount : 0;
                composedClassCount = composedCount > 0 ? composedClassCount + 1 : composedClassCount + 0;
                object[] row = new object[columns.Count];
                row[0] = rowId;
                row[1] = room.Name;
                row[2] = roomSize;
                row[3] = composedCount;
                row[4] = abstentionCount;
                row[5] = AppUtilities.GetTruncateOrRoundingValue(generalAverage, classGroup);
                row[6] = admittedCount;
                row[7] = failedCount;
                row[8] = Helper.RoundingValue(admittedCountP);
                row[9] = Helper.RoundingValue(failedCountP);
                dataTable.Rows.Add(row);
                rowId++;
            }
            double admittedCountFinalP = composedCountSum > 0 ? admittedCountSum * 100 / composedCountSum : 0;
            double failedCountFinalP = composedCountSum > 0 ? failedCountSum * 100 / composedCountSum : 0;
            object[] rowT = new object[columns.Count];
            rowT[0] = string.Empty;
            rowT[1] = "TOTAL";
            rowT[2] = roomSizeSum;
            rowT[3] = composedCountSum;
            rowT[4] = abstentionCountSum;
            rowT[5] = composedClassCount > 0 ? Helper.RoundingValue(generalAverageSum / composedClassCount) : 0;
            rowT[6] = admittedCountSum;
            rowT[7] = failedCountSum;
            rowT[8] = Helper.RoundingValue(admittedCountFinalP);
            rowT[9] = Helper.RoundingValue(failedCountFinalP);
            dataTable.Rows.Add(rowT);
            // create head report
            ClassGroupReportHeader headerSection = new(
                      new() {
                          new("Language",language),
                          new("ReportTitle",reportTitle),
                          new("SchoolYear",schoolYearLabel),
                          new("ClassGroup",classGroupLabel)
                      }, columns
                );
            //create detail of report
            ClassGroupReportDetail detailSection = new(dataTable);
            // create footer report         
            ReportFooter footerSection = new(
                      new() {
                          new(string.Empty,string.Empty),
                      }
                );

            return new(headerSection, detailSection, footerSection);
        }

        // Statistiques d'un trimestre d'un groupe de classes
        public async Task<ClassGroupReport> GetTermReportByClassGroupAsync(int groupId, int termId, int schoolYearId, int bookId)
        {
            // get data of head report

            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
            string termCode = term != null ? term.Code : string.Empty;
            var evaluations = Program.EvaluationSessionChildList.Where(x => x.Mother == term.Id);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == groupId);
            var reportTitle = $"STATISTIQUES {term.FrenchName}";
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var language = "FR";
            var schoolYearLabel = $"Année scolaire {schoolYear.Name}";
            var classGroupLabel = classGroup.Name;
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{term.EnglishName} STATISTIC REPORT";
                schoolYearLabel = $"Academic year {schoolYear.Name}";
                classGroupLabel = classGroup.Name;
                language = "EN";
            }
            // récupération des classes du groupe
            var classList = Program.SchoolClassList.Where(c => c.GroupId == groupId);
            // récupération des salles de classe du groupe
            var classroomList = Program.SchoolRoomList.Where(r => classList.Any(c => c.Id == r.ClassId)).OrderBy(r => r.Sequence);
            // create columns and data structure for report
            DataTable dataTable = new();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Classroom", typeof(string));
            dataTable.Columns.Add("ClassSize", typeof(int));

            List<string> columns = new()
            {
                "N°",
                language == "FR" ? "CLASSE" : "CLASS",
                language == "FR" ? "NOMBRE D'ELEVES" : "NUMBER OF STUDENT",
            };

            foreach (var eval in evaluations)
            {
                columns.Add(language == "FR" ? $"COMPOSE {eval.FrenchName}" : $"COMPOSED {eval.EnglishName}");
                columns.Add(language == "FR" ? $"ABSTENTION {eval.FrenchName}" : $"ABSTENTION {eval.EnglishName}");
                columns.Add(language == "FR" ? $"MOYENNE GENERALE {eval.FrenchName}" : $"GENERAL AVERAGE {eval.EnglishName}");
                columns.Add(language == "FR" ? $"ADMIS {eval.FrenchName}" : $"ADMITTED {eval.EnglishName}");
                columns.Add(language == "FR" ? $"RECALE {eval.FrenchName}" : $"FAILED {eval.EnglishName}");
                columns.Add(language == "FR" ? $"% ADMIS {eval.FrenchName}" : $"% ADMITED {eval.EnglishName}");
                columns.Add(language == "FR" ? $"% RECALE {eval.FrenchName}" : $"% FAILED {eval.EnglishName}");

                dataTable.Columns.Add($"Composed{eval.Code}", typeof(int));
                dataTable.Columns.Add($"Abstention{eval.Code}", typeof(int));
                dataTable.Columns.Add($"GeneralAverage{eval.Code}", typeof(double));
                dataTable.Columns.Add($"Admitted{eval.Code}", typeof(int));
                dataTable.Columns.Add($"Failed{eval.Code}", typeof(int));
                dataTable.Columns.Add($"AdmittedP{eval.Code}", typeof(double));
                dataTable.Columns.Add($"FailedP{eval.Code}", typeof(double));
            }

            columns.AddRange(
                new List<string>() {
                    language == "FR" ? "COMPOSE" : "COMPOSED",
                    language == "FR" ? "ABSTENTION" : "ABSTENTION",
                    language == "FR" ? "MOYENNE GENERALE" : "GENERAL AVERAGE",
                    language == "FR" ? "ADMIS" : "ADMITTED",
                    language == "FR" ? "RECALE" : "FAILED",
                    language == "FR" ? "% ADMIS" : "% ADMITED",
                    language == "FR" ? "% RECALE" : "% FAILED"
                }
                );

            dataTable.Columns.Add("Composed", typeof(int));
            dataTable.Columns.Add("Abstention", typeof(int));
            dataTable.Columns.Add("GeneralAverage", typeof(double));
            dataTable.Columns.Add("Admitted", typeof(int));
            dataTable.Columns.Add("Failed", typeof(int));
            dataTable.Columns.Add("AdmittedP", typeof(double));
            dataTable.Columns.Add("FailedP", typeof(double));
            Dictionary<SchoolRoom, Task<List<AverageRecord>>> getTermAveragesTask = new();
            Dictionary<(SchoolRoom, EvaluationSession), Task<List<AverageRecord>>> getEvaluationAveragesTask = new();
            // Création des lignes 
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var room in classroomList)
            {
                getTermAveragesTask.Add(room, localStudentNoteService.GetTermAverageListByRoom(room.Id, termCode, schoolYearId, bookId));
                foreach (var eval in evaluations)
                {
                    getEvaluationAveragesTask.Add((room, eval), localStudentNoteService.GetEvaluationAverageListByRoom(room.Id, eval.Id, schoolYearId, bookId));
                }
            }

            //watch.Stop();
            // Console.WriteLine($"Le temps de traitement est de {watch.ElapsedMilliseconds}");

            // injection des données
            int rowId = 1;
            int currentColum = 2;//
            double termStudentComposed = 0;
            int roomComposed = 0;
            object[] lastRow = new object[columns.Count]; // ligne des totaux
            // Initialisation de la ligne des totaux
            lastRow[0] = string.Empty;
            lastRow[1] = "TOTAL";
            for (int i = 2; i < columns.Count; i++)
            {
                lastRow[i] = 0;
            }
            foreach (var room in classroomList)
            {
                // extraction des moyennes de la classe
                if (getTermAveragesTask.TryGetValue(room, out Task<List<AverageRecord>> termTask))
                {
                    var roomSize = Program.StudentRoomList.Count(x => x.RoomId == room.Id && x.SchoolYearId == schoolYearId);
                    object[] row = new object[columns.Count];
                    row[0] = rowId; // numéro de la ligne
                    row[1] = room.Name;   // nom de la classe
                    row[2] = roomSize;  // effectif de la classe
                    lastRow[2] = int.Parse(lastRow[2].ToString()) + roomSize;

                    foreach (var eval in evaluations)
                    {
                        if (getEvaluationAveragesTask.TryGetValue((room, eval), out Task<List<AverageRecord>> evaluationTask))
                        {
                            var evaluationAverages = await evaluationTask;
                            double composedCount = evaluationAverages.Count;
                            double abstentionCount = roomSize - composedCount;
                            double generalAverage = composedCount > 0 ? evaluationAverages.Sum(x => x.Average) / composedCount : 0;
                            double admittedCount = evaluationAverages.Count(x => x.Average >= 10);
                            double failedCount = evaluationAverages.Count(x => x.Average < 10);
                            double admittedCountP = composedCount > 0 ? admittedCount * 100 / composedCount : 0;
                            double failedCountP = composedCount > 0 ? failedCount * 100 / composedCount : 0;

                            row[currentColum += 1] = composedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + composedCount;
                            row[currentColum += 1] = abstentionCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + abstentionCount;
                            row[currentColum += 1] = AppUtilities.GetTruncateOrRoundingValue(generalAverage, classGroup);
                            row[currentColum += 1] = admittedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + admittedCount;
                            row[currentColum += 1] = failedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + failedCount;
                            row[currentColum += 1] = Helper.RoundingValue(admittedCountP);
                            row[currentColum += 1] = Helper.RoundingValue(failedCountP);
                        }
                    }
                    var termAverages = await termTask;
                    double studentCount = termAverages.Count;
                    // Nombre d'élèves ayant composé
                    row[currentColum += 1] = studentCount;
                    lastRow[currentColum] = double.Parse(lastRow[currentColum].ToString()) + studentCount;
                    termStudentComposed += studentCount;
                    roomComposed = studentCount > 0 ? roomComposed + 1 : roomComposed;
                    // Nombre d'élèves n'ayant pas composé
                    row[currentColum += 1] = roomSize - studentCount;
                    lastRow[currentColum] = double.Parse(lastRow[currentColum].ToString()) + (roomSize - studentCount);
                    // moyenne général pour le trimestre 
                    var termGeneralAverage = studentCount > 0 ? Helper.RoundingValue(termAverages.Sum(x => x.Average) / studentCount) : 0;
                    row[currentColum += 1] = termGeneralAverage;
                    lastRow[currentColum] = termGeneralAverage + double.Parse(lastRow[currentColum].ToString());
                    // Nombre d'admis pour le trimestre
                    double termAdmittedCount = termAverages.Count(a => a.Average >= 10);
                    row[currentColum += 1] = termAdmittedCount;
                    lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + termAdmittedCount;
                    // Nombre de recalés pour le trimestre
                    double termFailedCount = termAverages.Count(a => a.Average < 10);
                    row[currentColum += 1] = termFailedCount;
                    lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + termFailedCount;
                    // Pourcentage des admis pour le trimestre
                    var termAdmittedCountP = studentCount > 0 ? Helper.RoundingValue(termAdmittedCount * 100 / studentCount) : 0;
                    row[currentColum += 1] = termAdmittedCountP;

                    // Pourcentage des recalés pour le trimestre
                    var termFailedCountP = studentCount > 0 ? Helper.RoundingValue(termFailedCount * 100 / studentCount) : 0;
                    row[currentColum += 1] = termFailedCountP;
                    dataTable.Rows.Add(row);
                    rowId++;
                    currentColum = 2;
                }
            }
            dataTable.Rows.Add(lastRow);

            // Mise à jour des totaux liés aux évaluations
            double averagesSum = 0;
            int averagesCount = 0;
            foreach (var eval in evaluations)
            {
                double admittedP = 0;
                double failedP = 0;
                if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Composed{eval.Code}"].ToString(), out double composedCount))
                {
                    if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Admitted{eval.Code}"].ToString(), out double admittedCount))
                    {
                        admittedP = composedCount > 0 ? admittedCount * 100 / composedCount : 0;
                    }
                    if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Failed{eval.Code}"].ToString(), out double failedCount))
                    {
                        failedP = composedCount > 0 ? failedCount * 100 / composedCount : 0;
                    }
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    var average = double.Parse(row[$"GeneralAverage{eval.Code}"].ToString());
                    averagesCount = average > 0 ? averagesCount + 1 : averagesCount;
                    averagesSum += average;

                }
                dataTable.Rows[classroomList.Count()][$"GeneralAverage{eval.Code}"] = Helper.RoundingValue(averagesCount > 0 ? averagesSum / averagesCount : 0);
                averagesSum = 0;
                averagesCount = 0;

                dataTable.Rows[classroomList.Count()][$"AdmittedP{eval.Code}"] = Helper.RoundingValue(admittedP);
                dataTable.Rows[classroomList.Count()][$"FailedP{eval.Code}"] = Helper.RoundingValue(failedP);
            }

            // Mise à jour des totaux liés au trimestre
            if (double.TryParse(dataTable.Rows[classroomList.Count()]["GeneralAverage"].ToString(), out double averageSum))
            {
                double average = roomComposed > 0 ? averageSum / roomComposed : 0;
                dataTable.Rows[classroomList.Count()]["GeneralAverage"] = Helper.RoundingValue(average);
            }

            if (double.TryParse(dataTable.Rows[classroomList.Count()]["Admitted"].ToString(), out double admittedSum))
            {
                double admittedP = termStudentComposed > 0 ? admittedSum * 100 / termStudentComposed : 0;
                dataTable.Rows[classroomList.Count()]["AdmittedP"] = Helper.RoundingValue(admittedP);
            }

            if (double.TryParse(dataTable.Rows[classroomList.Count()]["Failed"].ToString(), out double failedSum))
            {
                double failedP = termStudentComposed > 0 ? failedSum * 100 / termStudentComposed : 0;
                dataTable.Rows[classroomList.Count()]["FailedP"] = Helper.RoundingValue(failedP);
            }

            // create head report
            ClassGroupReportHeader headerSection = new(
                      new() {
                          new("Language",language),
                          new("ReportTitle",reportTitle),
                          new("SchoolYear",schoolYearLabel),
                          new("ClassGroup",classGroupLabel)
                      }, columns
                );
            //create detail of report
            ClassGroupReportDetail detailSection = new(dataTable);
            // create footer report         
            ReportFooter footerSection = new(
                      new() {
                          new(string.Empty,string.Empty),
                      }
                );

            return new(headerSection, detailSection, footerSection);
        }


        // Statistiques d'une  année d'un groupe de classes
        public async Task<ClassGroupReport> GetAnnualReportByClassGroupAsync(int groupId, int schoolYearId, int bookId)
        {
            // get data of head report

            var terms = Program.EvaluationSessionParentList;
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == groupId);
            var reportTitle = "STATISTIQUES ANNUELLES";
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var language = "FR";
            var schoolYearLabel = $"Année scolaire {schoolYear.Name}";
            var classGroupLabel = classGroup.Name;
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = "ANNUAL STATISTIC REPORT";
                schoolYearLabel = $"Academic year {schoolYear.Name}";
                classGroupLabel = classGroup.Name;
                language = "EN";
            }
            // récupération des classes du groupe
            var classList = Program.SchoolClassList.Where(c => c.GroupId == groupId);
            // récupération des salles de classe du groupe
            var classroomList = Program.SchoolRoomList.Where(r => classList.Any(c => c.Id == r.ClassId)).OrderBy(r => r.Sequence);
            // create columns and data structure for report
            DataTable dataTable = new();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Classroom", typeof(string));
            dataTable.Columns.Add("ClassSize", typeof(int));

            List<string> columns = new()
            {
                "N°",
                language == "FR" ? "CLASSE" : "CLASS",
                language == "FR" ? "NOMBRE D'ELEVES" : "NUMBER OF STUDENT",
            };

            foreach (var term in terms)
            {
                columns.Add(language == "FR" ? $"COMPOSE {term.FrenchName}" : $"COMPOSED {term.EnglishName}");
                columns.Add(language == "FR" ? $"ABSTENTION {term.FrenchName}" : $"ABSTENTION {term.EnglishName}");
                columns.Add(language == "FR" ? $"MOYENNE GENERALE {term.FrenchName}" : $"GENERAL AVERAGE {term.EnglishName}");
                columns.Add(language == "FR" ? $"ADMIS {term.FrenchName}" : $"ADMITTED {term.EnglishName}");
                columns.Add(language == "FR" ? $"RECALE {term.FrenchName}" : $"FAILED {term.EnglishName}");
                columns.Add(language == "FR" ? $"% ADMIS {term.FrenchName}" : $"% ADMITED {term.EnglishName}");
                columns.Add(language == "FR" ? $"% RECALE {term.FrenchName}" : $"% FAILED {term.EnglishName}");

                dataTable.Columns.Add($"Composed{term.Code}", typeof(int));
                dataTable.Columns.Add($"Abstention{term.Code}", typeof(int));
                dataTable.Columns.Add($"GeneralAverage{term.Code}", typeof(double));
                dataTable.Columns.Add($"Admitted{term.Code}", typeof(int));
                dataTable.Columns.Add($"Failed{term.Code}", typeof(int));
                dataTable.Columns.Add($"AdmittedP{term.Code}", typeof(double));
                dataTable.Columns.Add($"FailedP{term.Code}", typeof(double));
            }

            columns.AddRange(
                new List<string>() {
                    language == "FR" ? "COMPOSE" : "COMPOSED",
                    language == "FR" ? "ABSTENTION" : "ABSTENTION",
                    language == "FR" ? "MOYENNE GENERALE" : "GENERAL AVERAGE",
                    language == "FR" ? "ADMIS" : "ADMITTED",
                    language == "FR" ? "RECALE" : "FAILED",
                    language == "FR" ? "% ADMIS" : "% ADMITED",
                    language == "FR" ? "% RECALE" : "% FAILED"
                }
                );

            dataTable.Columns.Add("Composed", typeof(int));
            dataTable.Columns.Add("Abstention", typeof(int));
            dataTable.Columns.Add("GeneralAverage", typeof(double));
            dataTable.Columns.Add("Admitted", typeof(int));
            dataTable.Columns.Add("Failed", typeof(int));
            dataTable.Columns.Add("AdmittedP", typeof(double));
            dataTable.Columns.Add("FailedP", typeof(double));
            Dictionary<SchoolRoom, Task<List<AverageRecord>>> getAnnualAveragesTask = new();
            Dictionary<(SchoolRoom, EvaluationSession), Task<List<AverageRecord>>> getTermAveragesTask = new();
            // Création des lignes 
            foreach (var room in classroomList)
            {
                getAnnualAveragesTask.Add(room, localStudentNoteService.GetAnnualAverageListByRoom(room.Id, schoolYearId, bookId));
                foreach (var term in terms)
                {
                    getTermAveragesTask.Add((room, term), localStudentNoteService.GetTermAverageListByRoom(room.Id, term.Code, schoolYearId, bookId));
                }
            }
            var annualAveragesTaskResult = await Task.WhenAll(getAnnualAveragesTask.Values);
            var termAveragesTaskResult = await Task.WhenAll(getTermAveragesTask.Values);
            // injection des données
            int rowId = 1;
            int currentColum = 2;//
            double annualtudentComposed = 0;
            int roomComposed = 0;
            object[] lastRow = new object[columns.Count]; // ligne des totaux
            // Initialisation de la ligne des totaux
            lastRow[0] = string.Empty;
            lastRow[1] = "TOTAL";
            for (int i = 2; i < columns.Count; i++)
            {
                lastRow[i] = 0;
            }

            foreach (var room in classroomList)
            {
                if (getAnnualAveragesTask.TryGetValue(room, out Task<List<AverageRecord>> annualTask))
                {
                    var roomSize = Program.StudentRoomList.Count(x => x.RoomId == room.Id && x.SchoolYearId == schoolYearId);
                    object[] row = new object[columns.Count];
                    row[0] = rowId; // numéro de la ligne
                    row[1] = room.Name;   // nom de la classe
                    row[2] = roomSize;  // effectif de la classe
                    lastRow[2] = int.Parse(lastRow[2].ToString()) + roomSize;
                    //extraction des moyennes de la classe

                    foreach (var term in terms)
                    {
                        if (getTermAveragesTask.TryGetValue((room, term), out Task<List<AverageRecord>> termTask))
                        {
                            var termAverages = await termTask;
                            double composedCount = termAverages.Count;
                            double abstentionCount = roomSize - composedCount;
                            double generalAverage = composedCount > 0 ? termAverages.Sum(x => x.Average) / composedCount : 0;
                            double admittedCount = termAverages.Count(x => x.Average >= 10);
                            double failedCount = termAverages.Count(x => x.Average < 10);
                            double admittedCountP = composedCount > 0 ? admittedCount * 100 / composedCount : 0;
                            double failedCountP = composedCount > 0 ? failedCount * 100 / composedCount : 0;

                            row[currentColum += 1] = composedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + composedCount;
                            row[currentColum += 1] = abstentionCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + abstentionCount;
                            row[currentColum += 1] = AppUtilities.GetTruncateOrRoundingValue(generalAverage, classGroup);
                            row[currentColum += 1] = admittedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + admittedCount;
                            row[currentColum += 1] = failedCount;
                            lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + failedCount;
                            row[currentColum += 1] = Helper.RoundingValue(admittedCountP);
                            row[currentColum += 1] = Helper.RoundingValue(failedCountP);
                        }
                    }
                    var annualAverages = await annualTask;
                    double studentCount = annualAverages.Count;
                    // Nombre d'élèves ayant composé
                    row[currentColum += 1] = studentCount;
                    lastRow[currentColum] = double.Parse(lastRow[currentColum].ToString()) + studentCount;
                    annualtudentComposed += studentCount;
                    roomComposed = studentCount > 0 ? roomComposed + 1 : roomComposed;
                    // Nombre d'élèves n'ayant pas composé
                    row[currentColum += 1] = roomSize - studentCount;
                    lastRow[currentColum] = double.Parse(lastRow[currentColum].ToString()) + (roomSize - studentCount);
                    // moyenne général pour le trimestre 
                    var termGeneralAverage = studentCount > 0 ? Helper.RoundingValue(annualAverages.Sum(x => x.Average) / studentCount) : 0;
                    row[currentColum += 1] = termGeneralAverage;
                    lastRow[currentColum] = termGeneralAverage + double.Parse(lastRow[currentColum].ToString());
                    // Nombre d'admis pour le trimestre
                    double termAdmittedCount = annualAverages.Count(a => a.Average >= 10);
                    row[currentColum += 1] = termAdmittedCount;
                    lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + termAdmittedCount;
                    // Nombre de recalés pour le trimestre
                    double termFailedCount = annualAverages.Count(a => a.Average < 10);
                    row[currentColum += 1] = termFailedCount;
                    lastRow[currentColum] = int.Parse(lastRow[currentColum].ToString()) + termFailedCount;
                    // Pourcentage des admis pour le trimestre
                    var termAdmittedCountP = studentCount > 0 ? Helper.RoundingValue(termAdmittedCount * 100 / studentCount) : 0;
                    row[currentColum += 1] = termAdmittedCountP;

                    // Pourcentage des recalés pour le trimestre
                    var termFailedCountP = studentCount > 0 ? Helper.RoundingValue(termFailedCount * 100 / studentCount) : 0;
                    row[currentColum += 1] = termFailedCountP;
                    dataTable.Rows.Add(row);
                    rowId++;
                    currentColum = 2;

                }
            }
            dataTable.Rows.Add(lastRow);

            // Mise à jour des totaux liés aux évaluations
            double averagesSum = 0;
            int averagesCount = 0;
            foreach (var term in terms)
            {
                double admittedP = 0;
                double failedP = 0;
                if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Composed{term.Code}"].ToString(), out double composedCount))
                {
                    if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Admitted{term.Code}"].ToString(), out double admittedCount))
                    {
                        admittedP = composedCount > 0 ? admittedCount * 100 / composedCount : 0;
                    }
                    if (double.TryParse(dataTable.Rows[classroomList.Count()][$"Failed{term.Code}"].ToString(), out double failedCount))
                    {
                        failedP = composedCount > 0 ? failedCount * 100 / composedCount : 0;
                    }
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    var average = double.Parse(row[$"GeneralAverage{term.Code}"].ToString());
                    averagesCount = average > 0 ? averagesCount + 1 : averagesCount;
                    averagesSum += average;

                }
                dataTable.Rows[classroomList.Count()][$"GeneralAverage{term.Code}"] = Helper.RoundingValue(averagesCount > 0 ? averagesSum / averagesCount : 0);
                averagesSum = 0;
                averagesCount = 0;

                dataTable.Rows[classroomList.Count()][$"AdmittedP{term.Code}"] = Helper.RoundingValue(admittedP);
                dataTable.Rows[classroomList.Count()][$"FailedP{term.Code}"] = Helper.RoundingValue(failedP);
            }

            // Mise à jour des totaux liés au trimestre
            if (double.TryParse(dataTable.Rows[classroomList.Count()]["GeneralAverage"].ToString(), out double averageSum))
            {
                double average = roomComposed > 0 ? averageSum / roomComposed : 0;
                dataTable.Rows[classroomList.Count()]["GeneralAverage"] = Helper.RoundingValue(average);
            }

            if (double.TryParse(dataTable.Rows[classroomList.Count()]["Admitted"].ToString(), out double admittedSum))
            {
                double admittedP = annualtudentComposed > 0 ? admittedSum * 100 / annualtudentComposed : 0;
                dataTable.Rows[classroomList.Count()]["AdmittedP"] = Helper.RoundingValue(admittedP);
            }

            if (double.TryParse(dataTable.Rows[classroomList.Count()]["Failed"].ToString(), out double failedSum))
            {
                double failedP = annualtudentComposed > 0 ? failedSum * 100 / annualtudentComposed : 0;
                dataTable.Rows[classroomList.Count()]["FailedP"] = Helper.RoundingValue(failedP);
            }

            // create head report
            ClassGroupReportHeader headerSection = new(
                      new() {
                          new("Language",language),
                          new("ReportTitle",reportTitle),
                          new("SchoolYear",schoolYearLabel),
                          new("ClassGroup",classGroupLabel)
                      }, columns
                );
            //create detail of report
            ClassGroupReportDetail detailSection = new(dataTable);
            // create footer report         
            ReportFooter footerSection = new(
                      new() {
                          new(string.Empty,string.Empty),
                      }
                );

            return new(headerSection, detailSection, footerSection);
        }

        // Fiche de discipline d'un élève
        public async Task<StudentDisciplinarySheet> GetDisciplinarySheetByStudent(int studentId, int roomId, int schoolYearId, int bookId)
        {
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == studentId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByClass(classOfRoom.Id, schoolYearId);
            var getFirstTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM03", schoolYearId, bookId);
            var getAnnualAverages = localStudentNoteService.GetAnnualAverageListByRoom(roomId, schoolYearId, bookId);

            var teacherName = string.Empty;
            if (teacher != null)
            {
                teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
            }
            var reportTitle = "FICHE INDIVIDUELLE DE DISCIPLINE";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = "STUDENT DISCIPLINARY SHEET";
                language = "EN";
                if (teacher != null)
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }
            // create head of report card
            var headSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom, teacherName, language, string.Empty,null);

            // create detail section
            var disciplineItems = await getDisciplinesTask;
            var firstTermAverages = await getFirstTermAverages;
            var firstTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == studentId && x.Date.Month >= 9 && x.Date.Month <= 12);
            var firstTermStudentAverage = firstTermAverages.Find(x => x.Student.Id == studentId);
            var firstTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(firstTermAverages.Count > 0 ? firstTermAverages.Sum(x => x.Average) / firstTermAverages.Count : 0, classGroup);

            var FirstTermDisciplineItem = new TermDisciplineItem(
                firstTermStudentDisciplineItem.ToList(),
                firstTermStudentAverage != null ? firstTermStudentAverage.Average.ToString() : string.Empty,
                firstTermStudentAverage != null ? firstTermStudentAverage.Position : string.Empty,
                firstTermClassAverage.ToString()
                );

            var secondTermAverages = await getSecondTermAverages;
            var secondTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == studentId && x.Date.Month >= 1 && x.Date.Month <= 3);
            var secondTermStudentAverage = secondTermAverages.Find(x => x.Student.Id == studentId);
            var secondTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(secondTermAverages.Count > 0 ? secondTermAverages.Sum(x => x.Average) / secondTermAverages.Count : 0, classGroup);

            var SecondTermDisciplineItem = new TermDisciplineItem(
                secondTermStudentDisciplineItem.ToList(),
                secondTermStudentAverage != null ? secondTermStudentAverage.Average.ToString() : string.Empty,
                secondTermStudentAverage != null ? secondTermStudentAverage.Position : string.Empty,
                secondTermClassAverage.ToString()
                );

            var thirdTermAverages = await getThirdTermAverages;
            var thirdTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == studentId && x.Date.Month >= 4 && x.Date.Month <= 6);
            var thirdTermStudentAverage = thirdTermAverages.Find(x => x.Student.Id == studentId);
            var thirdTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(thirdTermAverages.Count > 0 ? thirdTermAverages.Sum(x => x.Average) / thirdTermAverages.Count : 0, classGroup);

            var ThirdTermDisciplineItem = new TermDisciplineItem(
                thirdTermStudentDisciplineItem.ToList(),
                thirdTermStudentAverage != null ? thirdTermStudentAverage.Average.ToString() : string.Empty,
                thirdTermStudentAverage != null ? thirdTermStudentAverage.Position : string.Empty,
                thirdTermClassAverage.ToString()
                );
            var annualAverages = await getAnnualAverages;

            List<DisciplineItemRecord> annualTermStudentDisciplineItem = new();
            annualTermStudentDisciplineItem.AddRange(firstTermStudentDisciplineItem);
            annualTermStudentDisciplineItem.AddRange(secondTermStudentDisciplineItem);
            annualTermStudentDisciplineItem.AddRange(thirdTermStudentDisciplineItem);
            var annualStudentAverage = annualAverages.Find(x => x.Student.Id == student.Id);
            var annualClassAverage = AppUtilities.GetTruncateOrRoundingValue(annualAverages.Count > 0 ? annualAverages.Sum(x => x.Average) / annualAverages.Count : 0, classGroup);
            var AnnualDisciplineItem = new AnnualDisciplineItem(
                annualTermStudentDisciplineItem,
                annualStudentAverage != null ? annualStudentAverage.Average.ToString() : string.Empty,
                annualStudentAverage != null ? annualStudentAverage.Position : string.Empty,
                annualClassAverage.ToString()
                );
            var disciplineScheetReportDetail = new DisciplineScheetReportDetail(
                FirstTermDisciplineItem,
                SecondTermDisciplineItem,
                ThirdTermDisciplineItem,
                AnnualDisciplineItem
                );

            return new StudentDisciplinarySheet(headSection, disciplineScheetReportDetail, null);
        }

        // Fiche de discipline d'une salle de classe
        public async Task<List<StudentDisciplinarySheet>> GetDisciplinarySheetByClassRoom(int roomId, int schoolYearId, int bookId)
        {
            List<StudentDisciplinarySheet> reportSheets = new();
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            var getDisciplinesTask = localStudentNoteService.GetDisciplineItemsByClass(classOfRoom.Id, schoolYearId);
            var getFirstTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM01", schoolYearId, bookId);
            var getSecondTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM02", schoolYearId, bookId);
            var getThirdTermAverages = localStudentNoteService.GetTermAverageListByRoom(roomId, "TERM03", schoolYearId, bookId);
            var getAnnualAverages = localStudentNoteService.GetAnnualAverageListByRoom(roomId, schoolYearId, bookId);
            var teacherName = string.Empty;
            if (teacher != null)
            {
                teacherName = teacher.Employee.Sex == "M" ? $"M.  {teacher.Employee.FullName}" : $"Mme.  {teacher.Employee.FullName}";
            }
            var reportTitle = "FICHE INDIVIDUELLE DE DISCIPLINE";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = "STUDENT DISCIPLINARY SHEET";
                language = "EN";
                if (teacher != null)
                {
                    teacherName = teacher.Employee.Sex == "M" ? $"Mr.  {teacher.Employee.FullName}" : $"Mrs.  {teacher.Employee.FullName}";
                }
            }

            var students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == roomId).Select(x => x.Student).OrderBy(x => x.FullName).ToList();

            var disciplineItems = await getDisciplinesTask;
            var firstTermAverages = await getFirstTermAverages;
            var secondTermAverages = await getSecondTermAverages;
            var thirdTermAverages = await getThirdTermAverages;
            var annualAverages = await getAnnualAverages;
            foreach (var student in students)
            {
                // create head of report card
                var headSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom, teacherName, language, string.Empty,null);

                // create detail section
                var firstTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == student.Id && x.Date.Month >= 9 && x.Date.Month <= 12);
                var firstTermStudentAverage = firstTermAverages.Find(x => x.Student.Id == student.Id);
                var firstTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(firstTermAverages.Count > 0 ? firstTermAverages.Sum(x => x.Average) / firstTermAverages.Count : 0, classGroup);

                var FirstTermDisciplineItem = new TermDisciplineItem(
                    firstTermStudentDisciplineItem.ToList(),
                    firstTermStudentAverage != null ? firstTermStudentAverage.Average.ToString() : string.Empty,
                    firstTermStudentAverage != null ? firstTermStudentAverage.Position : string.Empty,
                    firstTermClassAverage.ToString()
                    );

                var secondTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == student.Id && x.Date.Month >= 1 && x.Date.Month <= 3);
                var secondTermStudentAverage = secondTermAverages.Find(x => x.Student.Id == student.Id);
                var secondTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(secondTermAverages.Count > 0 ? secondTermAverages.Sum(x => x.Average) / secondTermAverages.Count : 0, classGroup);

                var SecondTermDisciplineItem = new TermDisciplineItem(
                    secondTermStudentDisciplineItem.ToList(),
                    secondTermStudentAverage != null ? secondTermStudentAverage.Average.ToString() : string.Empty,
                    secondTermStudentAverage != null ? secondTermStudentAverage.Position : string.Empty,
                    secondTermClassAverage.ToString()
                    );

                var thirdTermStudentDisciplineItem = disciplineItems.Where(x => x.Student.Id == student.Id && x.Date.Month >= 4 && x.Date.Month <= 6);
                var thirdTermStudentAverage = thirdTermAverages.Find(x => x.Student.Id == student.Id);
                var thirdTermClassAverage = AppUtilities.GetTruncateOrRoundingValue(thirdTermAverages.Count > 0 ? thirdTermAverages.Sum(x => x.Average) / thirdTermAverages.Count : 0, classGroup);

                var ThirdTermDisciplineItem = new TermDisciplineItem(
                    thirdTermStudentDisciplineItem.ToList(),
                    thirdTermStudentAverage != null ? thirdTermStudentAverage.Average.ToString() : string.Empty,
                    thirdTermStudentAverage != null ? thirdTermStudentAverage.Position : string.Empty,
                    thirdTermClassAverage.ToString()
                    );

                List<DisciplineItemRecord> annualTermStudentDisciplineItem = new();
                annualTermStudentDisciplineItem.AddRange(firstTermStudentDisciplineItem);
                annualTermStudentDisciplineItem.AddRange(secondTermStudentDisciplineItem);
                annualTermStudentDisciplineItem.AddRange(thirdTermStudentDisciplineItem);
                var annualStudentAverage = annualAverages.Find(x => x.Student.Id == student.Id);
                var annualClassAverage = AppUtilities.GetTruncateOrRoundingValue(annualAverages.Count > 0 ? annualAverages.Sum(x => x.Average) / annualAverages.Count : 0, classGroup);
                var AnnualDisciplineItem = new AnnualDisciplineItem(
                    annualTermStudentDisciplineItem,
                    annualStudentAverage != null ? annualStudentAverage.Average.ToString() : string.Empty,
                    annualStudentAverage != null ? annualStudentAverage.Position : string.Empty,
                    annualClassAverage.ToString()
                    );

                var disciplineScheetReportDetail = new DisciplineScheetReportDetail(
                    FirstTermDisciplineItem,
                    SecondTermDisciplineItem,
                    ThirdTermDisciplineItem,
                    AnnualDisciplineItem
                    );

                reportSheets.Add(new(headSection, disciplineScheetReportDetail, null));
            }



            return reportSheets;
        }

    }
}
