using Oblig1Vy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        

        public DbSet<Line> Lines { get; set; }
        public DbSet<OperationalInterval> OperationalIntervals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }

    }
}