using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class MoveAssignment
    {
        [Key]
        public int AssighnedID { get; set; }
        public int MoveID { get; set; }
        public int PokedexID { get; set; }
        public Moves Move { get; set; }
        public Pokedex Pokedex { get; set; }
    }
}
