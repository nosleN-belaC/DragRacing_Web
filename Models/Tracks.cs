using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace DragRacing_Web.Models
{
    public enum Distance
    {
        OneMile,
        ThreeQuartersMile,
        HalfMile,
        QuarterMile
    }
    public class Tracks
    {
        [Key]
        public int Track_ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public Distance? Distance { get; set; }
    }
}
