using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime JourneyDate { get; set; }
        public decimal Price { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public int ArrivalStationId { get; set; }
        public virtual Station  ArrivalStation { get; set; }
        public int DepartureStationId { get; set; }
        public virtual Station DepartureStation { get; set; }


    }
}