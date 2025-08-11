using Microsoft.AspNetCore.Mvc;
using MovieSelect.API.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<object>> GetAll()
    {
        var result = InMemoryDatabase.Movies.Select(m => new
        {
            m.Id,
            m.Title,
            m.AgeRating,
            Genre = InMemoryDatabase.Genres.FirstOrDefault(g => g.Id == m.GenreId)?.Name ?? "Unknown"
        }).ToList();

        return Ok(result);
    }
    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        var genre = InMemoryDatabase.Genres.FirstOrDefault(g => g.Id == movie.GenreId);

        // Return an object with both movie data and genre name
        return Ok(new
        {
            movie.Id,
            movie.Title,
            movie.AgeRating,
            Genre = genre != null ? genre.Name : "Unknown"
        });
    }
    // GET: api/movies/genre/{genreId}
    [HttpGet("genre/{genreId}")]
    public ActionResult<IEnumerable<Movie>> GetByGenre(int genreId)
    {
        var movies = InMemoryDatabase.Movies.Where(m => m.GenreId == genreId).ToList();
        return Ok(movies);
    }



    [HttpPost]
    public ActionResult<Movie> Create(Movie movie)
    {
        movie.Id = InMemoryDatabase.Movies.Count > 0
            ? InMemoryDatabase.Movies.Max(m => m.Id) + 1
            : 1;
        InMemoryDatabase.Movies.Add(movie);
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie updatedMovie)
    {
        var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();

        movie.Title = updatedMovie.Title;
        movie.GenreId = updatedMovie.GenreId;
        movie.AgeRating = updatedMovie.AgeRating;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = InMemoryDatabase.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();

        InMemoryDatabase.Movies.Remove(movie);
        return NoContent();
    }
}
