using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace E_commerce.Context
{
    public class ECommerceContext(DbContextOptions<ECommerceContext> options) : DbContext(options)
    {
        public DbSet<UserDetail> users {  get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<UserCredential> credentials { get; set; }
        public DbSet<OrderModel> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Optional: Make the relationship explict with Fluent API
            modelBuilder.Entity<UserDetail>()
                .HasOne(p => p.Credential)
                .WithOne(u => u.User)
                .HasForeignKey<UserDetail>(c => c.CredentialId);
            modelBuilder.Entity<OrderModel>()
                .HasOne(p => p.Product)
                .WithMany(u => u.Orders)
                .HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<OrderModel>()
                .HasOne(p => p.UserDetail)
                .WithMany(u => u.Orders)
                .HasForeignKey(c => c.UserId);
        }
    }
}
