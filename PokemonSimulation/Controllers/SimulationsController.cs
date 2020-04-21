using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonSimulation.Data;
using PokemonSimulation.Models;

namespace PokemonSimulation.Controllers
{
    
    public class SimulationsController : Controller
    {
        List<Moves> Moves1 = new List<Moves>();
        List<Moves> Moves2 = new List<Moves>();
        Abilitys Ability1;
        Abilitys Ability2;
        Items item1Selected;
        Items item2Selected;
        private readonly PokemonSimulationContext _context;

        public SimulationsController(PokemonSimulationContext context)
        {
            _context = context;
        }

        // GET: Simulations
        public async Task<IActionResult> Index(string[] selectedPokemon)
        {
            var viewModel = new PokedexIndexData();
            viewModel.Pokemon = await _context.Pokedex
                  .Include(i => i.moveAssignments)
                  .ThenInclude(i => i.Move)
                  .Include(i => i.abilitysAssignments)
                  .ThenInclude(i => i.Ability)
                  .OrderBy(i => i.Pokemon_Name)
                  .ToListAsync();

            PopulateAssignedMoves();

           
            return View(viewModel);
            
           
        }

        private void PopulateItems()
        {
            var allItem = _context.Items;
            var viewModel = new List<Items>();
            foreach (var item in allItem)
            {
                viewModel.Add(new Items
                {
                    ItemId = item.ItemId,
                    Item_Name = item.Item_Name
                });
            }
            ViewData["Item"] = viewModel;
        }
        private void PopulateAssignedMoves()
        {
            var allPokemon = _context.Pokedex;
            var viewModel = new List<Pokedex>();
            foreach (var pokemon in allPokemon)
            {
                viewModel.Add(new Pokedex
                {
                    PokemonId = pokemon.PokemonId,
                    Pokemon_Name = pokemon.Pokemon_Name,
                });
            }
            ViewData["Pokemon"] = viewModel;
        }
       

        public async Task<IActionResult> Moves(Pokedex pokedex, string[] selectedPokemon)
        {
            var sPokemon = new List<Pokedex>();
            var viewModel = new PokedexIndexData();
            viewModel.Pokemon = await _context.Pokedex
                  .Include(i => i.moveAssignments)
                  .ThenInclude(i => i.Move)
                  .Include(i => i.abilitysAssignments)
                  .ThenInclude(i => i.Ability)
                  .OrderBy(i => i.Pokemon_Name)
                  .ToListAsync();
            if (selectedPokemon.Count() != 0)
            {
                foreach (var pokemon in selectedPokemon)
                    if (pokemon != null)
                    {
                        ViewData["PokemonID"] = pokemon;
                        pokedex = viewModel.Pokemon.Where(
                            i => i.PokemonId == Convert.ToInt32(pokemon)).Single();
                        viewModel.Move = pokedex.moveAssignments.Select(s => s.Move);
                        viewModel.Ability = pokedex.abilitysAssignments.Select(s => s.Ability);
                        foreach (var item in viewModel.Pokemon)
                        {
                            if (item.PokemonId == Convert.ToInt32(pokemon))
                            {
                                var pokemonToAdd = item;
                                sPokemon.Add(item);
                            }
                        }
                    }
            }
            return View(sPokemon);
        }

        public async Task<IActionResult> Item(Pokedex pokedex,
            string[] selectedMove1, 
            string[] selectedMove2,
            string selectedAbility1, 
            string selectedAbility2, 
            string SelectedPokemon2, 
            string SelectedPokemon1)
        {
          
            var sPokemon = new List<Pokedex>();
            var viewModel = new PokedexIndexData();
            viewModel.Pokemon = await _context.Pokedex
                  .Include(i => i.moveAssignments)
                  .ThenInclude(i => i.Move)
                  .Include(i => i.abilitysAssignments)
                  .ThenInclude(i => i.Ability)
                  .OrderBy(i => i.Pokemon_Name)
                  .ToListAsync();

                        foreach (var item in viewModel.Pokemon)
                        {
                            if (item.PokemonId == Convert.ToInt32(SelectedPokemon2))
                            {
                                var pokemonToAdd = item;
                                sPokemon.Add(item);
                            }
                        }

            foreach (var item in viewModel.Pokemon)
            {
                if (item.PokemonId == Convert.ToInt32(SelectedPokemon1))
                {
                    var pokemonToAdd = item;
                    sPokemon.Add(item);
                }
            }


            ViewData["PokemonID1"] = SelectedPokemon1;
            ViewData["PokemonID2"] = SelectedPokemon2;
            ViewData["Move1"] = selectedMove1;
            ViewData["Move2"] = selectedMove2;
            ViewData["Ability1"] = selectedAbility1;
            ViewData["Ability2"] = selectedAbility2;


            PopulateItems();
            return View(sPokemon);
        }

