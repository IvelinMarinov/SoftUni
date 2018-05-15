using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Models;

namespace ProductsShop.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Age)
                .IsRequired(false);

            builder.Property(u => u.FirstName)
                .IsRequired(false);

            builder.Property(u => u.LastName)
                .IsRequired(true);

            builder.HasMany(u => u.ProductsSold)
                .WithOne(ps => ps.Seller)
                .HasForeignKey(ps => ps.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ProductsBought)
                .WithOne(pb => pb.Buyer)
                .HasForeignKey(pb => pb.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
