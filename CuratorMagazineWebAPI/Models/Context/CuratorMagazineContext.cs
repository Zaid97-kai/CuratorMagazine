using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using DataProtectionKey = Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey;

namespace CuratorMagazineWebAPI.Models.Context
{
    public class CuratorMagazineContext : DbContext, ICuratorMagazineContext, Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext
    {
        public CuratorMagazineContext(DbContextOptions<CuratorMagazineContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region Entities

        public DbSet<User> Users { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion

        public DbSet<DataProtectionKey> DataProtectionKeys { get; }
    }
}
