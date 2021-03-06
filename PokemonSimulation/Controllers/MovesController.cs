﻿using System;
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
    public class MovesController : Controller
    {
        private readonly PokemonSimulationContext _context;

        public MovesController(PokemonSimulationContext context)
        {
            _context = context;
        }

        // GET: Moves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moves.ToListAsync());
        }

        // GET: Moves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moves = await _context.Moves
                .FirstOrDefaultAsync(m => m.MoveId == id);
            if (moves == null)
            {
                return NotFound();
            }

            return View(moves);
        }

        // GET: Moves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoveId,Move_Name,Move_Description,Move_Power,Move_Type,Move_Amount,Accuracy,Move_dType")] Moves moves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moves);
        }

        // GET: Moves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moves = await _context.Moves.FindAsync(id);
            if (moves == null)
            {
                return NotFound();
            }
            return View(moves);
        }

        // POST: Moves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoveId,Move_Name,Move_Description,Move_Power,Move_Type,Move_Amount,Accuracy,Move_dType")] Moves moves)
        {
            if (id != moves.MoveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovesExists(moves.MoveId))
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
            return View(moves);
        }

        // GET: Moves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moves = await _context.Moves
                .FirstOrDefaultAsync(m => m.MoveId == id);
            if (moves == null)
            {
                return NotFound();
            }

            return View(moves);
        }

        // POST: Moves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moves = await _context.Moves.FindAsync(id);
            _context.Moves.Remove(moves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovesExists(int id)
        {
            return _context.Moves.Any(e => e.MoveId == id);
        }
    }
}
