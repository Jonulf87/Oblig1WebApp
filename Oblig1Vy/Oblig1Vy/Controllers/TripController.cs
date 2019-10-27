using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1Vy.Controllers
{
    [Authorize(Roles = "admins")]
    public class TripController : Controller
    {        

        [HttpGet]
        public ActionResult Index()
        {
            var tripService = new TripService();
            var tripList = tripService.GetTrips();

            return View(tripList);
        }

        [HttpGet]
        public ActionResult AddTrip()
        {
            SetDropdownsInViewBags();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addtrip(TripVm trip)
        {
            var tripService = new TripService();
            tripService.AddTrip(trip, User.Identity.Name);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTrip(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            SetDropdownsInViewBags();

            var tripService = new TripService();
            var trip = tripService.GetTrip(id.Value);

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTrip(TripVm trip)
        {
            var tripService = new TripService();
            tripService.UpdateTrip(trip, User.Identity.Name);

            return RedirectToAction("DetailsTrip", new { id = trip.Id});
        }

        [HttpGet]
        public ActionResult DeleteTrip(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var tripService = new TripService();
            var tripDelete = tripService.GetTrip(id.Value);

            return View(tripDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTrip(int id)
        {
            var tripService = new TripService();
            tripService.DeleteTrip(id, User.Identity.Name);

            return RedirectToAction("Index");
        }

        private void SetDropdownsInViewBags()
        {
            var operationalIntervalService = new OperationalIntervalService();
            var stationService = new StationService();
            var lineService = new LineService();

            ViewBag.Stations = stationService.GetStations()
                .OrderBy(a => a.StationName)
                .ToList();

            ViewBag.Ois = operationalIntervalService.GetOperationalIntervals()
                .OrderBy(a => a.Name)
                .Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                })
                .ToList();

            ViewBag.Lines = lineService.getLines()
                .OrderBy(a => a.LineName)
                .Select(a => new SelectListItem
                {
                    Text = a.LineName,
                    Value = a.Id.ToString()
                })
                .ToList();
        }

        public ActionResult DetailsTrip(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var tripService = new TripService();
            var trip = tripService.GetTrip(id.Value);

            return View(trip);
        }
    }
}