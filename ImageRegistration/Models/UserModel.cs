using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageRegistration.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required..!!")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email is required..!!")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is required..!!")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Image is required..!!")]
        public String Image { get; set; }

    }
}