using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class AdministratorHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
