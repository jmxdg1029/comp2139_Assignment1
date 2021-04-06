using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Assignment1.Models
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options)
            : base(options)
        { }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "1", CountryName = "Canada" },
                new Country { CountryId = "2", CountryName = "United States" },
                new Country { CountryId = "3", CountryName = "Philippiness" },
                new Country { CountryId = "4", CountryName = "India" }
            );
        }
    }
    
}
