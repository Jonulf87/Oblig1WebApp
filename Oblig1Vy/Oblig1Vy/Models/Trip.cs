using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        public virtual OperationalInterval OperationalInterval { get; set; }
        public virtual Line Line { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}