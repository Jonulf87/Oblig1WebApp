using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class Schedule
    {
        [Display]
        public int Id { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public virtual Station Station { get; set; }
        public int StationId { get; set; }
        public virtual Trip Trip { get; set; }
        public int TripId { get; set; }
    }
}