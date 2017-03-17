using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Menu2
    {
        public int Menu2ID { get; set; }

        public string NameOfRest2 { get; set; }

        public string Type2 { get; set; }

        public string Name2 { get; set; }

        public int Stars2 { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
        public decimal Price2 { get; set; }

        public string Description2 { get; set; }

        public int Ingredients2 { get; set; }

        public string Location { get; set; }

        public string TypeOfMeat { get; set; }
    }
}
