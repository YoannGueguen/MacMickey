using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class DessertMapping : IEntityTypeConfiguration<Dessert>
    {
        public void Configure(EntityTypeBuilder<Dessert> builder)
        {
            builder.ToTable(name: "Dessert", schema: "Domain");

            builder.Property(d => d.Milliliter)
                .HasColumnName("DessertMilliter")
                .IsRequired();

            builder.Property(d => d.IsFrozen)
                .IsRequired();
        }
    }
}
