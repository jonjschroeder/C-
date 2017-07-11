using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


 
namespace wedding.Models
{

    public class Invitation : BaseEntity
    {
        [Key]
        public int InvitationId { get; set; }  //or put in the[key]

        public int  UserId { get; set; }
        public User User { get; set; }

        public int WeddingId { get; set; }

        public Wedding Wedding { get; set; }
        
    }
}