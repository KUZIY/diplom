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
				ViewData["Theory"] = "Сортировка пузырьком является одним из самых простых методов сортировки. Алгоритм считается учебным и практически не применяется вне учебной литературы, вместо него на практике применяются более эффективные алгоритмы сортировки. В то же время метод сортировки обменами лежит в основе некоторых более совершенных алгоритмов. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. ";
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
				ViewData["Theory"] = "Сортировка выбором также является простым методом сортировки. Он находит минимальный элемент в массиве и меняет его местами с первым элементом в массиве. Затем он находит следующий минимальный элемент и меняет его местами со вторым элементом в массиве. Этот процесс повторяется до тех пор, пока все элементы не будут отсортированы.";
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
				ViewData["Theory"] = "Сортировка вставками является простым и эффективным методом сортировки, особенно для небольших массивов. Он проходит по массиву по одному элементу и вставляет его в отсортированную часть массива, находя для него правильную позицию. Это повторяется до тех пор, пока все элементы не будут отсортированы.";
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
				string str = "Шейкерная сортировка.";
				if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
				{
					HttpContext.Response.Cookies.Delete("TypeWork");
				}
				HttpContext.Response.Cookies.Append("TypeSort", str);
				ViewData["Title"] = str;
				ViewData["Theory"] = "Шейкерная сортировка является вариантом сортировки пузырьком, который двигается в обоих направлениях по массиву, сравнивая и меняя элементы, как в сортировке пузырьком. Однако, в отличие от сортировки пузырьком, шейкерная сортировка двигается не только в одном направлении, но и в обратном направлении. Это позволяет \"выталкивать\" большие элементы в конец массива, а маленькие - в начало. Это может ускорить процесс сортировки, особенно когда есть много элементов, которые нужно перемещать.";
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
				ViewData["Theory"] = "Сортировка Шелла является улучшенной версией сортировки вставками. Он сначала разбивает массив на несколько подмассивов, сортирует каждый из них отдельно, а затем объединяет их вместе. Этот метод использует несколько последовательностей смещения, чтобы ускорить сортировку вставками. Хотя сортировка Шелла не является самой быстрой сортировкой, она имеет лучшую производительность, чем сортировка пузырьком, сортировка выбором или сортировка вставками.";
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
				ViewData["Theory"] = "Быстрая сортировка является одним из самых популярных и эффективных методов сортировки. Он выбирает опорный элемент в массиве и разбивает массив на две части, одна содержит элементы, которые меньше опорного элемента, а другая - элементы, которые больше опорного элемента. Затем он рекурсивно повторяет этот процесс для каждой из частей массива до тех пор, пока массив не будет отсортирован полностью. Быстрая сортировка имеет лучшую среднюю производительность, чем сортировка пузырьком, сортировка вставками или сортировка выбором.";
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
			int[] ints = element.Select(int.Parse).ToArray();												
			string strprogramsort = Sort.SortPoAlg(ints, HttpContext.Request.Cookies["TypeSort"]);           
			Validation val = new Validation(DBContext);
			var userId = HttpContext.Request.Cookies["Id"];													
			ViewData["inf"] = "Result";																		
			ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];									
			ViewData["strtosort"] = form.strtosort;															
			ViewData["strstudentsort"] = form.strstudentsort;												
			ViewData["Mess"] = val.CheckWork(Convert.ToInt32(userId), form.strstudentsort, strprogramsort, HttpContext.Request.Cookies["TypeWork"], HttpContext.Request.Cookies["TypeSort"]); 
			ViewData["strprogramsort"] = strprogramsort;													
			return View("Test");																			
																											
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
