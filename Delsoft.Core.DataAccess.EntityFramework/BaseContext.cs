﻿// <copyright file="BaseContext.cs" company="Delsoft">
// Copyright (c) Delsoft. All rights reserved.
// </copyright>

namespace Delsoft.Core.DataAccess.EntityFramework
{
    using Delsoft.Core.DataModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Supports entity framework context classes providing base configuration.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>The entities.</value>
        protected DbSet<BaseEntity> Entities { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore(typeof(BaseEntity));
        }
    }
}