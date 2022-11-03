using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Models.Context
{
    public interface ICuratorMagazineContext
    {
        #region Entities

        public DbSet<User> Users { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion
    }
}
