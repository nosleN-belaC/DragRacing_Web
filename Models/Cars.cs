using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Cars
    {
        [Key]
        public int Car_ID { get; set; }

        [Required]
        [Display(Name = "Make Name")]
        public string Make_Name { get; set;}

        [Required]
        [Display(Name = "Model Name")]
        public string Model_Name { get; set;}

        [Required]
        [Display(Name = "Tire Compound")]
        public string Tire_Compound { get; set; }

        [Required]
        [ForeignKey("Engines")]
        public int Engine_ID { get; set; }
        public Engines Engines { get; set; }

    }
}
