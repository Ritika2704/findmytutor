using System.ComponentModel.DataAnnotations;

namespace findmytutor.Models.Entities
{
    public class States
    {
        [Key]
        public int state_id { get; set; }
        public string statename { get; set; }
    }
}