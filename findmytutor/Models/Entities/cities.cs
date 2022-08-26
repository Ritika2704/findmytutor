using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace findmytutor.Models.Entities
{
    public class cities
    {
        public string city_name { get; set; }
        [Key]
        public int city_id { get; set; }

       // [ForeignKey("state_id")]
        public int state_id { get; set; }
    }
}