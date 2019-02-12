using System;

namespace kompozytor_menu.Models
{
    public class MyMenu
    {
        public int Id { get; set; }
        public int SoupId { get; set; }
        public int MeatId { get; set; }
        [ForeignKey("MeatId")]
        public virtual Meat Meat { get; set; }
        [ForeignKey("SoupId")]
        public virtual Soup Soup { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime GenerationTime { get; set; }
    }
}