using Oblig1Vy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oblig1Vy
{
    public class Oblig1Initializer : DropCreateDatabaseIfModelChanges<Oblig1Context>
    {
        protected override void Seed(Oblig1Context context)
        {
            var locations = new List<Location>
            {
                new Location() { LocationName = "Stavanger" },
                new Location() { LocationName = "Kristiansand" },
                new Location() { LocationName = "Oslo" },
                new Location() { LocationName = "Trondheim" }
            };

            context.Locations.AddRange(locations);

            context.SaveChanges();

            for (int i = 0; i < 30; i++)
            {
                var morningRoute = new TrainRoute
                {
                    ArrivalId = locations[0].Id,
                    DepartureId = locations[2].Id,
                    Cost = 299,
                    DepartureTime = DateTime.Now.Date.AddHours(8).AddDays(i)
                };

                var eveningRoute = new TrainRoute
                {
                    ArrivalId = locations[0].Id,
                    DepartureId = locations[2].Id,
                    Cost = 299,
                    DepartureTime = DateTime.Now.Date.AddHours(16).AddDays(i)
                };

                context.TrainRoutes.Add(morningRoute);
                context.TrainRoutes.Add(eveningRoute);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}