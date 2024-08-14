using Telerik.WinControls.UI;

namespace SchoolManagement.UI.Localization
{
    public class FrenchPrintDialogsLocalizationProvider : PrintDialogsLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case PrintDialogsStringId.PreviewDialogTitle: return "Aperçu avant impression";
                case PrintDialogsStringId.PreviewDialogPrint: return "Imprimer...";
                case PrintDialogsStringId.PreviewDialogPrintSettings: return "Paramètres d'impression...";
                case PrintDialogsStringId.PreviewDialogWatermark: return "Filigrane...";
                case PrintDialogsStringId.PreviewDialogPreviousPage: return "Page précédente";
                case PrintDialogsStringId.PreviewDialogNextPage: return "Page suivante";
                case PrintDialogsStringId.PreviewDialogZoomIn: return "Agrandir";
                case PrintDialogsStringId.PreviewDialogZoomOut: return "Réduir";
                case PrintDialogsStringId.PreviewDialogZoom: return "Zoom";
                case PrintDialogsStringId.PreviewDialogAuto: return "Auto";
                case PrintDialogsStringId.PreviewDialogLayout: return "Disposition";
                case PrintDialogsStringId.PreviewDialogFile: return "Fichier";
                case PrintDialogsStringId.PreviewDialogView: return "Vue";
                case PrintDialogsStringId.PreviewDialogTools: return "Outils";
                case PrintDialogsStringId.PreviewDialogExit: return "Sortir";
                case PrintDialogsStringId.PreviewDialogStripTools: return "Outils";
                case PrintDialogsStringId.PreviewDialogStripNavigation: return "Navigation";
                case PrintDialogsStringId.WatermarkDialogTitle: return "Paramètres de filigrane";
                case PrintDialogsStringId.WatermarkDialogButtonOK: return "OK";
                case PrintDialogsStringId.WatermarkDialogButtonCancel: return "Annuler";
                case PrintDialogsStringId.WatermarkDialogLabelPreview: return "Aperçu";
                case PrintDialogsStringId.WatermarkDialogButtonRemove: return "Supprimer filigrane";
                case PrintDialogsStringId.WatermarkDialogLabelPosition: return "Position";
                case PrintDialogsStringId.WatermarkDialogRadioInFront: return "Devant";
                case PrintDialogsStringId.WatermarkDialogRadioBehind: return "Derrière";
                case PrintDialogsStringId.WatermarkDialogLabelPageRange: return "Intervalle de pages";
                case PrintDialogsStringId.WatermarkDialogRadioAll: return "Tout";
                case PrintDialogsStringId.WatermarkDialogRadioPages: return "Pages";
                case PrintDialogsStringId.WatermarkDialogLabelPagesDescription: return "(e.g. 1,3,5-12)";
                case PrintDialogsStringId.WatermarkDialogTabText: return "Texte";
                case PrintDialogsStringId.WatermarkDialogTabPicture: return "Image";
                case PrintDialogsStringId.WatermarkDialogLabelText: return "Texte";
                case PrintDialogsStringId.WatermarkDialogWatermarkText: return "Texte de filigrane";
                case PrintDialogsStringId.WatermarkDialogLabelHOffset: return "Décalage horizontal";
                case PrintDialogsStringId.WatermarkDialogLabelVOffset: return "Décalage vertical";
                case PrintDialogsStringId.WatermarkDialogLabelRotation: return "Rotation";
                case PrintDialogsStringId.WatermarkDialogLabelFont: return "Police de caractère:";
                case PrintDialogsStringId.WatermarkDialogLabelSize: return "Taille:";
                case PrintDialogsStringId.WatermarkDialogLabelColor: return "Couleur:";
                case PrintDialogsStringId.WatermarkDialogLabelOpacity: return "Opacité:";
                case PrintDialogsStringId.WatermarkDialogLabelLoadImage: return "Charger l'image:";
                case PrintDialogsStringId.WatermarkDialogCheckboxTiling: return "Carrelage";
                case PrintDialogsStringId.SettingDialogTitle: return "Paramètres d'impression";
                case PrintDialogsStringId.SettingDialogButtonPrint: return "Imprimer";
                case PrintDialogsStringId.SettingDialogButtonPreview: return "Aperçu";
                case PrintDialogsStringId.SettingDialogButtonCancel: return "Annuler";
                case PrintDialogsStringId.SettingDialogButtonOK: return "OK";
                case PrintDialogsStringId.SettingDialogPageFormat: return "Format";
                case PrintDialogsStringId.SettingDialogPagePaper: return "Papier";
                case PrintDialogsStringId.SettingDialogPageHeaderFooter: return "En-tête / pied de page";
                case PrintDialogsStringId.SettingDialogButtonPageNumber: return "Numéro de page";
                case PrintDialogsStringId.SettingDialogButtonTotalPages: return "Nombre de pages";
                case PrintDialogsStringId.SettingDialogButtonCurrentDate: return "Date actuelle";
                case PrintDialogsStringId.SettingDialogButtonCurrentTime: return "Heure actuelle";
                case PrintDialogsStringId.SettingDialogButtonUserName: return "Nom d'utilisateur";
                case PrintDialogsStringId.SettingDialogLabelHeader: return "En-tête";
                case PrintDialogsStringId.SettingDialogLabelFooter: return "pied de page";
                case PrintDialogsStringId.SettingDialogCheckboxReverse: return "Inverser sur les pages paires";
                case PrintDialogsStringId.SettingDialogLabelPage: return "Page";
                case PrintDialogsStringId.SettingDialogLabelType: return "Type";
                case PrintDialogsStringId.SettingDialogLabelPageSource: return "Source de la page";
                case PrintDialogsStringId.SettingDialogLabelMargins: return "Marges (inches)";
                case PrintDialogsStringId.SettingDialogLabelOrientation: return "Orientation";
                case PrintDialogsStringId.SettingDialogLabelTop: return "Haut:";
                case PrintDialogsStringId.SettingDialogLabelBottom: return "Bas:";
                case PrintDialogsStringId.SettingDialogLabelLeft: return "Gauche:";
                case PrintDialogsStringId.SettingDialogLabelRight: return "Droite:";
                case PrintDialogsStringId.SettingDialogRadioPortrait: return "Portrait";
                case PrintDialogsStringId.SettingDialogRadioLandscape: return "Paysage";
                case PrintDialogsStringId.SchedulerSettingsLabelPrintStyle: return "Style d'impression";
                case PrintDialogsStringId.SchedulerSettingsDailyStyle: return "Style quotidien";
                case PrintDialogsStringId.SchedulerSettingsWeeklyStyle: return "Style hebdomadaire";
                case PrintDialogsStringId.SchedulerSettingsMonthlyStyle: return "Style mensuel";
                case PrintDialogsStringId.SchedulerSettingsDetailStyle: return "Détails Style";
                case PrintDialogsStringId.SchedulerSettingsButtonWatermark: return "Filigrane...";
                case PrintDialogsStringId.SchedulerSettingsLabelPrintRange: return "Plage d'impression";
                case PrintDialogsStringId.SchedulerSettingsLabelStyleSettings: return "Paramètres de style";
                case PrintDialogsStringId.SchedulerSettingsLabelPrintSettings: return "Paramètres d'impression";
                case PrintDialogsStringId.SchedulerSettingsLabelStartDate: return "Date de début";
                case PrintDialogsStringId.SchedulerSettingsLabelEndDate: return "Date de fin";
                case PrintDialogsStringId.SchedulerSettingsLabelStartTime: return "Heure de début";
                case PrintDialogsStringId.SchedulerSettingsLabelEndTime: return "Heure de fin";
                case PrintDialogsStringId.SchedulerSettingsLabelDateFont: return "Police de titre de date";
                case PrintDialogsStringId.SchedulerSettingsLabelAppointmentFont: return "Police de rendez-vous";
                case PrintDialogsStringId.SchedulerSettingsLabelLayout: return "Disposition";
                case PrintDialogsStringId.SchedulerSettingsPrintPageTitle: return "Imprimer le titre de la page";
                case PrintDialogsStringId.SchedulerSettingsPrintCalendar: return "Inclure le calendrier dans le titre";
                case PrintDialogsStringId.SchedulerSettingsPrintTimezone: return "Imprimer le fuseau horaire sélectionné";
                case PrintDialogsStringId.SchedulerSettingsPrintNotesBlank: return "Zone de notes (vide)";
                case PrintDialogsStringId.SchedulerSettingsPrintNotesLined: return "Zone de notes (doublée)";
                case PrintDialogsStringId.SchedulerSettingsNonworkingDays: return "Exclure les jours chômés";
                case PrintDialogsStringId.SchedulerSettingsExactlyOneMonth: return "Imprimer exactement un mois";
                case PrintDialogsStringId.SchedulerSettingsLabelWeeksPerPage: return "Semaines par page";
                case PrintDialogsStringId.SchedulerSettingsNewPageEach: return "Commencer une nouvelle page chaque";
                case PrintDialogsStringId.SchedulerSettingsStringDay: return "Jour";
                case PrintDialogsStringId.SchedulerSettingsStringMonth: return "Mois";
                case PrintDialogsStringId.SchedulerSettingsStringWeek: return "Semaine";
                case PrintDialogsStringId.SchedulerSettingsStringPage: return "Page";
                case PrintDialogsStringId.SchedulerSettingsStringPages: return "Pages";
                case PrintDialogsStringId.SchedulerSettingsLabelGroupBy: return "Regrouper Par:";
                case PrintDialogsStringId.SchedulerSettingsGroupByNone: return "Aucun";
                case PrintDialogsStringId.SchedulerSettingsGroupByResource: return "Ressource";
                case PrintDialogsStringId.SchedulerSettingsGroupByDate: return "Date";
                case PrintDialogsStringId.GridSettingsLabelPreview: return "Aperçu";
                case PrintDialogsStringId.GridSettingsLabelStyleSettings: return "Paramètres de style";
                case PrintDialogsStringId.GridSettingsLabelFitMode: return "Mode d'ajustement de la page:";
                case PrintDialogsStringId.GridSettingsLabelHeaderCells: return "En-tête des Cellules";
                case PrintDialogsStringId.GridSettingsLabelGroupCells: return "Grouper les cellules";
                case PrintDialogsStringId.GridSettingsLabelDataCells: return "Données des  cellules";
                case PrintDialogsStringId.GridSettingsLabelSummaryCells: return "Résumé des cellules";
                case PrintDialogsStringId.GridSettingsLabelBackground: return "Arrière plan";
                case PrintDialogsStringId.GridSettingsLabelBorderColor: return "Couleur de la bordure";
                case PrintDialogsStringId.GridSettingsLabelAlternatingRowColor: return "Couleur de ligne alternée";
                case PrintDialogsStringId.GridSettingsLabelPadding: return "Marges Intérieures";
                case PrintDialogsStringId.GridSettingsPrintGrouping: return "Grouper les impressions";
                case PrintDialogsStringId.GridSettingsPrintSummaries: return "Imprimer des résumés";
                case PrintDialogsStringId.GridSettingsPrintHiddenRows: return "Imprimer les lignes cachées";
                case PrintDialogsStringId.GridSettingsPrintHiddenColumns: return "Imprimer les colonnes cachées";
                case PrintDialogsStringId.GridSettingsPrintHeader: return "Imprimer l'en-tête sur chaque page";
                case PrintDialogsStringId.GridSettingsButtonWatermark: return "Filigrane...";
                case PrintDialogsStringId.GridSettingsFitPageWidth: return "Ajuster la largeur de la page";
                case PrintDialogsStringId.GridSettingsNoFit: return "NoFit";
                case PrintDialogsStringId.GridSettingsNoFitCentered: return "NoFitCentered";
                case PrintDialogsStringId.GridSettingsLabelPrint: return "Iprimer";
            }
            return string.Empty;
        }
    }
}
