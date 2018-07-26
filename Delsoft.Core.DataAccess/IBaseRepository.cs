// <copyright file="IBaseRepository.cs" company="Delsoft">
// Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Delsoft.Core.DataModel;

    /// <summary>
    /// Defines all base methods for a repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(TEntity entity);

        /// <summary>
        /// Creates the specified i enumerable`1.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Create(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the entity <typeparamref name="TEntity"/> corresponding to the <paramref name="id"/>.</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Returns all <typeparamref name="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets the entity that correspond to the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void GetBy(Expression<Func<TEntity, bool>> predicate);
    }
}
