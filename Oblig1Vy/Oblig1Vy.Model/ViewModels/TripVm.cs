using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class TripVm
    {
        public int Id { get; set; }
        public int OperationalIntervalId { get; set; }
        public string OperationalIntervalName { get; set; }
        public int LineId { get; set; }
        public string LineName { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

    }
}
