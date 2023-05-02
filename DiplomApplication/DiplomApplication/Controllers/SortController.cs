using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using XAct;
using XAct.Users;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomApplication.Controllers
{
    public class SortController : Controller
    {
        public IActionResult Bubble()
        {
            string str = "Сортировка пузырьком.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }



        public IActionResult Selection()
        {
            string str = "Сортировка выбором.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }

        public IActionResult Insertion()
        {
            string str = "Сортировка вставками.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }

        public IActionResult Shaker()
        {
            string str = "Шейкерная сортирока.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }

        public IActionResult Shell()
        {
            string str = "Сортировка Шелла.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }

        public IActionResult Quick()
        {
            string str = "Быстрая сортировка.";
            if (HttpContext.Request.Cookies.ContainsKey("TypeWork"))
            {
                HttpContext.Response.Cookies.Delete("TypeWork");
            }
            HttpContext.Response.Cookies.Append("TypeSort", str);
            ViewData["Title"] = str;
            ViewData["Theory"] = "Cортировка пузырьком является одним из самых простых методов сортировки. Он проходит по массиву многократно, сравнивая пары соседних элементов и меняя их местами, если они находятся в неправильном порядке. Этот процесс повторяется до тех пор, пока массив не будет отсортирован. Ключевой недостаток этого метода заключается в том, что он имеет квадратичную сложность O(n^2)";
            return View("Theory");
        }
        //public IActionResult Theory()
        //{
        //	ViewData["Message"] = "Здесь будет строка после сортировки";
        //	return View();
        //}
        //public IActionResult Test()
        //{
        //	ViewData["Message"] = "Здесь будет строка после сортировки";
        //	return View();
        //}

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
            ViewData["Strtosort"] = "123 432 123";//генерация строки
			ViewData["strstudentsort"] = "";

			return View("Test");
        }
        public IActionResult ControlTest()
        {
            HttpContext.Response.Cookies.Append("TypeWork", "ControlTest");
            ViewData["inf"] = "ControlTest";
            ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
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
			ViewData["strtosort"] = "123 432 123";//генерация строки
            return View("Test");

		}
		public IActionResult GetAnsTrainingTest (StrtoSort form)
        {
			//Нужна проверочка на то что ввевли
				string[] element = form.strtosort.Split(new char[] { ' ' });
				int[] ints = element.Select(int.Parse).ToArray();
				ViewData["strprogramsort"] = Sort.BubbleSort(ints);// из куки достать алгоритм
			ViewData["strtosort"] = form.strtosort;
				
			ViewData["inf"] = "CheckAlg";
				ViewData["Title"] = HttpContext.Request.Cookies["TypeSort"];
			return View("Test");
		}
		public IActionResult Home()
		{
			return Redirect("/Home/Test");
		}

		//[HttpPost]
		//public IActionResult CheckBibble(StrtoSort st)
		//{
		//	
		//	if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//		int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//		return View("Bubble");
		//	}
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}

		//[HttpPost]
		//public IActionResult CheckSelection(StrtoSort st)
		//{
		//
		//    if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//        int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//        return View("Bubble");
		//    }
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}
		//
		//[HttpPost]
		//public IActionResult CheckInsertion(StrtoSort st)
		//{
		//
		//    if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//        int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//        return View("Bubble");
		//    }
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}
		//
		//[HttpPost]
		//public IActionResult CheckShaker(StrtoSort st)
		//{
		//
		//    if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//        int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//        return View("Bubble");
		//    }
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}
		//
		//[HttpPost]
		//public IActionResult CheckShell(StrtoSort st)
		//{
		//
		//    if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//        int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//        return View("Bubble");
		//    }
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}
		//
		//[HttpPost]
		//public IActionResult CheckQuick(StrtoSort st)
		//{
		//
		//    if (ModelState.IsValid)
		//    {
		//        string[] element = st.str.Split(new char[] { ' ' });
		//        int[] ints = element.Select(int.Parse).ToArray();
		//        ViewData["Message"] = Sort.BubbleSort(ints);
		//        return View("Bubble");
		//    }
		//    else
		//    {
		//        return View("Bubble");
		//    }
		//}


	}
} 
