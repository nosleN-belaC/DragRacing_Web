using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Drivers
    {
        [Key]
        public int Driver_ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime DOB { get; set; }

        [Required]
        public string Hometown { get; set; }

        [Display(Name = "Racing Team")]
        public string Racing_Team { get; set; }

        [Required]
        [ForeignKey("Cars")]
        public int Car_ID { get; set; }
        public Cars Cars { get; set; }
    }
}
