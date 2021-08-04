using System;
using System.ComponentModel.DataAnnotations;

namespace NSE.Web.MVC.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [EmailAddress(ErrorMessage = "The format of the field {0} is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
