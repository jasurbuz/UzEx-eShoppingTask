using e_Shopping.Data.Models;
using e_Shopping.Data.Models.Indentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_Shopping.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne<Bid>(client => client.Bid)
                .WithOne(bid => bid.Client)
                .HasForeignKey<Bid>(bid => bid.ClientId);

            builder.Entity<Product>()
                .HasOne<Bid>(product => product.Bid)
                .WithOne(bid => bid.Product)
                .HasForeignKey<Bid>(bid => bid.ProductId);

            base.OnModelCreating(builder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
