using Microsoft.AspNetCore.Mvc;

namespace DiplomApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
