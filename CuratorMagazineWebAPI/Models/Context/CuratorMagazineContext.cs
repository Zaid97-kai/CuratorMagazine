// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-03-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-22-2022
// ***********************************************************************
// <copyright file="CuratorMagazineContext.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using DataProtectionKey = Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey;

namespace CuratorMagazineWebAPI.Models.Context
{
    /// <summary>
    /// Class CuratorMagazineContext.
    /// Implements the <see cref="DbContext" />
    /// Implements the <see cref="CuratorMagazineWebAPI.Models.Context.ICuratorMagazineContext" />
    /// Implements the <see cref="Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="CuratorMagazineWebAPI.Models.Context.ICuratorMagazineContext" />
    /// <seealso cref="Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext" />
    public class CuratorMagazineContext : DbContext, ICuratorMagazineContext, Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CuratorMagazineContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CuratorMagazineContext(DbContextOptions<CuratorMagazineContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks><para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
        /// </para></remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        /// <remarks>See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information.</remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        #region Entities

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        /// <value>The divisions.</value>
        public DbSet<Division> Divisions { get; set; }
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        public DbSet<Group> Groups { get; set; }
        /// <summary>
        /// Gets or sets the parents.
        /// </summary>
        /// <value>The parents.</value>
        public DbSet<Parent> Parents { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public DbSet<Role> Roles { get; set; }

        #endregion

        /// <summary>
        /// A collection of <see cref="T:Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey" />
        /// </summary>
        /// <value>The data protection keys.</value>
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
