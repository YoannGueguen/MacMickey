using MacMickey.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MacMickey.Dal.Mapping;

namespace MacMickey.Dal
{
    public class MacContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
<<<<<<< HEAD
        public DbSet<Person> Persons { get; set; }
=======
        public DbSet<BasketCard> BasketCards { get; set; }
>>>>>>> 4215c69867ab92acbbfaa422e565aa120b790fc4

        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Side> Sides { get; set; }

        public DbSet<Bread> Breads { get; set; }
        public DbSet<Baker> Bakers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }


        //Static constructor define initializer once and only once
        static MacContext()
        {
            //TODO : Find a solution to enable MacInitializer
            //Database.SetInitializer<MacContext>(new MacInitializer());
        }

        public MacContext()
        {
        }

        public MacContext(DbContextOptions options) 
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To define connection string by code only (ex: uwp, consoleapp...)
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MacMickeyDb;Integrated Security=True;MultipleActiveResultSets=True;");

            base.OnConfiguring(optionsBuilder);
        }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Default schema of database */
            modelBuilder.HasDefaultSchema("Configuration");

            /* Entities mapping */
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new BurgerMapping());
            modelBuilder.ApplyConfiguration(new BeverageMapping());
            modelBuilder.ApplyConfiguration(new SideMapping());
            modelBuilder.ApplyConfiguration(new DessertMapping());
            modelBuilder.ApplyConfiguration(new MenuMapping());

            modelBuilder.ApplyConfiguration(new BreadMapping());
            modelBuilder.ApplyConfiguration(new BakerMapping());
            modelBuilder.ApplyConfiguration(new BakerBreadMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
