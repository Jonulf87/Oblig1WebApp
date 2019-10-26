using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class LineVm
    {
        public int Id { get; set; }
        [Display(Name = "Rute")]
        public string LineName { get; set; }
        public int DepartureStationId { get; set; }
        public int ArrivalStationId { get; set; }
        [Display(Name = "Avgangsstasjon")]
        public string DepartureStation { get; set; }
        [Display(Name = "Ankomststasjon")]
        public string ArrivalStation { get; set; }

    }
}
