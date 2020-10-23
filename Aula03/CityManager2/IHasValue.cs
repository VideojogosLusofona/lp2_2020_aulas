using System;

namespace CityManager2
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
