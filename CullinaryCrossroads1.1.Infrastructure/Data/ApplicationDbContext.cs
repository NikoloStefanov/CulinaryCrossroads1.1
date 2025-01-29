using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CullinaryCrossroads1._1.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CulinaryCrossroads1._1.Interface.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Food>()
                .HasOne(f => f.Agent)
                .WithMany()
                .HasForeignKey(f => f.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
           
            SeedUsers();
            builder.Entity<IdentityUser>().HasData(AgentUser, GuestUser);
            SeedAgent();
            builder.Entity<Agent>().HasData(Agent);
            SeedCategories();
            builder.Entity<Category>().HasData(AsianCuisine, BulgarianCuisine, ItalianCuisine, AmericanCuisine,
                Vegetarian, Vegan, Healthy, JustForConnoisseurs);

            base.OnModelCreating(builder);
        }

        private IdentityUser GuestUser;
        private IdentityUser AgentUser;
        private Agent Agent;
        private Category AsianCuisine;
        private Category BulgarianCuisine;
        private Category ItalianCuisine;
        private Category AmericanCuisine;
        private Category Vegetarian;
        private Category Vegan;
        private Category Healthy;
        private Category JustForConnoisseurs;
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");
        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }


        private void SeedCategories()
        {
            AsianCuisine = new Category()
            {
                Id = 1,
                Name = "Asian-Cuisine"
            };

            BulgarianCuisine = new Category()
            {
                Id = 2,
                Name = "Bulgarian-Cuisine"
            };

            ItalianCuisine = new Category()
            {
                Id = 3,
                Name = "Italian-Cuisine"
            };
            AmericanCuisine = new Category()
            {
                Id = 4,
                Name = "American-Cuisine"
            };
            Vegetarian = new Category()
            {
                Id = 5,
                Name = "Vegetarian"
            };
            Vegan = new Category()
            {
                Id = 6,
                Name = "Vegan"
            };
            Healthy = new Category()
            {
                Id = 7,
                Name = "Healthy"
            };
            JustForConnoisseurs = new Category()
            {
                Id = 8,
                Name = "Just-For-Connoisseurs"
            };
        }


    }
}
