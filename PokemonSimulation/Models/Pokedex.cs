using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonSimulation.Models
{
    public class Pokedex
    {
        [Key]
        public int PokemonId { get; set; }
        public string Pokemon_Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special_Attack { get; set; }
        public int Special_Defense { get; set; }
        public int Speed { get; set; }
        public int Total { get; set; }
        public ICollection<AbilityAssignment> abilitysAssignments { get;set; }
        public ICollection<MoveAssignment> moveAssignments { get; set; }
        

    }

}
