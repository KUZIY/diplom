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

		public IActionResult Admin()
        {
            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }

        public IActionResult AddTeacher()
        {
            return View();
        }
        public IActionResult CheckAddTeacher(Users user)
        {
            Validation val = new Validation(DBContext);
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

    }
}
