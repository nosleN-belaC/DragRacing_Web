using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace DragRacing_Web.Models
{
    // This section represents the enum for the distance field in this model.
    public enum Distance
    {
        OneMile,
        ThreeQuartersMile,
        HalfMile,
        QuarterMile
    }
    public class Tracks
    {
        // This section represents the primary key field of this model.
        [Key]
        public int Track_ID { get; set; }

        // This section represents the name field of this model.
        [Required(ErrorMessage = "Please enter a valid name."), MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid name starting with a captial letter.")]
        //The line of code above makes sure that the data entered into the field is valid and correct.
        public string Name { get; set; }

        // This section represents the city field of this model.
        [Required(ErrorMessage = "Please enter a valid city."), MaxLength(30)] // This code creates an error message if the field does not have data in it.
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid city starting with a captial letter.")]
        public string City { get; set; }

        // This section represents the region field of this model.
        [Required(ErrorMessage = "Please enter a valid region."), MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid region starting with a captial letter.")]
        public string Region { get; set; }

        // This section represents the country field of this model.
        [Required(ErrorMessage = "Please enter a valid country."), MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s[A-Z][a-zA-Z]*){1,2}$", ErrorMessage = "Please enter a valid country starting with a captial letter.")]
        public string Country { get; set; }

        // This section represents the distance field of this model.
        [Required(ErrorMessage = "Please enter a valid distance."), MaxLength(20)]
        public Distance? Distance { get; set; }
    }
}
