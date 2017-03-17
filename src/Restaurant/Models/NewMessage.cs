using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class NewMessage
    {
        public int NewMessageID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters")]
        [Display(Name = "Subject Text")]
        public string Subject { get; set; }

        [Required]
        //  [MaxLength(175, ErrorMessage = "You can only post 175 characters")]
        [MinLength(5, ErrorMessage = "You must enter at least 5 characters")]
        [MaxLength(175, ErrorMessage = "You can only type 175 characters")]
        [Display(Name = "Body Text")]
        public string Body { get; set; }

       
        //[Display(Name = "Member Text")]
       // public Member From { get; set; }
       
    }
}
