using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatApp.ViewModels
{
    public class LoginViewM
    {
        [Required]
        public String Username { get; set; }

        [ Required, DataType(DataType.Password)]
        public String Password { get; set; }
    }
}