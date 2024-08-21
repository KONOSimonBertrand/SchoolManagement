using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace SchoolManagement.UI.Localization
{
    class FrenchSchedulerLocalizationProvider : RadSchedulerLocalizationProvider

    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadSchedulerStringId.NextAppointment:
                    return "Programmation suivante";
                case RadSchedulerStringId.PreviousAppointment:
                    return "Programmation précédente";
                case RadSchedulerStringId.AppointmentDialogTitle:
                    return "Modifier le Rendez-vous";
                case RadSchedulerStringId.AppointmentDialogSubject:
                    return "Cours:";
                case RadSchedulerStringId.AppointmentDialogLocation:
                    return "Lieu:";
                case RadSchedulerStringId.AppointmentDialogBackground:
                    return "Propriété:";
                case RadSchedulerStringId.AppointmentDialogDescription:
                    return "Description:";
                case RadSchedulerStringId.AppointmentDialogStartTime:
                    return "Début:";
                case RadSchedulerStringId.AppointmentDialogEndTime:
                    return "Fin:";
                case RadSchedulerStringId.AppointmentDialogAllDay:
                    return "Tous les évènements journaliers";
                case RadSchedulerStringId.AppointmentDialogResource:
                    return "Ressource:";
                case RadSchedulerStringId.AppointmentDialogStatus:
                    return "Etat:";
                case RadSchedulerStringId.AppointmentDialogOK:
                    return "OK";
                case RadSchedulerStringId.AppointmentDialogCancel:
                    return "Annuler";
                case RadSchedulerStringId.AppointmentDialogDelete:
                    return "Supprimer";
                case RadSchedulerStringId.AppointmentDialogRecurrence:
                    return "Recurrence";
                case RadSchedulerStringId.OpenRecurringDialogTitle:
                    return "Ouvrir l'objet récurrent";
                case RadSchedulerStringId.OpenRecurringDialogOK:
                    return "OK";
                case RadSchedulerStringId.OpenRecurringDialogCancel:
                    return "Annuler";
                case RadSchedulerStringId.OpenRecurringDialogLabel:
                    return "\"{0}\" is a recurring\nappointment. Do you want to open\nonly this occurrence or the series?";
                case RadSchedulerStringId.OpenRecurringDialogRadioOccurrence:
                    return "Ouvrit cette occurrence.";
                case RadSchedulerStringId.OpenRecurringDialogRadioSeries:
                    return "Ouvrir les series.";
                case RadSchedulerStringId.RecurrenceDialogTitle:
                    return "Modifier l'ocurrence";
                case RadSchedulerStringId.RecurrenceDialogAppointmentTimeGroup:
                    return "Heure programmation";
                case RadSchedulerStringId.RecurrenceDialogDuration:
                    return "Durée:";
                case RadSchedulerStringId.RecurrenceDialogAppointmentEnd:
                    return "Fin:";
                case RadSchedulerStringId.RecurrenceDialogAppointmentStart:
                    return "Début:";
                case RadSchedulerStringId.RecurrenceDialogRecurrenceGroup:
                    return "Recurrence pattern";
                case RadSchedulerStringId.RecurrenceDialogRangeGroup:
                    return "Range of recurrence";
                case RadSchedulerStringId.RecurrenceDialogOccurrences:
                    return "occurrences";
                case RadSchedulerStringId.RecurrenceDialogRecurrenceStart:
                    return "Début:";
                case RadSchedulerStringId.RecurrenceDialogYearly:
                    return "Annuel";
                case RadSchedulerStringId.RecurrenceDialogMonthly:
                    return "Mensuel";
                case RadSchedulerStringId.RecurrenceDialogWeekly:
                    return "Hebdomadaire";
                case RadSchedulerStringId.RecurrenceDialogDaily:
                    return "Journalier";
                case RadSchedulerStringId.RecurrenceDialogEndBy:
                    return "Fini par:";
                case RadSchedulerStringId.RecurrenceDialogEndAfter:
                    return "End after:";
                case RadSchedulerStringId.RecurrenceDialogNoEndDate:
                    return "No end date";
                case RadSchedulerStringId.RecurrenceDialogOK:
                    return "OK";
                case RadSchedulerStringId.RecurrenceDialogCancel:
                    return "Annuler";
                case RadSchedulerStringId.RecurrenceDialogRemoveRecurrence:
                    return "Remove Recurrence";
                case RadSchedulerStringId.DailyRecurrenceEveryDay:
                    return "Every";
                case RadSchedulerStringId.DailyRecurrenceEveryWeekday:
                    return "Every weekday";
                case RadSchedulerStringId.DailyRecurrenceDays:
                    return "Jour(s)";
                case RadSchedulerStringId.WeeklyRecurrenceRecurEvery:
                    return "Recur every";
                case RadSchedulerStringId.WeeklyRecurrenceWeeksOn:
                    return "week(s) on:";
                case RadSchedulerStringId.WeeklyRecurrenceSunday:
                    return "Dimanche";
                case RadSchedulerStringId.WeeklyRecurrenceMonday:
                    return "Lundi";
                case RadSchedulerStringId.WeeklyRecurrenceTuesday:
                    return "Mardi";
                case RadSchedulerStringId.WeeklyRecurrenceWednesday:
                    return "Mercredi";
                case RadSchedulerStringId.WeeklyRecurrenceThursday:
                    return "Jeudi";
                case RadSchedulerStringId.WeeklyRecurrenceFriday:
                    return "Vendredi";
                case RadSchedulerStringId.WeeklyRecurrenceSaturday:
                    return "Samedi";
                case RadSchedulerStringId.WeeklyRecurrenceDay:
                    return "Jour";
                case RadSchedulerStringId.WeeklyRecurrenceWeekday:
                    return "Weekday";
                case RadSchedulerStringId.WeeklyRecurrenceWeekendDay:
                    return "Weekend day";
                case RadSchedulerStringId.MonthlyRecurrenceDay:
                    return "Jour";
                case RadSchedulerStringId.MonthlyRecurrenceWeek:
                    return "The";
                case RadSchedulerStringId.MonthlyRecurrenceDayOfMonth:
                    return "of every";
                case RadSchedulerStringId.MonthlyRecurrenceMonths:
                    return "mois";
                case RadSchedulerStringId.MonthlyRecurrenceWeekOfMonth:
                    return "of every";
                case RadSchedulerStringId.MonthlyRecurrenceFirst:
                    return "First";
                case RadSchedulerStringId.MonthlyRecurrenceSecond:
                    return "Second";
                case RadSchedulerStringId.MonthlyRecurrenceThird:
                    return "Third";
                case RadSchedulerStringId.MonthlyRecurrenceFourth:
                    return "Fourth";
                case RadSchedulerStringId.MonthlyRecurrenceLast:
                    return "Last";
                case RadSchedulerStringId.YearlyRecurrenceDayOfMonth:
                    return "Every";
                case RadSchedulerStringId.YearlyRecurrenceWeekOfMonth:
                    return "The";
                case RadSchedulerStringId.YearlyRecurrenceOfMonth:
                    return "of";
                case RadSchedulerStringId.YearlyRecurrenceJanuary:
                    return "Janvier";
                case RadSchedulerStringId.YearlyRecurrenceFebruary:
                    return "Février";
                case RadSchedulerStringId.YearlyRecurrenceMarch:
                    return "Mars";
                case RadSchedulerStringId.YearlyRecurrenceApril:
                    return "Avril";
                case RadSchedulerStringId.YearlyRecurrenceMay:
                    return "Mai";
                case RadSchedulerStringId.YearlyRecurrenceJune:
                    return "Juin";
                case RadSchedulerStringId.YearlyRecurrenceJuly:
                    return "Juillet";
                case RadSchedulerStringId.YearlyRecurrenceAugust:
                    return "Août";
                case RadSchedulerStringId.YearlyRecurrenceSeptember:
                    return "Septembre";
                case RadSchedulerStringId.YearlyRecurrenceOctober:
                    return "Octobre";
                case RadSchedulerStringId.YearlyRecurrenceNovember:
                    return "Novembre";
                case RadSchedulerStringId.YearlyRecurrenceDecember:
                    return "Decembre";
                case RadSchedulerStringId.BackgroundNone:
                    return "Normal";
                case RadSchedulerStringId.BackgroundImportant:
                    return "VIP";
                case RadSchedulerStringId.BackgroundBusiness:
                    return "Business";
                case RadSchedulerStringId.BackgroundPersonal:
                    return "Particulier";
                case RadSchedulerStringId.BackgroundVacation:
                    return "Récyclage";
                case RadSchedulerStringId.BackgroundMustAttend:
                    return "Révision";
                case RadSchedulerStringId.BackgroundTravelRequired:
                    return "Entretien Auto";
                case RadSchedulerStringId.BackgroundNeedsPreparation:
                    return "Conduite défensive";
                case RadSchedulerStringId.BackgroundBirthday:
                    return "Sécurité";
                case RadSchedulerStringId.BackgroundAnniversary:
                    return "Prévention";
                case RadSchedulerStringId.BackgroundPhoneCall:
                    return "Préparation Examen";
                case RadSchedulerStringId.StatusBusy:
                    return "A dispenser";
                case RadSchedulerStringId.StatusFree:
                    return "En Cours";
                case RadSchedulerStringId.StatusTentative:
                    return "Reporté";
                case RadSchedulerStringId.StatusUnavailable:
                    return "Fini";
                case RadSchedulerStringId.ContextMenuNewAppointment:
                    return "Nouveau Rendez-vous";
                case RadSchedulerStringId.ContextMenuEditAppointment:
                    return "Modifier le Rendez-vous";
                case RadSchedulerStringId.ContextMenuNewRecurringAppointment:
                    return "New Recurring Appointment";
                case RadSchedulerStringId.ContextMenu60Minutes:
                    return "60 Minutes";
                case RadSchedulerStringId.ContextMenu30Minutes:
                    return "30 Minutes";
                case RadSchedulerStringId.ContextMenu15Minutes:
                    return "15 Minutes";
                case RadSchedulerStringId.ContextMenu10Minutes:
                    return "10 Minutes";
                case RadSchedulerStringId.ContextMenu6Minutes:
                    return "6 Minutes";
                case RadSchedulerStringId.ContextMenu5Minutes:
                    return "5 Minutes";
                case RadSchedulerStringId.ContextMenuNavigateToNextView:
                    return "Vue suivante";
                case RadSchedulerStringId.ContextMenuNavigateToPreviousView:
                    return "Vue précédente";
                case RadSchedulerStringId.ContextMenuTimescales:
                    return "Time Scales";
                case RadSchedulerStringId.ContextMenuTimescalesYear:
                    return "Année";
                case RadSchedulerStringId.ContextMenuTimescalesMonth:
                    return "Mois";
                case RadSchedulerStringId.ContextMenuTimescalesWeek:
                    return "Semaine";
                case RadSchedulerStringId.ContextMenuTimescalesDay:
                    return "Jour";
                case RadSchedulerStringId.ContextMenuTimescalesHour:
                    return "Heure";
                case RadSchedulerStringId.ContextMenuTimescalesFifteenMinutes:
                    return "15 minutes";
                case RadSchedulerStringId.ErrorProviderWrongAppointmentDates:
                    return "Appointment end time is less or equal to start time!";
                case RadSchedulerStringId.ErrorProviderWrongExceptionDuration:
                    return "Recurrence interval must be greater or equal to appointment duration!";
                case RadSchedulerStringId.TimeZoneLocal:
                    return "Local";
               
            }

            return string.Empty;
        }
    }
}
