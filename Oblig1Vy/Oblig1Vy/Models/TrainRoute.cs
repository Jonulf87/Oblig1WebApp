using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class TrainRoute
    {
        public int Id { get; set; }
        public virtual Location Departure { get; set; }
        public int DepartureId { get; set; }
        public virtual Location Arrival { get; set; }
        public int ArrivalId { get; set; }
        public decimal Cost { get; set; }
        public DateTime DepartureTime { get; set; }
    }


    public class blash
    {
        //LAZY LOADING. Virtual, henter faktisk ikke navnet til departure før du faktisk accesserer det. Før det har den bare hentet Id.
        public void ASDF()
        {
            var a = new TrainRoute();
            var c = new Lazy<Location>();
            var b = a.Departure.LocationName;
        }
    }
}