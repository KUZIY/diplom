using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DiplomApplication.Models
{
    public class Users
    {
        [Display(Name = "Введите новый логин:")]
        public string Login { get; set; }

        [Display(Name = "Введите старый пароль:")]
        public string OldPassword { get; set; }

        [Display(Name = "Введите новый пароль:")]
        public string Password { get; set; }

        [Display(Name = "Повторите пароль:")]
        public string Password2 { get; set; }

        [Display(Name = "Введите свою группу:")]
        public string Group { get; set; }

        [Display(Name = "Введите ФИО:")]
        public string FIO { get; set; }
    }
}
