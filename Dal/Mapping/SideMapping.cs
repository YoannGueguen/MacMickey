using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class SideMapping : IEntityTypeConfiguration<Side>
    {
        public void Configure(EntityTypeBuilder<Side> builder)
        {
            builder.ToTable(name: "Side", schema: "Domain");

            builder.Property(s => s.Weight)
                .HasColumnName("SideWeight")
                .IsRequired();

            builder.Property(s => s.SaltWeight)
                .IsRequired(false);
        }
    }
}
