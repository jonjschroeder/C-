using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace wedding.Models
{
    public abstract class BaseEntity {} 
    public class User : BaseEntity
    {
        
        public int UserId { get; set; }  //or put in the[key]

        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        // [Required]
        // [CompareAttribute("Password", ErrorMessage = "Password and Password Confrimation Must match :]")]
        // public string PasswrodConfirmation {get; set;}

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Wedding> Weddings {get; set;}
        public List<Invitation> Invitations {get; set;}
        public User(){
            Weddings = new List<Wedding>();
            Invitations = new List<Invitation>();

        }
    }
}