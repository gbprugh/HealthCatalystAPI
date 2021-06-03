using System;
using System.IO;
using HealthCatalyst.API.Models;
using HealthCatalyst.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthCatalyst.API.Contexts
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }

        private static string _connectionString;

        public PersonContext(DbContextOptions<PersonContext> opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        private static string connectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();
                    _connectionString = config.GetSection(key: "ConnectionStrings")["HealthCatalystDbConnection"];
                }
                return _connectionString;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interest>()
                .HasOne(i => i.Person)
                .WithMany(p => p.Interests)
                .HasForeignKey(i => i.Person_Id);

            modelBuilder.Entity<Person>(person =>
            {

                person.HasKey(x => x.Id);
                PersonSeeding.PersonSeedData().ForEach(x => modelBuilder.Entity<Person>().HasData(x));

            });
            PersonSeeding.InterestSeedData().ForEach(x => modelBuilder.Entity<Interest>().HasData(x));
        }
    }
}