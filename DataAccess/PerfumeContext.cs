using Domain;
using EFDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess
{
    public class PerfumeContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            /*modelBuilder.Entity<Cart>().HasData(carts);
            modelBuilder.Entity<UserUseCase>().HasData(userUseCases);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<PerfumeScentNote>().HasData(perfumeScentNotes);
            modelBuilder.Entity<Perfume>().HasData(perfumes);
            modelBuilder.Entity<ScentNote>().HasData(scentNotes);
            modelBuilder.Entity<FragranceType>().HasData(fragranceTypes);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Gender>().HasData(genders);*/
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PerfumeConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new FragranceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ScentNoteConfiguration());

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Perfume>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(x => !x.IsDeleted);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXpress;Initial Catalog=dbperfumes;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FragranceType> FragranceTypes { get; set; }
        public DbSet<ScentNote> ScentNotes { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<PerfumeScentNote> PerfumeScentNotes { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
