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

            return RedirectToAction("Index");
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
    }
}