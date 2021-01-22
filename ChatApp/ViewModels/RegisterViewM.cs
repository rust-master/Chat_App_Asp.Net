using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatApp.ViewModels
{
    public class RegisterViewM
    {
       
        public String Username { get; set; }

       
        public String Password { get; set; }

        
       
       

        public String ConfirmPassword { get; set; }

        
        public String Email { get; set; }
    }
}