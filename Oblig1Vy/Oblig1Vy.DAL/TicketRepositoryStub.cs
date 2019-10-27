using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.DAL
{
    public class TicketRepositoryStub : ITicketRepository
    {
        public int AddTicket(TicketVm ticket)
        {
            var travelTicket = new Ticket
            {
                ArrivalStationId = 9,
                DepartureStationId = 0,
                TripId = 1,
                JourneyDate = DateTime.Parse("2020-05-01"),
                Id = 25
            };

            return travelTicket.Id;
        }

        public TicketSummaryVm GetTicketSummary(int id)
        {

                return new TicketSummaryVm
                {
                    ArrivalStation = "Stavanger",
                    DepartureStation = "Oslo",
                    LineName = "Oslo - Stavanger",
                    TicketDateAndTime = DateTime.Parse("2020-05-01")
                };
        }

        public TicketVm GetTicket(int id)
        {
            return new TicketVm
            {
                TripId = 1,
                Date = DateTime.Now,
                DepartureStationId = 1,
                ArrivalStationId = 2,
                Price = 300
            };
        }
    }
}
