using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedAdmin(builder);

            SeedUser(builder);

            SeedRole(builder);

            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            var admin1 = new IdentityUser
            {
                Id = "1",
                UserName = "messi@gmail.com",
                Email = "messi@gmail.com",
                NormalizedUserName = "messi@gmail.com",
                EmailConfirmed = true,

            };

            var admin2 = new IdentityUser
            {
                Id = "2",
                UserName = "neymar@gmail.com",
                Email = "neymar@gmail.com",
                NormalizedUserName = "neymar@gmail.com",
                EmailConfirmed = true,
            };

            var admin3 = new IdentityUser
            {
                Id = "3",
                UserName = "suarez@gmail.com",
                Email = "suarez@gmail.com",
                NormalizedUserName = "suarez@gmail.com",
                EmailConfirmed = true,
            };
            var hasher = new PasswordHasher<IdentityUser>();
            admin1.PasswordHash = hasher.HashPassword(admin1, "123abc");
            admin2.PasswordHash = hasher.HashPassword(admin2, "234def");
            admin3.PasswordHash = hasher.HashPassword(admin3, "345ghi");

            builder.Entity<IdentityUser>().HasData(admin1, admin2, admin3);
        }

        private void SeedRole(ModelBuilder builder)
        {
            var admin1 = new IdentityRole
            {
                Id = "A",
                Name = "admin1",
                NormalizedName = "admin1",
            };
            var admin2 = new IdentityRole
            {
                Id = "B",
                Name = "admin2",
                NormalizedName = "admin2",
            };
            var admin3 = new IdentityRole
            {
                Id = "C",
                Name = "admin3",
                NormalizedName = "admin3",
            };

            builder.Entity<IdentityRole>().HasData(admin1, admin2, admin3);
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
              new IdentityUserRole<string>
              {
                  UserId = "1",
                  RoleId = "A"
              },
              new IdentityUserRole<string>
              {
                  UserId = "2",
                  RoleId = "B"
              },
              new IdentityUserRole<string>
              {
                  UserId = "3",
                  RoleId = "C"
              }
                );
        }

        private void SeedAdmin(ModelBuilder builder)
        {
            _ = builder.Entity<Admin>().HasData(
               new Admin
               {
                   Id = 1,
                   Name = "Lionel Messi",
                   Email = "messi@gmail.com",
                   //Username = "messi@gmail.com",
                  // Password = "123abc",
                   Image = "https://th.bing.com/th/id/OIP.ppTbS216xqtwuKSKk9TPjgHaHa?w=192&h=192&c=7&r=0&o=5&dpr=1.25&pid=1.7",
                   Address = "Hai Ba Trung, Ha Noi",
                   Birthday = DateTime.Parse("1987-06-24")

               },
               new Admin
               {
                   Id = 2,
                   Name = "Neymar JR",
                   Email = "neymar@gmail.com",
                 //  Username = "neymar@gmail.com",
                 //  Password = "234def",
                   Image = "https://th.bing.com/th/id/OIP.Ed1Z8KOePEbynj_lKvXECwHaHa?w=182&h=182&c=7&r=0&o=5&dpr=1.25&pid=1.7",
                   Address = "Thanh Xuan, Ha Noi",
                   Birthday  = DateTime.Parse("1992-05-02")
               },
               new Admin
               {
                   Id = 3,
                   Name = "Luis Suarez",
                   Email = "suarez@gmail.com",
                //   Username = "suarez@gmail.com",
                  // Password = "345ghi",
                   Image = "https://th.bing.com/th/id/OIP.-3q4r4KBQ_nTPbUp9vBhKgHaFP?w=236&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7",
                   Address = "Dong Da, Ha Noi",
                   Birthday = DateTime.Parse("1987-01-24")
               });
        }
    }
}
