using System;
using System.Collections;
using System.Collections.Generic;

namespace Podium
{
    /// <summary>
    /// This class represents a podium, where only the best objects can be.
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects accepted in the podium. These objects must implement
    /// the IComparable interface, so we can check who's best.
    /// </typeparam>
    public class Podium<T> : IEnumerable<T> where T : IComparable<T>
    {
        // Internally we keep our podium in a list, which we keep as a private
        // instance variable
        private readonly List<T> podium;

        // The podium size is represented by a read-only property
        public int PodiumSize { get; }

        /// <summary>
        /// The constructor initializes our podium with the specified number of
        /// slots.
        /// </summary>
        /// <param name="podiumSize">The number of slots in our podium.</param>
        public Podium(int podiumSize)
        {

            // Initialize the podium size property
            PodiumSize = podiumSize;

            // Initialize list with slots for the specified size plus one for
            // temporary new objects that are not good enough to be in the
            // podium
            podium = new List<T>(podiumSize + 1);

            // Note: creating a list with a pre-specified size improves
            // performance (as long as the actual list size never gets bigger)
        }

        /// <summary>
        /// Try to add an object to the podium.
        /// </summary>
        /// <param name="obj">
        /// Object that we'll try to add to the podium.
        /// </param>
        /// <returns>
        /// True if object got into the podium, false otherwise.
        /// </returns>
        public bool Add(T obj)
        {
            // This flag indicates if the object got into the podium or note
            // It will be our return value
            bool inThePodium;

            // Add object to the list and sort the list
            podium.Add(obj);
            podium.Sort();

            // Did our list grow larger than the podium size?
            if (podium.Count > PodiumSize)
            {
                // Set the return flag according to wether our object came last
                inThePodium = !Equals(obj, podium[PodiumSize]);
                // Remove object in last position, which may or may not be our
                // object
                podium.RemoveAt(PodiumSize);
            }
            else
            {
                // In this case, the podium did not grow larger than the
                // specified podium size, so we're sure that the new object was
                // in fact placed in the podium
                inThePodium = true;
            }

            // Return flag indicating if object was placed in the podium
            return inThePodium;
        }

        /// <summary>
        /// This method is required because our classe implements
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <returns>The objects in the podium, one by one.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Go through objects in the podium
            foreach (T obj in podium)
            {
                // And return them, one at a time
                yield return obj;
            }
        }

        /// <summary>
        /// This method is required because our classe indirectly implements
        /// <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>This method simply calls its generic version.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
