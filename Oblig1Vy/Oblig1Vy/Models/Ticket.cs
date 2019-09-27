using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime JourneyDate { get; set; }
        public decimal Price { get; set; }
        public virtual Trip Trip { get; set; }

    }
}