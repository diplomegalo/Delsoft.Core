namespace DataModel
{
    /// <summary>
    /// Provides base properties and methods for complex key
    /// </summary>
    /// <typeparam name="TKey1">The type of the key1.</typeparam>
    /// <typeparam name="TKey2">The type of the key2.</typeparam>
    public class ComplexKey<TKey1, TKey2>
    {
        /// <summary>
        /// Gets or sets the identifier part1.
        /// </summary>
        /// <value>The identifier part1.</value>
        public TKey1 IdPart1 { get; set; }

        /// <summary>
        /// Gets or sets the identifier part2.
        /// </summary>
        /// <value>The identifier part2.</value>
        public TKey2 IdPart2 { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return !ReferenceEquals(obj, null)
                && this.GetType().Equals(obj.GetType())
                && this.IdPart1.Equals(((ComplexKey<TKey1, TKey2>)obj).IdPart1)
                && this.IdPart2.Equals(((ComplexKey<TKey1, TKey2>)obj).IdPart2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures
        /// like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.IdPart1.GetHashCode() +
                this.IdPart2.GetHashCode()).GetHashCode();
        }
    }

    /// <summary>
    /// Provides base properties and methods for complex key
    /// </summary>
    /// <typeparam name="TKey1">The type of the key1.</typeparam>
    /// <typeparam name="TKey2">The type of the key2.</typeparam>
    /// <typeparam name="TKey3">The type of the key3.</typeparam>
    public class ComplexKey<TKey1, TKey2, TKey3> : ComplexKey<TKey1, TKey2>
    {
        /// <summary>
        /// Gets or sets the identifier part3.
        /// </summary>
        /// <value>The identifier part3.</value>
        public TKey3 IdPart3 { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj)
                && this.IdPart3.Equals(((ComplexKey<TKey1, TKey2, TKey3>)obj).IdPart3);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures
        /// like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode()
                + this.IdPart3.GetHashCode()).GetHashCode();
        }
    }
}