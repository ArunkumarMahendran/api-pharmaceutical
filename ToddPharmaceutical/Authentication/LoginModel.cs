using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToddPharmaceutical.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
    }
}
