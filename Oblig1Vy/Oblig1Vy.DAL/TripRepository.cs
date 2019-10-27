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
    public class TripRepository : ITripRepository
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

        public PriceVm GetPrice(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var price = db.Trips.Where(a => a.Id == id).Select(b => new PriceVm
                {
                    BasePrice = b.BasePrice,
                    StopsPrice = b.StopsPrice
                }).SingleOrDefault();

                return price;
            }

            

        }

        public TripVm GetTrip(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var trip = db.Trips.Where(a => a.Id == id).ToList().Select(a => new TripVm
                {
                    Id = a.Id,
                    OperationalIntervalId = a.OperationalIntervalId,
                    OperationalIntervalName = a.OperationalInterval.Name,
                    LineId = a.LineId,
                    LineName = a.Line.LineName,
                    DepartureTime = a.DepartureTime.ToString(@"hh\:mm"),
                    ArrivalTime = a.ArrivalTime.ToString(@"hh\:mm"),
                    Schedules = a.Schedules.Select(b => new ScheduleVm
                    {
                        ArrivalTime = b.ArrivalTime,
                        DepartureTime = b.DepartureTime,
                        Id = b.Id,
                        StationId = b.StationId,
                        StationName = b.Station.StationName
                    }).ToList()
                }).SingleOrDefault();

                return trip;
            }
        }

        public List<TripVm> GetTrips()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var tripList = db.Trips
                    .Include(a => a.Line)
                    .Include(a => a.OperationalInterval)
                    .Include(a => a.Schedules)
                    .ToList()
                    .Select(a => new TripVm
                    {
                        Id = a.Id,
                        OperationalIntervalId = a.OperationalIntervalId,
                        OperationalIntervalName = a.OperationalInterval.Name,
                        LineId = a.LineId,
                        LineName = a.Line.LineName,
                        ArrivalTime = a.ArrivalTime.ToString(@"hh\:mm"),
                        DepartureTime = a.DepartureTime.ToString(@"hh\:mm"),
                        Schedules = a.Schedules.Select(b => new ScheduleVm
                        {
                            ArrivalTime = b.ArrivalTime,
                            DepartureTime = b.DepartureTime,
                            Id = b.Id,
                            StationId = b.StationId,
                            StationName = b.Station.StationName
                        }).ToList()
                    }).ToList();

                return tripList;
            }
        }

        public void UpdateTrip(TripVm tripVm, string userName)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var tripDb = db.Trips.Where(a => a.Id == tripVm.Id).SingleOrDefault();

                if (tripDb != null)
                {
                    var auditLog = new AuditLog
                    {
                        TimeStamp = DateTime.Now,
                        Model = nameof(Trip),
                        Type = AuditType.Updated,
                        User = userName
                    };

                    var sb = new StringBuilder();

                    if (tripDb.LineId != tripVm.LineId)
                    {
                        sb.AppendLine($"Updated Line from: {tripDb.Line.LineName} To: {tripVm.LineName}");
                    }

                    if (tripDb.OperationalIntervalId != tripVm.OperationalIntervalId)
                    {
                        sb.AppendLine($"Updated OperationalInterval from: {tripDb.OperationalInterval.Name} To: {tripVm.OperationalIntervalName}");
                    }

                    if (tripDb.LineId != tripVm.LineId)
                    {
                        sb.AppendLine($"Updated Line from: {tripDb.Line.LineName} To: {tripVm.LineName}");
                    }

                    var arrivalTime = TimeSpan.Parse(tripVm.ArrivalTime);
                    var departureTime = TimeSpan.Parse(tripVm.DepartureTime);

                    if (tripDb.ArrivalTime != arrivalTime)
                    {
                        sb.AppendLine($"Updated ArrivalTime from: {tripDb.ArrivalTime} To: {arrivalTime}");
                    }

                    if (tripDb.DepartureTime != departureTime)
                    {
                        sb.AppendLine($"Updated DepartureTime from: {tripDb.DepartureTime} To: {departureTime}");
                    }

                    auditLog.Log = sb.ToString();

                    tripDb.OperationalIntervalId = tripVm.OperationalIntervalId;
                    tripDb.LineId = tripVm.LineId;
                    tripDb.ArrivalTime = arrivalTime;
                    tripDb.DepartureTime = departureTime;

                    if (tripVm.Schedules == null || tripVm.Schedules.Count == 0)
                    {
                        db.Schedules.RemoveRange(tripDb.Schedules);
                    }
                    else
                    {
                        var scheduleIds = tripVm.Schedules.Select(a => a.Id).ToList();
                        var schedulesToRemove = tripDb.Schedules.Where(a => !scheduleIds.Contains(a.Id));
                        var schedulesToUpdate = tripDb.Schedules.Where(a => scheduleIds.Contains(a.Id));
                        var schedulesToAdd = tripVm.Schedules.Where(a => a.Id == 0);

                        if (schedulesToRemove.Any())
                        {
                            db.Schedules.RemoveRange(schedulesToRemove);
                        }

                        foreach (var schedule in schedulesToUpdate)
                        {
                            var scheduleVm = tripVm.Schedules.Single(a => a.Id == schedule.Id);

                            schedule.StationId = scheduleVm.StationId;
                            schedule.ArrivalTime = scheduleVm.ArrivalTime;
                            schedule.DepartureTime = scheduleVm.DepartureTime;
                        }

                        foreach (var schedule in schedulesToAdd)
                        {
                            tripDb.Schedules.Add(new Schedule
                            {
                                StationId = schedule.StationId,
                                ArrivalTime = schedule.ArrivalTime,
                                DepartureTime = schedule.DepartureTime
                            });
                        }
                    }

                    if (!string.IsNullOrEmpty(auditLog.Log))
                    {
                        db.AuditLogs.Add(auditLog);
                    }

                    db.SaveChanges();
                }
            }
        }

        public int AddTrip(TripVm tripVm, string userName)
        {
            var trip = new Trip
            {
                OperationalIntervalId = tripVm.OperationalIntervalId,
                LineId = tripVm.LineId,
                ArrivalTime = TimeSpan.Parse(tripVm.ArrivalTime),
                DepartureTime = TimeSpan.Parse(tripVm.DepartureTime)
            };

            if (tripVm.Schedules != null)
            {
                trip.Schedules = tripVm.Schedules.Select(a => new Schedule
                {
                    ArrivalTime = a.ArrivalTime,
                    DepartureTime = a.DepartureTime,
                    StationId = a.StationId
                }).ToList();
            }

            using (Oblig1Context db = new Oblig1Context())
            {
                db.Trips.Add(trip);
                db.SaveChanges();
            }

            return trip.Id;
        }

        public void DeleteTrip(int id, string userName)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var tripDelete = db.Trips.SingleOrDefault(a => a.Id == id);

                //Husk å legge if på flere singleordefault

                if (tripDelete != null)
                {
                    foreach (var schedule in tripDelete.Schedules.ToList())
                    {
                        db.Schedules.Remove(schedule);
                    }

                    db.Trips.Remove(tripDelete);
                    db.SaveChanges();
                }
            }
        }

        public int GetNumberOfStops(int tripId, int departureStationId, int arrivalStationId)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var trip = db.Trips.SingleOrDefault(a => a.Id == tripId);

                var arrivalSchedule = trip.Schedules.SingleOrDefault(a => a.StationId == arrivalStationId);
                var departureSchedule = trip.Schedules.SingleOrDefault(a => a.StationId == departureStationId);

                return trip.Schedules
                    .Where(a => a.DepartureTime > departureSchedule.DepartureTime && a.ArrivalTime < arrivalSchedule.ArrivalTime)
                    .Count();
            }
        }
    }
}
