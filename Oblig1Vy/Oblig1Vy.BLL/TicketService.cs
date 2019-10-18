using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public class TicketService
    {
        public int AddTicket(TicketVm ticket)
        {
            var ticketRepository = new TicketRepository();
            return ticketRepository.AddTicket(ticket);
        }

        public TicketSummaryVm GetTicketSummary(int id)
        {
            var ticketRepository = new TicketRepository();
            return ticketRepository.GetTicketSummary(id);
        }
    }
}
