using System;
using Commerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Commerce.SqlDataAccess
{
    public class CommerceContext : DbContext
    {
        private readonly string _connectionString;

        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString should not be empty.", nameof(connectionString));
            _connectionString = connectionString;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }
    }
}