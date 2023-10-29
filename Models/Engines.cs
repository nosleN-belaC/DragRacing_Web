using System.ComponentModel.DataAnnotations;

namespace DragRacing_Web.Models
{
    public class Engines
    {
        [Key]
        public int Engine_ID { get; set; }

        [Required(ErrorMessage = "Please enter a valid engine type."), MaxLength(15)]
        [Display(Name = "Engine Type")]
        public string Engine_Type { get; set; }

        public bool Stock { get; set; }

        [Display(Name = "Naturally Aspirated")]
        public bool N_A { get; set; }

        [Required(ErrorMessage = "Please enter a valid fuel type."), MaxLength(15)]
        [Display(Name = "Fuel Type")]
        public string Fuel_Type { get; set;}

        [Required(ErrorMessage = "Please enter a valid tune."), MaxLength(15)]
        public string Tune { get; set;}
    }
}
