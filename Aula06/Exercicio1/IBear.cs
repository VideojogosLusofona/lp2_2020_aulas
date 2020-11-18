namespace Exercicio1
{
    public interface IBear
    {
        bool Hibernating { get; set; }

        void Roar();
        void LookAt(object objectToLookAt);
        void GoTowards(object objectToWalkTowards);
        bool TryEat(object objectToEat);
    }
}