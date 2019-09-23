using Calculator.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Repository
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<CalculationHistory> CalculationHistories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.ApplyConfiguration(new ApplicationUserConfig());
            builder.ApplyConfiguration(new CalculationHistoryConfig());
        }
    }

    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.UserName).IsRequired();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.HasData(new ApplicationUser { Id = 1, UserName = "Admin" });
        }
    }
    public class CalculationHistoryConfig : IEntityTypeConfiguration<CalculationHistory>
    {
        public void Configure(EntityTypeBuilder<CalculationHistory> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.ApplicationUserId).IsRequired();
            builder.Property(c => c.CalculationDate).IsRequired();
            builder.Property(c => c.FirstNumber).IsRequired();
            builder.Property(c => c.SecondNumber).IsRequired();
            builder.Property(c => c.Result).IsRequired();
        }
    }
}
