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
       
        public ActionResult Index()
        {
            var lineSer = new LineService();
            var lineList = lineSer.getLines();

            return View(lineList);
        }

        public ActionResult AddLine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLine(LineVm line)
        {
            var lineSer = new LineService();
            lineSer.AddLine(line);

            return RedirectToAction("Index");
        }

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
        public ActionResult UpdateLine(LineVm line)
        {
            var lineSer = new LineService();
            lineSer.UpdateLine(line);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteLine(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var lineSer = new LineService();
            lineSer.DeleteLine(id.Value);

            return RedirectToAction("Index");
        }
    }
}