using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Data.DbConfigurations
{
    public class DbConfig
    {
        private readonly ModelBuilder _builder;

        public DbConfig(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void ConfigureUser()
        {
            var entity = _builder.Entity<User>();
            entity.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(20);

            entity.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(20);

            entity.Property(x => x.LastFourSSN)
                .IsRequired(true);

            entity.HasMany(x => x.UserRoles)
                .WithOne(x => x.User);

        }

        public void ConfigureRole()
        {
            var entity = _builder.Entity<Role>();
            entity.Property(x => x.Name)
                .HasMaxLength(15)
                .IsRequired(true);

            entity.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role);
        }

        public void ConfigureUserRole()
        {
            var entity = _builder.Entity<UserRole>();
            entity.HasKey("UserId", "RoleId");
            entity.HasOne(x => x.User);
            entity.HasOne(x => x.Role);
            
        }

        public void ConfigureCredentials()
        {
            var entity = _builder.Entity<UserCredential>();
            entity.Property(x => x.Username)
                .IsRequired(true)
                .HasMaxLength(20);

            entity.Property(x => x.Password)
                .IsRequired(true)
                .HasMaxLength(15);

            entity.Property(x => x.Email)
                .HasMaxLength(20);

            entity.HasOne(x => x.User);
        }

        public void ConfigureTimeLog()
        {
            var entity = _builder.Entity<TimeLog>();
            entity.Property(x => x.IsCheckedIn)
                .HasDefaultValue(false);
            entity.Property(x => x.Type)
                .HasDefaultValue(LogType.AdminStamped);

            entity.HasOne(x => x.User);
        }
    }
}
