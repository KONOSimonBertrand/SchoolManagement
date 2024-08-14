using Telerik.WinControls;

namespace SchoolManagement.UI.Localization
{
    class FrenchRadMessageLocalizationProvider : RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.AbortButton: return "Abandonner";
                case RadMessageStringID.CancelButton: return "Annuler";
                case RadMessageStringID.IgnoreButton: return "Ignorer";
                case RadMessageStringID.NoButton: return "Non";
                case RadMessageStringID.OKButton: return "OK";
                case RadMessageStringID.RetryButton: return "Réessayer";
                case RadMessageStringID.YesButton: return "Oui";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
