using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.Dal.Mapping
{
    internal class BasketCardMapping : IEntityTypeConfiguration<BasketCard>
    {
        public void Configure(EntityTypeBuilder<BasketCard> builder)
        {
            builder.ToTable(name: "BasketCard", schema: "Domain");
            //ERROR MAPPING inverser les cardinalite + passer product en icollection
            builder.HasOne(b => b.Product)
                .WithMany(p => p.BasketCards)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
