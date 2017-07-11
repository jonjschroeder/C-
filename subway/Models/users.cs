using System.ComponentModel.DataAnnotations;
 
namespace subway.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(3)]

        public string  FirstName { get; set; }
 
        [Required]
        [MinLength(3)]

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [CompareAttribute("Password", ErrorMessage = "Password and Password Confrimation Must match :]")]
        public string PasswordConfirm {get; set;}
    }
}