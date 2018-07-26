// <copyright file="BaseRepository.cs" company="Delsoft">
// Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Delsoft.Core.DataAccess;
    using Delsoft.Core.DataModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Support all repository methods with Entity Framework Core.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Delsoft.Core.DataAccess.IBaseRepository{TEntity}" />
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.CreationDate = DateTime.Now;
            this.dbContext.Add(entity);
        }

        /// <inheritdoc/>
        public void Create(IEnumerable<TEntity> entities)
        {
            entities.ToList()
                .ForEach(e => this.Create(e));
        }

        /// <inheritdoc/>
        public void Delete(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(IEnumerable<TEntity> entities)
        {
            entities.ToList()
                .ForEach(e => this.Delete(e));
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> GetAll()
        {
            return this.dbContext.Set<TEntity>()
                .ToList();
        }

        /// <inheritdoc/>
        public void GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            this.dbContext.Set<TEntity>()
                .Where(predicate);
        }

        /// <inheritdoc/>
        public TEntity GetById(object id)
        {
            return this.dbContext.Set<TEntity>()
                .Find(id);
        }

        /// <inheritdoc/>
        public void Update(TEntity entity)
        {
            var oldEntity = this.dbContext.Set<TEntity>()
                .Find(entity.Id);

            this.dbContext.Entry<TEntity>(oldEntity)
                .CurrentValues.SetValues(entity);

            oldEntity.UpdateDate = DateTime.Now;

            this.dbContext.SaveChanges();
        }
    }
}
