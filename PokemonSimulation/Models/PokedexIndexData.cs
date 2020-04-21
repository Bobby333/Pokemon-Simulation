using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class PokedexIndexData
    {
        public IEnumerable<Pokedex> Pokemon { get; set; }
        public IEnumerable<Moves> Move { get; set; }
        public IEnumerable<Abilitys> Ability { get; set; }
    }
}
