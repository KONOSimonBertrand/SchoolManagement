

namespace SchoolManagement.Core.Model
{ /// <summary>
  /// Cette classe represente un groupe d'employé
  /// Exemple STAFF ADMINISTRATIF
  /// </summary>
    public class EmployeeGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not EmployeeGroup other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name??"";
        }

    }
}
