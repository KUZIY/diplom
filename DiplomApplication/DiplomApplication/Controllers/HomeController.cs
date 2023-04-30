using DiplomApp.Data;
using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using XAct.Users;

namespace DiplomApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DiplomDataContext DBContext;

        public HomeController(DiplomDataContext dBContext)
        {
            DBContext = dBContext;
        }
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Home()
        {
            var userId = HttpContext.Request.Cookies["Id"];
            if (userId == null)
                return Redirect("/Authorization/Authorization");
            else
                return View();
        }

        public IActionResult Test()
        {
            return View();
        }
		

		public IActionResult Acount()
		{
			return View();
		}

        public IActionResult ChekAcount(Users user)
        {
            Validation val = new Validation(DBContext);
            ModelState.Clear();
            foreach (var x in val.CheckRegistration(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                val.CreateUser(user, "Student");
                ViewData["Mess"] = "Внесение изменений успешно";
            }
            else
            {
                ViewData["Login"] = user.Login;
                ViewData["FIO"] = user.FIO;
                ViewData["Group"] = user.Group;
            }
            return View("Acount");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}