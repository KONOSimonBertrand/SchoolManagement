

namespace SchoolManagement.Core.Model
{
    public class InsolvencyState
    {
        public int Id { get; set; }
        public bool Value { get; set; }

        public InsolvencyState()
        {

        }
        public InsolvencyState(int id, bool value)
        {
            this.Id = id;
            this.Value = value;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not InsolvencyState other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
    }
}
