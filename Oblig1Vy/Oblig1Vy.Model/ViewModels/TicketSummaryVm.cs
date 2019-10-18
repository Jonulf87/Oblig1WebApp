using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Model.ViewModels
{
    public class TicketSummaryVm
    {
        [DisplayName("Fra")]
        public string DepartureStation { get; set; }
        [DisplayName("Til")]
        public string ArrivalStation { get; set; }
        [DisplayName("Avgang")]
        public DateTime TicketDateAndTime { get; set; }
        [DisplayName("Rute")]
        public string LineName { get; set; }

    }
}