        private string winnerCalc(
        Pokedex pokemon1,
        Pokedex pokemon2,
        List<Moves> Moves1,
        List<Moves> Moves2,
        Abilitys Ability1,
        Abilitys Ability2,
        Items item1Selected,
        Items item2Selected)
        {
           
            
                double p1HP = pokemon1.HP;
                int p1Atk = pokemon1.Attack;
                int p1Def = pokemon1.Defense;
                int p1SpAtk = pokemon1.Special_Attack;
                int p1SpDef = pokemon1.Special_Defense;
                int p1Spd = pokemon1.Speed;
                double p2HP = pokemon2.HP;
                int p2Atk = pokemon2.Attack;
                int p2Def = pokemon2.Defense;
                int p2SpAtk = pokemon2.Special_Attack;
                int p2SpDef = pokemon2.Special_Defense;
                int p2Spd = pokemon2.Speed;
                Moves ChosenMove;
                while (p1HP > 0 && p2HP > 0)
                {
                    Random random = new Random();
                    int randomMove1 = Convert.ToInt32(random.Next(0, 4));
                    int randomMove2 = Convert.ToInt32(random.Next(0, 4));
                    int randomPower1 = Convert.ToInt32(random.Next(217, 255));
                    int randomPower2 = Convert.ToInt32(random.Next(217, 255));

                    if (p1Spd >= p2Spd)
                    {
                        if (p1HP > 0)
                        {
                            ChosenMove = Moves1[randomMove1];
                            if (ChosenMove.Move_dType == "Special")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1SpAtk * ChosenMove.Move_Power) / p2SpDef) / 50) + 2) * 1.5) * 1 / 10) * randomPower1) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1SpAtk * ChosenMove.Move_Power) / p2SpDef) / 50) + 2) * 1) * 1 / 10) * randomPower1) / 255);
                                }
                            }
                            if (ChosenMove.Move_dType == "Physical")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1.5) * 1 / 10) * randomPower1) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1) * 1 / 10) * randomPower1) / 255);
                                }
                            }

                        }
                        if (p2HP > 0)
                        {
                            ChosenMove = Moves2[randomMove2];
                            if (ChosenMove.Move_dType == "Special")
                            {
                                if (ChosenMove.Move_Type == pokemon2.Type1 || ChosenMove.Move_Type == pokemon2.Type2)
                                {
                                    p1HP = p1HP - (((((((((2 * 50 / 5 + 2) * p2SpAtk * ChosenMove.Move_Power) / p1SpDef) / 50) + 2) * 1.5) * 1 / 10) * randomPower2) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon2.Type1 || ChosenMove.Move_Type != pokemon2.Type2)
                                {
                                    p1HP = p1HP - (((((((((2 * 50 / 5 + 2) * p2SpAtk * ChosenMove.Move_Power) / p1SpDef) / 50) + 2) * 1) * 1 / 10) * randomPower2) / 255);
                                }
                            }
                            if (ChosenMove.Move_dType == "Physical")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1.5) * 1 / 10) * randomPower2) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1) * 1 / 10) * randomPower2) / 255);
                                }
                            }

                        }

                    }
                    if (p2Spd > p1Spd)
                    {
                        if (p2HP > 0)
                        {
                            ChosenMove = Moves2[randomMove2];
                            if (ChosenMove.Move_dType == "Special")
                            {
                                if (ChosenMove.Move_Type == pokemon2.Type1 || ChosenMove.Move_Type == pokemon2.Type2)
                                {
                                    p1HP = p1HP - (((((((((2 * 50 / 5 + 2) * p2SpAtk * ChosenMove.Move_Power) / p1SpDef) / 50) + 2) * 1.5) * 1 / 10) * randomPower2) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon2.Type1 || ChosenMove.Move_Type != pokemon2.Type2)
                                {
                                    p1HP = p1HP - (((((((((2 * 50 / 5 + 2) * p2SpAtk * ChosenMove.Move_Power) / p1SpDef) / 50) + 2) * 1) * 1 / 10) * randomPower2) / 255);
                                }
                            }
                            if (ChosenMove.Move_dType == "Physical")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1.5) * 1 / 10) * randomPower2) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1) * 1 / 10) * randomPower2) / 255);
                                }
                            }

                        }
                        if (p1HP > 0)
                        {
                            ChosenMove = Moves1[randomMove1];
                            if (ChosenMove.Move_dType == "Special")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1SpAtk * ChosenMove.Move_Power) / p2SpDef) / 50) + 2) * 1.5) * 1 / 10) * randomPower1) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1SpAtk * ChosenMove.Move_Power) / p2SpDef) / 50) + 2) * 1) * 1 / 10) * randomPower1) / 255);
                                }
                            }
                            if (ChosenMove.Move_dType == "Physical")
                            {
                                if (ChosenMove.Move_Type == pokemon1.Type1 || ChosenMove.Move_Type == pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1.5) * 1 / 10) * randomPower1) / 255);
                                }
                                if (ChosenMove.Move_Type != pokemon1.Type1 || ChosenMove.Move_Type != pokemon1.Type2)
                                {
                                    p2HP = p2HP - (((((((((2 * 50 / 5 + 2) * p1Atk * ChosenMove.Move_Power) / p2Def) / 50) + 2) * 1) * 1 / 10) * randomPower1) / 255);
                                }
                            }

                        }


                    }
                }
            if (p2HP < 0)
            {
                return "p1";
            }
            else if (p1HP < 0)
            {
                return "p2";
            }
          
                return "tie";
            
                
            
           
        }

        public async Task<IActionResult> Simulate(Pokedex pokedex,
            string selectedItem1,
             string selectedItem2,
            string[] selectedMove1,
            string[] selectedMove2,
            string selectedAbility1,
            string selectedAbility2,
            string SelectedPokemon2,
            string SelectedPokemon1)
        {
            int Pokemon1Wins = 0;
            int Pokemon2Wins = 0;
            Pokedex pokemon1 = null;
            Pokedex pokemon2 = null;
            List<Moves> Moves1 = new List<Moves>();
            List<Moves> Moves2 = new List<Moves>();
            Abilitys Ability1 = null;
            Abilitys Ability2 = null;
            Items item1Selected = null;
            Items item2Selected = null;
            var allMoves = _context.Moves;
            var allAbilities = _context.Abilitys;
            var allPokemon = _context.Pokedex;
            var allItems = _context.Items;
                foreach(var item in allItems)
            {
                if (item.ItemId == Convert.ToInt32(selectedItem1))
                {
                    item1Selected = item;
                }
            }
            foreach (var item in allItems)
            {
                if (item.ItemId == Convert.ToInt32(selectedItem2))
                {
                    item2Selected = item;
                }
            }
            foreach (var ability in allAbilities)
            {
                if (ability.Id_Ability == Convert.ToInt32(selectedAbility1))
                {
                    Ability1 = ability;
                }
            }
            foreach (var ability in allAbilities)
            {
                if (ability.Id_Ability == Convert.ToInt32(selectedAbility2))
                {
                    Ability2 = ability;
                }
            }
            foreach (var move in allMoves)
            {
                foreach (var smove in selectedMove1)
                {
                    if (move.MoveId == Convert.ToInt32(smove))
                    {
                        Moves1.Add(move);
                    }
                }
            }
            foreach (var move in allMoves)
            {
                foreach (var smove in selectedMove2)
                {
                    if (move.MoveId == Convert.ToInt32(smove))
                    {
                        Moves2.Add(move);
                    }
                }
            }
            foreach (var pokemon in allPokemon)
            {
                    if (pokemon.PokemonId == Convert.ToInt32(SelectedPokemon1))
                    {
                    pokemon1 = pokemon;
                    }
            }
            foreach (var pokemon in allPokemon)
            {
                if (pokemon.PokemonId == Convert.ToInt32(SelectedPokemon2))
                {
                    pokemon2 = pokemon;
                }
            }
            for (var i = 0; i < 10; i++)
            {
                string winner = winnerCalc(pokemon1, pokemon2, Moves1, Moves2, Ability1, Ability2, item1Selected, item2Selected);
                if (winner == "p1")
                {
                    Pokemon1Wins++;
                }
                if (winner == "p2")
                {
                    Pokemon2Wins++;
                }
            }
            ViewData["Pokemon1Wins"] = Pokemon1Wins;
            ViewData["Pokemon2Wins"] = Pokemon2Wins;
            ViewData["Pokemon1"] = pokemon1;
            ViewData["Pokemon2"] = pokemon2;
            return View();
        }



    }
}
