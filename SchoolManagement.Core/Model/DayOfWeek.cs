
namespace SchoolManagement.Core.Model
{
    public class DayOfWeek
    {

        public int Id { get; set; }
        public string Name { get; set; }
        //public DayOfWeek GetDay(int id)
        //{
        //    var day = new Data.Entity.DayOfWeek(1, "DIMANCHE");
        //    switch (id)
        //    {

        //        case 0:
        //            day = new Data.Entity.DayOfWeek(0, "DIMANCHE");
        //            break;
        //        case 1:
        //            day = new Data.Entity.DayOfWeek(1, "LUNDI");
        //            break;
        //        case 2:
        //            day = new Data.Entity.DayOfWeek(2, "MARDI");
        //            break;

        //        case 3:
        //            day = new Data.Entity.DayOfWeek(3, "MERCREDI");
        //            break;

        //        case 4:
        //            day = new Data.Entity.DayOfWeek(4, "JEUDI");
        //            break;
        //        case 5:
        //            day = new Data.Entity.DayOfWeek(5, "VENDREDI");
        //            break;
        //        case 6:
        //            day = new Data.Entity.DayOfWeek(6, "SAMEDI");
        //            break;
        //    }
        //    return day;
        //}
        public DayOfWeek()
        {

        }
        public DayOfWeek(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj is not DayOfWeek other)
                return false;
            return other.Id == this.Id ;
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
