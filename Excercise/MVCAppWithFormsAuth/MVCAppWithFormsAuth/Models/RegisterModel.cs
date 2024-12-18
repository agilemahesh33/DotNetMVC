using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAppWithFormsAuth.Models
{
    public class RegisterModel
    {
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "Can't leave the field empty.")]
        [RegularExpression("[A-Za-z0-9]{6,20}", ErrorMessage = "User Id value is invalid.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Can't leave the field empty.")]
        [RegularExpression("[A-Za-z\\s]{3,50}", ErrorMessage = "Name value is invalid.")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Can't leave the field empty.")]
        [RegularExpression("[A-Z]{1}[a-z0-9@#$%_-]{7,15}", ErrorMessage = "Password is invalid.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Can't leave the field empty.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Can't leave the field empty.")]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Phone is invalid.")]
        public string Mobile { get; set; }
    }
}