using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Cars
    {
        [Key]
        public int Car_ID { get; set; }

        [Required(ErrorMessage = "Please enter a valid make name."), MaxLength(15)]
        [Display(Name = "Make Name")]
        public string Make_Name { get; set;}

        [Required(ErrorMessage = "Please enter a valid model name."), MaxLength(15)]
        [Display(Name = "Model Name")]
        public string Model_Name { get; set;}

        [Required(ErrorMessage = "Please enter a valid tire compound."), MaxLength(15)]
        [Display(Name = "Tire Compound")]
        public string Tire_Compound { get; set; }

        [Required(ErrorMessage = "Please enter a valid engine."), MaxLength(15)]
        [ForeignKey("Engines")]
        public int Engine_ID { get; set; }
        public Engines Engines { get; set; }

    }
}
