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
            var context = new Oblig1Context();

            return View();
        }

        [HttpPost]
        public ActionResult Index(TravelSearchVm travelSearch)
        {
            Oblig1Context db = new Oblig1Context();
            return RedirectToAction("DepartureTimes");
        }

        public ActionResult DepartureTimes()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var departureTimeResult = new DepartureTimeVm();
                //departureTimeResult.DepartureStation = db.Schedules.Where()
            }
            return View();
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