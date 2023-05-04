using DiplomApp.Data;
using DiplomApplication.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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
        public bool CheckLoginId(string login, int id)
        {
            bool Ans = false;
            var x = DBContext.UsersDB.Where(x => x.IdUser == id && x.Login == login);//
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
		public void AddAtemp(int Id)
		{
			var x = DBContext.RatingsDB.First(x => x.IdUser == Id);//
            x.TotalAttempts++;
			DBContext.SaveChanges();
			return;
		}
        public bool? CheckControl(int Id, string typesort)
        {
            bool? ans = null;
            var x = DBContext.RatingsDB.First(x => x.IdUser == Id);//
            x.TotalAttempts++;
            switch (typesort)
            {
                case "Сортировка пузырьком.":
                    ans = x.BubleMark;
                    break;
                case "Сортировка выбором.":
                    ans = x.SelectionMark;
                    break;
                case "Сортировка вставками.":
                    ans = x.InsertionMark;
                    break;
                case "Шейкерная сортирока.":
                    ans = x.ShakerMark;
                        break;
                case "Сортировка Шелла.":
                    ans = x.ShellMark;
                    break;
                case "Быстрая сортировка.": 
                    ans = x.QuickMark;
                    break;
            }
            if (ans == false) ans = null;
            return ans;
        }
		public string GetLogin(int Id)
        {
            var x = DBContext.UsersDB.First(x => x.IdUser == Id);//
            return x.Login;
        }
        public string GetGroup(int Id)
        {
            var x = DBContext.UsersDB.First(x => x.IdUser == Id);//
            return x.Group;
        }
        public string GetFIO(int Id)
        {
            var x = DBContext.UsersDB.First(x => x.IdUser == Id);//
            return x.FIO;
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
        public List<(string, string)> CheckAcount(Users user, int id)
        {
            List<(string, string)> ans = new List<(string, string)>();
            if (!CheckLoginId(user.Login, id))
                if (CheckLogin(user.Login))
                {
                    ans.Add(("Login", "Такой логин уже занят"));
                }
            if (user.Login == null)
            {
                ans.Add(("Login", "Логин не может быть пустым"));
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
            if (user.FIO == null)
            {
                ans.Add(("FIO", "Поле ФИО не может быть пустым"));
            }
            if (user.Group == null)
            {
                ans.Add(("Group", "Группа не может быть пустой"));
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

        public List<(string, string)> CheckChangePass(Users user)
        {
            List<(string, string)> ans = new List<(string, string)>();

            if (user.Password == null)
                ans.Add(("Password", "Пароль не может быть пустым"));
            if (user.Password2 == null)
                ans.Add(("Password2", "Пароль не может быть пустым"));
            if (user.OldPassword == null)
                ans.Add(("Password", "Пароль не может быть пустым"));
            else if (!CheckPassword(user.Login, user.OldPassword))
                ans.Add(("OldPassword", "Страый пароль не правильный"));
            if (user.Password2 != user.Password)
                ans.Add(("Password2", "Новые пароли не совпадают"));
            if (user.Password == user.OldPassword)
                ans.Add(("Password2", "Новый пароль должен отличаться от старого"));
            return ans;
        }
        public Students GetStudentMarks(int id)
        {
            var x = DBContext.RatingsDB.First(x => x.IdUser == id);//
            Students student = new Students()
            {
                IdUser = x.IdUser,
                BubleMark = x.BubleMark,
                SelectionMark = x.SelectionMark,
                InsertionMark = x.InsertionMark,
                ShakerMark = x.ShakerMark,
                ShellMark = x.ShellMark,
                QuickMark = x.QuickMark,
                TotalAttempts = x.TotalAttempts,
                Rating = x.Rating,
            }; ;
            return student;
        }
        public List<Students> GetStudents()
        {
            var ans = new List<Students>();
            //foreach (var x in DBContext.UsersDB)
            //{
            //    if (x.Role == "Student")
            //    {
            //        var a = new Students() { IdUser = x.IdUser, FIO = x.FIO, Group = x.Group };
            //        ans.Add(a);
            //    }
            //
            //}
			//var h = DBContext.UsersDB.First(x => x.IdUser == Id);//
			foreach (var x in DBContext.RatingsDB)
			{
				//var h = DBContext.UsersDB.First(h => h.IdUser == x.IdUser);//
				var a = new Students()
                {
                    IdUser = x.IdUser,
                    BubleMark = x.BubleMark,
                    SelectionMark = x.SelectionMark,
                    InsertionMark = x.InsertionMark,
                    ShakerMark = x.ShakerMark,
                    ShellMark = x.ShellMark,
                    QuickMark = x.QuickMark,
                    TotalAttempts = x.TotalAttempts,
                    Rating = x.Rating,
                };
					ans.Add(a);
			}
            foreach (var x in ans)
            {
                var h = DBContext.UsersDB.First(h => h.IdUser == x.IdUser);
                x.FIO = h.FIO;
                x.Group = h.Group;
            }
			//var h = DBContext.UsersDB.First(h => h.IdUser == x.IdUser);//
			return ans;
        }
        public bool ChangeUser(Users user, int id)
        {
            bool Ans = false;
            try
            {

                //UsersDB x = DBContext.UsersDB.Where(x => x.Login == "admin").FirstOrDefault();
                var x = DBContext.UsersDB.First(x => x.IdUser == id);//
                //x.Password = PasswordHash.GetHashCode(pass); ;
                x.FIO = user.FIO;
                x.Group = user.Group;
                x.Login = user.Login;
                DBContext.SaveChanges();
                Ans = true; 
            }
            catch { }
            return Ans;
        }
    }
}
