using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionUsine.Data;
using GestionUsine.Models;

namespace GestionUsine.Controllers
{
    public class ChefEquipesController : Controller
    {
        private readonly GestionUsineContext _context;

        public ChefEquipesController(GestionUsineContext context)
        {
            _context = context;
        }

        // GET: ChefEquipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChefEquipe.ToListAsync());
        }

        // GET: ChefEquipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefEquipe = await _context.ChefEquipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chefEquipe == null)
            {
                return NotFound();
            }

            return View(chefEquipe);
        }

        // GET: ChefEquipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChefEquipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,MotDePasse")] ChefEquipe chefEquipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chefEquipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chefEquipe);
        }

        // GET: ChefEquipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefEquipe = await _context.ChefEquipe.FindAsync(id);
            if (chefEquipe == null)
            {
                return NotFound();
            }
            return View(chefEquipe);
        }

        // POST: ChefEquipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,MotDePasse")] ChefEquipe chefEquipe)
        {
            if (id != chefEquipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chefEquipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefEquipeExists(chefEquipe.Id))
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
            return View(chefEquipe);
        }

        // GET: ChefEquipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefEquipe = await _context.ChefEquipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chefEquipe == null)
            {
                return NotFound();
            }

            return View(chefEquipe);
        }

        // POST: ChefEquipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chefEquipe = await _context.ChefEquipe.FindAsync(id);
            _context.ChefEquipe.Remove(chefEquipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChefEquipeExists(int id)
        {
            return _context.ChefEquipe.Any(e => e.Id == id);
        }
    }
}
