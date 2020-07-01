using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ScentNoteConfiguration : IEntityTypeConfiguration<ScentNote>
    {
        public void Configure(EntityTypeBuilder<ScentNote> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.HasMany(x => x.PerfumesScentNote).WithOne(s => s.ScentNote).HasForeignKey(s => s.ScentNoteId);
        }
    }
}
