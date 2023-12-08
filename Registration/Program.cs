using HashPassword;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompBaseEntities CompEntities=new CompBaseEntities();
            Console.WriteLine("Ввежите id должности\n1-Технический специалист 2-Менеджер по продажам 3-Директор 4-Работник склада: ");
            int idPost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввежите имя пользователя: ");
            string Name= Console.ReadLine();
            Console.WriteLine("Ввежите фамилию пользователя: ");
            string Surname= Console.ReadLine();
            Console.WriteLine("Ввежите Отчество пользователя: ");
            string Patronomyc= Console.ReadLine();
            Console.WriteLine("Ввежите Телефонный номер пользователя: ");
            string phoneNumber= Console.ReadLine();
            Console.WriteLine("Ввежите Email пользователя: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Ввежите логин пользователя: ");

           string login = Console.ReadLine();
            Console.WriteLine("Ввежите пароль пользователя: ");
            string password = Console.ReadLine();
            hashPassword hasher = new hashPassword();
            string hashpassword = hasher.HashingPassword(password);
            Console.WriteLine(hashpassword);
            var emp = new Models.Employeey
            {
                IdPost = idPost,
                Name = Name,
                Surname = Surname,
                Patronymic =Patronomyc,
                PhoneNumber = phoneNumber,
                Email = Email
            };
            CompEntities.Employeey.Add(emp);
            CompEntities.SaveChanges();

            var user = new Models.Users 
            {   IdEmp = emp.IdEmp,
                Login = login,
                Password = hashpassword 
            };

            CompEntities.Users.Add(user);
            CompEntities.SaveChanges();

            Console.WriteLine("Учетная запись добавлена");
            Console.WriteLine($"Логин сотрудника{login} Пароль сотрудника{hashpassword}");
            Console.ReadKey();
        }
    }
}
