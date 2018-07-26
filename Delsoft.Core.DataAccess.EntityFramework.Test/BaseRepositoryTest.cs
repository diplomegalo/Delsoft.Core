// <copyright file="BaseRepositoryTest.cs" company="Delsoft">
// Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess.EntityFramework.Test
{
    using System;
    using Xunit;

    /// <summary>
    /// This class provides test for <see cref="BaseRepository{TEntity}"/>
    /// </summary>
    public class BaseRepositoryTest
    {
        /// <summary>
        /// Determines whether this instance [can create entity].
        /// </summary>
        [Fact]
        public void Can_CreateEntity()
        {
            // Arrange
            var entity = new TestEntity() { Id = 1 };
            var dbContext = new TestContext();
            var repository = new TestEntityRepository(dbContext);

            // Act
            repository.Create(entity);

            // Assert
            Assert.NotEqual(default(DateTime), entity.CreationDate);
        }

        /// <summary>
        /// Cannots the create entity null.
        /// </summary>
        [Fact]
        public void Cannot_CreateEntity_Null()
        {
            // Arrange
            var dbContext = new TestContext();
            var repository = new TestEntityRepository(dbContext);

            // Act
            var actual = new Action(() => repository.Create((TestEntity)null));

            // Assert
            Assert.Equal("entity", Assert.Throws<ArgumentNullException>(actual).ParamName);
        }
    }
}
