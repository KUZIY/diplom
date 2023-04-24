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
        public IActionResult CheckAuthorization(UsersAuthorization user)
        {
            if (ModelState.IsValid)
            {
                if (user.Login == "admin")
                    return Redirect("/Admin/Admin");
                else
                    return Redirect("/Home/Home");
            }
            else
            {
                return View("Authorization");
            }

        }

        [HttpPost]
        public IActionResult CheckRegistration(UsersRegistration user)
        {
            if (ModelState.IsValid)
            {
                if (user.Login == "admin")
                    return Redirect("/Admin/Admin");
                else
                    return Redirect("/Home/Home");
            }
            else
            {
                return View("Registration");
            }

        }
    }
}
