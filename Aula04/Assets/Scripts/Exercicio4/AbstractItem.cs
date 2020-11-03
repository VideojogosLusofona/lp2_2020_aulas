using System;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractItem : IBag<AbstractItem>, IHasWeight
{
    // Implementação da propriedade indicada por IHasWeight
    public abstract float Weight { get; }

    // Implementação dos métodos Add e Remove, indicados por IBag
    public virtual void Add(AbstractItem item)
    {
        throw new InvalidOperationException();
    }

    public virtual void Remove(AbstractItem item)
    {
        throw new InvalidOperationException();
    }

    // Implementação do método indicado por IEnumerable<T>
    public virtual IEnumerator<AbstractItem> GetEnumerator()
    {
        throw new InvalidOperationException();
    }

    // Implementação explícita do método indicado por IEnumerable (não genérico)
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
