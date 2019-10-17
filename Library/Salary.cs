namespace Library
{
    public class Salary
    {
        private int _id;
        private double _salary1;
        private double _salary2;

        public int ID { get { return _id; } }
        public double Salary1 { get { return _salary1; } }
        public double Salary2 { get { return _salary2; } }

        public Salary(int id, double salary1, double salary2)
        {
            this._id = id;
            this._salary1 = salary1;
            this._salary2 = salary2;
        }
    }
}
