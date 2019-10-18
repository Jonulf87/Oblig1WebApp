using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.DAL
{
    public class TripRepository
    {
        public List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ois = db.OperationalIntervals
                    .Where(a => a.StartDate <= travelSearch.Date && a.EndDate >= travelSearch.Date);

                switch (travelSearch.Date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        ois = ois.Where(a => a.Sunday);
                        break;
                    case DayOfWeek.Monday:
                        ois = ois.Where(a => a.Monday);
                        break;
                    case DayOfWeek.Tuesday:
                        ois = ois.Where(a => a.Tuesday);
                        break;
                    case DayOfWeek.Wednesday:
                        ois = ois.Where(a => a.Wednesday);
                        break;
                    case DayOfWeek.Thursday:
                        ois = ois.Where(a => a.Thursday);
                        break;
                    case DayOfWeek.Friday:
                        ois = ois.Where(a => a.Friday);
                        break;
                    case DayOfWeek.Saturday:
                        ois = ois.Where(a => a.Saturday);
                        break;
                }

                var trips = ois.SelectMany(a => a.Trips)
                    .Where(a => a.Schedules.Any(b => b.StationId == travelSearch.DepartureId) && a.Schedules.Any(b => b.StationId == travelSearch.ArrivalId))
                    .ToList();

                var departureTimeList = new List<DepartureTimeVm>();

                foreach (var trip in trips)
                {
                    var arrivalSchedule = trip.Schedules.SingleOrDefault(a => a.StationId == travelSearch.ArrivalId);
                    var departureSchedule = trip.Schedules.SingleOrDefault(a => a.StationId == travelSearch.DepartureId);

                    if (departureSchedule.DepartureTime < arrivalSchedule.ArrivalTime)
                    {
                        var stops = trip.Schedules
                            .Where(a => a.DepartureTime > departureSchedule.DepartureTime && a.ArrivalTime < arrivalSchedule.ArrivalTime)
                            .OrderBy(a => a.DepartureTime)
                            .Select(a => new DepartureTimeStop
                            {
                                Name = a.Station.StationName,
                                DepartureTime = a.DepartureTime.Value
                            }).ToList();

                        departureTimeList.Add(new DepartureTimeVm
                        {
                            TripId = trip.Id,
                            DepartureStationId = travelSearch.DepartureId,
                            DepartureStation = departureSchedule.Station.StationName,
                            DepartureStationTime = departureSchedule.DepartureTime.Value,
                            ArrivalStationId = travelSearch.ArrivalId,
                            ArrivalStation = arrivalSchedule.Station.StationName,
                            ArrivalStationTime = arrivalSchedule.ArrivalTime.Value,
                            Stops = stops
                        });
                    }
                }

                return departureTimeList;
            }
        }

        public List<StationVm> GetStationsByName(string searchterm)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var stations = db.Stations.Where(a => a.StationName.StartsWith(searchterm)).Select(b => new StationVm
                {
                    StationId = b.Id,
                    StationName = b.StationName
                }).ToList();

                return stations;
            }
        }
    }
}
