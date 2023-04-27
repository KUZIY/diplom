using DiplomApp.Data;
using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace DiplomApplication.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly DiplomDataContext DBContext;
        public AuthorizationController(DiplomDataContext DBContext) 
        {
            this.DBContext = DBContext;
        }
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
            Validation val = new Validation(DBContext);
            ModelState.Clear();
            foreach (var x in val.CheckAuthorization(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                if (val.CheckRole(user.Login))
                    return Redirect("/Home/Home");
                else
                    return Redirect("/Admin/Admin");
            }
            else
            {
                ViewData["Login"] = user.Login;
                return View("Authorization");
            }
                //       ModelState.AddModelError(x.Item1, x.Item2);
                //   if (!ModelState.IsValid)
                //   {
                //       return View("Authorization");
                //   }
                //       if (!val.CheckPassword(user.Login, user.Password))
                //   {
                //       ModelState.AddModelError("Password", "Логин или пароль не правильный.");
                //       return View("Authorization");
                //   }
                //       if (user.Login == "admin")
                //           return Redirect("/Admin/Admin");
                //       else
                //           return Redirect("/Home/Home");
            }

        [HttpPost]
        public IActionResult CheckRegistration(Users user)
        {
            Validation val = new Validation(DBContext);
            ModelState.Clear();
            foreach (var x in val.CheckRegistration(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                val.CreateUser(user, "Student");
                return View("Authorization");
            }
            else
            {
                ViewData["Login"] = user.Login;
                ViewData["FIO"] = user.FIO;
                ViewData["Group"] = user.Group;
                return View("Registration");
            }
        }
    }
}
