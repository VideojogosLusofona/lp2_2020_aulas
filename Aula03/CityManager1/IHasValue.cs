using System;

namespace CityManager1
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
