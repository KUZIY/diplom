using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace DiplomApplication.Models
{
    public class StrtoSort
    {
        [Required(ErrorMessage = "Заполните строку для сортировки")]
        [Display(Name = "Строка для сортироовки:")]
        public string strtosort { get; set; }
		public string strstudentsort { get; set; }
		public string Mess{ get; set; }
		public string strprogramsort { get; set; }

	}
}
