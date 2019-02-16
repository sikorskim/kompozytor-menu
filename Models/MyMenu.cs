using System;
using System.Collections.Generic;

namespace kompozytor_menu.Models
{
    public class MyMenu
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime GenerationTime { get; set; }
        public List<Meal> Meals { get; set; }
    }
}