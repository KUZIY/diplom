using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomApplication.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckAuthorization(Users user)
        {
            if (ModelState.IsValid)
            {
                if (user.Login == "admin")
                    return Redirect("/Home/Admin");
                else
                    return Redirect("/Home/Home");
            }
            else
            {
                return View("Authorization");
            }

        }
    }
}
