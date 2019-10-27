using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Model.ViewModels
{
    public class TicketVm
    {
        public int TripId { get; set; }
        public DateTime Date { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }
        public decimal Price { get; set; }
    }
}