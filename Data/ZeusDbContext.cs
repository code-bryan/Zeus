﻿using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ZeusDbContext : DbContext
    {
        public ZeusDbContext(DbContextOptions<ZeusDbContext> options) : base(options)
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CoursesUsers> CoursesUsers { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserType>().HasKey(e => e.Id);
            builder.Entity<Gender>().HasKey(e => e.Id);
            builder.Entity<Course>().HasKey(e => e.Id);
            builder.Entity<Status>().HasKey(e => e.Id);
            builder.Entity<Career>().HasKey(e => e.Id);
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<Subject>().HasKey(e => e.Id);

            builder.Entity<UserType>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Gender>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Course>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Status>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<User>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Subject>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Career>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<UserType>().HasData(
                new UserType {Id = 1, Description = "Participante", CreatedAt = DateTime.Now}
            );

            builder.Entity<Gender>().HasData(
                new Gender {Id = 1, Description = "Masculino", CreatedAt = DateTime.Now},
                new Gender {Id = 2, Description = "Femenino", CreatedAt = DateTime.Now}
            );

            builder.Entity<Status>().HasData(
                new Status {Id = 1, Description = "Aprobado", CreatedAt = DateTime.Now},
                new Status {Id = 2, Description = "Reprobado", CreatedAt = DateTime.Now},
                new Status {Id = 3, Description = "En progreso", CreatedAt = DateTime.Now}
            );

            builder.Entity<Career>().HasData(
                new Career {Id = 1, Description = "Ingenieria de Software", CreatedAt = DateTime.Now}
            );
        }
    }
}