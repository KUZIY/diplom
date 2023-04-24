using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Data
{
    public class RatingsDB
    {
        [Required]
        public int Id { get; set; }
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
