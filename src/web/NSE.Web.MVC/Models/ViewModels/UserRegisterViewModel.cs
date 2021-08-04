using System;
using System.ComponentModel.DataAnnotations;

namespace NSE.Web.MVC.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage="The field {0} is mandatory.")]
        [EmailAddress(ErrorMessage = "The field {0} is not a valid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1}", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password is not the same")]
        [Display(Name ="Confirm your Passowrd")]
        public string ConfPassword { get; set; }

    }
}
