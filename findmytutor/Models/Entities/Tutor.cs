using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace findmytutor.Models.Entities
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int State { get; set; }
        public int City {  get; set; }
        public string Address { get; set; }


    }
}