using JWTApp.Core.Domain;
using JWTApp.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JWTApp.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }
        public DbSet<Product> Products
        {
            get => this.Set<Product>();
        }
        public DbSet<Category> Category
        {
            get => this.Set<Category>();
        }
        public DbSet<AppUser> AppUser
        {
            get => this.Set<AppUser>();
        }
        public DbSet<AppRole> AppRole
        {
            get => this.Set<AppRole>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
