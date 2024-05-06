using System.ComponentModel.DataAnnotations;

namespace MovieBooking.Models
{
    public class MovieDetails
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set;}
        [Required]
        public string Genre { get; set; }


    }
}
