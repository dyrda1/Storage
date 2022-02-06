using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SkippedDays> SkippeddDays { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SkippedDaysConfiguration());
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Orders)
                .WithMany(o => o.Products)
                .UsingEntity(j => j.ToTable("OrderProducts"));

            builder.HasMany(p => p.Reports)
                .WithMany(r => r.Products)
                .UsingEntity(j => j.ToTable("ReportProducts"));
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Role).
                WithMany(r => r.Users).
                HasForeignKey(u => u.RoleId);
        }
    }

    public class SkippedDaysConfiguration : IEntityTypeConfiguration<SkippedDays>
    {
        public void Configure(EntityTypeBuilder<SkippedDays> builder)
        {
            builder.HasOne(d => d.User).
                WithOne(u => u.SkippeddDays).
                HasForeignKey<SkippedDays>(d=>d.UserId);
        }
    }
}
