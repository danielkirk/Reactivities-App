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
        public DbSet<Value> Values { get; set; }
    }
}
