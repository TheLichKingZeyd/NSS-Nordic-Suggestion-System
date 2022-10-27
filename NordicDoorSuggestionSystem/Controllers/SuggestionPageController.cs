using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoorSuggestionSystem.Controllers
{
    public class SuggestionPageController : Controller
    {

        public IActionResult Index()
        {
            return View("SuggestionOne");
        }

        public IActionResult SuggestionOne()
        {
            return View();
        }

        public IActionResult SuggestionTwo()
        {
            return View();
        }

        public IActionResult SuggestionThree()
        {
            return View();
        }

        public IActionResult SuggestionFour()
        {
            return View();
        }

        public IActionResult SuggestionFive()
        {
            return View();
        }
    }
}

