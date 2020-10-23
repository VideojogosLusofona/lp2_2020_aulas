using System;

namespace BuildingCollections
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
