using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.Dal.Mapping
{
    internal class BakerBreadMapping : IEntityTypeConfiguration<BakerBread>
    {
        public void Configure(EntityTypeBuilder<BakerBread> builder)
        {
            //Primary key of baker bread is just assembly of baker and bread foreign keys
            builder.ToTable(name: "BakerBread", schema: "Supplier")
                    .HasKey(bb => new { bb.BakerId, bb.BreadId });
        }
    }
}
