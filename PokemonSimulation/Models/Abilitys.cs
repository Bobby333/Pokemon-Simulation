using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class Abilitys
    {
        [Key]
        public int Id_Ability { get; set; }
        public string Ability_Name { get; set; }
        public string Ability_Description { get; set; }
        public int Ability_Boost { get; set; }
    }
}
