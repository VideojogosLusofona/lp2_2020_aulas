namespace Exercicio4
{
    // Interface for a generic 2D buffer
    public interface IBuffer2D<T>
    {
        int XDim { get; }
        int YDim { get; }
        T this[int x, int y] { get; set; }
    }
}