using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Oblig1Vy.DAL
{
    public class TripRepositoryStub : ITripRepository
    {
        public List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch)
        {
            var departureTimeList = new List<DepartureTimeVm>();

            var DepartureTimeStopList = new List<DepartureTimeStop>();
            var DepartureTimestop = new DepartureTimeStop()
            {
                Name = "Egersund",
                DepartureTime = new TimeSpan(12, 20, 0)
            };
            DepartureTimeStopList.Add(DepartureTimestop);
            DepartureTimeStopList.Add(DepartureTimestop);
            DepartureTimeStopList.Add(DepartureTimestop);

            var departureTime = new DepartureTimeVm()
            {
                TripId = 1,
                DepartureStationId = 1,
                DepartureStation = "Sandnes",
                DepartureStationTime = new TimeSpan(8, 47, 0),
                ArrivalStationId = 3,
                ArrivalStation = "Audnedal",
                ArrivalStationTime = new TimeSpan(16, 25, 0),
                Stops = DepartureTimeStopList
            };
                return departureTimeList;
        }

        public List<StationVm> GetStationsByName(string searchterm)
        {
            var stations = new List<StationVm>();
            var station1 = new StationVm()
            {
                StationId = 1,
                StationName = "Sandnes"
            };
            var station2 = new StationVm()
            {
                StationId = 2,
                StationName = "Egersund"
            };
            var station3 = new StationVm()
            {
                StationId = 3,
                StationName = "Audnedal"
            };
            stations.Add(station1);
            stations.Add(station2);
            stations.Add(station3);

            return stations;
        }

        public TripVm GetTrip(int id)
        {
            var trip = new TripVm
            {
                Id = 1,
                OperationalIntervalId = 1,
                OperationalIntervalName = "Sommerruter",
                LineId = 1,
                LineName = "Stavanger - Audnedal",
                DepartureTime = "12:15",
                ArrivalTime = "14:35"
            };

            return trip;
        }

        public List<TripVm> GetTrips()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var tripList = new List<TripVm>();
                var tripItem = new TripVm()
                {
                    Id = 1,
                    OperationalIntervalId = 1,
                    OperationalIntervalName = "Sommerruter",
                    LineId = 1,
                    LineName = "Stavanger - Audnedal",
                    DepartureTime = "12:15",
                    ArrivalTime = "14:35"
                };
                tripList.Add(tripItem);
                tripList.Add(tripItem);
                tripList.Add(tripItem);

                return tripList;
            }
        }

        public void UpdateTrip(TripVm tripVm, string userName)
        {
            
        }

        public int AddTrip(TripVm tripVm, string userName)
        {
            var trip = new Trip
            {
                Id = 1
            };
            return trip.Id;
        }

        public void DeleteTrip(int id, string userName)
        {
            
        }
    }
}
