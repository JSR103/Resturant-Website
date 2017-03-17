using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class NMViewModel
    {
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public NewMessage newmes { get; set; }
        public NewMessage nm { get; set; }


    }
}
