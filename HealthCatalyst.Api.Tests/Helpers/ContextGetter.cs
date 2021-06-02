using HealthCatalyst.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HealthCatalyst.API.Tests.Helpers
{
    public class ContextGetter
    {
        private static string _connectionString;
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
        public static PersonContext GetSqlServerContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<PersonContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new PersonContext(dbContextOptions);
        }
    }
}
