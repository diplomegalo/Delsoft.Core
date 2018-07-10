namespace DataModel
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Support all data model entities classes by providing and Id and base methods.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="DataModel.BaseEntity"/>
    public abstract class BaseEntityGeneric<TEntity, TKey> : BaseEntity
        where TEntity : BaseEntityGeneric<TEntity, TKey>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>This property hides the base <see cref="BaseEntity.Id"/> property.</remarks>
        public new TKey Id
        {
            get
            {
                if (base.Id == null)
                {
                    return default(TKey);
                }
                return (TKey)base.Id;
            }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is transient.
        /// </summary>
        /// <value><c>true</c> if this instance is transient; otherwise, <c>false</c>.</value>
        protected bool IsTransient
        {
            get => (typeof(TKey).IsValueType && this.Id.Equals(default(TKey))
#pragma warning disable IDE0041 // Use 'is null' check
                || (!typeof(TKey).IsValueType && ReferenceEquals(this.Id, null)));
#pragma warning restore IDE0041 // Use 'is null' check
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(BaseEntityGeneric<TEntity, TKey> leftOperand, BaseEntityGeneric<TEntity, TKey> rightOperand) =>
            leftOperand is null && !(rightOperand is null)
                || (!(leftOperand is null) 
                    && !leftOperand.Equals(rightOperand));

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(BaseEntityGeneric<TEntity, TKey> leftOperand, BaseEntityGeneric<TEntity, TKey> rightOperand) => 
            leftOperand is null && rightOperand is null 
                || (!(leftOperand is null)
                    && leftOperand.Equals(rightOperand));
        

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => !(obj is null)
                && this.GetType().Equals(obj.GetType())
                && this.Equals((TEntity)obj);


        /// <summary>
        /// Equalses the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// <c>true</c> if the specified entity is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(TEntity obj) => ReferenceEquals(this, obj)
                || (!(this is null)
                    && !this.IsTransient
                    && !obj.IsTransient
                    && this.Id.Equals(obj.Id));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures
        /// like a hash table.
        /// </returns>
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}