using DiplomApp.Data;
using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using XAct;
using XAct.Users;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomApplication.Controllers
{
	public class SortController : Controller
	{
		private readonly DiplomDataContext DBContext;

		public SortController(DiplomDataContext dBContext)
		{
			DBContext = dBContext;
		}
		public IActionResult Bubble()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{
				string str = "Сортировка пузырьком.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");
		}



		public IActionResult Selection()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{
				string str = "Сортировка выбором.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");

		}

		public IActionResult Insertion()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{
				string str = "Сортировка вставками.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");
		}

		public IActionResult Shaker()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{
				string str = "Шейкерная сортирока.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");
		}

		public IActionResult Shell()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{

				string str = "Сортировка Шелла.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");
		}


		public IActionResult Quick()
		{
			var userId = HttpContext.Request.Cookies["Id"];
			Validation val = new Validation(DBContext);
			if ((userId != null) || (val.CheckRole(val.GetLogin(Convert.ToInt32(userId)))))
			{
				string str = "Быстрая сортировка.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
				ViewData["Control"] = val.CheckControl(Convert.ToInt32(userId), str);
				return View("Theory");
			}
			else
				return Redirect("/Authorization/Authorization");
		}
        public IActionResult CheckAlg()
        {
            HttpContext.Response.Cookies.Append("TypeWork", "CheckAlg");
            ViewData["inf"] = "CheckAlg";
            ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
            return View("Test");
        }

        public IActionResult TrainingTest()
        {
            HttpContext.Response.Cookies.Append("TypeWork", "TrainingTest");
            ViewData["inf"] = "TrainingTest";
            ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
            ViewData["Strtosort"] = Sort.GetStrToSort();//генерация строки
			ViewData["strstudentsort"] = "";

			return View("Test");
        }
        public IActionResult ControlTest()
        {
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];
			val.AddAtemp(Convert.ToInt32(userId));
            HttpContext.Response.Cookies.Append("TypeWork", "ControlTest");
            ViewData["inf"] = "ControlTest";
            ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
			ViewData["Strtosort"] = Sort.GetStrToSort();//генерация строки
			ViewData["strstudentsort"] = "";

			return View("Test");
        }
        public IActionResult Warning()
        {
            ViewData["inf"] = HttpContext.Request.Cookies["TypeSort"];
            return View();
        }
		public IActionResult GenerateStr (StrtoSort form)
        {
			
			ViewData["inf"] = "CheckAlg";
			ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
			ViewData["strtosort"] = Sort.GetStrToSort();//генерация строки
			return View("Test");

		}
		public IActionResult CheckWork(StrtoSort form)
		{
			//Нужна проверочка на то что ввевли
			string[] element = form.strtosort.Split(new char[] { ' ' });
			int[] ints = element.Select(int.Parse).ToArray();													  //Проврека на ввод 
			string strprogramsort = Sort.SortPoAlg(ints, HttpContext.Request.Cookies["TypeSort"]);				  //Генерация сообщений
																												  //проверка правильности работы студента
			ViewData["inf"] = "Result";																			  //Выставленеие оценок
			ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];										  //
			ViewData["strtosort"] = form.strtosort;																  //
			ViewData["strstudentsort"] = form.strstudentsort;													  //
			ViewData["Mess"] = "pfukeirf yt ghblevfk"; // генерация сообщения									  //
			ViewData["strprogramsort"] = strprogramsort;														  //
			return View("Test");																				  //
																												  //
		}
		public IActionResult GetAnsTrainingTest (StrtoSort form)
        {
			//Нужна проверочка на то что ввевли
				string[] element = form.strtosort.Split(new char[] { ' ' });
				int[] ints = element.Select(int.Parse).ToArray();
				ViewData["strprogramsort"] = Sort.SortPoAlg(ints, HttpContext.Request.Cookies["TypeSort"]);
			ViewData["strtosort"] = form.strtosort;
				
			ViewData["inf"] = "CheckAlg";
				ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
			return View("Test");
		}
		public IActionResult Home()
		{
			return Redirect("/Home/Test");
		}
	}
} 
