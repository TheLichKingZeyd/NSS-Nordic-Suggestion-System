using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Entities;
using NordicDoorSuggestionSystem.Models;
using Microsoft.AspNetCore.Identity;
using NordicDoorSuggestionSystem.Repositories;

namespace NordicDoorSuggestionSystem.Controllers
{
    //[Authorize]
    public class SuggestionController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ISuggestionRepository _suggestionRepository;

        public SuggestionController(UserManager<IdentityUser> userManager, ISuggestionRepository suggestionRepository)
        {
            _userManager = userManager;
            _suggestionRepository = suggestionRepository;
        }

        // GET: Suggestion
        public async Task<IActionResult> Index(string searchString)
        {
            var suggestions = new List<Suggestion>();    
            if (!String.IsNullOrEmpty(searchString))
            {
                suggestions = await _suggestionRepository.QuerySuggestions(searchString);
            }else{
                suggestions = await _suggestionRepository.GetSuggestions();
            }
              return View(suggestions);
        } 

        // GET: Suggestion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }
            
            var suggestionEntity = await _suggestionRepository.GetSuggestion(id);
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
        public async Task<IActionResult> Create([Bind("Title,ResponsibleEmployee, Problem, Solution, Goal, Deadline, Progress, EmployeeNumber, TeamID")] SuggestionViewModel suggestionViewModel)
        {
            if (ModelState.IsValid)
            {
               // var user = await _userManager.GetUserAsync(HttpContext.User);

                var newSuggestion = new Suggestion {
                    Title = suggestionViewModel.Title,
                    ResponsibleEmployee = suggestionViewModel.ResponsibleEmployee,
                    Problem = suggestionViewModel.Problem,
                    Solution = suggestionViewModel.Solution,
                    Goal = suggestionViewModel.Goal,
                    Deadline = suggestionViewModel.Deadline,
                    Progress = suggestionViewModel.Progress,
                    // EmployeeNumber = user.Id,
                    EmployeeNumber = suggestionViewModel.EmployeeNumber,
                    TeamID = suggestionViewModel.TeamID
                };
                
                await _suggestionRepository.Add(newSuggestion);
                await _suggestionRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestionViewModel);
        }

        // GET: Suggestion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            var editSuggestionViewModel = new EditSuggestionViewModel {
                Title= suggestion.Title,
                ResponsibleEmployee= suggestion.ResponsibleEmployee,
                Problem= suggestion.Problem,
                Solution= suggestion.Solution,
                Goal= suggestion.Goal,
                Deadline= suggestion.Deadline,
                TeamID= suggestion.TeamID
            };

            return View(editSuggestionViewModel);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ResponsibleEmployeeNumber, Problem, Solution, Goal, Deadline, TeamID")] EditSuggestionViewModel editSuggestionViewModel)
        {
            var suggestion = await _suggestionRepository.GetSuggestion(id);
            if ( suggestion == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    suggestion.Title = editSuggestionViewModel.Title;
                    suggestion.ResponsibleEmployee = editSuggestionViewModel.ResponsibleEmployee;
                    suggestion.Problem = editSuggestionViewModel.Problem;
                    suggestion.Solution = editSuggestionViewModel.Solution;
                    suggestion.Goal = editSuggestionViewModel.Goal;
                    suggestion.Deadline = editSuggestionViewModel.Deadline;
                    suggestion.TeamID = editSuggestionViewModel.TeamID;
                    
                    await _suggestionRepository.Update(suggestion);
                    await _suggestionRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(suggestion);
        }

        // GET: Suggestion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _suggestionRepository.GetSuggestions() == null)
            {
                return NotFound();
            }

            var suggestionEntity = await _suggestionRepository.GetSuggestion(id);
            if (suggestionEntity == null)
            {
                return NotFound();
            }

            return View(suggestionEntity);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _suggestionRepository.GetSuggestions() == null)
            {
                return Problem("Entity set 'DataContext.Suggestion'  is null.");
            }
            var suggestionEntity = await _suggestionRepository.GetSuggestion(id);
            if (suggestionEntity != null)
            {
                await _suggestionRepository.Delete(suggestionEntity);
                await _suggestionRepository.SaveChanges();

            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionEntityExists(int id)
        {
          var suggestion = _suggestionRepository.GetSuggestion(id);
          
          if(suggestion == null) return false;
          return true;
        }
    }
}
