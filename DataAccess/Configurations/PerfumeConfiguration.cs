using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class PerfumeConfiguration : IEntityTypeConfiguration<Perfume>
    {
        public void Configure(EntityTypeBuilder<Perfume> builder)
        {
            builder.Property(x => x.Fragrance).IsRequired().HasMaxLength(30);
            builder.HasMany(p => p.PerfumeScentNotes).WithOne(x => x.Perfume).HasForeignKey(x => x.PerfumeId);
            builder.HasMany(p => p.PerfumesInCart).WithOne(c => c.Perfume).HasForeignKey(c => c.PerfumeId);

            builder.HasMany(p => p.OrderItems).WithOne(i => i.Perfume).HasForeignKey(i => i.PerfumeId);
        }
    }
}
