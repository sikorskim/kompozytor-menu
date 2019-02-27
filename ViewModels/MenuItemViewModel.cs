using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kompozytor_menu.ViewModels
{
    public class MenuItemViewModel
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public int PackageId { get; set; }

        public MenuItemViewModel(int mealId, string name, decimal price, int packageId)
        {
            MealId=mealId;
            Name=name;
            Price=price;
            PackageId=packageId;            
        }
    }
}