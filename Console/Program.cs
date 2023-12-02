using Console.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Models.LibraryBaseEntitiess entities = new LibraryBaseEntitiess();
            System.Console.WriteLine("введите должность пользователя\n1)Фотограф 2)копировальщик 3)админ 4) модератор 5)директор:");
            int idPos;
            if (!int.TryParse(System.Console.ReadLine(), out idPos))
            {
                System.Console.WriteLine("Ошибка ввода для должности. Введите целое число.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("Введите имя пользователя:");
            string name = System.Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                System.Console.WriteLine("Имя пользователя не может быть пустым.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("введите фамилию пользователя:");
            string last = System.Console.ReadLine();
            if (string.IsNullOrEmpty(last))
            {
                System.Console.WriteLine("Фамилия пользователя не может быть пустой.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("введите отчество пользователя:");
            string otchestv = System.Console.ReadLine();

            System.Console.WriteLine("введите адрес пользователя:");
            string adres = System.Console.ReadLine();
            if (string.IsNullOrEmpty(adres))
            {
                System.Console.WriteLine("Адрес пользователя не может быть пустым.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("введите дату рождения пользователя:");
            DateTime date;
            if (!DateTime.TryParse(System.Console.ReadLine(), out date))
            {
                System.Console.WriteLine("Ошибка ввода для даты рождения. Введите дату в формате MM/dd/yyyy.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("введите логин пользователя:");
            string Login = System.Console.ReadLine();
            if (string.IsNullOrEmpty(Login))
            {
                System.Console.WriteLine("Логин пользователя не может быть пустым.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("введите пароль пользователя:");
            string Password = System.Console.ReadLine();
            if (string.IsNullOrEmpty(Password))
            {
                System.Console.WriteLine("Пароль пользователя не может быть пустым.");
                System.Console.ReadKey();
                return;
            }

            string hashpassword = HashPassword.Hash.Hashing(Password);
            System.Console.WriteLine(hashpassword);

            var emp = new Console.Models.list_employees
            {
                position_number = idPos,
                imya = name,
                familiya = last,
                otchestvo = otchestv,
                address = adres,
                date_birthday = date,
            };
            entities.list_employees.Add(emp);
            entities.SaveChanges();

            var user = new Console.Models.Users
            {
                id_user = emp.id_employees,
                login = Login,
                password = hashpassword,
            };
            entities.Users.Add(user);
            entities.SaveChanges();

            System.Console.WriteLine("учетная запись добавлена");
            System.Console.ReadKey();
        }
    }
}



