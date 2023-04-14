using System.ComponentModel.DataAnnotations;

namespace DiplomApplication.Models
{
    public class Users
    {
       // public int Id { get; set; }
        [Required(ErrorMessage = "Логин не может быть пустым")]
        [Display(Name = "Логин:")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Display(Name = "Пароль:")]
        public string Password { get; set; }
     //  public string FIO { get; set; }
     //  public string Role { get; set; }

    }
}
