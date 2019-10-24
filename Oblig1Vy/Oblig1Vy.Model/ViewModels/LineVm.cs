using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class LineVm
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }

    }
}
