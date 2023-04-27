using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Data
{
    public class RatingsDB
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public bool BubleMark { get; set; }
        [Required]
        public bool SelectionMark { get; set; }
        [Required]
        public bool InsertionMark { get; set; }
        [Required]
        public bool ShakerMark { get; set; }
        [Required]
        public bool ShellMark { get; set; }
        [Required]
        public bool QuickMark { get; set; }
        [Required]
        public int TotalAttempts { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int IdUser { get; set; }
        [ForeignKey(nameof(IdUser))]
        public UsersDB User { get; set; }
    }
}
