using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

       
        public String Username { get; set; }

       
        public String Password { get; set; }

        
        public String Email { get; set; }

        [ScaffoldColumn(false)]

        [Display(Name ="Picture")]
        public String ImageUrl { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedOn { get; set; }
    }
}