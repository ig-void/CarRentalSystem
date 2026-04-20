using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental>Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Dell,51434;Database=Anubhav;User Id=Anubhav;Password=Anubhav;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<Customer>(c => c.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.Email )
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .IsRequired();
            modelBuilder.Entity<Car>()
                .Property(c => c.Model)
                .IsRequired();
            modelBuilder.Entity<Car>()
                .Property(c => c.Brand)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasData(new User { Id=1 , Email= "admin@gmail.com", Password = "admin123", IsAdmin = true});

            modelBuilder.Entity<Car>()
                .HasData(new Car {Id = 1 , Model ="Suv" , Brand = "Honda" , PricePerDay =2500 , IsAvailable=true,  IsActive= true },
                new Car { Id = 2, Model = "Rover", Brand = "Merc", PricePerDay = 500, IsAvailable = true, IsActive = true },
                new Car { Id = 3, Model = "Suv", Brand = "Bmw", PricePerDay = 5000, IsAvailable = true, IsActive = true }
                );
        }
    }
}
