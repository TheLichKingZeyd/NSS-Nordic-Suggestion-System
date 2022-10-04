using Microsoft.AspNetCore.Mvc;

namespace NSS.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index ()
        { 
            return view ();
        }
    }
}