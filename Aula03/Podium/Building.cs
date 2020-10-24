using System;

namespace Podium
{
    public class Building : IHasValue, IComparable<IHasValue>
    {
        public string Type { get; }
        public float Value { get; }
        public float Area { get; }

        public Building(string type, float  value, float area)
        {
            Type = type;
            Value = value;
            Area = area;
        }

        public override string ToString() =>
            $"{Type,-20}{Value,8:f2}${Area,8:f2}m2";

        /// <summary>
        /// Indicates whether the current object is "equal" to another object of
        /// the same type, according to the <see cref="IEquatable{T}"/>
        /// interface.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(IHasValue other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }

        /// <summary>
        /// This method compares two buildings according to the
        /// <see cref="IComparable{T}"/> interface. Buildings with a higher
        /// value come before buildings with a lower value.
        /// </summary>
        /// <param name="other">
        /// An object implementing <c>IHasValue</c> which will be compared to
        /// the current building in terms of value.
        /// </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being
        /// compared. If less than zero, the current building comes before
        /// <paramref name="other"/>; if zero, both buildings are in the same
        /// position; if greater than zero, the current building comes after
        /// <paramref name="other"/>.
        /// </returns>
        public int CompareTo(IHasValue other)
        {
            // Nulls always come first in sorting
            if (other == null) return 1;
            if (Value < other.Value) return -1;
            if (Value > other.Value) return 1;
            return 0;
        }

        // Return hash code for this building
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Value.GetHashCode();
        }

        // Two buildings are equal if they have the same type and value
        public override bool Equals(object obj)
        {
            Building other = obj as Building;
            if (obj is null) return false;
            return Type == other.Type && Value == other.Value;
        }
    }
}
