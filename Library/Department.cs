using Library.Observable;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Department : IObservable
    {
        private List<Vacancy> _vacancies;
        private List<IObserver> observers;
        public string Name { get; private set; }

        public List<Vacancy> Vacancies
        {
            get
            {
                return _vacancies;
            }
        }

        public Department(string name)
        {
            Name = name;
            _vacancies = new List<Vacancy>();
            observers = new List<IObserver>();
        }

        public void AddVacancy(Vacancy vacancy)
        {
            _vacancies.Add(vacancy);
        }

        public void RemoveVacancy(Vacancy vacancy)
        {
            _vacancies.Remove(vacancy);
        }

        public void OpenClose(string name, bool openClose)
        {
            if(_vacancies.Any(s => s.Name == name))
            {
                _vacancies.Where(s => s.Name == name).First().ISOpen = openClose;
            }
        }

        public void RegisterObserver(IObserver o, string vacancy)
        {
            User user = (User)o;
            if(user.Vacancy == vacancy)
            {
                observers.Add(o);
            }
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                User user = (User)o;
                foreach(var vacancy in _vacancies)
                {
                    if(user.Vacancy == vacancy.Name)
                    {
                        o.Update(vacancy);
                    }
                }
            }
        }

        public void VacancyOpen(string vacancy, bool open)
        {
            var vac = _vacancies.Where(s => s.Name == vacancy).First();
            vac.ISOpen = open;
            NotifyObservers();
        }
    }
}
