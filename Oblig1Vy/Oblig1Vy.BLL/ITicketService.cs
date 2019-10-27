using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public interface ITicketService
    {
        int AddTicket(TicketVm ticket);
        void FinalizeTicket(FinalizeTicketVm finalizeTicket);
        TicketSummaryVm GetTicketSummary(int id);
    }
}