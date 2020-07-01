 using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(x => x.Username);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(25);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(25);

            builder.HasMany(x => x.UserUseCases).WithOne(u => u.User).HasForeignKey(u => u.UserId);

            builder.HasMany(x => x.PerfumesInCart).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        }
    }
}
