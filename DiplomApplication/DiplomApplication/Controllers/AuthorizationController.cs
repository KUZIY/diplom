using DiplomApp.Data;
using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;


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
			if (HttpContext.Request.Cookies.ContainsKey("Id"))
			{
				HttpContext.Response.Cookies.Delete("Id");
			}
			return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckAuthorization(Users user)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Id"))
            {
                HttpContext.Response.Cookies.Delete("Id");
            }
            Validation val = new Validation(DBContext);
            ModelState.Clear();
            foreach (var x in val.CheckAuthorization(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("Id", Convert.ToString(val.GetId(user.Login)));
                //	Response.Cookies["Id"].Expires = DateTime.Now.AddDays(1);
                if (val.CheckRole(user.Login))
                    return Redirect("/Home/Test");
                else
                    return Redirect("/Admin/Home");
            }
            else
            {
                ViewData["Login"] = user.Login;
                return View("Authorization");
            }
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
