using DiplomApp.Data;
using DiplomApplication.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using XAct;
using XAct.Users;

namespace DiplomApplication.Logic
{
    public class Validation
    {
        private readonly DiplomDataContext DBContext;
        public Validation(DiplomDataContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public bool CheckLogin(string login)
        {
            bool Ans = false;
            var x = DBContext.UsersDB.Where(x => x.Login == login);
            if (x.Count() > 0)
            {
                Ans = true;
            }
            return Ans;
        }

        public bool CheckPassword(string log, string pass)
        {
            bool Ans = false;
            pass = PasswordHash.GetHashCode(pass);
            var x = DBContext.UsersDB.Where(x => x.Password == pass && x.Login == log);
            if (x.Count() > 0)
            {
                Ans = true;
            }
            return Ans;
        }
        public bool CheckRole(string log)
        {
            bool Ans = false;
            var x = DBContext.UsersDB.Where(x => x.Role == "Student" && x.Login == log);
            if (x.Count() > 0)
            {
                Ans = true;
            }
            return Ans;
        }

        /*public bool CheckFIO(string login)
        {
            bool Ans = false;
            var x = DBContext.UsersDB.Where(x => x.Login == login);
            DBContext.UsersDB.
            if (x.Count() > 0)
            {
                Ans = true;
            }
            return Ans;
        }*/

        public bool CheckGroup(string login)
        {
            bool Ans = false;
            var x = DBContext.UsersDB.Where(x => x.Login == login);
            if (x.Count() > 0)
            {
                Ans = true;
            }
            return Ans;
        }

        public int GetId(string log)
        {
            //UsersDB x = DBContext.UsersDB.Where(x => x.Login == "admin").FirstOrDefault();
            var x = DBContext.UsersDB.First(x => x.Login == log);//
            return x.IdUser;
        }

		public string GetLogin(int Id)
        {
			var x = DBContext.UsersDB.First(x => x.IdUser == Id);//
            return x.Login;
        }

		public bool ChangePass(string log, string pass)
        {
            bool Ans = false;
            //UsersDB x = DBContext.UsersDB.Where(x => x.Login == "admin").FirstOrDefault();
            var x = DBContext.UsersDB.First(x => x.Login == log);//
            x.Password = PasswordHash.GetHashCode(pass); ;

            DBContext.SaveChanges();
            return Ans;
        }
        public bool CreateUser(Users user, string role)
        {
            bool Ans = true;
            try
            {
                user.Password = PasswordHash.GetHashCode(user.Password);
                var userforDB = new UsersDB() { Login = user.Login, Password = user.Password, FIO = user.FIO, Group = user.Group, Role = role };
                DBContext.UsersDB.Add(userforDB);
                if (role == "Student")
                {
                    var ratingforDB = new RatingsDB() { BubleMark = false, SelectionMark = false, InsertionMark = false, ShakerMark = false, ShellMark = false, QuickMark = false, TotalAttempts = 0, Rating = 0, User = userforDB };
                    DBContext.RatingsDB.Add(ratingforDB);
                }
                DBContext.SaveChanges();
            }
            catch (Exception ex) { Ans = false; }
            return Ans;
        }

        public List<(string, string)> CheckRegistration(Users user)
        {
            List<(string, string)> ans = new List<(string, string)>();

            if (CheckLogin(user.Login))
            {
                ans.Add(("Login", "Такой логин уже занят"));
            }
            if (user.Login == null)
            {
                ans.Add(("Login", "Логин не может быть пустым"));
            }
            if (user.Password == null)
            {
                ans.Add(("Password", "Пароль не может быть пустым"));
            }
            if (user.Password2 == null)
            {
                ans.Add(("Password2", "Пароль не может быть пустым"));
            }
            if (user.Password2 != user.Password)
            {
                ans.Add(("Password2", "Пароли не совпадают"));
            }
            if (user.FIO == null)
            {
                ans.Add(("FIO", "Поле ФИО не может быть пустым"));
            }
            if (user.Group == null)
            {
                ans.Add(("Group", "Группа не может быть пустой"));
            }
            return ans;
        }

        public List<(string, string)> CheckTeacherRegistration(Users user)
        {
            List<(string, string)> ans = new List<(string, string)>();

            if (CheckLogin(user.Login))
            {
                ans.Add(("Login", "Такой логин уже занят"));
            }
            if (user.Login == null)
            {
                ans.Add(("Login", "Логин не может быть пустым"));
            }
            if (user.Password == null)
            {
                ans.Add(("Password", "Пароль не может быть пустым"));
            }
            if (user.Password2 == null)
            {
                ans.Add(("Password2", "Пароль не может быть пустым"));
            }
            if (user.Password2 != user.Password)
            {
                ans.Add(("Password2", "Пароли не совпадают"));
            }
            return ans;
        }

        public List<(string, string)> CheckAuthorization(Users user)
        {
            List<(string, string)> ans = new List<(string, string)>();
            if (user.Login == null)
                ans.Add(("Login", "Логин не может быть пустым"));
            if (user.Password == null)
                ans.Add(("Password", "Пароль не может быть пустым"));
            if ((user.Login != null) && (user.Password != null))
                if (!CheckPassword(user.Login, user.Password))
                    ans.Add(("Password", "Логин или пароль не правильный."));
            return ans;
        }

        public List<(string, string)>  CheckChangePass(Users user)
        {
            List<(string, string)> ans = new List<(string, string)>();

			if (user.Password == null)
                ans.Add(("Password", "Пароль не может быть пустым"));
            if (user.Password2 == null)
                ans.Add(("Password2", "Пароль не может быть пустым"));
            if (user.OldPassword == null)
                ans.Add(("Password", "Пароль не может быть пустым"));
            else if (CheckPassword(user.Login, user.OldPassword))
				ans.Add(("OldPassword", "Страый пароль не правильный"));
            if (user.Password2 != user.Password)
                ans.Add(("Password2", "Новые пароли не совпадают"));
            if (user.Password == user.OldPassword)
                ans.Add(("Password2", "Новый пароль должен отличаться от старого"));
            return ans;
        }
    }
}
