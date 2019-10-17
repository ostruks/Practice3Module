using Library.Observable;
using System;
using System.Linq;

namespace Library
{
    public class User : IObserver
    {
        IObservable _vacancy;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vacancy { get; set; }

        public User(string name)
        {
            this.Name = name;
        }

        public void Update(object ob)
        {
            Vacancy vacancy = (Vacancy)ob;
            if (vacancy.ISOpen)
            {
                Console.WriteLine($"Hello, {Name}, vacancy {vacancy.Name} is open!");
            }
            else
            {
                Console.WriteLine($"Hello, {Name}, vacancy {vacancy.Name} is closed!");
            }
        }

        public void Subscribe(string name, IObservable department)
        {
            Department dep = (Department)department;
            if (dep.Vacancies.Any(d => d.Name == name))
            {
                this._vacancy = department;
                _vacancy.RegisterObserver(this, name);
            }
        }

        public void StopWatch()
        {
            _vacancy.RemoveObserver(this);
            _vacancy = null;
        }
    }
}
