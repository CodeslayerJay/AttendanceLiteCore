using AttendanceLite.Data.DbConfigurations;
using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Data
{
    public class ApplicationDbContext : DbContext, IAppDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   }


        //private readonly string _connString = "Server=(localdb)\\MSSQLLocalDB;Database=AttendanceLiteDb_Core;Trusted_Connection=True;MultipleActiveResultSets=true";

        //public ApplicationDbContext()
        //{ }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        optionsBuilder.UseSqlServer(_connString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var dbConfig = new DbConfig(builder);
            dbConfig.ConfigureCredentials();
            dbConfig.ConfigureTimeLog();
            dbConfig.ConfigureUser();
            dbConfig.ConfigureUserRole();
            dbConfig.ConfigureRole();

            base.OnModelCreating(builder);
        }
    }
}
