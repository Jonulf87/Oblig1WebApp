using Oblig1Vy.Models;
using Oblig1Vy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1Vy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TravelSearchVm travelSearch)
        {
            return RedirectToAction("DepartureTimes", travelSearch);
        }

        public ActionResult DepartureTimes(TravelSearchVm travelSearch)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ois = db.OperationalIntervals
                    .Where(a => a.StartDate <= travelSearch.Date && a.EndDate >= travelSearch.Date);

                //if (travelSearch.Date.DayOfWeek == DayOfWeek.Sunday)
                //{
                //    ois = ois.Where(a => a.Sunday);
                //}
                //else if (travelSearch.Date.DayOfWeek == DayOfWeek.Monday)
                //{
                //    ois = ois.Where(a => a.Monday);
                //}
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

                //var trips = db.OperationalIntervals
                //    .Where(a => a.StartDate <= travelSearch.Date && a.EndDate >= travelSearch.Date)
                //    .SelectMany(a => a.Trips)
                //    .Where(a => a.Schedules.Any(b => b.StationId == travelSearch.DepartureId) && a.Schedules.Any(b => b.StationId == travelSearch.ArrivalId))
                //    .ToList();

                ViewBag.TicketDate = travelSearch.Date;

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


                return View(departureTimeList);
            }
        }
        
        [HttpPost]
        public ActionResult DepartureTimes(TicketVm ticket)
        {
            var travelTicket = new Ticket
            {
                ArrivalStationId = ticket.ArrivalStationId,
                DepartureStationId = ticket.DepartureStationId,
                TripId = ticket.TripId,
                JourneyDate = ticket.Date
            };

            using (Oblig1Context db = new Oblig1Context())
            {
                db.Tickets.Add(travelTicket);
                db.SaveChanges();
            }

            return RedirectToAction("TicketSummary", new { id = travelTicket.Id });
        }

        public ActionResult TicketSummary(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ticket = db.Tickets.Find(id);

                var departureTime = ticket.Trip.Schedules.SingleOrDefault(a => a.StationId == ticket.DepartureStationId);

                var ticketSummaryVm = new TicketSummaryVm
                {
                    ArrivalStation = ticket.ArrivalStation.StationName,
                    DepartureStation = ticket.DepartureStation.StationName,
                    LineName = ticket.Trip.Line.LineName,
                    TicketDateAndTime = ticket.JourneyDate.Date.Add(departureTime.DepartureTime.Value)
                };

                return View(ticketSummaryVm);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult AutoComplete(string term)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var stations = db.Stations.Where(a => a.StationName.StartsWith(term)).Select(b => new AutoCompleteSearchVm
                {
                    StationId = b.Id,
                    StationName = b.StationName
                }).ToList();

                return Json(stations, JsonRequestBehavior.AllowGet);
            }
        }

    }

 
}