using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Text { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedOn { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<Reply> Replies { get; set; }

    }
}