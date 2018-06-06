using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MacMickey.DomainModel;
using MacMickey.DomainModel.ModelOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(name: "Order", schema: "Domain")
                .HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .UseSqlServerIdentityColumn();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders);

            builder.HasOne(o => o.BasketCard)
                .WithOne(b => b.Order);
        }
    }
}
