using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentVacancy
{
    class Program
    {
        static void Main(string[] args)
        {
            Department bookkeeping = new Department("Bookkeeping");
            Department managment = new Department("Managment");

            User user1 = new User("Ivan");
            user1.Email = "ivan@gmail.com";
            user1.Phone = "+380631234567";

            User user2 = new User("Slava");
            user2.Email = "slava@gmail.com";
            user2.Phone = "+380631234567";

            User user3 = new User("Serhii");
            user3.Email = "serhii@gmail.com";
            user3.Phone = "+380631234567";

            bookkeeping.Vacancies.Add(new Vacancy("Accountant", false));
            managment.Vacancies.Add(new Vacancy("Manager", false));

            user1.Vacancy = "Accountant";
            user2.Vacancy = "Manager";
            user3.Vacancy = "Accountant";

            user1.Subscribe("Accountant", bookkeeping);
            user2.Subscribe("Manager", managment);
            user3.Subscribe("Accountant", bookkeeping);

            bookkeeping.RegisterObserver(user1, "Accountant");
            bookkeeping.RegisterObserver(user3, "Accountant");
            managment.RegisterObserver(user2, "Manager");

            bookkeeping.VacancyOpen("Accountant", true);
            managment.VacancyOpen("Manager", true);

            bookkeeping.VacancyOpen("Accountant", false);
            managment.VacancyOpen("Manager", false);

            user2.StopWatch();
            bookkeeping.VacancyOpen("Accountant", true);

            Console.ReadKey();
        }
    }
}
