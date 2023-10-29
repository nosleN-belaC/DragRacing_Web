using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Results
    {
        // This section represents the primary key field of this model.
        [Key]
        public int Result_ID { get; set; }

        // This section represents the foreign key/ drivers field of this model.
        [Required(ErrorMessage = "Please enter a valid driver."), MaxLength(10)] // This code creates an error message if the field does not have data in it.
        [Display(Name = "Driver")]
        [ForeignKey("Drivers")]
        public int Driver_ID { get; set; }
        public Drivers Drivers { get; set; }

        // This section represents the time field of this model.
        [Required(ErrorMessage = "Please enter a valid time."), MaxLength(15)]
        public string Time { get;set; }

        // This section represents the weather field of this model.
        [Required(ErrorMessage = "Please enter a valid weather type."), MaxLength(15)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid weather type starting with a captial letter.")]
        //The line of code above makes sure that the data entered into the field is valid and correct.
        public string Weather { get; set; }

        // This section represents the date field of this model.
        [Required(ErrorMessage = "Please enter a valid date."), MaxLength(15)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")] // This code makes sure the formating of the date is the correct way.
        public DateTime Date { get; set; }

        // This section represents the foreign key/ tracks field of this model.
        [Required(ErrorMessage = "Please enter a valid track."), MaxLength(10)]
        [Display(Name = "Track")] // This line of code changes how the name of the field is displayed. "Track" instead of "Tracks"
        [ForeignKey("Tracks")]
        public int Track_ID { get; set; }
        public Tracks Tracks { get; set; }

    }
}
