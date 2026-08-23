
namespace SchoolManagement.Core.Enum
{
    public enum TypeFee
    {
        TuitionFee,
        Subscription,
        SchoolSupply,
        Unknown
    }

    public enum FlowCategory
    {
        TuitionFee = 1,
        /// <summary>
        ///  Représente les flux d'entrée en abonnement.
        /// </summary>
        Subscription = 2,
        /// <summary>
        /// Représente les flux d'entrée en nature (fournitures scolaires, livres, uniformes, vêtements, équipements informatiques).
        /// </summary>
        SchoolSupplie = 3,
        /// <summary>
        /// Représente les flux de sortie en dépense.
        /// </summary>
        Expense = 4,
        /// <summary>
        /// Représente les flux d'entrée en approvisionnement.
        /// </summary>
        CashSupply = 5,
    }
    /// <summary>
    ///  Représente les différents types de transactions (Transaction en numéraire, Transaction en nature).
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        ///Transaction en numéraire.
        /// </summary>
        CashTransaction = 1,
        /// <summary>
        /// Transaction en nature .
        /// </summary>
        TransactionInKind = 2,
    }

    public enum FlowType
    {
        /// <summary>
        /// Représente les flux d'entrée.
        /// </summary>
        Inflow  = 1,
        /// <summary>
        /// Représente les flux de sortie.
        /// </summary>
        Outflow = 2,
    }

    public enum FlowDomain
    {
        Finance = 1,
        /// <summary>
        /// Flux de transport.
        /// </summary>
        Transport = 2,
        /// <summary>
        /// Flux de cantine.
        /// </summary>
        Canteen = 3,
        /// <summary>
        /// Activité periscolaire (sport, culture, art, musique, théâtre, etc.).
        /// </summary>
        SchoolActivity = 4,
    }

}
