using System;
using System.ComponentModel.DataAnnotations;
 
namespace rest.Models
{
    public class User
    {
        [Key]
        public int IdUsers { get; set; }

        [Required]
        [MinLength(3)]

        public string  first_name { get; set; }
 
        [Required]
        [MinLength(3)]

        public string res_name { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        public string star { get; set; }

        [Required]
        public DateTime date { get; set; }

    }
}