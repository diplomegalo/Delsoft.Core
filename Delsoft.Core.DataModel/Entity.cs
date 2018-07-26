// <copyright file="Entity.cs" company="Delsoft">
//     Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataModel
{
    using System;

    /// <summary>
    /// Support all data model entities classes by providing and Id and base methods.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="BaseEntity"/>
    public abstract class Entity<TEntity, TKey> : BaseEntity
        where TEntity : Entity<TEntity, TKey>
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

            set
            {
                base.Id = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is transient.
        /// </summary>
        /// <value><c>true</c> if this instance is transient; otherwise, <c>false</c>.</value>
        protected bool IsTransient
        {
            get => (typeof(TKey).IsValueType && this.Id.Equals(default(TKey)))
                || (!typeof(TKey).IsValueType && ReferenceEquals(this.Id, null));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Entity<TEntity, TKey> leftOperand, Entity<TEntity, TKey> rightOperand) =>
            !ReferenceEquals(leftOperand, null) && !leftOperand.Equals(rightOperand);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Entity<TEntity, TKey> leftOperand, Entity<TEntity, TKey> rightOperand) =>
            !ReferenceEquals(leftOperand, null) && leftOperand.Equals(rightOperand);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return ReferenceEquals(this, obj) || (!this.IsTransient && !((TEntity)obj).IsTransient && this.Id.Equals(((TEntity)obj).Id));
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}