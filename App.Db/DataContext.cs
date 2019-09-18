using System;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
            .HasData(new Value
            {
                Id = 1,
                Name = "Daniel"
            }, new Value
            {
                Id = 2,
                Name = "Katring"
            }, new Value
            {
                Id = 3,
                Name = "Nate"
            });
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
