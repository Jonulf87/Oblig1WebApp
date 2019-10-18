using Oblig1Vy.BLL;
using Oblig1Vy.Model.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Oblig1Vy.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TravelSearchVm travelSearch)
        {
            return RedirectToAction("DepartureTimes", travelSearch);
        }

        public ActionResult DepartureTimes(TravelSearchVm travelSearch) //Inneholder avgangsstasjon ID, ankomststasjon ID og dato for valgt tur/trip
        {
            ViewBag.TicketDate = travelSearch.Date;

            var tripService = new TripService();
            var departureTimeList = tripService.GetDepartureTimes(travelSearch);

            return View(departureTimeList);
        }
        
        [HttpPost]
        public ActionResult DepartureTimes(TicketVm ticket)
        {
            var ticketService = new TicketService();
            var ticketId = ticketService.AddTicket(ticket);

            return RedirectToAction("TicketSummary", new { id = ticketId });
        }

        public ActionResult TicketSummary(int id)
        {
            var ticketService = new TicketService();
            var ticketSummary = ticketService.GetTicketSummary(id);

            return View(ticketSummary);
        }

        public JsonResult AutoComplete(string term)
        {
            var tripService = new TripService();
            var stations = tripService.GetStationsByName(term);

            return Json(stations, JsonRequestBehavior.AllowGet);
        }

    }

 
}