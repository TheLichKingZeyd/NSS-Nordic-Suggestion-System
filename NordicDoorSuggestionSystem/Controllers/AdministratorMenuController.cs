using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
