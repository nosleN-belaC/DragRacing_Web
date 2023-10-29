using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Drivers
    {
        [Key]
        public int Driver_ID { get; set; }

        [Required(ErrorMessage = "Please enter a valid first name."), MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid first name starting with a captial letter.")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid last name."), MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid last name starting with a capital letter.")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid date of birth."), MaxLength(10)]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please enter a valid hometown."), MaxLength(10)]
        public string Hometown { get; set; }

        [Display(Name = "Racing Team")]
        public string Racing_Team { get; set; }

        [Required]
        [ForeignKey("Cars")]
        public int Car_ID { get; set; }
        public Cars Cars { get; set; }
    }
}
