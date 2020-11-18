namespace Exercicio1
{
    /// <summary>
    /// The adapter class always implements the interface it's trying to
    /// adapt to.
    /// </summary>
    public class WolfAdapter : IDog
    {
        /// <summary>
        /// An adapter always keeps a reference to the object it adapts, in
        /// this case, a concrete instance of IWolf.
        /// </summary>
        private IWolf wolf;

        /// <summary>
        /// Wolves don't bark, they howl, so we adapt the method accordingly
        /// </summary>
        public void Bark()
        {
            wolf.Howl();
        }

        /// <summary>
        /// Wolves don't fetch objects like dogs. They'll probably chase the
        /// object and kill it or destroy it.
        /// </summary>
        /// <param name="objectToFetch">
        /// Object the wolf will "fetch".
        /// </param>
        public void Fetch(object objectToFetch)
        {
            wolf.Chase(objectToFetch);
            wolf.Kill(objectToFetch);
        }

        /// <summary>
        /// Create a new instance of a wolf adapter.
        /// </summary>
        /// <param name="wolf">The wolf to be adapted as a dog.</param>
        public WolfAdapter(IWolf wolf)
        {
            this.wolf = wolf;
        }
    }
}
