
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public virtual Station Departure { get; set; }
        public int DepartureId { get; set; }
        public virtual Station Arrival { get; set; }
        public int ArrivalId { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}