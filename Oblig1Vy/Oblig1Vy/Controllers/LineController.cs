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
    public class LineController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var lineSer = new LineService();
            var lineList = lineSer.getLines();

            return View(lineList);
        }

        [HttpGet]
        public ActionResult AddLine()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLine(LineVm line)
        {
            var lineSer = new LineService();
            lineSer.AddLine(line);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateLine(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var lineSer = new LineService();
            var line = lineSer.GetLine(id.Value);

            return View(line);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLine(LineVm line)
        {
            var lineSer = new LineService();
            lineSer.UpdateLine(line);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteLine(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var lineSer = new LineService();
            var lineDelete = lineSer.GetLine(id.Value);

            return View(lineDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLine(int id)
        {
            

            var lineSer = new LineService();
            lineSer.DeleteLine(id);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult AutoComplete(string term)
        {
            var tripService = new TripService();
            var stations = tripService.GetStationsByName(term);

            return Json(stations, JsonRequestBehavior.AllowGet);
        }
    }
}