using System.Collections.Generic;

public interface IBag<T> : IEnumerable<T>
{
    void Add(T item);
    void Remove(T item);
}
