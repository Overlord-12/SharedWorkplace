using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SharedWorkplace.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is not specified")]
        public string Email { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "No password specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password was entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No password specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
