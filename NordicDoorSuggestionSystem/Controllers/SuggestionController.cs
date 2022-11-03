using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly DataContext _context;

        public SuggestionController(DataContext context)
        {
            _context = context;
        }

        // GET: Suggestion
        public async Task<IActionResult> Index(string searchString)
        {
            var suggestions = from m in _context.Suggestion
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                suggestions = suggestions.Where(s => s.Title!.Contains(searchString));
            }
              return View(await suggestions.ToListAsync());
        } 

        // GET: Suggestion/Details/5
        public async Task<IActionResult> Details(int? SgstnID)
        {
            if (SgstnID == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestionEntity = await _context.Suggestion
                .FirstOrDefaultAsync(m => m.SgstnID == SgstnID);
            if (suggestionEntity == null)
            {
                return NotFound();
            }

            return View(suggestionEntity);
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
        public async Task<IActionResult> Create([Bind("SgstnID,Title,ProbDescr, Solution, Goal ,ResponsibleEmployeeNumber, Deadline,TeamID")] SuggestionEntity suggestionEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suggestionEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestionEntity);
        }

        // GET: Suggestion/Edit/5
        public async Task<IActionResult> Edit(int? SgstnID)
        {
            if (SgstnID == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestionEntity = await _context.Suggestion.FindAsync(SgstnID);
            if (suggestionEntity == null)
            {
                return NotFound();
            }
            return View(suggestionEntity);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int SgstnID, [Bind("SgstnID,Title,ProbDescr, Solution, Goal ,ResponsibleEmployeeNumber, Deadline,TeamID")] SuggestionEntity suggestionEntity)
        {
            if (SgstnID != suggestionEntity.SgstnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suggestionEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuggestionEntityExists(suggestionEntity.SgstnID))
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
            return View(suggestionEntity);
        }

        // GET: Suggestion/Delete/5
        public async Task<IActionResult> Delete(int? SgstnID)
        {
            if (SgstnID == null || _context.Suggestion == null)
            {
                return NotFound();
            }

            var suggestionEntity = await _context.Suggestion
                .FirstOrDefaultAsync(m => m.SgstnID == SgstnID);
            if (suggestionEntity == null)
            {
                return NotFound();
            }

            return View(suggestionEntity);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int SgstnID)
        {
            if (_context.Suggestion == null)
            {
                return Problem("Entity set 'DataContext.Suggestion'  is null.");
            }
            var suggestionEntity = await _context.Suggestion.FindAsync(SgstnID);
            if (suggestionEntity != null)
            {
                _context.Suggestion.Remove(suggestionEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionEntityExists(int SgstnID)
        {
          return _context.Suggestion.Any(e => e.SgstnID == SgstnID);
        }
    }
}
