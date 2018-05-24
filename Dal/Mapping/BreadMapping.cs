using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class BreadMapping : IEntityTypeConfiguration<Bread>
    {
        public void Configure(EntityTypeBuilder<Bread> builder)
        {
            builder.ToTable(name: "Bread", schema: "Supplier")
                .HasKey(b => b.BreadId);

            builder.Property(b => b.BreadId)
                .HasColumnName("BreadID")
                .UseSqlServerIdentityColumn();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.HasSesameSeed)
                .IsRequired();

            // EF core 2
            //[Optional one-to-many]
            builder.HasMany(br => br.BakerBreads)
                .WithOne(bb => bb.Bread);
        }
    }
}
