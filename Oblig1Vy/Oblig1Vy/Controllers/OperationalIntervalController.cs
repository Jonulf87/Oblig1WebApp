using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1Vy.Controllers
{
    public class OperationalIntervalController : Controller
    {
        
        public ActionResult Index()
        {
            var oisService = new OperationalIntervalService();
            var oisList = oisService.GetOperationalIntervals();

            return View(oisList);
        }

        public ActionResult AddOis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOis(OperationalIntervalVm ois)
        {
            var oisService = new OperationalIntervalService();
            oisService.AddOis(ois);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateOis(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var oisService = new OperationalIntervalService();
            var ois = oisService.GetOperationalInterval(id.Value);

            return View(ois);
        }

        [HttpPost]
        public ActionResult UpdateOis(OperationalIntervalVm oisVm)
        {
            var oisService = new OperationalIntervalService();
            oisService.UpdateOperationalInterval(oisVm);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteOis(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var oisService = new OperationalIntervalService();
            oisService.DeleteOis(id.Value);

            return RedirectToAction("Index");

        }
    }
}