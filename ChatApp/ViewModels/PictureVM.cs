using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatApp.ViewModels
{
    public class PictureVM
    {
        [Required]
     public HttpPostedFileWrapper Picture { get; set; }
    }
}