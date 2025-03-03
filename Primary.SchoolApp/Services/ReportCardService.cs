

using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using System;
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
        public ReportCardService(LocalStudentNoteService localStudentNoteService)
        {
            this.localStudentNoteService = localStudentNoteService;
        }
        //bulletin scolaire d'une évaluation d'un élève
        public async Task<EvaluationReportCard> GetEvaluationReportCardByStudentAsync(int studentId, int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            // extraction des moyennes de la classe
            var evaluationAverageTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
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
            // create head of report card
            var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, teacherName, language, evaluation.Code);
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
            var footerSection = new EvaluationFooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage);
            #endregion
            return new EvaluationReportCard(headReportSection, detailSection, footerSection);
        }
        //bulletin  trimestrielle d'un élève
        public async Task<TermReportCard> GetTermReportCardByStudentAsync(int studentId, int roomId, int termId, int schoolYearId, int bookId)
        {
            
            var term= Program.EvaluationSessionList.FirstOrDefault(x => x.Id==termId);
            string termCode = term!=null?term.Code:string.Empty ;
            var evaluationCodes = LocalStudentNoteService.GetEvaluationCodeOfTerm(termCode);
            var eval01 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval02 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval03 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            // Extraction des notes du trimestre
            var term_notes_task = localStudentNoteService.GetTermNoteListByRoom(roomId, schoolYearId, bookId,termCode);
            var term_averages_task = localStudentNoteService.GetTermAverageListByRoom(roomId, schoolYearId, bookId,termCode);
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
            // create head of report card
            var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, teacherName, language, termCode);
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

            double sumFinalNote = AppUtilities.RoundingValue(student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.FinalNote));
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
            string secondMonthPosition = eval02_averages_student != null ? eval02_averages_student.Position : string.Empty;
            footerItems.Add(new("SecondMonthPosition", secondMonthPosition));
            string thirdMonthPosition = eval03_averages_student != null ? eval03_averages_student.Position : string.Empty;
            footerItems.Add(new("ThirdMonthPosition", thirdMonthPosition));
            string termPosition = term_averages_student != null ? term_averages_student.Position : string.Empty;
            footerItems.Add(new("TermPosition", termPosition));
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
            var footerSection = new ReportFooter(footerItems);
            #endregion
            return new TermReportCard(headReportSection, detailSection, footerSection);
        }

        //bulletins scolaires d'une évaluation d'une salle de classe
        public async Task<List<EvaluationReportCard>> GetEvaluationReportCardByClassRoomAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            List<EvaluationReportCard> result = new();
            // extraction des moyennes de la classe
            var evaluationAverageList = await localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            //extraction des notes de la classe;
            var evaluationNoteList = await localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var reportTitle = $"BULLETIN {evaluation.FrenchName}";
            var language = "FR";
            if (classGroup.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} SUMMARY MARK";
                language = "EN";
            }
            //extraction de la liste des élèves ayant composé
            var students = evaluationAverageList.Select(x => x.Student).ToList();
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id);
            //extraction des groupes de matières de la classe de l'élève
            var groupList = classroomSujectList.Where(x => x.BookId == bookId).OrderBy(x => x.Sequence).Select(x => x.Group).DistinctBy(x => x.Id).ToList();

            foreach (var student in students)
            {
                // create head of report card
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, "", language, evaluation.Code);
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
                var footerSection = new EvaluationFooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage);
                #endregion
                result.Add(new EvaluationReportCard(headReportSection, detailSection, footerSection));
            }
            return result;
        }
        //bulletins scolaires d'un trimestre d'une salle de classe
        public async Task<List<TermReportCard>> GetTermReportCardByClassRoomAsync(int roomId, int termId, int schoolYearId, int bookId)
        {
            List<TermReportCard> reportCards = new();
            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
            string termCode = term != null ? term.Code : string.Empty;
            var evaluationCodes = LocalStudentNoteService.GetEvaluationCodeOfTerm(termCode);
            var eval01 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("FirstMonth"));
            var eval02 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("SecondMonth"));
            var eval03 = Program.EvaluationSessionList.FirstOrDefault(x => x.Code == evaluationCodes.GetValueOrDefault("ThirdMonth"));
            // Extraction des notes du trimestre
            var term_notes_task = localStudentNoteService.GetTermNoteListByRoom(roomId, schoolYearId, bookId, termCode);
            var term_averages_task = localStudentNoteService.GetTermAverageListByRoom(roomId, schoolYearId, bookId, termCode);
            // extraction des moyennes des évaluations
            var eval01_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval01 != null ? eval01.Id : 100, schoolYearId, bookId);
            var eval02_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval02 != null ? eval02.Id : 100, schoolYearId, bookId);
            var eval03_averages_task = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, eval03 != null ? eval03.Id : 100, schoolYearId, bookId);
            // Récupération des info de la salle de classe;
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var classGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == classOfRoom.GroupId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var teacher = Program.EmployeeRoomList.FirstOrDefault(x => x.RoomId == roomId && x.IsMasterRoom && x.DefaultSection == bookId);
            //extraction des matières avec note max et groupe de la classe de l'élève
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id);
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

            // Production des bulletins
            foreach (var student in students) {
                var student_notes = term_notes.Where(x => x.Student.Id == student.Id).ToList();
                // create head of report card
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, teacherName, language, termCode);
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

                double sumFinalNote = AppUtilities.RoundingValue(student_notes.Where(x => x.FinalNoteAsString != string.Empty).Sum(x => x.FinalNote));
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
                string secondMonthPosition = eval02_averages_student != null ? eval02_averages_student.Position : string.Empty;
                footerItems.Add(new("SecondMonthPosition", secondMonthPosition));
                string thirdMonthPosition = eval03_averages_student != null ? eval03_averages_student.Position : string.Empty;
                footerItems.Add(new("ThirdMonthPosition", thirdMonthPosition));
                string termPosition = term_averages_student != null ? term_averages_student.Position : string.Empty;
                footerItems.Add(new("TermPosition", termPosition));
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
            var getAveragesTask = localStudentNoteService.GetTermAverageListByRoom(roomId,schoolYearId,bookId,termCode);
            var getNotesTask = localStudentNoteService.GetTermNoteListByRoom(roomId,schoolYearId,bookId,termCode);
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
                    row[columnId] = evaluationLine != null ? evaluationLine.FinalNoteAsString: string.Empty;
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
                          new("PassedFemale",AppUtilities.RoundingValue(passedFemale).ToString()),
                          new("PassedMale", AppUtilities.RoundingValue(passedMale).ToString()),
                          new("PassedTotal",AppUtilities.RoundingValue(passedTotal).ToString()),
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
            var classroomList = Program.SchoolRoomList.Where(r => classList.Any(c => c.Id == r.ClassId)).OrderBy(r => r.Name);
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
                row[8] = AppUtilities.RoundingValue(admittedCountP);
                row[9] = AppUtilities.RoundingValue(failedCountP);
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
            rowT[5] = composedClassCount > 0 ? AppUtilities.RoundingValue(generalAverageSum / composedClassCount) : 0;
            rowT[6] = admittedCountSum;
            rowT[7] = failedCountSum;
            rowT[8] = AppUtilities.RoundingValue(admittedCountFinalP);
            rowT[9] = AppUtilities.RoundingValue(failedCountFinalP);
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

        // Statistiques d'une évaluation d'un groupe de classes
        public async Task<ClassGroupReport> GetTermReportByClassGroupAsync(int groupId, int termId, int schoolYearId, int bookId)
        {
            // get data of head report

            var term = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == termId);
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
            var classroomList = Program.SchoolRoomList.Where(r => classList.Any(c => c.Id == r.ClassId)).OrderBy(r => r.Name);
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
                var averages = await localStudentNoteService.GetTermAverageListByRoom(room.Id,schoolYearId, bookId,term.Code);
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
                row[8] = AppUtilities.RoundingValue(admittedCountP);
                row[9] = AppUtilities.RoundingValue(failedCountP);
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
            rowT[5] = composedClassCount > 0 ? AppUtilities.RoundingValue(generalAverageSum / composedClassCount) : 0;
            rowT[6] = admittedCountSum;
            rowT[7] = failedCountSum;
            rowT[8] = AppUtilities.RoundingValue(admittedCountFinalP);
            rowT[9] = AppUtilities.RoundingValue(failedCountFinalP);
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

    }
}
