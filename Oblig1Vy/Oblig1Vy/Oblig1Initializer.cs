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
           var stations = new List<Station>
            {
                new Station() { StationName = "Stavanger" },
                new Station() { StationName = "Sandnes" },
                new Station() { StationName = "Egersund" },
                new Station() { StationName = "Audnedal" },
                new Station() { StationName = "Kristiansand" },
                new Station() { StationName = "Drangedal" },
                new Station() { StationName = "Kongsberg" },
                new Station() { StationName = "Drammen" },
                new Station() { StationName = "Asker" },
                new Station() { StationName = "Oslo S" },
                new Station() { StationName = "Trondheim" },
                new Station() { StationName = "Oppdal" },
                new Station() { StationName = "Dombås" },
                new Station() { StationName = "Vinstra" },
                new Station() { StationName = "Lillehammer" },
                new Station() { StationName = "Hamar" },
                new Station() { StationName = "Lillestrøm" }

            };

            context.Stations.AddRange(stations);

            context.SaveChanges();



            //Legger til Stavanger-Oslo
            //for (int i = 0; i < 30; i++)
            //{
            //    var morningRoute = new TrainRoute
            //    {
            //        ArrivalId = locations[0].Id,
            //        DepartureId = locations[2].Id,
            //        Cost = 299,
            //        DepartureTime = DateTime.Now.Date.AddHours(8).AddDays(i)
            //    };

            //    var eveningRoute = new TrainRoute
            //    {
            //        ArrivalId = locations[0].Id,
            //        DepartureId = locations[2].Id,
            //        Cost = 299,
            //        DepartureTime = DateTime.Now.Date.AddHours(16).AddDays(i)
            //    };

            //    context.TrainRoutes.Add(morningRoute);
            //    context.TrainRoutes.Add(eveningRoute);
            //}

            
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}