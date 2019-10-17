namespace Library.Observable
{
    public interface IObservable
    {
        void RegisterObserver(IObserver o, string vacancy);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}
