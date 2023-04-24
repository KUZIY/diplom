using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Data
{
    public class MessagesDB
    {
        [Required]
        public int Id { get; set; }
        public string StringToSort { get; set; }
        public string SortedByStudent { get; set; }
        public string SortedProgram { get; set; }
        public string Message { get; set; }
    }
}
