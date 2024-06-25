using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFirst.Data;
using MvcFirst.Models;

namespace MvcFirst.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly MvcFirstContext _context;

        public SuggestionController(MvcFirstContext context)
        {
            _context = context;
        }

        // GET: Suggestion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Places.ToListAsync());
        }

        // GET: Suggestion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var places = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // GET: Suggestion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suggestion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cordinates,Stars")] Places places)
        {
            if (ModelState.IsValid)
            {
                _context.Add(places);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(places);
        }

        // GET: Suggestion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var places = await _context.Places.FindAsync(id);
            if (places == null)
            {
                return NotFound();
            }
            return View(places);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cordinates,Stars")] Places places)
        {
            if (id != places.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(places);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacesExists(places.Id))
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
            return View(places);
        }

        // GET: Suggestion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var places = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var places = await _context.Places.FindAsync(id);
            if (places != null)
            {
                _context.Places.Remove(places);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacesExists(int id)
        {
            return _context.Places.Any(e => e.Id == id);
        }
    }
}
