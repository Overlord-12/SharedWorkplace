using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using SharedWorkplace.Models;
using System;

namespace DataBase
{
    public class BoardContext: DbContext
    {

        public virtual DbSet<Desk> Desks { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Server=localhost;Database=TesDesk;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed default roles
            string adminRoleName = "admin";
            string userRoleName = "user";
            Role adminRole = new() { Id = 1, RoleName = adminRoleName };
            Role userRole = new() { Id = 2, RoleName = userRoleName };

            // Seed default admin
            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";
            User adminUser = new() { Id = 1, Login = adminEmail, Name = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            string userEmail = "user.@mail.ru";
            string userPassword = "123456";
            User userUser = new() { Id = 2, Login = userEmail, Name = userEmail, Password = userPassword, RoleId = userRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, userUser});

            base.OnModelCreating(modelBuilder);
        }
    }
}
