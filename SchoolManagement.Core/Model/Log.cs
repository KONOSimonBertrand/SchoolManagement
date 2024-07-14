

using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe une action sur le systeme ou mouchard
    /// Exemple jout d'un utilisateur le 20/02/1983 a root
    /// </summary>
    public class Log
    {
        public Guid Id { get; set; }
        public string? UserAction { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public override string ToString()
        {
            return Id+"-"+UserAction;
        }
        public override bool Equals(object? obj)
        {
            if(obj is not Log log) return false;
            return this.Id.Equals(log.Id);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
