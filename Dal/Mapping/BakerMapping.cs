using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacMickey.Dal.Mapping
{
    internal class BakerMapping : IEntityTypeConfiguration<Baker>
    {
        public void Configure(EntityTypeBuilder<Baker> builder)
        {
            builder.ToTable(name: "Baker", schema: "Supplier")
                .HasKey(ba => ba.BakerId);

            builder.Property(ba => ba.BakerId)
                .HasColumnName("BakerID")
                .UseSqlServerIdentityColumn();

            builder.Property(ba => ba.Name)
                .HasMaxLength(30)
                .IsRequired();

            // EF core 2
            //[Optional one-to-many]
            builder.HasMany(bk => bk.BakerBreads)
                .WithOne(bb => bb.Baker);
        }
    }
}
