using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable(name: "Menu", schema: "Domain");

            builder.HasOne(m => m.Burger)
                .WithMany(b => b.Menus)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Beverage)
                .WithMany(b => b.Menus)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Side)
                .WithMany(b => b.Menus)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Dessert)
                .WithMany(b => b.Menus)
                .IsRequired(false);
        }
    }
}
