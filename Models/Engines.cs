using System.ComponentModel.DataAnnotations;

namespace DragRacing_Web.Models
{
    public class Engines
    {
        [Key]
        public int Engine_ID { get; set; }

        [Required]
        [Display(Name = "Engine Type")]
        public string Engine_Type { get; set; }

        public bool Stock { get; set;}

        [Display(Name = "Naturally Aspirated")]
        public bool N_A { get; set;}

        [Required]
        [Display(Name = "Fuel Type")]
        public string Fuel_Type { get; set;}

        [Required]
        public string Tune { get; set;}
    }
}
