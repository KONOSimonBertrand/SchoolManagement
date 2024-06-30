using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Model
{/// <summary>
  /// Cette classe represente une fonction
  /// Exemple Enseignant
  /// </summary>
    public class Job 
    {

        public int Id { get; set; }
        public string? Name { get; set; }

       
        public override bool Equals(object? obj)
        {
            if (obj is not Job other) return false;
            return (this.Id == other.Id || this.Name == other.Name);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
