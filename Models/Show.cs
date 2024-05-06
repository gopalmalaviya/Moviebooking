namespace MovieBooking.Models
{
    public class Show
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public MovieDetails Movie { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Time { get; set; }

        public double Price { get; set; }
    }
}
