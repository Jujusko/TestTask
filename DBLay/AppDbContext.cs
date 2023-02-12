using DBLay.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLay
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {
            Database.EnsureCreated();

        }
        //public AppDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=mysql;",
                new MySqlServerVersion(new Version(5, 7, 22))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TranzactionDate).IsRequired();
                entity.HasMany(d => d.Rows)
                  .WithOne(p => p.Order);
            });

            modelBuilder.Entity<RowInOrder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).IsRequired();
            });
        }
     
        public DbSet<Items> Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<RowInOrder> RowsInOrder { get; set; }

    }
}
