

using Org.BouncyCastle.Utilities;
using Primary.SchoolApp.Utilities;
using SchoolManagement.Core.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Telerik.WinControls.VirtualKeyboard;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;
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
        public async Task<ReportCard> GetEvaluationReportCardByStudentAsync(int studentId, int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            // extraction des moyennes de la classe
            var evaluationAverageTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            #region Head Report
            // get data of head report
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var student = Program.StudentEnrollingList.Select(x => x.Student).FirstOrDefault(x => x.Id == studentId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var reportTitle = $"BULLETIN {evaluation.FrenchName}";
            var language = "FR";
            if (classOfRoom.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} SUMMARY MARK";
                language = "EN";
            }
            // create head of report card
            var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, "", language);
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
            var detailSection = new DetailReportCard(studentNoteList, groupList);
            #endregion
            #region Footer Report
            // calcul de la moyenne
            double sumCoef = 0;//somme de coefficients
            double sumNote = 0;// somme de notes
            double sumMaxNote = 0;
            double average = 0;
            if (classOfRoom.AverageFormula == 0)
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
            double classAverage = classOfRoom.NoteIsTruncate == false ? double.Parse(cAverage.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(cAverage, 2);
            var footerSection = new FooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage);
            #endregion
            return new ReportCard(headReportSection, detailSection, footerSection);
        }

        //bulletins scolaires d'une évaluation d'une salle de classe
        public async Task<List<ReportCard>> GetEvaluationReportCardByRoomAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            List<ReportCard> result = new List<ReportCard>();
            // extraction des moyennes de la classe
            var evaluationAverageList = await localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            //extraction des notes de la classe;
            var evaluationNoteList = await localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var reportTitle = $"BULLETIN {evaluation.FrenchName}";
            var language = "FR";
            if (classOfRoom.DocumentLanguageId == 1 || bookId == 1)
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
                var headReportSection = new HeadReportCard(reportTitle, schoolYear.Name, student, classroom.Name, "", language);
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
                var detailSection = new DetailReportCard(studentNoteList, groupList);
                #endregion

                #region Footer Report
                // calcul de la moyenne
                double sumCoef = 0;//somme de coefficients
                double sumNote = 0;// somme de notes
                double sumMaxNote = 0;
                double average = 0;
                if (classOfRoom.AverageFormula == 0)
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
                double classAverage = classOfRoom.NoteIsTruncate == false ? double.Parse(cAverage.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(cAverage, 2);
                var footerSection = new FooterReportCard(sumNote, sumCoef, sumMaxNote, average, position, classAverage, highestAverage, lowestAverage);
                #endregion
                result.Add(new ReportCard(headReportSection, detailSection, footerSection));
            }
            return result;
        }
        // Procès verbal d'une salle de classe
        public async Task<ClassroomReport> GetClassroomReportAsync(int roomId, int evaluationId, int schoolYearId, int bookId)
        {
            // extraction des moyennes de la classe
            var getAveragesTask = localStudentNoteService.GetEvaluationAverageListByRoom(roomId, evaluationId, schoolYearId, bookId);
            var getNotesTask = localStudentNoteService.GetEvaluationNoteListByRoom(roomId, evaluationId, schoolYearId, bookId);
            // get data of head report
            var evaluation = Program.EvaluationSessionList.FirstOrDefault(x => x.Id == evaluationId);
            var classroom = Program.SchoolRoomList.FirstOrDefault(x => x.Id == roomId);
            var classOfRoom = Program.SchoolClassList.FirstOrDefault(x => x.Id == classroom.ClassId);
            var schoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == schoolYearId);
            var totalStudent = Program.StudentRoomList.Count(x => x.SchoolYearId == schoolYearId && x.RoomId == roomId);
            var reportTitle = $"PROCE VERBAL {evaluation.FrenchName}";
            var classroomSizeLabel = $"Effectif: {totalStudent} ";
            var schoolYearLabel = $"Année scolaire: {schoolYear.Name}";
            var classroomLabel = $"Classe: {classroom.Name}";
            //extraction des matières avec note max et groupe de la classe 
            var classroomSujectList = Program.ClassSubjectList.Where(x => x.ClassId == classOfRoom.Id && x.BookId == bookId).OrderBy(x => x.Sequence);
            var sumMaxOrCoef = classOfRoom.AverageFormula == 0 ? $"Total des notes max: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total des coefficients:{classroomSujectList.Sum(x => x.Coefficient)}";
            var language = "FR";
            if (classOfRoom.DocumentLanguageId == 1 || bookId == 1)
            {
                reportTitle = $"{evaluation.EnglishName} CLASS REPORT";
                classroomSizeLabel = $"N° on roll: {totalStudent} ";
                schoolYearLabel = $"Academic year: {schoolYear.Name}";
                classroomLabel = $"Class: {classroom.Name}";
                sumMaxOrCoef = classOfRoom.AverageFormula == 0 ? $"Total of max mark: {classroomSujectList.Sum(x => x.NotedOn)}" : $"Total of coefficient:{classroomSujectList.Sum(x => x.Coefficient)}";
                language = "EN";
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
                language == "FR" ? "SEXE" : "SEX"
            };
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Student", typeof(string));
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
                finalName = classOfRoom.AverageFormula == 0 ? $"{subjectName} \n Max: {item.NotedOn}" : $"{subjectName} \n Coef: {item.NoteCoef}";
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
                row[2] = student.Sex;
                int columnId = 3;
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
                          new("ClassRoomSize",classroomSizeLabel),
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
            var averageFemale = averages.Count(x => x.Student.Sex == "F" && x.Average>=10);
            var averageMale = averages.Count(x => x.Student.Sex == "M" && x.Average >= 10);
            var averageTotal = averages.Count(x => x.Average >= 10);
            var passedFemale = averageFemale * 100 / evaluatedFemale;
            var passedMale = averageMale * 100 / evaluatedMale;
            var passedTotal = averageTotal * 100 / evaluatedTotal;
            var classroomSizeDescription = language == "FR" ? "M: Maculin, F: Féminin, T: Total" : "M: Male, F: Female, T: Total";
            var generalAverageLabel = language == "FR" ? "Moyenne générale" : "General average";
            var ga = (averages.Sum(x => x.Average) / evaluatedTotal);
            var gaf = classOfRoom.NoteIsTruncate == false ? double.Parse(ga.ToString("F", System.Globalization.CultureInfo.CurrentCulture)) : AppUtilities.TruncateDouble(ga, 2);
            var generalAverage =$"{generalAverageLabel}: {gaf}" ;
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
    }
}
