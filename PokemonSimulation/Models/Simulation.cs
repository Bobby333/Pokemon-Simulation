using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class Simulations
    {
        [Key]
        public int SimulationID { get; set; }
        public ICollection<Pokedex> SPokemon { get; set; }

    }
}
