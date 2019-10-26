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
        private ITicketRepository _repository;

        public TicketService()
        {
            _repository = new TicketRepository();
        }

        public TicketService(ITicketRepository stub)
        {
            _repository = stub;
        }

        public int AddTicket(TicketVm ticket)
        {
            var ticketRepository = _repository;
            return ticketRepository.AddTicket(ticket);
        }

        public TicketSummaryVm GetTicketSummary(int id)
        {
            var ticketRepository = _repository;
            return ticketRepository.GetTicketSummary(id);
        }
    }
}
