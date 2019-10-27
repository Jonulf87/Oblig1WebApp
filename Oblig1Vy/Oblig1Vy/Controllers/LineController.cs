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
        private ILineService _LineBLL;

        public LineController()
        {
            _LineBLL = new LineService();
        }

        public LineController(ILineService stub)
        {
            _LineBLL = stub;
        }

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
            SetStationsViewBag();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLine(LineVm line)
        {
            if (!ModelState.IsValid)
            {
                SetStationsViewBag();
                return View(line);
            }

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

            SetStationsViewBag();

            var lineSer = new LineService();
            var line = lineSer.GetLine(id.Value);

            return View(line);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLine(LineVm line)
        {
            if (!ModelState.IsValid)
            {
                SetStationsViewBag();
                return View(line);
            }

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

        private void SetStationsViewBag()
        {
            var stationService = new StationService();

            ViewBag.Stations = stationService.GetStations().OrderBy(a => a.StationName)
                .Select(a => new SelectListItem
                {
                    Value = a.StationId.ToString(),
                    Text = a.StationName
                }).ToList();
        }
    }
}