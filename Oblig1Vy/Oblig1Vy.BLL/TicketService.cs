using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITripRepository _tripRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
            _tripRepository = new TripRepository();
        }

        public TicketService(ITicketRepository ticketRepository, ITripRepository tripRepository)
        {
            _ticketRepository = ticketRepository;
            _tripRepository = tripRepository;
        }

        public int AddTicket(TicketVm ticket)
        {
            var basePrice = _tripRepository.GetPrice(ticket.TripId);
            var getNumberOfStops = _tripRepository.GetNumberOfStops(ticket.TripId, ticket.ArrivalStationId, ticket.DepartureStationId);
            var price = TripService.CalculatePrice(basePrice.BasePrice, basePrice.StopsPrice, getNumberOfStops);

            ticket.Price = price;

            return _ticketRepository.AddTicket(ticket);
        }

        public TicketSummaryVm GetTicketSummary(int id)
        {
            return _ticketRepository.GetTicketSummary(id);
        }

        public TicketVm GetTicket(int id)
        {
            return _ticketRepository.GetTicket(id);
        }
    }
}
