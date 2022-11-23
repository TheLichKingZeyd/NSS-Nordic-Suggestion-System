using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Statistic()
        {
            return View();
        }
    }


/*
    [HttpGet]
    public async Task<IActionResult> UploadProfilePicture(byte[] picture)
    {
        var user = await _userManager.FindByIdAsync(id);
        var currentUser = _userManager.GetUserAsync(HttpContext.User);
        user.EmployeeNumber ;
    }
*/
   /* public async Task<IActionResult> Edit(int? id)
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

        var editSuggestionViewModel = new EditSuggestionViewModel
        {
            Title = suggestion.Title,
            ResponsibleEmployee = suggestion.ResponsibleEmployee,
            Problem = suggestion.Problem,
            Solution = suggestion.Solution,
            Goal = suggestion.Goal,
            Deadline = suggestion.Deadline,
            TeamID = suggestion.TeamID.Value
        };

        return View(editSuggestionViewModel);
    }*/




}

