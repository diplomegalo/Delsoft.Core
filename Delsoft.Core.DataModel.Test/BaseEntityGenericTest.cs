using System;
using Xunit;

namespace DataModel.Test
{
    
    public class BaseEntityTest
    {
        [Fact]
        public void Can_Equal_Same_SimpleKeyEntity()
        {
            // Arrange
            var left = new SimpleKeyEntity();

            // Act
            var result = left.Equals(left);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Can_Equal_Same_ComplexKeyEntity()
        {
            // Arrange
            var left = new ComplexKeyEntity();

            // Act
            var result = left.Equals(left);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Can_NotEqual_NotSame_SimpleKeyEntity()
        {
            // Arrange
            var left = new SimpleKeyEntity();
            var right = new SimpleKeyEntity();

            // Act

            // Assert
            Assert.False(left.Equals(right));
            Assert.True(left != right);
        }

        [Fact]
        public void Can_NotEqual_NotSame_ComplexKeyEntity()
        {
            // Arrange
            var left = new ComplexKeyEntity();
            var right = new ComplexKeyEntity();

            // Act

            // Assert
            Assert.False(left.Equals(right));
            Assert.True(left != right);
        }

        [Fact]
        public void Can_Equal_NotSame_SimpleKeyEntity()
        {
            // Arrange
            var left = new SimpleKeyEntity() { Id = 1 };
            var right = new SimpleKeyEntity() { Id = 1 };

            // Act

            // Assert
            Assert.True(left.Equals(right));
            Assert.True(left == right);
        }

        [Fact]
        public void Can_Equal_NotSame_ComplexKeyEntity()
        {
            // Arrange
            var left = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 2 } };
            var right = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 2 } };

            // Act

            // Assert
            Assert.True(left.Equals(right));
            Assert.True(left == right);
        }

        [Fact]
        public void Can_NotEqual_NotSame_SimpleKeyEntity_With_Value()
        {
            // Arrange
            var left = new SimpleKeyEntity() { Id = 1 };
            var right = new SimpleKeyEntity() { Id = 2 };

            // Act

            // Assert
            Assert.False(left.Equals(right));
            Assert.True(left != right);
        }

        [Fact]
        public void Can_NotEqual_NotSame_ComplexKeyEntity_With_Value()
        {
            // Arrange
            var left = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 2 } };
            var right = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 3 } };

            // Act

            // Assert
            Assert.False(left.Equals(right));
            Assert.True(left != right);
        }

        [Fact]
        public void Can_Equal_Null()
        {
            // Arrange
            var right = new SimpleKeyEntity() { Id = 2 };

            // Act

            // Assert
            Assert.False(((SimpleKeyEntity)null) == right);
            Assert.True(((SimpleKeyEntity)null) != right);
            Assert.False(right == null);
            Assert.True(right != null);
        }

        [Fact]
        public void Can_Equal_Object()
        {
            // Arrange
            var right = new SimpleKeyEntity() { Id = 1 };
            object left = new SimpleKeyEntity() { Id = 1 };

            // Act

            // Assert
            Assert.True(right.Equals(left));
        }

        [Fact]
        public void Can_NotEqual_Object()
        {
            // Arrange
            var right = new SimpleKeyEntity() { Id = 1 };
            object left = new SimpleKeyEntity() { Id = 2 };

            // Act

            // Assert
            Assert.False(right.Equals(left));
        }

        [Fact]
        public void Can_Default_Property()
        {
            // Arrange
            var simpleKeyEntity = new SimpleKeyEntity();
            var complexKeyEntity = new ComplexKeyEntity();

            // Act

            // Assert
            Assert.Equal(default(int), simpleKeyEntity.Id);
            Assert.Equal(default(ComplexKey<int, int>), complexKeyEntity.Id);
            Assert.Equal(default(DateTime), simpleKeyEntity.CreationDate);
            Assert.Equal(default(DateTime), complexKeyEntity.CreationDate);
            Assert.False(simpleKeyEntity.IsDeleted);
            Assert.False(complexKeyEntity.IsDeleted);
            Assert.Null(simpleKeyEntity.UpdateDate);
            Assert.Null(complexKeyEntity.UpdateDate);
        }
    }

    internal class SimpleKeyEntity : BaseEntityGeneric<SimpleKeyEntity, int>
    {

    }

    internal class ComplexKeyEntity : BaseEntityGeneric<ComplexKeyEntity, ComplexKey<int, int>>
    {

    }

}
