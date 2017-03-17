using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Menu1
    {
        public int Menu1ID { get; set; }

        public string NameOfRest1 { get; set; }

        public string Type1 { get; set; }

        public string Name1 { get; set; }

        public int Stars1 { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
        public decimal Price1 { get; set; }

        public string Description1 { get; set; }

        public int Ingredients1 { get; set; }

        public string Location { get; set; }

        public string TypeOfMeat { get; set; }

    }
}
