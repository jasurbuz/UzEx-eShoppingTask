using e_Shopping.Data.Confiigurations;
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
            #region Relation
            builder.Entity<Client>()
                .HasMany<Bid>(client => client.Bids)
                .WithOne(bid => bid.Client);
                

            builder.Entity<Product>()
                .HasMany<Bid>(product => product.Bids)
                .WithOne(bid => bid.Product);

            #endregion
            
            #region Configuration

            builder.ApplyConfiguration(new ClientConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            #endregion
            
            base.OnModelCreating(builder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
