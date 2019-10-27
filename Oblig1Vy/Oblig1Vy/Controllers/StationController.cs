using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.Controllers
{
    [Authorize(Roles = "admins")]
    public class StationController : Controller
    {
        private IStationService _StationBLL;

        public StationController()
        {
            _StationBLL = new StationService();
        }

        public StationController(IStationService stub)
        {
            _StationBLL = stub;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var stationService = _StationBLL;
            var stationsList = stationService.GetStations();
            return View(stationsList);
        }

        [HttpGet]
        public ActionResult AddStation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStation(StationVm station)
        {
            var stationService = _StationBLL;
            stationService.AddStation(station);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStation(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var stationService = _StationBLL;
            var station = stationService.GetStation(id.Value);

            return View(station);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStation(StationVm station)
        {
            var stationSer = _StationBLL;
            stationSer.UpdateStation(station);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DeleteStation(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var stationService = _StationBLL;
            var stationDelete = stationService.GetStation(id.Value);

            return View(stationDelete);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStation(int id)
        {
            var stationService = _StationBLL;
            stationService.DeleteStation(id);

            return RedirectToAction("Index");
        }
    }
}