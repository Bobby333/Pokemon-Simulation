using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class Moves
    {
        [Key]
        public int MoveId { get; set; }
        public string Move_Name { get; set; }
        public string Move_Description { get; set; }
        public int Move_Power { get; set; }
        public string Move_Type { get; set; }
        public int Move_Amount { get; set; }
        public int Accuracy { get; set; }

        public string Move_dType { get; set; }
    }

    public enum Move_dType
    {
        Special,
        Physical
    }
}
