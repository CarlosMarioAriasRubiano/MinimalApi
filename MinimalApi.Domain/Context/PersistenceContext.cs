using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Context
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config)
            : base(options)
        {
            this.config = config;
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<BuyerVehicle> BuyerVehicle { get; set; }
        public virtual DbSet<BuyerVehicleHistory> BuyerVehicleHistory { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("DevConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Buyer>();
            modelBuilder.Entity<BuyerVehicle>();
            modelBuilder.Entity<BuyerVehicleHistory>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Location>();
            modelBuilder.Entity<Vehicle>();
            modelBuilder.Entity<Invoice>();
            modelBuilder.Entity<Order>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
