using DiplomApplication.Logic;
using DiplomApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomApplication.Controllers
{
    public class SortController : Controller
    {
        public IActionResult Bubble()
        {ViewData["Message"] = "Здесь будет строка после сортировки";
			return View();
        }
        [HttpPost]
        public IActionResult CheckBibble(StrtoSort st)
        {
			
			if (ModelState.IsValid)
            {
                string[] element = st.str.Split(new char[] { ' ' });
				int[] ints = element.Select(int.Parse).ToArray();
                ViewData["Message"] = Sort.BubbleSort(ints);
				return View("Bubble");
			}
            else
            {
                return View("Bubble");
            }
        }
    }
}
