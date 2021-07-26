using Microsoft.EntityFrameworkCore;
using PetShop.Backend.Lib.Data.Helper;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Backend.Lib.Data
{
    public class PetShopDbContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
        }
        /// <summary>
        /// Seed data to the database when the project start to run
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
