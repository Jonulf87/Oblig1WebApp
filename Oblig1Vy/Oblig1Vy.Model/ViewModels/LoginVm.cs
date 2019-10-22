using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Oblig1Vy.Model.ViewModels
{
    public class LoginVm
    {
        [Required]
        [Display(Name = "Brukernavn")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Passord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
