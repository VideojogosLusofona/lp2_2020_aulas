namespace Exercicio1
{
    public interface ISubject
    {
        void RegisterObserver(IObserver obs);
        void RemoveObserver(IObserver obs);
    }
}
