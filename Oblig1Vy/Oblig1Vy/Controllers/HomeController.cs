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

                var trips = ois.SelectMany(a => a.Trips)
                    .Where(a => a.Schedules.Any(b => b.StationId == travelSearch.DepartureId) && a.Schedules.Any(b => b.StationId == travelSearch.ArrivalId))
                    .ToList();

                List<DepartureTimeVm> departureTimeList = new List<DepartureTimeVm>();

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
                            DepartureStationTime = departureSchedule.DepartureTime.Value,
                            ArrivalStationId = travelSearch.ArrivalId,
                            ArrivalStationTime = arrivalSchedule.ArrivalTime.Value,
                            Stops = stops
                        });
                    }
                }


                return View(departureTimeList);
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