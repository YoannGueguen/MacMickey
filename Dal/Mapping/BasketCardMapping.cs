using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.Dal.Mapping
{
    class BasketCardMapping
    {
        public void Configure(EntityTypeBuilder<BasketCards> builder)
        {
            builder.ToTable(name: "BasketCard", schema: "Domain");

            builder.HasOne(b => b.Product)
                .WithMany(p => p.BasketCards)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
