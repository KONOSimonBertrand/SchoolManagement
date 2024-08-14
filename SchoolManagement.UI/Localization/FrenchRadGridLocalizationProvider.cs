using Telerik.WinControls.UI.Localization;

namespace SchoolManagement.UI.Localization
{
    class FrenchRadGridLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.FilterFunctionBetween: return "Comprise";
                case RadGridStringId.FilterFunctionContains: return "Contient";
                case RadGridStringId.FilterFunctionDoesNotContain: return "Ne contient pas";
                case RadGridStringId.FilterFunctionEndsWith: return "Se termine par";
                case RadGridStringId.FilterFunctionEqualTo: return "Egale";
                case RadGridStringId.FilterFunctionGreaterThan: return "Supérieure";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo: return "Supérieure ou égale à";
                case RadGridStringId.FilterFunctionIsEmpty: return "Est vide";
                case RadGridStringId.FilterFunctionIsNull: return "Es nulle";
                case RadGridStringId.FilterFunctionLessThan: return "Inférieure à";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo: return "Inférieure ou égale à";
                case RadGridStringId.FilterFunctionNoFilter: return "Pas de filtre";
                case RadGridStringId.FilterFunctionNotBetween: return "N'est pas comprise";
                case RadGridStringId.FilterFunctionNotEqualTo: return "N'est pas égale à";
                case RadGridStringId.FilterFunctionNotIsEmpty: return "N'est pas vide";
                case RadGridStringId.FilterFunctionNotIsNull: return "N'est pas nulle";
                case RadGridStringId.FilterFunctionStartsWith: return "Commence par";
                case RadGridStringId.FilterFunctionCustom: return "Personnaliser";

                case RadGridStringId.FilterOperatorBetween: return "Comprise";
                case RadGridStringId.FilterOperatorContains: return "Contient";
                case RadGridStringId.FilterOperatorDoesNotContain: return "Ne contient pas";
                case RadGridStringId.FilterOperatorEndsWith: return "Se termine par";
                case RadGridStringId.FilterOperatorEqualTo: return "Egale";
                case RadGridStringId.FilterOperatorGreaterThan: return "Supérieure à";
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo: return "Supérieure ou égale";
                case RadGridStringId.FilterOperatorIsEmpty: return "Est vide";
                case RadGridStringId.FilterOperatorIsNull: return "Est nulle";
                case RadGridStringId.FilterOperatorLessThan: return "Inférieure à";
                case RadGridStringId.FilterOperatorLessThanOrEqualTo: return "Inférieure ou égale à";
                case RadGridStringId.FilterOperatorNoFilter: return "Pas de filtre";
                case RadGridStringId.FilterOperatorNotBetween: return "N'est pas comprise";
                case RadGridStringId.FilterOperatorNotEqualTo: return "N'est pas égale";
                case RadGridStringId.FilterOperatorNotIsEmpty: return "N'est pas vide";
                case RadGridStringId.FilterOperatorNotIsNull: return "N'est pas nulle";
                case RadGridStringId.FilterOperatorStartsWith: return "Commence par";
                case RadGridStringId.FilterOperatorIsLike: return "Comme";
                case RadGridStringId.FilterOperatorNotIsLike: return "Pas comme";
                case RadGridStringId.FilterOperatorIsContainedIn: return "Contenue dans";
                case RadGridStringId.FilterOperatorNotIsContainedIn: return "Ne figure pas dans";
                case RadGridStringId.FilterOperatorCustom: return "Personnaliser";

                case RadGridStringId.CustomFilterMenuItem: return "Personnaliser";
                case RadGridStringId.CustomFilterDialogCaption: return "Boite de diaglogue du filtre";
                case RadGridStringId.CustomFilterDialogLabel: return "Monter les ligne où:";
                case RadGridStringId.CustomFilterDialogRbAnd: return "Et";
                case RadGridStringId.CustomFilterDialogRbOr: return "Ou";
                case RadGridStringId.CustomFilterDialogBtnOk: return "OK";
                case RadGridStringId.CustomFilterDialogBtnCancel: return "Annuler";
                case RadGridStringId.CustomFilterDialogCheckBoxNot: return "Pas";
                case RadGridStringId.CustomFilterDialogTrue: return "Vrai";
                case RadGridStringId.CustomFilterDialogFalse: return "Faux";

                case RadGridStringId.FilterMenuAvailableFilters: return "Filtres disponibles";
                case RadGridStringId.FilterMenuSearchBoxText: return "Rechercher...";
                case RadGridStringId.FilterMenuClearFilters: return "Netoyer le filtre";
                case RadGridStringId.FilterMenuButtonOK: return "OK";
                case RadGridStringId.FilterMenuButtonCancel: return "Annuler";
                case RadGridStringId.FilterMenuSelectionAll: return "Tout";
                case RadGridStringId.FilterMenuSelectionAllSearched: return "Tous les résultat de la recherche";
                case RadGridStringId.FilterMenuSelectionNull: return "Nulle";
                case RadGridStringId.FilterMenuSelectionNotNull: return "N'est pas nulle";

                case RadGridStringId.FilterLogicalOperatorAnd: return "ET";
                case RadGridStringId.FilterLogicalOperatorOr: return "OU";
                case RadGridStringId.FilterCompositeNotOperator: return "PAS";

