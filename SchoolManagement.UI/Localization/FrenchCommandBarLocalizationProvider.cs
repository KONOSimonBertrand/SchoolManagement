using Telerik.WinControls.UI;

namespace SchoolManagement.UI.Localization
{
    public class FrenchCommandBarLocalizationProvider : CommandBarLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case CommandBarStringId.CustomizeDialogChooseToolstripLabelText: return "Choisissez une toolstrip pour réorganiser:";
                case CommandBarStringId.CustomizeDialogCloseButtonText: return "Fermer";
                case CommandBarStringId.CustomizeDialogItemsPageTitle: return "Items";
                case CommandBarStringId.CustomizeDialogMoveDownButtonText: return "Déplacer vers le bas";
                case CommandBarStringId.CustomizeDialogMoveUpButtonText: return "Déplacer vers le haut";
                case CommandBarStringId.CustomizeDialogResetButtonText: return "Réinitialiser";
                case CommandBarStringId.CustomizeDialogTitle: return "Personnaliser";
                case CommandBarStringId.CustomizeDialogToolstripsPageTitle: return "Toolstrips";
                case CommandBarStringId.OverflowMenuAddOrRemoveButtonsText: return "Ajouter ou supprimer des boutons";
                case CommandBarStringId.OverflowMenuCustomizeText: return "Personnaliser...";
                case CommandBarStringId.ContextMenuCustomizeText: return "Personnaliser...";
                default: return base.GetLocalizedString(id);
            }
        }
    }
}
