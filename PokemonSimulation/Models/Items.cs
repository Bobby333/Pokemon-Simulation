using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set;}
        public string Item_Name { get; set; }
        public string Item_Description { get; set; }
        public int Item_boost { get; set; }
    }
}
