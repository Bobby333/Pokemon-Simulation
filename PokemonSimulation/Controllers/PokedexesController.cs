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
    public class PokedexesController : Controller
    {
        private readonly PokemonSimulationContext _context;

        public PokedexesController(PokemonSimulationContext context)
        {
            _context = context;
        }

        // GET: Pokedexes
        //public async Task<IActionResult> Index()
        //{
        //    var pokedex = _context.Pokedex
        //       .AsNoTracking();
        //    return View(await pokedex.ToListAsync());
        //}
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new PokedexIndexData();
            viewModel.Pokemon = await _context.Pokedex
                  .Include(i => i.moveAssignments)
                  .ThenInclude(i => i.Move)
                  .Include(i => i.abilitysAssignments)
                  .ThenInclude(i => i.Ability)
                  .OrderBy(i => i.Pokemon_Name)
                  .ToListAsync();
            if (id != null)
            {
                ViewData["PokemonID"] = id.Value;
                Pokedex pokedex = viewModel.Pokemon.Where(
                    i => i.PokemonId == id.Value).Single();
                viewModel.Move = pokedex.moveAssignments.Select(s => s.Move);
                viewModel.Ability = pokedex.abilitysAssignments.Select(s => s.Ability);
            }


                return View(viewModel);
        }

        private void UpdatePokemonMoves(string[] selectedMoves, Pokedex MoveToUpdate)
        {
            if (selectedMoves == null)
            {
                MoveToUpdate.moveAssignments = new List<MoveAssignment>();
                return;
            }

            var selectedMovesHS = new HashSet<string>(selectedMoves);
            var PokemonMoves = new HashSet<int>
                (MoveToUpdate.moveAssignments.Select(c => c.Move.MoveId));
            foreach (var move in _context.Moves)
            {
                if (selectedMovesHS.Contains(move.MoveId.ToString()))
                {
                    if (!PokemonMoves.Contains(move.MoveId))
                    {
                        MoveToUpdate.moveAssignments.Add(new MoveAssignment { PokedexID = MoveToUpdate.PokemonId, MoveID = move.MoveId });
                    }
                }
                else
                {

                    if (PokemonMoves.Contains(move.MoveId))
                    {
                        MoveAssignment courseToRemove = MoveToUpdate.moveAssignments.FirstOrDefault(i => i.MoveID == move.MoveId);
                        _context.Remove(courseToRemove);
                    }
                }
            }
        }

        // GET: Pokedexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pokedex = await _context.Pokedex
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PokemonId == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // GET: Pokedexes/Create
        public IActionResult Create()
        {
            var Pokedex = new Pokedex();
            Pokedex.moveAssignments = new List<MoveAssignment>();
            Pokedex.abilitysAssignments = new List<AbilityAssignment>();
            PopulateAssignedAbilitys(Pokedex);
            PopulateAssignedMoves(Pokedex);
            return View();
        }

        private void PopulateAssignedMoves(Pokedex pokedex)
        {
            var allMoves = _context.Moves;
            var PokemonMoves = new HashSet<int>(pokedex.moveAssignments.Select(c => c.MoveID));
            var viewModel = new List<MoveAssignment>();
            foreach (var move in allMoves)
            {
                viewModel.Add(new MoveAssignment
                {
                    MoveID = move.MoveId,
                    Move = move,
                });
            }
            ViewData["Moves"] = viewModel;
        }
        private void PopulateAssignedAbilitys(Pokedex pokedex)
        {
            var allAbilitys = _context.Abilitys;
            var PokemonAbilitys = new HashSet<int>(pokedex.abilitysAssignments.Select(c => c.AbilityID));
            var viewModel = new List<AbilityAssignment>();
            foreach (var ability in allAbilitys)
            {
                viewModel.Add(new AbilityAssignment
                {
                    AbilityID = ability.Id_Ability,
                    Ability = ability,
                });
            }
            ViewData["Abilitys"] = viewModel;
        }
        
        // POST: Pokedexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokemonId,Pokemon_Name,Type1,Type2,HP,Attack,Defense,Special_Attack,Special_Defense,Speed,Total")] Pokedex pokedex, string[] selectedMoves, string[] SelectedAbility)
        {
            if (selectedMoves != null)
            {
                pokedex.moveAssignments = new List<MoveAssignment>();
                foreach (var move in selectedMoves)
                {
                    var moveToAdd = new MoveAssignment { PokedexID = pokedex.PokemonId, MoveID = int.Parse(move) };
                    pokedex.moveAssignments.Add(moveToAdd);
                }
            }
            if (SelectedAbility != null)
            {
                pokedex.abilitysAssignments = new List<AbilityAssignment>();
                foreach (var ability in SelectedAbility)
                {
                    var abilityToAdd = new AbilityAssignment { PokedexID = pokedex.PokemonId, AbilityID = int.Parse(ability) };
                    pokedex.abilitysAssignments.Add(abilityToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(pokedex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            PopulateAssignedAbilitys(pokedex);
            PopulateAssignedMoves(pokedex);
            return View(pokedex);
        }

        // GET: Pokedexes/Edit/5
        public async Task<IActionResult> Edit(int? id, string[] SelectedMoves)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }
            var Pokedex = new Pokedex();
            Pokedex.moveAssignments = new List<MoveAssignment>();
            Pokedex.abilitysAssignments = new List<AbilityAssignment>();
            
            PopulateAssignedAbilitys(Pokedex);
            PopulateAssignedMoves(Pokedex);
            return View(pokedex);
        }

        // POST: Pokedexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PokemonId,Pokemon_Name,Type1,Type2,HP,Attack,Defense,Special_Attack,Special_Defense,Speed,Total")] Pokedex pokedex, string[] selectedMoves, string[] SelectedAbility)
        {
            if (selectedMoves != null)
            {
                pokedex.moveAssignments = new List<MoveAssignment>();
                foreach (var move in selectedMoves)
                {
                    var moveToAdd = new MoveAssignment { PokedexID = pokedex.PokemonId, MoveID = int.Parse(move) };
                    pokedex.moveAssignments.Clear();
                    pokedex.moveAssignments.Add(moveToAdd);
                }
            }
            if (SelectedAbility != null)
            {
                pokedex.abilitysAssignments = new List<AbilityAssignment>();
                foreach (var ability in SelectedAbility)
                {
                    var abilityToAdd = new AbilityAssignment { PokedexID = pokedex.PokemonId, AbilityID = int.Parse(ability) };
                    pokedex.abilitysAssignments.Clear();
                    pokedex.abilitysAssignments.Add(abilityToAdd);
                }
            }


     

            if (id != pokedex.PokemonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokedex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokedexExists(pokedex.PokemonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //UpdatePokemonMoves(selectedMoves, PokemonToUpdate);
            PopulateAssignedAbilitys(pokedex);
            PopulateAssignedMoves(pokedex);
            return View(pokedex);
        }

        private void PopulateAbilityDropDownList(object selectedAbility = null)
        {

            List<object> newList = new List<object>();
            foreach (var ability in _context.Abilitys)
                newList.Add(new
                {
                    Id = ability.Id_Ability,
                    Name = ability.Ability_Name
                });
            ViewBag.PokemonId = new SelectList(newList, "Id", "Name", selectedAbility);
        }

        // GET: Pokedexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex
                .FirstOrDefaultAsync(m => m.PokemonId == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // POST: Pokedexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokedex = await _context.Pokedex.FindAsync(id);
            _context.Pokedex.Remove(pokedex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokedexExists(int id)
        {
            return _context.Pokedex.Any(e => e.PokemonId == id);
        }
    }
}
