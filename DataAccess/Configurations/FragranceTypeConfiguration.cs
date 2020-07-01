using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class FragranceTypeConfiguration : IEntityTypeConfiguration<FragranceType>
    {
       
        public void Configure(EntityTypeBuilder<FragranceType> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(t => t.Perfumes)
                .WithOne(x => x.FragranceType)
                .HasForeignKey(x => x.FragranceTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
