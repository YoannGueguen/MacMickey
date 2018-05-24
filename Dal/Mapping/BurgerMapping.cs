using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class BurgerMapping : IEntityTypeConfiguration<Burger>
    {
        public void Configure(EntityTypeBuilder<Burger> builder)
        {
            builder.ToTable(name: "Burger", schema: "Domain");
            
            builder.Property(b => b.Weight)
                .HasColumnName("BurgerWeight")
                .IsRequired();
            
            builder.Property(b => b.BeefWeight)
                .IsRequired(false);
        }
    }
}
