using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonSimulation.Models;

namespace PokemonSimulation.Data
{
    public class PokemonSimulationContext : DbContext
    {
        public PokemonSimulationContext (DbContextOptions<PokemonSimulationContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonSimulation.Models.Abilitys> Abilitys { get; set; }

        public DbSet<PokemonSimulation.Models.Items> Items { get; set; }

        public DbSet<PokemonSimulation.Models.Moves> Moves { get; set; }

        public DbSet<PokemonSimulation.Models.Pokedex> Pokedex { get; set; }

        public DbSet<PokemonSimulation.Models.Simulations> Simulation { get; set; }
    }
}
