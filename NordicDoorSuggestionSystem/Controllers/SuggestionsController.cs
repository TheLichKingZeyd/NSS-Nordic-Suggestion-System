using NordicDoorSuggestionSystem.Models.Suggestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NordicDoorSuggestionSystem.Controllers
{
   // [Authorize(Roles = "Administrator")]
    public class SuggestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Dette gikk dårlig");
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException();
            return null;
        }
    }
}
