using Microsoft.AspNetCore.Mvc;

namespace NordicDoorSuggestionSystem.Controllers
{
    public class NavigationPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
