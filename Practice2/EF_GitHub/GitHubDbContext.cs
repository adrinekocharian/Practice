using EF_GitHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace EF_GitHub
{
    class GitHubDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Entities.Repository> Repositories { get; set; }

        public GitHubDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connectionString = configBuilder.GetConnectionString("GitHubDatabase");
            string connectionString2 = configBuilder.GetSection("ConnectionStrings")["OtherDatabase"];

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasIndex(x => x.Username)
                .IsUnique();
            //List<string> a = new List<string> { "csharp", "java"};
            // "csharp,java"

        }
    }
}
