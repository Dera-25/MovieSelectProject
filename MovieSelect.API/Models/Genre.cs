namespace MovieSelect.API.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual List<Movie>? movies { get; set; }
    }
}
