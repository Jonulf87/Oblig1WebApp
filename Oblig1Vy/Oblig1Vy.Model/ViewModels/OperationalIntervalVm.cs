using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class OperationalIntervalVm
    {
        public int Id { get; set; }

        [Display(Name = "Intervallnavn")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Startdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sluttdato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Mandag")]
        public bool Monday { get; set; }

        [Display(Name = "Tirsdag")]
        public bool Tuesday { get; set; }

        [Display(Name = "Onsdag")]
        public bool Wednesday { get; set; }

        [Display(Name = "Torsdag")]
        public bool Thursday { get; set; }

        [Display(Name = "Fredag")]
        public bool Friday { get; set; }

        [Display(Name = "Lørdag")]
        public bool Saturday { get; set; }

        [Display(Name = "Søndag")]
        public bool Sunday { get; set; }
    }
}
