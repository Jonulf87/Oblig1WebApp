using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Oblig1Vy.ViewModels
{
    public class DepartureTimeVm
    {
        [DisplayName]
        public int TripId { get; set; }
        public string DepartureStation { get; set; }
        public int DepartureStationId { get; set; }
        public DateTime DepartureStationTime { get; set; }
        public string ArrivalStation { get; set; }
        public int ArrivalStationId { get; set; }
        public DateTime ArrivalStationTime { get; set; }
        public List<DepartureTimeStop> Stops { get; set; }

    }

    public class DepartureTimeStop
    {
        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}