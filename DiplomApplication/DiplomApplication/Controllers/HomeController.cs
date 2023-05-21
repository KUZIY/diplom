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

        public IActionResult Test()
        {
			if (HttpContext.Request.Cookies.ContainsKey("TypeSort"))
			{
				HttpContext.Response.Cookies.Delete("TypeSort");
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
			}
			Validation val = new Validation(DBContext);
            var userId = HttpContext.Request.Cookies["Id"];
            if ((userId == null) || !(val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
                return Redirect("/Authorization/Authorization");
            else
            {
                return View(val.GetStudentMarks(Convert.ToInt32(userId)));
            }
        }
        public IActionResult ChangePass()
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (!val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
				return Redirect("/Authorization/Authorization");
			else
				return View();
        }

        public IActionResult Acount()
        {
            Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (!val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
                return Redirect("/Authorization/Authorization");
            else
            {
                ViewData["Login"] = val.GetLogin(Convert.ToInt32(userId));
                ViewData["FIO"] = val.GetFIO(Convert.ToInt32(userId));
                ViewData["Group"] = val.GetGroup(Convert.ToInt32(userId));
                return View();
            }
        }
        public IActionResult ChekAcount(Users user)
        {
            Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (!val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
				return Redirect("/Authorization/Authorization");
			var id = Convert.ToInt32(userId);
            ModelState.Clear();
            foreach (var x in val.CheckAcount(user,id ))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                val.ChangeUser(user,Convert.ToInt32(HttpContext.Request.Cookies["Id"]));
                ViewData["Mess"] = "Внесение изменений успешно";
            }
                ViewData["Login"] = user.Login;
                ViewData["FIO"] = user.FIO;
                ViewData["Group"] = user.Group;        
            return View("Acount");
        }

        public IActionResult Checkpass(Users user)
        {
            Validation val = new Validation(DBContext);
            var userId = HttpContext.Request.Cookies["Id"];
            if ((userId == null) || !(val.CheckRole(user.Login)))
                return Redirect("/Authorization/Authorization");
            user.Login = val.GetLogin(Convert.ToInt32(userId));
            ModelState.Clear();
            foreach (var x in val.CheckChangePass(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                ViewData["Mess"] = "Пароль успешно изменён.";
                val.ChangePass(user.Login, user.Password);
            }
            return View("ChangePass");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}