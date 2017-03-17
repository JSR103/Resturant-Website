using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You must enter at least 2   characters")]
        [MaxLength(30, ErrorMessage = "You can only type 30 characters")]
        [Display(Name = "Subject Text")]
        public string Subject { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You must enter at least 2   characters")]
        [MaxLength(500, ErrorMessage = "You can only type 500 characters")]
        [Display(Name = "Body Text")]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        //public List<Message> Messages { get; set; }

        private List<NewMessage> newmes = new List<NewMessage>();

        public List<NewMessage> NewMessage { get { return newmes; } }

        //private List<Member> members = new List<Member>();
        //public List<Member> Members { get; }
    }
}
