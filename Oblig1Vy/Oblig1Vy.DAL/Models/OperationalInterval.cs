using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1Vy.DAL.Models
{
    public class OperationalInterval
    {
        public int Id { get; set; }
        
        //Navnet på rutetilbudet f.eks. sommerruter eller vinterruter
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public virtual List<Trip> Trips { get; set; }

    }
}