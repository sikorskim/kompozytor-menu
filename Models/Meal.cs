using System;

namespace kompozytor_menu.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        public int MealTypeId { get; set; }
        [ForeignKey("MealTypeId")]
        public MealType MealType { get; set; }
    }
}