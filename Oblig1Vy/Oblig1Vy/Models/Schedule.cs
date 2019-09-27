using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Models
{
    public class Schedule
    {
        [Display]
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public virtual Station Station { get; set; }
        public virtual Trip Trip { get; set; }
    }
}