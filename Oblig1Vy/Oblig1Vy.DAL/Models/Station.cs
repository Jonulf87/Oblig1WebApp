using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string StationName { get; set; }

        [InverseProperty("Departure")]
        public virtual List<Line> Departures { get; set; }

        [InverseProperty("Arrival")]
        public virtual List<Line> Arrivals { get; set; }
        public virtual List<Schedule> Schedules { get; set; }

    }
}