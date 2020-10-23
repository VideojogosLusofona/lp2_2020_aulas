using System;

namespace CityManager3
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
