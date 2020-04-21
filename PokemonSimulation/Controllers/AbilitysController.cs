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
    public class AbilitysController : Controller
    {
        private readonly PokemonSimulationContext _context;

        public AbilitysController(PokemonSimulationContext context)
        {
            _context = context;
        }

        // GET: Abilitys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Abilitys.ToListAsync());
        }

        // GET: Abilitys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abilitys = await _context.Abilitys
                .FirstOrDefaultAsync(m => m.Id_Ability == id);
            if (abilitys == null)
            {
                return NotFound();
            }

            return View(abilitys);
        }

        // GET: Abilitys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abilitys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Ability,Ability_Name,Ability_Description,Ability_Boost")] Abilitys abilitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abilitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abilitys);
        }

        // GET: Abilitys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abilitys = await _context.Abilitys.FindAsync(id);
            if (abilitys == null)
            {
                return NotFound();
            }
            return View(abilitys);
        }

        // POST: Abilitys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Ability,Ability_Name,Ability_Description,Ability_Boost")] Abilitys abilitys)
        {
            if (id != abilitys.Id_Ability)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abilitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbilitysExists(abilitys.Id_Ability))
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
            return View(abilitys);
        }

        // GET: Abilitys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abilitys = await _context.Abilitys
                .FirstOrDefaultAsync(m => m.Id_Ability == id);
            if (abilitys == null)
            {
                return NotFound();
            }

            return View(abilitys);
        }

        // POST: Abilitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abilitys = await _context.Abilitys.FindAsync(id);
            _context.Abilitys.Remove(abilitys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbilitysExists(int id)
        {
            return _context.Abilitys.Any(e => e.Id_Ability == id);
        }
    }
}
