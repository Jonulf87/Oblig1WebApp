using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Model.ViewModels
{
    public class ScheduleVm
    {
        public int Id { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? ArrivalTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? DepartureTime { get; set; }

        public int StationId { get; set; }

        public string StationName { get; set; }
    }
}