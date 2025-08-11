namespace MovieSelect.API.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AgeRating { get; set; } = string.Empty;
        public int GenreId { get; set; }

        public virtual Genre? Genre { get; set; }
    }
    
}
