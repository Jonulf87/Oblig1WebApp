using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public interface ITicketService
    {
        int AddTicket(TicketVm ticket);
        TicketSummaryVm GetTicketSummary(int id);
    }
}