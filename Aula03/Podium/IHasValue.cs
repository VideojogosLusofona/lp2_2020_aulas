using System;

namespace Podium
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value { get; }
    }
}
