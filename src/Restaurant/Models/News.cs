using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class News
    {
        public string Title { get; set; }

        //Date
        public DateTime ReleaseDate { get; set; }

        //List of Writers
        public List<string> Writers { get; set; }

    
    }
}
