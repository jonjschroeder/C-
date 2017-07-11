using System;
using System.ComponentModel.DataAnnotations;
 
namespace wedding.Models
{
    public class WeddingViewModel 
    {

        
        [Required]
        [MinLength(2)]
  
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2)]


        public string WedderTwo { get; set; }

        public DateTime Date { get; set; }
 
        [Required]
        public string Address { get; set; }



    }
}