                case RadGridStringId.DeleteRowMenuItem: return "Supprimer la ligne";
                case RadGridStringId.SortAscendingMenuItem: return "Trier par ordre croissant";
                case RadGridStringId.SortDescendingMenuItem: return "Trier par ordre décroissant";
                case RadGridStringId.ClearSortingMenuItem: return "Effacer le tri";
                case RadGridStringId.ConditionalFormattingMenuItem: return "Conditions de mise en forme";
                case RadGridStringId.GroupByThisColumnMenuItem: return "Grouper par cette colonne";
                case RadGridStringId.UngroupThisColumn: return "Dissocier cette colonne";
                case RadGridStringId.ColumnChooserMenuItem: return "Sélecteur de colonne";
                case RadGridStringId.HideMenuItem: return "Cacher la colonne";
                case RadGridStringId.UnpinMenuItem: return "Détacher la colonne";
                case RadGridStringId.UnpinRowMenuItem: return "Détacher la ligne";
                case RadGridStringId.PinMenuItem: return "Etat épinglé";
                case RadGridStringId.PinAtLeftMenuItem: return "Epingler à gauche";
                case RadGridStringId.PinAtRightMenuItem: return "Epingler à droite";
                case RadGridStringId.PinAtBottomMenuItem: return "Epingler en bas";
                case RadGridStringId.PinAtTopMenuItem: return "Epingler en haut";
                case RadGridStringId.BestFitMenuItem: return "Meilleure mise en forme";
                case RadGridStringId.PasteMenuItem: return "Coller";
                case RadGridStringId.EditMenuItem: return "Modifier";
                case RadGridStringId.ClearValueMenuItem: return "Effacer la valeur";
                case RadGridStringId.CopyMenuItem: return "Copier";
                case RadGridStringId.AddNewRowString: return "Cliquer ici pour ajouter une nouvelle ligne";
                case RadGridStringId.ConditionalFormattingCaption: return "Règles de mise en forme";
                case RadGridStringId.ConditionalFormattingLblColumn: return "Formater uniquement les cellules avec";
                case RadGridStringId.ConditionalFormattingLblName: return "Nom de la règle:";
                case RadGridStringId.ConditionalFormattingLblType: return "Valeur de la cellule:";
                case RadGridStringId.ConditionalFormattingLblValue1: return "Valeur 1:";
                case RadGridStringId.ConditionalFormattingLblValue2: return "Valeur 2:";
                case RadGridStringId.ConditionalFormattingGrpConditions: return "Règles";
                case RadGridStringId.ConditionalFormattingGrpProperties: return "Propriétés de la règle";
                case RadGridStringId.ConditionalFormattingChkApplyToRow: return "Appliquer cette règle à toute la ligne";
                case RadGridStringId.ConditionalFormattingBtnAdd: return "Ajouter une nouvelle règle";
                case RadGridStringId.ConditionalFormattingBtnRemove: return "Supprimer la règle sélectionnée";
                case RadGridStringId.ConditionalFormattingBtnOK: return "OK";
                case RadGridStringId.ConditionalFormattingBtnCancel: return "Annuler";
                case RadGridStringId.ConditionalFormattingBtnApply: return "Appliquer";
                case RadGridStringId.ConditionalFormattingRuleAppliesOn: return "Rule applies on:";
                case RadGridStringId.ConditionalFormattingChooseOne: return "[Choisisser une]";
                case RadGridStringId.ConditionalFormattingEqualsTo: return "égale [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsNotEqualTo: return "n'est pas égale à [Valeu1]";
                case RadGridStringId.ConditionalFormattingStartsWith: return "commence par [Valeur1]";
                case RadGridStringId.ConditionalFormattingEndsWith: return "se termine par [Valeur1]";
                case RadGridStringId.ConditionalFormattingContains: return "contient [Valeur1]";
                case RadGridStringId.ConditionalFormattingDoesNotContain: return "ne contient pas [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsGreaterThan: return "est supérieure à [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual: return "est supérieure ou égale à [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsLessThan: return "est inférieure à [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsLessThanOrEqual: return "est inféfieure ou égale à [Valeur1]";
                case RadGridStringId.ConditionalFormattingIsBetween: return "est comprise entre [Valeur1] et [Valeur2]";
                case RadGridStringId.ConditionalFormattingIsNotBetween: return "n'est pas comprise entre [Valeur1] et [Valeur2]";

                case RadGridStringId.ColumnChooserFormCaption: return "Sélecteur de colonne";
                case RadGridStringId.ColumnChooserFormMessage: return "Faite glisser une colonne du\ngrid ici pour l'enlever \nde la vue en cours.";
                case RadGridStringId.GroupingPanelDefaultMessage: return "Faites glisser une colonne ici pour grouper par cette colonne.";
                case RadGridStringId.GroupingPanelHeader: return "Grouper par:";
                case RadGridStringId.NoDataText: return "Aucune donnée à afficher";
                case RadGridStringId.CompositeFilterFormErrorCaption: return "Erreur au niveau du filtre";
            }

            return string.Empty;
        }

    }
}
