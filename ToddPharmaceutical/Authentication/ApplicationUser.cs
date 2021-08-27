using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToddPharmaceutical.Authentication
{
    public class ApplicationUser:IdentityUser
    {
        //[Required(ErrorMessage = "Please enter a User Name")]
        //public string UserName { get; set; }
        //[Required(ErrorMessage = "Please enter a Password")]
        //public string Password { get; set; }
    }
}
