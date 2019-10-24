using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.Model.ViewModels
{
    public class StationVm
    {
        public int StationId { get; set; }
        [Display(Name = "Stasjonsnavn")]
        public string StationName { get; set; }
    }
}