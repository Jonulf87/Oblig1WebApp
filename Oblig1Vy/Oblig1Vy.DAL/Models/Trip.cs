using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        public virtual OperationalInterval OperationalInterval { get; set; }
        public int OperationalIntervalId { get; set; }
        public virtual Line Line { get; set; }
        public int LineId { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public decimal BasePrice { get; set; }
        public decimal StopsPrice { get; set; }
    }
}