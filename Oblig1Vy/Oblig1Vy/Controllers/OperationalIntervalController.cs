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
    public class OperationalIntervalController : Controller
    {
        

        [HttpGet]
        public ActionResult Index()
        {
            var oisService = new OperationalIntervalService();
            var oisList = oisService.GetOperationalIntervals();

            return View(oisList);
        }

        [HttpGet]
        public ActionResult AddOis()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOis(OperationalIntervalVm ois)
        {
            var oisService = new OperationalIntervalService();
            oisService.AddOis(ois);

            return RedirectToAction("Index");
        }

        [HttpGet]
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
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOis(OperationalIntervalVm oisVm)
        {
            var oisService = new OperationalIntervalService();
            oisService.UpdateOperationalInterval(oisVm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteOis(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var oisService = new OperationalIntervalService();
            var oisDelete = oisService.GetOperationalInterval(id.Value);

            return View(oisDelete);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOis(int id)
        {
            var oisService = new OperationalIntervalService();
            oisService.DeleteOis(id);

            return RedirectToAction("Index");
        }
    }
}