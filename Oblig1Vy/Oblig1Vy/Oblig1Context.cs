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
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<TrainRoute> TrainRoutes { get; set; }
    }
}