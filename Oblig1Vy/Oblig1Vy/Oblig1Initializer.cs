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
                new Station() { StationName = "Stavanger" }, //0
                new Station() { StationName = "Sandnes" }, //1
                new Station() { StationName = "Egersund" }, //2
                new Station() { StationName = "Audnedal" }, //3
                new Station() { StationName = "Kristiansand" }, //4
                new Station() { StationName = "Drangedal" }, //5
                new Station() { StationName = "Kongsberg" }, //6
                new Station() { StationName = "Drammen" }, //7
                new Station() { StationName = "Asker" }, //8
                new Station() { StationName = "Oslo S" }, //9
                new Station() { StationName = "Trondheim" }, //10
                new Station() { StationName = "Oppdal" }, //11
                new Station() { StationName = "Dombås" }, //12
                new Station() { StationName = "Vinstra" }, //13
                new Station() { StationName = "Lillehammer" }, //14
                new Station() { StationName = "Hamar" }, //15
                new Station() { StationName = "Lillestrøm" } //16

            };

            context.Stations.AddRange(stations);

            context.SaveChanges();

            var operations = new List<OperationalInterval>
            {
                new OperationalInterval() {
                    Name = "Vinterruter",
                    StartDate = DateTime.Parse("2019-09-28"),
                    EndDate = DateTime.Parse("2020-04-30"),
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,
                    Saturday = true,
                    Sunday = true
                },
                new OperationalInterval() {
                    Name = "Sommerruter",
                    StartDate = DateTime.Parse("2020-05-01"),
                    EndDate = DateTime.Parse("2020-08-31"),
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,
                    Saturday = true,
                    Sunday = true
                }
            };

            context.OperationalIntervals.AddRange(operations);

            context.SaveChanges();

            var lines = new List<Line>
            {
                new Line()
                {
                    LineName = "Stavanger - Oslo",
                    DepartureId = stations[0].Id,
                    ArrivalId = stations[9].Id,

                },
                new Line()
                {
                    LineName = "Oslo - Stavanger",
                    DepartureId = stations[9].Id,
                    ArrivalId = stations[0].Id,

                },
                new Line()
                {
                    LineName = "Trondheim - Oslo",
                    DepartureId = stations[10].Id,
                    ArrivalId = stations[9].Id,

                },
                new Line()
                {
                    LineName = "Oslo - Trondheim",
                    DepartureId = stations[9].Id,
                    ArrivalId = stations[10].Id,

                }
            };

            context.Lines.AddRange(lines);
            context.SaveChanges();

            var trips = new List<Trip>
            {
                new Trip()
                {
                    Line = lines[0],
                    DepartureTime = new TimeSpan(8, 47, 0),
                    ArrivalTime = new TimeSpan(16, 25, 0),
                    OperationalInterval = operations[0]
                },
                new Trip()
                {
                    Line = lines[1],
                    DepartureTime = new TimeSpan(7, 25, 0),
                    ArrivalTime = new TimeSpan(15, 05, 0),
                    OperationalInterval = operations[0]

                },
                new Trip()
                {
                    Line = lines[2],
                    DepartureTime = new TimeSpan(8, 18, 0),
                    ArrivalTime = new TimeSpan(15, 3, 0),
                    OperationalInterval = operations[0]

                },
                new Trip()
                {
                    Line = lines[3],
                    DepartureTime = new TimeSpan(8, 2, 0),
                    ArrivalTime = new TimeSpan(14, 31, 0),
                    OperationalInterval = operations[0]

                }
            };

            context.Trips.AddRange(trips);
            context.SaveChanges();

            var schedules = new List<Schedule>
            {
                //Schedules, stoppesteder, for alle på trip 0. 
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[0],
                    ArrivalTime = null,
                    DepartureTime = new TimeSpan(8, 47, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[1],
                    ArrivalTime = new TimeSpan(9, 0, 0),
                    DepartureTime = new TimeSpan(9, 0, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[2],
                    ArrivalTime = new TimeSpan(9, 40, 0),
                    DepartureTime = new TimeSpan(9, 40, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[3],
                    ArrivalTime = new TimeSpan(11, 1, 0),
                    DepartureTime = new TimeSpan(11, 1, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[4],
                    ArrivalTime = new TimeSpan(11, 45, 0),
                    DepartureTime = new TimeSpan(11, 45, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[5],
                    ArrivalTime = new TimeSpan(13, 55, 0),
                    DepartureTime = new TimeSpan(13, 55, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[6],
                    ArrivalTime = new TimeSpan(15, 17, 0),
                    DepartureTime = new TimeSpan(15, 17, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[7],
                    ArrivalTime = new TimeSpan(15, 51, 0),
                    DepartureTime = new TimeSpan(15, 51, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[8],
                    ArrivalTime = new TimeSpan(16, 3, 0),
                    DepartureTime = new TimeSpan(16, 3, 0),
                },
                new Schedule()
                {
                    Trip = trips[0],
                    Station = stations[9],
                    ArrivalTime = new TimeSpan(16, 25, 0),
                    DepartureTime = null,
                },
                
                
                //Schedules, stoppesteder, for alle på trip 1. 
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[9],
                    ArrivalTime = null,
                    DepartureTime = new TimeSpan(7, 25, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[8],
                    ArrivalTime = new TimeSpan(7, 45, 0),
                    DepartureTime = new TimeSpan(7, 45, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[7],
                    ArrivalTime = new TimeSpan(7, 58, 0),
                    DepartureTime = new TimeSpan(7, 58, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[6],
                    ArrivalTime = new TimeSpan(8, 34, 0),
                    DepartureTime = new TimeSpan(8, 34, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[5],
                    ArrivalTime = new TimeSpan(9, 56, 0),
                    DepartureTime = new TimeSpan(9, 56, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[4],
                    ArrivalTime = new TimeSpan(11, 53, 0),
                    DepartureTime = new TimeSpan(11, 53, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[3],
                    ArrivalTime = new TimeSpan(12, 45, 0),
                    DepartureTime = new TimeSpan(12, 45, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[2],
                    ArrivalTime = new TimeSpan(14, 6, 0),
                    DepartureTime = new TimeSpan(14, 6, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[1],
                    ArrivalTime = new TimeSpan(14, 50, 0),
                    DepartureTime = new TimeSpan(14, 50, 0),
                },
                new Schedule()
                {
                    Trip = trips[1],
                    Station = stations[0],
                    ArrivalTime = new TimeSpan(15, 5, 0),
                    DepartureTime = null,
                },


                //Schedule for trip 2
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[10],
                    ArrivalTime = null,
                    DepartureTime = new TimeSpan(8, 18, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[11],
                    ArrivalTime = new TimeSpan(9, 55, 0),
                    DepartureTime = new TimeSpan(9, 55, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[12],
                    ArrivalTime = new TimeSpan(10, 54, 0),
                    DepartureTime = new TimeSpan(10, 54, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[13],
                    ArrivalTime = new TimeSpan(11, 50, 0),
                    DepartureTime = new TimeSpan(11, 50, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[14],
                    ArrivalTime = new TimeSpan(12, 48, 0),
                    DepartureTime = new TimeSpan(12, 48, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[15],
                    ArrivalTime = new TimeSpan(13, 32, 0),
                    DepartureTime = new TimeSpan(13, 32, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[16],
                    ArrivalTime = new TimeSpan(14, 49, 0),
                    DepartureTime = new TimeSpan(14, 49, 0),
                },
                new Schedule()
                {
                    Trip = trips[2],
                    Station = stations[9],
                    ArrivalTime = new TimeSpan(15, 3, 0),
                    DepartureTime = null
                },


                //Schedules for trip 3
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[9],
                    ArrivalTime = null,
                    DepartureTime = new TimeSpan(8, 2, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[16],
                    ArrivalTime = new TimeSpan(8, 12, 0),
                    DepartureTime = new TimeSpan(8, 12, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[15],
                    ArrivalTime = new TimeSpan(9, 18, 0),
                    DepartureTime = new TimeSpan(9, 18, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[14],
                    ArrivalTime = new TimeSpan(10, 6, 0),
                    DepartureTime = new TimeSpan(10, 6, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[13],
                    ArrivalTime = new TimeSpan(11, 6, 0),
                    DepartureTime = new TimeSpan(11, 6, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[12],
                    ArrivalTime = new TimeSpan(12, 0, 0),
                    DepartureTime = new TimeSpan(12, 0, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[11],
                    ArrivalTime = new TimeSpan(12, 58, 0),
                    DepartureTime = new TimeSpan(12, 58, 0),
                },
                new Schedule()
                {
                    Trip = trips[3],
                    Station = stations[10],
                    ArrivalTime = new TimeSpan(14, 31, 0),
                    DepartureTime = null
                },
            };

            context.Schedules.AddRange(schedules);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}