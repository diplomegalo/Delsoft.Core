using System;
using System.Collections.Generic;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Support all repository methods with Entity Framework Core.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="DataAccess.IBaseRepository{TEntity}" />
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

        ///<inheritdoc/>
        public void Create(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.CreationDate = DateTime.Today;
            this.dbContext.Add(entity);
        }

        ///<inheritdoc/>
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
