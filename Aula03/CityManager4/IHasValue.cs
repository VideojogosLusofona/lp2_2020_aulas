using System;

namespace CityManager4
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
