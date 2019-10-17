using System;

namespace Library
{
    public class Worker
    {
        private int _id;
        private string _fio;
        private string _education;
        private string _specialty;
        private int _year;

        public Worker(int id, string fio, string education, string specialty, int year)
        {
            this._id = id;
            this._fio = fio;
            this._education = education;
            this._specialty = specialty;
            this._year = year;
        }

        public int ID { get { return _id; } }
        public int Year { get { return _year; } }
        public string FIO { get { return _fio; } }

        public override string ToString()
        {
            return $"Worker: Id: {_id}, FIO: {_fio}, Education: {_education}, Specialty: {_specialty}, Date: {_year}";
        }
    }
}
