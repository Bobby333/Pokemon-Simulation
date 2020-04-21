using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class AbilityAssignment
    {
        [Key]
        public int AssiggnedAbilityID { get; set; }
        public int AbilityID { get; set; }
        public int PokedexID { get; set; }
        public Abilitys Ability { get; set; }
        public Pokedex Pokedex { get; set; }
    }
}
