using System.Drawing;

namespace Primary.SchoolApp.DTO
{
    public  record ListingItem
    {
        public int Id { get; set; } 
        public string FrenchName { get; set; }
        public string EnglishName { get; set; }
        public string FrenchDescription { get; set; }
        public string EnglishDescription { get; set; }
        public int ModuleId {  get; set; }
        public Image Image { get; set; }
    }

}
