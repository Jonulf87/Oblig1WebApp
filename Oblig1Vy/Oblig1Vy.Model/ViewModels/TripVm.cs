using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class TripVm
    {
        public int Id { get; set; }

        public int OperationalIntervalId { get; set; }

        [Display(Name = "Operasjonsintervall")]
        public string OperationalIntervalName { get; set; }

        public int LineId { get; set; }

        [Display(Name = "Rute")]
        public string LineName { get; set; }

        [Display(Name = "Avgangstid")]
        [DataType(DataType.Time)]
        public string DepartureTime { get; set; }

        [Display(Name = "Ankomsttid")]
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; }

        public List<ScheduleVm> Schedules { get; set; }

        [Display(Name = "Grunnpris")]
        public decimal BasePrice { get; set; }

        [Display(Name = "Pris per stopp")]
        public decimal StopsPrice { get; set; }
    }
}
