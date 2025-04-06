using System;
using System.Collections.Generic;
using System.Linq;
using static Primary.SchoolApp.DTO.DTOItem;

namespace Primary.SchoolApp.Reporting
{
    internal class DisciplinarySheetReport : SchoolManagement.UI.Reporting.DisciplinarySheetReport
    {
        public DisciplinarySheetReport(StudentDisciplinarySheet report)
        {
            string language = report.HeadSection.Language;
            InitLanguage(language);
            string img = language == "FR" ? "head_paper_fr.png" : "head_paper_en.png";
            string schoolYearLabel = language == "FR" ? "Année scolaire" : "School year";
            SchoolYearTextBox.Value = $"{schoolYearLabel}: {report.HeadSection.SchoolYear}";
            HeaderPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl(img);
            ReportTitleTextBox.Value = report.HeadSection.ReportTitle;
            StudentTextBox.Value = report.HeadSection.Student.FullName;
            StudentIdTextBox.Value = report.HeadSection.Student.IdNumber;
            ClassTextBox.Value = report.HeadSection.ClassRoom.Name;
            string bornLabel = report.HeadSection.Student.Sex == "M" ? "Né le " : "Née le ";
            string bornValueEN= BornTextBox.Value = "Born on" + report.HeadSection.Student.BirthDate.ToShortDateString() + " in " + report.HeadSection.Student.BirthPlace;
            string bornValueFR= bornLabel + report.HeadSection.Student.BirthDate.ToShortDateString() + " à " + report.HeadSection.Student.BirthPlace;
            BornTextBox.Value = language == "FR" ? bornValueFR : bornValueEN;

            #region First Term

            var absences = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4);
            var unjustifiesAbsences = GetItems(absences, a => a.Subject.Id == 4);
            var justifiesAbsences = GetItems(absences, a => a.Subject.Id == 3);
            var delays = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 1);
            var detentions = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 8);
            var warnings = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 5);
            var swarnings = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 6);
            var exclusions = GetItems(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 7);

            #region Mois de Septembre

            Term1Month01Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 1).ToString();
            Term1Month01Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 2).ToString();
            Term1Month01Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 3).ToString();
            Term1Month01Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 4).ToString();
            Term1Month01Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 5).ToString();
            Term1Month01Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 6).ToString();
            Term1Month01Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 7).ToString();
            Term1Month01Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 8).ToString();
            Term1Month01Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 9).ToString();
            Term1Month01Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 10).ToString();

            Term1Month01Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 11).ToString();
            Term1Month01Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 12).ToString();
            Term1Month01Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 13).ToString();
            Term1Month01Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 14).ToString();
            Term1Month01Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 15).ToString();
            Term1Month01Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 16).ToString();
            Term1Month01Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 17).ToString();
            Term1Month01Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 18).ToString();
            Term1Month01Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 19).ToString();
            Term1Month01Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 20).ToString();

            Term1Month01Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 21).ToString();
            Term1Month01Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 22).ToString();
            Term1Month01Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 23).ToString();
            Term1Month01Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 24).ToString();
            Term1Month01Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 25).ToString();
            Term1Month01Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 26).ToString();
            Term1Month01Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 27).ToString();
            Term1Month01Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 28).ToString();
            Term1Month01Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 29).ToString();
            Term1Month01Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 30).ToString();
            Term1Month01Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 9 && a.Date.Day == 31).ToString();

            Term1Month01LateTextBox.Value = GetSum(delays, d => d.Date.Month == 9).ToString();
            Term1Month01AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 9).ToString();
            Term1Month01JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 9).ToString();
            Term1Month01NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 9).ToString();
            Term1Month01DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 9).ToString();

            #endregion

            #region Mois de Octobre

            Term1Month02Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 1).ToString();
            Term1Month02Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 2).ToString();
            Term1Month02Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 3).ToString();
            Term1Month02Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 4).ToString();
            Term1Month02Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 5).ToString();
            Term1Month02Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 6).ToString();
            Term1Month02Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 7).ToString();
            Term1Month02Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 8).ToString();
            Term1Month02Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 10).ToString();
            Term1Month02Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 10).ToString();

            Term1Month02Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 11).ToString();
            Term1Month02Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 12).ToString();
            Term1Month02Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 13).ToString();
            Term1Month02Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 14).ToString();
            Term1Month02Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 15).ToString();
            Term1Month02Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 16).ToString();
            Term1Month02Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 17).ToString();
            Term1Month02Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 18).ToString();
            Term1Month02Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 19).ToString();
            Term1Month02Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 20).ToString();

            Term1Month02Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 21).ToString();
            Term1Month02Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 22).ToString();
            Term1Month02Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 23).ToString();
            Term1Month02Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 24).ToString();
            Term1Month02Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 25).ToString();
            Term1Month02Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 26).ToString();
            Term1Month02Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 27).ToString();
            Term1Month02Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 28).ToString();
            Term1Month02Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 29).ToString();
            Term1Month02Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 30).ToString();
            Term1Month02Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 10 && a.Date.Day == 31).ToString();

            Term1Month02LateTextBox.Value = GetSum(delays, d => d.Date.Month == 10).ToString();
            Term1Month02AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 10).ToString();
            Term1Month02JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 10).ToString();
            Term1Month02NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 10).ToString();
            Term1Month02DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 10).ToString();

            #endregion

            #region Mois de Novembre

            Term1Month03Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 1).ToString();
            Term1Month03Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 2).ToString();
            Term1Month03Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 3).ToString();
            Term1Month03Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 4).ToString();
            Term1Month03Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 5).ToString();
            Term1Month03Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 6).ToString();
            Term1Month03Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 7).ToString();
            Term1Month03Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 8).ToString();
            Term1Month03Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 11).ToString();
            Term1Month03Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 11).ToString();

            Term1Month03Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 11).ToString();
            Term1Month03Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 12).ToString();
            Term1Month03Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 13).ToString();
            Term1Month03Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 14).ToString();
            Term1Month03Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 15).ToString();
            Term1Month03Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 16).ToString();
            Term1Month03Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 17).ToString();
            Term1Month03Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 18).ToString();
            Term1Month03Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 19).ToString();
            Term1Month03Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 20).ToString();

            Term1Month03Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 21).ToString();
            Term1Month03Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 22).ToString();
            Term1Month03Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 23).ToString();
            Term1Month03Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 24).ToString();
            Term1Month03Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 25).ToString();
            Term1Month03Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 26).ToString();
            Term1Month03Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 27).ToString();
            Term1Month03Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 28).ToString();
            Term1Month03Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 29).ToString();
            Term1Month03Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 30).ToString();
            Term1Month03Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 11 && a.Date.Day == 31).ToString();

            Term1Month03LateTextBox.Value = GetSum(delays, d => d.Date.Month == 11).ToString();
            Term1Month03AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 11).ToString();
            Term1Month03JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 11).ToString();
            Term1Month03NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 11).ToString();
            Term1Month03DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 9).ToString();

            #endregion

            #region Mois de Décembre

            Term1Month04Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 1).ToString();
            Term1Month04Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 2).ToString();
            Term1Month04Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 3).ToString();
            Term1Month04Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 4).ToString();
            Term1Month04Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 5).ToString();
            Term1Month04Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 6).ToString();
            Term1Month04Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 7).ToString();
            Term1Month04Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 8).ToString();
            Term1Month04Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 12).ToString();
            Term1Month04Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 12).ToString();

            Term1Month04Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 12).ToString();
            Term1Month04Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 12).ToString();
            Term1Month04Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 13).ToString();
            Term1Month04Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 14).ToString();
            Term1Month04Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 15).ToString();
            Term1Month04Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 16).ToString();
            Term1Month04Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 17).ToString();
            Term1Month04Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 18).ToString();
            Term1Month04Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 19).ToString();
            Term1Month04Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 20).ToString();

            Term1Month04Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 21).ToString();
            Term1Month04Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 22).ToString();
            Term1Month04Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 23).ToString();
            Term1Month04Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 24).ToString();
            Term1Month04Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 25).ToString();
            Term1Month04Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 26).ToString();
            Term1Month04Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 27).ToString();
            Term1Month04Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 28).ToString();
            Term1Month04Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 29).ToString();
            Term1Month04Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 30).ToString();
            Term1Month04Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 12 && a.Date.Day == 31).ToString();

            Term1Month04LateTextBox.Value = GetSum(delays, d => d.Date.Month == 12).ToString();
            Term1Month04AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 12).ToString();
            Term1Month04JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 12).ToString();
            Term1Month04NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 12).ToString();
            Term1Month04DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 9).ToString();

            #endregion

            Term1TotalLateTextBox.Value = GetSum(delays, d => d.Date.Month == 9 || d.Date.Month == 10 || d.Date.Month == 11 || d.Date.Month == 12).ToString();
            Term1TotalAbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 9 || d.Date.Month == 10 || d.Date.Month == 11 || d.Date.Month == 12).ToString();
            Term1TotalJAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 9 || d.Date.Month == 10 || d.Date.Month == 11 || d.Date.Month == 12).ToString();
            Term1TotalNJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 9 || d.Date.Month == 10 || d.Date.Month == 11 || d.Date.Month == 12).ToString();
            Term1TotalDetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 9 || d.Date.Month == 10 || d.Date.Month == 11 || d.Date.Month == 12).ToString();

            Term1AverageTextBox.Value = report.DetailSection.FirstTermItem.Average + "/20";
            Term1PositionTextBox.Value = report.DetailSection.FirstTermItem.Position;
            Term1ClassAverageTextBox.Value = report.DetailSection.FirstTermItem.ClassAverage + "/20";

            if (!string.IsNullOrEmpty(report.DetailSection.FirstTermItem.Average))
            {
                if(double.TryParse(report.DetailSection.FirstTermItem.Average,out double average))
                {
                    if (average >= 12)
                    {
                        Term1WAwardTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term1WAwardTextBox.Value = language == "FR" ? "NON" : "NO";
                    }

                    if (average >= 13)
                    {
                        Term1WCreditTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term1WCreditTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average >= 14)
                    {
                        Term1WDistinctionTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term1WDistinctionTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average <= 8)
                    {
                        Term1WWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term1WWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average < 8)
                    {
                        Term1WSWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term1WSWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                }
            }

            Term1CWarningTextBox.Value = warnings.Any() ? "*" : "";
            Term1CSeriousWarningTextBox.Value = swarnings.Any() ? "*" : "";
            Term1CExclusionTextBox.Value= exclusions.Any() ? "*" : "";
            #endregion

            #region Second Term

            absences = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4);
            unjustifiesAbsences = GetItems(absences, a => a.Subject.Id == 4);
            justifiesAbsences = GetItems(absences, a => a.Subject.Id == 3);
            delays = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 1);
            detentions = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 8);
            warnings = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 5);
            swarnings = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 6);
            exclusions = GetItems(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 7);

            #region Mois de Janvier

            Term2Month01Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 1).ToString();
            Term2Month01Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 2).ToString();
            Term2Month01Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 3).ToString();
            Term2Month01Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 4).ToString();
            Term2Month01Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 5).ToString();
            Term2Month01Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 6).ToString();
            Term2Month01Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 7).ToString();
            Term2Month01Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 8).ToString();
            Term2Month01Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 9).ToString();
            Term2Month01Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 10).ToString();

            Term2Month01Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 11).ToString();
            Term2Month01Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 12).ToString();
            Term2Month01Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 13).ToString();
            Term2Month01Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 14).ToString();
            Term2Month01Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 15).ToString();
            Term2Month01Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 16).ToString();
            Term2Month01Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 17).ToString();
            Term2Month01Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 18).ToString();
            Term2Month01Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 19).ToString();
            Term2Month01Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 20).ToString();

            Term2Month01Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 21).ToString();
            Term2Month01Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 22).ToString();
            Term2Month01Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 23).ToString();
            Term2Month01Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 24).ToString();
            Term2Month01Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 25).ToString();
            Term2Month01Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 26).ToString();
            Term2Month01Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 27).ToString();
            Term2Month01Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 28).ToString();
            Term2Month01Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 29).ToString();
            Term2Month01Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 30).ToString();
            Term2Month01Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 1 && a.Date.Day == 31).ToString();

            Term2Month01LateTextBox.Value = GetSum(delays, d => d.Date.Month == 1).ToString();
            Term2Month01AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 1).ToString();
            Term2Month01JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 1).ToString();
            Term2Month01NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 1).ToString();
            Term2Month01DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 1).ToString();

            #endregion

            #region Mois de Février

            Term2Month02Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 1).ToString();
            Term2Month02Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 2).ToString();
            Term2Month02Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 3).ToString();
            Term2Month02Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 4).ToString();
            Term2Month02Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 5).ToString();
            Term2Month02Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 6).ToString();
            Term2Month02Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 7).ToString();
            Term2Month02Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 8).ToString();
            Term2Month02Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 10).ToString();
            Term2Month02Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 10).ToString();

            Term2Month02Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 11).ToString();
            Term2Month02Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 12).ToString();
            Term2Month02Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 13).ToString();
            Term2Month02Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 14).ToString();
            Term2Month02Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 15).ToString();
            Term2Month02Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 16).ToString();
            Term2Month02Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 17).ToString();
            Term2Month02Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 18).ToString();
            Term2Month02Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 19).ToString();
            Term2Month02Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 20).ToString();

            Term2Month02Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 21).ToString();
            Term2Month02Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 22).ToString();
            Term2Month02Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 23).ToString();
            Term2Month02Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 24).ToString();
            Term2Month02Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 25).ToString();
            Term2Month02Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 26).ToString();
            Term2Month02Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 27).ToString();
            Term2Month02Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 28).ToString();
            Term2Month02Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 29).ToString();
            Term2Month02Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 30).ToString();
            Term2Month02Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 2 && a.Date.Day == 31).ToString();

            Term2Month02LateTextBox.Value = GetSum(delays, d => d.Date.Month == 2).ToString();
            Term2Month02AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 2).ToString();
            Term2Month02JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 2).ToString();
            Term2Month02NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 2).ToString();
            Term2Month02DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 2).ToString();

            #endregion

            #region Mois de Mars

            Term2Month03Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 1).ToString();
            Term2Month03Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 2).ToString();
            Term2Month03Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 3).ToString();
            Term2Month03Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 4).ToString();
            Term2Month03Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 5).ToString();
            Term2Month03Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 6).ToString();
            Term2Month03Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 7).ToString();
            Term2Month03Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 8).ToString();
            Term2Month03Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 11).ToString();
            Term2Month03Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 11).ToString();

            Term2Month03Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 11).ToString();
            Term2Month03Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 12).ToString();
            Term2Month03Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 13).ToString();
            Term2Month03Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 14).ToString();
            Term2Month03Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 15).ToString();
            Term2Month03Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 16).ToString();
            Term2Month03Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 17).ToString();
            Term2Month03Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 18).ToString();
            Term2Month03Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 19).ToString();
            Term2Month03Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 20).ToString();

            Term2Month03Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 21).ToString();
            Term2Month03Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 22).ToString();
            Term2Month03Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 23).ToString();
            Term2Month03Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 24).ToString();
            Term2Month03Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 25).ToString();
            Term2Month03Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 26).ToString();
            Term2Month03Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 27).ToString();
            Term2Month03Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 28).ToString();
            Term2Month03Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 29).ToString();
            Term2Month03Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 30).ToString();
            Term2Month03Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 3 && a.Date.Day == 31).ToString();

            Term2Month03LateTextBox.Value = GetSum(delays, d => d.Date.Month == 3).ToString();
            Term2Month03AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 3).ToString();
            Term2Month03JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 3).ToString();
            Term2Month03NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 3).ToString();
            Term2Month03DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 1).ToString();

            #endregion



            Term2TotalLateTextBox.Value = GetSum(delays, d => d.Date.Month == 1 || d.Date.Month == 2 || d.Date.Month == 3).ToString();
            Term2TotalAbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 1 || d.Date.Month == 2 || d.Date.Month == 3).ToString();
            Term2TotalJAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 1 || d.Date.Month == 2 || d.Date.Month == 3).ToString();
            Term2TotalNJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 1 || d.Date.Month == 2 || d.Date.Month == 3).ToString();
            Term2TotalDetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 1 || d.Date.Month == 2 || d.Date.Month == 3).ToString();

            Term2AverageTextBox.Value = report.DetailSection.SecondTermItem.Average + "/20";
            Term2PositionTextBox.Value = report.DetailSection.SecondTermItem.Position;
            Term2ClassAverageTextBox.Value = report.DetailSection.SecondTermItem.ClassAverage + "/20";

            if (!string.IsNullOrEmpty(report.DetailSection.SecondTermItem.Average))
            {
                if (double.TryParse(report.DetailSection.SecondTermItem.Average, out double average))
                {
                    if (average >= 12)
                    {
                        Term2WAwardTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term2WAwardTextBox.Value = language == "FR" ? "NON" : "NO";
                    }

                    if (average >= 13)
                    {
                        Term2WCreditTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term2WCreditTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average >= 14)
                    {
                        Term2WDistinctionTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term2WDistinctionTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average <= 8)
                    {
                        Term2WWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term2WWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average < 8)
                    {
                        Term2WSWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term2WSWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                }
            }

            Term2CWarningTextBox.Value = warnings.Any() ? "*" : "";
            Term2CSeriousWarningTextBox.Value = swarnings.Any() ? "*" : "";
            Term2CExclusionTextBox.Value = exclusions.Any() ? "*" : "";


            #endregion

            #region Third Term

            absences = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4);
            unjustifiesAbsences = GetItems(absences, a => a.Subject.Id == 4);
            justifiesAbsences = GetItems(absences, a => a.Subject.Id == 3);
            delays = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 1);
            detentions = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 8);
            warnings = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 5);
            swarnings = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 6);
            exclusions = GetItems(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 7);


            #region Mois de Avril

            Term3Month01Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 1).ToString();
            Term3Month01Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 2).ToString();
            Term3Month01Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 3).ToString();
            Term3Month01Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 4).ToString();
            Term3Month01Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 5).ToString();
            Term3Month01Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 6).ToString();
            Term3Month01Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 7).ToString();
            Term3Month01Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 8).ToString();
            Term3Month01Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 9).ToString();
            Term3Month01Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 10).ToString();

            Term3Month01Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 11).ToString();
            Term3Month01Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 12).ToString();
            Term3Month01Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 13).ToString();
            Term3Month01Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 14).ToString();
            Term3Month01Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 15).ToString();
            Term3Month01Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 16).ToString();
            Term3Month01Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 17).ToString();
            Term3Month01Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 18).ToString();
            Term3Month01Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 19).ToString();
            Term3Month01Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 20).ToString();

            Term3Month01Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 21).ToString();
            Term3Month01Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 22).ToString();
            Term3Month01Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 23).ToString();
            Term3Month01Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 24).ToString();
            Term3Month01Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 25).ToString();
            Term3Month01Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 26).ToString();
            Term3Month01Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 27).ToString();
            Term3Month01Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 28).ToString();
            Term3Month01Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 29).ToString();
            Term3Month01Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 30).ToString();
            Term3Month01Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 4 && a.Date.Day == 31).ToString();

            Term3Month01LateTextBox.Value = GetSum(delays, d => d.Date.Month == 4).ToString();
            Term3Month01AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 4).ToString();
            Term3Month01JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 4).ToString();
            Term3Month01NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 4).ToString();
            Term3Month01DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 4).ToString();

            #endregion

            #region Mois de Mai

            Term3Month02Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 1).ToString();
            Term3Month02Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 2).ToString();
            Term3Month02Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 3).ToString();
            Term3Month02Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 4).ToString();
            Term3Month02Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 5).ToString();
            Term3Month02Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 6).ToString();
            Term3Month02Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 7).ToString();
            Term3Month02Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 8).ToString();
            Term3Month02Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 10).ToString();
            Term3Month02Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 10).ToString();

            Term3Month02Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 11).ToString();
            Term3Month02Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 12).ToString();
            Term3Month02Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 13).ToString();
            Term3Month02Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 14).ToString();
            Term3Month02Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 15).ToString();
            Term3Month02Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 16).ToString();
            Term3Month02Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 17).ToString();
            Term3Month02Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 18).ToString();
            Term3Month02Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 19).ToString();
            Term3Month02Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 20).ToString();

            Term3Month02Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 21).ToString();
            Term3Month02Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 22).ToString();
            Term3Month02Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 23).ToString();
            Term3Month02Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 24).ToString();
            Term3Month02Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 25).ToString();
            Term3Month02Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 26).ToString();
            Term3Month02Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 27).ToString();
            Term3Month02Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 28).ToString();
            Term3Month02Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 29).ToString();
            Term3Month02Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 30).ToString();
            Term3Month02Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 5 && a.Date.Day == 31).ToString();

            Term3Month02LateTextBox.Value = GetSum(delays, d => d.Date.Month == 5).ToString();
            Term3Month02AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 5).ToString();
            Term3Month02JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 5).ToString();
            Term3Month02NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 5).ToString();
            Term3Month02DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 5).ToString();

            #endregion

            #region Mois de Juin

            Term3Month03Day01TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 1).ToString();
            Term3Month03Day02TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 2).ToString();
            Term3Month03Day03TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 3).ToString();
            Term3Month03Day04TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 4).ToString();
            Term3Month03Day05TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 5).ToString();
            Term3Month03Day06TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 6).ToString();
            Term3Month03Day07TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 7).ToString();
            Term3Month03Day08TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 8).ToString();
            Term3Month03Day09TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 11).ToString();
            Term3Month03Day10TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 11).ToString();

            Term3Month03Day11TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 11).ToString();
            Term3Month03Day12TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 12).ToString();
            Term3Month03Day13TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 13).ToString();
            Term3Month03Day14TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 14).ToString();
            Term3Month03Day15TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 15).ToString();
            Term3Month03Day16TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 16).ToString();
            Term3Month03Day17TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 17).ToString();
            Term3Month03Day18TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 18).ToString();
            Term3Month03Day19TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 19).ToString();
            Term3Month03Day20TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 20).ToString();

            Term3Month03Day21TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 21).ToString();
            Term3Month03Day22TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 22).ToString();
            Term3Month03Day23TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 23).ToString();
            Term3Month03Day24TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 24).ToString();
            Term3Month03Day25TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 25).ToString();
            Term3Month03Day26TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 26).ToString();
            Term3Month03Day27TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 27).ToString();
            Term3Month03Day28TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 28).ToString();
            Term3Month03Day29TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 29).ToString();
            Term3Month03Day30TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 30).ToString();
            Term3Month03Day31TextBox.Value = GetSum(absences, a => a.Date.Month == 6 && a.Date.Day == 31).ToString();

            Term3Month03LateTextBox.Value = GetSum(delays, d => d.Date.Month == 6).ToString();
            Term3Month03AbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 6).ToString();
            Term3Month03JAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 6).ToString();
            Term3Month03NJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 6).ToString();
            Term3Month03DetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 4).ToString();

            #endregion



            Term3TotalLateTextBox.Value = GetSum(delays, d => d.Date.Month == 4 || d.Date.Month == 5 || d.Date.Month == 6).ToString();
            Term3TotalAbsenceTextBox.Value = GetSum(absences, d => d.Date.Month == 4 || d.Date.Month == 5 || d.Date.Month == 6).ToString();
            Term3TotalJAbsenceTextBox.Value = GetSum(justifiesAbsences, d => d.Date.Month == 4 || d.Date.Month == 5 || d.Date.Month == 6).ToString();
            Term3TotalNJAbsenceTextBox.Value = GetSum(unjustifiesAbsences, d => d.Date.Month == 4 || d.Date.Month == 5 || d.Date.Month == 6).ToString();
            Term3TotalDetentionTextBox.Value = GetSum(detentions, d => d.Date.Month == 4 || d.Date.Month == 5 || d.Date.Month == 6).ToString();

            Term3AverageTextBox.Value = report.DetailSection.ThirdTermItem.Average + "/20";
            Term3PositionTextBox.Value = report.DetailSection.ThirdTermItem.Position;
            Term3ClassAverageTextBox.Value = report.DetailSection.ThirdTermItem.ClassAverage + "/20";

            if (!string.IsNullOrEmpty(report.DetailSection.ThirdTermItem.Average))
            {
                if (double.TryParse(report.DetailSection.ThirdTermItem.Average, out double average))
                {
                    if (average >= 12)
                    {
                        Term3WAwardTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term3WAwardTextBox.Value = language == "FR" ? "NON" : "NO";
                    }

                    if (average >= 13)
                    {
                        Term3WCreditTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term3WCreditTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average >= 14)
                    {
                        Term3WDistinctionTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term3WDistinctionTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average <= 8)
                    {
                        Term3WWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term3WWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                    if (average < 8)
                    {
                        Term3WSWarningTextBox.Value = language == "FR" ? "OUI" : "YES";
                    }
                    else
                    {
                        Term3WSWarningTextBox.Value = language == "FR" ? "NON" : "NO";
                    }
                }
            }

            Term3CWarningTextBox.Value = warnings.Any()? "*" : "";
            Term3CSeriousWarningTextBox.Value = swarnings.Any() ? "*" : "";
            Term3CExclusionTextBox.Value = exclusions.Any() ? "*" : "";

            #endregion


            #region Annual Resume

            List<DisciplineItemRecord> annualDisciplines = new();
            annualDisciplines.AddRange(report.DetailSection.FirstTermItem.Disciplines);
            annualDisciplines.AddRange(report.DetailSection.SecondTermItem.Disciplines);
            annualDisciplines.AddRange(report.DetailSection.ThirdTermItem.Disciplines);


            ResumeDelayTerm1TextBox.Value = GetSum(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 1).ToString();
            ResumeDelayTerm2TextBox.Value = GetSum(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 1).ToString();
            ResumeDelayTerm3TextBox.Value = GetSum(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 1).ToString();
            ResumeDelayTotalTextBox.Value = GetSum(annualDisciplines, d => d.Subject.Id == 1).ToString();

            ResumeAbsenceTerm1TextBox.Value = GetSum(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4).ToString();
            ResumeAbsenceTerm2TextBox.Value = GetSum(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4).ToString();
            ResumeAbsenceTerm3TextBox.Value = GetSum(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4).ToString();
            ResumeAbsenceTotalTextBox.Value = GetSum(annualDisciplines, d => d.Subject.Id == 3 || d.Subject.Id == 4).ToString();

            ResumeWarningTerm1TextBox.Value = GetCount(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 5).ToString();
            ResumeWarningTerm2TextBox.Value = GetCount(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 5).ToString();
            ResumeWarningTerm3TextBox.Value = GetCount(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 5).ToString();
            ResumeWarningTotalTextBox.Value= GetCount(annualDisciplines, d => d.Subject.Id == 5).ToString();

            ResumeSWarningTerm1TextBox.Value = GetCount(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 6).ToString();
            ResumeSWarningTerm2TextBox.Value = GetCount(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 6).ToString();
            ResumeSWarningTerm3TextBox.Value = GetCount(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 6).ToString();
            ResumeSWarningTotalTextBox.Value = GetCount(annualDisciplines, d => d.Subject.Id == 6).ToString();

            ResumeDetentionTerm1TextBox.Value = GetSum(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 8).ToString();
            ResumeDetentionTerm2TextBox.Value = GetSum(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 8).ToString();
            ResumeDetentionTerm3TextBox.Value = GetSum(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 8).ToString();
            ResumeDetentionTotalTextBox.Value = GetSum(annualDisciplines, d => d.Subject.Id == 8).ToString();

            ResumeExclusionTerm1TextBox.Value = GetSum(report.DetailSection.FirstTermItem.Disciplines, d => d.Subject.Id == 7).ToString();
            ResumeExclusionTerm2TextBox.Value = GetSum(report.DetailSection.SecondTermItem.Disciplines, d => d.Subject.Id == 7).ToString();
            ResumeExclusionTerm3TextBox.Value = GetSum(report.DetailSection.ThirdTermItem.Disciplines, d => d.Subject.Id == 7).ToString();
            ResumeExclusionTotalTextBox.Value= GetSum(annualDisciplines, d => d.Subject.Id == 7).ToString();

            AnnualAverageTextBox.Value= $"{report.DetailSection.ResumeItem.Average}/20";
            AnnualPositionTextBox.Value = report.DetailSection.ResumeItem.Position;
            #endregion

            FacebookAddressLabel.Value = Program.CurrentSchool.Name;
            SchoolNameTextBox.Value= Program.CurrentSchool.Name;
            ContactTextBox.Value = $"Tel:{Program.CurrentSchool.Phone}";
            AddressTextBox.Value = Program.CurrentSchool.Address;
            WebSiteTextBox.Value = Program.CurrentSchool.WebSite;
            FaceBookPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Center;
            WebSitePictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("website.png");
            FaceBookPictureBox.Value = Utilities.AppUtilities.GetImageFromUrl("facebook.png");

        }

        private void InitLanguage(string language)
        {

            StudentLabel.Value = language == "FR" ? "Nom et prénoms:" : "Names of pupil:";
            StudentIdLabel.Value = language == "FR" ? "Matricule:" : "ID:";
            ClassLabel.Value = language == "FR" ? "Classe:" : "Class:";
            TeacherLabel.Value = language == "FR" ? "Titulaire:" : "Teacher:";

            Term1Month01Label.Value = language == "FR" ? "S" : "S";
            Term1Month02Label.Value = language == "FR" ? "O" : "O";
            Term1Month03Label.Value = language == "FR" ? "N" : "N";
            Term1Month04Label.Value = language == "FR" ? "D" : "D";

            Term1Label.Value = language == "FR" ? "1ᵉʳ TRIMESTRE" : "1ˢᵗ TERM";
            Term1AverageLabel.Value = language == "FR" ? "MOYENNE TRIMESTRIELLE : " : "TERM AVERAGE : ";
            Term1PositionLabel.Value = language == "FR" ? "RANG TRIMESTRIEL : " : "ORDER OF MERIT : ";
            Term1ClassAverageLabel.Value = language == "FR" ? "MOYENNE GENERALE DE LA CLASSE : " : "CLASS AVERAGE : ";
            Term1ClassDecisionLabel.Value = language == "FR" ? "DECISION DU CONSEIL DE CLASSE" : "DECISIONS OF CLASS COUNCIL";
            Term1GeneralRemarkLabel.Value = language == "FR" ? "OBSERVATIONS GENERALES" : "GENERAL REMARKS";
            Term1PrincipalVisaLabel.Value = language == "FR" ? "VISA DU PRINCIPAL" : "PRINCIPAL'S VISA";
            Term1ClassWorkLabel.Value = language == "FR" ? "TRAVAIL" : "CLASS WORK";
            Term1ConductLabel.Value = language == "FR" ? "CONDUITE" : "CONDUCT";
            Term1WAwardLabel.Value = language == "FR" ? "TABLEAU D'HONNEUR" : "HONOUR AWARD";
            Term1WCreditLabel.Value = language == "FR" ? "ENCOURAGEMENTS" : "CREDIT";
            Term1WDistinctionLabel.Value = language == "FR" ? "FELICITATIONS" : "DISTINCTIONS";
            Term1WWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term1WSWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term1CWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term1CSeriousWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term1CExclusionLabel.Value = language == "FR" ? "EXCLUSION" : "EXCLUSION(IN DAYS)";
            Term1ReasonLabel.Value = language == "FR" ? "MOTIF" : "MOTIVE";

            Term2Month01Label.Value = language == "FR" ? "J" : "J";
            Term2Month02Label.Value = language == "FR" ? "F" : "F";
            Term2Month03Label.Value = language == "FR" ? "M" : "M";

            Term2Label.Value = language == "FR" ? "2ᵉ TRIMESTRE" : "2ⁿᵈ TERM";
            Term2AverageLabel.Value = language == "FR" ? "MOYENNE TRIMESTRIELLE : " : "TERM AVERAGE : ";
            Term2PositionLabel.Value = language == "FR" ? "RANG TRIMESTRIEL : " : "ORDER OF MERIT : ";
            Term2ClassAverageLabel.Value = language == "FR" ? "MOYENNE GENERALE DE LA CLASSE : " : "CLASS AVERAGE : ";
            Term2ClassDecisionLabel.Value = language == "FR" ? "DECISION DU CONSEIL DE CLASSE" : "DECISIONS OF CLASS COUNCIL";
            Term2GeneralRemarkLabel.Value = language == "FR" ? "OBSERVATIONS GENERALES" : "GENERAL REMARKS";
            Term2PrincipalVisaLabel.Value = language == "FR" ? "VISA DU PRINCIPAL" : "PRINCIPAL'S VISA";
            Term2ClassWorkLabel.Value = language == "FR" ? "TRAVAIL" : "CLASS WORK";
            Term2ConductLabel.Value = language == "FR" ? "CONDUITE" : "CONDUCT";
            Term2WAwardLabel.Value = language == "FR" ? "TABLEAU D'HONNEUR" : "HONOUR AWARD";
            Term2WCreditLabel.Value = language == "FR" ? "ENCOURAGEMENTS" : "CREDIT";
            Term2WDistinctionLabel.Value = language == "FR" ? "FELICITATIONS" : "DISTINCTIONS";
            Term2WWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term2WSWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term2CWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term2CSeriousWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term2CExclusionLabel.Value = language == "FR" ? "EXCLUSION" : "EXCLUSION(IN DAYS)";
            Term2ReasonLabel.Value = language == "FR" ? "MOTIF" : "MOTIVE";


            Term3Month01Label.Value = language == "FR" ? "A" : "A";
            Term3Month02Label.Value = language == "FR" ? "M" : "M";
            Term3Month03Label.Value = language == "FR" ? "J" : "J";

            Term3Label.Value = language == "FR" ? "3ᵉ TRIMESTRE" : "3ʳᵈ TERM";
            Term3AverageLabel.Value = language == "FR" ? "MOYENNE TRIMESTRIELLE : " : "TERM AVERAGE : ";
            Term3PositionLabel.Value = language == "FR" ? "RANG TRIMESTRIEL : " : "ORDER OF MERIT : ";
            Term3ClassAverageLabel.Value = language == "FR" ? "MOYENNE GENERALE DE LA CLASSE : " : "CLASS AVERAGE : ";
            Term3ClassDecisionLabel.Value = language == "FR" ? "DECISION DU CONSEIL DE CLASSE" : "DECISIONS OF CLASS COUNCIL";
            Term3GeneralRemarkLabel.Value = language == "FR" ? "OBSERVATIONS GENERALES" : "GENERAL REMARKS";
            Term3PrincipalVisaLabel.Value = language == "FR" ? "VISA DU PRINCIPAL" : "PRINCIPAL'S VISA";
            Term3ClassWorkLabel.Value = language == "FR" ? "TRAVAIL" : "CLASS WORK";
            Term3ConductLabel.Value = language == "FR" ? "CONDUITE" : "CONDUCT";
            Term3WAwardLabel.Value = language == "FR" ? "TABLEAU D'HONNEUR" : "HONOUR AWARD";
            Term3WCreditLabel.Value = language == "FR" ? "ENCOURAGEMENTS" : "CREDIT";
            Term3WDistinctionLabel.Value = language == "FR" ? "FELICITATIONS" : "DISTINCTIONS";
            Term3WWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term3WSWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term3CWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            Term3CSeriousWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            Term3CExclusionLabel.Value = language == "FR" ? "EXCLUSION" : "EXCLUSION(IN DAYS)";
            Term3ReasonLabel.Value = language == "FR" ? "MOTIF" : "MOTIVE";


            AnnualResumeLabel.Value= language== "FR"? "RECAPITULATIF ANNUEL" : "ANNUAL RESULT";
            AnnualResultLabel.Value = language == "FR" ? "RESULTATS ANNUELS" : "ANNUAL RESULT";
            ResumeTerm1Label.Value = language == "FR" ? "1ᵉʳTRIM" : "1ˢᵗ TERM";
            ResumeTerm2Label.Value = language == "FR" ? "2ᵉTRIM" : "2ⁿᵈ TERM";
            ResumeTerm3Label.Value = language == "FR" ? "3ᵉTRIM" : "3ʳᵈ TERM";
            ResumeDelayLabel.Value = language == "FR" ? "RETARDS" : "LATE";
            ResumeAbsenceLabel.Value = language == "FR" ? "ABSENCES" : "ABSENCES";
            ResumeWarningLabel.Value = language == "FR" ? "AVERTISSEMENTS" : "WARNING";
            ResumeSWarningLabel.Value = language == "FR" ? "BLAMES" : "SERIOUS WARNING";
            ResumeDetentionLabel.Value = language == "FR" ? "CONSIGNE" : "DETENTIONS";
            ResumeExclusionLabel.Value = language == "FR" ? "EXCLUSIONS" : "EXCLUSIONS";

            AnnualAverageLabel.Value = language == "FR" ? "MOYENNE ANNUELLE : " : "ANNUAL AVERAGE : ";
            AnnualPositionLabel.Value = language == "FR" ? "RANG ANNUEL :" : "ORDER OF MERIT :";
            AnnualDecisionLabel.Value = language == "FR" ? "DECISION DU CONSEIL DE CLASSE :" : "DECISIONS OF CLASS COUNCIL:";
        }

        // Retourne la liste des (retenues, retards,absences,...) selon la condition
        private IEnumerable<DisciplineItemRecord> GetItems(IEnumerable<DisciplineItemRecord> items, Func<DisciplineItemRecord, bool> condition)
        {
            return items.Where(condition);
        }

        // Retourne la Somme de la durée des (retenues, retards,absences,...) selon la condition
        private double GetSum(IEnumerable<DisciplineItemRecord> items, Func<DisciplineItemRecord, bool> condition)
        {
            return items.Where(condition).Sum(d => d.Duration);
        }

        // Retourne le nombre (retenues, retards,absences,...) selon la condition
        private int GetCount(IEnumerable<DisciplineItemRecord> items, Func<DisciplineItemRecord, bool> condition)
        {
            return items.Where(condition).Count();
        }

    }
}
