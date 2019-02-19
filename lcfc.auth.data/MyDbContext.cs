using lcfc.auth.data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.data
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=mydb;uid=root;pwd=my123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Domain
            modelBuilder.Entity<Domain>().HasKey(u => u.Id);
            modelBuilder.Entity<Domain>().HasIndex(u => u.Name).IsUnique();
            //Location
            modelBuilder.Entity<Location>().HasKey(u => u.Code);
            modelBuilder.Entity<Location>().HasIndex(u => new { u.Domain, u.Name }).IsUnique();
            modelBuilder.Entity<Location>().HasOne(u => (Location)u.Parent)
                .WithOne()
                .HasForeignKey<Location>("ParentCode")
                .HasPrincipalKey<Location>(u => u.Code);
                
            //Account
            modelBuilder.Entity<Account>().HasKey(u => u.Number);
            modelBuilder.Entity<Account>().HasIndex(u => u.Email);
            modelBuilder.Entity<Account>().HasIndex(u => u.MobileNum);
            modelBuilder.Entity<Account>().HasIndex(u => u.Domain);
            modelBuilder.Entity<Account>().HasOne(u => (Account)u.Parent)
                .WithOne()
                .HasForeignKey<Account>("ParentNumber")
                .HasPrincipalKey<Account>(u => u.Number);

            //Passport
            modelBuilder.Entity<Passport>().HasKey(u => u.Id);
            modelBuilder.Entity<Passport>().HasIndex(u => new { u.LoginName, u.Domain }).IsUnique();
            modelBuilder.Entity<Passport>().HasIndex(u => u.Account);
            //Role
            modelBuilder.Entity<Role>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().HasIndex(u => new { u.Name, u.Domain }).IsUnique();
            //AccountRoleMap
            modelBuilder.Entity<AccountRoleMap>().HasKey(u => new { u.Account, u.RoleId });
            //RoleModuleMap
            modelBuilder.Entity<RoleModuleMap>().HasKey(u => new { u.RoleId, u.Name });
            modelBuilder.Entity<RoleModuleMap>().HasIndex(u => new { u.Title, u.Domain }).IsUnique();
        }

        public DbSet<Domain> Domain { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Account> Account { get; set; }

        public DbSet<Passport> Passport { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<AccountRoleMap> AccountRoleMap { get; set; }

        public DbSet<RoleModuleMap> RoleModuleMap { get; set; }
    }
}
