// <copyright file="TestContext.cs" company="Delsoft">
//     Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess.EntityFramework.Test
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class provides test class for <see cref="BaseContext"/>
    /// </summary>
    /// <seealso cref="BaseContext"/>
    internal class TestContext : BaseContext
    {
        /// <summary>
        /// Gets or sets the entity tests.
        /// </summary>
        /// <value>The entity tests.</value>
        public DbSet<TestEntity> EntityTests { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "Test");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>();
        }
    }
}