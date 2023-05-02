using DiplomApp.Data;
using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly DiplomDataContext DBContext;

		public AdminController(DiplomDataContext dBContext)
		{
			DBContext = dBContext;
		}

		public IActionResult Home()
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
            if ((userId == null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
                return Redirect("/Authorization/Authorization");
            else
            {
                //var list = new List<Students>();
                //list.Add(val.GetStudent());
				return View(val.GetStudents());
            }

		}

        public IActionResult ChangePass()
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
				return Redirect("/Authorization/Authorization");
			else
				return View();
        }

        public IActionResult AddTeacher()
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
				return Redirect("/Authorization/Authorization");
			else
				return View();
        }
        public IActionResult CheckAddTeacher(Users user)
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			if ((userId == null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
				return Redirect("/Authorization/Authorization");
            ModelState.Clear();
            foreach (var x in val.CheckTeacherRegistration(user))
                ModelState.AddModelError(x.Item1, x.Item2);
            if (ModelState.IsValid)
            {
                ViewData["Mess"] = "Пользователь с логином " + user.Login + " успешно добавлен.";
                val.CreateUser(user, "Teacher");
            }
            else
            {
                ViewData["Login"] = user.Login;
            }
            return View("AddTeacher");
        }

        public IActionResult Checkpass(Users user)
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
            user.Login = val.GetLogin(Convert.ToInt32(userId));
			if ((userId == null) || (val.CheckRole(user.Login)))
				return Redirect("/Authorization/Authorization");
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
        public IActionResult Exit()
        { 
            return Redirect("/Authorization/Authorization");  
        }
	}
}
