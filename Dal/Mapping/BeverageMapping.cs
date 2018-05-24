using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class BeverageMapping : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.ToTable(name: "Beverage", schema: "Domain");

            builder.Property(b => b.Milliliter)
                .HasColumnName("BeverageMilliter")
                .IsRequired();

            builder.Property(b => b.IsCarbonated)
                .IsRequired();
        }
    }
}
