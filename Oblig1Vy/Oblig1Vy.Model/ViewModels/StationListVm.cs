using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class StationListVm
    {
        public int Id { get; set; }
        [Display(Name = "Stasjonsnavn")]
        public string StationName { get; set; }
    }
}
