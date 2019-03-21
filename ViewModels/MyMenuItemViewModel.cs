using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kompozytor_menu.ViewModels
{
    public class MyMenuItemViewModel
    {                
        public int Id { get; set; }
        public string Name { get; set; }        
        public int PackageId { get; set; }
        public int MealTypeId { get; set; }
        public bool Selected { get; set; }

        public MyMenuItemViewModel()
        { }
        public MyMenuItemViewModel(int id, string name, int packageId, int mealTypeId)
        {
            Id=id;
            Name=name;
            PackageId=packageId;
            MealTypeId=mealTypeId;
            Selected=false;
        }
    }
}