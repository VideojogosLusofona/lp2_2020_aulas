using System;

namespace MyGenericMethod
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
