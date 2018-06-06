using MacMickey.DomainModel;
using MacMickey.DomainModel.ModelOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.Dal.Mapping
{
    internal class BasketCardItemMapping : IEntityTypeConfiguration<BasketCardItem>
    {
        public void Configure(EntityTypeBuilder<BasketCardItem> builder)
        {
            builder.ToTable(name: "BasketCardItem", schema: "Domain");

            builder.HasOne(bc => bc.Product)
    .WithMany(p => p.BasketCardItems);
        }
    }
}
