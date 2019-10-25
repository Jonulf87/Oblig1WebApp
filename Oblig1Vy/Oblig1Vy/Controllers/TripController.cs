using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1Vy.Controllers
{
    public class TripController : Controller
    {
        [Authorize(Roles = "admins")]
        public ActionResult Index()
        {
            var tripService = new TripService();
            var tripList = tripService.GetTrips();

            return View(tripList);
        }

        public ActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addtrip(TripVm trip)
        {
            var tripService = new TripService();
            tripService.AddTrip(trip, User.Identity.Name);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateTrip(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var tripService = new TripService();
            var trip = tripService.GetTrip(id.Value);

            return View(trip);
        }

        [HttpPost]
        public ActionResult UpdateTrip(TripVm trip)
        {
            var tripService = new TripService();
            tripService.UpdateTrip(trip, User.Identity.Name);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTrip(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var tripService = new TripService();
            tripService.DeleteTrip(id.Value, User.Identity.Name);

            return RedirectToAction("Index");
        }
    }
}