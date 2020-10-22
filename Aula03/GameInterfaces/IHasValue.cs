using System;

namespace GameInterfaces
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
