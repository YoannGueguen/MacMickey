using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MacMickey.Dal.Extensions;

namespace MacMickey.Dal.Mapping
{
    /// <summary>
    /// Configuration used to define Product table
    /// </summary>
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Product", schema: "Domain")
                .HasKey(p => p.ProductID);

            builder.Property(p => p.ProductID)
                .HasColumnName("ProductID")
                .UseSqlServerIdentityColumn(); //TODO: provider injection

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(4, 2);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(350);

            builder.Property(p => p.Stockpiled)
                .IsRequired();
        }
    }
}
