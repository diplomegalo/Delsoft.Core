// <copyright file="TestEntityRepository.cs" company="Delsoft">
//     Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess.EntityFramework.Test
{
    using DataAccess.EntityFramework;

    /// <summary>
    /// This class provides test for <see cref="BaseRepository{TEntity}"/>
    /// </summary>
    /// <seealso cref="BaseRepository{TestEntity}"/>
    internal class TestEntityRepository : BaseRepository<TestEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestEntityRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public TestEntityRepository(TestContext dbContext)
            : base(dbContext)
        {
        }
    }
}