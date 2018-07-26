// <copyright file="EntityTest.cs" company="Delsoft">
// Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataModel.Test
{
    using System;
    using Xunit;

    /// <summary>
    /// This class provides test for <see cref="Entity{TEntity, TKey}"/> class.
    /// </summary>
    public class EntityTest
    {
        /// <summary>
        /// Determines whether this instance [can equal same simple key entity].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can equal same complex key entity].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can not equal not same simple key entity].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can not equal not same complex key entity].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can equal not same simple key entity].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can equal not same complex key entity].
        /// </summary>
        [Fact]
        public void Can_Equal_NotSame_ComplexKeyEntity()
        {
            // Arrange
            var left = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 2 } };
            var right = new ComplexKeyEntity() { Id = new ComplexKey<int, int> { IdPart1 = 1, IdPart2 = 2 } };

            // Act
            var @operator = left == right;
            var equal = left.Equals(right);

            // Assert
            Assert.True(@operator);
            Assert.True(equal);
        }

        /// <summary>
        /// Determines whether this instance [can not equal not same simple key entity with value].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can not equal not same complex key entity with value].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can equal null].
        /// </summary>
        [Fact]
        public void Can_Equal_Null()
        {
            // Arrange
            var entity = new SimpleKeyEntity() { Id = 2 };
            var nullValue = (SimpleKeyEntity)null;

            // Act

            // Assert
            Assert.False(nullValue == entity);
            Assert.False(nullValue != entity);
            Assert.False(entity == nullValue);
            Assert.True(entity != nullValue);
        }

        /// <summary>
        /// Determines whether this instance [can equal object].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can not equal object].
        /// </summary>
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

        /// <summary>
        /// Determines whether this instance [can default property].
        /// </summary>
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
}
