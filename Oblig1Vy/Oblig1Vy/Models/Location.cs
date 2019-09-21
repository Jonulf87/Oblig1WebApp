using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }

        [InverseProperty("Departure")]
        public virtual List<TrainRoute> Departures { get; set; }

        [InverseProperty("Arrival")]
        public virtual List<TrainRoute> Arrivals { get; set; }
    }
}