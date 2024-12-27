

namespace SchoolManagement.Application.Extensions
{
    public static class ConvertionExtension
    {
        public static string ToValidateState(this bool value)
        {
            return value ? "Validé" : "Validation en attente";
        }
    }
}
