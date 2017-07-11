using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


 
namespace wedding.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }  //or put in the[key]

        public string  WedderOne { get; set; }

        public string WedderTwo { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }
        
        // [Required]
        // [CompareAttribute("Password", ErrorMessage = "Password and Password Confrimation Must match :]")]
        // public string PasswrodConfirmation {get; set;}

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public List<Invitation> Invitations {get; set;}

        public User User {get; set;}

        public Wedding(){
            Invitations = new List<Invitation>();
        
        }
    }
}