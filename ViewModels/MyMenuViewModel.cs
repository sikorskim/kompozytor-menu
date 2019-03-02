using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kompozytor_menu.ViewModels
{
    public class MyMenuViewModel
    {                
        public List<MyMenuItemViewModel> MyMenuItems { get; set; }

        public MyMenuViewModel(List<MyMenuItemViewModel> myMenuItems)
        {
            MyMenuItems = myMenuItems;
        }
    }
}