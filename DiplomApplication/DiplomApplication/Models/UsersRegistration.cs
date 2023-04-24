using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DiplomApplication.Models
{
    public class UsersRegistration
    {

       // public int Id { get; set; }
        [Required(ErrorMessage = "Логин не может быть пустым")]
        [Display(Name = "Введите новый логин:")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Display(Name = "Введите новый пароль:")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Display(Name = "Повторите пароль:")]
        public string Password2 { get; set; }

        [Required(ErrorMessage = "Группа не может быть пустой")]
        [Display(Name = "Введите свою группу:")]
        public string Group { get; set; }

        [Required(ErrorMessage = "Поле ФИО не может быть пустым")]
        [Display(Name = "Введите ФИО:")]
        public string FIO { get; set; }

        //  public string FIO { get; set; }
        //  public string Role { get; set; }

    }
}

