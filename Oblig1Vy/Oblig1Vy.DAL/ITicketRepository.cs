using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public interface ITicketRepository
    {
        int AddTicket(TicketVm ticket);
        void FinalizeTicket(FinalizeTicketVm finalizeTicket);
        TicketSummaryVm GetTicketSummary(int id);
        TicketVm GetTicket(int id);
    }
}