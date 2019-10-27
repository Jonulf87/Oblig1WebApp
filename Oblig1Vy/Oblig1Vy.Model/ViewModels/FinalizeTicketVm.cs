using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.Model.ViewModels
{
    public class FinalizeTicketVm
    {
        public int TicketId { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
    }
}