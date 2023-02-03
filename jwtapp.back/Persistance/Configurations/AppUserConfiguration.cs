using System.Collections.Immutable;
using jwtapp.back.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jwtapp.back.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.AppRoleId);
            
            builder.Property(x=>x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(20).IsRequired();
        }
        
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
        
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
    
}