using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Perfumes)
                .WithOne(p => p.Gender).HasForeignKey(p => p.GenderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
