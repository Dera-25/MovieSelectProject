namespace MovieSelect.API.Models
{
    public static class InMemoryDatabase
    {
        public static List<Genre> Genres { get; set; } = new List<Genre>
    {
        new Genre { Id = 1, Name = "Action" },
        new Genre { Id = 2, Name = "Comedy" },
        new Genre { Id = 3, Name = "Drama" },
        new Genre { Id = 4, Name = "Horror" },
        new Genre { Id = 5, Name = "Sci-Fi" },
        new Genre { Id = 6, Name = "Romance" },
        new Genre { Id = 7, Name = "Animation" }
    };

        public static List<Movie> Movies { get; set; } = new List<Movie>
    {
        new Movie { Id = 1, Title = "Die Hard", AgeRating = "R", GenreId = 1 },
        new Movie { Id = 2, Title = "The Mask", AgeRating = "PG-13", GenreId = 2 },
        new Movie { Id = 3, Title = "The Godfather", AgeRating = "R", GenreId = 3 },
        new Movie { Id = 4, Title = "The Conjuring", AgeRating = "R", GenreId = 4 },
        new Movie { Id = 5, Title = "Interstellar", AgeRating = "PG-13", GenreId = 5 },
        new Movie { Id = 6, Title = "Titanic", AgeRating = "PG-13", GenreId = 6 },
        new Movie { Id = 7, Title = "Toy Story", AgeRating = "G", GenreId = 7 },
        new Movie { Id = 8, Title = "Inception", AgeRating = "PG", GenreId = 5 },
        new Movie { Id = 9, Title = "The Avengers", AgeRating = "PG", GenreId = 1 },
        new Movie { Id = 10, Title = "22 Jump Street", AgeRating = "R", GenreId = 2 },
        new Movie { Id =11, Title = "John Wick", AgeRating = "R", GenreId = 1 },
        new Movie { Id = 12, Title = "Mean Girls", AgeRating = "PG-13", GenreId = 2 },
        new Movie { Id = 4, Title = "Mad Max: Fury Road", AgeRating = "R", GenreId = 1 },
        new Movie { Id = 5, Title = "Die Hard", AgeRating = "R", GenreId = 1 },
        new Movie { Id = 6, Title = "The Hangover", AgeRating = "R", GenreId = 2 },
        new Movie { Id = 7, Title = "Superbad", AgeRating = "R", GenreId = 2 },
        new Movie { Id = 8, Title = "The Shawshank Redemption", AgeRating = "R", GenreId = 3 },
        new Movie { Id = 9, Title = "Forrest Gump", AgeRating = "PG-13", GenreId = 3 },
        new Movie { Id = 10, Title = "The Conjuring", AgeRating = "R", GenreId = 4 },
        new Movie { Id = 11, Title = "A Quiet Place", AgeRating = "PG-13", GenreId = 4 },
        new Movie { Id = 12, Title = "Interstellar", AgeRating = "PG-13", GenreId = 5 },
        new Movie { Id = 13, Title = "The Matrix", AgeRating = "R", GenreId = 5 },
        new Movie { Id = 14, Title = "The Notebook", AgeRating = "PG-13", GenreId = 6 },
        new Movie { Id = 15, Title = "La La Land", AgeRating = "PG-13", GenreId = 6 },
        new Movie { Id = 16, Title = "Toy Story", AgeRating = "G", GenreId = 7 },
        new Movie { Id = 17, Title = "Frozen", AgeRating = "PG", GenreId = 7 },
        new Movie { Id = 18, Title = "Gladiator", AgeRating = "R", GenreId = 1 },
        new Movie { Id = 19, Title = "Step Brothers", AgeRating = "R", GenreId = 2 },
        new Movie { Id = 20, Title = "The Green Mile", AgeRating = "R", GenreId = 3 },
        new Movie { Id = 21, Title = "Insidious", AgeRating = "PG-13", GenreId = 4 },
        new Movie { Id = 22, Title = "Inception", AgeRating = "PG-13", GenreId = 5 },
        new Movie { Id = 23, Title = "Titanic", AgeRating = "PG-13", GenreId = 6 },
        new Movie { Id = 24, Title = "Shrek", AgeRating = "PG", GenreId = 7 }
    };
    }
}
