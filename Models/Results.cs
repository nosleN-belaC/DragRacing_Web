using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragRacing_Web.Models
{
    public class Results
    {
        [Key]
        public int Result_ID { get; set; }

        [Required]
        [ForeignKey("Drivers")]
        public int Driver_ID { get; set; }
        public Drivers Drivers { get; set; }

        [Required]
        public string Time { get;set; }

        [Required]
        public string Weather { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Tracks")]
        public int Track_ID { get; set; }
        public Tracks Tracks { get; set; }

    }
}
