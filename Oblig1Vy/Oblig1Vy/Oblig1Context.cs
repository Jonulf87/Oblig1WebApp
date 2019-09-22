using Oblig1Vy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oblig1Vy
{
    public class Oblig1Context : DbContext
    {
        public Oblig1Context() : base("Oblig1Context")
        {
            Database.SetInitializer(new Oblig1Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainRoute>()
                    .HasRequired<Location>(p => p.Arrival)
                    .WithMany(t => t.Arrivals)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrainRoute>()
                    .HasRequired<Location>(p => p.Departure)
                    .WithMany(t => t.Departures)
                    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<TrainRoute> TrainRoutes { get; set; }
    }
}