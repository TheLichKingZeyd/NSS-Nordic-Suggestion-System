using NordicDoorSuggestionSystem.DataAccess;
using NordicDoorSuggestionSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NordicDoorSuggestionSystem.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles ="Administrator,Team Leder,Standard Bruker")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }


    }
}