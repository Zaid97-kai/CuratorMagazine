using CuratorMagazineWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuratorMagazineWebAPI.Models.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(x => x.Mother)
                .WithMany(x => x.MotherChildrens)
                .HasForeignKey(x => x.MotherId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);            
            
            builder
                .HasOne(x => x.Father)
                .WithMany(x => x.FatherChildrens)
                .HasForeignKey(x => x.FatherId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);            
            
            builder
                .HasOne(x => x.Division)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DivisionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
