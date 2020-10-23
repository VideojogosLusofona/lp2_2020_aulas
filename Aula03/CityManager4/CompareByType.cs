using System.Collections.Generic;

namespace CityManager4
{
    /// <summary>
    /// Compares buildings by type according to the IComparer interface.
    /// </summary>
    /// <typeparam name="Building">Building which will be compared.</typeparam>
    public class CompareByType : IComparer<Building>
    {
        // True for ascending order, false otherwise
        private bool ord;

        /// <summary>
        /// Creates a new instance of CompareByType.
        /// </summary>
        /// <param name="ord">
        /// True for ascending order, false otherwise.
        /// </param>
        public CompareByType(bool ord)
        {
            this.ord = ord;
        }

        /// <summary>
        /// Compares two buildings by type.
        /// </summary>
        /// <param name="x">The first building.</param>
        /// <param name="y">The second building.</param>
        /// <returns>
        /// A negative number if the first building's type comes before the
        /// second building's type.
        /// Zero if both buildings have the same type.
        /// A positive number if first building's type is to appear after the
        /// second building's type.
        /// </returns>
        public int Compare(Building x, Building y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return ord ? x.Type.CompareTo(y.Type) : y.Type.CompareTo(x.Type);
        }
    }
}
