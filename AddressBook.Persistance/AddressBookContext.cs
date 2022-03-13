using AddressBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AddressBook.Persistance
{
    public class AddressBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
                 .SetBasePath(@"C:\Users\User\source\repos\AddressBook\AddressBook.Persistance")
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connectionString = configBuilder.GetConnectionString("AddressBookConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .Property(p => p.PhysicalAddress).HasMaxLength(40);
        }
    }
}
