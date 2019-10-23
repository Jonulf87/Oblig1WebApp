using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oblig1Vy.BLL;

namespace Oblig1Vy.Controllers
{
    [Authorize(Roles = "admins")]
    public class StationController : Controller
    {
        
        public ActionResult Index()
        {
            var stationService = new StationService();
            var stationsList = stationService.GetStations();
            return View(stationsList);
        }

        public ActionResult AddStation()
        {
            return View();
        }

        public ActionResult UpdateStation()
        {
            return View();
        }

        public ActionResult DeleteStation()
        {
            return View();
        }
    }
}