using System.ComponentModel.DataAnnotations;

namespace DiplomApplication.Models
{
    public class Students
    {
		public int IdUser { get; set; }
		public string? FIO { get; set; }
		public string? Group { get; set; }
		public bool BubleMark { get; set; }
		public bool SelectionMark { get; set; }
		public bool InsertionMark { get; set; }
		public bool ShakerMark { get; set; }
		public bool ShellMark { get; set; }
		public bool QuickMark { get; set; }
		public int TotalAttempts { get; set; }
		public int Rating { get; set; }
	}
}
