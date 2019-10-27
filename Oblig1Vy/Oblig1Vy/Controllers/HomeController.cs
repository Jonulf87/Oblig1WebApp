using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Oblig1Vy.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            throw new Exception("Test");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TravelSearchVm travelSearch)
        {
            return RedirectToAction("DepartureTimes", travelSearch);
        }

        [HttpGet]
        public ActionResult DepartureTimes(TravelSearchVm travelSearch) //Inneholder avgangsstasjon ID, ankomststasjon ID og dato for valgt tur/trip
        {
            if (travelSearch != null)
            {
                ViewBag.TicketDate = travelSearch.Date;
            }

            var tripService = new TripService();
            var departureTimeList = tripService.GetDepartureTimes(travelSearch);

            return View(departureTimeList);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DepartureTimes(TicketVm ticket)
        {
            var ticketService = new TicketService();
            var ticketId = ticketService.AddTicket(ticket);

            return RedirectToAction("TicketSummary", new { id = ticketId });
        }

        [HttpGet]
        public ActionResult TicketSummary(int id)
        {
            var ticketService = new TicketService();
            var ticketSummary = ticketService.GetTicketSummary(id);

            return View(ticketSummary);
        }

        [HttpGet]
        public JsonResult AutoComplete(string term)
        {
            var tripService = new TripService();
            var stations = tripService.GetStationsByName(term);

            return Json(stations, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}