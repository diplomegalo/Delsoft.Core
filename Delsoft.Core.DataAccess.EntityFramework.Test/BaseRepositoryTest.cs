using System;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DataAccess.EntityFramework.Test
{
    public class BaseRepositoryTest
    {
        [Fact]
        public void Can_CreateEntity()
        {
            // Arrange
            var entity = new TestEntity();
            var dbContext = new TestContext();
            var repository = new TestEntityRepository(dbContext);

            // Act
            repository.Create(entity);

            // Assert
            Assert.NotEqual(default(DateTime), entity.CreationDate);
        }

        [Fact]
        public void Cannot_CreateEntity_Null()
        {
            // Arrange
            var dbContext = new TestContext();
            var repository = new TestEntityRepository(dbContext);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => repository.Create(null));

            // Assert
            Assert.Equal("entity", ex.ParamName);
        }
    }

    internal class TestEntity : BaseEntityGeneric<TestEntity, int>
    {

    }

    internal class TestContext : BaseContext
    {
        public DbSet<TestEntity> EntityTests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "Test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>();
        }
    }

    internal class TestEntityRepository : BaseRepository<TestEntity>
    {
        public TestEntityRepository(TestContext dbContext) : base(dbContext)
        {
        }
    }
}
