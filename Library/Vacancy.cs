namespace Library
{
    public class Vacancy
    {
        public string Name { get; set; }
        public bool ISOpen { get; set; }

        public Vacancy()
        {

        }
        public Vacancy(string name, bool isOpen)
        {
            Name = name;
            ISOpen = isOpen;
        }
    }
}
