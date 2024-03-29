﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class OperationalInterval
    {
        public int Id { get; set; }
        
        //Navnet på rutetilbudet f.eks. sommerruter eller vinterruter
        [Display(Name = "Operasjonsintervall")]
        public string Name { get; set; }
        [Display(Name = "Startdato")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Sluttdato")]
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
        public virtual List<Trip> Trips { get; set; }

    }
}