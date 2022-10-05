using Microsoft.AspNetCore.Mvc;
using NordicDoorSuggestionSystem.Models;
using System.Diagnostics;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult User()
        {
            return View();
        }
    }
}
